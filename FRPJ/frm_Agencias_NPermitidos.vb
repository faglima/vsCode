Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Agencias_NPermitidos
    Dim myDataSet As DataSet
    Private Sub frm_Agencias_NPermitidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            fLoadForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub fSalvar()
        Try

            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()
            RecebeAlteracoes()

            strSql = "EXEC FRPJ_SP_AGENCIAS_FILTRO"
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            fLoadForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub RecebeAlteracoes()
        Try
            Dim dta As New DataTable
            dta = DirectCast(Me.BindingSource1.DataSource, DataTable)

            myDataSet.Tables.RemoveAt(0)
            myDataSet.Tables.Add(dta)

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

    Public Sub fLoadForm()
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_AGENCIAS_FILTRO"
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns(0).ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btn_Salvar_Click(sender As Object, e As EventArgs) Handles btn_Salvar.Click
        If MessageBox.Show("Você gostaria de salvar as alterações na tabela ?", "Alteração de Registro", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then

            fSalvar()

        End If
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If MessageBox.Show("Tem certeza que deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            Me.BindingSource1.RemoveCurrent()
            Me.BindingSource1.EndEdit()
            Me.Validate()

            fSalvar()
        End If
    End Sub
End Class