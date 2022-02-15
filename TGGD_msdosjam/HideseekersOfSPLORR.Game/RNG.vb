Module RNG
    Private ReadOnly random As New Random
    Function FromRange(minimum As Integer, maximum As Integer) As Integer
        Return random.Next(minimum, maximum)
    End Function
End Module
