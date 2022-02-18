Imports System.Text

Public Class Recipe
    ReadOnly Property Characteristic As Characteristic
    ReadOnly Property Difficulty As TaskDifficulty
    ReadOnly Property Inputs As IDictionary(Of ItemType, Integer)
    ReadOnly Property SuccessOutputs As IDictionary(Of ItemType, Integer)
    ReadOnly Property FailureOutputs As IDictionary(Of ItemType, Integer)
    Sub New(characteristic As Characteristic, difficulty As TaskDifficulty, inputs As IDictionary(Of ItemType, Integer), successOutputs As IDictionary(Of ItemType, Integer), failureOutputs As IDictionary(Of ItemType, Integer))
        Me.Characteristic = characteristic
        Me.Difficulty = difficulty
        Me.Inputs = inputs
        Me.SuccessOutputs = successOutputs
        Me.FailureOutputs = failureOutputs
    End Sub
    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder
        Dim first As Boolean = True
        For Each input In Inputs
            If Not first Then
                builder.Append("+")
            End If
            first = False
            builder.Append($"{input.Key.GetName()}({input.Value})")
        Next
        builder.Append("->")
        first = True
        For Each output In SuccessOutputs
            If Not first Then
                builder.Append("+")
            End If
            first = False
            builder.Append($"{output.Key.GetName()}({output.Value})")
        Next
        Return builder.ToString()
    End Function
End Class
