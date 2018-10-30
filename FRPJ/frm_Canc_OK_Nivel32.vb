Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_OK_Nivel32
    Dim myDataSet As DataSet
    Dim strEps As String = "0"
    Private Sub frm_Canc_OK_Nivel32_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            If Me.Tag = "N2" Then
                Select Case frm_MainForm.Tag
                    Case Is = "13" '2º NÍVEL SAC
                        strEps = "3"
                    Case Is = "12" '1º NÍVEL SAC
                        strEps = "3"
                    Case Is = "-1", "2", "3" 'MASTER, MASTER CORRETORA E MASTER SEGURADORA
                        strEps = "100"
                End Select

            Else
                'Caso o acesso não seja efetuado pelo 2º NÍVEL exibe todas as informações
                strEps = "100"
            End If

            strSql = "EXEC FRPJ_SP_CANC_OK_NIVEL32 @EPS=" & strEps
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ReadOnly = True
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns(6).DefaultCellStyle.Format = "n2"

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
End Class