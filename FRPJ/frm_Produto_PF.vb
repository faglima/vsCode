Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Produto_PF
    Dim myDataSet As DataSet

    Private Sub frm_Produto_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim strSqlCbo As String
            Dim conn As New SqlConnection
            Dim cboSegmento As New DataGridViewComboBoxColumn
            Dim cboClasse As New DataGridViewComboBoxColumn
            Dim btnCateg As New DataGridViewButtonColumn
            Dim cboGrupo As New DataGridViewComboBoxColumn

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_PRODUTOS"
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 32
            DataGridView1.Columns(0).DefaultCellStyle.Alignment = 32

            DataGridView1.Columns.Remove("CodId_Grupo_Fk")
            strSqlCbo = "EXEC FRPF_SP_PRODUTO_GRUPO_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboGrupo, "CodId_Grupo_Fk", "Grupo", 2)
            cboGrupo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            DataGridView1.Columns.Insert(3, cboGrupo)


            btnCateg.HeaderText = "Visualizar"
            btnCateg.DefaultCellStyle.Font = New Font("Arial", 8)
            btnCateg.FlatStyle = FlatStyle.Standard
            btnCateg.Text = "Categorias"
            btnCateg.Name = "btnCateg"
            btnCateg.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Insert(0, btnCateg)

            DataGridView1.Columns.Remove("Classe")
            strSqlCbo = "EXEC FRPF_SP_PRODUTO_CLASSE_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboClasse, "Classe", "Tipo", 2)
            cboClasse.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            DataGridView1.Columns.Insert(15, cboClasse)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        Try

            If e.ColumnIndex = 0 Then
                DataGridView1.Cursor = Cursors.Hand
            Else
                DataGridView1.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                       Handles DataGridView1.CellContentClick
        Try
            Dim senderGrid = DirectCast(sender, DataGridView)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 Then

                If Not IsDBNull(DataGridView1.CurrentRow.Cells(1).Value) And DataGridView1.CurrentRow.Cells("Categoria").Value = True Then

                    Me.Cursor = Cursors.WaitCursor

                    frm_Produtos_Categ.Tag = DataGridView1.CurrentRow.Cells(1).Value

                    frm_Produtos_Categ.ShowDialog()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btn_Salvar_Click(sender As Object, e As EventArgs) Handles btn_Salvar.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPF_SP_PRODUTOS"
            MyDa = cls.Return_DataAdapter(strSql, 2)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)

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

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Produtos_PF.xml"

            dttObj = cls.Return_DataTable("EXEC FRPF_SP_OFF_PRODUTOS", 2)

            clsU.GeraXml_DataTable(dttObj, strFile)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        Try

            e.Row.Cells("Segmento").Value = False
            e.Row.Cells("Inativo").Value = False
            e.Row.Cells("Categoria").Value = False
            e.Row.Cells("TipoResidencia").Value = False
            e.Row.Cells("OfertaDif").Value = False
            e.Row.Cells("Venda").Value = False
            e.Row.Cells("Ch_Esp").Value = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class