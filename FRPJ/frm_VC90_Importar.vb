Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Imports System.Object
Imports System.Threading.Thread
Imports System.Globalization

Public Class frm_VC90_Importar

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim cls As New cls_SqlConnect
        Dim strFileCI As String
        Dim dlgResult As DialogResult
        Dim strPath As String

        Try

            OpenFileDialog1.Title = "Por favor, selecione o arquivo CSV"

            If Directory.Exists(My.Settings.VC90_Importar) Then
                strPath = My.Settings.VC90_Importar
            Else
                strPath = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Arquivo_CI_CSV'")
            End If

            OpenFileDialog1.InitialDirectory = strPath
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.Filter = "csv files (*.csv)|*.csv"
            OpenFileDialog1.FileName = "*.csv"

            dlgResult = OpenFileDialog1.ShowDialog()

            If dlgResult = DialogResult.OK Then
                My.Settings.VC90_Importar = Path.GetDirectoryName(OpenFileDialog1.FileName.ToString)
                txtFile.Text = OpenFileDialog1.FileName.ToString
                strFileCI = OpenFileDialog1.FileName.ToString
            Else
                txtFile.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim cls As New cls_SqlConnect
        Dim strFileS As String
        Dim strFileD As String
        Dim strSqlTable As String
        Dim lngRecords As Long
        Dim strUser As String

        Try

            If txtFile.Text = Nothing Then
                MessageBox.Show("Selecione o arquivo VC90!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            strFileS = txtFile.Text
            strFileD = Path.GetFileNameWithoutExtension(strFileS).ToString
            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_Server_Bulk'") & "\" & strFileD & ".txt"
            strSqlTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='VC90_SqlTable'")

            Application.DoEvents()

            If File.Exists(strFileD) Then
                Kill(strFileD)
            End If

            FileCopy(strFileS, strFileD)

            strUser = Environment.UserName

            cls.Exec_Command_NQ("EXEC FRPJ_SP_TRUNCATE_VC90")

            lngRecords = cls.Exec_Command_NQ("EXEC FRPJ_SP_BULK @SQLTable='" & strSqlTable & "',@TXTSource='" & strFileD & "'," _
                                           & "@FIRSTROW='2',@FIELDTERMINATOR=';',@RecInsert=0", 3)

            Select Me.Tag
                Case Is = "PE"
                    cls.Exec_Command_NQ("EXEC FRPJ_SP_UPDATE_VC90 @Login='" & strUser & "'")
                Case Is = "VC"
                    cls.Exec_Command_NQ("EXEC FRPJ_SP_UPDATE_VC90_VC")
            End Select

            MessageBox.Show("Registros carregados: " & lngRecords, "Importar e Processar", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

End Class