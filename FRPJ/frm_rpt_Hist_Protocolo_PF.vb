Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Imports System.Text

Public Class frm_rpt_Hist_Protocolo_PF
    Dim intPerfil As Integer


    Function GetCboItems(strSql As String) As List(Of cls_Populate)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql, 2)

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

    Private Sub frm_rpt_Protocolo_PF_Load(sender As Object, e As EventArgs) Handles Me.Load

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
            Dim strSql As String = Nothing
            Dim dtaTable As DataTable
            Dim strProtocolo As String
            Dim strCpf As String

            If Not txtProtocolo.Text = Nothing Or Not txtCPF.Text = Nothing Then

                Me.Cursor = Cursors.WaitCursor

                If Not txtProtocolo.Text = Nothing Then

                    strProtocolo = CStr(txtProtocolo.Text)

                    'If intPerfil = 6 Then
                    'strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO_OP @Protocolo=" & strProtocolo
                    'Else
                    'strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO @Protocolo=" & strProtocolo
                    'End If

                    'strSql = "FRPF_SP_ATENDIMENTO_PROTOCOLO_HISTORICO @Protocolo=" & strProtocolo

                    Dim strBuilder As New StringBuilder

                    strBuilder.AppendLine("SELECT Protocolo, CPF, Nome, DataNasc, Profissao, Banco, Agencia, ContaCorrente, Segmento, Atual_CodProduto, Atual_ImpSeg, Atual_Premio,")
                    strBuilder.AppendLine(" Atual_Proposta_VC,Atual_Apolice,Atual_Certificado,DDD,Telefone,Nivel_2,Nivel_2_Dt,Nivel_3,Nivel_3_Dt,Data_Solicitacao,")
                    strBuilder.AppendLine(" Ret_Eps,N_Correntista,Status,Nivel_2_Tratado,Nivel_2_Tratado_Dt,Nivel_2_Tratado_Login,Proposta_Nova,Alteracao_Data,")
                    strBuilder.AppendLine(" Alter_Premio,Alter_IS,Alter_OK,Alter_Data,Nivel_2_Motivo,Data_Ini_Vigencia,Data_Fim_Vigencia,Status_Ligacao,Opcao_Cliente_Det,")
                    strBuilder.AppendLine(" CodProduto_Det,CodProduto_Rector,Desc_Produto,Apolice,Premio_Det,ImpSeg_Det,Produto_Grupo,NomeUsuario,Origem_Ligacao,Obs,Nivel_2_Tratado_Obs")
                    strBuilder.AppendLine(" FROM tbl_Retencao WHERE Protocolo=" & strProtocolo)

                    strSql = strBuilder.ToString

                ElseIf Not txtCPF.Text = Nothing Then

                    strCpf = CStr(txtCPF.Text)

                    'If intPerfil = 6 Then
                    'strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO_OP @Protocolo=0, @Cpf=" & strCpf
                    'Else
                    'strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO @Protocolo=0, @Cpf=" & strCpf
                    'End If
                    'strSql = "EXEC FRPF_SP_ATENDIMENTO_PROTOCOLO_HISTORICO @Protocolo=0, @Cpf=" & strCpf

                    Dim strBuilder As New StringBuilder

                    strBuilder.AppendLine("SELECT Protocolo, CPF, Nome, DataNasc, Profissao, Banco, Agencia, ContaCorrente, Segmento, Atual_CodProduto, Atual_ImpSeg, Atual_Premio,")
                    strBuilder.AppendLine(" Atual_Proposta_VC,Atual_Apolice,Atual_Certificado,DDD,Telefone,Nivel_2,Nivel_2_Dt,Nivel_3,Nivel_3_Dt,Data_Solicitacao,")
                    strBuilder.AppendLine(" Ret_Eps,N_Correntista,Status,Nivel_2_Tratado,Nivel_2_Tratado_Dt,Nivel_2_Tratado_Login,Proposta_Nova,Alteracao_Data,")
                    strBuilder.AppendLine(" Alter_Premio,Alter_IS,Alter_OK,Alter_Data,Nivel_2_Motivo,Data_Ini_Vigencia,Data_Fim_Vigencia,Status_Ligacao,Opcao_Cliente_Det,")
                    strBuilder.AppendLine(" CodProduto_Det,CodProduto_Rector,Desc_Produto,Apolice,Premio_Det,ImpSeg_Det,Produto_Grupo,NomeUsuario,Origem_Ligacao,Obs,Nivel_2_Tratado_Obs")
                    strBuilder.AppendLine(" FROM tbl_Retencao WHERE CPF=" & strCpf)

                    strSql = strBuilder.ToString

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
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Try

            txtProtocolo.Text = Nothing
            txtCPF.Text = Nothing
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
                txtCPF.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCPF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCPF.Validating
        Try

            If Not txtCPF.Text = Nothing Then
                txtProtocolo.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class