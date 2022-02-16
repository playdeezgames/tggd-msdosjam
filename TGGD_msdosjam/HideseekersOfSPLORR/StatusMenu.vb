Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module StatusMenu
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Status", cancelButton)
        dlg.Add(New Label(1, 1, $"Strength:  {PlayerCharacter.Characteristics.Strength}"))
        dlg.Add(New Label(1, 2, $"Dexterity: {PlayerCharacter.Characteristics.Dexterity}"))
        dlg.Add(New Label(1, 3, $"Endurance: {PlayerCharacter.Characteristics.Endurance}"))
        dlg.Add(New Label(1, 4, $"Intellect: {PlayerCharacter.Characteristics.Intellect}"))
        dlg.Add(New Label(1, 5, $"Education: {PlayerCharacter.Characteristics.Education}"))
        dlg.Add(New Label(1, 6, $"Social:    {PlayerCharacter.Characteristics.Social}"))
        Application.Run(dlg)
    End Sub
End Module
