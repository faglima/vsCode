<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Offline_Importar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Offline_Importar))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtProcess = New System.Windows.Forms.TextBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.AutoSize = True
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(14, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 27)
        Me.Button1.TabIndex = 103
        Me.Button1.TabStop = False
        Me.Button1.Text = "Importar e Processar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtProcess
        '
        Me.txtProcess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcess.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcess.Location = New System.Drawing.Point(14, 65)
        Me.txtProcess.Multiline = True
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.ReadOnly = True
        Me.txtProcess.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProcess.Size = New System.Drawing.Size(675, 319)
        Me.txtProcess.TabIndex = 107
        Me.txtProcess.WordWrap = False
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.Location = New System.Drawing.Point(14, 37)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(675, 22)
        Me.txtPath.TabIndex = 108
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Diretório Padrão"
        '
        'btnLimpar
        '
        Me.btnLimpar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimpar.AutoSize = True
        Me.btnLimpar.BackColor = System.Drawing.Color.LightGray
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLimpar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpar.Location = New System.Drawing.Point(167, 398)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(75, 27)
        Me.btnLimpar.TabIndex = 110
        Me.btnLimpar.Text = "Limpar"
        Me.btnLimpar.UseVisualStyleBackColor = False
        '
        'frm_Offline_Importar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(712, 437)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.txtProcess)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frm_Offline_Importar"
        Me.Text = "Importar Arquivos Offline"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLimpar As System.Windows.Forms.Button
End Class
