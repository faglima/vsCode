Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Motivo
    Dim myDataSet As DataSet
    Private Sub frm_Motivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim clsU As New cls_Utilities
            Dim btnOpen As New DataGridViewButtonColumn

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_CANC_MOTIVOS"
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            btnOpen.HeaderText = "Motivos Gerenciais"
            btnOpen.DefaultCellStyle.Font = New Font("Arial", 7)
            btnOpen.FlatStyle = FlatStyle.Standard
            btnOpen.Text = "Motivos Gerenciais"
            btnOpen.Name = "btnOpen"
            btnOpen.UseColumnTextForButtonValue = True

            DataGridView1.Columns.Insert(6, btnOpen)
            DataGridView1.Columns(0).ReadOnly = True
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)


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

            strSql = "EXEC FRPJ_SP_CANC_MOTIVOS"
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        Try

            e.Row.Cells(3).Value = False
            e.Row.Cells(4).Value = False
            e.Row.Cells(5).Value = False

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

                frm_Motivo2.Tag = DataGridView1.Item(1, e.RowIndex).Value
                frm_Motivo2.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnXml_Click(sender As Object, e As EventArgs) Handles btnXml.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strFile As String
            Dim dttObj As DataTable

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_Canc_PJ.xml"

            dttObj = cls.Return_DataTable("EXEC FRPJ_SP_OFF_MOTIVOS_CANC")

            clsU.GeraXml_DataTable(dttObj, strFile)

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos2_Canc_PJ.xml"

            dttObj = cls.Return_DataTable("EXEC FRPJ_SP_CANC_MOTIVOS2_CBO")

            clsU.GeraXml_DataTable(dttObj, strFile)

            strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_Arg_PJ.xml"

            dttObj = cls.Return_DataTable("EXEC FRPJ_SP_OFF_MOTIVOS_ARG")

            clsU.GeraXml_DataTable(dttObj, strFile)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class