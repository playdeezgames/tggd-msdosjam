Public Module CritterData
    Private Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Critters]
            (
                [CritterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [CritterType] INT NOT NULL,
                [LocationId] INT NOT NULL,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Sub Create(critterType As Integer, locationId As Long)
        Initialize()
        Using command = CreateCommand("INSERT INTO [Critters]([CritterType],[LocationId]) VALUES (@CritterType,@LocationId);")
            command.Parameters.AddWithValue("@CritterType", critterType)
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadCountForLocation(locationId As Long) As Integer
        Initialize()
        Using command = CreateCommand("SELECT COUNT([CritterId]) FROM [Critters] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
End Module
