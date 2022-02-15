Imports HideseekersOfSPLORR.Data

Public Class Character
    Private characterId As Long
    Sub New(characterId As Long)
        Me.characterId = characterId
    End Sub
    ReadOnly Property Id As Long
        Get
            Return characterId
        End Get
    End Property
    ReadOnly Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocationForCharacter(characterId).Value)
        End Get
    End Property
    ReadOnly Property Facing As Direction
        Get
            Return CType(CharacterData.ReadFacing(characterId).Value, Direction)
        End Get
    End Property
End Class
