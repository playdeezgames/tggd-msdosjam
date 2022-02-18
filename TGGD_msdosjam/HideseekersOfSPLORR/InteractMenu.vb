Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InteractMenu
    Private groundButton As Button
    Private Sub Forage()
        Dim item = PlayerCharacter.Forage()
        If item IsNot Nothing Then
            MessageBox.Query("Success!", $"You find {item.Description}", "Ok")
        Else
            MessageBox.Query("Fail", "You find nothing!", "Ok")
        End If
    End Sub
    Private Sub Refresh()
        groundButton.Enabled = Not PlayerCharacter.Location.Inventory.IsEmpty
    End Sub
    Private Sub ShowGroundInventory()
        GroundMenu.Run()
        Refresh()
    End Sub
    Sub Run()
        Dim cancelButton = New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim forageButton = New Button("Forage")
        AddHandler forageButton.Clicked, AddressOf Forage
        groundButton = New Button("Ground...")
        AddHandler groundButton.Clicked, AddressOf ShowGroundInventory
        Dim dlg As New Dialog("Interact...", cancelButton, forageButton, groundButton)
        Refresh()
        Application.Run(dlg)
    End Sub
End Module
