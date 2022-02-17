Module RNG
    Private ReadOnly random As New Random
    Function FromRange(minimum As Integer, maximum As Integer) As Integer
        Return random.Next(minimum, maximum)
    End Function
    Function RollDice(dieCount As Integer, dieSize As Integer) As Integer
        Dim result As Integer = dieCount
        While dieCount > 0
            dieCount -= 1
            result += FromRange(0, dieSize)
        End While
        Return result
    End Function
    Function Generate(Of TGenerated)(generator As Dictionary(Of TGenerated, Integer)) As TGenerated
        Dim generated = FromRange(0, generator.Values.Sum())
        For Each entry In generator
            generated -= entry.Value
            If generated < 0 Then
                Return entry.Key
            End If
        Next
        Throw New NotImplementedException()
    End Function
End Module
