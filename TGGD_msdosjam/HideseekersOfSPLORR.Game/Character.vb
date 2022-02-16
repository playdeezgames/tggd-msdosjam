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
            Return New Location(CharacterData.ReadLocationId(characterId).Value)
        End Get
    End Property
    ReadOnly Property Facing As Direction
        Get
            Return CType(CharacterData.ReadFacing(characterId).Value, Direction)
        End Get
    End Property
    Sub TurnLeft()
        TurnRight()
        TurnRight()
        TurnRight()
    End Sub
    Sub TurnRight()
        CharacterData.WriteFacing(characterId, (CharacterData.ReadFacing(characterId).Value + 1) Mod 4)
    End Sub
    Sub TurnAround()
        TurnRight()
        TurnRight()
    End Sub
    Sub MoveAhead()
        Dim characterX As Integer = Me.Location.X
        Dim characterY As Integer = Me.Location.Y
        Select Case Facing
            Case Direction.North
                characterY -= 1
            Case Direction.South
                characterY += 1
            Case Direction.East
                characterX += 1
            Case Direction.West
                characterX -= 1
            Case Else
                Throw New NotImplementedException()
        End Select
        Dim location As New Location(characterX, characterY)
        CharacterData.WriteLocationId(characterId, location.Id)
    End Sub
    Sub MoveRight()
        TurnRight()
        MoveAhead()
        TurnLeft()
    End Sub
    Sub MoveLeft()
        TurnLeft()
        MoveAhead()
        TurnRight()
    End Sub
    Sub MoveBack()
        TurnAround()
        MoveAhead()
        TurnAround()
    End Sub
End Class
