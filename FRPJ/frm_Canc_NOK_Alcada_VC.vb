Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_NOK_Alcada_VC
    Dim myDataSet As DataSet
    Private Sub frm_Canc_NOK_Alcada_VC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            Dim cols As Integer = 0
            Dim i As Integer

            fLoadForm()

            cols = DataGridView1.Columns.Count - 1

            For i = 3 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub tsbtn_Excel_Click(sender As Object, e As EventArgs) Handles tsbtn_Excel.Click
        Dim clsU As New cls_Utilities

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then
                clsU.GeraTxt_DataGrid(Me.DataGridView1)
            Else
                MessageBox.Show("Nenhum registro para geração de arquivo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtn_Select_Click(sender As Object, e As EventArgs) Handles tsbtn_Select.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            If Me.DataGridView1.RowCount > 0 Then

                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_NOK_TRUE_ALCADA_VC")

                If lngRec > 0 Then
                    fLoadForm()
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

                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_NOK_FALSE_ALCADA_VC")

                If lngRec > 0 Then
                    fLoadForm()
                Else
                    MessageBox.Show("Erro ao tentar excluir seleção de registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro para selecão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsbtn_Reproc_Click(sender As Object, e As EventArgs) Handles tsbtn_Reproc.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            fSalvar()

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPJ_SP_CHECK_REPROC_ALCADA_VC"))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_NOK_REPROC_ALCADA_VC")

                If lngRec > 0 Then
                    fLoadForm()
                    MessageBox.Show("Registros enviados para reprocessamento com sucesso!", "Enviar reprocessamento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Erro ao tentar enviar seleção de registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

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

            strSql = "EXEC FRPJ_SP_CANC_NOK_ALCADA_VC"
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub fLoadForm()
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String
            Dim cboCod As New DataGridViewComboBoxColumn
            Dim cboData As New DataGridViewComboBoxColumn

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CANC_NOK_ALCADA_VC"
            myDataSet = cls.Return_DataSet(strSql)
            BindingSource1.DataSource = Nothing
            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            DataGridView1.Columns.Remove("Cod_Cancelamento")
            strSqlCbo = "EXEC FRPJ_SP_CANC_CODIGOS_CBO 2"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboCod, "Cod_Cancelamento", "Cod_Canc.*")
            cboCod.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Data_Cancelamento")
            strSqlCbo = "EXEC FRPJ_SP_CANC_DATA_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboData, "Data_Cancelamento", "Data_Canc.*")
            cboData.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Insert(1, cboCod)
            DataGridView1.Columns(1).Width = 70
            DataGridView1.Columns.Insert(2, cboData)
            DataGridView1.Columns(2).Width = 160
            DataGridView1.Columns(9).DefaultCellStyle.Format = "N2"
            DataGridView1.Columns(10).DefaultCellStyle.Format = "N2"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
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

    Private Sub btn_Salvar_Click(sender As Object, e As EventArgs) Handles btn_Salvar.Click
        Me.Cursor = Cursors.WaitCursor
        fSalvar()
        Me.Cursor = Cursors.Default
    End Sub
End Class