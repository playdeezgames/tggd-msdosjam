Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module CraftMenu
    Private recipeView As ListView
    Private Sub Refresh()
        recipeView.SetSource(CType(PlayerCharacter.Inventory.CraftableRecipes, IList))
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Craft...", cancelButton)
        recipeView = New ListView(New Rect(1, 1, 60, 20), CType(PlayerCharacter.Inventory.CraftableRecipes, IList))
        dlg.Add(recipeView)
        Application.Run(dlg)
    End Sub
End Module
