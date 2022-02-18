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
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module