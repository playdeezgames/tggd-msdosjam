Imports Terminal.Gui

Module Program
    Sub ConfirmQuit()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
        End If
    End Sub
    Sub Main(args As String())
        Application.Init()
        Dim startButton As New Button("_Start")
        Dim continueButton As New Button("_Continue")
        Dim quitButton As New Button("_Quit")
        AddHandler quitButton.Clicked, AddressOf ConfirmQuit
        Dim dlg As New Dialog("Hello, Dialog!", startButton, continueButton, quitButton)
        Application.Run(dlg)
    End Sub
End Module
