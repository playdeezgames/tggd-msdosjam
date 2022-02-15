Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InPlay
    Private Sub AbandonGame()
        If MessageBox.Query("Are you sure?", "Are you sure you want to abandon the game?", "No", "Yes") = 1 Then
            Game.Finish()
            Application.RequestStop()
        End If
    End Sub
    Sub Run()
        Dim abandonButton As New Button("Abandon")
        AddHandler abandonButton.Clicked, AddressOf AbandonGame
        Dim dlg As New Dialog("In Play", abandonButton)

        Dim character = PlayerCharacter
        dlg.Add(New Label(0, 0, $"CharacterId: {character.Id}"))
        dlg.Add(New Label(0, 1, $"X: {character.Location.X}"))
        dlg.Add(New Label(0, 2, $"Y: {character.Location.Y}"))
        Application.Run(dlg)
    End Sub
End Module
