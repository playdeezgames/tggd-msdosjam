Imports HideseekersOfSPLORR.Data

Public Class Item
    Sub New(itemId As Long)
        Me.Id = itemId
    End Sub
    ReadOnly Property Id As Long
    ReadOnly Property Name As String
        Get
            Dim itemType = ItemData.ReadItemType(Id)
            If itemType.HasValue Then
                Return CType(itemType.Value, ItemType).GetName()
            End If
            Return ""
        End Get
    End Property
    ReadOnly Property Description As String
        Get
            Dim itemType As ItemType = CType(ItemData.ReadItemType(Id), ItemType)
            Return itemType.GetDescription
        End Get
    End Property
    ReadOnly Property ItemType As ItemType
        Get
            Return CType(ItemData.ReadItemType(Id), ItemType)
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
    Sub PickUp(character As Character)
        If character IsNot Nothing Then
            LocationItemData.ClearForItem(Id)
            CharacterItemData.Write(character.Id, Id)
        End If
    End Sub
    Sub Destroy()
        ItemData.Destroy(Id)
    End Sub
End Class
