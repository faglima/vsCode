<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Dash
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
        Me.btnGrapf = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboEps = New System.Windows.Forms.ComboBox()
        Me.cboMesref = New System.Windows.Forms.ComboBox()
        Me.cboOrigem = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnGrapf
        '
        Me.btnGrapf.Location = New System.Drawing.Point(20, 75)
        Me.btnGrapf.Name = "btnGrapf"
        Me.btnGrapf.Size = New System.Drawing.Size(307, 26)
        Me.btnGrapf.TabIndex = 0
        Me.btnGrapf.Text = "Gerar Apresentação de Indicadores "
        Me.btnGrapf.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Mesref:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(201, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Eps:"
        '
        'cboEps
        '
        Me.cboEps.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEps.FormattingEnabled = True
        Me.cboEps.Location = New System.Drawing.Point(201, 36)
        Me.cboEps.Name = "cboEps"
        Me.cboEps.Size = New System.Drawing.Size(126, 22)
        Me.cboEps.TabIndex = 9
        '
        'cboMesref
        '
        Me.cboMesref.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesref.FormattingEnabled = True
        Me.cboMesref.Location = New System.Drawing.Point(107, 36)
        Me.cboMesref.Name = "cboMesref"
        Me.cboMesref.Size = New System.Drawing.Size(88, 22)
        Me.cboMesref.TabIndex = 10
        '
        'cboOrigem
        '
        Me.cboOrigem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrigem.FormattingEnabled = True
        Me.cboOrigem.Location = New System.Drawing.Point(20, 36)
        Me.cboOrigem.Name = "cboOrigem"
        Me.cboOrigem.Size = New System.Drawing.Size(81, 22)
        Me.cboOrigem.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Origem:"
        '
        'frm_Dash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(510, 303)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboOrigem)
        Me.Controls.Add(Me.cboMesref)
        Me.Controls.Add(Me.cboEps)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGrapf)
        Me.Name = "frm_Dash"
        Me.Text = "Gerar Indicadores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGrapf As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboEps As System.Windows.Forms.ComboBox
    Friend WithEvents cboMesref As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
