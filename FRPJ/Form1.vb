Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cls As New cls_Utilities
        Dim strReturn As String
        Dim arrReturn As Array
        Dim intProduto As Integer
        Dim intApolice As Integer

        strReturn = cls.GetProdutoPJ_Xml("C:\Users\te24195\Desktop\FR_SISTEMA\Produtos_Pj.xml", 8114)
        arrReturn = Split(strReturn, ";")

        intProduto = arrReturn(0)
        intApolice = arrReturn(1)

        If intProduto = 0 Then
            MessageBox.Show("Produto não cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MsgBox("ok")
        End If

    End Sub
End Class