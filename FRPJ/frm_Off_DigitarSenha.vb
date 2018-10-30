Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Off_DigitarSenha

    Private Sub btnGerar_Click(sender As Object, e As EventArgs) Handles btnGerar.Click
        Try

            If Not txtSenha.Text = Nothing Then

                Me.Cursor = Cursors.WaitCursor

                Dim clsE As New cls_Crypto("FR")
                Dim strSenha As String
                Dim strSenha1 As String
                Dim dtExpira As Date
                Dim hrExpira As Date


                strSenha = txtSenha.Text

                strSenha1 = clsE.DecryptData(strSenha)
                dtExpira = DateSerial(DateAndTime.Year(Today()), DateAndTime.Month(Today()), Strings.Left(strSenha1, 2))
                hrExpira = dtExpira & " " & Strings.Right(strSenha1, 5)

                If Now() >= hrExpira Then
                    MessageBox.Show("Senha Expirada em " & hrExpira)
                Else

                    Dim strfile As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Off.txt"
                    Dim swFile = New StreamWriter(strfile)
                    swFile.WriteLine(hrExpira)
                    swFile.Close()






                    Me.Close()
                    Application.Restart()
                End If
            End If


        Catch ex As Exception
            If ex.GetType.Name = "FormatException" Then
                MessageBox.Show("Senha Inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class