﻿Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_NOK_Nivel32_Baixar

    Private Sub frm_Canc_NOK_Nivel32_Baixar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
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
            Dim strObs As String = "NULL"
            Dim strSql As String = "NULL"
            Dim intRet As Integer = 0
            Dim strOrigem As String
            Dim ArrayItems As Array


            If txtObs.Text = Nothing Then
                Throw New Exception("Por favor, informe a solução final!")
            Else
                strObs = clsU.FormataStringSQL(txtObs.Text, cls_Utilities.TipoDado.Texto)
            End If

            ArrayItems = Split(Me.Tag, ";")
            strProtocolo = clsU.FormataStringSQL(ArrayItems(1).ToString, cls_Utilities.TipoDado.Numerico)
            strOrigem = ArrayItems(0).ToString

            If MessageBox.Show("Tem certeza que deseja baixar a ligação de protocolo " & strProtocolo & " ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                strLogin = clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto)

                strSql = "EXEC FRPJ_SP_UPDATE_CANC_OK_NIVEL32 @CodId=" & strProtocolo & ", @Login=" & strLogin & ",@Obs=" & strObs
                intRet = cls.Exec_Command_NQ(strSql)

                If intRet > 0 Then
                    MessageBox.Show("ligação de protocolo " & strProtocolo & " baixada com sucesso!", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_Canc_NOK_Nivel32.fLoadForm()
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

    Private Sub frm_Canc_NOK_Nivel3_Baixar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.txtObs.Text = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class