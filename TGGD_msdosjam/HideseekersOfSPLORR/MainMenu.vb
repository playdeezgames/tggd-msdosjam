Imports Terminal.Gui

Module MainMenu
    Private done As Boolean
    Private Sub ConfirmQuit()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
            done = True
        End If
    End Sub
    Sub Run()
        done = False
        Dim quitButton As New Button("Quit")
        AddHandler quitButton.Clicked, AddressOf ConfirmQuit
        Dim dlg As New Dialog("Hideseekers of SPLORR!!", quitButton)
        While Not done
            Application.Run(dlg)
        End While
    End Sub
End Module
