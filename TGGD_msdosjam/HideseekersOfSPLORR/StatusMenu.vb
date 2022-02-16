Imports Terminal.Gui
Imports HideseekersOfSPLORR.Game
Module StatusMenu
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Status", cancelButton)
        Dim characteristics = PlayerCharacter.Characteristics
        dlg.Add(New Label(1, 1, $"Strength:  {characteristics.Strength} (DM {characteristics.GetDiceModifier(Characteristic.Strength)})"))
        dlg.Add(New Label(1, 2, $"Dexterity: {characteristics.Dexterity} (DM {characteristics.GetDiceModifier(Characteristic.Dexterity)})"))
        dlg.Add(New Label(1, 3, $"Endurance: {characteristics.Endurance} (DM {characteristics.GetDiceModifier(Characteristic.Endurance)})"))
        dlg.Add(New Label(1, 4, $"Intellect: {characteristics.Intellect} (DM {characteristics.GetDiceModifier(Characteristic.Intellect)})"))
        dlg.Add(New Label(1, 5, $"Education: {characteristics.Education} (DM {characteristics.GetDiceModifier(Characteristic.Education)})"))
        dlg.Add(New Label(1, 6, $"Social:    {characteristics.Social} (DM {characteristics.GetDiceModifier(Characteristic.Social)})"))
        Application.Run(dlg)
    End Sub
End Module
