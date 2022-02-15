Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InPlay
    Private Sub AbandonGame()
        If MessageBox.Query("Are you sure?", "Are you sure you want to abandon the game?", "No", "Yes") = 1 Then
            Game.Finish()
            Application.RequestStop()
        End If
    End Sub
    Private Sub Turn()
        TurnMenu.Run()
        UpdateLabels()
    End Sub
    Private ReadOnly facingLabel As New Label(0, 3, "")
    Private Sub UpdateLabels()
        facingLabel.Text = $"Facing: {PlayerCharacter.Facing} "
    End Sub
    Sub Run()
        Dim abandonButton As New Button("Abandon")
        AddHandler abandonButton.Clicked, AddressOf AbandonGame
        Dim turnButton As New Button("Turn...")
        AddHandler turnButton.Clicked, AddressOf Turn
        Dim dlg As New Dialog("In Play", turnButton, abandonButton)
        dlg.Add(New Label(0, 0, $"CharacterId: {PlayerCharacter.Id}"))
        dlg.Add(New Label(0, 1, $"X: {PlayerCharacter.Location.X}"))
        dlg.Add(New Label(0, 2, $"Y: {PlayerCharacter.Location.Y}"))
        dlg.Add(facingLabel)
        UpdateLabels()
        Application.Run(dlg)
    End Sub
End Module
