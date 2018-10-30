<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rpt_Operacao_Mensal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_rptOperacional = New FRPJ.DS_rptOperacional()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGerar = New System.Windows.Forms.Button()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter()
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALTableAdapter()
        Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_rptOperacional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource
        '
        Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource.DataMember = "FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PF"
        Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource.DataSource = Me.DS_rptOperacional
        '
        'DS_rptOperacional
        '
        Me.DS_rptOperacional.DataSetName = "DS_rptOperacional"
        Me.DS_rptOperacional.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.btnGerar)
        Me.Panel1.Controls.Add(Me.L2)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1030, 64)
        Me.Panel1.TabIndex = 5
        '
        'btnGerar
        '
        Me.btnGerar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGerar.Location = New System.Drawing.Point(218, 25)
        Me.btnGerar.Name = "btnGerar"
        Me.btnGerar.Size = New System.Drawing.Size(81, 25)
        Me.btnGerar.TabIndex = 8
        Me.btnGerar.Text = "Gerar"
        Me.btnGerar.UseVisualStyleBackColor = True
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(104, 9)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(65, 14)
        Me.L2.TabIndex = 7
        Me.L2.Text = "Mesref Fim"
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(6, 9)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(60, 14)
        Me.L1.TabIndex = 6
        Me.L1.Text = "Mesref Ini"
        '
        'FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter
        '
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter.ClearBeforeFill = True
        '
        'FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALTableAdapter
        '
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALTableAdapter.ClearBeforeFill = True
        '
        'FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFTableAdapter
        '
        Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "DS_Canc_Rector_Mensal"
        ReportDataSource1.Value = Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "FRPJ.rpt_Canc_Rector_Mensal.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 65)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1030, 381)
        Me.ReportViewer1.TabIndex = 6
        '
        'frm_rpt_Operacao_Mensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 444)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_rpt_Operacao_Mensal"
        Me.Text = "Relatório Operacional - Cancelamento Mensal"
        CType(Me.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_rptOperacional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGerar As System.Windows.Forms.Button
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents cboMesrefFim As FRPJ.CenteredComboBox
    Friend WithEvents cboMesrefIni As FRPJ.CenteredComboBox
    Friend WithEvents FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter
    Friend WithEvents FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_CANCELAMENTO_CORRETORA_MENSALTableAdapter
    Friend WithEvents FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DS_rptOperacional As FRPJ.DS_rptOperacional
    Friend WithEvents FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_REPORT_OPERACIONAL_MENSAL_PFTableAdapter
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
