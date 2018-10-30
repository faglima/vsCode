<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Retencao_PJ_SAC
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtAg = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCorrentista = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboOrigem = New System.Windows.Forms.ComboBox()
        Me.L2 = New System.Windows.Forms.Label()
        Me.txtCnpj = New System.Windows.Forms.MaskedTextBox()
        Me.lbl01 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtProtocoloSac = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbl03 = New System.Windows.Forms.Label()
        Me.txtCodProdRector = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGrupoProd = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDtFimVig = New System.Windows.Forms.MaskedTextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDtIniVig = New System.Windows.Forms.MaskedTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtPremio = New System.Windows.Forms.TextBox()
        Me.btnAtivar = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCertificado = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtApolice = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtProposta = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lbl04 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtMatricula = New System.Windows.Forms.MaskedTextBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lMotivo2 = New System.Windows.Forms.Label()
        Me.cboMotivo2 = New System.Windows.Forms.ComboBox()
        Me.rbtnCancNEfetuado = New System.Windows.Forms.RadioButton()
        Me.rbtnClienteAtrito = New System.Windows.Forms.RadioButton()
        Me.lMatricula = New System.Windows.Forms.Label()
        Me.chkClienteAgencia = New System.Windows.Forms.CheckBox()
        Me.lMotivo = New System.Windows.Forms.Label()
        Me.cboMotivo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDesfecho = New System.Windows.Forms.ComboBox()
        Me.rbtnCancelamento = New System.Windows.Forms.RadioButton()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnLimparAt = New System.Windows.Forms.Button()
        Me.btnLimparForm = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.txtAg)
        Me.Panel2.Controls.Add(Me.txtProtocoloSac)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtCC)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cboBanco)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.cboCorrentista)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cboOrigem)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.txtCnpj)
        Me.Panel2.Location = New System.Drawing.Point(12, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1006, 75)
        Me.Panel2.TabIndex = 0
        '
        'txtAg
        '
        Me.txtAg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAg.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtAg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAg.ForeColor = System.Drawing.Color.Black
        Me.txtAg.Location = New System.Drawing.Point(657, 28)
        Me.txtAg.Mask = "0000"
        Me.txtAg.Name = "txtAg"
        Me.txtAg.Size = New System.Drawing.Size(51, 22)
        Me.txtAg.TabIndex = 73
        Me.txtAg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAg.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(711, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 14)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Conta Corrente:"
        '
        'txtCC
        '
        Me.txtCC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCC.Location = New System.Drawing.Point(714, 28)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(130, 22)
        Me.txtCC.TabIndex = 74
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(654, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 14)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Agência:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(356, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 14)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Banco:"
        '
        'cboBanco
        '
        Me.cboBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(359, 28)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(292, 22)
        Me.cboBanco.TabIndex = 70
        Me.cboBanco.Tag = "2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(283, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Correntista:"
        '
        'cboCorrentista
        '
        Me.cboCorrentista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorrentista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCorrentista.FormattingEnabled = True
        Me.cboCorrentista.Location = New System.Drawing.Point(286, 28)
        Me.cboCorrentista.Name = "cboCorrentista"
        Me.cboCorrentista.Size = New System.Drawing.Size(67, 22)
        Me.cboCorrentista.TabIndex = 68
        Me.cboCorrentista.Tag = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(156, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Origem:"
        '
        'cboOrigem
        '
        Me.cboOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboOrigem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigem.Enabled = False
        Me.cboOrigem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrigem.FormattingEnabled = True
        Me.cboOrigem.Location = New System.Drawing.Point(159, 28)
        Me.cboOrigem.Name = "cboOrigem"
        Me.cboOrigem.Size = New System.Drawing.Size(121, 22)
        Me.cboOrigem.TabIndex = 2
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.Black
        Me.L2.Location = New System.Drawing.Point(10, 11)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(102, 14)
        Me.L2.TabIndex = 57
        Me.L2.Text = "Cnpj da Empresa:"
        '
        'txtCnpj
        '
        Me.txtCnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCnpj.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCnpj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCnpj.ForeColor = System.Drawing.Color.Black
        Me.txtCnpj.Location = New System.Drawing.Point(13, 28)
        Me.txtCnpj.Mask = "00,000,000/0000-00"
        Me.txtCnpj.Name = "txtCnpj"
        Me.txtCnpj.Size = New System.Drawing.Size(140, 22)
        Me.txtCnpj.TabIndex = 1
        Me.txtCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lbl01
        '
        Me.lbl01.AutoSize = True
        Me.lbl01.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl01.ForeColor = System.Drawing.Color.Black
        Me.lbl01.Location = New System.Drawing.Point(10, 6)
        Me.lbl01.Name = "lbl01"
        Me.lbl01.Size = New System.Drawing.Size(166, 14)
        Me.lbl01.TabIndex = 58
        Me.lbl01.Text = "Dados da Empresa Segurada:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.lbl01)
        Me.Panel1.Location = New System.Drawing.Point(12, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1006, 28)
        Me.Panel1.TabIndex = 59
        '
        'ErrProv
        '
        Me.ErrProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrProv.ContainerControl = Me
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(847, 11)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(122, 14)
        Me.Label47.TabIndex = 93
        Me.Label47.Text = "Nº Protocolo People:"
        '
        'txtProtocoloSac
        '
        Me.txtProtocoloSac.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProtocoloSac.Location = New System.Drawing.Point(850, 28)
        Me.txtProtocoloSac.Name = "txtProtocoloSac"
        Me.txtProtocoloSac.Size = New System.Drawing.Size(124, 22)
        Me.txtProtocoloSac.TabIndex = 75
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.lbl03)
        Me.Panel5.Location = New System.Drawing.Point(12, 103)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1006, 28)
        Me.Panel5.TabIndex = 63
        '
        'lbl03
        '
        Me.lbl03.AutoSize = True
        Me.lbl03.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl03.ForeColor = System.Drawing.Color.Black
        Me.lbl03.Location = New System.Drawing.Point(10, 6)
        Me.lbl03.Name = "lbl03"
        Me.lbl03.Size = New System.Drawing.Size(137, 14)
        Me.lbl03.TabIndex = 58
        Me.lbl03.Text = "Dados do Seguro Atual:"
        '
        'txtCodProdRector
        '
        Me.txtCodProdRector.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodProdRector.Location = New System.Drawing.Point(13, 23)
        Me.txtCodProdRector.Name = "txtCodProdRector"
        Me.txtCodProdRector.Size = New System.Drawing.Size(119, 22)
        Me.txtCodProdRector.TabIndex = 78
        Me.txtCodProdRector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(10, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 14)
        Me.Label19.TabIndex = 79
        Me.Label19.Text = "Produto Rector:"
        '
        'txtGrupoProd
        '
        Me.txtGrupoProd.Enabled = False
        Me.txtGrupoProd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupoProd.Location = New System.Drawing.Point(13, 68)
        Me.txtGrupoProd.Name = "txtGrupoProd"
        Me.txtGrupoProd.Size = New System.Drawing.Size(235, 22)
        Me.txtGrupoProd.TabIndex = 80
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(10, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 14)
        Me.Label20.TabIndex = 81
        Me.Label20.Text = "Grupo Produto:"
        '
        'txtDtFimVig
        '
        Me.txtDtFimVig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDtFimVig.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtDtFimVig.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDtFimVig.ForeColor = System.Drawing.Color.Black
        Me.txtDtFimVig.Location = New System.Drawing.Point(257, 68)
        Me.txtDtFimVig.Mask = "00/00/0000"
        Me.txtDtFimVig.Name = "txtDtFimVig"
        Me.txtDtFimVig.Size = New System.Drawing.Size(110, 22)
        Me.txtDtFimVig.TabIndex = 85
        Me.txtDtFimVig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDtFimVig.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(254, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(107, 14)
        Me.Label21.TabIndex = 83
        Me.Label21.Text = "Data Fim Vigência:"
        '
        'txtDtIniVig
        '
        Me.txtDtIniVig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDtIniVig.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtDtIniVig.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDtIniVig.ForeColor = System.Drawing.Color.Black
        Me.txtDtIniVig.Location = New System.Drawing.Point(257, 23)
        Me.txtDtIniVig.Mask = "00/00/0000"
        Me.txtDtIniVig.Name = "txtDtIniVig"
        Me.txtDtIniVig.Size = New System.Drawing.Size(110, 22)
        Me.txtDtIniVig.TabIndex = 84
        Me.txtDtIniVig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDtIniVig.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(254, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 14)
        Me.Label23.TabIndex = 85
        Me.Label23.Text = "Data Ini Vigência:"
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.txtPremio)
        Me.Panel6.Controls.Add(Me.btnAtivar)
        Me.Panel6.Controls.Add(Me.Label27)
        Me.Panel6.Controls.Add(Me.Label25)
        Me.Panel6.Controls.Add(Me.txtCertificado)
        Me.Panel6.Controls.Add(Me.Label24)
        Me.Panel6.Controls.Add(Me.txtApolice)
        Me.Panel6.Controls.Add(Me.Label22)
        Me.Panel6.Controls.Add(Me.txtProposta)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Controls.Add(Me.txtDtIniVig)
        Me.Panel6.Controls.Add(Me.Label21)
        Me.Panel6.Controls.Add(Me.txtDtFimVig)
        Me.Panel6.Controls.Add(Me.Label20)
        Me.Panel6.Controls.Add(Me.txtGrupoProd)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.txtCodProdRector)
        Me.Panel6.Location = New System.Drawing.Point(12, 130)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1006, 111)
        Me.Panel6.TabIndex = 61
        '
        'txtPremio
        '
        Me.txtPremio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPremio.Location = New System.Drawing.Point(540, 68)
        Me.txtPremio.Name = "txtPremio"
        Me.txtPremio.Size = New System.Drawing.Size(151, 22)
        Me.txtPremio.TabIndex = 94
        '
        'btnAtivar
        '
        Me.btnAtivar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtivar.Location = New System.Drawing.Point(706, 62)
        Me.btnAtivar.Name = "btnAtivar"
        Me.btnAtivar.Size = New System.Drawing.Size(100, 28)
        Me.btnAtivar.TabIndex = 98
        Me.btnAtivar.Text = "Ativar Retenção"
        Me.btnAtivar.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(537, 51)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(81, 14)
        Me.Label27.TabIndex = 95
        Me.Label27.Text = "Parcela Atual:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(537, 6)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 14)
        Me.Label25.TabIndex = 91
        Me.Label25.Text = "Certificado:"
        '
        'txtCertificado
        '
        Me.txtCertificado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertificado.Location = New System.Drawing.Point(540, 23)
        Me.txtCertificado.Name = "txtCertificado"
        Me.txtCertificado.Size = New System.Drawing.Size(151, 22)
        Me.txtCertificado.TabIndex = 90
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(370, 51)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 14)
        Me.Label24.TabIndex = 89
        Me.Label24.Text = "Apolice:"
        '
        'txtApolice
        '
        Me.txtApolice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApolice.Location = New System.Drawing.Point(373, 68)
        Me.txtApolice.Name = "txtApolice"
        Me.txtApolice.Size = New System.Drawing.Size(161, 22)
        Me.txtApolice.TabIndex = 88
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(370, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 14)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "Nro. Proposta VC:"
        '
        'txtProposta
        '
        Me.txtProposta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProposta.Location = New System.Drawing.Point(373, 23)
        Me.txtProposta.Name = "txtProposta"
        Me.txtProposta.Size = New System.Drawing.Size(161, 22)
        Me.txtProposta.TabIndex = 86
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.Controls.Add(Me.lbl04)
        Me.Panel7.Location = New System.Drawing.Point(12, 240)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1006, 28)
        Me.Panel7.TabIndex = 63
        Me.Panel7.Visible = False
        '
        'lbl04
        '
        Me.lbl04.AutoSize = True
        Me.lbl04.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl04.ForeColor = System.Drawing.Color.Black
        Me.lbl04.Location = New System.Drawing.Point(10, 6)
        Me.lbl04.Name = "lbl04"
        Me.lbl04.Size = New System.Drawing.Size(139, 14)
        Me.lbl04.TabIndex = 58
        Me.lbl04.Text = "Atendimento Retenção:"
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.Controls.Add(Me.txtMatricula)
        Me.Panel8.Controls.Add(Me.txtObs)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.lMotivo2)
        Me.Panel8.Controls.Add(Me.cboMotivo2)
        Me.Panel8.Controls.Add(Me.rbtnCancNEfetuado)
        Me.Panel8.Controls.Add(Me.rbtnClienteAtrito)
        Me.Panel8.Controls.Add(Me.lMatricula)
        Me.Panel8.Controls.Add(Me.chkClienteAgencia)
        Me.Panel8.Controls.Add(Me.lMotivo)
        Me.Panel8.Controls.Add(Me.cboMotivo)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.cboDesfecho)
        Me.Panel8.Controls.Add(Me.rbtnCancelamento)
        Me.Panel8.Controls.Add(Me.ShapeContainer1)
        Me.Panel8.Location = New System.Drawing.Point(12, 266)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1006, 156)
        Me.Panel8.TabIndex = 62
        Me.Panel8.Visible = False
        '
        'txtMatricula
        '
        Me.txtMatricula.Location = New System.Drawing.Point(819, 114)
        Me.txtMatricula.Mask = "000000"
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(100, 20)
        Me.txtMatricula.TabIndex = 128
        Me.txtMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMatricula.Visible = False
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(13, 110)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(780, 37)
        Me.txtObs.TabIndex = 127
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(10, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 14)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Obs:"
        '
        'lMotivo2
        '
        Me.lMotivo2.AutoSize = True
        Me.lMotivo2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMotivo2.ForeColor = System.Drawing.Color.Black
        Me.lMotivo2.Location = New System.Drawing.Point(438, 51)
        Me.lMotivo2.Name = "lMotivo2"
        Me.lMotivo2.Size = New System.Drawing.Size(100, 14)
        Me.lMotivo2.TabIndex = 125
        Me.lMotivo2.Text = "Motivo Gerencial:"
        Me.lMotivo2.Visible = False
        '
        'cboMotivo2
        '
        Me.cboMotivo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMotivo2.FormattingEnabled = True
        Me.cboMotivo2.Location = New System.Drawing.Point(441, 68)
        Me.cboMotivo2.Name = "cboMotivo2"
        Me.cboMotivo2.Size = New System.Drawing.Size(352, 22)
        Me.cboMotivo2.TabIndex = 124
        Me.cboMotivo2.Visible = False
        '
        'rbtnCancNEfetuado
        '
        Me.rbtnCancNEfetuado.AutoSize = True
        Me.rbtnCancNEfetuado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCancNEfetuado.ForeColor = System.Drawing.Color.Red
        Me.rbtnCancNEfetuado.Location = New System.Drawing.Point(304, 16)
        Me.rbtnCancNEfetuado.Name = "rbtnCancNEfetuado"
        Me.rbtnCancNEfetuado.Size = New System.Drawing.Size(198, 18)
        Me.rbtnCancNEfetuado.TabIndex = 123
        Me.rbtnCancNEfetuado.TabStop = True
        Me.rbtnCancNEfetuado.Text = "Cancelamento Não Efetuado"
        Me.rbtnCancNEfetuado.UseVisualStyleBackColor = True
        '
        'rbtnClienteAtrito
        '
        Me.rbtnClienteAtrito.AutoSize = True
        Me.rbtnClienteAtrito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnClienteAtrito.ForeColor = System.Drawing.Color.Red
        Me.rbtnClienteAtrito.Location = New System.Drawing.Point(152, 16)
        Me.rbtnClienteAtrito.Name = "rbtnClienteAtrito"
        Me.rbtnClienteAtrito.Size = New System.Drawing.Size(130, 18)
        Me.rbtnClienteAtrito.TabIndex = 122
        Me.rbtnClienteAtrito.TabStop = True
        Me.rbtnClienteAtrito.Text = "Cliente em Atrito"
        Me.rbtnClienteAtrito.UseVisualStyleBackColor = True
        '
        'lMatricula
        '
        Me.lMatricula.AutoSize = True
        Me.lMatricula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMatricula.ForeColor = System.Drawing.Color.DarkBlue
        Me.lMatricula.Location = New System.Drawing.Point(817, 98)
        Me.lMatricula.Name = "lMatricula"
        Me.lMatricula.Size = New System.Drawing.Size(111, 13)
        Me.lMatricula.TabIndex = 121
        Me.lMatricula.Text = "Matrícula do Gerente:"
        Me.lMatricula.Visible = False
        '
        'chkClienteAgencia
        '
        Me.chkClienteAgencia.AutoSize = True
        Me.chkClienteAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClienteAgencia.ForeColor = System.Drawing.Color.Navy
        Me.chkClienteAgencia.Location = New System.Drawing.Point(819, 73)
        Me.chkClienteAgencia.Name = "chkClienteAgencia"
        Me.chkClienteAgencia.Size = New System.Drawing.Size(115, 17)
        Me.chkClienteAgencia.TabIndex = 119
        Me.chkClienteAgencia.Text = "Cliente na Agência"
        Me.chkClienteAgencia.UseVisualStyleBackColor = True
        '
        'lMotivo
        '
        Me.lMotivo.AutoSize = True
        Me.lMotivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMotivo.ForeColor = System.Drawing.Color.Black
        Me.lMotivo.Location = New System.Drawing.Point(106, 51)
        Me.lMotivo.Name = "lMotivo"
        Me.lMotivo.Size = New System.Drawing.Size(47, 14)
        Me.lMotivo.TabIndex = 75
        Me.lMotivo.Text = "Motivo:"
        Me.lMotivo.Visible = False
        '
        'cboMotivo
        '
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMotivo.FormattingEnabled = True
        Me.cboMotivo.Location = New System.Drawing.Point(109, 68)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(326, 22)
        Me.cboMotivo.TabIndex = 4
        Me.cboMotivo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Desfecho:"
        '
        'cboDesfecho
        '
        Me.cboDesfecho.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDesfecho.FormattingEnabled = True
        Me.cboDesfecho.Location = New System.Drawing.Point(13, 68)
        Me.cboDesfecho.Name = "cboDesfecho"
        Me.cboDesfecho.Size = New System.Drawing.Size(90, 22)
        Me.cboDesfecho.TabIndex = 3
        '
        'rbtnCancelamento
        '
        Me.rbtnCancelamento.AutoSize = True
        Me.rbtnCancelamento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCancelamento.ForeColor = System.Drawing.Color.Red
        Me.rbtnCancelamento.Location = New System.Drawing.Point(13, 16)
        Me.rbtnCancelamento.Name = "rbtnCancelamento"
        Me.rbtnCancelamento.Size = New System.Drawing.Size(111, 18)
        Me.rbtnCancelamento.TabIndex = 1
        Me.rbtnCancelamento.TabStop = True
        Me.rbtnCancelamento.Text = "Cancelamento"
        Me.rbtnCancelamento.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1006, 156)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.BorderColor = System.Drawing.Color.Gainsboro
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 0
        Me.LineShape1.X2 = 1006
        Me.LineShape1.Y1 = 44
        Me.LineShape1.Y2 = 44
        '
        'btnSalvar
        '
        Me.btnSalvar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalvar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalvar.Location = New System.Drawing.Point(896, 433)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(114, 28)
        Me.btnSalvar.TabIndex = 99
        Me.btnSalvar.Text = "Salvar Atendimento"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnLimparAt
        '
        Me.btnLimparAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimparAt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimparAt.Location = New System.Drawing.Point(25, 433)
        Me.btnLimparAt.Name = "btnLimparAt"
        Me.btnLimparAt.Size = New System.Drawing.Size(114, 28)
        Me.btnLimparAt.TabIndex = 100
        Me.btnLimparAt.Text = "Limpar Atendimento"
        Me.btnLimparAt.UseVisualStyleBackColor = True
        '
        'btnLimparForm
        '
        Me.btnLimparForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimparForm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimparForm.Location = New System.Drawing.Point(150, 433)
        Me.btnLimparForm.Name = "btnLimparForm"
        Me.btnLimparForm.Size = New System.Drawing.Size(114, 28)
        Me.btnLimparForm.TabIndex = 101
        Me.btnLimparForm.Text = "Limpar Formulário"
        Me.btnLimparForm.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.Location = New System.Drawing.Point(276, 433)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(114, 28)
        Me.btnFechar.TabIndex = 102
        Me.btnFechar.Text = "Fechar Atendimento"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'frm_Retencao_PJ_SAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1030, 465)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnLimparForm)
        Me.Controls.Add(Me.btnLimparAt)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.Name = "frm_Retencao_PJ_SAC"
        Me.Text = "Atendimento Retenção PJ - SAC"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents txtCnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl01 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCorrentista As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lbl03 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtProposta As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDtIniVig As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtDtFimVig As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoProd As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCodProdRector As System.Windows.Forms.TextBox
    Friend WithEvents btnAtivar As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtCertificado As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtApolice As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lbl04 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents rbtnCancelamento As System.Windows.Forms.RadioButton
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lMotivo As System.Windows.Forms.Label
    Friend WithEvents cboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDesfecho As System.Windows.Forms.ComboBox
    Friend WithEvents btnFechar As System.Windows.Forms.Button
    Friend WithEvents btnLimparForm As System.Windows.Forms.Button
    Friend WithEvents btnLimparAt As System.Windows.Forms.Button
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents lMatricula As System.Windows.Forms.Label
    Friend WithEvents chkClienteAgencia As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnCancNEfetuado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnClienteAtrito As System.Windows.Forms.RadioButton
    Friend WithEvents lMotivo2 As System.Windows.Forms.Label
    Friend WithEvents cboMotivo2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAg As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPremio As System.Windows.Forms.TextBox
    Friend WithEvents txtMatricula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtProtocoloSac As System.Windows.Forms.TextBox
End Class
