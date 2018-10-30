Public Class frm_Welcome

    Public Sub ShowMe(cls As cls_Utilities)
        Me.Show()
        Label1.Text = "Olá " & cls.UserName & ", seja bem-vindo ao " & Application.ProductName.ToString & vbCrLf _
                    & "Utilize o menu acima para navegar entre suas funcionalidades"
    End Sub

    Private Sub frm_Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class