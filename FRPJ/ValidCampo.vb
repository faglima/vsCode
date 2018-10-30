Public Class ValidCampo


    Private errmsg As String

    Public Property Msg() As String
        Get
            Return errmsg
        End Get
        Set(ByVal value As String)
            errmsg = value
        End Set
    End Property

    Private org As Object
    Public Property Origem() As Object
        Get
            Return org
        End Get
        Set(ByVal value As Object)
            org = value
        End Set
    End Property

    Public Sub New(ByVal msg As String, ByVal org As Object)

        'Me.PossuiErro = iserror
        Me.Msg = msg
        Me.Origem = org

    End Sub

End Class

