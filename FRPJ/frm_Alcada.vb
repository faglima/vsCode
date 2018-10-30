Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Alcada
    Dim myDataSet As DataSet
    Private intProdutoGrupo As Integer
    Private intLocalCanc As Integer

    Private Sub frm_Alcada_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frm_Alcada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim cboGrupo As New DataGridViewComboBoxColumn
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String

            intProdutoGrupo = CInt(Me.Tag)

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_ALCADA @CodId_Prod_Grupo=" & intProdutoGrupo
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.Columns.Remove("Grupo_Produto")
            strSqlCbo = "EXEC FRPJ_SP_PRODUTO_GRUPO_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboGrupo, "Grupo_Produto", "Grupo")
            cboGrupo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns.Insert(1, cboGrupo)
            DataGridView1.Columns(1).Width = 180
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).DefaultCellStyle.Format = "n2"

            'Me.WindowState = FormWindowState.Normal
            Me.StartPosition = FormStartPosition.CenterScreen


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub btn_Salvar_Click(sender As Object, e As EventArgs) Handles btn_Salvar.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPJ_SP_ALCADA @CodId_Prod_Grupo=" & intProdutoGrupo
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        Try

            e.Row.Cells(1).Value = intProdutoGrupo

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class