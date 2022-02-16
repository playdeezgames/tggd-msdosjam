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
    Private ReadOnly xLabel As New Label(0, 1, "")
    Private ReadOnly yLabel As New Label(0, 2, "")
    Private Sub UpdateLabels()
        xLabel.Text = $"X: {PlayerCharacter.Location.X}   "
        yLabel.Text = $"Y: {PlayerCharacter.Location.Y}   "
        facingLabel.Text = $"Facing: {PlayerCharacter.Facing} "
    End Sub
    Private Sub HandleKeyEvent(evt As View.KeyEventEventArgs)
        If evt.KeyEvent.Key = Key.Esc Then
            evt.Handled = Not GameMenu.Run()
        End If
    End Sub
    Private Sub Move()
        MoveMenu.Run()
        UpdateLabels()
    End Sub
    Private Sub ShowStatus()
        StatusMenu.Run()
    End Sub
    Private Sub Interact()
        InteractMenu.Run()
    End Sub
    Sub Run()
        Dim menuButton As New Button("Menu")
        AddHandler menuButton.Clicked, AddressOf Menu
        Dim turnButton As New Button("Turn...")
        AddHandler turnButton.Clicked, AddressOf Turn
        Dim moveButton As New Button("Move...")
        AddHandler moveButton.Clicked, AddressOf Move
        Dim statusButton As New Button("Status...")
        AddHandler statusButton.Clicked, AddressOf ShowStatus
        Dim interactButton As New Button("Interact...")
        AddHandler interactButton.Clicked, AddressOf Interact

        Dim dlg As New Dialog("In Play", moveButton, turnButton, statusButton, interactButton, menuButton)
        AddHandler dlg.KeyPress, AddressOf HandleKeyEvent
        dlg.Add(New Label(0, 0, $"CharacterId: {PlayerCharacter.Id}"))
        dlg.Add(xLabel)
        dlg.Add(yLabel)
        dlg.Add(facingLabel)
        UpdateLabels()
        Application.Run(dlg)
    End Sub
End Module
