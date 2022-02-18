Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game

Module GroundMenu
    Private inventoryView As ListView
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Ground", cancelButton)
        inventoryView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Location.Inventory.Items, IList))
        dlg.Add(inventoryView)
        Application.Run(dlg)
    End Sub
End Module
