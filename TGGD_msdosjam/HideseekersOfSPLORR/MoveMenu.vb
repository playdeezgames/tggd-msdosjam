Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game

Module MoveMenu

    Private Sub Cancel()
        Application.RequestStop()
    End Sub
    Private Sub MoveAhead()
        PlayerCharacter.MoveAhead()
        Application.RequestStop()
    End Sub
    Private Sub MoveLeft()
        PlayerCharacter.MoveLeft()
        Application.RequestStop()
    End Sub
    Private Sub MoveRight()
        PlayerCharacter.MoveRight()
        Application.RequestStop()
    End Sub
    Private Sub MoveBack()
        PlayerCharacter.MoveBack()
        Application.RequestStop()
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Cancel
        Dim moveAheadButton As New Button("Ahead", True)
        AddHandler moveAheadButton.Clicked, AddressOf MoveAhead
        Dim moveLeftButton As New Button("Left")
        AddHandler moveLeftButton.Clicked, AddressOf MoveLeft
        Dim moveRightButton As New Button("Right")
        AddHandler moveRightButton.Clicked, AddressOf MoveRight
        Dim moveBackButton As New Button("Back")
        AddHandler moveBackButton.Clicked, AddressOf MoveBack
        Dim dlg As New Dialog("Move...", cancelButton, moveAheadButton, moveLeftButton, moveRightButton, moveBackButton)
        Application.Run(dlg)
    End Sub
End Module
