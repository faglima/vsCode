Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Desfecho_Grupo_PF
    Dim myDataSet As DataSet
    Private Sub frm_Desfecho_Grupo_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim strSqlCbo As String
            Dim conn As New SqlConnection
            Dim btnOpen As New DataGridViewButtonColumn
            Dim btnOpen2 As New DataGridViewButtonColumn
            Dim cboLocal As New DataGridViewComboBoxColumn

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_PRODUTO_GRUPO"
            myDataSet = cls.Return_DataSet(strSql, 2)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Columns.Remove("Local_Canc")
            strSqlCbo = "EXEC FRPF_SP_CANC_LOCAL_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboLocal, "Local_Canc", "Local_Canc.", 2)
            cboLocal.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            btnOpen.HeaderText = "Regras"
            btnOpen.DefaultCellStyle.Font = New Font("Arial", 7)
            btnOpen.FlatStyle = FlatStyle.Standard
            btnOpen.Text = "Motivos e Regras"
            btnOpen.Name = "btnOpen"
            btnOpen.UseColumnTextForButtonValue = True

            btnOpen2.HeaderText = "Alçadas"
            btnOpen2.DefaultCellStyle.Font = New Font("Arial", 7)
            btnOpen2.FlatStyle = FlatStyle.Standard
            btnOpen2.Text = "Alçadas"
            btnOpen2.Name = "btnOpen2"
            btnOpen2.UseColumnTextForButtonValue = True

            DataGridView1.Columns.Insert(3, cboLocal)
            DataGridView1.Columns.Insert(8, btnOpen2)
            DataGridView1.Columns.Insert(9, btnOpen)
            'DataGridView1.Columns(0).ReadOnly = True

            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        Try

            If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
                DataGridView1.Cursor = Cursors.Hand
            Else
                DataGridView1.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                       Handles DataGridView1.CellContentClick
        Try
            Dim senderGrid = DirectCast(sender, DataGridView)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 Then
                If e.ColumnIndex = 1 Then
                    Me.Cursor = Cursors.WaitCursor

                    frm_Desfecho_PF.Tag = DataGridView1.Item(2, e.RowIndex).Value & ";" & DataGridView1.Item(5, e.RowIndex).Value
                    frm_Desfecho_PF.ShowDialog()
                ElseIf e.ColumnIndex = 0 Then
                    Me.Cursor = Cursors.WaitCursor

                    frm_Alcada_PF.Tag = DataGridView1.Item(2, e.RowIndex).Value
                    frm_Alcada_PF.ShowDialog()

                End If


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class