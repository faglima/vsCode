Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_Codigos_PF
    Dim myDataSet As DataSet
    Private Sub frm_Canc_Codigos_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim cboLocal As New DataGridViewComboBoxColumn
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String


            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_CANC_CODIGOS"
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.Columns.Remove("CodId_CLocal_Fk")
            strSqlCbo = "EXEC FRPF_SP_CANC_LOCAL_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboLocal, "CodId_CLocal_Fk", "Local_Cancelamento", 2)
            cboLocal.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing


            DataGridView1.Columns.Insert(1, cboLocal)
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns(0).Visible = False

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

            strSql = "EXEC FRPF_SP_CANC_CODIGOS"
            MyDa = cls.Return_DataAdapter(strSql, 2)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class