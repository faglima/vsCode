<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MainForm_Off
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MainForm_Off))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmi_Cad = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Welcome = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_Sair = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_At = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_At_Ret_PF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_At_Ret = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_OffLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_OffLine2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_OffLine1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Sair1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 568)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(1159, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Powered by IT Lab"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_Cad, Me.tsmi_At, Me.tsmi_OffLine, Me.tsmi_Sair1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 44)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1168, 26)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmi_Cad
        '
        Me.tsmi_Cad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_Welcome, Me.ToolStripSeparator5, Me.tsmi_Sair})
        Me.tsmi_Cad.Name = "tsmi_Cad"
        Me.tsmi_Cad.Size = New System.Drawing.Size(66, 22)
        Me.tsmi_Cad.Text = "Cadastro"
        '
        'tsmi_Welcome
        '
        Me.tsmi_Welcome.Image = CType(resources.GetObject("tsmi_Welcome.Image"), System.Drawing.Image)
        Me.tsmi_Welcome.Name = "tsmi_Welcome"
        Me.tsmi_Welcome.Size = New System.Drawing.Size(124, 22)
        Me.tsmi_Welcome.Text = "Welcome"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(121, 6)
        '
        'tsmi_Sair
        '
        Me.tsmi_Sair.Image = CType(resources.GetObject("tsmi_Sair.Image"), System.Drawing.Image)
        Me.tsmi_Sair.Name = "tsmi_Sair"
        Me.tsmi_Sair.Size = New System.Drawing.Size(124, 22)
        Me.tsmi_Sair.Text = "Sair"
        '
        'tsmi_At
        '
        Me.tsmi_At.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_At_Ret_PF, Me.ToolStripSeparator8, Me.tsmi_At_Ret})
        Me.tsmi_At.Name = "tsmi_At"
        Me.tsmi_At.ShortcutKeyDisplayString = ""
        Me.tsmi_At.ShowShortcutKeys = False
        Me.tsmi_At.Size = New System.Drawing.Size(89, 22)
        Me.tsmi_At.Text = "Atendimento"
        '
        'tsmi_At_Ret_PF
        '
        Me.tsmi_At_Ret_PF.Image = CType(resources.GetObject("tsmi_At_Ret_PF.Image"), System.Drawing.Image)
        Me.tsmi_At_Ret_PF.Name = "tsmi_At_Ret_PF"
        Me.tsmi_At_Ret_PF.Size = New System.Drawing.Size(152, 22)
        Me.tsmi_At_Ret_PF.Text = "Retenção PF"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(149, 6)
        '
        'tsmi_At_Ret
        '
        Me.tsmi_At_Ret.Image = CType(resources.GetObject("tsmi_At_Ret.Image"), System.Drawing.Image)
        Me.tsmi_At_Ret.Name = "tsmi_At_Ret"
        Me.tsmi_At_Ret.Size = New System.Drawing.Size(152, 22)
        Me.tsmi_At_Ret.Text = "Retenção PJ"
        '
        'tsmi_OffLine
        '
        Me.tsmi_OffLine.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_OffLine2, Me.ToolStripSeparator1, Me.tsmi_OffLine1})
        Me.tsmi_OffLine.Name = "tsmi_OffLine"
        Me.tsmi_OffLine.Size = New System.Drawing.Size(58, 22)
        Me.tsmi_OffLine.Text = "OffLine"
        '
        'tsmi_OffLine2
        '
        Me.tsmi_OffLine2.Image = CType(resources.GetObject("tsmi_OffLine2.Image"), System.Drawing.Image)
        Me.tsmi_OffLine2.Name = "tsmi_OffLine2"
        Me.tsmi_OffLine2.Size = New System.Drawing.Size(187, 22)
        Me.tsmi_OffLine2.Text = "Digitar nova senha"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'tsmi_OffLine1
        '
        Me.tsmi_OffLine1.Image = CType(resources.GetObject("tsmi_OffLine1.Image"), System.Drawing.Image)
        Me.tsmi_OffLine1.Name = "tsmi_OffLine1"
        Me.tsmi_OffLine1.Size = New System.Drawing.Size(187, 22)
        Me.tsmi_OffLine1.Text = "Sair do modo OffLine"
        '
        'tsmi_Sair1
        '
        Me.tsmi_Sair1.Name = "tsmi_Sair1"
        Me.tsmi_Sair1.Size = New System.Drawing.Size(38, 22)
        Me.tsmi_Sair1.Text = "Sair"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Location = New System.Drawing.Point(0, 73)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1168, 490)
        Me.Panel1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(170, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(768, 31)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "label 3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1168, 43)
        Me.Label4.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Red
        Me.PictureBox1.Image = Global.FRPJ.My.Resources.Resources.Logo_Santander_
        Me.PictureBox1.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(164, 38)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'frm_MainForm_Off
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1159, 596)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_MainForm_Off"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tsmi_Cad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Sair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Welcome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tsmi_At As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_At_Ret As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Sair1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_At_Ret_PF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_OffLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_OffLine1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_OffLine2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
