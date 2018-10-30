Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime

Public Class frm_T_SQL
    Dim strLogin As String
    Dim myDataSet As DataSet

    Private Sub frm_T_SQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            strLogin = Environment.UserName

            cboDb.Items.Clear()
            cboDb.Items.Add("DB_FRPJ")
            cboDb.Items.Add("DB_FRPF")
            DataGridView1.DataSource = Nothing
            DataGridView1.Visible = False
            BindingSource1.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        Try
            cboDb.SelectedIndex = -1
            txtSql.Text = Nothing
            DataGridView1.DataSource = Nothing
            DataGridView1.Visible = False
            BindingSource1.DataSource = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click

        Dim cls As New cls_SqlConnect
        Dim strSql As String
        Dim conn As New SqlConnection
        Dim clsU As New cls_Utilities
        Dim intConn As Integer

        Try

            If Not txtSql.Text = Nothing And Not cboDb.Text = Nothing Then

                Me.Cursor = Cursors.WaitCursor

                strSql = txtSql.Text
                If InStr(1, strSql, "INTO", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando INTO não permitido!")
                End If
                If InStr(1, strSql, "EXEC", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando EXEC não permitido!")
                End If
                If InStr(1, strSql, "EXECUTE", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando EXECUTE não permitido!")
                End If
                If InStr(1, strSql, "UPDATE", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando UPDATE não permitido!")
                End If
                If InStr(1, strSql, "INSERT", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando INSERT não permitido!")
                End If
                If InStr(1, strSql, "DELETE", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando DELETE não permitido!")
                End If
                If InStr(1, strSql, "TRUNCATE", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando TRUNCATE não permitido!")
                End If
                If InStr(1, strSql, "sp_truncate", CompareMethod.Text) > 0 Then
                    Throw New Exception("Comando sp_truncate não permitido!")
                End If
                If InStr(1, strSql, "SELECT", CompareMethod.Text) = 0 Or InStr(1, strSql, "SELECT", CompareMethod.Text) > 1 Then
                    Throw New Exception("A instrução T-SQL deve ser iniciada pelo comando SELECT")
                End If

                If cboDb.Text = "DB_FRPJ" Then
                    intConn = 1
                Else
                    intConn = 2
                End If

                Me.DataGridView1.DataSource = Nothing
                Me.BindingSource1.DataSource = Nothing

                Me.DataGridView1.DataSource = Me.BindingSource1

                myDataSet = cls.Return_DataSet(strSql)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.ReadOnly = True
                'DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
                'clsU.FormatGrid(DataGridView1, BindingSource1)

                DataGridView1.Visible = True
            Else
                Throw New Exception("Favor informar o Database e a instrução T-SQL!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub frm_T_SQL_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try

            If e.KeyCode = Keys.F5 Then 'Imports Microsoft.VisualBasic
                btnExecute_Click(sender, New EventArgs)
                e.Handled = True
            ElseIf e.KeyCode = Keys.Escape Then 'Imports Microsoft.VisualBasic
                btnClear_Click(sender, New EventArgs)
                e.Handled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class