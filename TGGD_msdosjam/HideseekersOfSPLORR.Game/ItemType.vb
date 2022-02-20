Imports System.Runtime.CompilerServices

Public Enum ItemType
    None
    Stick
    Milkweed
    Rock
    PlantFiber
    Twine
    SharpRock
    Spear
    CritterCorpse
    Hide
    Meat
    Knife
End Enum
Module ItemTypeExtensions
    <Extension()>
    Function GetName(itemType As ItemType) As String
        Select Case itemType
            Case ItemType.Milkweed
                Return "milkweed"
            Case ItemType.Rock
                Return "rock"
            Case ItemType.Stick
                Return "stick"
            Case ItemType.PlantFiber
                Return "plant fiber"
            Case ItemType.Twine
                Return "twine"
            Case ItemType.SharpRock
                Return "sharp rock"
            Case ItemType.Spear
                Return "spear"
            Case ItemType.CritterCorpse
                Return "critter corpse"
            Case ItemType.Hide
                Return "hide"
            Case ItemType.Meat
                Return "meat"
            Case ItemType.Knife
                Return "knife"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Function GetDescription(itemType As ItemType) As String
        Select Case itemType
            Case ItemType.Milkweed
                Return "a stalk of milkweed"
            Case ItemType.Rock
                Return "a rock"
            Case ItemType.Stick
                Return "a stick"
            Case ItemType.PlantFiber
                Return "a strand of plant fiber"
            Case ItemType.Twine
                Return "a piece of twine"
            Case ItemType.SharpRock
                Return "a sharp rock"
            Case ItemType.Spear
                Return "a wooden spear"
            Case ItemType.CritterCorpse
                Return "the corpse of a critter"
            Case ItemType.Hide
                Return "the skin of a critter"
            Case ItemType.Meat
                Return "a hunk of meat"
            Case ItemType.Knife
                Return "a knife"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Function CanConsume(itemType As ItemType) As Boolean
        Return itemType = ItemType.Meat
    End Function
    <Extension()>
    Function GetSatiety(itemType As ItemType) As Integer
        Select Case itemType
            Case ItemType.Meat
                Return 10
            Case Else
                Return 0
        End Select
    End Function
End Module