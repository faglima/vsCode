Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Canc_NOK_Nivel2
    Dim myDataSet As DataSet
    Dim strEps As String = "0"
    Private Sub frm_Canc_NOK_Nivel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim btnOpen As New DataGridViewButtonColumn

            fLoadForm()

            btnOpen.HeaderText = "Baixar"
            btnOpen.DefaultCellStyle.Font = New Font("Arial", 7)
            btnOpen.FlatStyle = FlatStyle.Standard
            btnOpen.Text = "Baixar Ligação"
            btnOpen.Name = "btnOpen"
            btnOpen.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Insert(0, btnOpen)
            DataGridView1.Columns("Premio").DefaultCellStyle.Format = "n2"
            DataGridView1.Columns("ImpSegurada").DefaultCellStyle.Format = "n2"

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
    Public Sub fLoadForm()

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection


            Me.DataGridView1.DataSource = Me.BindingSource1

            Select Case frm_MainForm.Tag
                Case Is = "13" '2º NÍVEL SAC
                    strEps = "3"
                Case Is = "12" '1º NÍVEL SAC
                    strEps = "3"
                Case Is = "-1", "2", "3" 'MASTER, MASTER CORRETORA E MASTER SEGURADORA
                    strEps = "100"
            End Select

            strSql = "EXEC FRPJ_SP_CANC_NOK_NIVEL2 @EPS=" & strEps
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.ReadOnly = True
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Dim senderGrid = DirectCast(sender, DataGridView)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 Then

                Me.Cursor = Cursors.WaitCursor

                frm_Canc_NOK_Nivel2_Baixar.Tag = DataGridView1.Item(1, e.RowIndex).Value & ";" & DataGridView1.Item(2, e.RowIndex).Value & ";2"
                frm_Canc_NOK_Nivel2_Baixar.Text = "Baixar Ligação Protocolo " & DataGridView1.Item(1, e.RowIndex).Value & " - Origem: " & DataGridView1.Item(2, e.RowIndex).Value
                frm_Canc_NOK_Nivel2_Baixar.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        Try

            If e.ColumnIndex = 0 Then
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
End Class