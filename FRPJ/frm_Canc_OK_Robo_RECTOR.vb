﻿Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_OK_Robo_RECTOR
    Dim myDataSet As DataSet
    Private Sub frm_Canc_Efetivado_Robo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        InicializaTxt()
        DataGridView1.DataSource = Nothing
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
    Private Sub CarregaGrid(ByVal strDataIni As String, ByVal strDataFim As String)
        Try
            If Not (String.IsNullOrEmpty(strDataIni) And String.IsNullOrEmpty(strDataFim)) Then

                Dim cls As New cls_SqlConnect
                Dim strSql As String
                Dim conn As New SqlConnection
                Dim clsU As New cls_Utilities

                Me.DataGridView1.DataSource = Me.BindingSource1


                strDataIni = clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Datetime)
                strDataFim = clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Datetime)

                strSql = "EXEC FRPJ_SP_CANC_OK_RECTOR " & strDataIni & "," & strDataFim

                myDataSet = cls.Return_DataSet(strSql)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.ReadOnly = True
                'DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
                clsU.FormatGrid(DataGridView1, BindingSource1)

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