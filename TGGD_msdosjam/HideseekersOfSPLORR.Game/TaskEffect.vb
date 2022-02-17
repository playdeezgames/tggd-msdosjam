Imports System.Runtime.CompilerServices

Public Enum TaskEffect As Integer
    ExceptionalFailure = -3
    AverageFailure = -2
    MarginalFailure = -1
    MarginalSuccess = 0
    AverageSuccess = 1
    ExceptionalSuccess = 2
End Enum
Module TaskEffectExtensions
    <Extension()>
    Function IsSuccess(ByVal effect As TaskEffect) As Boolean
        Select Case effect
            Case TaskEffect.MarginalSuccess, TaskEffect.AverageSuccess, TaskEffect.ExceptionalSuccess
                Return True
            Case Else
                Return False
        End Select
    End Function
End Module