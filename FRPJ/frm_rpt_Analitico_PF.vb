Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_rpt_Analitico_PF

    Private Sub frm_rpt_Geral_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim conn As New SqlConnection
            Dim cls_u As New cls_Utilities

            InicializaTxt()
            CarregaGrid(txtDtIni.Text, txtDtFim.Text)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            CarregaGrid(txtDtIni.Text, txtDtFim.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Try

            InicializaTxt()
            DataGridView1.DataSource = Nothing

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
    Private Sub CarregaGrid(ByVal strDataIni As String, ByVal strDataFim As String)
        Try
            If Not (String.IsNullOrEmpty(strDataIni) And String.IsNullOrEmpty(strDataFim)) Then

                Dim cls As New cls_SqlConnect
                Dim strSql As String
                Dim conn As New SqlConnection
                Dim cls_u As New cls_Utilities

                Me.DataGridView1.DataSource = Me.BindingSource1


                strDataIni = cls_u.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Datetime)
                strDataFim = cls_u.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Datetime)

                strSql = "EXEC FRPF_SP_ATEND_RET_ANALITICO_PF " & strDataIni & "," & strDataFim

                BindingSource1.DataSource = cls.Return_DataSet(strSql, 2).Tables(0)
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.ReadOnly = True
                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            Else
                MessageBox.Show("Informe as datas para a pesquisa !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub InicializaTxt()

        txtDtIni.Text = Today
        txtDtFim.Text = Today

    End Sub

End Class