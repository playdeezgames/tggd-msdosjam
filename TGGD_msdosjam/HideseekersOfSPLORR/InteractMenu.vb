Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InteractMenu
    Private Sub Forage()
        Dim item = PlayerCharacter.Forage()
        If item IsNot Nothing Then

        Else
            MessageBox.Query("Fail", "You find nothing!", "Ok")
        End If
    End Sub
    Sub Run()
        Dim cancelButton = New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim forageButton = New Button("Forage")
        AddHandler forageButton.Clicked, AddressOf Forage
        Dim dlg As New Dialog("Interact...", cancelButton, forageButton)
        Application.Run(dlg)
    End Sub
End Module
