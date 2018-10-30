Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Altera_Dados_PF
    Dim myDataSet As DataSet
    Dim strCodId As String = "0"
    Dim strCpf As String = "0"


    Private Sub frm_Altera_Dados_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Call fLoadForm()

            Dim cols As Integer = 0
            Dim i As Integer

            cols = DataGridView1.Columns.Count - 1

            For i = 0 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next

            DataGridView1.Columns("Premio").ReadOnly = False
            DataGridView1.Columns("ImpSegurada").ReadOnly = False
            DataGridView1.Columns("Nome").Width = 300

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btn_Salvar_Click(sender As Object, e As EventArgs) Handles btn_Salvar.Click
        Try

            fSalvar()

            MessageBox.Show("Registros salvos com sucesso!", "Salvar", MessageBoxButtons.OK)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub fLoadForm()
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_ALTERA_DADOS_PF @CodId=" & strCodId & ",@Cpf=" & strCpf
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            clsU.FormatGrid(DataGridView1, BindingSource1)



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

    Private Sub fSalvar()

        Try
            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPJ_SP_ALTERA_DADOS_PF @CodId=" & strCodId & ",@Cpf=" & strCpf
            MyDa = cls.Return_DataAdapter(strSql)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            If Not txtProtocolo.Text = Nothing Or Not txtCpf.Text = Nothing Then

                If Not txtProtocolo.Text = Nothing Then
                    strCodId = CStr(txtProtocolo.Text)
                End If
                If Not txtCpf.Text = Nothing Then
                    strCpf = CStr(txtCpf.Text)
                End If
            End If

            fLoadForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Try

            strCodId = "0"
            strCpf = "0"
            txtProtocolo.Text = Nothing
            txtCpf.Text = Nothing

            fLoadForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class