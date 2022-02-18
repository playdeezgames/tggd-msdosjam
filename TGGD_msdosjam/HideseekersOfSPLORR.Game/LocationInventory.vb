Imports HideseekersOfSPLORR.Data

Public Class LocationInventory
    Private locationId As Long
    Sub New(locationId As Long)
        Me.locationId = locationId
    End Sub
    ReadOnly Property IsEmpty As Boolean
        Get
            Return LocationItemData.ReadCountForLocation(locationId) = 0
        End Get
    End Property
    ReadOnly Property Items As IList(Of Item)
        Get
            Return LocationItemData.ReadForLocation(locationId).Select(AddressOf Item.FromId).ToList()
        End Get
    End Property
End Class
