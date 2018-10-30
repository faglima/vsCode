Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Produtos_Categ
    Dim myDA As SqlDataAdapter
    Dim myDataSet As DataSet

    Private Sub frm_Produtos_Categ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim cboCateg As New DataGridViewComboBoxColumn

            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = Me.BindingSource1


            strSql = "SELECT CodId_Prod_Categ, CodProduto_Fk, CodId_Cobertura_Fk, Categoria FROM tbl_Produto_Categoria_Prod WHERE CodProduto_Fk=" & CLng(Me.Tag)

            Using Conn As New SqlConnection(cls.Open_Db(2))
                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strSql
                    .CommandType = CommandType.Text
                    .Connection = Conn
                End With

                myDA = New SqlDataAdapter
                myDA.SelectCommand = cmdComando

                Dim commandBuilder As New SqlCommandBuilder(myDA)

                myDataSet = New DataSet
                myDA.Fill(myDataSet)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1
                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 32
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Visible = False
                DataGridView1.Columns(3).Visible = False

                DataGridView1.Columns.Remove("CodId_Cobertura_Fk")
                cboCateg.DataPropertyName = "CodId_Cobertura_Fk"
                strSql = "select CodId_Categoria, upper(Categoria) from tbl_Produto_Categoria"
                cboCateg.DataSource = GetCboItems(strSql)
                cboCateg.DisplayMember = "Item"
                cboCateg.ValueMember = "ID"
                cboCateg.HeaderText = "Categoria"
                cboCateg.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                DataGridView1.Columns.Insert(3, cboCateg)
                DataGridView1.Columns(3).Width = 190

                Me.Text = "Categorias - " & frm_Produto_PF.DataGridView1.CurrentRow.Cells(7).Value

                Conn.Close()
                Conn.Dispose()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Try
            Me.Validate()

            Me.myDA.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Alterações salvas com sucesso!", "Salvar", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Try

            DataGridView1.CurrentRow.Cells(1).Value = Tag.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function GetCboItems(strSql As String) As List(Of cls_Populate)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql, 2)

            If dtr.HasRows Then
                Do While dtr.Read
                    cboItems.Add(New cls_Populate(dtr.Item(0).ToString(), dtr.Item(1).ToString()))
                Loop
            Else
                cboItems.Add(New cls_Populate(0, "Atenção"))
            End If

            dtr.Close()

            Return cboItems

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    
End Class