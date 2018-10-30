Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Connect_Canc_Enviar_RECTOR
    Dim myDataSet As DataSet
    Private Sub frm_Connect_Canc_Enviar_RECTOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CONNECT_CANC_A_ENVIAR"
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ReadOnly = True
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub tsbtn_Excel_Click(sender As Object, e As EventArgs) Handles tsbtn_Excel.Click
        Dim cls As New cls_Utilities

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then
                cls.GeraTxt_DataGrid(Me.DataGridView1)
            Else
                MessageBox.Show("Nenhum registro para geração de arquivo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtn_EnviarRobo_Click(sender As Object, e As EventArgs) Handles tsbtn_EnviarRobo.Click

        Dim cls As New cls_SqlConnect
        Dim clsU As New cls_Utilities
        Dim strFile As String
        Dim lngReg As Long

        Try
            Me.Cursor = Cursors.WaitCursor

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Cancel_Seguros.txt"

            If File.Exists(strFile) Then
                If MessageBox.Show("O arquivo já existe, deseja gerar mesmo assim?", "Gerar Arquivo Connect", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Kill(strFile)
                Else
                    Throw New Exception("Processo cancelado")
                End If

            End If

            If Me.DataGridView1.RowCount > 0 Then
                lngReg = cls.Exec_Command_NQ("EXEC FRPJ_SP_CONNECT_CANC_UPDATE_A_ENVIAR")

                clsU.GeraTxt_DataTable("FRPJ_SP_CONNECT_CANC_A_ENVIAR_TXT", strFile, False, Nothing, 1, 1)

                lngReg = cls.Exec_Command_NQ("EXEC FRPJ_SP_CONNECT_CANC_UPDATE_ENVIADO @Login='" & Environment.UserName & "'")

                If Not lngReg > 0 Then
                    Throw New Exception("Erro ao enviar dados para connect de cancelamento")
                Else
                    'frm_Connect_Canc_Enviar_RECTOR_Load(sender, New EventArgs)
                    Me.Close()
                    frm_MainForm.SetSubForm(frm_Welcome, clsU)
                    MessageBox.Show("Arquivo gerado com sucesso para: " & strFile, "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Nenhum registro para geração de arquivo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

        'Dim cls As New cls_SqlConnect
        'Dim lngReg As Long = 0
        'Dim lngRegDataGrid As Long = 0

        'Try
        '    Me.Cursor = Cursors.WaitCursor

        '    If Me.DataGridView1.RowCount > 0 Then
        '        lngRegDataGrid = DataGridView1.RowCount

        '        lngReg = cls.Exec_Command_NQ("EXEC FRPJ_SP_CANC_UPDATE_ENVIAR_ROBO @Login='" & Environment.UserName & "', @LocalCanc=" & Me.Tag & ",@Lotes=" & Me.txtLotes.Text & ",@TotalRegistros=" & lngRegDataGrid)

        '        If (lngReg) > 0 Then
        '            MessageBox.Show("Ligações enviadas para cancelamento com sucesso, favor acionar o robô de cancelamento!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            frm_Canc_Enviar_Connect_RECTOR_Load(sender, New EventArgs)
        '        Else
        '            MessageBox.Show("Erro ao enviar dados para robô de cancelamento!", "Enviar para robô", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    Else
        '        MessageBox.Show("Nenhum registro para enviar ao robô de cancelamento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try

    End Sub
End Class