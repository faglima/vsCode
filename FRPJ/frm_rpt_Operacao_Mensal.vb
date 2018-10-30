Imports Microsoft.Reporting.WinForms

Public Class frm_rpt_Operacao_Mensal
    Private strLocalCanc As String
    Private Sub frm_rpt_Operacao_Mensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        Try
            strLocalCanc = Me.Tag
            PopulaMesref()
            PopulaRelatorio()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub PopulaRelatorio()
        Try
            Dim rptDS As New ReportDataSource("Ds_Canc_Rector_Mensal", GetDataSourceRelatorio)
            'Dim params As New List(Of ReportParameter)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(rptDS)

            'If strLocalCanc = "1" Then
            '    params.Add(New ReportParameter("rptPrm1", "Relatório Operacional Mensal RECTOR"))
            '    params.Add(New ReportParameter("rptPrmImg", "1"))
            'Else
            '    params.Add(New ReportParameter("rptPrm1", "Relatório Operacional Mensal VC"))
            '    params.Add(New ReportParameter("rptPrmImg", "2"))
            'End If
            'ReportViewer1.LocalReport.SetParameters(params)
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                strFiltros = strLocalCanc & "," & clsU.FormataStringSQL(strDataIni, cls_Utilities.TipoDado.Numerico) & "," & clsU.FormataStringSQL(strDataFim, cls_Utilities.TipoDado.Numerico)
                Return cls.Return_DataTable("EXEC FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PF " & strFiltros)
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