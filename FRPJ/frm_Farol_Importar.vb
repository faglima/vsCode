Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Imports System.Object
Imports System.Threading.Thread
Imports System.Globalization

Public Class frm_Farol_Importar

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim cls As New cls_SqlConnect
        Dim strFileCI As String
        Dim dlgResult As DialogResult
        Dim strPath As String

        Try

            OpenFileDialog1.Title = "Por favor, selecione o arquivo TXT"

            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.Filter = "txt files (*.txt)|*.txt"
            OpenFileDialog1.FileName = "*.txt"

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
        Dim strSql As String
        Dim strFmtFile As String

        Try

            If txtFile.Text = Nothing Then
                MessageBox.Show("Selecione o arquivo de Farol!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            strFileS = txtFile.Text
            strFileD = Path.GetFileNameWithoutExtension(strFileS).ToString
            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_Server_Bulk'") & "\" & strFileD & ".txt"
            strSqlTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Farol_SqlTable'")
            strFmtFile = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Farol_FMT'")


            Application.DoEvents()

            If File.Exists(strFileD) Then
                Kill(strFileD)
            End If

            FileCopy(strFileS, strFileD)

            strUser = Environment.UserName

            cls.Exec_Command_NQ("DELETE FROM " & strSqlTable, 2)

            'strSql = "INSERT INTO " & strSqlTable & " (Estrela,Farol_G) " _
            '         & "SELECT CASE WHEN ISNULL(T1.FAROL,'0') = 'Verde' THEN 1 WHEN ISNULL(T1.FAROL,'0') = 'Amarelo' THEN 2 WHEN ISNULL(T1.FAROL,'0') = 'Vermelho' THEN 3 ELSE 1 END,T1.CPF " _
            '         & "FROM OPENROWSET (BULK '" & strFileD & "', FORMATFILE = '" & strFmtFile & "', FIRSTROW=2, CODEPAGE='ACP') AS T1"

            strSql = "SELECT 'Estrela' as tCols UNION ALL SELECT 'Farol_G' as tCols UNION ALL SELECT 'Farol_Y' as tCols"

            Dim dtretorno = cls.Return_DataTable(strSql, 2)
            Dim colunas As List(Of String) = New List(Of String)

            For Each row As DataRow In dtretorno.Rows
                colunas.Add(row("tCols"))
            Next

            Dim dtArquivo As DataTable
            Dim BulkManager As New ImportText()

            dtArquivo = BulkManager.OpenFile(strFileS, Nothing, colunas.ToArray(), vbTab.ToString, True)
            dtArquivo.TableName = strSqlTable

            If dtArquivo.Rows.Count > 0 Then

                ' faz o bulk insert
                BulkManager.BulkInsert(dtArquivo, colunas.ToArray(), 4)

            Else

                Throw New Exception("Não foi possível obter informação do arquivo.")

            End If


            lngRecords = cls.Exec_Command_NQ(strSql, 2)


            MessageBox.Show(lngRecords & " registros carregados com sucesso!", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFile.Text = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


End Class