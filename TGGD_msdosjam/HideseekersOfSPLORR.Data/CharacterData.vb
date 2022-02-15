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
    Function Create(locationId As ULong, facing As Integer) As ULong
        Initialize()
        Using command = CreateCommand("INSERT INTO [Characters]([LocationId]) VALUES(@LocationId,@Facing);")
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@Facing", locationId)
            command.ExecuteNonQuery()
        End Using
        Return LastInsertedIndex
    End Function
    Function ReadLocationForCharacter(characterId As ULong) As ULong?
        Initialize()
        Using command = CreateCommand("SELECT [LocationId] FROM [Characters] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CULng(result)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadFacing(characterId As ULong) As Integer?
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
End Module
