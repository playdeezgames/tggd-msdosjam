Public Module CharacterItemData
    Sub Initialize()
        CharacterData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery("CREATE TABLE IF NOT EXISTS [CharacterItems]([CharacterId] INT NOT NULL UNIQUE,[ItemId] INT NOT NULL UNIQUE);")
    End Sub
    Sub Write(characterId As Long, itemId As Long)
        Initialize()
        Using command = CreateCommand("REPLACE INTO [CharacterItems]([CharacterId],[ItemId]) VALUES (@CharacterId, @ItemId);")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
