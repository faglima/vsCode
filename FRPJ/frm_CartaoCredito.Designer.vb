<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CartaoCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CartaoCredito))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.rbtnVisa = New System.Windows.Forms.RadioButton()
        Me.rbtnMaster = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCC4 = New System.Windows.Forms.MaskedTextBox()
        Me.txtCC2 = New System.Windows.Forms.TextBox()
        Me.txtCC3 = New System.Windows.Forms.TextBox()
        Me.txtCC1 = New System.Windows.Forms.TextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(39, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(131, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 31)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'rbtnVisa
        '
        Me.rbtnVisa.AutoSize = True
        Me.rbtnVisa.Location = New System.Drawing.Point(18, 30)
        Me.rbtnVisa.Name = "rbtnVisa"
        Me.rbtnVisa.Size = New System.Drawing.Size(14, 13)
        Me.rbtnVisa.TabIndex = 2
        Me.rbtnVisa.TabStop = True
        Me.rbtnVisa.UseVisualStyleBackColor = True
        '
        'rbtnMaster
        '
        Me.rbtnMaster.AutoSize = True
        Me.rbtnMaster.Location = New System.Drawing.Point(111, 30)
        Me.rbtnMaster.Name = "rbtnMaster"
        Me.rbtnMaster.Size = New System.Drawing.Size(14, 13)
        Me.rbtnMaster.TabIndex = 3
        Me.rbtnMaster.TabStop = True
        Me.rbtnMaster.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtCC4)
        Me.Panel1.Controls.Add(Me.txtCC2)
        Me.Panel1.Controls.Add(Me.txtCC3)
        Me.Panel1.Controls.Add(Me.txtCC1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.rbtnMaster)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.rbtnVisa)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 114)
        Me.Panel1.TabIndex = 4
        '
        'txtCC4
        '
        Me.txtCC4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCC4.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtCC4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCC4.ForeColor = System.Drawing.Color.Black
        Me.txtCC4.Location = New System.Drawing.Point(210, 68)
        Me.txtCC4.Mask = "0000"
        Me.txtCC4.Name = "txtCC4"
        Me.txtCC4.Size = New System.Drawing.Size(58, 22)
        Me.txtCC4.TabIndex = 86
        Me.txtCC4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCC4.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtCC2
        '
        Me.txtCC2.Enabled = False
        Me.txtCC2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCC2.Location = New System.Drawing.Point(82, 68)
        Me.txtCC2.Name = "txtCC2"
        Me.txtCC2.Size = New System.Drawing.Size(58, 22)
        Me.txtCC2.TabIndex = 7
        '
        'txtCC3
        '
        Me.txtCC3.Enabled = False
        Me.txtCC3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCC3.Location = New System.Drawing.Point(146, 68)
        Me.txtCC3.Name = "txtCC3"
        Me.txtCC3.Size = New System.Drawing.Size(58, 22)
        Me.txtCC3.TabIndex = 6
        '
        'txtCC1
        '
        Me.txtCC1.Enabled = False
        Me.txtCC1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCC1.Location = New System.Drawing.Point(18, 68)
        Me.txtCC1.Name = "txtCC1"
        Me.txtCC1.Size = New System.Drawing.Size(58, 22)
        Me.txtCC1.TabIndex = 4
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = CType(resources.GetObject("btnSalvar.Image"), System.Drawing.Image)
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(229, 139)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 25)
        Me.btnSalvar.TabIndex = 5
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(136, 139)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frm_CartaoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(318, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_CartaoCredito"
        Me.ShowIcon = False
        Me.Text = "Dados do Cartão de Crédito"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents rbtnVisa As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMaster As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCC2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCC3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCC1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents txtCC4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
