Imports Microsoft.Data.Sqlite
Public Module Store
    Private connection As SqliteConnection = Nothing
    Sub Start()
        Finish()
        connection = New SqliteConnection("Data Source=:memory:")
        connection.Open()
    End Sub
    Sub Finish()
        If connection IsNot Nothing Then
            connection.Close()
            connection = Nothing
        End If
    End Sub
    Function CreateCommand(sql As String) As SqliteCommand
        Dim command = connection.CreateCommand()
        command.CommandText = sql
        Return command
    End Function
    Sub ExecuteNonQuery(sql As String)
        Using command = CreateCommand(sql)
            command.ExecuteNonQuery()
        End Using
    End Sub
    ReadOnly Property LastInsertedIndex As ULong
        Get
            Using command = CreateCommand("SELECT last_insert_rowid();")
                Dim temp = command.ExecuteScalar()
                Return CULng(temp)
            End Using
        End Get
    End Property
End Module
