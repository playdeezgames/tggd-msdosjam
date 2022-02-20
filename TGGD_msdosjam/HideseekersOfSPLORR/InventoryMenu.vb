Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module InventoryMenu
    Private inventoryView As ListView
    Private craftButton As Button
    Private consumeButton As Button
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
        consumeButton.Enabled = False
        Dim source = inventoryView.Source.ToList()
        If source.Count > 0 Then
            Dim item = CType(source(inventoryView.SelectedItem), Item)
            consumeButton.Enabled = item.CanConsume
        End If
    End Sub
    Private Sub Craft()
        CraftMenu.Run()
        Refresh()
    End Sub
    Private Sub Consume()
        Dim source = inventoryView.Source.ToList()
        If source.Count > 0 Then
            Dim item = CType(source(inventoryView.SelectedItem), Item)
            item.Consume(PlayerCharacter)
            Refresh()
        End If
    End Sub
    Private Sub ChangeItem(args As ListViewItemEventArgs)
        Dim item = CType(args.Value, Item)
        If item IsNot Nothing Then
            consumeButton.Enabled = item.CanConsume
        End If
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never Mind", True)
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dropButton As New Button("Drop")
        AddHandler dropButton.Clicked, AddressOf Drop
        consumeButton = New Button("Consume")
        AddHandler consumeButton.Clicked, AddressOf Consume
        craftButton = New Button("Craft...")
        AddHandler craftButton.Clicked, AddressOf Craft
        Dim dlg As New Dialog("Inventory", cancelButton, dropButton, consumeButton, craftButton)
        inventoryView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Inventory.Items, IList))
        AddHandler inventoryView.SelectedItemChanged, AddressOf ChangeItem
        dlg.Add(inventoryView)
        Refresh()
        Application.Run(dlg)
    End Sub
End Module
