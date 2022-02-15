Imports HideseekersOfSPLORR.Data
Public Module Game
    Private characterId As Long? = Nothing
    ReadOnly Property PlayerCharacter As Character
        Get
            If Not characterId.HasValue Then
                Dim location = New Location(RNG.FromRange(0, 100), RNG.FromRange(0, 100))
                characterId = CharacterData.Create(location.Id, RNG.FromRange(0, 4))
            End If
            Return New Character(characterId.Value)
        End Get
    End Property
    Sub Start()
        Store.Start()
    End Sub
    Sub Finish()
        characterId = Nothing
        Store.Finish()
    End Sub
End Module
