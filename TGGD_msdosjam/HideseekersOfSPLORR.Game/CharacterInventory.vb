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
End Class
