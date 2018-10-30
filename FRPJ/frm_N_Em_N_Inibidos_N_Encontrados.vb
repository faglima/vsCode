﻿Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_N_Em_N_Inibidos_N_Encontrados
    Dim myDataSet As DataSet
    Dim strParam

    Private Sub frm_N_Em_N_Inibidos_N_Encontrados_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim cols As Integer

            Me.DataGridView1.DataSource = Me.BindingSource1

            strParam = "@CodId=0, @Cpf=0"

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_N_ENCONTRADO " & strParam

            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            cols = DataGridView1.Columns.Count - 1

            For i = 1 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next

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

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_N_ENCONTRADO " & strParam

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

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_N_ENCONTRADO " & strParam

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


    Private Sub tsmi_Nivel2_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel2.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim lngRec As Long = 0

            Cursor = Cursors.WaitCursor


            If DataGridView1.RowCount > 0 Then
                lngRec = cls.Exec_Command_NQ("FRPF_SP_UPDATE_N_EMITIDO_N_INIBIDO_N_ENCONTRADO_N2 @Login='" & Environment.UserName & "'", 2)
                If lngRec > 0 Then
                    MessageBox.Show("Registros enviados ao 2º nível com sucesso!", "Enviar 2º nível", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call frm_N_Em_N_Inibidos_N_Encontrados_Load(sender, New System.EventArgs)
                Else
                    MessageBox.Show("Nenhum registro enviado ao 2º nível!", "Enviar 2º nível", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                           Handles DataGridView1.CellContentClick
        Try
            Dim senderGrid = DirectCast(sender, DataGridView)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then

                fSalvar()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub fSalvar()
        Try

            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPF_SP_N_EMITIDO_N_INIBIDO_N_ENCONTRADO " & strParam

            MyDa = cls.Return_DataAdapter(strSql, 2)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtn_Select_Click(sender As Object, e As EventArgs) Handles tsbtn_Select.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            If Me.DataGridView1.RowCount > 0 Then

                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_UPDATE_N_EMITIDO_N_INIBIDO_N_ENCONTRADO_OK " & strParam)

                If lngRec > 0 Then
                    Call btnFiltrar_Click(sender, New System.EventArgs)
                Else
                    MessageBox.Show("Erro ao tentar selecionar registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro para selecão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbtn_Unselect_Click(sender As Object, e As EventArgs) Handles tsbtn_Unselect.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            If Me.DataGridView1.RowCount > 0 Then

                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_UPDATE_N_EMITIDO_N_INIBIDO_N_ENCONTRADO_NOK " & strParam)

                If lngRec > 0 Then
                    Call btnFiltrar_Click(sender, New System.EventArgs)
                Else
                    MessageBox.Show("Erro ao tentar selecionar registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro para selecão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class