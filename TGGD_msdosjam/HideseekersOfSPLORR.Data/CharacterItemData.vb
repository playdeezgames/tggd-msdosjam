Public Module CharacterItemData
    Sub Initialize()
        CharacterData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery("CREATE TABLE IF NOT EXISTS [CharacterItems]([CharacterId] INT NOT NULL,[ItemId] INT NOT NULL UNIQUE);")
    End Sub
    Sub Write(characterId As Long, itemId As Long)
        Initialize()
        Using command = CreateCommand("REPLACE INTO [CharacterItems]([CharacterId],[ItemId]) VALUES (@CharacterId, @ItemId);")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadCountForCharacter(characterId As Long) As Integer
        Initialize()
        Using command = CreateCommand("SELECT COUNT([ItemId]) FROM [CharacterItems] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Return CInt(command.ExecuteScalar())
        End Using
    End Function
    Function ReadForCharacter(characterId As Long) As IList(Of Long)
        Initialize()
        Using command = CreateCommand("SELECT [ItemId] FROM [CharacterItems] WHERE [CharacterId]=@CharacterId;")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Using reader = command.ExecuteReader
                Dim result As New List(Of Long)
                While reader.Read()
                    result.Add(CLng(reader("ItemId")))
                End While
                Return result
            End Using
        End Using
    End Function
    Sub ClearForItem(itemId As Long)
        Initialize()
        Using command = CreateCommand("DELETE FROM [CharacterItems] WHERE [ItemId]=@ItemId;")
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
