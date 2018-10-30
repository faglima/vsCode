Imports System.IO

Public Class frm_Offline_Importar

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim strFileD As String
            Dim strFMTPathPJ As String
            Dim strFMTPathPF As String
            Dim strTxtTable As String
            Dim lngRecords As Long
            Dim intTotal As Integer
            Dim intSuc As Integer
            Dim intErr As Integer
            Dim dirSuc As DirectoryInfo
            Dim dirErr As DirectoryInfo
            Dim dirImp As DirectoryInfo

            Me.Cursor = Cursors.WaitCursor

            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_OffLine'")
            strFMTPathPJ = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='OffLine_PJ_FMT'")
            strFMTPathPF = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='OffLine_PF_FMT'")

            cls.Exec_Command_NQ("EXEC FRPJ_SP_TRUNCATE_TXT_PF")
            cls.Exec_Command_NQ("EXEC FRPJ_SP_TRUNCATE_TXT_PJ")

            txtProcess.Text = Nothing
            txtProcess.AppendText(String.Concat("Tabelas temporárias criadas", vbNewLine))

            dirImp = New DirectoryInfo(strFileD)

            Dim fiArrPF = dirImp.GetFiles("*_PF_*")

            strTxtTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='PF_SqlTable'")

            For Each strFile As FileInfo In fiArrPF

                lngRecords = ExecBulkFmt(strTxtTable, strFile.FullName, "1", ";", strFMTPathPF)

                If lngRecords > 0 Then

                    File.Copy(strFile.FullName, String.Concat(strFileD, "\", "Sucesso", "\", strFile.Name), True)

                    txtProcess.AppendText(String.Concat(strFile.Name, " processado com sucesso !", vbNewLine))

                Else

                    File.Copy(strFile.FullName, String.Concat(strFileD, "\", "Erro", "\", strFile.Name), True)

                    txtProcess.AppendText(String.Concat(strFile.Name, " erro no processo !", vbNewLine))

                End If

                Application.DoEvents()

            Next

            Dim fiArrPJ = dirImp.GetFiles("*_PJ_*")

            strTxtTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='PJ_SqlTable'")

            For Each strFile As FileInfo In fiArrPJ

                lngRecords = ExecBulkFmt(strTxtTable, strFile.FullName, "1", ";", strFMTPathPJ)

                If lngRecords > 0 Then

                    File.Copy(strFile.FullName, String.Concat(strFileD, "\", "Sucesso", "\", strFile.Name), True)

                    txtProcess.AppendText(String.Concat(strFile.Name, " processado com sucesso !", vbNewLine))

                Else

                    File.Copy(strFile.FullName, String.Concat(strFileD, "\", "Erro", "\", strFile.Name), True)

                    txtProcess.AppendText(String.Concat(strFile.Name, " erro no processo !", vbNewLine))

                End If

                Application.DoEvents()

            Next

            dirSuc = New DirectoryInfo(String.Concat(strFileD, "\", "Sucesso"))
            dirErr = New DirectoryInfo(String.Concat(strFileD, "\", "Erro"))

            intTotal = dirImp.GetFiles().Count
            intSuc = dirSuc.GetFiles().Count
            intErr = dirErr.GetFiles().Count

            txtProcess.AppendText(String.Concat("Total de arquivos: ", intTotal.ToString, vbNewLine))
            txtProcess.AppendText(String.Concat("Total de arquivos com sucesso: ", intSuc.ToString, vbNewLine))
            txtProcess.AppendText(String.Concat("Total de arquivos com erro: ", intErr.ToString, vbNewLine))

            cls.Exec_Command_Scalar("EXEC FRPJ_SP_INSERT_ATENDIMENTO_OFF")
            cls.Exec_Command_Scalar("EXEC FRPF_SP_INSERT_ATENDIMENTO_OFF", 2)

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

            lngRecordsTxt = cls.Exec_Command_NQ("EXEC FRPJ_SP_BULK_FMT @SQLTable='" & strSqlTable & "',@TXTSource='" & strFileD & "'," _
                                          & "@FIRSTROW='" & strFirstRow & "',@FIELDTERMINATOR='" & strFieldTerminator & "',@FORMATFILE = '" & strFMTPath & "',@RecInsert=0", 3)

            Return lngRecordsTxt
        Catch ex As Exception
            Return 0
        End Try


    End Function

    Private Sub frm_Offline_Importar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim strFileD As String

            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_OffLine'")
            txtPath.Text = strFileD

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        txtProcess.Text = Nothing
    End Sub
End Class