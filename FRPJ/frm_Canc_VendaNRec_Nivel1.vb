Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_VendaNRec_Nivel1
    Dim myDataSet As DataSet

    Private Sub frm_Canc_VendaNRec_Nivel1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String
            Dim conn As New SqlConnection
            Dim cboMotivo As New DataGridViewComboBoxColumn


            Call fLoadForm()

            DataGridView1.Columns.Remove("CodId_Motivo")
            strSqlCbo = "SELECT CodId_CMotivo_Pk,Motivo From tbl_Canc_Motivo WHERE Retido=0"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboMotivo, "CodId_Motivo", "Selecione o Motivo")
            cboMotivo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            cboMotivo.DropDownWidth = 300
            DataGridView1.Columns.Insert(1, cboMotivo)
            DataGridView1.Columns(1).Width = 300
            DataGridView1.Columns("premio").DefaultCellStyle.Format = "n2"
            DataGridView1.Columns("ImpSegurada").DefaultCellStyle.Format = "n2"

            Dim cols As Integer = 0
            Dim i As Integer

            cols = DataGridView1.Columns.Count - 1

            For i = 2 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next

            DataGridView1.Columns("Nivel1_Obs").ReadOnly = False


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

                If Not IsDBNull(DataGridView1.CurrentRow.Cells(1).Value) And DataGridView1.CurrentRow.Cells(10).Value = True Then

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

            strSql = "EXEC FRPJ_SP_NIVEL1_VENDA_N_RECONHECIDA"
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            strSql = "EXEC FRPJ_SP_CANC_UPDATE_VENDA_N_RECONHECIDA_NIVEL1 @Login='" & Environment.UserName & "'"
            cls.Exec_Command_NQ(strSql)

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)

            Call fLoadForm()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub fLoadForm()
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_NIVEL1_VENDA_N_RECONHECIDA"
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns(1).Width = 300

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
End Class