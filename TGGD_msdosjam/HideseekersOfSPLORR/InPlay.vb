Imports Terminal.Gui
Module InPlay
    Private Sub AbandonGame()
        If MessageBox.Query("Are you sure?", "Are you sure you want to abandon the game?", "No", "Yes") = 1 Then
            Application.RequestStop()
        End If
    End Sub
    Sub Run()
        Dim abandonButton As New Button("Abandon")
        AddHandler abandonButton.Clicked, AddressOf AbandonGame
        Dim dlg As New Dialog("In Play", abandonButton)

        dlg.Add(New Label(1, 1, $"CharacterId: {Game.PlayerCharacter.Id}"))

        Application.Run(dlg)
    End Sub
End Module
