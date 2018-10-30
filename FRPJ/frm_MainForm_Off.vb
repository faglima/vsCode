Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_MainForm_Off
    Private frmSub As Form

    Private Sub frm_MainForm_Off_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim strHostName As String
            Dim strValidade As String
            Dim strFile As New StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Off.txt")

            strValidade = strFile.ReadLine
            strFile.Close()

            Me.dtValidade = CDate(strValidade)

            strHostName = System.Net.Dns.GetHostName

            Label1.Text = "Powered by IT Lab Development Team - Version " & Application.ProductVersion & " - Server: OffLine - Senha válida até: " & strValidade
            Label3.Parent = Label4
            Label3.BackColor = Color.Transparent
            Label3.Text = "|  " & Application.ProductName.ToString
            Label3.ForeColor = Color.White

            frmSub = Me
            SetSubForm(frm_Welcome_Off)



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub SetSubForm(frmS As Form)

        Try

            If Not frmS.Name = frmSub.Name Then

                If Not frmSub.Name = Me.Name Then
                    frmSub.Dispose()
                    frmSub.Close()
                End If

            End If

            Me.Panel1.Controls.Clear()
            frmS.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmS.TopLevel = False
            Me.Panel1.Controls.Add(frmS)
            frmS.Dock = DockStyle.Fill
            frmS.Show()
            Me.Label3.Text = "|  " & Application.ProductName.ToString & "  |   " & frmS.Text
            frmSub = frmS
            Me.Panel1.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub SetSubForm(frmS As frm_Welcome_Off, cls As cls_Utilities)
        Try

            If Not frmS.Name = frmSub.Name Then

                If Not frmSub.Name = Me.Name Then
                    frmSub.Dispose()
                    frmSub.Close()
                End If

            End If

            Me.Panel1.Controls.Clear()
            frmS.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmS.TopLevel = False
            Me.Panel1.Controls.Add(frmS)
            frmS.Dock = DockStyle.Fill
            frmS.ShowMe(cls)
            Me.Label3.Text = "|  " & Application.ProductName.ToString & "  |   " & frmS.Text
            frmSub = frmS

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Public Sub tsmi_Welcome_Click(sender As Object, e As EventArgs) Handles tsmi_Welcome.Click
        Try

            SetSubForm(frm_Welcome_Off)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Sair_Click(sender As Object, e As EventArgs) Handles tsmi_Sair.Click
        Try

            Application.Exit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_Sair1_Click(sender As Object, e As EventArgs) Handles tsmi_Sair1.Click
        Try

            Application.Exit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_OffLine1_Click(sender As Object, e As EventArgs) Handles tsmi_OffLine1.Click
        Try

            Dim strFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Off.txt"

            Kill(strFile)
            Application.Restart()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frm_MainForm_Off_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.Closing
        Try

            Application.Exit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_At_Ret_PF_Click(sender As Object, e As EventArgs) Handles tsmi_At_Ret_PF.Click
        Try

            SetSubForm(frm_Retencao_PF_Off)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_OffLine2_Click(sender As Object, e As EventArgs) Handles tsmi_OffLine2.Click
        Try
            frm_Off_DigitarSenha.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private dtValidade As Date 
    Public Property Validade() As Date
        Get
            Return dtValidade
        End Get
        Set(ByVal Value As Date)
            dtValidade = Value
        End Set
    End Property

    Private Sub tsmi_At_Ret_Click(sender As Object, e As EventArgs) Handles tsmi_At_Ret.Click
        Try

            SetSubForm(frm_Retencao_Off)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class