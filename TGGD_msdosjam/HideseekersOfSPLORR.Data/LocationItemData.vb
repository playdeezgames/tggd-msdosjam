Public Module LocationItemData
    Sub Initialize()
        LocationData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [LocationItems]
            (
                [LocationId] INT NOT NULL,
                [ItemId] INT NOT NULL UNIQUE,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId]),
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub Write(locationId As Long, itemId As Long)
        Initialize()
        Using command = CreateCommand("REPLACE INTO [LocationItems]([LocationId],[ItemId]) VALUES(@LocationId, @ItemId);")
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadCountForLocation(locationId As Long) As Integer
        Initialize()
        Using command = CreateCommand("SELECT COUNT([ItemId]) FROM [LocationItems] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    Function ReadForLocation(locationId As Long) As IList(Of Long)
        Initialize()
        Using command = CreateCommand("SELECT [ItemId] FROM [LocationItems] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
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
        Using command = CreateCommand("DELETE FROM [LocationItems] WHERE [ItemId]=@ItemId;")
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
