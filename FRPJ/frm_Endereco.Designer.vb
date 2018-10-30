<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Endereco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Endereco))
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.txtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComplemento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUF = New System.Windows.Forms.MaskedTextBox()
        Me.cboTipoRes = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCan = New System.Windows.Forms.Button()
        Me.btnBaixar = New System.Windows.Forms.Button()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkSave = New System.Windows.Forms.CheckBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 14)
        Me.Label17.TabIndex = 82
        Me.Label17.Text = "Endereço:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(19, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 14)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "CEP:"
        '
        'txtEnd
        '
        Me.txtEnd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrProv.SetIconPadding(Me.txtEnd, -10)
        Me.txtEnd.Location = New System.Drawing.Point(22, 83)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(631, 22)
        Me.txtEnd.TabIndex = 81
        '
        'txtCEP
        '
        Me.txtCEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCEP.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCEP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEP.ForeColor = System.Drawing.Color.Black
        Me.txtCEP.Location = New System.Drawing.Point(22, 31)
        Me.txtCEP.Mask = "00000-000"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(77, 22)
        Me.txtCEP.TabIndex = 80
        Me.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCEP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(656, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Número:"
        '
        'txtNro
        '
        Me.txtNro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro.Location = New System.Drawing.Point(659, 83)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(78, 22)
        Me.txtNro.TabIndex = 84
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 14)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Complemento:"
        '
        'txtComplemento
        '
        Me.txtComplemento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComplemento.Location = New System.Drawing.Point(22, 129)
        Me.txtComplemento.Name = "txtComplemento"
        Me.txtComplemento.Size = New System.Drawing.Size(268, 22)
        Me.txtComplemento.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(293, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Bairro:"
        '
        'txtBairro
        '
        Me.txtBairro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBairro.Location = New System.Drawing.Point(296, 129)
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(441, 22)
        Me.txtBairro.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Cidade:"
        '
        'txtCidade
        '
        Me.txtCidade.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrProv.SetIconPadding(Me.txtCidade, -10)
        Me.txtCidade.Location = New System.Drawing.Point(22, 176)
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(663, 22)
        Me.txtCidade.TabIndex = 90
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(688, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 14)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "UF:"
        '
        'txtUF
        '
        Me.txtUF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUF.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtUF.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUF.ForeColor = System.Drawing.Color.Black
        Me.txtUF.Location = New System.Drawing.Point(691, 176)
        Me.txtUF.Mask = "AA"
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(46, 22)
        Me.txtUF.TabIndex = 92
        Me.txtUF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtUF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'cboTipoRes
        '
        Me.cboTipoRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoRes.FormattingEnabled = True
        Me.cboTipoRes.Location = New System.Drawing.Point(22, 225)
        Me.cboTipoRes.Name = "cboTipoRes"
        Me.cboTipoRes.Size = New System.Drawing.Size(136, 22)
        Me.cboTipoRes.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 14)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Tipo de Residência:"
        '
        'btnCan
        '
        Me.btnCan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCan.Image = CType(resources.GetObject("btnCan.Image"), System.Drawing.Image)
        Me.btnCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCan.Location = New System.Drawing.Point(517, 267)
        Me.btnCan.Name = "btnCan"
        Me.btnCan.Size = New System.Drawing.Size(87, 29)
        Me.btnCan.TabIndex = 97
        Me.btnCan.TabStop = False
        Me.btnCan.Text = "  Cancelar"
        Me.btnCan.UseVisualStyleBackColor = True
        '
        'btnBaixar
        '
        Me.btnBaixar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBaixar.Image = CType(resources.GetObject("btnBaixar.Image"), System.Drawing.Image)
        Me.btnBaixar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaixar.Location = New System.Drawing.Point(650, 267)
        Me.btnBaixar.Name = "btnBaixar"
        Me.btnBaixar.Size = New System.Drawing.Size(87, 29)
        Me.btnBaixar.TabIndex = 96
        Me.btnBaixar.Text = "Confirmar"
        Me.btnBaixar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaixar.UseVisualStyleBackColor = True
        '
        'ErrProv
        '
        Me.ErrProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrProv.ContainerControl = Me
        '
        'chkSave
        '
        Me.chkSave.AutoSize = True
        Me.chkSave.Location = New System.Drawing.Point(331, 267)
        Me.chkSave.Name = "chkSave"
        Me.chkSave.Size = New System.Drawing.Size(81, 17)
        Me.chkSave.TabIndex = 98
        Me.chkSave.Text = "CheckBox1"
        Me.chkSave.UseVisualStyleBackColor = True
        Me.chkSave.Visible = False
        '
        'frm_Endereco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(757, 316)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkSave)
        Me.Controls.Add(Me.btnCan)
        Me.Controls.Add(Me.btnBaixar)
        Me.Controls.Add(Me.cboTipoRes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUF)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtComplemento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNro)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.txtCEP)
        Me.KeyPreview = True
        Me.Name = "frm_Endereco"
        Me.Text = "Endereço de risco"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtCEP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBairro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCidade As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboTipoRes As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCan As System.Windows.Forms.Button
    Friend WithEvents btnBaixar As System.Windows.Forms.Button
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkSave As System.Windows.Forms.CheckBox
End Class
