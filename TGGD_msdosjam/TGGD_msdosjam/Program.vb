Imports Terminal.Gui

Module Program
    Sub DoStuff()

    End Sub
    Sub Main(args As String())
        Application.Init()
        Dim win As New Window("Window!")
        win.Add(New ListView(New Rect(0, 0, 10, 10), New List(Of String) From {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13"}))
        Application.Run(win)
    End Sub
End Module
