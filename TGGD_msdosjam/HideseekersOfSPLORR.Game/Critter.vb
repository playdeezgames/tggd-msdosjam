Imports HideseekersOfSPLORR.Data

Public Class Critter
    ReadOnly Property Id As Long
    Sub New(critterId As Long)
        Id = critterId
    End Sub
    Public Overrides Function ToString() As String
        Dim critterType = CritterData.ReadCritterType(Id)
        If critterType IsNot Nothing Then
            Return CType(critterType.Value, CritterType).GetName
        Else
            Return ""
        End If
    End Function
End Class
