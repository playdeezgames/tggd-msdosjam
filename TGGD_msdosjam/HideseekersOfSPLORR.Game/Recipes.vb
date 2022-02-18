Module Recipes
    Private ReadOnly recipes As New List(Of Recipe) From
        {
        New Recipe(
            Characteristic.Dexterity,
            TaskDifficulty.Routine,
            New Dictionary(Of ItemType, Integer) From {{ItemType.Milkweed, 1}},
            New Dictionary(Of ItemType, Integer) From {{ItemType.PlantFiber, 2}},
            New Dictionary(Of ItemType, Integer) From {{ItemType.PlantFiber, 1}}
           ),
        New Recipe(
            Characteristic.Dexterity,
            TaskDifficulty.Average,
            New Dictionary(Of ItemType, Integer) From {{ItemType.PlantFiber, 2}},
            New Dictionary(Of ItemType, Integer) From {{ItemType.Twine, 1}},
            New Dictionary(Of ItemType, Integer) From {{ItemType.PlantFiber, 1}}
           ),
        New Recipe(
            Characteristic.Strength,
            TaskDifficulty.Average,
            New Dictionary(Of ItemType, Integer) From {{ItemType.Rock, 2}},
            New Dictionary(Of ItemType, Integer) From {{ItemType.SharpRock, 1}, {ItemType.Rock, 1}},
            New Dictionary(Of ItemType, Integer) From {{ItemType.Rock, 1}}
           )
        }
    ReadOnly Property All As IList(Of Recipe)
        Get
            Return recipes
        End Get
    End Property
End Module
