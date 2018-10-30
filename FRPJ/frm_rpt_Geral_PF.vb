Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_rpt_Geral_PF
    Dim intPerfil As Integer


    Function GetCboItems(strSql As String, Optional ByVal intConn As Integer = 1) As List(Of cls_Populate)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql, intConn)

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
            Return Nothing
        End Try

    End Function
    Private Sub frm_rpt_Geral_PF_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim strLogin As String
            Dim strLoginF As String
            Dim strDataIni As String
            Dim strDataFim As String
            Dim dtaTable As DataTable
            Dim strEps As String
            Dim strSup As String

            strLogin = Environment.UserName

            intPerfil = cls.Exec_Command_Scalar("select top 1 PerfilUsuario from tbl_usuario where login='" & strLogin & "'")

            PopulaCombo("select CodId_Usuario, UPPER(NomeUsuario) AS NomeUsuario from tbl_Usuario where PerfilUsuario=6 order by NomeUsuario", cboOperador)
            PopulaCombo("select CodId_Usuario, UPPER(NomeUsuario) AS NomeUsuario from tbl_Usuario where PerfilUsuario=5 order by NomeUsuario", cboSupervisor)
            PopulaCombo("select CodId_Eps_Pk, Eps from tbl_Eps", cboEPS)

            txtDtIni.Text = Today
            txtDtFim.Text = Today

            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            If cboEPS.SelectedIndex = -1 Then
                strEps = "NULL"
            Else
                strEps = cboEPS.SelectedValue.ToString
            End If

            If cboSupervisor.SelectedIndex = -1 Then
                strSup = "NULL"
            Else
                strSup = cboSupervisor.SelectedValue.ToString
            End If

            If intPerfil = 6 Then
                Dim intCodIdUser As Integer

                strLoginF = "'" & strLogin & "'"

                intCodIdUser = cls.Exec_Command_Scalar("select top 1 CodId_Usuario from tbl_usuario where login='" & strLogin & "'")
                cboOperador.SelectedValue = intCodIdUser
                cboOperador.Enabled = False
                strSql = "EXEC FRPF_SP_ATENDIMENTO_GERAL_OP @DataIni='" & strDataIni & "',@DataFim='" & strDataFim & "',@Operador=" & strLoginF
                cboEPS.Visible = False
                Label5.Visible = False
                Label4.Visible = False
                cboSupervisor.Visible = False
            Else
                strLoginF = "NULL"
                cboOperador.Enabled = True
                cboOperador.SelectedIndex = -1
                strSql = "EXEC FRPF_SP_ATENDIMENTO_GERAL @DataIni='" & strDataIni & "',@DataFim='" & strDataFim & "',@Operador=" & strLoginF & ",@IDSup=" & strSup & ",@EPS=" & strEps
                cboEPS.Visible = True
                cboSupervisor.Visible = True
                Label5.Visible = True
                Label4.Visible = True
            End If

            Me.DataGridView1.DataSource = Me.BindingSource1

            dtaTable = cls.Return_DataTable(strSql, 2)

            BindingSource1.DataSource = dtaTable
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 32
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim strDataIni As String
            Dim strDataFim As String
            Dim strLogin As String
            Dim dtaTable As DataTable
            Dim strEps As String
            Dim strSup As String

            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            If cboOperador.SelectedIndex = -1 Then
                strLogin = "NULL"
            Else
                strLogin = "'" & cls.Exec_Command_Scalar("select top 1 Login from tbl_usuario where CodId_Usuario=" & cboOperador.SelectedValue) & "'"
            End If

            If cboEPS.SelectedIndex = -1 Then
                strEps = "NULL"
            Else
                strEps = cboEPS.SelectedValue.ToString
            End If

            If cboSupervisor.SelectedIndex = -1 Then
                strSup = "NULL"
            Else
                strSup = cboSupervisor.SelectedValue.ToString
            End If

            If intPerfil = 6 Then
                strSql = "EXEC FRPF_SP_ATENDIMENTO_GERAL_OP @DataIni='" & strDataIni & "',@DataFim='" & strDataFim & "',@Operador=" & strLogin
            Else
                strSql = "EXEC FRPF_SP_ATENDIMENTO_GERAL @DataIni='" & strDataIni & "',@DataFim='" & strDataFim & "',@Operador=" & strLogin & ",@IDSup=" & strSup & ",@EPS=" & strEps
            End If

            Me.DataGridView1.DataSource = Me.BindingSource1

            dtaTable = cls.Return_DataTable(strSql, 2)

            BindingSource1.DataSource = dtaTable
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim strDataIni As String
            Dim strDataFim As String
            Dim strLogin As String
            Dim dtaTable As DataTable

            txtDtIni.Text = Today
            txtDtFim.Text = Today


            strDataIni = CStr(CDate(txtDtIni.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtIni.Text).Day), 2)
            strDataFim = CStr(CDate(txtDtFim.Text).Year) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(txtDtFim.Text).Day), 2)

            If intPerfil = 6 Then
                strLogin = "'" & cls.Exec_Command_Scalar("select top 1 Login from tbl_usuario where CodId_Usuario=" & cboOperador.SelectedValue) & "'"
                strSql = "EXEC FRPF_SP_ATENDIMENTO_GERAL_OP @DataIni='" & strDataIni & "',@DataFim='" & strDataFim & "',@Operador=" & strLogin
            Else
                strLogin = "NULL"
                cboOperador.SelectedIndex = -1
                cboEPS.SelectedIndex = -1
                cboSupervisor.SelectedIndex = -1
                strSql = "EXEC FRPF_SP_ATENDIMENTO_GERAL @DataIni='" & strDataIni & "',@DataFim='" & strDataFim & "',@Operador=" & strLogin
            End If


            Me.DataGridView1.DataSource = Me.BindingSource1

            dtaTable = cls.Return_DataTable(strSql, 2)

            BindingSource1.DataSource = dtaTable
            BindingNavigator1.BindingSource = BindingSource1


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


    Private Sub txtDtIni_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDtIni.Validating
        Try

            If txtDtIni.MaskFull = False OrElse IsDate(txtDtIni.Text) = False Then
                txtDtIni.Text = Today
            ElseIf CDate(txtDtIni.Text) > CDate(txtDtFim.Text) Then
                txtDtFim.Text = txtDtIni.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtDtFim_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDtFim.Validating
        Try

            If txtDtFim.MaskFull = False OrElse IsDate(txtDtFim.Text) = False Then
                txtDtFim.Text = txtDtIni.Text
            ElseIf CDate(txtDtFim.Text) < CDate(txtDtIni.Text) Then
                txtDtFim.Text = txtDtIni.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PopulaCombo(strSQL As String, ByRef cbo As ComboBox)
        With cbo
            .DataSource = GetCboItems(strSQL, 1)
            .DisplayMember = "Item"
            .ValueMember = "ID"
            .SelectedIndex = -1
        End With
    End Sub

End Class