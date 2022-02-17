Imports HideseekersOfSPLORR.Data

Public Class Item
    Sub New(itemId As Long)
        Me.Id = itemId
    End Sub
    ReadOnly Property Id As Long
    ReadOnly Property Name As String
        Get
            Dim itemType As ItemType = CType(ItemData.ReadItemType(Id), ItemType)
            Return itemType.GetName
        End Get
    End Property
    ReadOnly Property Description As String
        Get
            Dim itemType As ItemType = CType(ItemData.ReadItemType(Id), ItemType)
            Return itemType.GetDescription
        End Get
    End Property
    Shared Function FromId(itemId As Long) As Item
        Return New Item(itemId)
    End Function
    Public Overrides Function ToString() As String
        Return Name
    End Function
    Sub Drop()
        Dim characterId = CharacterItemData.ReadForItem(Id)
        If characterId.HasValue Then
            CharacterItemData.ClearForItem(Id)
            LocationItemData.Write(CharacterData.ReadLocationId(characterId.Value).Value, Id)
        End If
    End Sub
End Class
