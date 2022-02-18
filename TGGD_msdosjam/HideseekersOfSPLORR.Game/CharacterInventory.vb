Imports HideseekersOfSPLORR.Data

Public Class CharacterInventory
    Private ReadOnly characterId As Long
    Sub New(characterId As Long)
        Me.characterId = characterId
    End Sub
    ReadOnly Property IsEmpty As Boolean
        Get
            Return CharacterItemData.ReadCountForCharacter(characterId) = 0
        End Get
    End Property
    ReadOnly Property Items As IList(Of Item)
        Get
            Return CharacterItemData.ReadForCharacter(characterId).Select(AddressOf Item.FromId).ToList()
        End Get
    End Property
    Sub AddItem(item As Item)
        CharacterItemData.Write(characterId, item.Id)
    End Sub
    ReadOnly Property CanCraft As Boolean
        Get
            Return Recipes.All.Any(Function(recipe)
                                       Return CanCraftRecipe(recipe)
                                   End Function)
        End Get
    End Property
    Function CanCraftRecipe(recipe As Recipe) As Boolean
        Dim stock As New Dictionary(Of ItemType, Integer)
        For Each item In Items
            If stock.ContainsKey(item.ItemType) Then
                stock(item.ItemType) += 1
            Else
                stock(item.ItemType) = 1
            End If
        Next
        For Each input In recipe.Inputs
            If Not stock.ContainsKey(input.Key) OrElse input.Value > stock(input.Key) Then
                Return False
            End If
        Next
        Return True
    End Function
    ReadOnly Property CraftableRecipes As IList(Of Recipe)
        Get
            Return Recipes.All.Where(AddressOf CanCraftRecipe).ToList()
        End Get
    End Property
    Function CraftRecipe(recipe As Recipe) As Boolean
        Dim character As New Character(characterId)
        Dim inputs As New Dictionary(Of ItemType, Integer)(recipe.Inputs)
        Dim consumed As New List(Of Item)
        For Each item In Items
            If inputs.ContainsKey(item.ItemType) AndAlso inputs(item.ItemType) > 0 Then
                inputs(item.ItemType) -= 1
                consumed.Add(item)
            End If
        Next
        For Each item In consumed
            item.Destroy()
        Next
        If character.Characteristics.Check(recipe.Characteristic, recipe.Difficulty).IsSuccess Then
            For Each output In recipe.SuccessOutputs
                Dim count = output.Value
                While count > 0
                    Dim itemId = ItemData.Create(output.Key)
                    CharacterItemData.Write(characterId, itemId)
                    count -= 1
                End While
            Next
            Return True
        Else
            For Each output In recipe.FailureOutputs
                Dim count = output.Value
                While count > 0
                    Dim itemId = ItemData.Create(output.Key)
                    CharacterItemData.Write(characterId, itemId)
                    count -= 1
                End While
            Next
            Return False
        End If
    End Function
End Class
