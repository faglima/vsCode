Imports Microsoft.Reporting.WinForms

Public Class frm_rpt_Sla_Cancelamento

    Private Sub frm_rpt_Sla_Cancelamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS_rptOperacional.frpj_SP_RPT_SLA_Emissao' table. You can move, or remove it, as needed.
        'Me.frpj_SP_RPT_SLA_EmissaoTableAdapter.Fill(Me.DS_rptOperacional.frpj_SP_RPT_SLA_Emissao)
        Try

            PopulaMesref()
            PopulaRelatorio()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PopulaRelatorio()
        Try
            Dim dsTeste As DataTable = GetDataSourceRelatorio()
            Dim rptDS As New ReportDataSource("DsCancelamento", dsTeste)

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

            strFiltros = cboMesrefIni.Text

            If Not strFiltros = Nothing Then
                Return cls.Return_DataTable("EXEC FRPJ_SP_RPT_SLA_CANCELAMENTO " & strFiltros)
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


            cboMesrefIni.Text = clsU.fGetMesref(Date.Today)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class