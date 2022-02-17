Imports HideseekersOfSPLORR.Data

Public Class CharacteristicSet
    Private ReadOnly characteristicSetId As Long
    Private ReadOnly characteristicGenerator As Func(Of Characteristic, Integer)
    Sub New(characteristicSetId As Long, characteristicGenerator As Func(Of Characteristic, Integer))
        Me.characteristicSetId = characteristicSetId
        Me.characteristicGenerator = characteristicGenerator
    End Sub
    Public Function GetCharacteristic(characteristic As Characteristic) As Integer
        Dim value = CharacteristicData.Read(characteristicSetId, CInt(characteristic))
        If value Is Nothing Then

            value = New Tuple(Of Integer, Integer)(characteristicGenerator(characteristic), 0)
            CharacteristicData.Write(characteristicSetId, CInt(characteristic), value.Item1, value.Item2)
        End If
        Return value.Item1 + value.Item2
    End Function
    Public Function GetDiceModifier(characteristic As Characteristic) As Integer
        Select Case GetCharacteristic(characteristic)
            Case 0 To 2
                Return -2
            Case 3 To 5
                Return -1
            Case 6 To 8
                Return 0
            Case 9 To 11
                Return 1
            Case 12 To 14
                Return 2
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    ReadOnly Property Strength As Integer
        Get
            Return GetCharacteristic(Characteristic.Strength)
        End Get
    End Property
    ReadOnly Property Dexterity As Integer
        Get
            Return GetCharacteristic(Characteristic.Dexterity)
        End Get
    End Property
    ReadOnly Property Endurance As Integer
        Get
            Return GetCharacteristic(Characteristic.Endurance)
        End Get
    End Property
    ReadOnly Property Intellect As Integer
        Get
            Return GetCharacteristic(Characteristic.Intellect)
        End Get
    End Property
    ReadOnly Property Education As Integer
        Get
            Return GetCharacteristic(Characteristic.Education)
        End Get
    End Property
    ReadOnly Property Social As Integer
        Get
            Return GetCharacteristic(Characteristic.Social)
        End Get
    End Property
    Private Shared Function DetermineDifficultyModifier(difficulty As TaskDifficulty) As Integer
        Select Case difficulty
            Case TaskDifficulty.Simple
                Return 6
            Case TaskDifficulty.Easy
                Return 4
            Case TaskDifficulty.Routine
                Return 2
            Case TaskDifficulty.Average
                Return 0
            Case TaskDifficulty.Difficult
                Return -2
            Case TaskDifficulty.VeryDifficult
                Return -4
            Case Else
                Return -6
        End Select
    End Function
    Function Check(characteristic As Characteristic, difficulty As TaskDifficulty) As TaskEffect
        Dim modifier As Integer = DetermineDifficultyModifier(difficulty)
        Dim roll = RNG.RollDice(2, 6) + modifier + GetDiceModifier(characteristic) - 8
        Select Case roll
            Case < -5
                Return TaskEffect.ExceptionalFailure
            Case < -1
                Return TaskEffect.AverageFailure
            Case -1
                Return TaskEffect.MarginalFailure
            Case 0
                Return TaskEffect.MarginalSuccess
            Case 1 To 5
                Return TaskEffect.AverageSuccess
            Case Else
                Return TaskEffect.ExceptionalSuccess
        End Select
    End Function
End Class
