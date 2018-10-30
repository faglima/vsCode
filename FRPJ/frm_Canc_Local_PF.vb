Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_Local_PF
    Dim myDataSet As DataSet
    Private Sub frm_Canc_Local_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_CANC_LOCAL"
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Columns(0).ReadOnly = True
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
End Class