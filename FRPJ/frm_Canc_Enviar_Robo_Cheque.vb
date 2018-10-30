Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_Enviar_Robo_Cheque
    Dim myDataSet As DataSet
    Private Sub frm_Canc_Enviar_Robo_VC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim cols As Integer = 0

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CANC_ENVIAR_ROBO_CHEQUE"
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            cols = DataGridView1.Columns.Count - 1

            For i = 1 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next

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

    Private Sub tsbtn_EnviarRobo_Click(sender As Object, e As EventArgs) Handles tsbtn_EnviarRobo.Click
        Dim cls As New cls_SqlConnect
        Dim lngReg As Long = 0

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then

                lngReg = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_ENVIAR_ROBO_CHEQUE @Login='" & Environment.UserName & "'")

                If (lngReg) > 0 Then
                    MessageBox.Show(" Ligações enviadas para verificação de Cheque Especial, favor acionar o robô de Cheque Especial!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_Canc_Enviar_Robo_VC_Load(sender, New EventArgs)
                Else
                    MessageBox.Show("0 Ligações enviadas para robô de Cheque Especial!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Nenhum registro para enviar ao robô de Cheque Especial!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub txtLotes_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub
    Private Sub fSalvar(intId As Integer)
        Try

            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPJ_SP_CANC_UPDATE_SELECIONAR_ID " & intId.ToString
            cls.Exec_Command_NQ(strSql)

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

                fSalvar(DataGridView1.Item("CodId_Atend_Pk", e.RowIndex).Value)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsbtn_EnviarRobo2_Click(sender As Object, e As EventArgs) Handles tsbtn_EnviarRobo2.Click
        Dim cls As New cls_SqlConnect
        Dim lngReg As Long = 0


        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then

                lngReg = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_ENVIAR_ROBO_CHEQUE_SELECT @Login='" & Environment.UserName & "'")

                If (lngReg) > 0 Then
                    MessageBox.Show(lngReg & " Ligações enviadas para verificação de Cheque Especial, favor acionar o robô de Cheque Especial!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_Canc_Enviar_Robo_VC_Load(sender, New EventArgs)
                Else
                    MessageBox.Show("0 Ligações enviadas para robô de Cheque Especial!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Nenhum registro para enviar ao robô de Cheque Especial!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class