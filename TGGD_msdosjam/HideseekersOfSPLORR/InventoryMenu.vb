Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InventoryMenu
    Private inventoryView As ListView
    Private Sub Drop()
        Dim source = inventoryView.Source.ToList()
        If source.Count > 0 Then
            Dim item = CType(source(inventoryView.SelectedItem), Item)
            item.Drop()
            RefreshInventory()
        End If
    End Sub
    Private Sub RefreshInventory()
        inventoryView.SetSource(CType(PlayerCharacter.Inventory.Items, IList))
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never Mind", True)
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dropButton As New Button("Drop")
        AddHandler dropButton.Clicked, AddressOf Drop
        Dim dlg As New Dialog("Inventory", cancelButton, dropButton)
        inventoryView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Inventory.Items, IList))
        dlg.Add(inventoryView)
        Application.Run(dlg)
    End Sub
End Module
