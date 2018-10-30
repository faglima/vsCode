Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Endosso_NOK
    Dim myDataSet As DataSet
    Dim strParam
    Private Sub frm_Endosso_NOK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cols As Integer = 0
            Dim i As Integer
            Dim btnOpen As New DataGridViewButtonColumn

            strParam = "@Motivo= NULL, @ID= NULL, @Cpf= NULL"
            fLoadForm(strParam)

            cols = DataGridView1.Columns.Count - 1

            For i = 1 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next
            DataGridView1.Columns("Obs").ReadOnly = False
            DataGridView1.Columns("Obs").Width = 150

            btnOpen.HeaderText = "Baixar"
            btnOpen.DefaultCellStyle.Font = New Font("Arial", 7)
            btnOpen.FlatStyle = FlatStyle.Standard
            btnOpen.Text = "Baixar Ligação"
            btnOpen.Name = "btnOpen"
            btnOpen.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Insert(0, btnOpen)

            fLoadCboMotivo()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub tsbtn_Excel_Click(sender As Object, e As EventArgs) Handles tsbtn_Excel.Click
        Dim clsU As New cls_Utilities

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.DataGridView1.RowCount > 0 Then
                clsU.GeraTxt_DataGrid(Me.DataGridView1)
            Else
                MessageBox.Show("Nenhum registro para geração de arquivo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtn_Select_Click(sender As Object, e As EventArgs) Handles tsbtn_Select.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            If Me.DataGridView1.RowCount > 0 Then

                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_UPDATE_ENDOSSO_NOK_SELECT " & strParam, 2)

                If lngRec > 0 Then
                    fLoadForm(strParam)
                Else
                    MessageBox.Show("Erro ao tentar selecionar registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro para selecão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtn_Unselect_Click(sender As Object, e As EventArgs) Handles tsbtn_Unselect.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            If Me.DataGridView1.RowCount > 0 Then

                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_UPDATE_ENDOSSO_NOK_UNSELECT " & strParam, 2)

                If lngRec > 0 Then
                    fLoadForm(strParam)
                Else
                    MessageBox.Show("Erro ao tentar selecionar registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro para selecão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsbtn_Reproc_Click(sender As Object, e As EventArgs) Handles tsbtn_Reproc.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPF_SP_ENDOSSO_CHECK_ENVIAR_VC " & strParam, 2))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_ENDOSSO_UPDATE_NOK_REPROCESSAR_VC " & strParam, 2)

                If lngRec > 0 Then
                    fLoadForm(strParam)
                    fLoadCboMotivo()
                    MessageBox.Show("Registros enviados para reprocessamento com sucesso!", "Enviar reprocessamento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Erro ao tentar enviar seleção de registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbtn_Nivel2_Click(sender As Object, e As EventArgs) Handles tsbtn_Nivel2.Click
        Try

            Dim cls As New cls_SqlConnect
            Dim lngRec As Long = 0

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPF_SP_ENDOSSO_CHECK_ENVIAR_VC " & strParam, 2))

            If lngRec > 0 Then
                fSalvar()
                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_ENDOSSO_UPDATE_NOK_NIVEL2_VC @Login='" & Environment.UserName & "', " & strParam, 2)

                If lngRec > 0 Then
                    fLoadForm(strParam)
                    fLoadCboMotivo()
                    MessageBox.Show("Registros enviados para 2º nível com sucesso!", "Enviar 2º nível", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Erro ao tentar enviar seleção de registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Nenhum registro selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub fSalvar()
        Try

            Dim cls As New cls_SqlConnect
            Dim MyDa As New SqlDataAdapter
            Dim strSql As String

            Me.Validate()

            strSql = "EXEC FRPF_SP_ENDOSSO_NOK " & strParam
            MyDa = cls.Return_DataAdapter(strSql, 2)

            MyDa.Update(myDataSet.Tables(0))
            Me.myDataSet.AcceptChanges()

            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                           Handles DataGridView1.CellContentClick
        Try

            Dim senderGrid = DirectCast(sender, DataGridView)

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then

                fSalvar()

            ElseIf TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 Then

                Me.Cursor = Cursors.WaitCursor

                frm_Endosso_NOK_Baixar.Tag = DataGridView1.Item("CodId", e.RowIndex).Value & ";" & DataGridView1.Item("Origem", e.RowIndex).Value & ";2"
                frm_Endosso_NOK_Baixar.Text = "Baixar Ligação Protocolo " & DataGridView1.Item("CodId", e.RowIndex).Value & " - Origem: " & DataGridView1.Item("Origem", e.RowIndex).Value
                frm_Endosso_NOK_Baixar.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub fLoadForm(strParam As String)
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String


            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_ENDOSSO_NOK " & strParam
            myDataSet = cls.Return_DataSet(strSql, 2)
            BindingSource1.DataSource = Nothing
            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            DataGridView1.Columns("Obs").Width = 150

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try

            Dim strMotivo As String = "NULL"
            Dim strId As String = "NULL"
            Dim strCpf As String = "NULL"

            If Not Me.cboMotivos.SelectedIndex = -1 Then
                strMotivo = "'" & Me.cboMotivos.Text & "'"
            End If
            If Me.txtId.Text <> "" Then
                strId = Me.txtId.Text
            End If

            If Me.txtCPF.Text <> "" Then
                strCpf = Me.txtCPF.Text
            End If

            strParam = "@Motivo=" & strMotivo & ", @Id=" & strId & ", @Cpf=" & strCpf

            fLoadForm(strParam)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Try

            strParam = "@Motivo= NULL, @ID= NULL, @Cpf= NULL"
            Me.cboMotivos.SelectedIndex = -1
            Me.txtId.Text = Nothing
            Me.txtCPF.Text = Nothing

            fLoadForm(strParam)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub fLoadCboMotivo()
        Try

            Dim cls As New cls_SqlConnect
            Dim dtr As SqlDataReader
            Dim lstItems As New List(Of String)
            Dim clsU As New cls_Utilities

            cboMotivos.Items.Clear()

            dtr = cls.Return_DataReader("EXEC FRPF_SP_ENDOSSO_NOK_MOTIVO_CBO", 2)
            With dtr

                If .HasRows Then
                    Do While .Read()
                        lstItems.Add(.Item("Endosso_Proc_NOK_Motivo").ToString())
                    Loop
                    clsU.SetCboItems(cboMotivos, lstItems)
                End If
            End With

            dtr.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtId.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

End Class