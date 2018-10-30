Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Venda_NOK_Nivel1
    Dim myDataSet As DataSet
    Private Sub frm_Venda_NOK_Nivel1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            InicializaTxt()

            fLoadForm()

           
            'DataGridView1.Columns.RemoveAt(0)
            'DataGridView1.Columns(23).DefaultCellStyle.Format = "n2"
            'DataGridView1.Columns(24).DefaultCellStyle.Format = "n2"

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
            If Not (String.IsNullOrEmpty(txtDtIni.Text) AndAlso String.IsNullOrEmpty(txtDtFim.Text)) Then

                Dim cls As New cls_SqlConnect
                Dim strSql As String
                Dim conn As New SqlConnection
                Dim cls_u As New cls_Utilities
                Dim strDataIni As String
                Dim strDataFim As String
                Dim btnOpen As New DataGridViewButtonColumn

                If DataGridView1.Columns.Count > 0 Then
                    DataGridView1.Columns.RemoveAt(0)
                End If

                strDataIni = cls_u.FormataStringSQL(txtDtIni.Text, cls_Utilities.TipoDado.Datetime)
                strDataFim = cls_u.FormataStringSQL(txtDtFim.Text, cls_Utilities.TipoDado.Datetime)

                Me.DataGridView1.DataSource = Me.BindingSource1

                strSql = "EXEC FRPF_SP_EMISSAO_NOK_NIVEL1 " & strDataIni & "," & strDataFim
                myDataSet = cls.Return_DataSet(strSql, 2)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.ReadOnly = True
                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

                btnOpen.HeaderText = "Baixar"
                btnOpen.DefaultCellStyle.Font = New Font("Arial", 7)
                btnOpen.FlatStyle = FlatStyle.Standard
                btnOpen.Text = "Baixar Ligação"
                btnOpen.Name = "btnOpen"
                btnOpen.UseColumnTextForButtonValue = True
                DataGridView1.Columns.Insert(0, btnOpen)

            Else
                MessageBox.Show("Informe as datas para a pesquisa !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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

                frm_Venda_NOK_Nivel1_Baixar.Tag = DataGridView1.Item(2, e.RowIndex).Value & ";" & DataGridView1.Item(1, e.RowIndex).Value
                frm_Venda_NOK_Nivel1_Baixar.Text = "Baixar Ligação Protocolo " & DataGridView1.Item(2, e.RowIndex).Value & " - Origem: " & DataGridView1.Item(1, e.RowIndex).Value
                frm_Venda_NOK_Nivel1_Baixar.ShowDialog()



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
    Private Sub InicializaTxt()

        txtDtIni.Text = Today
        txtDtFim.Text = Today

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            fLoadForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        InicializaTxt()
        DataGridView1.DataSource = Nothing
        If DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns.RemoveAt(0)
        End If
    End Sub
End Class