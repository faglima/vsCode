Public Class cls_Populate
    Public Sub New(ByVal ValueItem As Integer, ByVal DisplayItem As String)
        iValueItem = ValueItem
        iDisplayItem = DisplayItem
    End Sub
    Private iValueItem As Integer
    Public Property ID() As Integer
        Get
            Return iValueItem
        End Get
        Set(ByVal Value As Integer)
            iValueItem = Value
        End Set
    End Property
    Private iDisplayItem As String
    Public Property Item() As String
        Get
            Return iDisplayItem
        End Get
        Set(ByVal Value As String)
            iDisplayItem = Value
        End Set
    End Property

    
End Class
