Public Module CharacteristicData
    Sub Initialize()
        CharacteristicSetData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characteristics]
            (
                [CharacteristicSetId] INT NOT NULL,
                [Characteristic] INT NOT NULL,
                [Value] INT NOT NULL,
                [Buff] INT NOT NULL,
                UNIQUE([CharacteristicSetId],[Characteristic]),
                FOREIGN KEY ([CharacteristicSetId]) REFERENCES [CharacteristicSets]([CharacteristicSetId])
            );")
    End Sub
    Function Read(characteristicSetId As Long, characteristic As Integer) As Tuple(Of Integer, Integer)
        Initialize()
        Using command = CreateCommand("SELECT [Value],[Buff] FROM [Characteristics] WHERE [CharacteristicSetId]=@CharacteristicSetId AND [Characteristic]=@Characteristic;")
            command.Parameters.AddWithValue("@CharacteristicSetId", characteristicSetId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            Using reader = command.ExecuteReader
                If reader.Read() Then
                    Return New Tuple(Of Integer, Integer)(CInt(reader("Value")), CInt(reader("Buff")))
                End If
                Return Nothing
            End Using
        End Using
    End Function
    Sub Write(characteristicSetId As Long, characteristic As Integer, value As Integer, buff As Integer)
        Initialize()
        Using command = CreateCommand(
            "REPLACE INTO [Characteristics]
            (
                [CharacteristicSetId], 
                [Characteristic],
                [Value],
                [Buff]
            ) 
            VALUES
            (
                @CharacteristicSetId,
                @Characteristic,
                @Value,
                @Buff
            );")
            command.Parameters.AddWithValue("@CharacteristicSetId", characteristicSetId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            command.Parameters.AddWithValue("@Value", value)
            command.Parameters.AddWithValue("@Buff", buff)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
