﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rpt_Operacao_Emissao_Mensal
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
        Me.FRPJ_SP_RPT_EMISSAOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_rptOperacional = New FRPJ.DS_rptOperacional()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.FRPJ_SP_RPT_EMISSAOTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_EMISSAOTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGerar = New System.Windows.Forms.Button()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.cboMesrefFim = New FRPJ.CenteredComboBox()
        Me.cboMesrefIni = New FRPJ.CenteredComboBox()
        Me.FRPJ_SP_RPT_EMISSAO_MENSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FRPJ_SP_RPT_EMISSAO_MENSALTableAdapter = New FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_EMISSAO_MENSALTableAdapter()
        CType(Me.FRPJ_SP_RPT_EMISSAOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_rptOperacional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.FRPJ_SP_RPT_EMISSAO_MENSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FRPJ_SP_RPT_EMISSAOBindingSource
        '
        Me.FRPJ_SP_RPT_EMISSAOBindingSource.DataMember = "FRPJ_SP_RPT_EMISSAO"
        Me.FRPJ_SP_RPT_EMISSAOBindingSource.DataSource = Me.DS_rptOperacional
        '
        'DS_rptOperacional
        '
        Me.DS_rptOperacional.DataSetName = "DS_rptOperacional"
        Me.DS_rptOperacional.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsEmissao"
        ReportDataSource1.Value = Me.FRPJ_SP_RPT_EMISSAO_MENSALBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "FRPJ.rpt_Operacao_Emissao_Mensal.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 64)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(715, 380)
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
        Me.Panel1.Controls.Add(Me.L2)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Controls.Add(Me.cboMesrefFim)
        Me.Panel1.Controls.Add(Me.cboMesrefIni)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 64)
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
        'cboMesrefFim
        '
        Me.cboMesrefFim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMesrefFim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesrefFim.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesrefFim.FormattingEnabled = True
        Me.cboMesrefFim.Location = New System.Drawing.Point(107, 26)
        Me.cboMesrefFim.Name = "cboMesrefFim"
        Me.cboMesrefFim.Size = New System.Drawing.Size(92, 23)
        Me.cboMesrefFim.TabIndex = 5
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
        'FRPJ_SP_RPT_EMISSAO_MENSALBindingSource
        '
        Me.FRPJ_SP_RPT_EMISSAO_MENSALBindingSource.DataMember = "FRPJ_SP_RPT_EMISSAO_MENSAL"
        Me.FRPJ_SP_RPT_EMISSAO_MENSALBindingSource.DataSource = Me.DS_rptOperacional
        '
        'FRPJ_SP_RPT_EMISSAO_MENSALTableAdapter
        '
        Me.FRPJ_SP_RPT_EMISSAO_MENSALTableAdapter.ClearBeforeFill = True
        '
        'frm_rpt_Operacao_Emissao_Mensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 444)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_rpt_Operacao_Emissao_Mensal"
        Me.Text = "Relatório Operacional - Emissão Mensal"
        CType(Me.FRPJ_SP_RPT_EMISSAOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_rptOperacional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FRPJ_SP_RPT_EMISSAO_MENSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FRPJ_SP_RPT_EMISSAOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DS_rptOperacional As FRPJ.DS_rptOperacional
    Friend WithEvents FRPJ_SP_RPT_EMISSAOTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_EMISSAOTableAdapter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGerar As System.Windows.Forms.Button
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents cboMesrefFim As FRPJ.CenteredComboBox
    Friend WithEvents cboMesrefIni As FRPJ.CenteredComboBox
    Friend WithEvents FRPJ_SP_RPT_EMISSAO_MENSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FRPJ_SP_RPT_EMISSAO_MENSALTableAdapter As FRPJ.DS_rptOperacionalTableAdapters.FRPJ_SP_RPT_EMISSAO_MENSALTableAdapter
End Class
