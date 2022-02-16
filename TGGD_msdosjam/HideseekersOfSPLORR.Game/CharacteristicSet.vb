Imports HideseekersOfSPLORR.Data

Public Class CharacteristicSet
    Private characteristicSetId As Long
    Private characteristicGenerator As Func(Of Characteristic, Integer)
    Sub New(characteristicSetId As Long, characteristicGenerator As Func(Of Characteristic, Integer))
        Me.characteristicSetId = characteristicSetId
        Me.characteristicGenerator = characteristicGenerator
    End Sub
    Private Function GetCharacteristic(characteristic As Characteristic) As Integer
        Dim value = CharacteristicData.Read(characteristicSetId, CInt(characteristic))
        If Not value.HasValue Then
            value = characteristicGenerator(characteristic)
            CharacteristicData.Write(characteristicSetId, CInt(characteristic), value.Value)
        End If
        Return value.Value
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
End Class
