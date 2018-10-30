Imports Microsoft.Reporting.WinForms

Public Class frm_rpt_Operacao_Endosso_Mensal

    Private Sub frm_rpt_Operacao_Endosso_Diario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            PopulaMesref()
            PopulaRelatorio()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PopulaRelatorio()
        Try

            Dim rptDS As New ReportDataSource("DsEndosso", GetDataSourceRelatorio)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(rptDS)
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
            Dim dtDataIni As Date
            Dim dtDataFim As Date

            dtDataIni = clsU.fMesrefToDate(cboMesrefIni.Text, cls_Utilities.DiaMes.Inicio)
            dtDataFim = clsU.fMesrefToDate(cboMesrefFim.Text, cls_Utilities.DiaMes.Fim)

            If Not dtDataIni = Nothing AndAlso Not dtDataFim = Nothing Then
                strFiltros = clsU.FormataStringSQL(dtDataIni, cls_Utilities.TipoDado.Datetime) & "," & clsU.FormataStringSQL(dtDataFim, cls_Utilities.TipoDado.Datetime)
                Return cls.Return_DataTable("EXEC FRPJ_SP_RPT_ENDOSSO_MENSAL " & strFiltros)
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