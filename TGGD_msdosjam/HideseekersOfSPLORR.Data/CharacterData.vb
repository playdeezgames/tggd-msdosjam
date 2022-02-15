Public Module CharacterData
    Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characters]
            (
                [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [LocationId] INT NOT NULL,
                [Facing] INT NOT NULL,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Function Create(locationId As Long, facing As Integer) As Long
        Initialize()
        Using command = CreateCommand("INSERT INTO [Characters]([LocationId],[Facing]) VALUES(@LocationId,@Facing);")
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@Facing", locationId)
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
End Module
