Imports Terminal.Gui
Module InteractMenu
    Sub Run()
        Dim cancelButton = New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Interact...", cancelButton)
        Application.Run(dlg)
    End Sub
End Module
