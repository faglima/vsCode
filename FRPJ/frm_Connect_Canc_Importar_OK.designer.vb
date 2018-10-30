<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Connect_Canc_Importar_OK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Connect_Canc_Importar_OK))
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.btnImp = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
        Me.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelect.Location = New System.Drawing.Point(33, 32)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(184, 30)
        Me.btnSelect.TabIndex = 101
        Me.btnSelect.TabStop = False
        Me.btnSelect.Text = "Selecionar Arquivo Retorno OK"
        Me.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Enabled = False
        Me.txtFile.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFile.ForeColor = System.Drawing.Color.Black
        Me.txtFile.Location = New System.Drawing.Point(33, 68)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(583, 23)
        Me.txtFile.TabIndex = 102
        Me.txtFile.TabStop = False
        Me.txtFile.WordWrap = False
        '
        'btnImp
        '
        Me.btnImp.Image = CType(resources.GetObject("btnImp.Image"), System.Drawing.Image)
        Me.btnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImp.Location = New System.Drawing.Point(485, 97)
        Me.btnImp.Name = "btnImp"
        Me.btnImp.Size = New System.Drawing.Size(131, 30)
        Me.btnImp.TabIndex = 103
        Me.btnImp.TabStop = False
        Me.btnImp.Text = "Importar e Processar"
        Me.btnImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImp.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frm_Connect_Canc_Importar_OK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(872, 373)
        Me.Controls.Add(Me.btnImp)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.txtFile)
        Me.Name = "frm_Connect_Canc_Importar_OK"
        Me.Text = "Importar Retorno Connect OK"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents btnImp As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
