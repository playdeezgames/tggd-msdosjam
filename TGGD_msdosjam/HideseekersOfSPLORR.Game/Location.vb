Imports HideseekersOfSPLORR.Data

Public Class Location
    Sub New(locationId As Long)
        Me.Id = locationId
    End Sub
    Sub New(x As Integer, y As Integer)
        Dim candidate = LocationData.ReadForXY(x, y)
        If candidate.HasValue Then
            Id = candidate.Value
        Else
            Id = LocationData.Create(x, y)
        End If
    End Sub
    ReadOnly Property Id As Long
    ReadOnly Property X As Integer
        Get
            Return LocationData.ReadX(Id).Value
        End Get
    End Property
    ReadOnly Property Y As Integer
        Get
            Return LocationData.ReadY(Id).Value
        End Get
    End Property
End Class
