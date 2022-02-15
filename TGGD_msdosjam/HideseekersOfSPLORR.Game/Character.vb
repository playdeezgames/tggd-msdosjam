Imports HideseekersOfSPLORR.Data

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
    ReadOnly Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocationForCharacter(characterId).Value)
        End Get
    End Property
End Class
