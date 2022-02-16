Public Module CharacteristicSetData
    Sub Initialize()
        ExecuteNonQuery("CREATE TABLE IF NOT EXISTS [CharacteristicSets]([CharacteristicSetId] INTEGER PRIMARY KEY AUTOINCREMENT);")
    End Sub
    Function Create() As Long
        Initialize()
        ExecuteNonQuery("INSERT INTO [CharacteristicSets] DEFAULT VALUES;")
        Return LastInsertedIndex
    End Function
End Module
