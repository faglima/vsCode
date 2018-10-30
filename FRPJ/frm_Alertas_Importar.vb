Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Imports System.Object
Imports System.Threading.Thread
Imports System.Globalization

Public Class frm_Alertas_Importar

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim cls As New cls_SqlConnect
        Dim strFileCI As String
        Dim dlgResult As DialogResult
        Dim strPath As String

        Try

            OpenFileDialog1.Title = "Por favor, selecione o arquivo CSV"
            strPath = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Arquivo_CI_CSV'")

            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.InitialDirectory = strPath
            OpenFileDialog1.Filter = "csv files (*.csv)|*.csv"
            OpenFileDialog1.FileName = "*.csv"

            dlgResult = OpenFileDialog1.ShowDialog()

            If dlgResult = DialogResult.OK Then
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
                MessageBox.Show("Selecione o arquivo de Alerta!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            strFileS = txtFile.Text
            strFileD = Path.GetFileNameWithoutExtension(strFileS).ToString
            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_Server_Bulk'") & "\" & strFileD & ".txt"
            strSqlTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Alerta_SqlTable'")

            Application.DoEvents()

            If File.Exists(strFileD) Then
                Kill(strFileD)
            End If

            FileCopy(strFileS, strFileD)

            strUser = Environment.UserName

            'cls.Exec_Command_NQ("EXEC FRPJ_SP_TRUNCATE_ALERTA")

            lngRecords = cls.Exec_Command_NQ("EXEC FRPJ_SP_BULK @SQLTable='" & strSqlTable & "',@TXTSource='" & strFileD & "'," _
                                           & "@FIRSTROW='2',@FIELDTERMINATOR=';',@RecInsert=0", 3)


            MessageBox.Show(lngRecords & " registros carregados com sucesso!", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFile.Text = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


End Class