Public Module CharacterData
    Sub Initialize()
        LocationData.Initialize()
        CharacteristicSetData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characters]
            (
                [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [LocationId] INT NOT NULL,
                [Facing] INT NOT NULL,
                [CharacteristicSetId] INT NOT NULL,
                [Hunger] INT NOT NULL DEFAULT 0,
                [Score] INT NOT NULL DEFAULT 0,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId]),
                FOREIGN KEY ([CharacteristicSetId]) REFERENCES [CharacteristicSets]([CharacteristicSetId])
            );")
    End Sub
    Function Create(locationId As Long, facing As Integer, characteristicSetId As Long) As Long
        Initialize()
        Using command = CreateCommand("INSERT INTO [Characters]([LocationId],[CharacteristicSetId],[Facing]) VALUES(@LocationId,@CharacteristicSetId,@Facing);")
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@Facing", facing)
            command.Parameters.AddWithValue("@CharacteristicSetId", characteristicSetId)
            command.ExecuteNonQuery()
        End Using
        Return LastInsertedIndex
    End Function
    Function ReadLocationId(characterId As Long) As Long?
        Initialize()
        Using command = CreateCommand("SELECT [LocationId] FROM [Characters] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CLng(result)
            End If
            Return Nothing
        End Using
    End Function

    Function ReadCharacteristicSetId(characterId As Long) As Long?
        Initialize()
        Using command = CreateCommand("SELECT [CharacteristicSetId] FROM [Characters] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CLng(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub WriteLocationId(characterId As Long, locationId As Long)
        Initialize()
        Using command = CreateCommand("UPDATE [Characters] SET [LocationId]=@LocationId WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadFacing(characterId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [Facing] FROM [Characters] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub WriteFacing(characterId As Long, facing As Integer)
        Initialize()
        Using command = CreateCommand("UPDATE [Characters] SET [Facing]=@Facing WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@Facing", facing)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadHunger(characterId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [Hunger] FROM [Characters] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadScore(characterId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [Score] FROM [Characters] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
End Module
