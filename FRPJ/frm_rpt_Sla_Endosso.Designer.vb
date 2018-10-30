<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rpt_Sla_Endosso
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
        Me.FRPj_SP_RPT_SLA_ENDOSSOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_rptOperacional = New FRPJ.DS_rptOperacional()
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FRPJ_SP_RPT_ENDOSSOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FRPJ_SP_RPT_EMISSAOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.FRPJ_SP_RPT_EMISSAOTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_EMISSAOTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGerar = New System.Windows.Forms.Button()
        Me.L1 = New System.Windows.Forms.Label()
        Me.FRPJ_SP_RPT_ENDOSSOTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_ENDOSSOTableAdapter()
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter()
        Me.FRPj_SP_RPT_SLA_ENDOSSOTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPj_SP_RPT_SLA_ENDOSSOTableAdapter()
        Me.cboMesrefIni = New FRPJ.CenteredComboBox()
        CType(Me.FRPj_SP_RPT_SLA_ENDOSSOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_rptOperacional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FRPJ_SP_RPT_ENDOSSOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FRPJ_SP_RPT_EMISSAOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FRPj_SP_RPT_SLA_ENDOSSOBindingSource
        '
        Me.FRPj_SP_RPT_SLA_ENDOSSOBindingSource.DataMember = "FRPj_SP_RPT_SLA_ENDOSSO"
        Me.FRPj_SP_RPT_SLA_ENDOSSOBindingSource.DataSource = Me.DS_rptOperacional
        '
        'DS_rptOperacional
        '
        Me.DS_rptOperacional.DataSetName = "DS_rptOperacional"
        Me.DS_rptOperacional.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource
        '
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource.DataMember = "FRPJ_SP_RPT_CANCELAMENTO_CORRETORA"
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource.DataSource = Me.DS_rptOperacional
        '
        'FRPJ_SP_RPT_ENDOSSOBindingSource
        '
        Me.FRPJ_SP_RPT_ENDOSSOBindingSource.DataMember = "FRPJ_SP_RPT_ENDOSSO"
        Me.FRPJ_SP_RPT_ENDOSSOBindingSource.DataSource = Me.DS_rptOperacional
        '
        'FRPJ_SP_RPT_EMISSAOBindingSource
        '
        Me.FRPJ_SP_RPT_EMISSAOBindingSource.DataMember = "FRPJ_SP_RPT_EMISSAO"
        Me.FRPJ_SP_RPT_EMISSAOBindingSource.DataSource = Me.DS_rptOperacional
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsEndosso"
        ReportDataSource1.Value = Me.FRPj_SP_RPT_SLA_ENDOSSOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "FRPJ.rpt_Sla_Endosso.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 64)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(918, 380)
        Me.ReportViewer1.TabIndex = 0
        '
        'FRPJ_SP_RPT_EMISSAOTableAdapter
        '
        Me.FRPJ_SP_RPT_EMISSAOTableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.btnGerar)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Controls.Add(Me.cboMesrefIni)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(918, 64)
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
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(6, 9)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(43, 14)
        Me.L1.TabIndex = 6
        Me.L1.Text = "Mesref"
        '
        'FRPJ_SP_RPT_ENDOSSOTableAdapter
        '
        Me.FRPJ_SP_RPT_ENDOSSOTableAdapter.ClearBeforeFill = True
        '
        'FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter
        '
        Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter.ClearBeforeFill = True
        '
        'FRPj_SP_RPT_SLA_ENDOSSOTableAdapter
        '
        Me.FRPj_SP_RPT_SLA_ENDOSSOTableAdapter.ClearBeforeFill = True
        '
        'cboMesrefIni
        '
        Me.cboMesrefIni.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMesrefIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesrefIni.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesrefIni.FormattingEnabled = True
        Me.cboMesrefIni.Location = New System.Drawing.Point(9, 26)
        Me.cboMesrefIni.Name = "cboMesrefIni"
        Me.cboMesrefIni.Size = New System.Drawing.Size(92, 23)
        Me.cboMesrefIni.TabIndex = 4
        '
        'frm_rpt_Sla_Endosso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 444)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_rpt_Sla_Endosso"
        Me.Text = "Relatório Operacional - SLA Endosso Diário"
        CType(Me.FRPj_SP_RPT_SLA_ENDOSSOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_rptOperacional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FRPJ_SP_RPT_ENDOSSOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FRPJ_SP_RPT_EMISSAOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FRPJ_SP_RPT_EMISSAOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DS_rptOperacional As FRPJ.DS_rptOperacional
    Friend WithEvents FRPJ_SP_RPT_EMISSAOTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_EMISSAOTableAdapter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGerar As System.Windows.Forms.Button
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents cboMesrefIni As FRPJ.CenteredComboBox
    Friend WithEvents FRPJ_SP_RPT_ENDOSSOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FRPJ_SP_RPT_ENDOSSOTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_ENDOSSOTableAdapter
    Friend WithEvents FRPJ_SP_RPT_CANCELAMENTO_CORRETORABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_CANCELAMENTO_CORRETORATableAdapter
    Friend WithEvents FRPj_SP_RPT_SLA_ENDOSSOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FRPj_SP_RPT_SLA_ENDOSSOTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPj_SP_RPT_SLA_ENDOSSOTableAdapter
End Class
