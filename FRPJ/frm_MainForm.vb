Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports System.DateTime
Public Class frm_MainForm
    Private frmSub As Form

    Private Sub frm_MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim cls As New cls_SqlConnect
            Dim clsUtility As New cls_Utilities
            Dim strReturnUser As String
            Dim strHostName As String
            Dim strEnvironment As String
            Dim strNomePerfil As String
            Dim strFile As String
            Dim strPathDestino As String = ""
            Dim strServer As String

            My.Settings.Ambiente = cls_SqlConnect.strAmbiente

            strEnvironment = My.Settings.Ambiente

            If cls.fTestConn(cls_SqlConnect.TipoConn.Sql) Then

                strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\" & Environment.UserName & "_PF.txt"
                strPathDestino = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_OffLine'") & "\" & Environment.UserName & "_PF_" & Format(Now(), "ddMMyyyyHHmmss") & ".txt"
                If File.Exists(strFile) Then
                    File.Copy(strFile, strPathDestino)
                    Kill(strFile)
                End If

                strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\" & Environment.UserName & "_PJ.txt"
                strPathDestino = cls.Exec_Command_Scalar("select ValorParametro from tsys_Parametro where NomeParametro='Path_OffLine'") & "\" & Environment.UserName & "_PJ_" & Format(Now(), "ddMMyyyyHHmmss") & ".txt"
                If File.Exists(strFile) Then
                    File.Copy(strFile, strPathDestino)
                    Kill(strFile)
                End If

                With clsUtility
                    .UserLogin = UCase(Environment.UserName)
                    strReturnUser = UCase(cls.Exec_Command_Scalar("select login from tbl_usuario where login='" & .UserLogin & "'"))
                    .UserName = cls.Exec_Command_Scalar("select NomeUsuario from tbl_usuario where login='" & .UserLogin & "'")
                    .Perfil = cls.Exec_Command_Scalar("select PerfilUsuario from tbl_usuario where login='" & .UserLogin & "'")
                    strNomePerfil = cls.Exec_Command_Scalar("select PerfilUsuario from tbl_Usuario_Perfil where CodId_Perfil_Pk='" & .Perfil & "'")

                    Me.Tag = .Perfil
                    .Release = Application.ProductVersion

                    If .UserLogin <> strReturnUser Then
                        MsgBox("Usuário não Cadastrado!" & vbCrLf & "Usuário Local: " & .UserLogin & vbCrLf & "Usuário Sql: " & strReturnUser, vbCritical, "Atenção")
                        Me.Close()
                    End If

                    'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

                    strHostName = System.Net.Dns.GetHostName

                    cls.Exec_Command_NQ("EXEC FRPJ_SP_INSERT_RELEASE @Release=" & CLng(Replace(.Release, ".", "")) & ",@HostName='" & strHostName & "'")

                    Using Conn As New SqlConnection(cls.Open_Db(1))

                        Conn.Open()
                        strServer = Conn.DataSource
                        Conn.Close()
                        Conn.Dispose()

                    End Using


                    Label1.Text = "Powered by IT Lab Development Team - Version " & .Release & " - Server: " & strServer & " - Ambiente: " & strEnvironment & " - Perfil Usuário: " & strNomePerfil
                    Label3.Parent = Label4
                    Label3.BackColor = Color.Transparent
                    Label3.Text = "|  " & Application.ProductName.ToString
                    Label3.ForeColor = Color.White

                    frmSub = Me
                    SetSubForm(frm_Welcome, clsUtility)
                    SetPerfil(.Perfil)

                End With
            Else
                strHostName = System.Net.Dns.GetHostName

                Label1.Text = "Powered by IT Lab Development Team - Version " & Application.ProductVersion & " - Server: OffLine - Ambiente: " & strEnvironment & " - Perfil Usuário: OffLine"
                Label3.Parent = Label4
                Label3.BackColor = Color.Transparent
                Label3.Text = "|  " & Application.ProductName.ToString
                Label3.ForeColor = Color.White
                frmSub = Me
                SetSubForm(frm_Welcome, clsUtility)
                SetPerfil(0)
            End If

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
    Sub SetSubForm(frmS As frm_Welcome, cls As cls_Utilities)
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


    Public Sub tsmi_Welcome_Click(sender As Object, e As EventArgs) Handles tsmi_Cad6.Click
        Try

            Dim clsUtility As New cls_Utilities
            Dim cls As New cls_SqlConnect

            clsUtility.UserName = cls.Exec_Command_Scalar("select NomeUsuario from tbl_usuario where login='" & Environment.UserName & "'")
            SetSubForm(frm_Welcome, clsUtility)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Usuarios_Click(sender As Object, e As EventArgs) Handles tsmi_Cad3.Click
        Try

            SetSubForm(frm_Usuarios)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsmi_Sair_Click(sender As Object, e As EventArgs) Handles tsmi_Cad7.Click
        Try

            Application.Exit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsmi_Welcome1_Click(sender As Object, e As EventArgs)

        Try

            Dim clsUtility As New cls_Utilities
            Dim cls As New cls_SqlConnect

            clsUtility.UserName = cls.Exec_Command_Scalar("select NomeUsuario from tbl_usuario where login='" & Environment.UserName & "'")
            SetSubForm(frm_Welcome, clsUtility)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsmi_Sair1_Click(sender As Object, e As EventArgs)

        Try

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsmi_Param_Click(sender As Object, e As EventArgs) Handles tsmi_Cad1.Click
        Try

            SetSubForm(frm_Param)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_EPS_Click(sender As Object, e As EventArgs) Handles tsmi_Cad2.Click
        Try

            SetSubForm(frm_EPS)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_GrupoProduto_Click(sender As Object, e As EventArgs) Handles tsmi_GrupoProduto.Click
        Try

            SetSubForm(frm_Produto_Grupo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Produtos_Click(sender As Object, e As EventArgs) Handles tsmi_Produtos.Click
        Try

            SetSubForm(frm_Produto)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_TipoRet_Click(sender As Object, e As EventArgs) Handles tsmi_TipoRet.Click
        Try

            SetSubForm(frm_Tipo_Retencao)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Categoria_Click(sender As Object, e As EventArgs) Handles tsmi_Categoria.Click
        Try

            SetSubForm(frm_Produto_Categoria)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Segmentos_Click(sender As Object, e As EventArgs) Handles tsmi_Segmentos.Click
        Try

            SetSubForm(frm_Produto_Segmento)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Tickets_Click(sender As Object, e As EventArgs) Handles tsmi_Tickets.Click
        Try

            SetSubForm(frm_Produto_Tickets)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cargos_Click(sender As Object, e As EventArgs) Handles tsmi_Cargos.Click
        Try

            SetSubForm(frm_Cargos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_C_Local_Click(sender As Object, e As EventArgs) Handles tsmi_C_Local.Click
        Try

            SetSubForm(frm_Canc_Local)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_C_Codigo_Click(sender As Object, e As EventArgs) Handles tsmi_C_Codigo.Click
        Try

            SetSubForm(frm_Canc_Codigos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_C_Data_Click(sender As Object, e As EventArgs) Handles tsmi_C_Data.Click
        Try

            SetSubForm(frm_Canc_Data)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_C_Tipo_Click(sender As Object, e As EventArgs) Handles tsmi_C_Tipo.Click
        Try

            SetSubForm(frm_Canc_Tipos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Motivos_Desfecho_Click(sender As Object, e As EventArgs) Handles tsmi_Motivos_Desfecho.Click
        Try

            SetSubForm(frm_Motivo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Grupos_Desfecho_Click(sender As Object, e As EventArgs) Handles tsmi_Grupos_Desfecho.Click
        Try

            SetSubForm(frm_Desfecho_Grupo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_At_Ret_Click(sender As Object, e As EventArgs) Handles tsmi_At3.Click
        Try
            If Me.Tag = 13 Or Me.Tag = 12 Then
                SetSubForm(frm_Retencao_PJ_SAC)
            Else
                SetSubForm(frm_Retencao_PJ)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Sair1_Click_1(sender As Object, e As EventArgs) Handles tsmi_Sair1.Click
        Try

            Application.Exit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Geral_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Geral.Click
        Try

            SetSubForm(frm_rpt_Geral)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsmi_rpt_Protocolo_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Protocolo.Click
        Try

            SetSubForm(frm_rpt_Protocolo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_Enviar_Click(sender As Object, e As EventArgs) Handles tsmi_Canc2.Click
        Try
            frm_Canc_Enviar_Robo_VC.Tag = 2
            SetSubForm(frm_Canc_Enviar_Robo_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_Ag_Rector_Click(sender As Object, e As EventArgs) Handles tsmi_Canc3.Click
        Try

            SetSubForm(frm_Canc_Pend_Robo_Rector)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_Ag_Vc_Click(sender As Object, e As EventArgs) Handles tsmi_Canc4.Click
        Try

            SetSubForm(frm_Canc_Pend_Robo_Vc)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_OK_Click(sender As Object, e As EventArgs) Handles tsmi_Canc5.Click
        Try

            SetSubForm(frm_Canc_OK_Robo_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_N2_Pend_Click(sender As Object, e As EventArgs) Handles tsmi_N21.Click
        Try

            SetSubForm(frm_Canc_NOK_Nivel2)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N2_Tratadas_Click(sender As Object, e As EventArgs) Handles tsmi_N26.Click
        Try

            SetSubForm(frm_Canc_OK_Nivel2)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_EnviarVC_Click(sender As Object, e As EventArgs)
        Try
            frm_Canc_Enviar_Robo_RECTOR.Tag = 2
            SetSubForm(frm_Canc_Enviar_Robo_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_EnviarRECTOR_Click(sender As Object, e As EventArgs)
        Try
            frm_Canc_Enviar_Robo_RECTOR.Tag = 1
            SetSubForm(frm_Canc_Enviar_Robo_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_Ag_Vc1_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_Pend_Robo_Vc)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_Ag_Rector1_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_Pend_Robo_Rector)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_OK_VC_Click(sender As Object, e As EventArgs)
        Try

            frm_Canc_OK_Robo_RECTOR.Tag = 2
            SetSubForm(frm_Canc_OK_Robo_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_OK_RECTOR_Click(sender As Object, e As EventArgs)
        Try

            frm_Canc_OK_Robo_RECTOR.Tag = 1
            SetSubForm(frm_Canc_OK_Robo_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_NOK_VC1_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_NOK_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_NOK_RECTOR1_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_NOK_Rector)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Alcada_RECTOR_Click(sender As Object, e As EventArgs) Handles tsmi_Alcada_RECTOR.Click
        Try

            SetSubForm(frm_Canc_NOK_Alcada_Rector)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Alcada_VC_Click(sender As Object, e As EventArgs) Handles tsmi_Alcada_VC.Click
        Try

            SetSubForm(frm_Canc_NOK_Alcada_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_NC_Enviar_Click(sender As Object, e As EventArgs) Handles tsmi_NC1.Click
        Try

            SetSubForm(frm_Canc_OK_Enviar_CM)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_NC_Enviados_Click(sender As Object, e As EventArgs) Handles tsmi_NC2.Click
        Try

            SetSubForm(frm_Canc_OK_Enviado_CM)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_GrupoProduto_PF_Click(sender As Object, e As EventArgs) Handles tsmi_GrupoProduto_PF.Click
        Try

            SetSubForm(frm_Produto_Grupo_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_TipoRet_PF_Click(sender As Object, e As EventArgs) Handles tsmi_TipoRet_PF.Click
        Try

            SetSubForm(frm_Tipo_Retencao_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Categoria_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Categoria_PF.Click
        Try

            SetSubForm(frm_Produto_Categoria_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Segmentos_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Segmentos_PF.Click
        Try

            SetSubForm(frm_Produto_Segmento_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cancelamento_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Cancelamento_PF.Click
        Try

            SetSubForm(frm_Canc_Local_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_C_Codigo_PF_Click(sender As Object, e As EventArgs) Handles tsmi_C_Codigo_PF.Click
        Try

            SetSubForm(frm_Canc_Codigos_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_C_Data_PF_Click(sender As Object, e As EventArgs) Handles tsmi_C_Data_PF.Click
        Try

            SetSubForm(frm_Canc_Data_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_C_Tipo_PF_Click(sender As Object, e As EventArgs) Handles tsmi_C_Tipo_PF.Click
        Try

            SetSubForm(frm_Canc_Tipos_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Motivos_Desfecho_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Motivos_Desfecho_PF.Click
        Try

            SetSubForm(frm_Motivo_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Grupos_Desfecho_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Grupos_Desfecho_PF.Click
        Try

            SetSubForm(frm_Desfecho_Grupo_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsmi_Canc_NOK_VC_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_NOK_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_Canc_NOK_RECTOR_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_NOK_Rector)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_Alcada_RECTOR_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Alcada_RECTOR_PF.Click
        Try

            SetSubForm(frm_Canc_NOK_Alcada_Rector_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Alcada_VC_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Alcada_VC_PF.Click
        Try

            SetSubForm(frm_Canc_NOK_Alcada_VC_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_At_Ret_PF_Click(sender As Object, e As EventArgs) Handles tsmi_At1.Click
        Try
            If Me.Tag = 13 Or Me.Tag = 12 Then
                SetSubForm(frm_Retencao_PF_SAC)
            Else
                SetSubForm(frm_Retencao_PF)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub tsmi_rpt_Geral_PF_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Geral_PF.Click
        Try

            SetSubForm(frm_rpt_Geral_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Protocolo_PF_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Protocolo_PF.Click
        Try

            SetSubForm(frm_rpt_Protocolo_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Produtos_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Produtos_PF.Click
        Try

            SetSubForm(frm_Produto_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsmi_rptDiarioRector_Click(sender As Object, e As EventArgs) Handles tsmi_rptDiarioRector.Click
        Try

            SetSubForm(frm_rpt_Canc_Rector_Diario)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rptMensalRector_Click(sender As Object, e As EventArgs) Handles tsmi_rptMensalRector.Click
        Try

            SetSubForm(frm_rpt_Canc_Rector_Mensal)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsmi_Tickets_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Tickets_PF.Click
        SetSubForm(frm_Planos)
    End Sub

    Private Sub tsmi_N2_Canc_Click(sender As Object, e As EventArgs) Handles tsmi_N25.Click
        Try
            SetSubForm(frm_Canc_NEfetuado_Nivel2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao_NOK_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao11.Click
        Try
            SetSubForm(frm_Venda_NOK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InconsistênciasDeEmissãoPendentesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel11.Click
        Try
            SetSubForm(frm_Venda_NOK_Nivel1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsmi_Endosso_NOK_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao12.Click
        Try
            SetSubForm(frm_Endosso_NOK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_EnviarREC_Click(sender As Object, e As EventArgs) Handles tsmi_Canc1.Click
        Try

            frm_Canc_Enviar_Robo_RECTOR.Tag = 1
            SetSubForm(frm_Canc_Enviar_Robo_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao_Robo_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao1.Click

        Try

            SetSubForm(frm_Venda_Enviar_Robo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao_Proc_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao5.Click
        Try

            SetSubForm(frm_Venda_Robo_Pendente)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao_OK_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao8.Click
        Try

            SetSubForm(frm_Venda_OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InconsistênciasDeEmissãoTratadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel12.Click
        Try

            SetSubForm(frm_Venda_OK_Nivel1)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tsmi_Canc_NOK_RECTOR_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Canc7.Click
        Try

            SetSubForm(frm_Canc_NOK_Rector)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_NOK_VC_PF_Click(sender As Object, e As EventArgs) Handles tsmi_Canc8.Click
        Try

            SetSubForm(frm_Canc_NOK_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_Nivel3_Nok_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel3_Nok.Click
        Try

            SetSubForm(frm_Canc_NOK_Nivel3)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_Robo_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao2.Click
        Try

            SetSubForm(frm_Endosso_Enviar_Robo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_Proc_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao6.Click
        Try

            SetSubForm(frm_Endosso_Robo_Pendente)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_OK_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao9.Click
        Try

            SetSubForm(frm_Endosso_OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_Nok_N2_Click(sender As Object, e As EventArgs) Handles tsmi_N22.Click
        Try
            SetSubForm(frm_Endosso_NOK_Nivel2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_Nok_N2_OK_Click(sender As Object, e As EventArgs) Handles tsmi_N27.Click
        Try
            SetSubForm(frm_Endosso_OK_Nivel2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_RoboCC_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao3.Click
        Try
            SetSubForm(frm_EndossoCC_Enviar_Robo)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_ProcCC_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao7.Click
        Try
            SetSubForm(frm_EndossoCC_Robo_Pendente)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_OKCC_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao10.Click
        Try
            SetSubForm(frm_EndossoCC_OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_NOKCC_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao13.Click
        Try
            SetSubForm(frm_EndossoCC_NOK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_Nok_N2CC_Click(sender As Object, e As EventArgs) Handles tsmi_N23.Click
        Try
            SetSubForm(frm_EndossoCC_NOK_Nivel2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Endosso_Nok_N2_OKCC_Click(sender As Object, e As EventArgs) Handles tsmi_N28.Click
        Try
            SetSubForm(frm_EndossoCC_OK_Nivel2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_PEmiss1_Click(sender As Object, e As EventArgs) Handles tsmi_Canc_PEmiss1.Click

        Try
            SetSubForm(frm_Canc_NOK_RECTOR_PE)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsmi_Canc_PEmiss2_Click(sender As Object, e As EventArgs) Handles tsmi_Canc_PEmiss2.Click
        Try
            SetSubForm(frm_Canc_NOK_RECTOR_PE_VC90_NOK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc_PEmiss3_Click(sender As Object, e As EventArgs) Handles tsmi_Canc_PEmiss3.Click
        Try
            frm_VC90_Importar.Tag = "PE"
            SetSubForm(frm_VC90_Importar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Historico_PF_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Historico_PF.Click
        Try
            SetSubForm(frm_rpt_Hist_Protocolo_PF)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Ferrari1_Click(sender As Object, e As EventArgs) Handles tsmi_Ferrari1.Click
        Try
            SetSubForm(frm_Ferrari_Enviar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Ferrari2_Click(sender As Object, e As EventArgs) Handles tsmi_Ferrari2.Click
        Try
            SetSubForm(frm_Ferrari_Enviado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetPerfil(Perfil As Integer)
        Try
            Select Case Perfil
                Case Is = -1 'Master/Gestor
                    tsmi_Cad20.Visible = True
                    tsmi_Tsql.Visible = True
                    tsmi_Cad.Visible = True
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = True
                    tsmi_At6.Visible = True
                    tsml_At0.Visible = True
                    tsmi_rpt_AnlPJ.Visible = True
                    tsmi_rpt_AnlPF.Visible = True
                    tsmi_Emissao.Visible = True
                    tsmi_Canc.Visible = True
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = True
                    tsmi_Nivel1.Visible = True
                    tsmi_N2.Visible = True
                    tsmi_Nivel3.Visible = True
                    tsmi_Sair1.Visible = True
                    tsmi_Off.Visible = True
                    tsmi_N_Em.Visible = True
                    tsmi_Cad9.Visible = True
                    tsmi_Cad10.Visible = True
                    tsmi_Canc0.Visible = True
                Case Is = 0 'Master/Gestor
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Cad.Visible = False
                    tsmi_At.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = False
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_Off.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Canc0.Visible = False
                Case Is = 1 'Master/Gestor
                    tsmi_Cad20.Visible = True
                    tsmi_Tsql.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = True
                    tsmi_At6.Visible = True
                    tsml_At0.Visible = True
                    tsmi_rpt_AnlPJ.Visible = True
                    tsmi_rpt_AnlPF.Visible = True
                    tsmi_Emissao.Visible = True
                    tsmi_Canc.Visible = True
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = True
                    tsmi_N2.Visible = True
                    tsmi_Nivel3.Visible = True
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Canc0.Visible = True
                Case Is = 2 'Seguradora Master
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = True
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = True
                    tsmi_Canc63.Visible = False
                    tsmi_Canc1.Visible = True
                    tsmi_Canc2.Visible = False
                    tsmi_Canc3.Visible = True
                    tsmi_Canc4.Visible = False
                    tsmi_Canc5.Visible = True
                    tsmi_Canc6.Visible = False
                    tsmi_Canc7.Visible = True
                    tsmi_Canc8.Visible = False
                    tsmi_Canc9.Visible = True
                    tsmi_Canc10.Visible = True
                    tsmi_Canc11.Visible = False
                    tsmi_Canc13.Visible = False
                    tsmi_Canc14.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = True
                    tsmi_N21.Visible = True
                    tsmi_N22.Visible = False
                    tsmi_N23.Visible = False
                    tsmi_N24.Visible = True
                    tsmi_N25.Visible = True
                    tsmi_N26.Visible = True
                    tsmi_N27.Visible = False
                    tsmi_N28.Visible = False
                    tsmi_Nivel3.Visible = True
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = True
                    tsmi_Cad10.Visible = True
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 3 'Corretora Master
                    tsmi_Cad20.Visible = True
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = True
                    tsmi_Cad12.Visible = True
                    tsmi_Cad13.Visible = True
                    tsmi_CadL1.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = True
                    tsmi_At6.Visible = True
                    tsml_At0.Visible = True
                    tsmi_rpt_AnlPJ.Visible = True
                    tsmi_rpt_AnlPF.Visible = True
                    tsmi_Emissao.Visible = True
                    tsmi_Canc.Visible = True
                    tsmi_Canc63.Visible = True
                    tsmi_Canc1.Visible = False
                    tsmi_Canc2.Visible = True
                    tsmi_Canc3.Visible = False
                    tsmi_Canc4.Visible = True
                    tsmi_Canc5.Visible = False
                    tsmi_Canc6.Visible = True
                    tsmi_Canc7.Visible = False
                    tsmi_Canc8.Visible = True
                    tsmi_Canc9.Visible = False
                    tsmi_Canc10.Visible = False
                    tsmi_Canc11.Visible = True
                    tsmi_Canc13.Visible = True
                    tsmi_Canc14.Visible = True
                    tsmi_CancL5.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = True
                    tsmi_N2.Visible = True
                    tsmi_N21.Visible = True
                    tsmi_N22.Visible = True
                    tsmi_N23.Visible = True
                    tsmi_N24.Visible = True
                    tsmi_N25.Visible = True
                    tsmi_N26.Visible = True
                    tsmi_N27.Visible = True
                    tsmi_N28.Visible = True
                    tsmi_Nivel3.Visible = True
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = True
                    tsmi_Cad9.Visible = True
                    tsmi_Cad10.Visible = True
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = True
                Case Is = 4, 5 'EPS coordenador/supervisor
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = True
                    tsmi_At6.Visible = True
                    tsml_At0.Visible = True
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = True
                    tsmi_N2.Visible = False
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 6 'EPS operador
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = False
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 7 'Seguradora Op
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = True
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = True
                    tsmi_Canc63.Visible = False
                    tsmi_Canc1.Visible = True
                    tsmi_Canc2.Visible = False
                    tsmi_Canc3.Visible = True
                    tsmi_Canc4.Visible = False
                    tsmi_Canc5.Visible = True
                    tsmi_Canc6.Visible = False
                    tsmi_Canc7.Visible = True
                    tsmi_Canc8.Visible = False
                    tsmi_Canc9.Visible = True
                    tsmi_Canc10.Visible = True
                    tsmi_Canc11.Visible = False
                    tsmi_Canc13.Visible = False
                    tsmi_Canc14.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = True
                    tsmi_N21.Visible = True
                    tsmi_N22.Visible = False
                    tsmi_N23.Visible = False
                    tsmi_N24.Visible = True
                    tsmi_N25.Visible = True
                    tsmi_N26.Visible = True
                    tsmi_N27.Visible = False
                    tsmi_N28.Visible = False
                    tsmi_Nivel3.Visible = True
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 8 'Corretora Op
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_Emissao.Visible = True
                    tsmi_Canc.Visible = True
                    tsmi_Canc1.Visible = False
                    tsmi_Canc63.Visible = True
                    tsmi_Canc2.Visible = True
                    tsmi_Canc3.Visible = False
                    tsmi_Canc4.Visible = True
                    tsmi_Canc5.Visible = False
                    tsmi_Canc6.Visible = True
                    tsmi_Canc7.Visible = False
                    tsmi_Canc8.Visible = True
                    tsmi_Canc9.Visible = False
                    tsmi_Canc10.Visible = False
                    tsmi_Canc11.Visible = True
                    tsmi_Canc13.Visible = True
                    tsmi_Canc14.Visible = True
                    tsmi_CancL5.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = True
                    tsmi_N2.Visible = True
                    tsmi_N21.Visible = True
                    tsmi_N22.Visible = True
                    tsmi_N23.Visible = True
                    tsmi_N24.Visible = True
                    tsmi_N25.Visible = True
                    tsmi_N26.Visible = True
                    tsmi_N27.Visible = True
                    tsmi_N28.Visible = True
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = True
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 9 'nível 1  = EPS coordenador/supervisor
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = True
                    tsmi_At6.Visible = True
                    tsml_At0.Visible = True
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = True
                    tsmi_N2.Visible = False
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 10 'nivel2
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At.Text = "Consulta"
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_At1.Visible = False
                    tsmi_At3.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = True
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 11 'nivel3
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At.Text = "Consulta"
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_At1.Visible = False
                    tsmi_At3.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = False
                    tsmi_Nivel3.Visible = True
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 12 'SAC 1º Nível
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = False
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
                Case Is = 13 'SAC 2º Nível
                    tsmi_Cad20.Visible = False
                    tsmi_Tsql.Visible = False
                    tsmi_Canc0.Visible = False
                    tsmi_Cad.Visible = True
                    tsmi_Cad1.Visible = False
                    tsmi_Cad11.Visible = False
                    tsmi_Cad12.Visible = False
                    tsmi_Cad13.Visible = False
                    tsmi_Cad14.Visible = False
                    tsmi_CadL1.Visible = False
                    tsmi_Cad2.Visible = False
                    tsmi_Cad3.Visible = False
                    tsmi_CadL2.Visible = False
                    tsmi_Cad4.Visible = False
                    tsmi_CadL3.Visible = False
                    tsmi_Cad5.Visible = False
                    tsmi_CadL4.Visible = False
                    tsmi_Cad6.Visible = True
                    tsmi_Cad7.Visible = True
                    tsmi_Cad8.Visible = False
                    tsmi_At.Visible = True
                    tsmi_At5.Visible = False
                    tsmi_At6.Visible = False
                    tsml_At0.Visible = False
                    'tsmi_At.Text = "Consulta"
                    'tsmi_At1.Visible = False --solicitado por vanessa em 29/06/2017
                    'tsmi_At3.Visible = False --solicitado por vanessa em 29/06/2017
                    tsmi_Emissao.Visible = False
                    tsmi_Canc.Visible = False
                    tsmi_Alcada.Visible = False
                    tsmi_NC.Visible = False
                    tsmi_Nivel1.Visible = False
                    tsmi_N2.Visible = True
                    tsmi_N22.Visible = False
                    tsmi_N23.Visible = False
                    tsmi_N27.Visible = False
                    tsmi_N28.Visible = False
                    tsmi_Nivel3.Visible = False
                    tsmi_Sair1.Visible = True
                    tsmi_N_Em.Visible = False
                    tsmi_Cad9.Visible = False
                    tsmi_Cad10.Visible = False
                    tsmi_Off.Visible = True
                    tsmi_Off2.Visible = False
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Canc_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Canc.Click
        Try
            SetSubForm(frm_rpt_Operacao_Cancelamento_Diario)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Canc_M_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Canc_M.Click
        Try
            SetSubForm(frm_rpt_Operacao_Cancelamento_Mensal)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RelatóriosEndossoCartãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao16.Click
        Try
            SetSubForm(frm_Under_Construction)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao141_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao141.Click
        Try
            SetSubForm(frm_rpt_Operacao_Emissao_Diario)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao142_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao142.Click
        Try
            SetSubForm(frm_rpt_Operacao_Emissao_Mensal)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tsmi_Emissao151_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao151.Click
        Try
            SetSubForm(frm_rpt_Operacao_Endosso_Diario)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao152_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao152.Click
        Try
            SetSubForm(frm_rpt_Operacao_Endosso_Mensal)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CancelamentoVsCMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelamentoVsCMToolStripMenuItem.Click
        Try

            SetSubForm(frm_Canc_Vs_Compromisso)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   

    Private Sub tsmi_Cad81_Click(sender As Object, e As EventArgs) Handles tsmi_Cad81.Click
        Try

            SetSubForm(frm_Alertas_Importar)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
    Private Sub tsmi_Cad82_Click(sender As Object, e As EventArgs) Handles tsmi_Cad82.Click
        Try

            SetSubForm(frm_Alertas)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.Closing
        Try
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Off1_Click(sender As Object, e As EventArgs) Handles tsmi_Off1.Click
        Try
            frm_Off_DigitarSenha.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad9_Click(sender As Object, e As EventArgs) Handles tsmi_Cad9.Click
        Try

            SetSubForm(frm_Bancos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao143.Click
        Try

            SetSubForm(frm_rpt_Sla_Emissao)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Emissao153_Click(sender As Object, e As EventArgs) Handles tsmi_Emissao153.Click
        Try

            SetSubForm(frm_rpt_Sla_Endosso)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Sla_Canc_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Sla_Canc.Click
        Try

            SetSubForm(frm_rpt_Sla_Cancelamento)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad101_Click(sender As Object, e As EventArgs) Handles tsmi_Cad101.Click
        Try

            SetSubForm(frm_Agencias_Importar)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N_Em1_Click(sender As Object, e As EventArgs) Handles tsmi_N_Em1.Click
        Try

            SetSubForm(frm_N_Em_Inibidos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N_Em21_Click(sender As Object, e As EventArgs) Handles tsmi_N_Em21.Click
        Try

            SetSubForm(frm_N_Em_N_Inibidos_Encontrados)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N_Em22_Click(sender As Object, e As EventArgs) Handles tsmi_N_Em22.Click
        Try

            SetSubForm(frm_N_Em_N_Inibidos_N_Encontrados)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N29_Click(sender As Object, e As EventArgs) Handles tsmi_N29.Click
        Try

            SetSubForm(frm_Canc_VendaNREc_Nivel2_Ok)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N30_Click(sender As Object, e As EventArgs) Handles tsmi_N30.Click
        Try

            SetSubForm(frm_Canc_NEfetuado_Nivel2_Ok)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles tsmi_rpt_AnlPF.Click
        Try

            SetSubForm(frm_rpt_Analitico_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_AnlPJ.Click
        Try

            SetSubForm(frm_rpt_Analitico_PJ)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N_Em23_Click(sender As Object, e As EventArgs) Handles tsmi_N_Em23.Click
        Try

            SetSubForm(frm_N_Em_N_Inibidos_Encontrados_VCAL)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Off2_Click(sender As Object, e As EventArgs) Handles tsmi_Off2.Click
        Try

            SetSubForm(frm_Offline_Importar)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel321_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel321.Click
        Try

            SetSubForm(frm_Canc_OK_Nivel3)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel322_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel322.Click
        Try

            SetSubForm(frm_Canc_OK_Nivel32)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel31_Nok_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel31_Nok.Click
        Try

            frm_Canc_NOK_Nivel32.Tag = "N3"
            SetSubForm(frm_Canc_NOK_Nivel32)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PendentesDeAnáliseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmi_N241.Click
        Try
            SetSubForm(frm_Canc_VendaNREc_Nivel2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N242_Click(sender As Object, e As EventArgs) Handles tsmi_N242.Click
        Try

            frm_Canc_NOK_Nivel3.Tag = "N2"
            SetSubForm(frm_Canc_NOK_Nivel3)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N243_Click(sender As Object, e As EventArgs) Handles tsmi_N243.Click
        Try

            frm_Canc_OK_Nivel3.Tag = "N2"
            SetSubForm(frm_Canc_OK_Nivel3)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N244_Click(sender As Object, e As EventArgs) Handles tsmi_N244.Click
        Try

            SetSubForm(frm_Canc_NOK_Nivel32)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_N245_Click(sender As Object, e As EventArgs) Handles tsmi_N245.Click
        Try

            frm_Canc_OK_Nivel32.Tag = "N2"
            SetSubForm(frm_Canc_OK_Nivel32)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc61_Click(sender As Object, e As EventArgs) Handles tsmi_Canc61.Click
        Try

            SetSubForm(frm_Canc_OK_Robo_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc62_Click(sender As Object, e As EventArgs) Handles tsmi_Canc62.Click
        Try
            frm_VC90_Importar.Tag = "VC"
            SetSubForm(frm_VC90_Importar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc63_Click(sender As Object, e As EventArgs)
        Try

            SetSubForm(frm_Canc_OK_Robo_VC_Rector_OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad102_Click(sender As Object, e As EventArgs) Handles tsmi_Cad102.Click
        Try

            SetSubForm(frm_Agencias_Consulta)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad103_Click(sender As Object, e As EventArgs) Handles tsmi_Cad103.Click
        Try

            SetSubForm(frm_Agencias_NPermitidos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc13_Click(sender As Object, e As EventArgs) Handles tsmi_Canc13.Click
        Try

            SetSubForm(frm_Canc_Enviar_Robo_Cheque)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc14_Click(sender As Object, e As EventArgs) Handles tsmi_Canc14.Click
        Try

            SetSubForm(frm_Canc_Pend_Robo_Cheque)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_rpt_Canc_OK_Click(sender As Object, e As EventArgs) Handles tsmi_rpt_Canc_OK.Click
        Try

            SetSubForm(frm_rpt_Cancelamento)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmi_Cad12.Click
        Try

            SetSubForm(frm_Dash)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad11_Click(sender As Object, e As EventArgs) Handles tsmi_Cad11.Click
        Try

            SetSubForm(frm_Retencao_Metas)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc63_Click_1(sender As Object, e As EventArgs) Handles tsmi_Canc63.Click
        Try

            SetSubForm(frm_Canc_OK_Robo_VC_Rector_OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel13_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel13.Click
        Try

            SetSubForm(frm_Canc_NEfetuado_Nivel1)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel14_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel14.Click
        Try

            SetSubForm(frm_Canc_NEfetuado_Nivel1_Ok)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel15_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel15.Click
        Try

            SetSubForm(frm_Canc_VendaNRec_Nivel1)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Nivel16_Click(sender As Object, e As EventArgs) Handles tsmi_Nivel16.Click
        Try

            SetSubForm(frm_Canc_VendaNRec_Nivel1_Ok)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad13_Click(sender As Object, e As EventArgs) Handles tsmi_Cad13.Click
        Try

            SetSubForm(frm_Retencao_Metas_PJ)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc151_Click(sender As Object, e As EventArgs) Handles tsmi_Canc151.Click
        Try

            SetSubForm(frm_Canc_OK_VC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc152_Click(sender As Object, e As EventArgs) Handles tsmi_Canc152.Click
        Try

            SetSubForm(frm_Canc_OK_VC_Devolvidos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_ControlRemoved(sender As Object, e As ControlEventArgs) Handles Panel1.ControlRemoved
        Try
            Label3.Text = "|  " & Application.ProductName.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fechamento de tela", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc01_Click(sender As Object, e As EventArgs) Handles tsmi_Canc01.Click
        Try

            SetSubForm(frm_Connect_Canc_Enviar_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc02_Click(sender As Object, e As EventArgs) Handles tsmi_Canc02.Click
        Try

            SetSubForm(frm_Connect_Canc_Enviados_RECTOR)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click_2(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try

            SetSubForm(frm_Connect_Canc_Importar_OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Canc03_Click(sender As Object, e As EventArgs) Handles tsmi_Canc03.Click
        Try

            SetSubForm(frm_Connect_Canc_Importar_NOK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad140_Click(sender As Object, e As EventArgs) Handles tsmi_Cad140.Click
        Try

            SetSubForm(frm_Clientes_Seg_Importar)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad141_Click(sender As Object, e As EventArgs) Handles tsmi_Cad141.Click
        Try

            SetSubForm(frm_Clientes_Seg)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_At5_Click(sender As Object, e As EventArgs) Handles tsmi_At5.Click
        Try

            SetSubForm(frm_Altera_Dados_PF)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_At6_Click(sender As Object, e As EventArgs) Handles tsmi_At6.Click
        Try

            SetSubForm(frm_Altera_Dados_PJ)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Tsql1_Click(sender As Object, e As EventArgs) Handles tsmi_Tsql1.Click
        Try

            SetSubForm(frm_T_SQL)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad201_Click(sender As Object, e As EventArgs) Handles tsmi_Cad201.Click
        Try

            SetSubForm(frm_Farol_Importar)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmi_Cad202_Click(sender As Object, e As EventArgs) Handles tsmi_Cad202.Click
        Try

            SetSubForm(frm_Farol)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class