Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Usuarios
    Dim myDataSet As DataSet
    Dim intPerfil As Integer
    Private Sub frm_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim conn As New SqlConnection
            Dim cboPerfil As New DataGridViewComboBoxColumn
            Dim cboEps As New DataGridViewComboBoxColumn
            Dim cboSuper As New DataGridViewComboBoxColumn
            Dim strSqlCbo As String

            intPerfil = cls.Exec_Command_Scalar("select PerfilUsuario from tbl_usuario where login='" & Environment.UserName & "'")

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPJ_SP_USUARIOS @Perfil=" & intPerfil
            myDataSet = cls.Return_DataSet(strSql)

            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1

            DataGridView1.Columns.Remove("Site")
            strSqlCbo = "EXEC FRPJ_SP_RET_EPS_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboEps, "Site", "Site")
            cboEps.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("PerfilUsuario")
            strSqlCbo = "EXEC FRPJ_SP_USUARIOS_PERFIL_CBO @Perfil=" & intPerfil
            clsU.GetCboItems_DataGrid(strSqlCbo, cboPerfil, "PerfilUsuario", "Perfil")
            cboPerfil.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Supervisor")
            strSqlCbo = "EXEC FRPJ_SP_SUPERVISOR_CBO"
            clsU.GetCboItems_DataGrid(strSqlCbo, cboSuper, "Supervisor", "Supervisor")
            cboSuper.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing


            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns.Insert(3, cboEps)
            DataGridView1.Columns(3).Width = 120
            DataGridView1.Columns.Insert(4, cboPerfil)
            DataGridView1.Columns(4).Width = 100
            DataGridView1.Columns.Insert(5, cboSuper)
            DataGridView1.Columns(5).Width = 200
            DataGridView1.Columns(6).Width = 50

            'DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            If MessageBox.Show("Tem certeza que deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Me.BindingSource1.RemoveCurrent()
                Me.BindingSource1.EndEdit()
                Me.Validate()

                strSql = "EXEC FRPJ_SP_USUARIOS @Perfil=" & intPerfil
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

            strSql = "EXEC FRPJ_SP_USUARIOS @Perfil=" & intPerfil
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

            e.Row.Cells(6).Value = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class