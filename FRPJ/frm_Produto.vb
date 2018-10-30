Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Produto
    Dim myDataSet As DataSet
    Private Sub frm_Produto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim cboProduto As New DataGridViewComboBoxColumn
            Dim cboClasse As New DataGridViewComboBoxColumn
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String


            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_PRODUTOS"
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.Columns.Remove("CodId_Grupo_Fk")
            strSqlCbo = "EXEC FRPJ_SP_PRODUTO_GRUPO_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboProduto, "CodId_Grupo_Fk", "Grupo")
            cboProduto.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            DataGridView1.Columns.Insert(3, cboProduto)
           

            DataGridView1.Columns.Remove("Classe")
            strSqlCbo = "EXEC FRPJ_SP_PRODUTO_CLASSE_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboClasse, "Classe", "Tipo")
            cboClasse.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            DataGridView1.Columns.Insert(9, cboClasse)

            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns(4).ReadOnly = True


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

            strSql = "EXEC FRPJ_SP_PRODUTOS"
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

            e.Row.Cells(7).Value = False
            e.Row.Cells(9).Value = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            Dim senderGrid = DirectCast(sender, DataGridView)
            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim intRamo As Integer

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn AndAlso
               e.RowIndex >= 0 AndAlso e.ColumnIndex = 3 Then

                strSql = "SELECT Ramo FROM tbl_Produto_Grupo WHERE CodId_Prod_Grupo_Pk=" & senderGrid.Item(e.ColumnIndex, e.RowIndex).Value

                intRamo = cls.Exec_Command_Scalar(strSql)

                DataGridView1.CurrentRow.Cells(4).Value = intRamo

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnXml_Click(sender As Object, e As EventArgs) Handles btnXml.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strFile As String
            Dim dttObj As DataTable

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Produtos_PJ.xml"

            dttObj = cls.Return_DataTable("EXEC FRPJ_SP_OFF_PRODUTOS")

            clsU.GeraXml_DataTable(dttObj, strFile)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class