Public Module CharacteristicData
    Sub Initialize()
        CharacteristicSetData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characteristics]
            (
                [CharacteristicSetId] INT NOT NULL,
                [Characteristic] INT NOT NULL,
                [Value] INT NOT NULL,
                UNIQUE([CharacteristicSetId],[Characteristic]),
                FOREIGN KEY ([CharacteristicSetId]) REFERENCES [CharacteristicSets]([CharacteristicSetId])
            );")
    End Sub
    Function Read(characteristicSetId As Long, characteristic As Integer) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [Value] FROM [Characteristics] WHERE [CharacteristicSetId]=@CharacteristicSetId AND [Characteristic]=@Characteristic;")
            command.Parameters.AddWithValue("@CharacteristicSetId", characteristicSetId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Write(characteristicSetId As Long, characteristic As Integer, value As Integer)
        Initialize()
        Using command = CreateCommand(
            "REPLACE INTO [Characteristics]
            (
                [CharacteristicSetId], 
                [Characteristic],
                [Value]
            ) 
            VALUES
            (
                @CharacteristicSetId,
                @Characteristic,
                @Value
            );")
            command.Parameters.AddWithValue("@CharacteristicSetId", characteristicSetId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            command.Parameters.AddWithValue("@Value", value)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
