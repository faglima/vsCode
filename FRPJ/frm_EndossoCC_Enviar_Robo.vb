Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_EndossoCC_Enviar_Robo
    Dim myDataSet As DataSet
    Private Sub frm_EndossoCC_Enviar_Robo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_ENDOSSO_CC_PENDENTE"
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

    Private Sub tsbtn_EnviarRobo_Click(sender As Object, e As EventArgs) Handles tsbtn_EnviarRobo.Click
        Dim cls As New cls_SqlConnect
        Dim lngReg As Long = 0
        Dim lngRegDataGrid As Long = 0


        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then
                lngRegDataGrid = DataGridView1.RowCount

                lngReg = cls.Exec_Command_NQ("EXEC FRPF_SP_ENDOSSO_CC_UPDATE_ENVIAR_ROBO @Login='" & Environment.UserName & "'", 2)

                If (lngReg) > 0 Then
                    MessageBox.Show("Ligações enviadas para endosso com sucesso, favor acionar o robô de endosso Cartão!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_EndossoCC_Enviar_Robo_Load(sender, New EventArgs)
                Else
                    MessageBox.Show("Erro ao enviar ligações!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Nenhum registro para enviar ao robô de endosso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
End Class