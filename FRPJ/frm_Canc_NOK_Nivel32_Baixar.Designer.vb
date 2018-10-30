<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Canc_NOK_Nivel32_Baixar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Canc_NOK_Nivel32_Baixar))
        Me.btnBaixar = New System.Windows.Forms.Button()
        Me.btnCan = New System.Windows.Forms.Button()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnBaixar
        '
        Me.btnBaixar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBaixar.Image = CType(resources.GetObject("btnBaixar.Image"), System.Drawing.Image)
        Me.btnBaixar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaixar.Location = New System.Drawing.Point(331, 223)
        Me.btnBaixar.Name = "btnBaixar"
        Me.btnBaixar.Size = New System.Drawing.Size(80, 29)
        Me.btnBaixar.TabIndex = 2
        Me.btnBaixar.Text = "Confirmar"
        Me.btnBaixar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaixar.UseVisualStyleBackColor = True
        '
        'btnCan
        '
        Me.btnCan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCan.Image = CType(resources.GetObject("btnCan.Image"), System.Drawing.Image)
        Me.btnCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCan.Location = New System.Drawing.Point(245, 223)
        Me.btnCan.Name = "btnCan"
        Me.btnCan.Size = New System.Drawing.Size(80, 29)
        Me.btnCan.TabIndex = 3
        Me.btnCan.TabStop = False
        Me.btnCan.Text = "  Cancelar"
        Me.btnCan.UseVisualStyleBackColor = True
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(12, 37)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(399, 162)
        Me.txtObs.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Informe a Solução Final e Contato:"
        '
        'frm_Canc_NOK_Nivel32_Baixar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(437, 267)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.btnCan)
        Me.Controls.Add(Me.btnBaixar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Canc_NOK_Nivel32_Baixar"
        Me.Text = "Baixar Ligação"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBaixar As System.Windows.Forms.Button
    Friend WithEvents btnCan As System.Windows.Forms.Button
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
