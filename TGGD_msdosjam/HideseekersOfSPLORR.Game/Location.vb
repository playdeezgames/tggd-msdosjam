Imports HideseekersOfSPLORR.Data

Public Class Location
    Private locationId As ULong

    Sub New(locationId As ULong)
        Me.locationId = locationId
    End Sub
    Sub New(x As Integer, y As Integer)
        Dim candidate = LocationData.ReadForXY(x, y)
        If candidate.HasValue Then
            locationId = candidate.Value
        Else
            locationId = LocationData.Create(x, y)
        End If
    End Sub
    ReadOnly Property Id As ULong
        Get
            Return locationId
        End Get
    End Property
    ReadOnly Property X As Integer
        Get
            Return LocationData.ReadX(locationId).Value
        End Get
    End Property
    ReadOnly Property Y As Integer
        Get
            Return LocationData.ReadY(locationId).Value
        End Get
    End Property
End Class
