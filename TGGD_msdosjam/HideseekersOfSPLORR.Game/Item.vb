Public Class Item
    Private ReadOnly itemId As Long
    Sub New(itemId As Long)
        Me.itemId = itemId
    End Sub
    ReadOnly Property Id As Long
        Get
            Return itemId
        End Get
    End Property
End Class
