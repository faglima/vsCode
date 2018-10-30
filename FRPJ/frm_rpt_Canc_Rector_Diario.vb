Imports Microsoft.Reporting.WinForms

Public Class frm_rpt_Canc_Rector_Diario

    Private Sub frm_rpt_Canc_Rector_Diario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsU As New cls_Utilities

            PopulaMesref()
            Dim lstItems As New List(Of String)
            lstItems.Add("PF")
            lstItems.Add("PJ")
            clsU.GetCboItems_List(cboOrigem, lstItems)
            cboOrigem.SelectedValue = 0

            PopulaRelatorio()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PopulaRelatorio()
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rptDS As New ReportDataSource("DS_Canc_Rector_Diario", GetDataSourceRelatorio)
            Dim params As New List(Of ReportParameter)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(rptDS)

            If cboOrigem.SelectedValue = 0 Then
                params.Add(New ReportParameter("prm2", "Relatório Operacional Diário RECTOR - PF"))
            Else
                params.Add(New ReportParameter("prm2", "Relatório Operacional Diário RECTOR - PJ"))
            End If

            ReportViewer1.LocalReport.SetParameters(params)

            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Function GetDataSourceRelatorio() As DataTable
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim dt As New DataTable
            Dim strFiltros As String
            Dim strDataIni As String
            Dim strDataFim As String

            strDataIni = cboMesrefIni.Text
            strDataFim = cboMesrefFim.Text

            If Not strDataIni = Nothing AndAlso Not strDataFim = Nothing Then
                strFiltros = clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Numerico) & "," & clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Numerico)
                If cboOrigem.SelectedValue = 0 Then
                    Return cls.Return_DataTable("EXEC FRPJ_SP_REPORT_OPERACIONAL_DIARIO_PF " & strFiltros)
                Else
                    Return cls.Return_DataTable("EXEC FRPJ_SP_REPORT_OPERACIONAL_DIARIO_PJ " & strFiltros)
                End If

            Else
                Throw New Exception("Erro ao gerar datas para o SQL")
            End If


        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btnGerar_Click(sender As Object, e As EventArgs) Handles btnGerar.Click
        Try

            PopulaRelatorio()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PopulaMesref()
        Try

            Dim clsU As New cls_Utilities

            clsU.SetMesRef(cboMesrefIni, #2/1/2017#, Date.Today)
            clsU.SetMesRef(cboMesrefFim, #2/1/2017#, Date.Today)

            cboMesrefIni.Text = clsU.fGetMesref(Date.Today)
            cboMesrefFim.Text = clsU.fGetMesref(Date.Today)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class