Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Desfecho_PF
    Dim myDataSet As DataSet
    Private intProdutoGrupo As Integer
    Private intLocalCanc As Integer

    Private Sub frm_Desfecho_PF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frm_Desfecho_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim cboGrupo As New DataGridViewComboBoxColumn
            Dim cboTipoRet As New DataGridViewComboBoxColumn
            Dim cboMotivo As New DataGridViewComboBoxColumn
            Dim cboLocal As New DataGridViewComboBoxColumn
            Dim cboCod As New DataGridViewComboBoxColumn
            Dim cboData As New DataGridViewComboBoxColumn
            Dim cboTipo As New DataGridViewComboBoxColumn
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String
            Dim ArrayItems As Array

            ArrayItems = Split(Me.Tag, ";")
            intProdutoGrupo = CInt(ArrayItems(0).ToString)
            intLocalCanc = CInt(ArrayItems(1).ToString)

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_DESFECHO @CodId_Prod_Grupo=" & intProdutoGrupo
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.Columns.Remove("Grupo_Produto")
            strSqlCbo = "EXEC FRPF_SP_PRODUTO_GRUPO_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboGrupo, "Grupo_Produto", "Grupo", 2)
            cboGrupo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing


            DataGridView1.Columns.Remove("Tipo_Retencao")
            strSqlCbo = "EXEC FRPF_SP_TIPO_RETENCAO_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboTipoRet, "Tipo_Retencao", "Tipo Retenção", 2)
            cboTipoRet.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Motivo")
            strSqlCbo = "EXEC FRPF_SP_CANC_MOTIVOS_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboMotivo, "Motivo", "Motivo", 2)
            cboMotivo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Local_Canc")
            strSqlCbo = "EXEC FRPF_SP_CANC_LOCAL_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboLocal, "Local_Canc", "Local_Canc.", 2)
            cboLocal.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            cboLocal.ReadOnly = True

            DataGridView1.Columns.Remove("Cod_Cancelamento")
            strSqlCbo = "EXEC FRPF_SP_CANC_CODIGOS_CBO " & intLocalCanc
            clsU.GetCboItems_DataGrid(strSqlCbo, cboCod, "Cod_Cancelamento", "Cod_Canc.", 2)
            cboCod.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Data_Cancelamento")
            strSqlCbo = "EXEC FRPF_SP_CANC_DATA_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboData, "Data_Cancelamento", "Data_Canc.", 2)
            cboData.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Tipo_Devolucao")
            strSqlCbo = "EXEC FRPF_SP_CANC_TIPO_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboTipo, "Tipo_Devolucao", "Tipo_Devolucao", 2)
            cboTipo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns.Insert(1, cboGrupo)
            DataGridView1.Columns(1).Width = 180
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).Width = 60
            DataGridView1.Columns.Insert(3, cboTipoRet)
            DataGridView1.Columns(3).Width = 120
            DataGridView1.Columns.Insert(4, cboMotivo)
            DataGridView1.Columns(4).Width = 300
            DataGridView1.Columns.Insert(5, cboLocal)
            DataGridView1.Columns(5).Width = 80
            DataGridView1.Columns.Insert(6, cboCod)
            DataGridView1.Columns(6).Width = 80
            DataGridView1.Columns.Insert(7, cboData)
            DataGridView1.Columns(7).Width = 180
            DataGridView1.Columns.Insert(8, cboTipo)
            DataGridView1.Columns(8).Width = 160
            DataGridView1.Columns(9).Width = 50
            DataGridView1.Columns(10).Width = 50

            Me.WindowState = FormWindowState.Maximized

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

            strSql = "EXEC FRPF_SP_DESFECHO @CodId_Prod_Grupo=" & intProdutoGrupo
            MyDa = cls.Return_DataAdapter(strSql, 2)

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
            e.Row.Cells(5).Value = intLocalCanc
            e.Row.Cells(9).Value = False
            e.Row.Cells(10).Value = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class