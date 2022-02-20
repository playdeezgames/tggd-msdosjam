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
        Refresh()
    End Sub
    Private ReadOnly xLabel As New Label(1, 2, "")
    Private ReadOnly yLabel As New Label(1, 3, "")
    Private ReadOnly facingLabel As New Label(1, 4, "")
    Private ReadOnly hungerLabel As New Label(1, 5, "")
    Private ReadOnly scoreLabel As New Label(1, 6, "")
    Private ReadOnly critterLabel As New Label(1, 7, "")
    Private Sub Refresh()
        xLabel.Text = $"X: {PlayerCharacter.Location.X}   "
        yLabel.Text = $"Y: {PlayerCharacter.Location.Y}   "
        facingLabel.Text = $"Facing: {PlayerCharacter.Facing} "
        If PlayerCharacter.Location.HasCritters Then
            critterLabel.Text = $"There is at least one critter here."
        Else
            critterLabel.Text = $"There are no critters here.        "
        End If
        hungerLabel.Text = $"Hunger: {PlayerCharacter.Hunger}"
        scoreLabel.Text = $"Score: {PlayerCharacter.Score}"
        If PlayerCharacter.IsDead Then
            MessageBox.Query("Dead!", $"You starved to death. Yer final score is {PlayerCharacter.Score}.", "Ok")
            Application.RequestStop()
        End If
    End Sub
    Private Sub HandleKeyEvent(evt As View.KeyEventEventArgs)
        If evt.KeyEvent.Key = Key.Esc Then
            evt.Handled = Not GameMenu.Run()
        End If
    End Sub
    Private Sub Move()
        MoveMenu.Run()
        Refresh()
    End Sub
    Private Sub ShowStatus()
        StatusMenu.Run()
        Refresh()
    End Sub
    Private Sub Interact()
        InteractMenu.Run()
        Refresh()
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
        dlg.Add(New Label(1, 1, $"CharacterId: {PlayerCharacter.Id}"))
        dlg.Add(xLabel)
        dlg.Add(yLabel)
        dlg.Add(facingLabel)
        dlg.Add(critterLabel)
        dlg.Add(hungerLabel)
        dlg.Add(scoreLabel)
        Refresh()
        Application.Run(dlg)
    End Sub
End Module
