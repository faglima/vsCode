Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Endosso_NOK_Baixar

    Private Sub frm_Endosso_NOK_Baixar_Baixar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Return) Then 'Imports Microsoft.VisualBasic
                SendKeys.Send("{TAB}")
                e.Handled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCan_Click(sender As Object, e As EventArgs) Handles btnCan.Click
        Try

            Me.Dispose()
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBaixar_Click(sender As Object, e As EventArgs) Handles btnBaixar.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strLogin As String = "NULL"
            Dim strProtocolo As String = "NULL"
            Dim strProposta As String = "NULL"
            Dim strObs As String = "NULL"
            Dim strSql As String = "NULL"
            Dim intRet As Integer = 0
            Dim strEmitido As String = "0"
            Dim strFrmOrigem As String = "0"

            'strFrmOrigem = 1 - Emissão | 2 - Endosso | 3 - Endosso CC  

            If txtProposta.Text = Nothing Then
                Throw New Exception("Digite o número da proposta VC!")
            Else
                strProposta = clsU.FormataStringSQL(txtProposta.Text, cls_Utilities.TipoDado.Numerico)
                strEmitido = "1"
            End If

            If txtObs.Text = Nothing Then
                Throw New Exception("Digite uma justificativa breve!")
            Else
                strObs = clsU.FormataStringSQL(txtObs.Text, cls_Utilities.TipoDado.Texto)
            End If



            Dim ArrayItems As Array

            ArrayItems = Split(Me.Tag, ";")
            strProtocolo = clsU.FormataStringSQL(ArrayItems(0).ToString, cls_Utilities.TipoDado.Numerico)
            strFrmOrigem = ArrayItems(2).ToString

            If MessageBox.Show("Tem certeza que deseja baixar a ligação de protocolo " & strProtocolo, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                strLogin = clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto)
                strObs = clsU.FormataStringSQL(txtObs.Text, cls_Utilities.TipoDado.Texto)

                Select Case strFrmOrigem
                    Case Is = 1
                        strSql = "EXEC FRPF_SP_EMISSAO_UPDATE_OK_MANUAL @CodId=" & strProtocolo & ", @Proposta=" & strProposta & ",@Login=" & strLogin & ",@Obs=" & strObs
                    Case Is = 2
                        strSql = "EXEC FRPF_SP_ENDOSSO_UPDATE_OK_MANUAL @CodId=" & strProtocolo & ", @Proposta=" & strProposta & ",@Login=" & strLogin & ",@Obs=" & strObs
                    Case Is = 3
                        strSql = "EXEC FRPF_SP_ENDOSSO_CC_UPDATE_OK_MANUAL @CodId=" & strProtocolo & ", @Proposta=" & strProposta & ",@Login=" & strLogin & ",@Obs=" & strObs
                End Select

                intRet = cls.Exec_Command_NQ(strSql, 2)

                If intRet > 0 Then
                    MessageBox.Show("ligação de protocolo " & strProtocolo & " baixada com sucesso!", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Select Case strFrmOrigem
                        Case Is = 1
                            frm_Venda_NOK.fLoadForm("NULL")
                            frm_Venda_NOK.fLoadCboMotivo()
                        Case Is = 2
                            frm_Endosso_NOK.fLoadForm("NULL")
                            frm_Endosso_NOK.fLoadCboMotivo()
                        Case Is = 3
                            frm_EndossoCC_NOK.fLoadForm("NULL")
                            frm_EndossoCC_NOK.fLoadCboMotivo()
                    End Select

                    Me.Dispose()
                    Me.Close()
                Else
                    MessageBox.Show("Erro ao baixar ligação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Dispose()
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    

    Private Sub txtProposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProposta.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = ",") Then

            e.Handled = True

        End If
    End Sub

End Class