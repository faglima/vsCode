Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime

Public Class frm_Retencao_PJ_SAC
    Private intGrupo As Integer = 0
    Dim campos As New List(Of ValidCampo)
    Dim utl As cls_Utilities

    Private Sub frm_Retencao_PJ_SAC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Return) Then 'Imports Microsoft.VisualBasic
                SendKeys.Send("{TAB}")
                e.Handled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Try

            Panel1.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel1.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Panel2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Try

            Panel2.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel2.ClientRectangle)

            'Dim g As Graphics = e.Graphics
            'Dim pen As New Pen(Color.Yellow, 2.0)
            'Dim j As Integer = Panel2.Controls.Count - 1

            'For i As Integer = j To 0 Step -1
            '    If TypeOf Panel2.Controls(i) Is MaskedTextBox Then
            '        g.DrawRectangle(pen, New Rectangle(Panel2.Controls(i).Location, Panel2.Controls(i).Size))
            '    End If
            'Next
            'pen.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub Panel3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Try

    '        Panel3.BorderStyle = BorderStyle.None
    '        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel3.ClientRectangle)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub Panel4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Try

    '        Panel4.BorderStyle = BorderStyle.None
    '        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel4.ClientRectangle)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub Panel5_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint
        Try

            Panel5.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel5.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel6_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint
        Try

            Panel6.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel6.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel7_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel7.Paint
        Try

            Panel7.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel7.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel8_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel8.Paint
        Try

            Panel8.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel8.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function fVersaoCorreta(ByVal strVersao As String) As Boolean
        Try
            Dim cls As New cls_SqlConnect
            Return cls.Exec_Command_Scalar("SELECT Versao FROM dbo.FRPJ_FN_GET_VERSAO(" & strVersao & ")")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub txtCnpj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCnpj.Validating
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String
            Dim intSelect As String
            Dim dtr As SqlDataReader
            Dim strBuider As New StringBuilder
            Dim strMsg As String
            Dim intOrigem As Integer
            Dim strVersao As String
            Dim strAlerta As String = Nothing

            strVersao = Strings.Replace(Application.ProductVersion.ToString, ".", "")

            If fVersaoCorreta(strVersao) = False Then
                MessageBox.Show("Você está utilizando uma versão antiga do sistema." & vbNewLine & "Utilize o painel para acessar o sistema novamente e atualizar a versão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Application.Exit()
            End If
            If Not txtCnpj.Text = Nothing Then
                If txtCnpj.MaskCompleted = False Then
                    ErrProv.SetError(txtCnpj, "Digite o CNPJ corretamente com todos os 14 dígitos!")
                    e.Cancel = True
                    MessageBox.Show("Digite o CNPJ corretamente com todos os 14 dígitos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf clsU.fCNPJ(txtCnpj.Text) = False Then
                    ErrProv.SetError(txtCnpj, "CNPJ inválido!")
                    e.Cancel = True
                    MessageBox.Show("CNPJ inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else

                    strSql = "EXEC FRPF_SP_GET_ORIGEM_USER '" & Environment.UserName & "'"
                    intOrigem = cls.Exec_Command_Scalar(strSql, 2)
                    cboOrigem.SelectedValue = intOrigem

                    strSql = "EXEC FRPJ_SP_GET_ALERTA " & txtCnpj.Text
                    dtr = cls.Return_DataReader(strSql)
                    If dtr.HasRows Then
                        Dim strText As New StringBuilder
                        Dim i As Integer = 0
                        Do While dtr.Read
                            i += 1
                            If i > 1 Then
                                strText.AppendLine(vbCrLf)
                            End If
                            strText.AppendLine("Alerta " & i & " : " & dtr.Item("Mensagem").ToString)

                        Loop

                        strAlerta = strText.ToString
                        MessageBox.Show(strAlerta, "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If


                    dtr.Close()


                    dtr = cls.Return_DataReader("EXEC FRPJ_SP_GET_ULTIMA_LIGACAO " & txtCnpj.Text, 1)

                    If dtr.HasRows Then
                        dtr.Read()
                        'txtRS.Text = dtr.Item("RazaoSocial").ToString
                        'txtEmail.Text = dtr.Item("Email").ToString
                        txtProtocoloSac.Text = dtr.Item("Num_Protocolo_SAC").ToString
                        'txtDDD.Text = dtr.Item("DDD").ToString
                        'txtFone.Text = dtr.Item("Fone").ToString
                        'txtRamal.Text = IIf(String.IsNullOrEmpty(dtr.Item("Ramal").ToString) = True, Nothing, dtr.Item("Ramal").ToString)
                        'txtDDD2.Text = IIf(dtr.Item("DDD2").ToString = Nothing, Nothing, dtr.Item("DDD2").ToString)
                        'txtCel.Text = IIf(dtr.Item("Celular").ToString = Nothing, Nothing, dtr.Item("Celular").ToString)
                        cboCorrentista.Text = dtr.Item("Correntista").ToString
                        cboBanco.SelectedValue = CInt(dtr.Item("Banco"))
                        txtAg.Text = dtr.Item("Agencia").ToString
                        txtCC.Text = dtr.Item("ContaCorrente").ToString

                        Call cboBanco_Validating(sender, e)

                        'cboSeg.SelectedValue = dtr.Item("Segmento")
                        'txtCPF.Text = dtr.Item("Cpf").ToString
                        'txtNome.Text = dtr.Item("Nome").ToString
                        'cboCargo.SelectedValue = CInt(IIf(dtr.Item("Cargo").ToString = Nothing, -1, dtr.Item("Cargo")))
                        'txtDataNasc.Text = IIf(dtr.Item("DataNasc").ToString = Nothing, Nothing, dtr.Item("DataNasc").ToString)

                        'Call txtDataNasc_Validated(sender, New System.EventArgs)

                        strBuider.AppendLine("Última ligação: " & dtr.Item("LigacaoData"))
                        strBuider.AppendLine("Produto: " & dtr.Item("NomeProduto"))

                        strBuider.AppendLine("Proposta: " & dtr.Item("Proposta"))
                        strBuider.AppendLine("Apólice: " & dtr.Item("Apolice"))
                        strBuider.AppendLine("Certificado: " & dtr.Item("Certificado"))
                        strBuider.AppendLine("Prêmio: " & dtr.Item("Premio"))
                        strBuider.AppendLine("Imp. Segurada: " & dtr.Item("ImpSegurada"))

                        strBuider.AppendLine("Desfecho: " & dtr.Item("Retido"))

                        strMsg = strBuider.ToString

                        MessageBox.Show(strMsg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        txtCodProdRector.Focus()


                   
                    End If
                    dtr.Close()
                    ErrProv.SetError(txtCnpj, "")
                End If
            Else
                ErrProv.SetError(txtCnpj, "")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frm_Retencao_PJ_SAC_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            txtCnpj.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_Retencao_PJ_SAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String

            strSqlCbo = "EXEC FRPJ_SP_RET_EPS_CBO"
            clsU.GetCboItems(strSqlCbo, cboOrigem)

            strSqlCbo = "EXEC FRPJ_SP_CBO_BANCOS"
            clsU.GetCboItems(strSqlCbo, cboBanco)
            cboBanco.DropDownWidth = 300
            cboBanco.SelectedValue = 33
            cboBanco.Enabled = False

            'strSqlCbo = "EXEC FRPJ_SP_RET_SEGMENTOS_CBO"
            'clsU.GetCboItems(strSqlCbo, cboSeg)

            'strSqlCbo = "EXEC FRPJ_SP_RET_CATEGORIAS_CBO"
            'clsU.GetCboItems(strSqlCbo, cboCateg)

            'strSqlCbo = "EXEC FRPJ_SP_RET_CARGOS_CBO"
            'clsU.GetCboItems(strSqlCbo, cboCargo)

            strSqlCbo = "EXEC FRPJ_SP_CANC_MOTIVOS2_CBO"
            clsU.GetCboItems(strSqlCbo, cboMotivo2, 1)

            Dim lstItems As New List(Of String)
            lstItems.AddRange({"Não", "Sim"})
            clsU.GetCboItems_List(cboCorrentista, lstItems)
            cboCorrentista.SelectedValue = 1

            Dim lstItems1 As New List(Of String)
            lstItems1.AddRange({"Não Retido", "Retido"})
            clsU.GetCboItems_List(cboDesfecho, lstItems1)
            cboDesfecho.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel2_Enter(sender As Object, e As EventArgs) Handles Panel2.Enter
        Try

            Panel1.BackColor = Color.Gold
            lbl01.Font = New Font(lbl01.Font, FontStyle.Bold)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel2_Leave(sender As Object, e As EventArgs) Handles Panel2.Leave
        Try

            Panel1.BackColor = Color.WhiteSmoke
            lbl01.Font = New Font(lbl01.Font, FontStyle.Regular)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub Panel4_Enter(sender As Object, e As EventArgs)
    '    Try

    '        'Panel3.BackColor = Color.Gold
    '        'lbl02.Font = New Font(lbl02.Font, FontStyle.Bold)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub Panel4_Leave(sender As Object, e As EventArgs)
    '    Try

    '        Panel3.BackColor = Color.WhiteSmoke
    '        lbl02.Font = New Font(lbl02.Font, FontStyle.Regular)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub Panel6_Enter(sender As Object, e As EventArgs) Handles Panel6.Enter
        Try

            Panel5.BackColor = Color.Gold
            lbl03.Font = New Font(lbl03.Font, FontStyle.Bold)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel6_Leave(sender As Object, e As EventArgs) Handles Panel6.Leave
        Try

            Panel5.BackColor = Color.WhiteSmoke
            lbl03.Font = New Font(lbl03.Font, FontStyle.Regular)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel8_Enter(sender As Object, e As EventArgs) Handles Panel8.Enter
        Try

            Panel7.BackColor = Color.Gold
            lbl04.Font = New Font(lbl04.Font, FontStyle.Bold)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Panel8_Leave(sender As Object, e As EventArgs) Handles Panel8.Leave
        Try

            Panel7.BackColor = Color.WhiteSmoke
            lbl04.Font = New Font(lbl04.Font, FontStyle.Regular)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Try

            Me.Close()
            Me.Dispose()
            frm_MainForm.tsmi_Welcome_Click(sender, New EventArgs)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim utl As New cls_Utilities
            Dim qtdErros As Integer = 0
            Dim strBuider As New StringBuilder
            Dim strCommand As String

            Dim strCnpj As String = "null"
            Dim strRazaoSocial As String = "null"
            Dim strDDD As String = "null"
            Dim strFone As String = "null"
            Dim strRamal As String = "null"
            Dim strDDD_Cel As String = "null"
            Dim strCelular As String = "null"
            Dim strNCorrentista As String = "null"
            Dim strBanco As String = "null"
            Dim strAgencia As String = "null"
            Dim strContaCorrente As String = "null"
            Dim strDG As String = "null"
            Dim strCodId_Segmento_Fk As String = "null"
            Dim strCpf As String = "null"
            Dim strNome As String = "null"
            Dim strEmail As String = "Null"
            Dim strCodId_Cargo_Fk As String = "null"
            Dim strDataNasc As String = "null"
            Dim strIdade As String = "null"
            Dim strCodProduto_Rector As String = "null"
            Dim strCodProduto_VC As String = "null"
            Dim strCodId_Prod_Grupo_Fk As String = "null"
            Dim strDataIniVig As String = "null"
            Dim strDataFimVig As String = "null"
            Dim strProposta As String = "null"
            Dim strApolice As String = "null"
            Dim strCertificado As String = "null"
            Dim strCodId_Categoria_Fk As String = "null"
            Dim strPremio As String = "null"
            Dim strImpSegurada As String = "null"
            Dim strArgumentacao As String = "0"
            Dim strCancelamento As String = "null"
            Dim strEndosso As String = "null"
            Dim strRetido As String = "0"
            Dim strCodId_Motivo As String = "null"
            Dim strCanc_Local As String = "null"
            Dim strCanc_Data As String = "null"
            Dim strCanc_Codigo As String = "null"
            Dim strAlcada As String = "0"
            Dim strAlcadaValor As String = "null"
            Dim strAlcadaDias As String = "null"
            Dim arrRegra As Array
            Dim strRegra As String = "NULL"
            Dim arrAlcada As Array
            Dim strAlcadas As String = "NULL"
            Dim strQtde_Parcelas As String = "NULL"
            Dim strCodId_Motivo2 As String = "NULL"
            Dim strClienteAgencia As String = "0"
            Dim strMatricula As String = "null"
            Dim strObs As String = "null"
            Dim strAtrito_VendaNRec As String = "0"
            Dim strAtrito_CancNEfetuado As String = "0"
            Dim strDate As String
            Dim strProtocoloSAC As String = "0"

            If fValidaAtivarRet(boolSalvar:=True) > 0 Then
                ExibeErros(campos)
                Throw New Exception("Favor preencher os dados obrigatórios!")
            End If

            If Panel8.Visible = False Then
                Throw New Exception("Favor preencher os dados obrigatórios!")
            End If

            If rbtnCancelamento.Checked = False And rbtnCancNEfetuado.Checked = False And rbtnClienteAtrito.Checked = False Then
                Throw New Exception("Favor preencher o desfecho da ligação!")
            ElseIf rbtnCancelamento.Checked = True Then

                If cboMotivo.SelectedIndex = -1 Then
                    Throw New Exception("Favor selecionar o motivo para o desfecho!")
                ElseIf cboMotivo.SelectedValue = 3 Then
                    If cboMotivo2.SelectedIndex = -1 Then
                        Throw New Exception("Favor selecionar o motivo gerencial para o desfecho!")
                    End If
                End If
            End If

            If chkClienteAgencia.Checked = True Then
                If txtMatricula.Text = Nothing Then
                    Throw New Exception("Favor informar a matrícula do gerente!")
                End If
            End If


            With utl
                strCnpj = .FormataStringSQL(txtCnpj.Text, TipoDado.Numerico)
                'strRazaoSocial = .FormataStringSQL(txtRS.Text, TipoDado.Texto)
                'strDDD = .FormataStringSQL(txtDDD.Text, TipoDado.Texto)
                'strFone = .FormataStringSQL(txtFone.Text, TipoDado.Texto)
                'strRamal = .FormataStringSQL(txtRamal.Text, TipoDado.Texto)
                'strDDD_Cel = .FormataStringSQL(txtDDD2.Text, TipoDado.Texto)
                'strCelular = .FormataStringSQL(txtCel.Text, TipoDado.Texto)
                If cboCorrentista.Text = "Não" Then
                    strNCorrentista = "1"
                Else
                    strNCorrentista = "0"
                End If
                strBanco = .FormataStringSQL(cboBanco.SelectedValue, TipoDado.Numerico)
                strAgencia = .FormataStringSQL(txtAg.Text, TipoDado.Numerico)

                If txtCC.Enabled = True Then
                    strContaCorrente = .FormataStringSQL(Strings.Left(txtCC.Text, Len(txtCC.Text) - 1), TipoDado.Numerico)
                    strDG = .FormataStringSQL(Strings.Right(txtCC.Text, 1), TipoDado.Numerico)
                End If

                'strCodId_Segmento_Fk = .FormataStringSQL(cboSeg.SelectedValue, TipoDado.Numerico)
                'strCpf = .FormataStringSQL(txtCPF.Text, TipoDado.Numerico)
                'strNome = .FormataStringSQL(txtNome.Text, TipoDado.Texto)
                'strEmail = .FormataStringSQL(txtEmail.Text, TipoDado.Texto)
                strProtocoloSAC = .FormataStringSQL(txtProtocoloSac.Text, TipoDado.Numerico)

                'strCodId_Cargo_Fk = .FormataStringSQL(cboCargo.SelectedValue, TipoDado.Numerico)
                'If txtDataNasc.Text <> "" Then
                '    strDate = Strings.Left(txtDataNasc.Text, 2) & "/" & Strings.Mid(txtDataNasc.Text, 3, 2) & "/" & Strings.Right(txtDataNasc.Text, 4)
                'Else
                '    strDate = ""
                'End If

                'strDataNasc = .FormataStringSQL(strDate, TipoDado.Datetime)
                'strIdade = .FormataStringSQL(txtIdade.Text, TipoDado.Numerico)
                strCodProduto_Rector = .FormataStringSQL(txtCodProdRector.Text, TipoDado.Numerico)
                strCodProduto_VC = cls.Exec_Command_Scalar("EXEC FRPJ_SP_GET_PRODUTO_VC @CodProdRector=" & strCodProduto_Rector)
                strCodProduto_VC = .FormataStringSQL(strCodProduto_VC, TipoDado.Numerico)
                strCodId_Prod_Grupo_Fk = .FormataStringSQL(intGrupo, TipoDado.Numerico)
                strDate = Strings.Left(txtDtIniVig.Text, 2) & "/" & Strings.Mid(txtDtIniVig.Text, 3, 2) & "/" & Strings.Right(txtDtIniVig.Text, 4)
                strDataIniVig = .FormataStringSQL(strDate, TipoDado.Datetime)
                strDate = Strings.Left(txtDtFimVig.Text, 2) & "/" & Strings.Mid(txtDtFimVig.Text, 3, 2) & "/" & Strings.Right(txtDtFimVig.Text, 4)
                strDataFimVig = .FormataStringSQL(strDate, TipoDado.Datetime)
                strProposta = .FormataStringSQL(txtProposta.Text, TipoDado.Numerico)
                strApolice = .FormataStringSQL(txtApolice.Text, TipoDado.Numerico)
                strCertificado = .FormataStringSQL(txtCertificado.Text, TipoDado.Numerico)
                'strCodId_Categoria_Fk = .FormataStringSQL(cboCateg.SelectedValue, TipoDado.Numerico)
                strPremio = .FormataStringSQL(txtPremio.Text, TipoDado.Numerico)
                'strQtde_Parcelas = .FormataStringSQL(txtParcelas.Text, TipoDado.Numerico)
                'strImpSegurada = .FormataStringSQL(txtImpSeg.Text, TipoDado.Numerico)
                'strArgumentacao = .FormataStringSQL(rbtnArgumentacao.Checked, TipoDado.Booleano)
                strCancelamento = .FormataStringSQL(rbtnCancelamento.Checked, TipoDado.Booleano)
                strEndosso = "0"


                strRetido = .FormataStringSQL(cboDesfecho.SelectedValue, cls_Utilities.TipoDado.Numerico)

                strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)

                If rbtnCancelamento.Checked = True Then
                    If cboMotivo.SelectedValue = 3 Then
                        strCodId_Motivo2 = .FormataStringSQL(cboMotivo2.SelectedValue, TipoDado.Numerico)
                    End If
                    strRegra = cls.Exec_Command_Scalar("EXEC FRPJ_SP_GET_CANC_REGRA @CodId_Motivo=" & strCodId_Motivo & ", @CodId_Grupo=" & strCodId_Prod_Grupo_Fk)
                    arrRegra = Split(strRegra, ";")

                    strCanc_Local = arrRegra(0).ToString
                    strCanc_Data = arrRegra(1).ToString
                    strCanc_Codigo = arrRegra(2).ToString
                    strAlcada = arrRegra(3).ToString

                    strAlcadas = cls.Exec_Command_Scalar("EXEC FRPJ_SP_GET_ALCADA @CodId_Produto_Grupo=" & strCodId_Prod_Grupo_Fk)
                    arrAlcada = Split(strAlcadas, ";")

                    strAlcadaValor = arrAlcada(0).ToString
                    strAlcadaDias = arrAlcada(1).ToString
                End If
                If chkClienteAgencia.Checked = True Then
                    strClienteAgencia = "1"
                    strMatricula = .FormataStringSQL(txtMatricula.Text, TipoDado.Texto)
                End If

                If Not txtObs.Text = Nothing Then
                    strObs = .FormataStringSQL(Strings.Right(txtObs.Text, 200), TipoDado.Texto)
                End If

                If rbtnCancNEfetuado.Checked = True Then
                    strAtrito_CancNEfetuado = "1"
                End If
                If rbtnClienteAtrito.Checked = True Then
                    strAtrito_VendaNRec = "1"
                End If

                strBuider.AppendLine(" EXEC FRPJ_SP_INSERT_ATENDIMENTO ")
                strBuider.AppendLine("@Cnpj=" & strCnpj & ",")
                strBuider.AppendLine("@RazaoSocial=" & strRazaoSocial & ",")
                strBuider.AppendLine("@DDD=" & strDDD & ",")
                strBuider.AppendLine("@Fone=" & strFone & ",")
                strBuider.AppendLine("@Ramal=" & strRamal & ",")
                strBuider.AppendLine("@DDD2=" & strDDD_Cel & ",")
                strBuider.AppendLine("@Cel=" & strCelular & ",")
                strBuider.AppendLine("@NCorrentista=" & strNCorrentista & ",")
                strBuider.AppendLine("@Banco=" & strBanco & ",")
                strBuider.AppendLine("@Agencia=" & strAgencia & ",")
                strBuider.AppendLine("@ContaCorrente=" & strContaCorrente & ",")
                strBuider.AppendLine("@DG=" & strDG & ",")
                strBuider.AppendLine("@CodId_Segmento_Fk =" & strCodId_Segmento_Fk & ",")
                strBuider.AppendLine("@Cpf=" & strCpf & ",")
                strBuider.AppendLine("@Nome=" & strNome & ",")
                strBuider.AppendLine("@Email=" & strEmail & ",")
                strBuider.AppendLine("@ProtocoloSac=" & strProtocoloSAC & ",")
                strBuider.AppendLine("@CodId_Cargo_Fk=" & strCodId_Cargo_Fk & ",")
                strBuider.AppendLine("@DataNasc=" & strDataNasc & ",")
                strBuider.AppendLine("@Idade=" & strIdade & ",")
                strBuider.AppendLine("@CodProduto_Rector=" & strCodProduto_Rector & ",")
                strBuider.AppendLine("@CodProduto_VC=" & strCodProduto_VC & ",")
                strBuider.AppendLine("@CodId_Prod_Grupo_Fk=" & strCodId_Prod_Grupo_Fk & ",")
                strBuider.AppendLine("@DataIniVig=" & strDataIniVig & ",")
                strBuider.AppendLine("@DataFimVig=" & strDataFimVig & ",")
                strBuider.AppendLine("@Proposta=" & strProposta & ",")
                strBuider.AppendLine("@Apolice=" & strApolice & ",")
                strBuider.AppendLine("@Certificado=" & strCertificado & ",")
                strBuider.AppendLine("@CodId_Categoria_Fk=" & strCodId_Categoria_Fk & ",")
                strBuider.AppendLine("@Premio=" & strPremio & ",")
                strBuider.AppendLine("@ImpSegurada=" & strImpSegurada & ",")
                strBuider.AppendLine("@Argumentacao=" & strArgumentacao & ",")
                strBuider.AppendLine("@Cancelamento=" & strCancelamento & ",")
                strBuider.AppendLine("@Endosso=" & strEndosso & ",")
                strBuider.AppendLine("@Retido=" & strRetido & ",")
                strBuider.AppendLine("@CodId_Motivo=" & strCodId_Motivo & ",")
                strBuider.AppendLine("@Canc_Local=" & strCanc_Local & ",")
                strBuider.AppendLine("@Canc_Data=" & strCanc_Data & ",")
                strBuider.AppendLine("@Canc_Codigo=" & strCanc_Codigo & ",")
                strBuider.AppendLine("@Login=" & .FormataStringSQL(Environment.UserName, TipoDado.Texto) & ",")
                strBuider.AppendLine("@Alcada=" & strAlcada & ",")
                strBuider.AppendLine("@Alcada_Valor=" & strAlcadaValor & ",")
                strBuider.AppendLine("@Alcada_Dias=" & .FormataStringSQL(strAlcadaDias, cls_Utilities.TipoDado.Numerico) & ",")
                strBuider.AppendLine("@Qtde_Parcelas=" & strQtde_Parcelas & ",")
                strBuider.AppendLine("@CodId_Motivo2=" & strCodId_Motivo2 & ",")
                strBuider.AppendLine("@ClienteAgencia=" & strClienteAgencia & ",")
                strBuider.AppendLine("@MatriculaGerente=" & strMatricula & ",")
                strBuider.AppendLine("@Obs=" & strObs & ",")
                strBuider.AppendLine("@Atrito_VendaNRec=" & strAtrito_VendaNRec & ",")
                strBuider.AppendLine("@Atrito_CancNEfetuado=" & strAtrito_CancNEfetuado)


                strCommand = strBuider.ToString

                Dim lngRec As Long
                lngRec = cls.Exec_Command_NQ(strCommand)

                If lngRec > 0 Then
                    Dim lngProtocol As Long

                    lngProtocol = fGetProtocolo(.FormataStringSQL(Environment.UserName, TipoDado.Texto))
                    MessageBox.Show("Registro Salvo com sucesso!" & vbCrLf & "Protocolo: " & lngProtocol, "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call btnLimparForm_Click(sender, New EventArgs)
                Else
                    MessageBox.Show("Erro ao salvar ligação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function fExisteRepetidos(ByVal str As String, Optional intRepetAceitavel As Integer = 1) As Boolean
        Dim i As Integer = 1
        Dim ant As Char = ""

        For Each c As Char In str
            If c = ant Then
                i += 1
                If i > intRepetAceitavel Then
                    Return True
                End If
            Else
                i = 1
            End If
            ant = c
        Next

        Return False

    End Function
    Private Sub btnAtivar_Click(sender As Object, e As EventArgs) Handles btnAtivar.Click
        Try

            Dim intErros As Integer

            intErros = fValidaAtivarRet(boolSalvar:=False)

            If intErros > 0 Then
                ExibeErros(campos)
                Throw New Exception(String.Format("{0} campos sem preenchimento.", intErros))
                Me.Panel7.Visible = False
                Me.Panel8.Visible = False
            Else
                ExibeErros(campos)
                Me.Panel7.Visible = True
                Me.Panel8.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txtCodProdRector_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCodProdRector.Validating
        Dim cls As New cls_SqlConnect
        Dim strGrupo As String
        Dim arrGrupo As Array
        Dim intApolice As Integer = 0

        If Not txtCodProdRector.Text = Nothing Then

            strGrupo = cls.Exec_Command_Scalar("FRPJ_SP_GET_GRUPO " & txtCodProdRector.Text)
            If strGrupo = Nothing Then
                MessageBox.Show("Produto não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCodProdRector.Text = Nothing
                txtGrupoProd.Text = Nothing
                intGrupo = 0
            Else
                arrGrupo = Split(strGrupo, " - ")
                txtGrupoProd.Text = arrGrupo(1).ToString
                intGrupo = CInt(arrGrupo(0))
                intApolice = CInt(arrGrupo(2))

                If intApolice > 0 Then
                    txtApolice.Text = intApolice
                    MessageBox.Show("Apólice: " & intApolice, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    txtApolice.Text = Nothing
                End If
            End If

        Else
            intGrupo = 0
            txtGrupoProd.Text = Nothing
        End If

    End Sub

    'Private Sub rbtnArgumentacao_CheckedChanged(sender As Object, e As EventArgs)
    '    Dim strSqlCbo As String
    '    Dim clsU As New cls_Utilities

    '    If rbtnArgumentacao.Checked = True Then
    '        cboMotivo.DataSource = Nothing
    '        rbtnCancelamento.Checked = False
    '        cboDesfecho.Text = "Retido"
    '        cboMotivo.Visible = True
    '        lMotivo.Visible = True
    '        strSqlCbo = "EXEC FRPJ_SP_RET_MOTIVOS_CBO @CodId_TipoRet=3,@CodId_Prod_Grupo=" & intGrupo
    '        clsU.GetCboItems(strSqlCbo, cboMotivo)
    '        cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
    '        cboMotivo.DroppedDown = True
    '    Else
    '        cboMotivo.DataSource = Nothing
    '        cboMotivo.Visible = False
    '        lMotivo.Visible = False
    '    End If

    'End Sub
    Private Sub rbtnCancelamento_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCancelamento.CheckedChanged
        Dim strSqlCbo As String
        Dim clsU As New cls_Utilities
        Dim strDataIniVig As String = "NULL"

        If rbtnCancelamento.Checked = True Then
            cboMotivo.DataSource = Nothing
            'rbtnArgumentacao.Checked = False
            cboDesfecho.Text = "Não Retido"
            cboMotivo.Visible = True
            lMotivo.Visible = True
            Dim strDate As String = Strings.Left(txtDtIniVig.Text, 2) & "/" & Strings.Mid(txtDtIniVig.Text, 3, 2) & "/" & Strings.Right(txtDtIniVig.Text, 4)
            strDataIniVig = clsU.FormataStringSQL(strDate, TipoDado.Datetime)
            strSqlCbo = "EXEC FRPJ_SP_RET_MOTIVOS_CBO @CodId_TipoRet=1,@CodId_Prod_Grupo=" & intGrupo & ",@DtIniVig=" & strDataIniVig
            clsU.GetCboItems(strSqlCbo, cboMotivo)
            cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
            cboMotivo.DroppedDown = True
        Else
            cboMotivo.DataSource = Nothing
            cboMotivo.Visible = False
            lMotivo.Visible = False
        End If

    End Sub
    Private Function fValidaAtivarRet(ByVal boolSalvar As Boolean) As Integer
        Try
            Dim intErros As Integer = 0

            If txtCnpj.MaskCompleted = False Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtCnpj))
            Else
                campos.Add(New ValidCampo("", txtCnpj))
            End If
            If cboOrigem.SelectedIndex = -1 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", cboOrigem))
            Else
                campos.Add(New ValidCampo("", cboOrigem))
            End If
            'If txtRS.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtRS))
            'Else
            '    campos.Add(New ValidCampo("", txtRS))
            'End If
            'If txtProtocoloSac.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtProtocoloSac))
            'Else
            '    campos.Add(New ValidCampo("", txtProtocoloSac))
            'End If
            'If txtDDD.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtDDD))
            'Else
            '    campos.Add(New ValidCampo("", txtDDD))
            'End If
            'If txtFone.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtFone))
            'Else
            '    campos.Add(New ValidCampo("", txtFone))
            'End If

            'If chkSCelular.Checked = False Then

            '    If txtDDD2.Text = Nothing Then
            '        intErros += 1
            '        campos.Add(New ValidCampo("Campo obrigatório", txtDDD2))
            '    Else
            '        campos.Add(New ValidCampo("", txtDDD2))
            '    End If
            '    If txtCel.Text = Nothing Then
            '        intErros += 1
            '        campos.Add(New ValidCampo("Campo obrigatório", txtCel))
            '    Else
            '        campos.Add(New ValidCampo("", txtCel))
            '    End If
            'Else
            '    campos.Add(New ValidCampo("", txtDDD2))
            '    campos.Add(New ValidCampo("", txtCel))
            'End If
            If cboCorrentista.SelectedIndex = -1 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", cboCorrentista))
            Else
                campos.Add(New ValidCampo("", cboCorrentista))
            End If
            If cboBanco.SelectedIndex = -1 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", cboBanco))
            Else
                campos.Add(New ValidCampo("", cboBanco))
            End If
            If cboBanco.SelectedIndex = -1 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", cboBanco))
            Else
                campos.Add(New ValidCampo("", cboBanco))
            End If
            If txtAg.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtAg))
            Else
                campos.Add(New ValidCampo("", txtAg))
            End If
            If cboCorrentista.Text = "Não" AndAlso cboBanco.SelectedValue <> "033" Then
                If txtCC.Text = Nothing Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtCC))
                Else
                    campos.Add(New ValidCampo("", txtCC))
                End If
            ElseIf cboCorrentista.Text = "Sim" Then
                If txtCC.Text = Nothing Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtCC))
                Else
                    campos.Add(New ValidCampo("", txtCC))
                End If
            End If
            'If cboSeg.SelectedIndex = -1 Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", cboSeg))
            'Else
            '    campos.Add(New ValidCampo("", cboSeg))
            'End If

            If boolSalvar And cboMotivo.SelectedValue <> 4 Then

                'If txtCPF.MaskCompleted = False Then
                '    intErros += 1
                '    campos.Add(New ValidCampo("Campo obrigatório", txtCPF))
                'Else
                '    campos.Add(New ValidCampo("", txtCPF))
                'End If
                'If txtNome.Text = Nothing Then
                '    intErros += 1
                '    campos.Add(New ValidCampo("Campo obrigatório", txtNome))
                'Else
                '    campos.Add(New ValidCampo("", txtNome))
                'End If
                'If cboCargo.SelectedIndex = -1 Then
                '    intErros += 1
                '    campos.Add(New ValidCampo("Campo obrigatório", cboCargo))
                'Else
                '    campos.Add(New ValidCampo("", cboCargo))
                'End If
                'If txtDataNasc.MaskCompleted = False Then
                '    intErros += 1
                '    campos.Add(New ValidCampo("Campo obrigatório", txtDataNasc))
                'Else
                '    campos.Add(New ValidCampo("", txtDataNasc))
                'End If

            End If

            If txtCodProdRector.Text = Nothing Or intGrupo = 0 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtCodProdRector))
                txtCodProdRector.Text = Nothing
            Else
                campos.Add(New ValidCampo("", txtCodProdRector))
            End If
            If txtDtIniVig.MaskCompleted = False Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtDtIniVig))
            Else
                campos.Add(New ValidCampo("", txtDtIniVig))
            End If
            If txtDtFimVig.MaskCompleted = False Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtDtFimVig))
            Else
                campos.Add(New ValidCampo("", txtDtFimVig))
            End If
            If txtProposta.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtProposta))
            Else
                campos.Add(New ValidCampo("", txtProposta))
            End If
            If txtApolice.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtApolice))
            Else
                campos.Add(New ValidCampo("", txtApolice))
            End If
            If txtCertificado.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtCertificado))
            Else
                campos.Add(New ValidCampo("", txtCertificado))
            End If
            'If cboCateg.SelectedIndex = -1 Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", cboCateg))
            'Else
            '    campos.Add(New ValidCampo("", cboCateg))
            'End If
            If txtPremio.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtPremio))
            Else
                campos.Add(New ValidCampo("", txtPremio))
            End If
            'If txtImpSeg.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtImpSeg))
            'Else
            '    campos.Add(New ValidCampo("", txtImpSeg))
            'End If

            If (rbtnClienteAtrito.Checked Or rbtnCancNEfetuado.Checked) And txtObs.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtObs))
            Else
                campos.Add(New ValidCampo("", txtObs))
            End If
            'If txtParcelas.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtParcelas))
            'ElseIf CInt(txtParcelas.Text) = 0 Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtParcelas))
            'Else
            '    campos.Add(New ValidCampo("", txtParcelas))
            'End If
            Return intErros

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub cboBanco_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboBanco.Validating
        If cboCorrentista.Text = "Não" AndAlso cboBanco.SelectedValue = "033" Then
            txtCC.Enabled = False
        Else
            txtCC.Enabled = True
        End If
    End Sub

    Private Sub cboCorrentista_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCorrentista.Validating

        txtCC.Enabled = True

        If cboCorrentista.Text = "Não" Then
            cboBanco.Enabled = True
            cboBanco.SelectedIndex = -1
            cboBanco.DroppedDown = True
        Else
            cboBanco.Text = "033 - Banco Santander (Brasil) S.A."
            cboBanco.Enabled = False
        End If
    End Sub

    'Private Sub txtDataNasc_Validated(sender As Object, e As EventArgs)
    '    Dim strDate As String
    '    If txtDataNasc.MaskCompleted = True Then
    '        strDate = Strings.Left(txtDataNasc.Text, 2) & "/" & Strings.Mid(txtDataNasc.Text, 3, 2) & "/" & Strings.Right(txtDataNasc.Text, 4)
    '        txtIdade.Text = DateAndTime.DateDiff(DateInterval.Day, CDate(strDate), Today) \ 365.25
    '    Else
    '        txtIdade.Text = Nothing
    '    End If
    'End Sub

    'Private Sub txtCPF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    Dim clsU As New cls_Utilities

    '    If Not txtCPF.Text = Nothing Then
    '        If txtCPF.MaskCompleted = False Then
    '            ErrProv.SetError(txtCPF, "Digite o CPF corretamente com todos os 11 dígitos!")
    '            e.Cancel = True
    '            MessageBox.Show("Digite o CPF corretamente com todos os 11 dígitos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        ElseIf clsU.CPF(txtCPF.Text) = False Then
    '            ErrProv.SetError(txtCPF, "CPF inválido!")
    '            e.Cancel = True
    '            MessageBox.Show("CPF inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Else
    '            ErrProv.SetError(txtCPF, "")
    '        End If
    '    Else
    '        ErrProv.SetError(txtCPF, "")
    '    End If
    'End Sub
    Private Sub ExibeErros(campos As List(Of ValidCampo))

        For Each vc In campos
            ErrProv.SetIconAlignment(vc.Origem, ErrorIconAlignment.TopRight)
            ErrProv.SetIconPadding(vc.Origem, -10)
            errProv.SetError(vc.Origem, vc.Msg)

        Next

    End Sub

    'Private Sub txtImpSeg_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    If Not txtImpSeg.Text = Nothing And IsNumeric(txtImpSeg.Text) Then
    '        txtImpSeg.Text = FormatNumber(CDbl(txtImpSeg.Text), 2)
    '    Else
    '        txtImpSeg.Text = Nothing
    '    End If
    'End Sub

    Private Sub btnLimparAt_Click(sender As Object, e As EventArgs) Handles btnLimparAt.Click
        If Panel8.Visible = True Then
            RemoveErrosPainel(Panel8)
            ZeraPainel(Panel8)
            cboMotivo2.Visible = False
            lMotivo2.Visible = False
        End If
    End Sub
    Private Sub ZeraPainel(ByVal pnl As Panel)

        RemoveErrosPainel(pnl)

        For Each ctrl As Control In pnl.Controls

            If (ctrl.GetType().Name = "ComboBox") Then
                Dim cbo As ComboBox = ctrl
                If cbo.Tag = "1" Then
                    cbo.Text = "Sim"
                ElseIf cbo.Tag = "2" Then
                    cbo.SelectedValue = 33
                    cbo.Enabled = False
                Else
                    cbo.SelectedIndex = -1
                End If

            End If

            If (ctrl.GetType().Name = "TextBox") Then

                Dim txt As TextBox = ctrl
                txt.Text = ""
                If txt.Name = "txtCC" Then txt.Enabled = True
            End If

            If (ctrl.GetType().Name = "CheckBox") Then

                Dim chk As CheckBox = ctrl
                chk.CheckState = CheckState.Unchecked

            End If
            If (ctrl.GetType().Name = "CheckBox") Then

                Dim chk As CheckBox = ctrl
                chk.CheckState = CheckState.Unchecked

            End If
            If (ctrl.GetType().Name = "RadioButton") Then

                Dim chk As RadioButton = ctrl
                chk.Checked = False

            End If
            If (ctrl.GetType().Name = "MaskedTextBox") Then

                Dim msktxt As MaskedTextBox = ctrl
                msktxt.Text = Nothing

            End If


        Next

    End Sub
    Private Sub RemoveErrosPainel(ByVal pnl As Panel)

        For Each ctrl As Control In pnl.Controls
            errProv.SetError(ctrl, "")
        Next

    End Sub

    Private Sub btnLimparForm_Click(sender As Object, e As EventArgs) Handles btnLimparForm.Click
        If Panel8.Visible = True Then
            RemoveErrosPainel(Panel8)
            ZeraPainel(Panel8)
            Panel8.Visible = False
            Panel7.Visible = False
            cboMotivo2.Visible = False
            lMotivo2.Visible = False
        End If
        RemoveErrosPainel(Panel6)
        ZeraPainel(Panel6)
        'RemoveErrosPainel(Panel4)
        'ZeraPainel(Panel4)
        RemoveErrosPainel(Panel2)
        ZeraPainel(Panel2)
        txtCnpj.Focus()
    End Sub
    Enum TipoDado
        Texto = 0
        Numerico = 1
        Booleano = 2
        Datetime = 3
    End Enum
    Private Function fGetProtocolo(LoginOperador As String) As Long

        Dim cls As New cls_SqlConnect
        Dim strSql As String
        Dim lngProtocolo As Long

        strSql = "EXEC FRPJ_SP_ID_LIGACAO " & LoginOperador

        lngProtocolo = cls.Exec_Command_Scalar(strSql)

        Return lngProtocolo


    End Function

    Private Sub txtAg_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtCC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCC.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtCodProdRector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodProdRector.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtProposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProposta.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtApolice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApolice.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtCertificado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCertificado.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtPremioKeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = ",") Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtImpSeg_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = ",") Then

            e.Handled = True

        End If
    End Sub



    Private Sub DesativarRetencao(sender As Object)
        Try

            If Panel8.Visible = True Then
                Call btnLimparAt_Click(sender, New System.EventArgs)
                Panel8.Visible = False
                Panel7.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtCnpj_TextChanged(sender As Object, e As EventArgs) Handles txtCnpj.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboOrigem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrigem.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtRS_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtDDD_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    'Private Sub txtFone_TextChanged(sender As Object, e As EventArgs)
    '    Call DesativarRetencao(sender)

    '    If Strings.Len(txtFone.Text) < 8 Then
    '        txtFone.Mask = "999999999"
    '    End If
    'End Sub

    Private Sub txtRamal_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboCorrentista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCorrentista.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBanco.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtAg_TextChanged(sender As Object, e As EventArgs) Handles txtAg.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtCC_TextChanged(sender As Object, e As EventArgs) Handles txtCC.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboSeg_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub


    Private Sub txtCPF_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtNome_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboCargo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub


    Private Sub txtDataNasc_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtCodProdRector_TextChanged(sender As Object, e As EventArgs) Handles txtCodProdRector.TextChanged
        Call DesativarRetencao(sender)
    End Sub


    Private Sub txtDtIniVig_TextChanged(sender As Object, e As EventArgs) Handles txtDtIniVig.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtDtFimVig_TextChanged(sender As Object, e As EventArgs) Handles txtDtFimVig.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtProposta_TextChanged(sender As Object, e As EventArgs) Handles txtProposta.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtApolice_TextChanged(sender As Object, e As EventArgs) Handles txtApolice.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtCertificado_TextChanged(sender As Object, e As EventArgs) Handles txtCertificado.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboCateg_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtImpSeg_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub chkClienteAgencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkClienteAgencia.CheckedChanged

        txtMatricula.Text = Nothing

        If chkClienteAgencia.Checked = True Then
            txtMatricula.Visible = True
            lMatricula.Visible = True
        Else
            txtMatricula.Visible = False
            lMatricula.Visible = False
        End If
    End Sub


    Private Sub rbtnClienteAtrito_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnClienteAtrito.CheckedChanged
        Try
            cboDesfecho.Text = "Não Retido"

            If rbtnClienteAtrito.Checked Then
                MessageBox.Show("ATENÇÂO: Este encaminhamento é exclusivo para situações de clientes em atrito, para estorno superior a 90 dias." + vbNewLine + "É OBRIGATÓRIO a aprovação do Supervisor para encaminhamento do chamado." _
                                + vbNewLine + "Não é necessário abrir GCA/Ocorrência...", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCancNEfetuado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCancNEfetuado.CheckedChanged
        Try
            cboDesfecho.Text = "Não Retido"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboMotivo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboMotivo.Validating

        If cboMotivo.SelectedIndex = -1 Then
            Me.cboMotivo2.Visible = False
            Me.lMotivo2.Visible = False
        ElseIf cboMotivo.SelectedValue = 3 Then
            Me.cboMotivo2.Visible = True
            Me.lMotivo2.Visible = True
            cboMotivo2.DroppedDown = True
        Else
            Me.cboMotivo2.Visible = False
            Me.lMotivo2.Visible = False
        End If

    End Sub

    Private Sub txtParcelas_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtParcelas_TextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    'Private Sub txtRS_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    If Not txtRS.Text = Nothing Then
    '        txtRS.Text = UCase(txtRS.Text)
    '    End If
    'End Sub

    'Private Sub txtNome_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    If Not txtNome.Text = Nothing Then
    '        txtNome.Text = UCase(txtNome.Text)
    '    End If
    'End Sub

    Private Sub txtCC_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCC.Validating
        Try
            Dim clsU As New cls_Utilities
            Dim bco As String = ""

            If cboBanco.Text <> "" Then
                bco = CInt(Strings.Left(cboBanco.Text, 3))
            End If

            If cboCorrentista.Text = "Sim" AndAlso Not txtCC.Text = Nothing Then
                If clsU.fValidaCC(txtAg.Text, Strings.Left(txtCC.Text, Strings.Len(txtCC.Text) - 1), Strings.Right(txtCC.Text, 1)) = False Then
                    ErrProv.SetError(txtCC, "Conta corrente inválida!")
                    e.Cancel = True
                    MessageBox.Show("Conta corrente inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If fContaInvalida(bco, txtAg.Text, txtCC.Text) = True Then

                        ErrProv.SetError(txtCC, "A devolução só poderá ser feita na conta de titularidade do segurado, portanto esta conta não está apta pra receber estorno!")
                        e.Cancel = True
                        MessageBox.Show("A devolução só poderá ser feita na conta de titularidade do segurado, portanto esta conta não está apta pra receber estorno!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Else
                        ErrProv.SetError(txtCC, "")
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtAg_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAg.Validating
        Dim intAg As Integer
        Dim strBco As String
        If txtAg.Text <> "" Then

            intAg = CInt(txtAg.Text)
            strBco = CInt(Strings.Left(cboBanco.Text, 3))

            If intAg > 0 Then

                If txtAg.MaskCompleted = False Then
                    ErrProv.SetError(txtAg, "Digite a agência corretamente !")
                    e.Cancel = True
                    MessageBox.Show("Digite a agência corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    'Verifica se a agencia não possui numeros repetidos 1111, 2222 e etc
                    If fAgenciaInvalida(txtAg.Text, strBco) = False Then
                        ErrProv.SetError(txtAg, "")
                    Else
                        ErrProv.SetError(txtAg, "Digite a agência corretamente !")
                        e.Cancel = True
                        MessageBox.Show("Digite a agência corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                End If
            Else
                ErrProv.SetError(txtAg, "Digite a agência corretamente !")
                e.Cancel = True
                MessageBox.Show("Digite a agência corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            ErrProv.SetError(txtAg, "")
        End If

    End Sub
    Private Function fAgenciaInvalida(ByVal strAg As String, Optional strBco As String = "NULL") As Boolean

        Try

            Dim cls As New cls_SqlConnect
            Return cls.Exec_Command_Scalar("SELECT Invalido FROM dbo.FRPJ_FN_GET_AG_CC_INVALIDA (" & strBco & "," & strAg & ",NULL)")

        Catch ex As Exception
            Return True
        End Try

    End Function

    Private Function fContaInvalida(ByVal strBco As String, ByVal strAg As String, ByVal strCc As String) As Boolean

        Try

            Dim cls As New cls_SqlConnect
            Return cls.Exec_Command_Scalar("SELECT Invalido FROM dbo.FRPJ_FN_GET_AG_CC_INVALIDA (" & strBco & "," & strAg & "," & strCc & ")")

        Catch ex As Exception
            Return True
        End Try

    End Function

    'Private Sub txtFone_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    Dim boolErro As Boolean = False

    '    If txtFone.Text <> "" Then

    '        If Strings.Len(txtFone.Text) = 8 Then 'Verifica se o numero é fixo e altera sua máscara
    '            txtFone.Mask = "0000-0000"
    '        ElseIf Strings.Len(txtFone.Text) = 9 Then 'Verifica se o numero é celular e altera sua máscara
    '            txtFone.Mask = "00000-0000"
    '        ElseIf (txtFone.Text = "" Or Strings.Len(txtFone.Text) < 8) And txtDDD.Text <> "" Then
    '            boolErro = True
    '            txtFone.Mask = "999999999"
    '        End If

    '        If txtFone.MaskCompleted = False Or boolErro = True Or fExisteRepetidos(txtFone.Text, 4) = True Then
    '            ErrProv.SetError(txtFone, "Digite o telefone corretamente !")
    '            e.Cancel = True
    '            MessageBox.Show("Digite o telefone corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            boolErro = False
    '        Else
    '            If Strings.Len(txtFone.Text) = 9 And txtCel.Text = "" Then
    '                txtCel.Text = txtFone.Text
    '                txtDDD2.Text = txtDDD.Text
    '            End If
    '            ErrProv.SetError(txtFone, "")
    '        End If

    '    Else
    '        ErrProv.SetError(txtFone, "")
    '    End If

    'End Sub

    'Private Sub txtCel_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    '    If txtCel.Text <> "" Then
    '        If txtCel.MaskCompleted = False Or fExisteRepetidos(txtCel.Text, 4) = True Then
    '            ErrProv.SetError(txtCel, "Digite o celular corretamente !")
    '            e.Cancel = True
    '            MessageBox.Show("Digite o celular corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Else
    '            ErrProv.SetError(txtCel, "")

    '            If txtFone.Text = "" Then
    '                txtFone.Text = txtCel.Text
    '                txtDDD.Text = txtDDD2.Text
    '            End If
    '        End If
    '    Else
    '        ErrProv.SetError(txtCel, "")
    '    End If
    'End Sub

    'Private Sub txtDDD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    '    If txtDDD.Text <> "" Then
    '        If txtDDD.MaskCompleted = False Then
    '            ErrProv.SetError(txtDDD, "Digite o DDD corretamente !")
    '            e.Cancel = True
    '            MessageBox.Show("Digite o DDD corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Else
    '            ErrProv.SetError(txtDDD, "")
    '        End If
    '    Else
    '        ErrProv.SetError(txtDDD, "")
    '    End If

    'End Sub

    'Private Sub txtDDD2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    '    If txtDDD2.Text <> "" Then
    '        If txtDDD2.MaskCompleted = False Then
    '            ErrProv.SetError(txtDDD2, "Digite o DDD corretamente !")
    '            e.Cancel = True
    '            MessageBox.Show("Digite o DDD corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Else
    '            ErrProv.SetError(txtDDD2, "")
    '        End If
    '    Else
    '        ErrProv.SetError(txtDDD2, "")
    '    End If

    'End Sub

    Private Sub txtPremioTextChanged(sender As Object, e As EventArgs)
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtPremio_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPremio.Validating
        Try
            Dim dblPremio As Double

            If Not txtPremio.Text = Nothing And IsNumeric(txtPremio.Text) Then
                dblPremio = CDbl(txtPremio.Text)

                If dblPremio < 100000 Then
                    txtPremio.Text = FormatNumber(dblPremio, 2)
                    ErrProv.SetError(txtPremio, "")
                Else
                    ErrProv.SetError(txtPremio, "Valor acima do permitido !")
                    MessageBox.Show("Valor acima do permitido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtPremio.Focus()
                End If


            Else
                txtPremio.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtProposta_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProposta.Validating
        Dim intCaract As Integer
        intCaract = Len(txtProposta.Text)
        If txtProposta.Text <> Nothing Then
            If (intCaract < 8 Or intCaract > 12) Then
                MessageBox.Show("Número de proposta inválido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtProposta.Focus()

            Else
                If IsNumeric(txtProposta.Text) = False Then
                    MessageBox.Show("Caractere inválido na proposta !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtProposta.Focus()
                End If
            End If

        End If

    End Sub


    Private Sub txtCertificado_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCertificado.Validating

        If txtCertificado.Text <> Nothing Then

            If txtProposta.Text = txtCertificado.Text Then
                MessageBox.Show("Número de certificado inválido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCertificado.Focus()
            Else
                If IsNumeric(txtCertificado.Text) = False Then
                    MessageBox.Show("Caractere inválido na proposta !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtCertificado.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub txtApolice_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtApolice.Validating

        If IsNumeric(txtApolice.Text) = False And Len(txtApolice.Text) > 0 Then
            MessageBox.Show("Caractere inválido na apólice !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApolice.Focus()
        End If
    End Sub

    'Private Sub chkSCelular_CheckedChanged(sender As Object, e As EventArgs)
    '    If chkSCelular.Checked = True Then
    '        txtCel.Enabled = False
    '        txtDDD2.Enabled = False

    '        txtCel.Text = ""
    '        txtDDD2.Text = ""
    '    Else
    '        txtCel.Enabled = True
    '        txtDDD2.Enabled = True
    '    End If
    'End Sub
    Private Sub txtProtocoloSac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProtocoloSac.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub
End Class