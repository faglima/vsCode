Imports System.IO

Public Class frm_Agencias_Importar

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim cls As New cls_SqlConnect
        Dim strFileCI As String
        Dim dlgResult As DialogResult
        'Dim strPath As String

        Try

            'strPath = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Arquivo_CI_CSV'")
            'OpenFileDialog1.InitialDirectory = strPath

            With OpenFileDialog1
                .Title = "Por favor, selecione o arquivo CSV"
                .Multiselect = False
                .Filter = "csv files (*.csv)|*.csv"
                .FileName = "*.csv"
                dlgResult = .ShowDialog()
            End With

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
        Dim lngRecordstxt As Long
        Dim lngRecords As Long

        Try

            If txtFile.Text = Nothing Then
                MessageBox.Show("Selecione o arquivo de Agências!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            strFileS = txtFile.Text
            strFileD = Path.GetFileNameWithoutExtension(strFileS).ToString
            strFileD = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_Server_Bulk'") & "\" & strFileD & ".txt"
            strSqlTable = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Agencia_SqlTable'")

            Application.DoEvents()

            If File.Exists(strFileD) Then
                Kill(strFileD)
            End If

            FileCopy(strFileS, strFileD)

            cls.Exec_Command_NQ("EXEC FRPJ_SP_TRUNCATE_TXT_AGENCIAS")

            lngRecordstxt = cls.Exec_Command_NQ("EXEC FRPJ_SP_BULK @SQLTable='" & strSqlTable & "',@TXTSource='" & strFileD & "'," _
                                           & "@FIRSTROW='2',@FIELDTERMINATOR='\n',@RecInsert=0", 3)

            If lngRecordstxt > 0 Then

                cls.Exec_Command_NQ("EXEC FRPJ_SP_TRUNCATE_AGENCIAS")

                lngRecords = cls.Exec_Command_NQ("FRPJ_SP_CARREGA_AGENCIAS")

            End If

            MessageBox.Show("Registros carregados: " & lngRecords, "Importar e Processar", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

End Class