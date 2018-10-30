Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_OK_Enviar_CM
    Dim myDataSet As DataSet

    Private Sub frm_Canc_OK_Enviar_CM__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cols As Integer = 0
            Dim i As Integer

            fLoadForm()

            cols = DataGridView1.Columns.Count - 1

            For i = 1 To cols
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

                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_TRUE_ENVIAR_CM")

                If lngRec > 0 Then
                    fLoadForm()
                Else
                    MessageBox.Show("Nenhum registro para selecão, o valor de devolução deve ser maior que zero!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPJ_SP_CANC_CHECK_ENVIAR_CM"))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_FALSE_ENVIAR_CM")

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

    Private Sub fSalvar()
        Try

            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPJ_SP_CANC_OK_ENVIAR_CM"
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                           Handles DataGridView1.CellContentClick
        Try
            Dim senderGrid = DirectCast(sender, DataGridView)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then

                If DataGridView1.Item(3, e.RowIndex).Value > 0 Then
                    fSalvar()
                Else
                    DataGridView1.EndEdit()
                    DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = False
                    'fSalvar()
                    MessageBox.Show("O valor de devolução deve ser maior que zero!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub fLoadForm()
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String


            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CANC_OK_ENVIAR_CM"
            myDataSet = cls.Return_DataSet(strSql)
            BindingSource1.DataSource = Nothing
            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns("Canc_Valor_Devolucao").DefaultCellStyle.Format = "N2"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtn_CM_Click(sender As Object, e As EventArgs) Handles tsbtn_CM.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim lngRec As Long = 0
            Dim strFile As String
            Dim strSql As String

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPJ_SP_CANC_CHECK_ENVIAR_CM"))

            If lngRec > 0 Then

                strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\CM_" & Format(Now(), "dd_MM_yyyy") & ".txt"
                strSql = " EXEC FRPJ_SP_NCORRENTISTA_ENVIAR_CM @Login=" & clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto)

                If clsU.GeraTxt_DataTable(strSql, strFile, True, ";") Then
                    lngRec = 0
                    strSql = " EXEC FRPJ_SP_UPDATE_NCORRENTISTA_ENVIAR_CM @Login=" & clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto)

                    lngRec = cls.Exec_Command_NQ(strSql)

                    If lngRec > 0 Then
                        fLoadForm()
                        MessageBox.Show("Arquivo gerado com sucesso!" & vbCrLf & strFile, "Gerar Arquivo CM", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Nenhum registro exportado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    MessageBox.Show("Nenhum registro exportado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Nenhum registro selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtn_Calc_Click(sender As Object, e As EventArgs) Handles tsbtn_Calc.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPJ_SP_CHECK_CALCULO_CM_VC"))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPJ_SP_UPDATE_CANC_OK_CALCULAR_CM_VC")

                If lngRec > 0 Then
                    fLoadForm()
                    MessageBox.Show("Cálculo de devolução realizado com sucesso!", "Calcular Devolução VC", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Erro ao tentar calcular devolução VC!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro VC para cálculo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class