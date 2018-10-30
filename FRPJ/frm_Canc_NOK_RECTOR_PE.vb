Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_NOK_RECTOR_PE
    Dim myDataSet As DataSet
    Private Sub frm_Canc_NOK_RECTOR_PE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CANC_NOK_RECTOR_PE"

            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ReadOnly = True
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
                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_UPDATE_CANC_NOK_RECTOR_PE_EXP")
                If lngRec > 0 Then
                    If clsU.GeraTxt_DataTable("FRPJ_SP_CANC_NOK_RECTOR_PE_EXP", strFile, False, "") Then
                        lngRec = 0
                        lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_UPDATE_CANC_NOK_RECTOR_PE_EXP_OK " & clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto))
                        If lngRec > 0 Then
                            MessageBox.Show("Arquivo VC90 gerado com sucesso!" & vbCrLf & strFile, "Exportar Propostas", MessageBoxButtons.OK)
                            Call frm_Canc_NOK_RECTOR_PE_Load(sender, New System.EventArgs)
                        Else
                            MessageBox.Show("Erro ao gerar Arquivo VC90!" & vbCrLf & strFile, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Erro ao gerar Arquivo VC90!" & vbCrLf & strFile, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
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
End Class