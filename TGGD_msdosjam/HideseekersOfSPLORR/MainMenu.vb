Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game

Module MainMenu
    Private Sub ConfirmQuit()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
        End If
    End Sub
    Private Sub StartGame()
        Game.Start()
        InPlay.Run()
    End Sub
    Sub Run()
        Dim quitButton As New Button("Quit")
        AddHandler quitButton.Clicked, AddressOf ConfirmQuit
        Dim startButton As New Button("Start")
        AddHandler startButton.Clicked, AddressOf StartGame
        Dim dlg As New Dialog("", startButton, quitButton)
        Dim title As New Label("Hideseekers of SPLORR!!")
        With title
            .X = Pos.Center()
            .Y = Pos.Center() - 1
        End With
        dlg.Add(title)
        Dim subtitle As New Label("A Production of TheGrumpyGameDev")
        With subtitle
            .X = Pos.Center()
            .Y = Pos.Center() + 1
        End With
        dlg.Add(subtitle)
        dlg.Add(title)
        Application.Run(dlg)
    End Sub
End Module
