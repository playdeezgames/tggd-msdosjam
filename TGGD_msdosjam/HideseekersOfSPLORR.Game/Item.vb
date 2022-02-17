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
        CharacterItemData.ClearForItem(Id)
        'drop it on the ground
    End Sub
End Class
