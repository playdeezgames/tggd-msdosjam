Public Module CharacterData
    Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characters]
            (
                [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT
            );")
    End Sub
    Function Create() As ULong
        Initialize()
        ExecuteNonQuery("INSERT INTO [Characters] DEFAULT VALUES;")
        Return LastInsertedIndex
    End Function
End Module
