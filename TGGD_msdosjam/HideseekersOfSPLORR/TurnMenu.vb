Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module TurnMenu
    Private Sub Cancel()
        Application.RequestStop()
    End Sub
    Private Sub TurnLeft()
        PlayerCharacter.Turnleft()
        Application.RequestStop()
    End Sub
    Private Sub TurnRight()
        PlayerCharacter.TurnRight()
        Application.RequestStop()
    End Sub
    Private Sub TurnAround()
        PlayerCharacter.TurnAround()
        Application.RequestStop()
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Cancel
        Dim leftButton As New Button("Left")
        AddHandler leftButton.Clicked, AddressOf TurnLeft
        Dim rightButton As New Button("Right")
        AddHandler rightButton.Clicked, AddressOf TurnRight
        Dim aroundButton As New Button("Around")
        AddHandler aroundButton.Clicked, AddressOf TurnAround
        Dim dlg As New Dialog("Turn...", cancelButton, leftButton, rightButton, aroundButton)
        Dim character = PlayerCharacter
        dlg.Add(New Label(0, 0, $"Current Facing: {character.Facing}"))
        Application.Run(dlg)
    End Sub
End Module
