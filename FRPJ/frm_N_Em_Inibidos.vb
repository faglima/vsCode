Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_N_Em_Inibidos
    Private Sub frm_rpt_Geral_PF_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim strDataIni As String
            Dim strDataFim As String
            Dim dtaTable As DataTable

            txtDtIni.Text = Today
            txtDtFim.Text = Today

            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_N_EMITIDO_INIBIDO @CodId=0, @Cpf=0, @DtaInibidoIni=" & clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Datetime) & ",@DtaInibidoFim=" & clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Datetime)

            dtaTable = cls.Return_DataTable(strSql, 2)

            BindingSource1.DataSource = dtaTable
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 32
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim strDataIni As String
            Dim strDataFim As String
            Dim strCodId As String = "0"
            Dim strCpf As String = "0"
            Dim strProtocolo As String = "0"
            Dim dtaTable As DataTable

            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            If Not txtProtocolo.Text = Nothing Then
                strProtocolo = clsU.FormataStringSQL(txtProtocolo.Text, cls_Utilities.TipoDado.Numerico)
            End If
            If Not txtCpf.Text = Nothing Then
                strCpf = clsU.FormataStringSQL(txtCpf.Text, cls_Utilities.TipoDado.Numerico)
            End If

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_N_EMITIDO_INIBIDO @CodId=" & strProtocolo & ", @Cpf=" & strCpf & ", @DtaInibidoIni=" & clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Datetime) & ",@DtaInibidoFim=" & clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Datetime)

            dtaTable = cls.Return_DataTable(strSql, 2)

            BindingSource1.DataSource = dtaTable
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Refresh()
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim strDataIni As String
            Dim strDataFim As String
            Dim dtaTable As DataTable

            txtDtIni.Text = Today
            txtDtFim.Text = Today
            txtProtocolo.Text = Nothing
            txtCpf.Text = Nothing

            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            strSql = "EXEC FRPF_SP_N_EMITIDO_INIBIDO @CodId=0, @Cpf=0, @DtaInibidoIni=" & clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Datetime) & ",@DtaInibidoFim=" & clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Datetime)

            Me.DataGridView1.DataSource = Me.BindingSource1

            dtaTable = cls.Return_DataTable(strSql, 2)

            BindingSource1.DataSource = dtaTable
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.Refresh()
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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


    Private Sub txtDtIni_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDtIni.Validating
        Try

            If txtDtIni.MaskFull = False OrElse IsDate(txtDtIni.Text) = False Then
                txtDtIni.Text = Today
            ElseIf CDate(txtDtIni.Text) > CDate(txtDtFim.Text) Then
                txtDtFim.Text = txtDtIni.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtDtFim_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDtFim.Validating
        Try

            If txtDtFim.MaskFull = False OrElse IsDate(txtDtFim.Text) = False Then
                txtDtFim.Text = txtDtIni.Text
            ElseIf CDate(txtDtFim.Text) < CDate(txtDtIni.Text) Then
                txtDtFim.Text = txtDtIni.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class