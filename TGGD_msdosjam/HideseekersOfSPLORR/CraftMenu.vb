Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module CraftMenu
    Private recipeView As ListView
    Private Sub Refresh()
        InventoryMenu.Refresh()
        recipeView.SetSource(CType(PlayerCharacter.Inventory.CraftableRecipes, IList))
    End Sub
    Private Sub CraftRecipe(recipe As Recipe)
        If PlayerCharacter.Inventory.CraftRecipe(recipe) Then
            MessageBox.Query("Success!", "You are successful!", "Ok")
        Else
            MessageBox.Query("Failure!", "You fail!", "Ok")
        End If
    End Sub
    Private Sub Craft()
        Dim source = recipeView.Source.ToList()
        If source.Count > 0 Then
            Dim recipe = CType(source(recipeView.SelectedItem), Recipe)
            CraftRecipe(recipe)
        End If
        Refresh()
    End Sub
    Private Sub OpenListViewItem(args As ListViewItemEventArgs)
        Dim recipe = CType(args.Value, Recipe)
        CraftRecipe(recipe)
        Refresh()
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim craftButton As New Button("Craft!")
        AddHandler craftButton.Clicked, AddressOf Craft
        Dim dlg As New Dialog("Craft...", cancelButton, craftButton)
        recipeView = New ListView(New Rect(1, 1, 60, 20), CType(PlayerCharacter.Inventory.CraftableRecipes, IList))
        AddHandler recipeView.OpenSelectedItem, AddressOf OpenListViewItem
        dlg.Add(recipeView)
        Application.Run(dlg)
    End Sub
End Module
