Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Motivo2_PF
    Dim myDataSet As DataSet
    Private intMotivo As Integer
    Private Sub frm_Motivo2_PF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frm_Motivo2_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim clsU As New cls_Utilities

            intMotivo = CInt(Me.Tag)

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_CANC_MOTIVOS2 @CodId_Motivo=" & intMotivo
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Columns(1).Visible = False
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            'DataGridView1.Columns(3).Width = 240

            'DataGridView1.Columns(1).ReadOnly = True
            'DataGridView1.Columns(2).DefaultCellStyle.Format = "n2"

            'Me.WindowState = FormWindowState.Normal
            Me.StartPosition = FormStartPosition.CenterScreen


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub btn_Salvar_Click(sender As Object, e As EventArgs) Handles btn_Salvar.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPF_SP_CANC_MOTIVOS2 @CodId_Motivo=" & intMotivo
            MyDa = cls.Return_DataAdapter(strSql, 2)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        Try

            e.Row.Cells(1).Value = intMotivo

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class