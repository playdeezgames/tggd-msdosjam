Public Module LocationData
    Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Locations]
            (
                [LocationId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [X] INT NOT NULL,
                [Y] INT NOT NULL,
                UNIQUE([X],[Y])
            );")
    End Sub
    Function ReadForXY(x As Integer, y As Integer) As Long?
        Initialize()
        Using command = CreateCommand("SELECT [LocationId] FROM [Locations] WHERE [X]=@X AND [Y]=@Y;")
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CLng(result)
            End If
            Return Nothing
        End Using
        Return Nothing
    End Function
    Function Create(x As Integer, y As Integer) As Long
        Initialize()
        Using command = CreateCommand("INSERT INTO [Locations]([X],[Y]) VALUES(@X,@Y);")
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            command.ExecuteNonQuery()
        End Using
        Return LastInsertedIndex
    End Function
    Function ReadX(locationId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [X] FROM [Locations] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadY(locationId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [Y] FROM [Locations] WHERE [LocationId]=@LocationId;")
            command.Parameters.AddWithValue("@LocationId", locationId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
End Module
