Public Module ItemData
    Sub Initialize()
        ExecuteNonQuery("CREATE TABLE IF NOT EXISTS [Items]([ItemId] INTEGER PRIMARY KEY AUTOINCREMENT,[ItemType] INT NOT NULL);")
    End Sub
    Function Create(itemType As Integer) As Long
        Initialize()
        Using command = CreateCommand("INSERT INTO [Items]([ItemType]) VALUES(@ItemType);")
            command.Parameters.AddWithValue("@ItemType", itemType)
            command.ExecuteNonQuery()
            Return LastInsertedIndex
        End Using
    End Function
    Function ReadItemType(itemId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [ItemType] FROM [Items] WHERE [ItemId]=@ItemId;")
            command.Parameters.AddWithValue("@ItemId", itemId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Destroy(itemId As Long)
        Initialize()
        CharacterItemData.ClearForItem(itemId)
        LocationItemData.ClearForItem(itemId)
        Using command = CreateCommand("DELETE FROM [Items] WHERE [ItemId]=@ItemId;")
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
