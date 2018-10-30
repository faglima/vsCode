Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Ferrari_Enviar
    Dim myDataSet As DataSet
    Private Sub frm_Ferrari_Enviar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_OFERTA_FERRARI_PENDENTE"

            myDataSet = cls.Return_DataSet(strSql, 2)

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
            Dim dtr As SqlDataReader
            Dim strSql As String
            Dim strFile As String
            Dim lngRec As Long = 0
            Dim strCodConnect As String = "NULL"

            Cursor = Cursors.WaitCursor

            If DataGridView1.RowCount > 0 Then
                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_OFERTA_UPDATE_MARCAR", 2)
                If lngRec > 0 Then

                    strSql = "EXEC FRPF_SP_GET_OFERTA_CBO"

                    dtr = cls.Return_DataReader(strSql, 2)

                    If dtr.HasRows Then
                        Do While dtr.Read
                            strCodConnect = clsU.FormataStringSQL(dtr.Item(0).ToString(), cls_Utilities.TipoDado.Numerico)
                            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & strCodConnect & "_VC_GRPCLI_LISTAS_" & Format(Now(), "ddMMyyyy") & ".txt"
                            strSql = "EXEC FRPF_SP_OFERTA_FERRARI_FILE @CodFerrari=" & strCodConnect
                            clsU.GeraTxt_DataTable(strSql, strFile, False, "", 2, 2)
                        Loop

                        strSql = "EXEC FRPF_SP_OFERTA_UPDATE_FERRARI_EXP @Login=" & clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto)
                        lngRec = cls.Exec_Command_NQ(strSql, 2)

                        If lngRec > 0 Then
                            MessageBox.Show("Arquivos Ferrari gerados em seu desktop com sucesso!", "Gerar Connect Ferrari", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Call frm_Ferrari_Enviar_Load(sender, New EventArgs)
                        Else
                            MessageBox.Show("Erro update Ferrari!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    Else
                        MessageBox.Show("Nenhuma oferta ATIVA verifique o cadastro de ofertas Ferrari!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    dtr.Close()

                Else
                    MessageBox.Show("Erro ao gerar Arquivos Ferrari!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Nenhuma oferta pendente para exportação!", "Atenção", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
End Class