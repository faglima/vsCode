Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Venda_OK
    Dim myDataSet As DataSet
    Private Sub frm_Canc_Enviar_Robo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim strDataIni As String
            Dim strDataFim As String

            txtDtIni.Text = Today
            txtDtFim.Text = Today
            txtCPF.Text = Nothing

            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            strDataIni = clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Datetime)
            strDataFim = clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Datetime)

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_EMISSAO_OK @DataIni=" & strDataIni & ",@DataFim=" & strDataFim
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ReadOnly = True
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub tsbtn_Excel_Click(sender As Object, e As EventArgs) Handles tsbtn_Excel.Click
        Dim cls As New cls_Utilities

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then
                cls.GeraTxt_DataGrid(Me.DataGridView1)
            Else
                MessageBox.Show("Nenhum registro para geração de arquivo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strDtIni As String = "NULL"
            Dim strDtFim As String = "NULL"
            Dim strCpf As String = "0"
            Dim strSql As String

            strDtIni = clsU.FormataStringSQL(txtDtIni.Text, cls_Utilities.TipoDado.Datetime)
            strDtFim = clsU.FormataStringSQL(txtDtFim.Text, cls_Utilities.TipoDado.Datetime)
            strCpf = clsU.FormataStringSQL(txtCPF.Text, cls_Utilities.TipoDado.Numerico, "0")

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_EMISSAO_OK @DataIni=" & strDtIni & ",@DataFim=" & strDtFim & ",@Cpf=" & strCpf
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strDtIni As String = "NULL"
            Dim strDtFim As String = "NULL"
            Dim strSql As String

            txtDtIni.Text = Today
            txtDtFim.Text = Today
            txtCPF.Text = Nothing

            strDtIni = clsU.FormataStringSQL(txtDtIni.Text, cls_Utilities.TipoDado.Datetime)
            strDtFim = clsU.FormataStringSQL(txtDtFim.Text, cls_Utilities.TipoDado.Datetime)

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_EMISSAO_OK @DataIni=" & strDtIni & ",@DataFim=" & strDtFim
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCPF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCPF.Validating
        Try

            If txtCPF.MaskFull = True Then
                txtDtIni.Text = Nothing
                txtDtFim.Text = Nothing
            ElseIf txtCPF.Text = Nothing Then
                txtDtIni.Text = Today
                txtDtFim.Text = Today
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class