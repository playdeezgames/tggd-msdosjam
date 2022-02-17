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
End Class
