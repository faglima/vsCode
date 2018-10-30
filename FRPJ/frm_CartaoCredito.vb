Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
Public Class frm_CartaoCredito

    Private Sub frm_CartaoCredito_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            rbtnVisa.Checked = False
            rbtnMaster.Checked = False
            txtCC1.Text = Nothing
            txtCC2.Text = "****"
            txtCC3.Text = "****"
            txtCC4.Text = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnVisa_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnVisa.CheckedChanged
        Try

            If rbtnVisa.Checked = True Then
                txtCC1.Text = "4***"
                txtCC4.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnMaster_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMaster.CheckedChanged
        Try

            If rbtnMaster.Checked = True Then
                txtCC1.Text = "5***"
                txtCC4.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim strBuilder As New StringBuilder
            Dim intErr As Integer = 0
            Dim strMsg As String

            If txtCC1.Text = Nothing Then
                intErr += 1
                strBuilder.AppendLine("Selecione a bandeira...")
            End If

            If txtCC4.Text = Nothing Then
                intErr += 1
                strBuilder.AppendLine("Digite os últimos 4 números do cartão de crédito...")
            End If

            If intErr = 0 Then
                If Me.Tag = Nothing Then
                    frm_Retencao_PF.txtCartaoBandeira.Text = Strings.Left(txtCC1.Text, 1)
                    frm_Retencao_PF.txtCartaoNumero.Text = txtCC4.Text
                    MessageBox.Show("Dados do cartão salvos com sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Dispose()
                    Me.Close()
                Else
                    frm_Retencao_PF_Off.txtCartaoBandeira.Text = Strings.Left(txtCC1.Text, 1)
                    frm_Retencao_PF_Off.txtCartaoNumero.Text = txtCC4.Text
                    MessageBox.Show("Dados do cartão salvos com sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Dispose()
                    Me.Close()
                End If

            Else
                strMsg = strBuilder.ToString
                MessageBox.Show(strMsg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub frm_CartaoCredito_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try

            rbtnVisa.Checked = False
            rbtnMaster.Checked = False
            txtCC1.Text = Nothing
            txtCC2.Text = "****"
            txtCC3.Text = "****"
            txtCC4.Text = Nothing
            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try

            If MessageBox.Show("Tem certeza que deseja cancelar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Me.Tag = Nothing Then
                    frm_Retencao_PF.rbtnCCredito.Checked = False
                Else
                    frm_Retencao_PF_Off.rbtnCCredito.Checked = False
                End If

                Me.Dispose()
                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class