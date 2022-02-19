Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module CritterMenu
    Private critterListView As ListView
    Private attackButton As Button
    Public Sub Refresh()
        critterListView.SetSource(CType(PlayerCharacter.Location.Critters, IList))
        attackButton.Enabled = PlayerCharacter.CanAttack
    End Sub
    Public Sub Attack()
        Dim source = critterListView.Source.ToList()
        If source.Count > 0 Then
            Dim critter = CType(source(critterListView.SelectedItem), Critter)
            If critter.Attack(PlayerCharacter) Then
                MessageBox.Query("Success!", "You kill it!", "Ok")
            Else
                MessageBox.Query("Fail!", "You missed!", "Ok")
            End If
            Refresh()
        End If
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        attackButton = New Button("Attack!")
        AddHandler attackButton.Clicked, AddressOf Attack
        Dim dlg As New Dialog("Critters...", cancelButton, attackButton)
        critterListView = New ListView(New Rect(1, 1, 40, 20), CType(PlayerCharacter.Location.Critters, IList))
        dlg.Add(critterListView)
        Refresh()
        Application.Run(dlg)
    End Sub
End Module
