Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Planos
    Dim myDA As SqlDataAdapter
    Dim myDataSet As DataSet


    Function GetCboItems(strSql As String) As List(Of cls_Populate)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql, 2)

            If dtr.HasRows Then
                Do While dtr.Read
                    cboItems.Add(New cls_Populate(dtr.Item(0).ToString(), dtr.Item(1).ToString()))
                Loop
            Else
                cboItems.Add(New cls_Populate(0, ""))
            End If

            dtr.Close()

            Return cboItems

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub frm_Planos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim cboProduto As New DataGridViewComboBoxColumn
            Dim cboTipoRes As New DataGridViewComboBoxColumn
            Dim cboSeg As New DataGridViewComboBoxColumn
            Dim cboCateg As New DataGridViewComboBoxColumn

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_PLANOS @CodProduto=0,@Tipo_Res=-1,@Segmento=-1,@Categoria=-1"

            Using Conn As New SqlConnection(cls.Open_Db(2))
                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strSql
                    .CommandType = CommandType.Text
                    .Connection = Conn
                End With

                myDA = New SqlDataAdapter
                myDA.SelectCommand = cmdComando

                Dim commandBuilder As New SqlCommandBuilder(myDA)

                myDataSet = New DataSet
                myDA.Fill(myDataSet)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1



                DataGridView1.Columns.Remove("CodProduto")
                cboProduto.DataPropertyName = "CodProduto"
                cboProduto.Name = cboProduto.DataPropertyName
                strSql = "select CodProduto, CONVERT(nvarchar(6), CodProduto) + ' - ' + NomeProduto as NomeProduto from tbl_Produto order by NomeProduto"
                cboProduto.DataSource = GetCboItems(strSql)
                cboProduto.DisplayMember = "Item"
                cboProduto.ValueMember = "ID"
                cboProduto.HeaderText = "Produto"
                cboProduto.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                DataGridView1.Columns.Insert(1, cboProduto)

                cboProdutoF.DataSource = GetCboItems(strSql)
                cboProdutoF.DisplayMember = "Item"
                cboProdutoF.ValueMember = "ID"
                cboProdutoF.SelectedIndex = -1

                DataGridView1.Columns.Remove("Segmento")
                cboSeg.DataPropertyName = "Segmento"
                cboSeg.Name = cboSeg.DataPropertyName
                strSql = "select CodId_Segmento, Segmento from tbl_Produto_Segmento"
                cboSeg.DataSource = GetCboItems(strSql)
                cboSeg.DisplayMember = "Item"
                cboSeg.ValueMember = "ID"
                cboSeg.HeaderText = "Segmento"
                cboSeg.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                DataGridView1.Columns.Insert(2, cboSeg)

                cboSegF.DataSource = GetCboItems(strSql)
                cboSegF.DisplayMember = "Item"
                cboSegF.ValueMember = "ID"
                cboSegF.SelectedIndex = -1

                DataGridView1.Columns.Remove("Categoria")
                cboCateg.DataPropertyName = "Categoria"
                cboCateg.Name = cboCateg.DataPropertyName
                strSql = "select CodId_Categoria, upper(Categoria) from tbl_Produto_Categoria"
                cboCateg.DataSource = GetCboItems(strSql)
                cboCateg.DisplayMember = "Item"
                cboCateg.ValueMember = "ID"
                cboCateg.HeaderText = "Categoria"
                cboCateg.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                DataGridView1.Columns.Insert(3, cboCateg)

                strSql = "select CodId_Categoria, upper(Categoria) from tbl_Produto_Categoria"
                cboCategF.DataSource = GetCboItems(strSql)
                cboCategF.DisplayMember = "Item"
                cboCategF.ValueMember = "ID"
                cboCategF.SelectedIndex = -1

                DataGridView1.Columns.Remove("Tipo_Res")
                cboTipoRes.DataPropertyName = "Tipo_Res"
                cboTipoRes.Name = cboTipoRes.DataPropertyName
                strSql = "select CodId_Tipo_Res,Tipo_Res from tbl_Tipo_Residencia"
                cboTipoRes.DataSource = GetCboItems(strSql)
                cboTipoRes.DisplayMember = "Item"
                cboTipoRes.ValueMember = "ID"
                cboTipoRes.HeaderText = "Tipo Residência"
                cboTipoRes.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                DataGridView1.Columns.Insert(4, cboTipoRes)

                strSql = "select CodId_Tipo_Res,upper(Tipo_Res) as Tipo_Res from tbl_Tipo_Residencia"
                cboTipoResF.DataSource = GetCboItems(strSql)
                cboTipoResF.DisplayMember = "Item"
                cboTipoResF.ValueMember = "ID"
                cboTipoResF.SelectedIndex = -1

                Dim lstCol As New List(Of String)
                lstCol.Add("CodId_Plano")

                clsU.FormatGrid(DataGridView1, BindingSource1, lstCol)

                'Visible = False
                'DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = 32
                'DataGridView1.Columns(2).DefaultCellStyle.Alignment = 32
                'DataGridView1.Columns(3).DefaultCellStyle.Alignment = 32
                'DataGridView1.Columns(5).DefaultCellStyle.Format = "n2"
                'DataGridView1.Columns(5).DefaultCellStyle.Alignment = 32
                'DataGridView1.Columns(6).DefaultCellStyle.Format = "n2"
                'DataGridView1.Columns(6).DefaultCellStyle.Alignment = 32

                'DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
                DataGridView1.Columns(1).Width = 300

                Conn.Close()
                Conn.Dispose()

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Try

            Me.Validate()

            Me.myDA.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            MessageBox.Show("Alterações salvas com sucesso!", "Salvar", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try

            If MessageBox.Show("Tem certeza que deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Me.BindingSource1.RemoveCurrent()
                Me.BindingSource1.EndEdit()
                Me.Validate()
                Me.myDA.Update(myDataSet.Tables(0))
                Me.myDataSet.AcceptChanges()

                MessageBox.Show("Registro excluído com sucesso!", "Excluir", MessageBoxButtons.OK)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim intProduto As Integer
            Dim intTipoRes As Integer
            Dim intCateg As Integer
            Dim intSeg As Integer

            Me.DataGridView1.DataSource = Me.BindingSource1

            If cboProdutoF.SelectedIndex = -1 Then
                intProduto = 0
            Else
                intProduto = cboProdutoF.SelectedValue.ToString
            End If
            If cboTipoResF.SelectedIndex = -1 Then
                intTipoRes = -1
            Else
                intTipoRes = cboTipoResF.SelectedValue.ToString
            End If
            If cboSegF.SelectedIndex = -1 Then
                intSeg = -1
            Else
                intSeg = cboSegF.SelectedValue.ToString
            End If
            If cboCategF.SelectedIndex = -1 Then
                intCateg = -1
            Else
                intCateg = cboCategF.SelectedValue.ToString
            End If


            strSql = "EXEC FRPF_SP_PLANOS @CodProduto=" & intProduto & ", @Tipo_Res=" & intTipoRes & ",@Segmento=" & intSeg & ",@Categoria=" & intCateg

            Using Conn As New SqlConnection(cls.Open_Db(2))
                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strSql
                    .CommandType = CommandType.Text
                    .Connection = Conn
                End With

                myDA = New SqlDataAdapter
                myDA.SelectCommand = cmdComando

                Dim commandBuilder As New SqlCommandBuilder(myDA)

                myDataSet = New DataSet
                myDA.Fill(myDataSet)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.Refresh()

                Conn.Close()
                Conn.Dispose()

            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String
            Dim cboProduto As New DataGridViewComboBoxColumn
            Dim cboTipoRes As New DataGridViewComboBoxColumn

            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_PLANOS @CodProduto=0, @Tipo_Res=-1,@Segmento=-1,@Categoria=-1"

            Me.cboProdutoF.SelectedIndex = -1
            Me.cboProdutoF.Refresh()
            Me.cboTipoResF.SelectedIndex = -1
            Me.cboTipoResF.Refresh()
            Me.cboSegF.SelectedIndex = -1
            Me.cboSegF.Refresh()
            Me.cboCategF.SelectedIndex = -1
            Me.cboCategF.Refresh()

            Using Conn As New SqlConnection(cls.Open_Db(2))
                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strSql
                    .CommandType = CommandType.Text
                    .Connection = Conn
                End With

                myDA = New SqlDataAdapter
                myDA.SelectCommand = cmdComando

                Dim commandBuilder As New SqlCommandBuilder(myDA)

                myDataSet = New DataSet
                myDA.Fill(myDataSet)

                BindingSource1.DataSource = myDataSet.Tables(0)
                BindingNavigator1.BindingSource = BindingSource1

                DataGridView1.Refresh()

                Conn.Close()
                Conn.Dispose()

            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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

    'Private Sub cboProdutoF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboProdutoF.Validating
    '    Try
    '        If cboProdutoF.SelectedIndex = -1 Then
    '            cboCategF.DataSource = Nothing
    '            cboCategF.Refresh()
    '        Else
    '            Dim strSql As String = "select CodId_Categ_Fk, upper(Categoria) from SGIV_VI_PRODUTO_CATEG WHERE CodProduto_Fk=" & cboProdutoF.SelectedValue
    '            cboCategF.DataSource = GetCboItems(strSql)
    '            cboCategF.DisplayMember = "Item"
    '            cboCategF.ValueMember = "ID"
    '            cboCategF.SelectedIndex = -1
    '            cboCategF.Refresh()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class