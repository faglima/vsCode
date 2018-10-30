Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_rpt_Protocolo_PF
    Dim intPerfil As Integer


    Function GetCboItems(strSql As String) As List(Of cls_Populate)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql)

            If dtr.HasRows Then
                Do While dtr.Read
                    cboItems.Add(New cls_Populate(dtr.Item(0).ToString(), dtr.Item(1).ToString()))
                Loop
            Else
                cboItems.Add(New cls_Populate(0, ""))
            End If

            dtr.Close()

            Return cboItems

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub frm_rpt_Protocolo_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim conn As New SqlConnection
            Dim strLogin As String


            strLogin = Environment.UserName

            intPerfil = cls.Exec_Command_Scalar("select top 1 PerfilUsuario from tbl_usuario where login='" & strLogin & "'")

            Me.DataGridView1.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String = ""
            Dim dtaTable As DataTable
            Dim strProtocolo As String = "0"
            Dim strCnpj As String = "0"
            Dim strApolice As String = "0"
            Dim strCertificado As String = "0"

            If Not txtProtocolo.Text = Nothing Or Not txtCpf.Text = Nothing Or Not txtApolice.Text = Nothing _
               Or Not txtCertificado.Text = Nothing Then

                If Not txtProtocolo.Text = Nothing Then
                    strProtocolo = CStr(txtProtocolo.Text)
                End If
                If Not txtCpf.Text = Nothing Then
                    strCnpj = CStr(txtCpf.Text)
                End If
                If Not txtApolice.Text = Nothing Then
                    strApolice = CStr(txtApolice.Text)
                End If
                If Not txtCertificado.Text = Nothing Then
                    strCertificado = CStr(txtCertificado.Text)
                End If

                If intPerfil = 6 Then
                    strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO_OP @Protocolo=" & strProtocolo & ",@Cpf=" & strCnpj & ",@Apolice=" & strApolice & ",@Certificado=" & strCertificado
                Else
                    strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO @Protocolo=" & strProtocolo & ",@Cpf=" & strCnpj & ",@Apolice=" & strApolice & ",@Certificado=" & strCertificado
                End If

                Me.DataGridView1.DataSource = Me.BindingSource1

                dtaTable = cls.Return_DataTable(strSql, 2)

                BindingSource1.DataSource = dtaTable
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 32
                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

                DataGridView1.Refresh()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Try

            txtProtocolo.Text = Nothing
            txtCpf.Text = Nothing
            txtApolice.Text = Nothing
            txtCertificado.Text = Nothing

            Me.DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
    Private Sub txtProtocolo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProtocolo.KeyPress

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If

    End Sub

    Private Sub txtProtocolo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProtocolo.Validating
        Try

            If Not txtProtocolo.Text = Nothing Then
                txtCpf.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCnpj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCpf.Validating
        Try

            If Not txtCpf.Text = Nothing Then
                txtProtocolo.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtApolice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApolice.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtCertificado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCertificado.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub
End Class