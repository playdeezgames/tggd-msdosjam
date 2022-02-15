Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InPlay
    Private Sub Menu()
        If GameMenu.Run() Then
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
    Private Sub HandleKeyEvent(evt As View.KeyEventEventArgs)
        If evt.KeyEvent.Key = Key.Esc Then
            evt.Handled = Not GameMenu.Run()
        End If
    End Sub
    Sub Run()
        Dim abandonButton As New Button("Menu")
        AddHandler abandonButton.Clicked, AddressOf Menu
        Dim turnButton As New Button("Turn...")
        AddHandler turnButton.Clicked, AddressOf Turn
        Dim dlg As New Dialog("In Play", turnButton, abandonButton)
        AddHandler dlg.KeyPress, AddressOf HandleKeyEvent
        dlg.Add(New Label(0, 0, $"CharacterId: {PlayerCharacter.Id}"))
        dlg.Add(New Label(0, 1, $"X: {PlayerCharacter.Location.X}"))
        dlg.Add(New Label(0, 2, $"Y: {PlayerCharacter.Location.Y}"))
        dlg.Add(facingLabel)
        UpdateLabels()
        Application.Run(dlg)
    End Sub
End Module
