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
End Class
