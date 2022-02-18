Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InventoryMenu
    Private inventoryView As ListView
    Private craftButton As Button
    Private Sub Drop()
        Dim source = inventoryView.Source.ToList()
        If source.Count > 0 Then
            Dim item = CType(source(inventoryView.SelectedItem), Item)
            item.Drop()
            Refresh()
        End If
    End Sub
    Public Sub Refresh()
        inventoryView.SetSource(CType(PlayerCharacter.Inventory.Items, IList))
        craftButton.Enabled = PlayerCharacter.Inventory.CanCraft
    End Sub
    Private Sub Craft()
        CraftMenu.Run()
        Refresh()
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never Mind", True)
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dropButton As New Button("Drop")
        AddHandler dropButton.Clicked, AddressOf Drop
        craftButton = New Button("Craft...")
        craftButton.Enabled = PlayerCharacter.Inventory.CanCraft
        AddHandler craftButton.Clicked, AddressOf Craft
        Dim dlg As New Dialog("Inventory", cancelButton, dropButton, craftButton)
        inventoryView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Inventory.Items, IList))
        dlg.Add(inventoryView)
        Application.Run(dlg)
    End Sub
End Module
