Imports System.Runtime.CompilerServices

Public Enum CritterType
    Wabbit
    Duck
End Enum
Module CritterTypeExtensions
    <Extension()>
    Function GetName(critterType As CritterType) As String
        Select Case critterType
            Case CritterType.Wabbit
                Return "wabbit"
            Case CritterType.Duck
                Return "duck"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Function GetDescription(critterType As CritterType) As String
        Select Case critterType
            Case CritterType.Wabbit
                Return "a wascally wabbit"
            Case CritterType.Duck
                Return "a duck"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
