Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Imports System.Object
Imports System.Threading.Thread
Imports System.Globalization

Public Class frm_Connect_Canc_Importar_OK

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click

        Dim cls As New cls_SqlConnect
        Dim strFileCI As String
        Dim dlgResult As DialogResult
        Dim strPath As String = Nothing

        Try

            OpenFileDialog1.Title = "Por favor, selecione o arquivo txt"

            If Directory.Exists(My.Settings.Imp_Connect_Canc_OK) Then
                strPath = My.Settings.Imp_Connect_Canc_OK
            End If

            OpenFileDialog1.InitialDirectory = strPath
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.Filter = "txt files (*.txt)|*.txt"
            OpenFileDialog1.FileName = "*.txt"

            dlgResult = OpenFileDialog1.ShowDialog()

            If dlgResult = DialogResult.OK Then
                My.Settings.Imp_Connect_Canc_OK = Path.GetDirectoryName(OpenFileDialog1.FileName.ToString)
                txtFile.Text = OpenFileDialog1.FileName.ToString
                strFileCI = OpenFileDialog1.FileName.ToString
            Else
                txtFile.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnImp_Click(sender As System.Object, e As System.EventArgs) Handles btnImp.Click

        Dim cls As New cls_SqlConnect
        Dim strFileS As String
        Dim strFileD As String
        Dim strSqlTable As String
        Dim strFMTPath As String
        Dim lngRecords As Long

        Try

            If txtFile.Text = Nothing Then
                Throw New Exception("Selecione o arquivo !")
            End If

            Me.Cursor = Cursors.WaitCursor

            strFileS = txtFile.Text
            strFileD = Path.GetFileNameWithoutExtension(strFileS).ToString
            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_Server_Bulk'") & "\" & strFileD & ".txt"
            strSqlTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Connect_Canc_OK_SqlTable'")
            strFMTPath = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Connect_Canc_OK_FMT'")

            Application.DoEvents()

            If File.Exists(strFileD) Then
                Kill(strFileD)
            End If

            FileCopy(strFileS, strFileD)

            lngRecords = ExecBulkFmt(strSqlTable, strFileD, 1, "", strFMTPath)

            MessageBox.Show("Registros carregados e processados: " & lngRecords, "Importar e Processar", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Function ExecBulkFmt(ByVal strSqlTable As String, ByVal strFileD As String, ByVal strFirstRow As String, ByVal strFieldTerminator As String, ByVal strFMTPath As String) As Integer

        Try
            Dim cls As New cls_SqlConnect
            Dim lngRecordsTxt As Long = 0

            cls.Exec_Command_NQ("EXEC sp_truncate '" & strSqlTable & "'")

            lngRecordsTxt = cls.Exec_Command_NQ("EXEC FRPJ_SP_BULK_FMT @SQLTable='" & strSqlTable & "',@TXTSource='" & strFileD & "'," _
                                          & "@FIRSTROW='" & strFirstRow & "',@FIELDTERMINATOR='" & strFieldTerminator & "',@FORMATFILE = '" & strFMTPath & "',@RecInsert=0", 3)

            cls.Exec_Command_NQ("EXEC FRPJ_SP_CONNECT_CANC_UPDATE_OK")


            Return lngRecordsTxt


        Catch ex As Exception
            Return 0
        End Try


    End Function

End Class