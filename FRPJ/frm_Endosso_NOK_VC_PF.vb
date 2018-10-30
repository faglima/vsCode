Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_Endosso_NOK_VC_PF
    Dim myDataSet As DataSet
    Dim strParam
    Private Sub frm_Canc_NOK_VC_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cols As Integer = 0
            Dim i As Integer


            strParam = "NULL"
            fLoadForm(strParam)

            cols = DataGridView1.Columns.Count - 1

            For i = 1 To cols
                DataGridView1.Columns(i).ReadOnly = True
            Next

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

                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_CANC_UPDATE_NOK_TRUE_VC @Canc_Nok_Motivo=" & strParam, 2)

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

                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_CANC_UPDATE_NOK_FALSE_VC @Canc_Nok_Motivo=" & strParam, 2)

                If lngRec > 0 Then
                    fLoadForm(strParam)
                Else
                    MessageBox.Show("Erro ao tentar excluir seleção de registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPF_SP_CHECK_ENVIAR_VC @Canc_Nok_Motivo=" & strParam, 2))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_CANC_UPDATE_NOK_REPROCESSAR_VC @Canc_Nok_Motivo=" & strParam, 2)

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

            lngRec = CLng(cls.Exec_Command_Scalar("EXEC FRPF_SP_CHECK_ENVIAR_VC @Canc_Nok_Motivo=" & strParam, 2))

            If lngRec > 0 Then

                lngRec = 0
                lngRec = cls.Exec_Command_NQ("EXEC FRPF_SP_CANC_UPDATE_NOK_NIVEL2_VC @Login='" & Environment.UserName & "', @Canc_Nok_Motivo=" & strParam, 2)

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

            strSql = "EXEC FRPF_SP_CANC_NOK_VC @Canc_Nok_Motivo=" & strParam
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

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub fLoadForm(strParam As String)
        Try

            Dim cls As New cls_SqlConnect
            Dim strSql As String


            Me.DataGridView1.DataSource = Me.BindingSource1

            strSql = "EXEC FRPF_SP_CANC_NOK_VC @Canc_Nok_Motivo=" & strParam
            myDataSet = cls.Return_DataSet(strSql, 2)
            BindingSource1.DataSource = Nothing
            BindingSource1.DataSource = myDataSet.Tables(0)
            BindingNavigator1.BindingSource = BindingSource1
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

            DataGridView1.Columns("Cnpj").Visible = False
            DataGridView1.Columns("RazaoSocial").Visible = False
            DataGridView1.Columns("CARGO").Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        Try

            If Not Me.cboMotivos.SelectedIndex = -1 Then
                strParam = "'" & Me.cboMotivos.Text & "'"
            End If

            fLoadForm(strParam)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        Try

            If Not Me.cboMotivos.SelectedIndex = -1 Then
                strParam = "NULL"
            End If
            Me.cboMotivos.SelectedIndex = -1
            fLoadForm(strParam)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fLoadCboMotivo()
        Try

            Dim cls As New cls_SqlConnect
            Dim dtr As SqlDataReader
            Dim lstItems As New List(Of String)
            Dim clsU As New cls_Utilities

            cboMotivos.Items.Clear()

            dtr = cls.Return_DataReader("EXEC FRPF_SP_CANC_NOK_VC_MOTIVO_CBO", 2)
            With dtr

                If .HasRows Then
                    Do While .Read()
                        lstItems.Add(.Item("Canc_Nok_Motivo").ToString())
                    Loop
                    clsU.SetCboItems(cboMotivos, lstItems)
                End If
            End With

            dtr.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class