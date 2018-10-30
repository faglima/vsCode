Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_VendaNREc_Nivel2
    Dim myDataSet As DataSet
    Dim strEps As String = "0"

    Private Sub frm_Canc_VendaNREc_Nivel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String
            Dim conn As New SqlConnection
            Dim cboProcedente As New DataGridViewComboBoxColumn

            fLoadForm()

            DataGridView1.Columns.Remove("Atrito_CodId_Procedente")
            strSqlCbo = "EXEC FRPJ_SP_PROCEDENTE_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboProcedente, "Atrito_CodId_Procedente", "Procedente")
            cboProcedente.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            cboProcedente.DropDownWidth = 200
            DataGridView1.Columns.Insert(0, cboProcedente)
            DataGridView1.Columns(0).Width = 200
            DataGridView1.Columns("premio").DefaultCellStyle.Format = "n2"
            DataGridView1.Columns("ImpSegurada").DefaultCellStyle.Format = "n2"

            Dim cols As Integer = 0
            Dim i As Integer

            cols = DataGridView1.Columns.Count - 1

            For i = 1 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next

            DataGridView1.Columns("Obs_Nivel2").ReadOnly = False
            DataGridView1.Columns("Obs_Nivel2").Width = 200
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
            Dim lngRet As Long

            Me.Validate()

            strSql = "EXEC FRPJ_SP_NIVEL2_VENDA_N_RECONHECIDA @EPS=" & strEps
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            'Verifica se possui algum registro a ser enviado ao nível 3 com Obs2 Null
            strSql = "EXEC FRPJ_SP_CANC_ATRITO_GET_OBS_NIVEL2_NULL"
            lngRet = cls.Exec_Command_Scalar(strSql)

            If lngRet > 0 Then
                Throw New Exception("O campo Obs_Nivel2 deve ser preenchido para a opção 'Procedente + de 01 vigência'")
            End If

            strSql = "EXEC FRPJ_SP_CANC_UPDATE_ATRITO @Login='" & Environment.UserName & "'"
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

            Select Case frm_MainForm.Tag
                Case Is = "13" '2º NÍVEL SAC
                    strEps = "3"
                Case Is = "12" '1º NÍVEL SAC
                    strEps = "3"
                Case Is = "-1", "2", "3" 'MASTER, MASTER CORRETORA E MASTER SEGURADORA
                    strEps = "100"
            End Select

            strSql = "EXEC FRPJ_SP_NIVEL2_VENDA_N_RECONHECIDA @EPS=" & strEps
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1


            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns(0).Width = 200


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