Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Param
    Dim myDataSet As DataSet
    Dim strParam As String
    Private Sub frm_Param_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim conn As New SqlConnection


            If frm_MainForm.Tag = "-1" Then
                strParam = "0"
            Else
                strParam = "1"
            End If

            Me.DataGridView1.DataSource = Me.BindingSource1


            strSql = "EXEC FRPJ_SP_PARAMETROS " & strParam
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(3).Visible = False

            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Function GetCboItems() As List(Of cls_Populate)
        Try
            Dim cboItems = New List(Of cls_Populate)

            cboItems.Add(New cls_Populate(-1, "Master"))
            cboItems.Add(New cls_Populate(1, "Gestor"))
            cboItems.Add(New cls_Populate(2, "Coordenador"))
            cboItems.Add(New cls_Populate(3, "Operador"))


            Return cboItems

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function




    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            If MessageBox.Show("Tem certeza que deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Me.BindingSource1.RemoveCurrent()
                Me.BindingSource1.EndEdit()
                Me.Validate()

                strSql = "EXEC FRPJ_SP_PARAMETROS " & strParam
                MyDa = cls.Return_DataAdapter(strSql)

                MyDa.Update(myDataSet.Tables(0))
                Me.myDataSet.AcceptChanges()


                MessageBox.Show("Registro excluído com sucesso!", "Excluir", MessageBoxButtons.OK)

            End If

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

            strSql = "EXEC FRPJ_SP_PARAMETROS " & strParam
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

            e.Row.Cells(5).Value = False
            e.Row.Cells(3).Value = 8

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
End Class