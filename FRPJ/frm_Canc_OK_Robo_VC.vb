Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_OK_Robo_VC
    Dim myDataSet As DataSet
    Private Sub frm_Canc_OK_Robo_VC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
 
        fLoadForm()

    End Sub
    Public Sub fLoadForm()
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CANC_OK_VC"

            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            For i = 1 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).ReadOnly = True
            Next

            'DataGridView1.ReadOnly = True
            'DataGridView1.Columns("Selecione").ReadOnly = False
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

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

    Private Sub tsbtn_VC90_Click(sender As Object, e As EventArgs) Handles tsbtn_VC90.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strFile As String
            Dim lngRec As Long = 0

            Cursor = Cursors.WaitCursor

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\VC90_" & Format(Now(), "dd_MM_yyyy") & ".txt"

            If DataGridView1.RowCount > 0 Then

                If clsU.GeraTxt_DataTable("FRPJ_SP_CANC_OK_VC_PEND_RECTOR", strFile, False, "") Then
                    MessageBox.Show("Arquivo VC90 gerado com sucesso!" & vbCrLf & strFile, "Exportar Propostas", MessageBoxButtons.OK)
                    Call frm_Canc_OK_Robo_VC_Load(sender, New System.EventArgs)
                Else
                    MessageBox.Show("Erro ao gerar Arquivo VC90!" & vbCrLf & strFile, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhuma proposta pendente para exportação!", "Exportar Propostas", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtn_Reproc_Click(sender As Object, e As EventArgs) Handles tsbtn_Reproc.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPJ_SP_CHECK_ENVIAR_NOK_VC "))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_OK_REPROCESSAR_VC ")

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

    Private Sub tsbtn_Rector_Click(sender As Object, e As EventArgs) Handles tsbtn_Rector.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPJ_SP_CHECK_ENVIAR_NOK_VC "))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_OK_ENVIAR_RECTOR ")

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

            RecebeAlteracoes()
            Me.Validate()

            strSql = "EXEC FRPJ_SP_CANC_OK_VC "
            MyDa = cls.Return_DataAdapter(strSql)
            MyDa.UpdateCommand() = New SqlCommand("UPDATE tbl_Atendimento SET Nivel2_Enviar = @Nivel2 WHERE CodId_Atend_Pk = @Id")
            MyDa.UpdateCommand.Parameters.Add(New SqlParameter("@Nivel2", SqlDbType.Bit) With {.SourceColumn = "Selecione"})
            MyDa.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int) With {.SourceColumn = "CodId_Atend_Pk"})

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            DataGridView1.Refresh()

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
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                           Handles DataGridView1.CellContentClick
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
End Class