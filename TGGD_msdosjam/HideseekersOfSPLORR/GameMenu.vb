Imports Terminal.Gui

Module GameMenu
    Private result As Boolean = False
    Private Sub AbandonGame()
        If MessageBox.Query("Are you sure?", "Are you sure you want to abandon the game?", "No", "Yes") = 1 Then
            Game.Finish()
            Application.RequestStop()
            result = True
        End If
    End Sub
    Private Sub Cancel()
        Application.RequestStop()
        result = False
    End Sub
    Function Run() As Boolean
        Dim cancelButton As New Button("Never mind", True)
        AddHandler cancelButton.Clicked, AddressOf Cancel
        Dim abandonButton As New Button("Abandon Game")
        AddHandler abandonButton.Clicked, AddressOf AbandonGame
        Dim dlg As New Dialog("Game Menu", cancelButton, abandonButton)
        Application.Run(dlg)
        Return result
    End Function
End Module
