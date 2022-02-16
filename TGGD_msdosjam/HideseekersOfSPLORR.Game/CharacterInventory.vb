Public Class CharacterInventory
    Private ReadOnly characterId As Long
    Sub New(characterId As Long)
        Me.characterId = characterId
    End Sub
    ReadOnly Property IsEmpty As Boolean
        Get
            Return True
        End Get
    End Property
End Class
