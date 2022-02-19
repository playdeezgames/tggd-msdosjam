Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module CritterMenu
    Private critterListView As ListView
    Public Sub Refresh()
        critterListView.SetSource(CType(PlayerCharacter.Location.Critters, IList))
    End Sub

    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Critters...", cancelButton)
        critterListView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Location.Critters, IList))
        dlg.Add(critterListView)
        Application.Run(dlg)
    End Sub
End Module
