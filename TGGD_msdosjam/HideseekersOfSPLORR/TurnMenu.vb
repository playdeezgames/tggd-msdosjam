Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module TurnMenu
    Private Sub Cancel()
        Application.RequestStop()
    End Sub
    Private Sub TurnLeft()

    End Sub
    Private Sub TurnRight()

    End Sub
    Private Sub TurnAround()

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
        Application.Run(dlg)
    End Sub
End Module
