Imports HideseekersOfSPLORR.Data
Public Module Game
    Private characterId As ULong? = Nothing
    ReadOnly Property PlayerCharacter As Character
        Get
            If Not characterId.HasValue Then
                characterId = CharacterData.Create()
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
