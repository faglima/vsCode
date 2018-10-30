<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Endosso_NOK_Nivel2_Baixar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Endosso_NOK_Nivel2_Baixar))
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBaixar = New System.Windows.Forms.Button()
        Me.btnCan = New System.Windows.Forms.Button()
        Me.txtProposta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkOK = New System.Windows.Forms.CheckBox()
        Me.chkNok = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(15, 145)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(433, 60)
        Me.txtObs.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Digite um breve texto referente ao tratamento:"
        '
        'btnBaixar
        '
        Me.btnBaixar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBaixar.Image = CType(resources.GetObject("btnBaixar.Image"), System.Drawing.Image)
        Me.btnBaixar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaixar.Location = New System.Drawing.Point(368, 219)
        Me.btnBaixar.Name = "btnBaixar"
        Me.btnBaixar.Size = New System.Drawing.Size(80, 29)
        Me.btnBaixar.TabIndex = 5
        Me.btnBaixar.Text = "Confirmar"
        Me.btnBaixar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaixar.UseVisualStyleBackColor = True
        '
        'btnCan
        '
        Me.btnCan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCan.Image = CType(resources.GetObject("btnCan.Image"), System.Drawing.Image)
        Me.btnCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCan.Location = New System.Drawing.Point(282, 219)
        Me.btnCan.Name = "btnCan"
        Me.btnCan.Size = New System.Drawing.Size(80, 29)
        Me.btnCan.TabIndex = 10
        Me.btnCan.TabStop = False
        Me.btnCan.Text = "  Cancelar"
        Me.btnCan.UseVisualStyleBackColor = True
        '
        'txtProposta
        '
        Me.txtProposta.Enabled = False
        Me.txtProposta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProposta.Location = New System.Drawing.Point(15, 77)
        Me.txtProposta.Name = "txtProposta"
        Me.txtProposta.Size = New System.Drawing.Size(132, 23)
        Me.txtProposta.TabIndex = 3
        Me.txtProposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Número proposta VC"
        '
        'chkOK
        '
        Me.chkOK.AutoSize = True
        Me.chkOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOK.ForeColor = System.Drawing.Color.Blue
        Me.chkOK.Location = New System.Drawing.Point(15, 21)
        Me.chkOK.Name = "chkOK"
        Me.chkOK.Size = New System.Drawing.Size(43, 17)
        Me.chkOK.TabIndex = 1
        Me.chkOK.Text = "OK"
        Me.chkOK.UseVisualStyleBackColor = True
        '
        'chkNok
        '
        Me.chkNok.AutoSize = True
        Me.chkNok.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNok.ForeColor = System.Drawing.Color.Red
        Me.chkNok.Location = New System.Drawing.Point(82, 21)
        Me.chkNok.Name = "chkNok"
        Me.chkNok.Size = New System.Drawing.Size(52, 17)
        Me.chkNok.TabIndex = 2
        Me.chkNok.Text = "NOK"
        Me.chkNok.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(175, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 117)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Clique na opção OK se você efetivou o cadastro no VC. Para isto você deve informa" & _
    "r o número da proposta VC "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(321, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 102)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Clique na opção NOK se você NÃO efetivou o cadastro no VC."
        '
        'frm_Endosso_NOK_Nivel2_Baixar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(477, 260)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkNok)
        Me.Controls.Add(Me.chkOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProposta)
        Me.Controls.Add(Me.btnCan)
        Me.Controls.Add(Me.btnBaixar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtObs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Endosso_NOK_Nivel2_Baixar"
        Me.Text = "Baixar Ligação"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBaixar As System.Windows.Forms.Button
    Friend WithEvents btnCan As System.Windows.Forms.Button
    Friend WithEvents txtProposta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkOK As System.Windows.Forms.CheckBox
    Friend WithEvents chkNok As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
