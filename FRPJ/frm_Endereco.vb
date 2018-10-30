Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Imports Microsoft.VisualBasic
Public Class frm_Endereco

    Private Sub txtCEP_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCEP.Validating
        Try

            Dim cls As New cls_SqlConnect
            Dim dtr As SqlDataReader

            If txtCEP.MaskCompleted = True Then
                dtr = cls.Return_DataReader("EXEC FRPF_SP_GET_ENDERECO '" & txtCEP.Text & "'", 2)

                If dtr.HasRows Then
                    dtr.Read()
                    txtEnd.Text = dtr.Item("logradouro").ToString
                    txtBairro.Text = dtr.Item("bairro").ToString
                    txtCidade.Text = dtr.Item("cidade").ToString
                    txtUF.Text = dtr.Item("UF").ToString
                    txtNro.Focus()
                Else
                    txtEnd.Text = Nothing
                    txtBairro.Text = Nothing
                    txtCidade.Text = Nothing
                    txtUF.Text = Nothing
                End If

                dtr.Close()
            Else
                txtEnd.Text = Nothing
                txtBairro.Text = Nothing
                txtCidade.Text = Nothing
                txtUF.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frm_Endereco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Return) Then 'Imports Microsoft.VisualBasic
                SendKeys.Send("{TAB}")
                e.Handled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_Endereco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsU As New cls_Utilities
            Dim strSql As String

            strSql = "select CodId_Tipo_Res,Tipo_Res from tbl_Tipo_Residencia where CodId_Tipo_Res>0"
            clsU.GetCboItems(strSql, cboTipoRes, 2)
            If Not String.IsNullOrEmpty(Me.Tag) Then
                cboTipoRes.SelectedValue = Me.Tag
                cboTipoRes.Enabled = False
            Else
                cboTipoRes.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBaixar_Click(sender As Object, e As EventArgs) Handles btnBaixar.Click
        Try
            Dim intErr As Integer = 0

            Dim textBoxes = Me.Controls.OfType(Of TextBox)()

            For Each t In textBoxes
                If Not t.Name = "txtComplemento" Then
                    If String.IsNullOrEmpty(t.Text) Then
                        intErr += 1
                        ErrProv.SetError(t, "Preenchimento obrigatório")
                    Else
                        intErr += 0
                        ErrProv.SetError(t, "")
                    End If
                End If
            Next t
            Dim MaskedTxt = Me.Controls.OfType(Of MaskedTextBox)()

            For Each c In MaskedTxt

                If String.IsNullOrEmpty(c.Text) Then
                    intErr += 1
                    ErrProv.SetError(c, "Preenchimento obrigatório")
                Else
                    intErr += 0
                    ErrProv.SetError(c, "")
                End If

            Next c

            If cboTipoRes.SelectedIndex = -1 Then
                intErr += 1
                ErrProv.SetError(cboTipoRes, "Preenchimento obrigatório")
            Else
                intErr += 0
                ErrProv.SetError(cboTipoRes, "")
            End If

            If intErr > 0 Then
                MessageBox.Show("Favor preencher os dados corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                chkSave.Checked = True
                With frm_Retencao_PF
                    .CepRes = txtCEP.Text
                    .EnderecoRes = txtEnd.Text
                    .NroRes = txtNro.Text
                    If Not String.IsNullOrEmpty(txtComplemento.Text) Then .ComplementoRes = txtComplemento.Text
                    .BairroRes = txtBairro.Text
                    .CidadeRes = txtCidade.Text
                    .UFRes = txtUF.Text
                    .TipoRes = cboTipoRes.SelectedValue
                    MessageBox.Show("Dados salvos com sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()

                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frm_Endereco_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try

            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCan_Click(sender As Object, e As EventArgs) Handles btnCan.Click
        Try

            If MessageBox.Show("Tem certeza que deseja cancelar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                frm_Retencao_PF.rbtnVenda.Checked = False
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNro_ValidaNumero(sender As Object, e As KeyPressEventArgs) Handles txtNro.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
End Class