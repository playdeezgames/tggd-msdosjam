Imports Terminal.Gui

Module CritterMenu
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Critters...", cancelButton)
        Application.Run(dlg)
    End Sub
End Module
