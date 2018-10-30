Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime

Public Class frm_Retencao_PF_Off
    Private intGrupo As Integer = 0
    Private intCodProdutoVC As Integer = 0
    Dim intTipoResVenda As Integer = 0
    Dim intCategVenda As Integer = 0
    Dim blnCateg As Boolean = False
    Dim blnSeg As Boolean = False
    Dim campos As New List(Of ValidCampo)
    Dim utl As cls_Utilities
    Private intDesfecho = 0

    Private Sub frm_Retencao_PF_Off_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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
    Private Sub Panel81_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel81.Paint
        Try

            Panel81.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel81.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub frm_Retencao_PF_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            txtCPF.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frm_Retencao_PF_Off_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim clsU As New cls_Utilities

            clsU.GetCboItems_Xml(cboOrigem, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\EPS.xml")

            clsU.GetCboItems_Xml(cboBanco, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Bancos.xml")
            cboBanco.DropDownWidth = 300
            cboBanco.SelectedValue = 33
            cboBanco.Enabled = False

            clsU.GetCboItems_Xml(cboProf, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Prof.xml")
            cboProf.SelectedValue = 9999

            clsU.GetCboItems_Xml(cboSeg, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\SegPF.xml")

            clsU.GetCboItems_Xml(cboCateg, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\CategPF.xml")

            clsU.GetCboItems_Xml(cboMotivo2, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos2_Canc_PF.xml")

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
            frm_MainForm_Off.SetSubForm(frm_Welcome_Off)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try

            Dim swFile As StreamWriter
            Dim strFile As String
            Dim utl As New cls_Utilities
            Dim qtdErros As Integer = 0
            Dim strBuider As New StringBuilder
            Dim strCommand As String

            Dim strCnpj As String = "''"
            Dim strRazaoSocial As String = "''"
            Dim strDDD As String = "''"
            Dim strFone As String = "''"
            Dim strDDD2 As String = "''"
            Dim strCel As String = "''"
            Dim strRamal As String = "''"
            Dim strNCorrentista As String = "''"
            Dim strBanco As String = "''"
            Dim strAgencia As String = "''"
            Dim strContaCorrente As String = "''"
            Dim strDG As String = "''"
            Dim strCodId_Segmento_Fk As String = "''"
            Dim strCpf As String = "''"
            Dim strNome As String = "''"
            Dim strEmail As String = "''"
            Dim strProtocoloSAC As String = "0"
            Dim strCodId_Cargo_Fk As String = "''"
            Dim strDataNasc As String = "''"
            Dim strIdade As String = "''"
            Dim strCodProduto_Rector As String = "''"
            Dim strCodProduto_VC As String = "''"
            Dim strCodId_Prod_Grupo_Fk As String = "''"
            Dim strDataIniVig As String = "''"
            Dim strDataFimVig As String = "''"
            Dim strProposta As String = "''"
            Dim strApolice As String = "''"
            Dim strCertificado As String = "''"
            Dim strCodId_Categoria_Fk As String = "''"
            Dim strPremio As String = "''"
            Dim strImpSegurada As String = "''"
            Dim strArgumentacao As String = "0"
            Dim strCancelamento As String = "0"
            Dim strEndosso As String = "0"
            Dim strRetido As String = "0"
            Dim strCodId_Motivo As String = "0"
            Dim strCanc_Local As String = "0"
            Dim strCanc_Data As String = "0"
            Dim strCanc_Codigo As String = "0"
            Dim strAlcada As String = "0"
            Dim strAlcadaValor As String = "0"
            Dim strAlcadaDias As String = "0"
            Dim strEndosso_ImpSeg As String = "''"
            Dim strEndosso_Premio As String = "''"
            Dim strVenda As String = "0"
            Dim strVenda_Produto_VC As String = "''"
            Dim strVenda_ImpSeg As String = "''"
            Dim strVenda_Premio As String = "''"
            Dim strCCred_TFC As String = "0"
            Dim strCCred_TFC_Bandeira As String = "0"
            Dim strCCred_TFC_Numero As String = "0"
            Dim strOferta As String = "0"
            Dim strOferta_Cod_Ferrari As String = "''"
            Dim strOferta_ImpSeg As String = "''"
            Dim strOferta_Premio As String = "''"
            Dim strN_Emitido As String = "0"
            Dim strQtde_Parcelas As String = "''"
            Dim strATM As String = "0"
            Dim strSMS As String = "0"
            Dim strClienteAgencia As String = "0"
            Dim strMatriculaGerente As String = "''"
            Dim strCodId_Motivo2 As String = "0"
            Dim strAtrito_VendaNRec As String = "0"
            Dim strAtrito_CancNEfetuado As String = "0"
            Dim strLogradouro As String = "''"
            Dim strNumero As String = "''"
            Dim strComplemento As String = "''"
            Dim strBairro As String = "''"
            Dim strCidade As String = "''"
            Dim strUF As String = "''"
            Dim strCEP As String = "''"
            Dim strTipo_Imovel As String = "''"
            Dim strObs As String = "''"
            Dim strOferta_Produto_VC As String = "''"
            Dim strDataDebito As String = "''"
            Dim strOferta_CodId_Plano As String = "''"
            Dim strVenda_CodId_Plano As String = "''"
            Dim lngProtocolo As Long = CLng(CStr(Int((10000 * Rnd()) + 1)) & CStr(Format(Now(), "hhmmss")))

            If Panel8.Visible = False Then
                Throw New Exception("Favor preencher os dados obrigatórios!")
            End If
            If fValidaAtendimento() = False Then
                ExibeErros(campos)
                Throw New Exception("Favor selecionar todos os dados para o desfecho do atendimento!")
            End If

            With utl
                'strCnpj = .FormataStringSQL(txtCnpj.Text, TipoDado.Numerico,"0")
                'strRazaoSocial = .FormataStringSQL(txtRS.Text, TipoDado.Texto, "''")
                strDDD = .FormataStringSQL(txtDDD.Text, TipoDado.Texto, "''")
                strFone = .FormataStringSQL(txtFone.Text, TipoDado.Texto, "''")
                strRamal = .FormataStringSQL(txtRamal.Text, TipoDado.Texto, "''")
                strDDD2 = .FormataStringSQL(txtDDD2.Text, TipoDado.Texto, "''")
                strCel = .FormataStringSQL(txtCel.Text, TipoDado.Texto, "''")
                strEmail = .FormataStringSQL(txtEmail.Text, TipoDado.Texto, "''")
                strProtocoloSAC = .FormataStringSQL(txtProtocoloSac.Text, TipoDado.Numerico, "0")
                If cboCorrentista.Text = "Não" Then
                    strNCorrentista = "1"
                Else
                    strNCorrentista = "0"
                End If

                If chkATM.Checked = True Then
                    strATM = "1"
                End If

                If chkATM_N_Emitido.Checked = True Then
                    strN_Emitido = "1"
                End If

                strBanco = .FormataStringSQL(cboBanco.SelectedValue, TipoDado.Numerico, "0")
                strAgencia = .FormataStringSQL(txtAg.Text, TipoDado.Numerico, "0")
                strContaCorrente = .FormataStringSQL(Strings.Left(txtCC.Text, Len(txtCC.Text) - 1), TipoDado.Numerico, "0")
                strDG = .FormataStringSQL(Strings.Right(txtCC.Text, 1), TipoDado.Numerico, "0")
                strCodId_Segmento_Fk = .FormataStringSQL(cboSeg.SelectedValue, TipoDado.Numerico, "0")
                strCpf = .FormataStringSQL(txtCPF.Text, TipoDado.Numerico, "0")
                strNome = .FormataStringSQL(txtNome.Text, TipoDado.Texto, "''")
                strEmail = .FormataStringSQL(txtEmail.Text, TipoDado.Texto, "''")
                strProtocoloSAC = .FormataStringSQL(txtProtocoloSac.Text, TipoDado.Numerico, "0")
                'strCodId_Cargo_Fk = .FormataStringSQL(cboCargo.SelectedValue, TipoDado.Numerico,"0")
                Dim strDate As String = Strings.Left(txtDataNasc.Text, 2) & "/" & Strings.Mid(txtDataNasc.Text, 3, 2) & "/" & Strings.Right(txtDataNasc.Text, 4)
                strDataNasc = .FormataStringSQL(strDate, TipoDado.Numerico, "''")
                strIdade = .FormataStringSQL(txtIdade.Text, TipoDado.Numerico, "0")
                strCodProduto_Rector = .FormataStringSQL(txtCodProdRector.Text, TipoDado.Numerico, "0")
                strCodProduto_VC = .FormataStringSQL(intCodProdutoVC, TipoDado.Numerico, "0")
                strCodId_Prod_Grupo_Fk = .FormataStringSQL(intGrupo, TipoDado.Numerico, "0")
                If chkATM_N_Emitido.Checked = False Then
                    strDate = Strings.Left(txtDtIniVig.Text, 2) & "/" & Strings.Mid(txtDtIniVig.Text, 3, 2) & "/" & Strings.Right(txtDtIniVig.Text, 4)
                    strDataIniVig = .FormataStringSQL(strDate, TipoDado.Numerico, "''")
                    strDate = Strings.Left(txtDtFimVig.Text, 2) & "/" & Strings.Mid(txtDtFimVig.Text, 3, 2) & "/" & Strings.Right(txtDtFimVig.Text, 4)
                    strDataFimVig = .FormataStringSQL(strDate, TipoDado.Numerico, "''")
                    strProposta = .FormataStringSQL(txtProposta.Text, TipoDado.Numerico, "0")
                    strApolice = .FormataStringSQL(txtApolice.Text, TipoDado.Numerico, "0")
                    strCertificado = .FormataStringSQL(txtCertificado.Text, TipoDado.Numerico, "0")
                    strCodId_Categoria_Fk = .FormataStringSQL(cboCateg.SelectedValue, TipoDado.Numerico, "0")
                    strPremio = .FormataStringSQL(txtPremio.Text, TipoDado.Numerico, "0")
                    strImpSegurada = .FormataStringSQL(txtImpSeg.Text, TipoDado.Numerico, "0")
                    'strQtde_Parcelas = .FormataStringSQL(txtParcelas.Text, TipoDado.Numerico,"0")
                End If
                strObs = .FormataStringSQL(txtObs.Text, TipoDado.Texto, "''")

                If cboDesfecho.Text = "Retido" Then
                    strRetido = "1"
                Else
                    strRetido = "0"
                End If

                Select Case intDesfecho
                    Case Is = 1 'Argumentação
                        strArgumentacao = "1"
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico, "0")
                    Case Is = 2 'Cartão de Crédito
                        strCCred_TFC = "1"
                        strCCred_TFC_Bandeira = .FormataStringSQL(txtCartaoBandeira.Text, TipoDado.Numerico, "0")
                        strCCred_TFC_Numero = .FormataStringSQL(txtCartaoNumero.Text, TipoDado.Numerico, "0")
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico, "0")
                    Case Is = 3 'Cancelamento
                        If chkATM_N_Emitido.Checked = True Then
                            strN_Emitido = "1"
                            strCancelamento = "0"
                        Else
                            strCancelamento = "1"
                        End If

                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico, "0")
                        If cboMotivo.SelectedValue = 3 Then
                            strCodId_Motivo2 = .FormataStringSQL(cboMotivo2.SelectedValue, TipoDado.Numerico, "0")
                        End If

                        strCanc_Local = "0"
                        strCanc_Data = "0"
                        strCanc_Codigo = "0"
                        strAlcada = "0"
                        strAlcadaValor = "0"
                        strAlcadaDias = "0"
                    Case Is = 4 'Cliente em Atrito
                        strAtrito_VendaNRec = "1"
                    Case Is = 5 'Cancelamento não efetuado
                        strAtrito_CancNEfetuado = "1"
                End Select

                strBuider.Append(lngProtocolo & ";")
                strBuider.Append(strDDD & ";")
                strBuider.Append(strFone & ";")
                strBuider.Append(strRamal & ";")
                strBuider.Append(strDDD2 & ";")
                strBuider.Append(strCel & ";")
                strBuider.Append(strNCorrentista & ";")
                strBuider.Append(strBanco & ";")
                strBuider.Append(strAgencia & ";")
                strBuider.Append(strContaCorrente & ";")
                strBuider.Append(strDG & ";")
                strBuider.Append(strCodId_Segmento_Fk & ";")
                strBuider.Append(strCpf & ";")
                strBuider.Append(strNome & ";")
                strBuider.Append(strEmail & ";")
                strBuider.Append(strProtocoloSAC & ";")
                strBuider.Append(strCodId_Cargo_Fk & ";")
                strBuider.Append(strDataNasc & ";")
                strBuider.Append(strIdade & ";")
                strBuider.Append(strCodProduto_Rector & ";")
                strBuider.Append(strCodProduto_VC & ";")
                strBuider.Append(strCodId_Prod_Grupo_Fk & ";")
                strBuider.Append(strDataIniVig & ";")
                strBuider.Append(strDataFimVig & ";")
                strBuider.Append(strProposta & ";")
                strBuider.Append(strApolice & ";")
                strBuider.Append(strCertificado & ";")
                strBuider.Append(strCodId_Categoria_Fk & ";")
                strBuider.Append(strPremio & ";")
                strBuider.Append(strImpSegurada & ";")
                strBuider.Append(strArgumentacao & ";")
                strBuider.Append(strCancelamento & ";")
                strBuider.Append(strEndosso & ";")
                strBuider.Append(strRetido & ";")
                strBuider.Append(strCodId_Motivo & ";")
                strBuider.Append(strCanc_Local & ";")
                strBuider.Append(strCanc_Data & ";")
                strBuider.Append(strCanc_Codigo & ";")
                strBuider.Append(.FormataStringSQL(Environment.UserName, TipoDado.Texto, "''") & ";")
                strBuider.Append(strAlcada & ";")
                strBuider.Append(strAlcadaValor & ";")
                strBuider.Append(.FormataStringSQL(strAlcadaDias, cls_Utilities.TipoDado.Numerico, "0") & ";")
                strBuider.Append(strEndosso_ImpSeg & ";")
                strBuider.Append(strEndosso_Premio & ";")
                strBuider.Append(strVenda & ";")
                strBuider.Append(strVenda_Produto_VC & ";")
                strBuider.Append(strVenda_ImpSeg & ";")
                strBuider.Append(strVenda_Premio & ";")
                strBuider.Append(strCCred_TFC & ";")
                strBuider.Append(strCCred_TFC_Bandeira & ";")
                strBuider.Append(strCCred_TFC_Numero & ";")
                strBuider.Append(strOferta & ";")
                strBuider.Append(strOferta_Cod_Ferrari & ";")
                strBuider.Append(strOferta_ImpSeg & ";")
                strBuider.Append(strOferta_Premio & ";")
                strBuider.Append(strN_Emitido & ";")
                strBuider.Append(strQtde_Parcelas & ";")
                strBuider.Append(strATM & ";")
                strBuider.Append(strSMS & ";")
                strBuider.Append(strClienteAgencia & ";")
                strBuider.Append(strMatriculaGerente & ";")
                strBuider.Append(strCodId_Motivo2 & ";")
                strBuider.Append(strAtrito_VendaNRec & ";")
                strBuider.Append(strAtrito_CancNEfetuado & ";")
                strBuider.Append(strLogradouro & ";")
                strBuider.Append(strNumero & ";")
                strBuider.Append(strComplemento & ";")
                strBuider.Append(strBairro & ";")
                strBuider.Append(strCidade & ";")
                strBuider.Append(strUF & ";")
                strBuider.Append(strCEP & ";")
                strBuider.Append(strTipo_Imovel & ";")
                strBuider.Append(strObs & ";")
                strBuider.Append(strOferta_Produto_VC & ";")
                strBuider.Append(strDataDebito & ";")
                strBuider.Append(strOferta_CodId_Plano & ";")
                strBuider.Append(strVenda_CodId_Plano)


                strCommand = strBuider.ToString

                strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\" & Environment.UserName & "_PF.txt"

                If File.Exists(strFile) Then
                    swFile = My.Computer.FileSystem.OpenTextFileWriter(strFile, True)
                Else
                    swFile = New StreamWriter(strFile)
                End If

                swFile.WriteLine(strCommand)
                swFile.Close()
                MessageBox.Show("Registro Salvo com sucesso!" & vbCrLf & "Protocolo: " & lngProtocolo, "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call btnLimparForm_Click(sender, New EventArgs)
                intDesfecho = 0


                'Dim lngRec As Long
                'lngRec = cls.Exec_Command_NQ(strCommand, 2)

                'If lngRec > 0 Then
                '    Dim lngProtocol As Long

                '    lngProtocol = fGetProtocolo(.FormataStringSQL(Environment.UserName, TipoDado.Texto))
                '    MessageBox.Show("Registro Salvo com sucesso!" & vbCrLf & "Protocolo: " & lngProtocol, "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Call btnLimparForm_Click(sender, New EventArgs)
                '    intDesfecho = 0
                'Else
                '    MessageBox.Show("Erro ao salvar ligação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'End If

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAtivar_Click(sender As Object, e As EventArgs) Handles btnAtivar.Click
        Try
            'Dim cls As New cls_SqlConnect
            Dim intErros As Integer

            If Panel8.Visible = True Then
                RemoveErrosPainel(Panel8)
                ZeraPainel(Panel8)
                ZeraPainel(Panel81)
                
            End If

            intErros = fValidaAtivarRet()

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
        Try

            Dim clsU As New cls_Utilities
            Dim strReturn As String
            Dim arrReturn As Array
            Dim intProduto As Integer
            Dim intApolice As Integer
            Dim strAtm As String
            Dim strFile As String

            If Not txtCodProdRector.Text = Nothing Then
                strFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Produtos_PF.xml"

                strReturn = clsU.GetProdutoPF_Xml(strFile, txtCodProdRector.Text)
                arrReturn = Split(strReturn, ";")

                intProduto = arrReturn(0)
                intApolice = arrReturn(1)
                strAtm = arrReturn(2)

                If intProduto = 0 Then
                    MessageBox.Show("Produto não cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodProdRector.Text = Nothing
                    chkATM.Visible = False
                    chkATM_N_Emitido.Visible = False
                    chkATM_N_Emitido.Checked = False
                    chkATM.Checked = False
                    txtGrupoProd.Text = Nothing
                Else
                    If intApolice > 0 Then
                        MessageBox.Show("Apolice: " & intApolice, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtApolice.Text = intApolice
                    End If
                    If strAtm = "True" Then
                        chkATM.Visible = True
                        chkATM_N_Emitido.Visible = True
                        chkATM_N_Emitido.Checked = False
                        chkATM.Checked = False
                        txtGrupoProd.Text = Nothing
                    Else
                        chkATM.Visible = False
                        chkATM_N_Emitido.Visible = False
                        chkATM_N_Emitido.Checked = False
                        chkATM.Checked = False
                        txtGrupoProd.Text = Nothing
                    End If

                End If
            Else
                chkATM.Visible = False
                chkATM_N_Emitido.Visible = False
                chkATM_N_Emitido.Checked = False
                chkATM.Checked = False
                txtGrupoProd.Text = Nothing

            End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


    End Sub

    Private Sub rbtnArgumentacao_CheckedChanged(sender As Object, e As EventArgs)
        Try

            Dim clsU As New cls_Utilities

            If rbtnArgumentacao.Checked = True Then
                cboMotivo.DataSource = Nothing
                rbtnCancelamento.Checked = False
                cboDesfecho.Text = "Retido"

                clsU.GetCboItems_Xml(cboMotivo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_Arg_PF.xml")

                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo.DroppedDown = True
            End If

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
    Private Sub rbtnCancelamento_CheckedChanged(sender As Object, e As EventArgs)
        Try

            Dim clsU As New cls_Utilities

            If rbtnCancelamento.Checked = True Then
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Não Retido"

                clsU.GetCboItems_Xml(cboMotivo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_Canc_PF.xml")

                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo.DroppedDown = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function fValidaAtivarRet() As Integer
        Try
            Dim intErros As Integer = 0

            If cboOrigem.SelectedIndex = -1 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", cboOrigem))
            Else
                campos.Add(New ValidCampo("", cboOrigem))
            End If
            If txtDDD.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtDDD))
            Else
                campos.Add(New ValidCampo("", txtDDD))
            End If
            If txtFone.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtFone))
            Else
                campos.Add(New ValidCampo("", txtFone))
            End If

            If chkSCelular.Checked = False Then

                If txtDDD2.Text = Nothing Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtDDD2))
                Else
                    campos.Add(New ValidCampo("", txtDDD2))
                End If
                If txtCel.Text = Nothing Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtCel))
                Else
                    campos.Add(New ValidCampo("", txtCel))
                End If
            Else
                campos.Add(New ValidCampo("", txtDDD2))
                campos.Add(New ValidCampo("", txtCel))
            End If

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
            ElseIf cboCorrentista.Text = "Não" AndAlso cboBanco.SelectedValue = "033" Then

                campos.Add(New ValidCampo("", txtCC))
            End If

            If cboSeg.SelectedIndex = -1 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", cboSeg))
            Else
                campos.Add(New ValidCampo("", cboSeg))
            End If

            If txtCPF.MaskCompleted = False Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtCPF))
            Else
                campos.Add(New ValidCampo("", txtCPF))
            End If
            If txtNome.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtNome))
            Else
                campos.Add(New ValidCampo("", txtNome))
            End If
            If txtDataNasc.MaskCompleted = False Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtDataNasc))
            Else
                campos.Add(New ValidCampo("", txtDataNasc))
            End If
            If txtCodProdRector.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtCodProdRector))
                txtCodProdRector.Text = Nothing
            Else
                campos.Add(New ValidCampo("", txtCodProdRector))
            End If
            If chkATM_N_Emitido.Checked = False Then
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
                If cboCateg.SelectedIndex = -1 Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", cboCateg))
                Else
                    campos.Add(New ValidCampo("", cboCateg))
                End If
                If txtPremio.Text = Nothing Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtPremio))
                ElseIf CDbl(txtPremio.Text) = 0 Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtPremio))
                Else
                    campos.Add(New ValidCampo("", txtPremio))
                End If
                If txtImpSeg.Text = Nothing Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtImpSeg))
                ElseIf CDbl(txtImpSeg.Text) = 0 Then
                    intErros += 1
                    campos.Add(New ValidCampo("Campo obrigatório", txtImpSeg))
                Else
                    campos.Add(New ValidCampo("", txtImpSeg))
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
            Else
                campos.Add(New ValidCampo("", txtDtIniVig))
                campos.Add(New ValidCampo("", txtDtFimVig))
                campos.Add(New ValidCampo("", txtProposta))
                campos.Add(New ValidCampo("", txtApolice))
                campos.Add(New ValidCampo("", txtCertificado))
                campos.Add(New ValidCampo("", cboCateg))
                campos.Add(New ValidCampo("", txtPremio))
                campos.Add(New ValidCampo("", txtImpSeg))
                campos.Add(New ValidCampo("", txtParcelas))
            End If

            Return intErros

        Catch ex As Exception
            Return 1
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub cboBanco_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboBanco.Validating

        Try

            If cboCorrentista.Text = "Não" AndAlso cboBanco.SelectedValue = "033" Then
                txtCC.Enabled = False
            Else
                txtCC.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboCorrentista_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCorrentista.Validating
        Try

            txtCC.Enabled = True
            txtAg.Text = Nothing
            txtCC.Text = Nothing

            If cboCorrentista.Text = "Não" Then
                cboBanco.Enabled = True
                cboBanco.SelectedIndex = -1
                cboBanco.DroppedDown = True
            Else
                cboBanco.Text = "033 - Banco Santander (Brasil) S.A."
                cboBanco.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDataNasc_Validated(sender As Object, e As EventArgs) Handles txtDataNasc.Validated
        Try

            Dim strDate As String
            If txtDataNasc.MaskCompleted = True Then
                strDate = Strings.Left(txtDataNasc.Text, 2) & "/" & Strings.Mid(txtDataNasc.Text, 3, 2) & "/" & Strings.Right(txtDataNasc.Text, 4)
                txtIdade.Text = DateAndTime.DateDiff(DateInterval.Day, CDate(strDate), Today) \ 365.25
            Else
                txtIdade.Text = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub txtCPF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCPF.Validating
        Try

            Dim clsU As New cls_Utilities

            If frm_MainForm_Off.Validade <= Now Then
                frm_MainForm_Off.SetSubForm(frm_Welcome_Off)
                MessageBox.Show("Senha expirada, solicite uma nova senha ao seu gestor...")
                Exit Sub
            End If

            If Not txtCPF.Text = Nothing Then

                If txtCPF.MaskCompleted = False Then
                    ErrProv.SetError(txtCPF, "Digite o CPF corretamente com todos os 11 dígitos!")
                    e.Cancel = True
                    MessageBox.Show("Digite o CPF corretamente com todos os 11 dígitos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf clsU.CPF(txtCPF.Text) = False Then
                    ErrProv.SetError(txtCPF, "CPF inválido!")
                    e.Cancel = True
                    MessageBox.Show("CPF inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    ErrProv.SetError(txtCPF, "")
                End If
            Else
                ErrProv.SetError(txtCPF, "")
                cboOrigem.SelectedIndex = -1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExibeErros(campos As List(Of ValidCampo))
        Try
            For Each vc In campos
                ErrProv.SetIconAlignment(vc.Origem, ErrorIconAlignment.TopRight)
                ErrProv.SetIconPadding(vc.Origem, -10)
                ErrProv.SetError(vc.Origem, vc.Msg)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub txtImpSeg_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtImpSeg.Validating
        Try
            If Not txtImpSeg.Text = Nothing And IsNumeric(txtImpSeg.Text) Then
                txtImpSeg.Text = FormatNumber(CDbl(txtImpSeg.Text), 2)
            Else
                txtImpSeg.Text = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimparAt_Click(sender As Object, e As EventArgs) Handles btnLimparAt.Click
        Try

            If Panel8.Visible = True Then
                RemoveErrosPainel(Panel8)
                ZeraPainel(Panel8)
                ZeraPainel(Panel81)
                lMotivo2.Visible = False
                cboMotivo2.Visible = False
                cboMotivo2.SelectedIndex = -1
                With Me
                    .CepRes = Nothing
                    .EnderecoRes = Nothing
                    .NroRes = Nothing
                    .ComplementoRes = Nothing
                    .BairroRes = Nothing
                    .CidadeRes = Nothing
                    .UFRes = Nothing
                    .TipoRes = Nothing
                    .GrupoVenda = Nothing
                    .ProdRectorVenda = Nothing
                    .ApoliceVenda = Nothing
                    .SegVenda = Nothing
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
                ElseIf cbo.Tag = "3" Then
                    cbo.SelectedValue = 9999
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
            ZeraPainel(Panel81)
            lMotivo.Visible = False
            cboMotivo.Visible = False
            lMotivo2.Visible = False
            cboMotivo2.Visible = False
            lMatricula.Visible = False
            txtMatricula.Visible = False

            Panel8.Visible = False
            Panel7.Visible = False
        End If
        RemoveErrosPainel(Panel6)
        ZeraPainel(Panel6)
        RemoveErrosPainel(Panel2)
        ZeraPainel(Panel2)
        txtCPF.Focus()
        intGrupo = 0
        intCodProdutoVC = 0
        intTipoResVenda = 0
        intCategVenda = 0
        intDesfecho = 0
        chkATM.Visible = False
        chkATM_N_Emitido.Visible = False
        chkATM_N_Emitido.Checked = False
        chkATM.Checked = False



    End Sub
    Enum TipoDado
        Texto = 0
        Numerico = 1
        Booleano = 2
        Datetime = 3
    End Enum
    Private Function fGetProtocolo(LoginOperador As String) As Long

        'Dim cls As New cls_SqlConnect
        'Dim strSql As String
        'Dim lngProtocolo As Long

        'strSql = "EXEC FRPF_SP_ID_LIGACAO " & LoginOperador

        'lngProtocolo = cls.Exec_Command_Scalar(strSql, 2)

        'Return lngProtocolo


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

    Private Sub txtPremio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPremio.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = ",") Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtImpSeg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImpSeg.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = ",") Then

            e.Handled = True

        End If
    End Sub

    Private Sub txtNome_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNome.Validating

        If Not txtNome.Text = Nothing Then
            txtNome.Text = UCase(txtNome.Text)
        End If

    End Sub
    Private Sub rbtnArgumentacao_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbtnArgumentacao.CheckedChanged
        Try

            Dim clsU As New cls_Utilities

            If rbtnArgumentacao.Checked = True Then

                cboMotivo.DataSource = Nothing
                cboDesfecho.Text = "Retido"

                clsU.GetCboItems_Xml(cboMotivo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_Arg_PF.xml")

                cboMotivo.Visible = True
                lMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo.DroppedDown = True
                cboMotivo2.Visible = False
            Else
                cboMotivo.Visible = False
                lMotivo.Visible = False
                cboMotivo2.Visible = False
                lMotivo2.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCCredito.CheckedChanged
        Try

            Dim clsU As New cls_Utilities

            If rbtnCCredito.Checked = True Then
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Retido"

                clsU.GetCboItems_Xml(cboMotivo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_CC_PF.xml")

                cboMotivo.Visible = True
                lMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo2.Visible = False
                'cboMotivo.DroppedDown = True
                frm_CartaoCredito.Tag = "off"
                frm_CartaoCredito.ShowDialog()

            Else
                cboMotivo.DataSource = Nothing
                cboMotivo.Visible = False
                lMotivo.Visible = False
                cboMotivo2.Visible = False
                lMotivo2.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCancelamento_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbtnCancelamento.CheckedChanged
        Try
            Dim clsU As New cls_Utilities

            If rbtnCancelamento.Checked = True Then
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Não Retido"

                clsU.GetCboItems_Xml(cboMotivo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Motivos_Canc_PF.xml")

                lMotivo.Visible = True
                cboMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo.DroppedDown = True
                lMotivo2.Visible = False
                cboMotivo2.Visible = False

                'Panel82.Visible = False
                'Panel83.Visible = False
                'Panel84.Visible = False
            Else
                cboMotivo.DataSource = Nothing
                cboMotivo.Visible = False
                lMotivo.Visible = False
                cboMotivo2.Visible = False
                lMotivo2.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnClienteAtrito_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnClienteAtrito.CheckedChanged
        Try

            If rbtnClienteAtrito.Checked = True Then

                cboDesfecho.SelectedValue = 0
                cboMotivo.DataSource = Nothing
                lMotivo.Visible = False
                cboMotivo.Visible = False
                lMotivo2.Visible = False
                cboMotivo2.Visible = False
                cboMotivo2.SelectedIndex = -1

                MessageBox.Show("ATENÇÂO: Este encaminhamento é exclusivo para situações de clientes em atrito, para estorno superior a 90 dias." + vbNewLine + "É OBRIGATÓRIO a aprovação do Supervisor para encaminhamento do chamado.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCancNEfetuado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCancNEfetuado.CheckedChanged
        Try

            If rbtnCancNEfetuado.Checked = True Then
                cboDesfecho.SelectedValue = 0
                cboMotivo.DataSource = Nothing
                lMotivo.Visible = False
                cboMotivo.Visible = False
                lMotivo2.Visible = False
                cboMotivo2.Visible = False
                cboMotivo2.SelectedIndex = -1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtParcelas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtParcelas.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If
    End Sub

    Private Sub cboMotivo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboMotivo.Validating
        If cboMotivo.SelectedValue = 3 Then
            lMotivo2.Visible = True
            cboMotivo2.Visible = True
            cboMotivo2.DroppedDown = True
        Else
            lMotivo2.Visible = False
            cboMotivo2.Visible = False
        End If
    End Sub

    Private Sub chkClienteAgencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkClienteAgencia.CheckedChanged
        If chkClienteAgencia.CheckState = CheckState.Checked Then
            lMatricula.Visible = True
            txtMatricula.Visible = True
        Else
            lMatricula.Visible = False
            txtMatricula.Visible = False

        End If
    End Sub


    Function fValidaAtendimento() As Boolean
        Try
            Dim strDesfecho As String = ""

            intDesfecho = 0

            If rbtnArgumentacao.Checked = True Then
                intDesfecho = 1
            End If

            If rbtnCCredito.Checked = True Then
                intDesfecho = 2
            End If

            If rbtnCancelamento.Checked = True Then
                intDesfecho = 3
            End If

            If rbtnClienteAtrito.Checked = True Then
                intDesfecho = 4

            End If
            If rbtnCancNEfetuado.Checked = True Then
                intDesfecho = 5
            End If

            If (rbtnClienteAtrito.Checked Or rbtnCancNEfetuado.Checked) And txtObs.Text = Nothing Then
                campos.Add(New ValidCampo("Campo obrigatório", txtObs))
                Return False
            End If

            If intDesfecho = 0 Then
                Return False
            ElseIf chkClienteAgencia.CheckState = CheckState.Checked And txtMatricula.Text = Nothing Then
                Return False
            Else
                'Argumentação
                If intDesfecho = 1 Then
                    If cboMotivo.SelectedIndex = -1 Then
                        Return False
                    Else
                        Return True
                    End If
                End If
                'Cartão de Crédito
                If intDesfecho = 2 Then
                    If cboMotivo.SelectedIndex = -1 Then
                        Return False
                    ElseIf txtCartaoBandeira.Text = Nothing Then
                        Return False
                    Else
                        Return True
                    End If
                End If
                'Cancelamento
                If intDesfecho = 3 Then
                    If cboMotivo.SelectedIndex = -1 Then
                        Return False
                    ElseIf cboMotivo.SelectedValue = 3 And cboMotivo2.SelectedIndex = -1 Then
                        Return False
                    Else
                        Return True
                    End If
                End If
                'Atrito
                If intDesfecho = 4 Then
                    Return True
                End If
                'Cancelamento não efetuado
                If intDesfecho = 5 Then
                    Return True
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function




    Private Sub txtCC_Enter(sender As Object, e As EventArgs) Handles txtCC.Enter

        Try

            If txtAg.Text = Nothing Then
                txtAg.Focus()
                MessageBox.Show("Digite a agência", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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

                        ErrProv.SetError(txtCC, "Conta corrente inválida!")
                        e.Cancel = True
                        MessageBox.Show("Conta corrente inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        ErrProv.SetError(txtCC, "")
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private strCep As String
    Public Property CepRes() As String
        Get
            Return strCep
        End Get
        Set(ByVal Value As String)
            strCep = Value
        End Set
    End Property
    Private strEndereco As String
    Public Property EnderecoRes() As String
        Get
            Return strEndereco
        End Get
        Set(ByVal Value As String)
            strEndereco = Value
        End Set
    End Property
    Private strNro As String
    Public Property NroRes() As String
        Get
            Return strNro
        End Get
        Set(ByVal Value As String)
            strNro = Value
        End Set
    End Property
    Private strComplemento As String
    Public Property ComplementoRes() As String
        Get
            Return strComplemento
        End Get
        Set(ByVal Value As String)
            strComplemento = Value
        End Set
    End Property
    Private strBairro As String
    Public Property BairroRes() As String
        Get
            Return strBairro
        End Get
        Set(ByVal Value As String)
            strBairro = Value
        End Set
    End Property
    Private strCidade As String
    Public Property CidadeRes() As String
        Get
            Return strCidade
        End Get
        Set(ByVal Value As String)
            strCidade = Value
        End Set
    End Property
    Private strUF As String
    Public Property UFRes() As String
        Get
            Return strUF
        End Get
        Set(ByVal Value As String)
            strUF = Value
        End Set
    End Property
    Private iTipoRes As Integer
    Public Property TipoRes() As Integer
        Get
            Return iTipoRes
        End Get
        Set(ByVal Value As Integer)
            iTipoRes = Value
        End Set
    End Property
    Private iGrupoVenda As Integer
    Public Property GrupoVenda() As Integer
        Get
            Return iGrupoVenda
        End Get
        Set(ByVal Value As Integer)
            iGrupoVenda = Value
        End Set
    End Property
    Private iApoliceVenda As Integer
    Public Property ApoliceVenda() As Integer
        Get
            Return iApoliceVenda
        End Get
        Set(ByVal Value As Integer)
            iApoliceVenda = Value
        End Set
    End Property
    Private iProdRectorVenda As Integer
    Public Property ProdRectorVenda() As Integer
        Get
            Return iProdRectorVenda
        End Get
        Set(ByVal Value As Integer)
            iProdRectorVenda = Value
        End Set
    End Property
    Private iSegVenda As Integer
    Public Property SegVenda() As Integer
        Get
            Return iSegVenda
        End Get
        Set(ByVal Value As Integer)
            iSegVenda = Value
        End Set
    End Property

    Private Sub chkATM_N_Emitido_CheckedChanged(sender As Object, e As EventArgs) Handles chkATM_N_Emitido.CheckedChanged
        Try
            Call DesativarRetencao(sender)
            If chkATM_N_Emitido.Checked = True Then
                chkATM.Checked = True
                btnAtivar.Focus()
                txtDtIniVig.Text = Nothing
                txtDtIniVig.Enabled = False
                txtDtFimVig.Text = Nothing
                txtDtFimVig.Enabled = False
                txtProposta.Text = Nothing
                txtProposta.Enabled = False
                txtApolice.Enabled = False
                txtCertificado.Text = Nothing
                txtCertificado.Enabled = False
                cboCateg.SelectedIndex = -1
                cboCateg.Enabled = False
                txtPremio.Text = Nothing
                txtPremio.Enabled = False
                txtImpSeg.Text = Nothing
                txtImpSeg.Enabled = False
                txtParcelas.Text = Nothing
                txtParcelas.Enabled = False
            Else
                btnAtivar.Focus()
                txtDtIniVig.Text = Nothing
                txtDtIniVig.Enabled = True
                txtDtFimVig.Text = Nothing
                txtDtFimVig.Enabled = True
                txtProposta.Text = Nothing
                txtProposta.Enabled = True
                txtApolice.Enabled = True
                txtCertificado.Text = Nothing
                txtCertificado.Enabled = True
                cboCateg.SelectedIndex = -1
                cboCateg.Enabled = True
                txtPremio.Text = Nothing
                txtPremio.Enabled = True
                txtImpSeg.Text = Nothing
                txtImpSeg.Enabled = True
                txtParcelas.Text = Nothing
                txtParcelas.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkATM_CheckedChanged(sender As Object, e As EventArgs) Handles chkATM.CheckedChanged
        Try
            Call DesativarRetencao(sender)
            If chkATM.Checked = False Then
                chkATM_N_Emitido.Checked = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtCodProdRector_TextChanged(sender As Object, e As EventArgs) Handles txtCodProdRector.TextChanged
        Call DesativarRetencao(sender)
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

    Private Sub cboCateg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCateg.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtPremio_TextChanged(sender As Object, e As EventArgs) Handles txtPremio.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtParcelas_TextChanged(sender As Object, e As EventArgs) Handles txtParcelas.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtImpSeg_TextChanged(sender As Object, e As EventArgs) Handles txtImpSeg.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtCPF_TextChanged(sender As Object, e As EventArgs) Handles txtCPF.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboOrigem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrigem.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub cboProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProf.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtDDD_TextChanged(sender As Object, e As EventArgs) Handles txtDDD.TextChanged, txtDDD2.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtFone_TextChanged(sender As Object, e As EventArgs) Handles txtFone.TextChanged, txtCel.TextChanged
        Call DesativarRetencao(sender)

        If Strings.Len(txtFone.Text) < 8 Then
            txtFone.Mask = "999999999"
        End If

    End Sub

    Private Sub txtRamal_TextChanged(sender As Object, e As EventArgs) Handles txtRamal.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtDataNasc_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtDataNasc.MaskInputRejected
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtIdade_TextChanged(sender As Object, e As EventArgs) Handles txtIdade.TextChanged
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

    Private Sub cboSeg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeg.SelectedIndexChanged
        Call DesativarRetencao(sender)
    End Sub


    Private Sub txtAg_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAg.Validating
        Dim intAg As Integer

        If txtAg.Text <> "" Then
            intAg = CInt(txtAg.Text)

            If intAg > 0 Then
                If txtAg.MaskCompleted = False Then
                    ErrProv.SetError(txtAg, "Digite a agência corretamente !")
                    e.Cancel = True
                    MessageBox.Show("Digite a agência corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    'Verifica se a agencia não possui numeros repetidos 1111, 2222 e etc
                    If fAgenciaInvalida(txtAg.Text) = False Then
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
    Private Function fAgenciaInvalida(ByVal txtAg As String) As Boolean

        Try

            Dim cls As New cls_SqlConnect
            Return False

        Catch ex As Exception
            Return True
        End Try

    End Function
    Private Function fContaInvalida(ByVal strBco As String, ByVal strAg As String, ByVal strCc As String) As Boolean

        Try

            Dim cls As New cls_SqlConnect
            Return False

        Catch ex As Exception
            Return True
        End Try

    End Function


    Private Sub txtFone_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFone.Validating

        Dim boolErro As Boolean = False

        If txtFone.Text <> "" Then

            If Strings.Len(txtFone.Text) = 8 Then 'Verifica se o numero é fixo e altera sua máscara
                txtFone.Mask = "0000-0000"
            ElseIf Strings.Len(txtFone.Text) = 9 Then 'Verifica se o numero é celular e altera sua máscara
                txtFone.Mask = "00000-0000"
            ElseIf (txtFone.Text = "" Or Strings.Len(txtFone.Text) < 8) And txtDDD.Text <> "" Then
                boolErro = True
                txtFone.Mask = "999999999"
            End If

            If txtFone.MaskCompleted = False Or boolErro = True Or fExisteRepetidos(txtFone.Text, 4) = True Then
                ErrProv.SetError(txtFone, "Digite o telefone corretamente !")
                e.Cancel = True
                MessageBox.Show("Digite o telefone corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                boolErro = False
            Else
                If Strings.Len(txtFone.Text) = 9 And txtCel.Text = "" Then
                    txtCel.Text = txtFone.Text
                    txtDDD2.Text = txtDDD.Text
                End If
                ErrProv.SetError(txtFone, "")
            End If

        Else
            ErrProv.SetError(txtFone, "")
        End If

    End Sub

    Private Sub txtCel_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCel.Validating

        If txtCel.Text <> "" Then
            If txtCel.MaskCompleted = False Or fExisteRepetidos(txtCel.Text, 4) = True Then
                ErrProv.SetError(txtCel, "Digite o celular corretamente !")
                e.Cancel = True
                MessageBox.Show("Digite a agência corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ErrProv.SetError(txtCel, "")

                If txtFone.Text = "" Then
                    txtFone.Text = txtCel.Text
                    txtDDD.Text = txtDDD2.Text
                End If
            End If
        Else
            ErrProv.SetError(txtCel, "")
        End If
    End Sub

    Private Sub txtDDD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDDD.Validating

        If txtDDD.Text <> "" Then
            If txtDDD.MaskCompleted = False Then
                ErrProv.SetError(txtDDD, "Digite o DDD corretamente !")
                e.Cancel = True
                MessageBox.Show("Digite o DDD corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ErrProv.SetError(txtDDD, "")
            End If
        Else
            ErrProv.SetError(txtDDD, "")
        End If

    End Sub

    Private Sub txtDDD2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDDD2.Validating

        If txtDDD2.Text <> "" Then
            If txtDDD2.MaskCompleted = False Then
                ErrProv.SetError(txtDDD2, "Digite o DDD corretamente !")
                e.Cancel = True
                MessageBox.Show("Digite o DDD corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ErrProv.SetError(txtDDD2, "")
            End If
        Else
            ErrProv.SetError(txtDDD2, "")
        End If

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
                    MessageBox.Show("Caractere inválido no certificado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtCertificado.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub chkSCelular_CheckedChanged(sender As Object, e As EventArgs) Handles chkSCelular.CheckedChanged
        If chkSCelular.Checked = True Then
            txtCel.Enabled = False
            txtDDD2.Enabled = False

            txtCel.Text = ""
            txtDDD2.Text = ""
        Else
            txtCel.Enabled = True
            txtDDD2.Enabled = True
        End If
    End Sub
End Class