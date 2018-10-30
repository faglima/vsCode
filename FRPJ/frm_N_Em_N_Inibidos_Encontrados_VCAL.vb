Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_N_Em_N_Inibidos_Encontrados_VCAL
    Dim myDataSet As DataSet
    Dim strParam
    Private Sub frm_N_Em_N_Inibidos_Encontrados_VCAL_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String

            Me.DataGridView1.DataSource = Me.BindingSource1

            strParam = "@CodId=0, @Cpf=0"

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_ENCONTRADO_VCAL " & strParam

            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
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
            Dim strCodId As String = "0"
            Dim strCpf As String = "0"
            Dim strProtocolo As String = "0"
            Dim dtaTable As DataTable

            If Not txtProtocolo.Text = Nothing Then
                strProtocolo = clsU.FormataStringSQL(txtProtocolo.Text, cls_Utilities.TipoDado.Numerico)
            End If
            If Not txtCpf.Text = Nothing Then
                strCpf = clsU.FormataStringSQL(txtCpf.Text, cls_Utilities.TipoDado.Numerico)
            End If

            Me.DataGridView1.DataSource = Me.BindingSource1

            strParam = "@CodId=" & strProtocolo & ", @Cpf=" & strCpf

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_ENCONTRADO_VCAL " & strParam

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
            Dim dtaTable As DataTable

            txtProtocolo.Text = Nothing
            txtCpf.Text = Nothing

            strParam = "@CodId=0, @Cpf=0"

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_ENCONTRADO_VCAL " & strParam

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
End Class