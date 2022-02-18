Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game

Module GroundMenu
    Private inventoryView As ListView
    Private Sub PickUp()
        Dim source = inventoryView.Source.ToList()
        If source.Count > 0 Then
            Dim item = CType(source(inventoryView.SelectedItem), Item)
            item.PickUp(PlayerCharacter)
            RefreshInventory()
        End If
    End Sub
    Private Sub RefreshInventory()
        inventoryView.SetSource(CType(PlayerCharacter.Location.Inventory.Items, IList))
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim pickUpButton As New Button("Pick Up")
        AddHandler pickUpButton.Clicked, AddressOf PickUp
        Dim dlg As New Dialog("Ground", cancelButton, pickUpButton)
        inventoryView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Location.Inventory.Items, IList))
        dlg.Add(inventoryView)
        Application.Run(dlg)
    End Sub
End Module
