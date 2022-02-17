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

End Module
