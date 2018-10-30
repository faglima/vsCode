Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_NOK_Nivel3_Baixar

    Private Sub txtVlrDev_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtVlrDev.Validating

        If Not txtVlrDev.Text = Nothing Then
            txtVlrDev.Text = FormatNumber(CDbl(txtVlrDev.Text), 2)
        Else
            txtVlrDev.Text = FormatNumber(CDbl(0), 2)
        End If

    End Sub

    Private Sub frm_Canc_NOK_Nivel3_Baixar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
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
            Dim strVlrDEv As String = "NULL"
            Dim strNivel2 As String = "0"
            Dim strObs As String = "NULL"
            Dim strSql As String = "NULL"
            Dim intRet As Integer = 0
            Dim strOrigem As String
            Dim ArrayItems As Array


            If txtObs.Text = Nothing Then
                Throw New Exception("O campo Obs é de digitação obrigatória, esta informação é importante para o entendimento do desfecho ou para que o 2º nível realize a solução final ")
            Else
                strObs = clsU.FormataStringSQL(txtObs.Text, cls_Utilities.TipoDado.Texto)
            End If

            ArrayItems = Split(Me.Tag, ";")
            strProtocolo = clsU.FormataStringSQL(ArrayItems(1).ToString, cls_Utilities.TipoDado.Numerico)
            strOrigem = ArrayItems(0).ToString

            If MessageBox.Show("Tem certeza que deseja baixar a ligação de protocolo " & strProtocolo & vbCrLf _
                               & "com  valor de devolução " & FormatNumber(CDbl(txtVlrDev.Text), 2) & " ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                If chkNivel2.CheckState = CheckState.Checked Then
                    strNivel2 = clsU.FormataStringSQL(chkNivel2.CheckState, cls_Utilities.TipoDado.Booleano)
                End If

                strLogin = clsU.FormataStringSQL(Environment.UserName, cls_Utilities.TipoDado.Texto)
                strVlrDEv = clsU.FormataStringSQL(txtVlrDev.Text, cls_Utilities.TipoDado.Numerico)
                'strProtocolo = clsU.FormataStringSQL(Me.Tag, cls_Utilities.TipoDado.Numerico)


                strSql = "EXEC FRPJ_SP_UPDATE_CANC_OK_NIVEL3 @CodId=" & strProtocolo & ", @Login=" & strLogin & ",@VlrDev=" & strVlrDEv & ",@Nivel2=" & strNivel2 & ",@Obs=" & strObs
                intRet = cls.Exec_Command_NQ(strSql)


                If intRet > 0 Then
                    MessageBox.Show("ligação de protocolo " & strProtocolo & " baixada com sucesso!", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_Canc_NOK_Nivel3.fLoadForm()
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

            Me.txtVlrDev.Text = FormatNumber(CDbl(0), 2)
            Me.txtObs.Text = Nothing
            Me.chkNivel2.CheckState = CheckState.Unchecked

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtVlrDev_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVlrDev.KeyPress

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = ",") Then

            e.Handled = True

        End If

    End Sub
End Class