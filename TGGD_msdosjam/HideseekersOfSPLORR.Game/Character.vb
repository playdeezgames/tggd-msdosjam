Imports HideseekersOfSPLORR.Data

Public Class Character
    Sub New(characterId As Long)
        Me.Id = characterId
    End Sub
    ReadOnly Property Id As Long
    ReadOnly Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocationId(Id).Value)
        End Get
    End Property
    ReadOnly Property Facing As Direction
        Get
            Return CType(CharacterData.ReadFacing(Id).Value, Direction)
        End Get
    End Property
    ReadOnly Property Inventory As CharacterInventory
        Get
            Return New CharacterInventory(Id)
        End Get
    End Property
    Private Shared Function GenerateCharacterStatistics(characteristic As Characteristic) As Integer
        Return RNG.RollDice(2, 6)
    End Function
    ReadOnly Property Characteristics As CharacteristicSet
        Get
            Return New CharacteristicSet(CharacterData.ReadCharacteristicSetId(Id).Value, AddressOf GenerateCharacterStatistics)
        End Get
    End Property
    Sub TurnLeft()
        TurnRight()
        TurnRight()
        TurnRight()
    End Sub
    Sub TurnRight()
        CharacterData.WriteFacing(Id, (CharacterData.ReadFacing(Id).Value + 1) Mod 4)
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
        CharacterData.WriteLocationId(Id, location.Id)
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
    Function Forage() As Item
        If Characteristics.Check(Characteristic.Education, TaskDifficulty.Average).IsSuccess Then
            Dim foragedItem = Location.DetermineForagedItem()
            If foragedItem IsNot Nothing Then
                Inventory.AddItem(foragedItem)
            End If
            Return foragedItem
        End If
        Return Nothing
    End Function
    ReadOnly Property CanAttack As Boolean
        Get
            Return Inventory.HasItemType(ItemType.Spear)
        End Get
    End Property
    ReadOnly Property Hunger As Integer
        Get
            Return CharacterData.ReadHunger(Id).Value
        End Get
    End Property
    ReadOnly Property Score As Integer
        Get
            Return CharacterData.ReadScore(Id).Value
        End Get
    End Property
End Class
