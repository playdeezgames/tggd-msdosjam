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
    Function ReadCritterType(critterId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [CritterType] FROM [Critters] WHERE [CritterId]=@CritterId;")
            command.Parameters.AddWithValue("@CritterId", critterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadCountForLocation(locationId As Long) As Integer
        Initialize()
        Using command = CreateCommand("SELECT COUNT([CritterId]) FROM [Critters] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    Function ReadForLocation(locationId As Long) As List(Of Long)
        Initialize()
        Using command = CreateCommand("SELECT [CritterId] FROM [Critters] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
            Dim result As New List(Of Long)
            Using reader = command.ExecuteReader
                While reader.Read()
                    result.Add(CLng(reader("CritterId")))
                End While
            End Using
            Return result
        End Using
    End Function
End Module
