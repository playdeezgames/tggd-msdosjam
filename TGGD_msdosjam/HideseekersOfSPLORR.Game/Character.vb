Public Class Character
    Private characterId As ULong
    Sub New(characterId As ULong)
        Me.characterId = characterId
    End Sub
    ReadOnly Property Id As ULong
        Get
            Return characterId
        End Get
    End Property
End Class
