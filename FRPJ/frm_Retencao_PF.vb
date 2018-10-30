Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Threading.Tasks

Public Class frm_Retencao_PF
    Private intGrupo As Integer = 0
    Private intCodProdutoVC As Integer = 0
    Dim intTipoResVenda As Integer = 0
    Dim intCategVenda As Integer = 0
    Dim campos As New List(Of ValidCampo)
    Dim utl As cls_Utilities
    Private intDesfecho = 0
    Private blnFarol As Boolean = False

    Private Sub frm_Retencao_PF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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
    Private Sub Panel82_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel82.Paint
        Try

            Panel82.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel82.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel83_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel83.Paint
        Try

            Panel83.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel83.ClientRectangle)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Panel84_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel84.Paint
        Try

            Panel84.BorderStyle = BorderStyle.None
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), Panel84.ClientRectangle)

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

    Private Sub frm_Retencao_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSqlCbo As String

            strSqlCbo = "EXEC FRPF_SP_RET_EPS_CBO"
            clsU.GetCboItems(strSqlCbo, cboOrigem, 2)

            strSqlCbo = "EXEC FRPJ_SP_CBO_BANCOS"
            clsU.GetCboItems(strSqlCbo, cboBanco)
            cboBanco.DropDownWidth = 300
            cboBanco.SelectedValue = 33
            cboBanco.Enabled = False

            strSqlCbo = "EXEC FRPF_SP_PROFISSAO_CBO"
            clsU.GetCboItems(strSqlCbo, cboProf, 2)
            cboProf.SelectedValue = 9999

            strSqlCbo = "EXEC FRPF_SP_RET_SEGMENTOS_CBO"
            clsU.GetCboItems(strSqlCbo, cboSeg, 2)

            'strSqlCbo = "EXEC FRPF_SP_RET_CATEGORIAS_CBO"
            'clsU.GetCboItems(strSqlCbo, cboCateg, 2)
           

            strSqlCbo = "EXEC FRPF_SP_CANC_MOTIVOS2_CBO"
            clsU.GetCboItems(strSqlCbo, cboMotivo2, 2)

            Dim lstItems As New List(Of String)
            lstItems.AddRange({"Não", "Sim"})
            clsU.GetCboItems_List(cboCorrentista, lstItems)
            cboCorrentista.SelectedValue = 1

            Dim lstItems1 As New List(Of String)
            lstItems1.AddRange({"Não Retido", "Retido"})
            clsU.GetCboItems_List(cboDesfecho, lstItems1)
            cboDesfecho.Enabled = False

            Dim lstItems2 As New List(Of String)
            lstItems2.AddRange({"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
            clsU.GetCboItems_List(cboDiaDebito, lstItems2)

            imgFarol.Image = My.Resources.GREEN

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
            Dim strDDD2 As String = "null"
            Dim strCel As String = "null"
            Dim strRamal As String = "null"
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
            Dim strCancelamento As String = "0"
            Dim strEndosso As String = "0"
            Dim strRetido As String = "0"
            Dim strCodId_Motivo As String = "null"
            Dim strCanc_Local As String = "null"
            Dim strCanc_Data As String = "null"
            Dim strCanc_Codigo As String = "null"
            Dim strAlcada As String = "0"
            Dim strAlcadaValor As String = "null"
            Dim strAlcadaDias As String = "null"
            Dim arrRegra As Array
            Dim strRegra As String
            Dim arrAlcada As Array
            Dim strAlcadas As String
            Dim strEndosso_ImpSeg As String = "NULL"
            Dim strEndosso_Premio As String = "NULL"
            Dim strVenda As String = "0"
            Dim strVenda_Produto_VC As String = "NULL"
            Dim strVenda_ImpSeg As String = "NULL"
            Dim strVenda_Premio As String = "NULL"
            Dim strCCred_TFC As String = "0"
            Dim strCCred_TFC_Bandeira As String = "NULL"
            Dim strCCred_TFC_Numero As String = "NULL"
            Dim strOferta As String = "0"
            Dim strOferta_Cod_Ferrari As String = "NULL"
            Dim strOferta_ImpSeg As String = "NULL"
            Dim strOferta_Premio As String = "NULL"
            Dim strN_Emitido As String = "0"
            Dim strQtde_Parcelas As String = "NULL"
            Dim strATM As String = "0"
            Dim strSMS As String = "0"
            Dim strClienteAgencia As String = "0"
            Dim strMatriculaGerente As String = "NULL"
            Dim strCodId_Motivo2 As String = "NULL"
            Dim strAtrito_VendaNRec As String = "0"
            Dim strAtrito_CancNEfetuado As String = "0"
            Dim strLogradouro As String = "NULL"
            Dim strNumero As String = "NULL"
            Dim strComplemento As String = "NULL"
            Dim strBairro As String = "NULL"
            Dim strCidade As String = "NULL"
            Dim strUF As String = "NULL"
            Dim strCEP As String = "NULL"
            Dim strTipo_Imovel As String = "NULL"
            Dim strObs As String = "NULL"
            Dim strOferta_Produto_VC As String = "NULL"
            Dim strDataDebito As String = "NULL"
            Dim strOferta_CodId_Plano As String = "NULL"
            Dim strVenda_CodId_Plano As String = "NULL"
            Dim strProtocoloSAC As String = "NULL"

            If Panel8.Visible = False Then
                Throw New Exception("Favor preencher os dados obrigatórios!")
            End If
            If fValidaAtendimento() = False Then
                ExibeErros(campos)
                Throw New Exception("Favor selecionar todos os dados para o desfecho do atendimento!")
            End If

            
            With utl
                'strCnpj = .FormataStringSQL(txtCnpj.Text, TipoDado.Numerico)
                'strRazaoSocial = .FormataStringSQL(txtRS.Text, TipoDado.Texto)
                strDDD = .FormataStringSQL(txtDDD.Text, TipoDado.Texto)
                strFone = .FormataStringSQL(txtFone.Text, TipoDado.Texto)
                strRamal = .FormataStringSQL(txtRamal.Text, TipoDado.Texto)
                strDDD2 = .FormataStringSQL(txtDDD2.Text, TipoDado.Texto)
                strCel = .FormataStringSQL(txtCel.Text, TipoDado.Texto)
                strEmail = .FormataStringSQL(txtEmail.Text, TipoDado.Texto)
                strProtocoloSAC = .FormataStringSQL(txtProtocoloSac.Text, TipoDado.Numerico)

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

                strBanco = .FormataStringSQL(cboBanco.SelectedValue, TipoDado.Numerico)
                strAgencia = .FormataStringSQL(txtAg.Text, TipoDado.Numerico)

                If txtCC.Enabled = True Then
                    strContaCorrente = .FormataStringSQL(Strings.Left(txtCC.Text, Len(txtCC.Text) - 1), TipoDado.Numerico)
                    strDG = .FormataStringSQL(Strings.Right(txtCC.Text, 1), TipoDado.Numerico)
                End If

                strCodId_Segmento_Fk = .FormataStringSQL(cboSeg.SelectedValue, TipoDado.Numerico)
                strCpf = .FormataStringSQL(txtCPF.Text, TipoDado.Numerico)
                strNome = .FormataStringSQL(txtNome.Text, TipoDado.Texto)
                'strCodId_Cargo_Fk = .FormataStringSQL(cboCargo.SelectedValue, TipoDado.Numerico)
                Dim strDate As String = Strings.Left(txtDataNasc.Text, 2) & "/" & Strings.Mid(txtDataNasc.Text, 3, 2) & "/" & Strings.Right(txtDataNasc.Text, 4)
                strDataNasc = .FormataStringSQL(strDate, TipoDado.Datetime)
                strIdade = .FormataStringSQL(txtIdade.Text, TipoDado.Numerico)
                strCodProduto_Rector = .FormataStringSQL(txtCodProdRector.Text, TipoDado.Numerico)
                strCodProduto_VC = .FormataStringSQL(intCodProdutoVC, TipoDado.Numerico)
                strCodId_Prod_Grupo_Fk = .FormataStringSQL(intGrupo, TipoDado.Numerico)
                If chkATM_N_Emitido.Checked = False Then
                    strDate = Strings.Left(txtDtIniVig.Text, 2) & "/" & Strings.Mid(txtDtIniVig.Text, 3, 2) & "/" & Strings.Right(txtDtIniVig.Text, 4)
                    strDataIniVig = .FormataStringSQL(strDate, TipoDado.Datetime)
                    strDate = Strings.Left(txtDtFimVig.Text, 2) & "/" & Strings.Mid(txtDtFimVig.Text, 3, 2) & "/" & Strings.Right(txtDtFimVig.Text, 4)
                    strDataFimVig = .FormataStringSQL(strDate, TipoDado.Datetime)
                    strProposta = .FormataStringSQL(txtProposta.Text, TipoDado.Numerico)
                    strApolice = .FormataStringSQL(txtApolice.Text, TipoDado.Numerico)
                    strCertificado = .FormataStringSQL(txtCertificado.Text, TipoDado.Numerico)
                    strCodId_Categoria_Fk = .FormataStringSQL(cboCateg.SelectedValue, TipoDado.Numerico)
                    strPremio = .FormataStringSQL(txtPremio.Text, TipoDado.Numerico)
                    strImpSegurada = .FormataStringSQL(txtImpSeg.Text, TipoDado.Numerico)
                    'strQtde_Parcelas = .FormataStringSQL(txtParcelas.Text, TipoDado.Numerico)
                End If

                strObs = .FormataStringSQL(txtObs.Text, TipoDado.Texto)

                If cboDesfecho.Text = "Retido" Then
                    strRetido = "1"
                Else
                    strRetido = "0"
                End If

                Select Case intDesfecho
                    Case Is = 1 'Argumentação
                        strArgumentacao = "1"
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)
                    Case Is = 2 'Cartão de Crédito
                        strCCred_TFC = "1"
                        strCCred_TFC_Bandeira = .FormataStringSQL(txtCartaoBandeira.Text, TipoDado.Numerico)
                        strCCred_TFC_Numero = .FormataStringSQL(txtCartaoNumero.Text, TipoDado.Numerico)
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)
                    Case Is = 3 'Cancelamento
                        If chkATM_N_Emitido.Checked = True Then
                            strN_Emitido = "1"
                            strCancelamento = "0"
                        Else
                            strCancelamento = "1"
                        End If

                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)
                        If cboMotivo.SelectedValue = 3 Then
                            strCodId_Motivo2 = .FormataStringSQL(cboMotivo2.SelectedValue, TipoDado.Numerico)
                        End If
                        strRegra = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_CANC_REGRA @CodId_Motivo=" & strCodId_Motivo & ", @CodId_Grupo=" & strCodId_Prod_Grupo_Fk, 2)
                        arrRegra = Split(strRegra, ";")

                        strCanc_Local = arrRegra(0).ToString
                        strCanc_Data = arrRegra(1).ToString
                        strCanc_Codigo = arrRegra(2).ToString
                        strAlcada = arrRegra(3).ToString

                        strAlcadas = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_ALCADA @CodId_Produto_Grupo=" & strCodId_Prod_Grupo_Fk, 2)
                        arrAlcada = Split(strAlcadas, ";")

                        strAlcadaValor = arrAlcada(0).ToString
                        strAlcadaDias = arrAlcada(1).ToString
                    Case Is = 4 'Cliente em Atrito
                        strAtrito_VendaNRec = "1"
                    Case Is = 5 'Cancelamento não efetuado
                        strAtrito_CancNEfetuado = "1"
                    Case Is = 6 'Oferta

                        If chkATM_N_Emitido.Checked = True Then
                            strN_Emitido = "1"
                            strCancelamento = "0"
                        Else
                            strCancelamento = "1"
                        End If

                        strOferta = "1"
                        strOferta_Cod_Ferrari = .FormataStringSQL(cboOferta.SelectedValue, TipoDado.Numerico)
                        strOferta_ImpSeg = .FormataStringSQL(txtImpSegOferta.Text, TipoDado.Numerico)
                        strOferta_Premio = .FormataStringSQL(txtPremioOferta.Text, TipoDado.Numerico)
                        strOferta_Produto_VC = .FormataStringSQL(cboOfertaProd.SelectedValue, TipoDado.Texto)
                        strDataDebito = .FormataStringSQL(txtDataDebito.Text, TipoDado.Datetime)
                        'regra para cancelamento
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)
                        strRegra = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_CANC_REGRA @CodId_Motivo=" & strCodId_Motivo & ", @CodId_Grupo=" & strCodId_Prod_Grupo_Fk, 2)
                        arrRegra = Split(strRegra, ";")

                        strCanc_Local = arrRegra(0).ToString
                        strCanc_Data = arrRegra(1).ToString
                        strCanc_Codigo = arrRegra(2).ToString
                        strAlcada = arrRegra(3).ToString

                        strAlcadas = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_ALCADA @CodId_Produto_Grupo=" & strCodId_Prod_Grupo_Fk, 2)
                        arrAlcada = Split(strAlcadas, ";")

                        strAlcadaValor = arrAlcada(0).ToString
                        strAlcadaDias = arrAlcada(1).ToString
                        strOferta_CodId_Plano = .FormataStringSQL(cboOfertaPlan.SelectedValue, TipoDado.Numerico)

                    Case Is = 7 'Endosso
                        strEndosso = "1"
                        strEndosso_ImpSeg = .FormataStringSQL(txtImpSegEndosso.Text, TipoDado.Numerico)
                        strEndosso_Premio = .FormataStringSQL(txtPremioEndosso.Text, TipoDado.Numerico)
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)
                    Case Is = 8 'Venda
                        If chkATM_N_Emitido.Checked = True Then
                            strN_Emitido = "1"
                            strCancelamento = "0"
                        Else
                            strCancelamento = "1"
                        End If

                        strVenda = "1"
                        strVenda_Produto_VC = .FormataStringSQL(cboProdutoVenda.SelectedValue, TipoDado.Texto)
                        strVenda_ImpSeg = .FormataStringSQL(txtImpSegVenda.Text, TipoDado.Numerico)
                        strVenda_Premio = .FormataStringSQL(txtPremioVenda.Text, TipoDado.Numerico)
                        strDataDebito = .FormataStringSQL(txtDataDebito.Text, TipoDado.Datetime)
                        'regra para cancelamento
                        strCodId_Motivo = .FormataStringSQL(cboMotivo.SelectedValue, TipoDado.Numerico)
                        strRegra = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_CANC_REGRA @CodId_Motivo=" & strCodId_Motivo & ", @CodId_Grupo=" & strCodId_Prod_Grupo_Fk, 2)
                        arrRegra = Split(strRegra, ";")

                        strCanc_Local = arrRegra(0).ToString
                        strCanc_Data = arrRegra(1).ToString
                        strCanc_Codigo = arrRegra(2).ToString
                        strAlcada = arrRegra(3).ToString

                        strAlcadas = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_ALCADA @CodId_Produto_Grupo=" & strCodId_Prod_Grupo_Fk, 2)
                        arrAlcada = Split(strAlcadas, ";")

                        strAlcadaValor = arrAlcada(0).ToString
                        strAlcadaDias = arrAlcada(1).ToString
                        strVenda_CodId_Plano = .FormataStringSQL(cboPlanoVenda.SelectedValue, TipoDado.Numerico)

                        If Me.GrupoVenda = 3 Then
                            strCEP = .FormataStringSQL(Me.CepRes, TipoDado.Texto)
                            strLogradouro = .FormataStringSQL(Me.EnderecoRes, TipoDado.Texto)
                            strNumero = .FormataStringSQL(Me.NroRes, TipoDado.Texto)
                            If Not String.IsNullOrEmpty(Me.ComplementoRes) Then
                                strComplemento = .FormataStringSQL(Me.ComplementoRes, TipoDado.Texto)
                            End If
                            .FormataStringSQL(Me.ComplementoRes, TipoDado.Texto)
                            strBairro = .FormataStringSQL(Me.BairroRes, TipoDado.Texto)
                            strCidade = .FormataStringSQL(Me.CidadeRes, TipoDado.Texto)
                            strUF = .FormataStringSQL(Me.UFRes, TipoDado.Texto)
                            strTipo_Imovel = .FormataStringSQL(Me.TipoRes, TipoDado.Numerico)
                        End If

                End Select

                If chkClienteAgencia.Checked = True Then
                    strClienteAgencia = "1"
                    strMatriculaGerente = .FormataStringSQL(txtMatricula.Text, TipoDado.Texto)
                End If

                strBuider.AppendLine(" EXEC FRPF_SP_INSERT_ATENDIMENTO ")
                strBuider.AppendLine("@Cnpj=" & strCnpj & ",")
                strBuider.AppendLine("@RazaoSocial=" & strRazaoSocial & ",")
                strBuider.AppendLine("@DDD=" & strDDD & ",")
                strBuider.AppendLine("@Fone=" & strFone & ",")
                strBuider.AppendLine("@Ramal=" & strRamal & ",")
                strBuider.AppendLine("@DDD2=" & strDDD2 & ",")
                strBuider.AppendLine("@Cel=" & strCel & ",")
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
                strBuider.AppendLine("@Endosso_ImpSeg=" & strEndosso_ImpSeg & ",")
                strBuider.AppendLine("@Endosso_Premio=" & strEndosso_Premio & ",")
                strBuider.AppendLine("@Venda=" & strVenda & ",")
                strBuider.AppendLine("@Venda_Produto_VC=" & strVenda_Produto_VC & ",")
                strBuider.AppendLine("@Venda_ImpSeg=" & strVenda_ImpSeg & ",")
                strBuider.AppendLine("@Venda_Premio=" & strVenda_Premio & ",")
                strBuider.AppendLine("@CCred_TFC=" & strCCred_TFC & ",")
                strBuider.AppendLine("@CCred_TFC_Bandeira=" & strCCred_TFC_Bandeira & ",")
                strBuider.AppendLine("@CCred_TFC_Numero=" & strCCred_TFC_Numero & ",")
                strBuider.AppendLine("@Oferta=" & strOferta & ",")
                strBuider.AppendLine("@Oferta_Cod_Ferrari=" & strOferta_Cod_Ferrari & ",")
                strBuider.AppendLine("@Oferta_ImpSeg=" & strOferta_ImpSeg & ",")
                strBuider.AppendLine("@Oferta_Premio=" & strOferta_Premio & ",")
                strBuider.AppendLine("@N_Emitido=" & strN_Emitido & ",")
                strBuider.AppendLine("@Qtde_Parcelas=" & strQtde_Parcelas & ",")
                strBuider.AppendLine("@ATM=" & strATM & ",")
                strBuider.AppendLine("@SMS=" & strSMS & ",")
                strBuider.AppendLine("@ClienteAgencia=" & strClienteAgencia & ",")
                strBuider.AppendLine("@MatriculaGerente=" & strMatriculaGerente & ",")
                strBuider.AppendLine("@CodId_Motivo2=" & strCodId_Motivo2 & ",")
                strBuider.AppendLine("@Atrito_VendaNRec=" & strAtrito_VendaNRec & ",")
                strBuider.AppendLine("@Atrito_CancNEfetuado=" & strAtrito_CancNEfetuado & ",")
                strBuider.AppendLine("@Logradouro=" & strLogradouro & ",")
                strBuider.AppendLine("@Numero=" & strNumero & ",")
                strBuider.AppendLine("@Complemento=" & strComplemento & ",")
                strBuider.AppendLine("@Bairro=" & strBairro & ",")
                strBuider.AppendLine("@Cidade=" & strCidade & ",")
                strBuider.AppendLine("@UF=" & strUF & ",")
                strBuider.AppendLine("@CEP=" & strCEP & ",")
                strBuider.AppendLine("@Tipo_Imovel=" & strTipo_Imovel & ",")
                strBuider.AppendLine("@Obs=" & strObs & ",")
                strBuider.AppendLine("@Oferta_Produto_VC=" & strOferta_Produto_VC & ",")
                strBuider.AppendLine("@DataDebito=" & strDataDebito & ",")
                strBuider.AppendLine("@Oferta_CodId_Plano=" & strOferta_CodId_Plano & ",")
                strBuider.AppendLine("@Venda_CodId_Plano=" & strVenda_CodId_Plano)

                strCommand = strBuider.ToString

                Dim lngRec As Long
                lngRec = cls.Exec_Command_NQ(strCommand, 2)

                If lngRec > 0 Then
                    Dim lngProtocol As Long

                    lngProtocol = fGetProtocolo(.FormataStringSQL(Environment.UserName, TipoDado.Texto))
                    MessageBox.Show("Registro Salvo com sucesso!" & vbCrLf & "Protocolo: " & lngProtocol, "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call btnLimparForm_Click(sender, New EventArgs)
                    intDesfecho = 0
                Else
                    MessageBox.Show("Erro ao salvar ligação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAtivar_Click(sender As Object, e As EventArgs) Handles btnAtivar.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim intErros As Integer
            Dim arrGrupo As Array
            Dim strGrupo As String
            Dim j As Integer
            Dim i As Integer
            Dim strPanel As String
            Dim strVisible As String
            Dim blnSimulador As Boolean

            If Panel8.Visible = True Then
                RemoveErrosPainel(Panel8)
                ZeraPainel(Panel8)
                ZeraPainel(Panel81)
                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
            End If

            intErros = fValidaAtivarRet()

            If intErros > 0 Then

                ExibeErros(campos)
                Throw New Exception(String.Format("{0} campos sem preenchimento.", intErros))
                Me.Panel7.Visible = False
                Me.Panel8.Visible = False
                btnSimular.Enabled = False
            Else
                ExibeErros(campos)
                Me.Panel7.Visible = True
                Me.Panel8.Visible = True
                strGrupo = cls.Exec_Command_Scalar("FRPF_SP_GET_OPTIONS " & intGrupo, 2)
                arrGrupo = Split(strGrupo, ";")

                j = UBound(arrGrupo)

                For i = 0 To j

                    strPanel = Strings.Left(arrGrupo(i).ToString, Len(arrGrupo(i).ToString) - 1)
                    strVisible = Strings.Right(arrGrupo(i).ToString, 1)

                    If strVisible = "1" Then
                        Me.Panel8.Controls(strPanel).Visible = True
                    Else
                        Me.Panel8.Controls(strPanel).Visible = False
                    End If
                Next

                blnSimulador = CBool(cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_GRUPO_SIMULADOR @CodId_Grupo=" & intGrupo, 2))
                If blnSimulador = True Then
                    btnSimular.Enabled = True
                Else
                    btnSimular.Enabled = False
                End If



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txtCodProdRector_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCodProdRector.Validating
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strGrupo As String
            Dim arrGrupo As Array
            Dim intApolice As Integer = 0
            Dim intATM As Integer = 0
            Dim strSql As String
            Dim strSqlCbo As String
            Dim intClasse As Integer = 0
            Dim intFarol As Integer = 0

            If Not txtCodProdRector.Text = Nothing Then

                strGrupo = cls.Exec_Command_Scalar("FRPF_SP_GET_GRUPO " & txtCodProdRector.Text, 2)

                If strGrupo = Nothing Then
                    MessageBox.Show("Produto não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtCodProdRector.Text = Nothing
                    txtGrupoProd.Text = Nothing
                    intGrupo = 0
                    chkATM.Visible = False
                    chkATM_N_Emitido.Visible = False
                    chkATM_N_Emitido.Checked = False
                    chkATM.Checked = False
                Else
                    arrGrupo = Split(strGrupo, " - ")
                    txtGrupoProd.Text = arrGrupo(1).ToString
                    intGrupo = CInt(arrGrupo(0))
                    intApolice = CInt(arrGrupo(2))
                    intCodProdutoVC = CInt(arrGrupo(3))

                    strSqlCbo = "EXEC FRPF_SP_RET_CATEGORIAS_CBO2 @CodProdutoVC=" & intCodProdutoVC
                    clsU.GetCboItems(strSqlCbo, cboCateg, 2)

                    If intApolice > 0 Then
                        txtApolice.Text = intApolice
                        MessageBox.Show("Apólice: " & intApolice, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        txtApolice.Text = Nothing
                    End If

                    strSql = "EXEC FRPF_SP_GET_ATM_SMS " & txtCodProdRector.Text
                    intATM = cls.Exec_Command_Scalar(strSql, 2)
                    If intATM > 0 Then
                        chkATM.Visible = True
                        chkATM_N_Emitido.Visible = True
                        chkATM_N_Emitido.Checked = False
                        chkATM.Checked = False
                    Else
                        chkATM.Visible = False
                        chkATM_N_Emitido.Visible = False
                        chkATM_N_Emitido.Checked = False
                        chkATM.Checked = False
                    End If

                    strSql = "SELECT ISNULL(Classe,0) FROM tbl_Produto WHERE CodProduto=" & intCodProdutoVC

                    intClasse = cls.Exec_Command_Scalar(strSql, 2)

                    If intClasse = 1 Then

                        strSql = "SELECT Estrela FROM tbl_Segmento_Farol WHERE Farol_G=" & txtCPF.Text

                        intFarol = cls.Exec_Command_Scalar(strSql, 2)

                        Select Case intFarol
                            Case 1
                                imgFarol.Image = My.Resources.GREEN
                                lblFarol.Text = "Reter este cliente com argumentação, benefícios e contra argumentação"
                                imgFarol.Visible = True
                                lblFarol.Visible = True
                                blnFarol = True
                            Case 2
                                imgFarol.Image = My.Resources.YELLOW
                                lblFarol.Text = "RETER este cliente com ARGUMENTAÇÃO"
                                imgFarol.Visible = True
                                lblFarol.Visible = True
                                blnFarol = True
                            Case 3
                                imgFarol.Image = My.Resources.RED
                                lblFarol.Text = "Atendimento e cancelamento SEM RETENÇÃO"
                                imgFarol.Visible = True
                                lblFarol.Visible = True
                                blnFarol = True
                            Case Else
                                imgFarol.Image = Nothing
                                lblFarol.Text = Nothing
                                imgFarol.Visible = False
                                lblFarol.Visible = False
                                blnFarol = False
                        End Select
                    Else
                        imgFarol.Image = Nothing
                        lblFarol.Text = Nothing
                        imgFarol.Visible = False
                        lblFarol.Visible = False
                        blnFarol = False
                    End If

                End If

            Else
                intGrupo = 0
                txtGrupoProd.Text = Nothing
                chkATM.Visible = False
                chkATM_N_Emitido.Visible = False
                chkATM_N_Emitido.Checked = False
                chkATM.Checked = False
                cboCateg.DataSource = Nothing
                imgFarol.Image = Nothing
                lblFarol.Text = Nothing
                imgFarol.Visible = False
                lblFarol.Visible = False
                blnFarol = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub rbtnArgumentacao_CheckedChanged(sender As Object, e As EventArgs)
        Try

            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities

            If rbtnArgumentacao.Checked = True Then
                cboMotivo.DataSource = Nothing
                rbtnCancelamento.Checked = False
                cboDesfecho.Text = "Retido"
                strSqlCbo = "EXEC FRPJ_SP_RET_MOTIVOS_CBO @CodId_TipoRet=3,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo)
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo.DroppedDown = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbtnCancelamento_CheckedChanged(sender As Object, e As EventArgs)
        Try

            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities

            If rbtnCancelamento.Checked = True Then
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Não Retido"
                strSqlCbo = "EXEC FRPJ_SP_RET_MOTIVOS_CBO @CodId_TipoRet=1,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo)
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

            'If txtProtocoloSac.Text = Nothing Then
            '    intErros += 1
            '    campos.Add(New ValidCampo("Campo obrigatório", txtProtocoloSac))
            'Else
            '    campos.Add(New ValidCampo("", txtProtocoloSac))
            'End If

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
            If txtCodProdRector.Text = Nothing Or intGrupo = 0 Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtCodProdRector))
                txtCodProdRector.Text = Nothing
            Else
                campos.Add(New ValidCampo("", txtCodProdRector))
            End If
            If (rbtnClienteAtrito.Checked Or rbtnCancNEfetuado.Checked) And txtObs.Text = Nothing Then
                intErros += 1
                campos.Add(New ValidCampo("Campo obrigatório", txtObs))
            Else
                campos.Add(New ValidCampo("", txtObs))
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
    Private Function fVersaoCorreta(ByVal strVersao As String) As Boolean
        Try
            Dim cls As New cls_SqlConnect
            Return cls.Exec_Command_Scalar("SELECT Versao FROM dbo.FRPJ_FN_GET_VERSAO(" & strVersao & ")")
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub txtCPF_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCPF.Validating
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

                    ZeraPainel(Panel6)
                    imgFarol.Image = Nothing
                    lblFarol.Text = Nothing
                    imgFarol.Visible = False
                    lblFarol.Visible = False
                    blnFarol = False

                    strSql = "EXEC FRPJ_SP_CLIENTES_GET_SEGMENTO " & txtCPF.Text
                    intSelect = cls.Exec_Command_Scalar(strSql)

                    Select Case intSelect
                        Case Is = 0
                            Me.imgSelect.Visible = False
                            Me.cboSeg.Enabled = True
                            Me.cboSeg.SelectedIndex = -1
                        Case Is = 1
                            Me.imgSelect.Visible = False
                            Me.cboSeg.SelectedValue = 1
                            Me.cboSeg.Enabled = False
                        Case Is = 2
                            Me.imgSelect.Visible = False
                            Me.cboSeg.SelectedValue = 1
                            Me.cboSeg.Enabled = False
                        Case Is = 3
                            Me.imgSelect.Visible = False
                            Me.cboSeg.SelectedValue = 3
                            Me.cboSeg.Enabled = False
                        Case Is = 4
                            Me.imgSelect.Visible = True
                            Me.cboSeg.SelectedValue = 4
                            Me.cboSeg.Enabled = False
                    End Select

                    strSql = "EXEC FRPF_SP_GET_ORIGEM_USER '" & Environment.UserName & "'"
                    intOrigem = cls.Exec_Command_Scalar(strSql, 2)
                    cboOrigem.SelectedValue = intOrigem

                    strSql = "EXEC FRPJ_SP_GET_ALERTA " & txtCPF.Text
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

                    dtr = cls.Return_DataReader("EXEC FRPF_SP_GET_ULTIMA_LIGACAO " & txtCPF.Text, 2)

                    If dtr.HasRows Then
                        dtr.Read()
                        txtNome.Text = dtr.Item("Nome").ToString
                        txtEmail.Text = dtr.Item("Email").ToString
                        txtProtocoloSac.Text = dtr.Item("Num_Protocolo_SAC").ToString
                        cboProf.SelectedValue = 9999
                        txtDDD.Text = dtr.Item("DDD").ToString
                        txtFone.Text = dtr.Item("Fone").ToString
                        txtRamal.Text = IIf(String.IsNullOrEmpty(dtr.Item("Ramal").ToString) = True, Nothing, dtr.Item("Ramal").ToString)
                        txtDDD2.Text = IIf(dtr.Item("DDD2").ToString = Nothing, Nothing, dtr.Item("DDD2").ToString)
                        txtCel.Text = IIf(dtr.Item("Celular").ToString = Nothing, Nothing, dtr.Item("Celular").ToString)
                        txtDataNasc.Text = dtr.Item("DataNasc").ToString
                        Call txtDataNasc_Validated(sender, New System.EventArgs)
                        cboCorrentista.Text = dtr.Item("Correntista").ToString
                        cboBanco.SelectedValue = CInt(dtr.Item("Banco"))
                        txtAg.Text = dtr.Item("Agencia").ToString
                        txtCC.Text = dtr.Item("ContaCorrente").ToString
                        If intSelect = 0 Then
                            cboSeg.SelectedValue = dtr.Item("Segmento")
                        End If

                        Call cboBanco_Validating(sender, e)

                        strBuider.AppendLine("Última ligação: " & dtr.Item("LigacaoData"))
                        strBuider.AppendLine("Produto: " & dtr.Item("NomeProduto"))
                        If dtr.Item("N_Emitido") = 0 Then
                            strBuider.AppendLine("Proposta: " & dtr.Item("Proposta"))
                            strBuider.AppendLine("Apólice: " & dtr.Item("Apolice"))
                            strBuider.AppendLine("Certificado: " & dtr.Item("Certificado"))
                            strBuider.AppendLine("Prêmio: " & dtr.Item("Premio"))
                            strBuider.AppendLine("Imp. Segurada: " & dtr.Item("ImpSegurada"))
                        Else
                            strBuider.AppendLine("Atenção: ATM Não Emitido")
                        End If
                        strBuider.AppendLine("Desfecho: " & dtr.Item("Retido"))

                        strMsg = strBuider.ToString

                        MessageBox.Show(strMsg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        txtCodProdRector.Focus()
                    Else
                        txtNome.Focus()
                    End If

                    dtr.Close()
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
                ZeraPainel(Panel82)
                ZeraPainel(Panel821)
                ZeraPainel(Panel83)
                ZeraPainel(Panel831)
                ZeraPainel(Panel84)
                ZeraPainel(Panel841)
                lMotivo2.Visible = False
                cboMotivo2.Visible = False
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
            ZeraPainel(Panel82)
            ZeraPainel(Panel821)
            ZeraPainel(Panel83)
            ZeraPainel(Panel831)
            ZeraPainel(Panel84)
            ZeraPainel(Panel841)
            lMotivo.Visible = False
            cboMotivo.Visible = False
            lMotivo2.Visible = False
            cboMotivo2.Visible = False
            lDiaDebito.Visible = False
            txtDataDebito.Visible = False
            lMatricula.Visible = False
            txtMatricula.Visible = False

            Panel8.Visible = False
            Panel7.Visible = False
        End If
        RemoveErrosPainel(Panel6)
        ZeraPainel(Panel6)
        RemoveErrosPainel(Panel2)
        ZeraPainel(Panel2)
        imgFarol.Visible = False
        lblFarol.Visible = False
        blnFarol = False
        imgSelect.Visible = False
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
        btnSimular.Enabled = False
        cboCateg.DataSource = Nothing
        cboSeg.Enabled = True

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

        strSql = "EXEC FRPF_SP_ID_LIGACAO " & LoginOperador

        lngProtocolo = cls.Exec_Command_Scalar(strSql, 2)

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
            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities

            If rbtnArgumentacao.Checked = True Then
                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
                ZeraPainel(Panel821)
                ZeraPainel(Panel831)
                ZeraPainel(Panel841)


                cboMotivo.DataSource = Nothing
                cboDesfecho.Text = "Retido"
                strSqlCbo = "EXEC FRPF_SP_RET_MOTIVOS_CBO @CodId_TipoRet=3,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo, 2)
                cboMotivo.Visible = True
                lMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo.DroppedDown = True
                cboMotivo2.Visible = False
            Else
                cboMotivo.Visible = False
                lMotivo.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCCredito.CheckedChanged
        Try
            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities

            If rbtnCCredito.Checked = True Then
                If Not txtDtFimVig.Text = Nothing Then
                    ValidaRenov(txtDtFimVig.Text)
                End If
                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
                ZeraPainel(Panel821)
                ZeraPainel(Panel831)
                ZeraPainel(Panel841)
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Retido"
                strSqlCbo = "EXEC FRPF_SP_RET_MOTIVOS_CBO @CodId_TipoRet=6,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo, 2)
                cboMotivo.Visible = True
                lMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo2.Visible = False
                'cboMotivo.DroppedDown = True
                frm_CartaoCredito.ShowDialog()

            Else
                cboMotivo.Visible = False
                lMotivo.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCancelamento_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbtnCancelamento.CheckedChanged
        Try
            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities
            Dim strDataIniVig As String = "NULL"


            If rbtnCancelamento.Checked = True Then

                If Not txtDtFimVig.Text = Nothing Then
                    ValidaRenov(txtDtFimVig.Text)
                End If

                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
                ZeraPainel(Panel821)
                ZeraPainel(Panel831)
                ZeraPainel(Panel841)
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Não Retido"
                If chkATM_N_Emitido.CheckState = CheckState.Checked Then
                    strDataIniVig = clsU.FormataStringSQL(Today(), TipoDado.Datetime)
                Else
                    Dim strDate As String = Strings.Left(txtDtIniVig.Text, 2) & "/" & Strings.Mid(txtDtIniVig.Text, 3, 2) & "/" & Strings.Right(txtDtIniVig.Text, 4)
                    strDataIniVig = clsU.FormataStringSQL(strDate, TipoDado.Datetime)
                End If

                strSqlCbo = "EXEC FRPF_SP_RET_MOTIVOS_CBO @CodId_TipoRet=1,@CodId_Prod_Grupo=" & intGrupo & ",@DtIniVig=" & strDataIniVig
                clsU.GetCboItems(strSqlCbo, cboMotivo, 2)
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
                lMotivo.Visible = False
                cboMotivo.Visible = False

                'Panel82.Visible = True
                'Panel83.Visible = True
                'Panel84.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnVenda_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnVenda.CheckedChanged
        Try
            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities

            If rbtnVenda.Checked = True Then
                If Not txtDtFimVig.Text = Nothing Then
                    ValidaRenov(txtDtFimVig.Text)
                End If
                ZeraPainel(Panel81)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
                ZeraPainel(Panel831)
                ZeraPainel(Panel841)
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Retido"
                strSqlCbo = "EXEC FRPF_SP_RET_MOTIVOS_CBO @CodId_TipoRet=5,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo, 2)
                cboMotivo.Visible = True
                lMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList

                cboMotivo2.Visible = False
                cboDiaDebito.Visible = True
                lDiaDebito.Visible = True
                txtDataDebito.Visible = True
                lDataDebito.Visible = True
                strSqlCbo = "EXEC FRPF_SP_GET_VENDA_PRODUTO @CodId_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboProdutoVenda, 2)
                SendKeys.Send("{TAB}")
                SendKeys.Send("{F4}")

                Panel821.Visible = True

            Else

                Panel821.Visible = False

                cboProdutoVenda.DataSource = Nothing
                cboTipoResVenda.DataSource = Nothing
                cboCategoriaVenda.DataSource = Nothing
                cboPlanoVenda.DataSource = Nothing
                txtImpSegVenda.Text = Nothing
                cboMotivo.Visible = False
                lMotivo.Visible = False
                cboDiaDebito.Visible = False
                lDiaDebito.Visible = False
                txtDataDebito.Visible = False
                lDataDebito.Visible = False
            End If

            Panel8.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnOferta_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOferta.CheckedChanged
        Try
            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities

            If rbtnOferta.Checked = True Then
                If Not txtDtFimVig.Text = Nothing Then
                    ValidaRenov(txtDtFimVig.Text)
                End If
                ZeraPainel(Panel81)
                ZeraPainel(Panel82)
                ZeraPainel(Panel84)
                ZeraPainel(Panel821)
                ZeraPainel(Panel841)
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Retido"
                strSqlCbo = "EXEC FRPF_SP_RET_MOTIVOS_CBO @CodId_TipoRet=4,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo, 2)
                cboMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo2.Visible = False
                lMotivo.Visible = True
                strSqlCbo = "EXEC FRPF_SP_GET_OFERTA_CBO"
                clsU.GetCboItems(strSqlCbo, cboOferta, 2)

                strSqlCbo = "EXEC FRPF_SP_GET_OFERTA_PRODUTO_CBO"
                clsU.GetCboItems(strSqlCbo, cboOfertaProd, 2)

                SendKeys.Send("{TAB}")
                SendKeys.Send("{F4}")

                cboDiaDebito.Visible = True
                lDiaDebito.Visible = True
                txtDataDebito.Visible = True
                lDataDebito.Visible = True

                Panel831.Visible = True
            Else

                Panel831.Visible = False

                lMotivo.Visible = False
                cboMotivo.Visible = False
                cboOfertaProd.DataSource = Nothing
                cboOferta.DataSource = Nothing
                cboOfertaPlan.DataSource = Nothing
                cboDiaDebito.Visible = False
                lDiaDebito.Visible = False
                txtDataDebito.Visible = False
                lDataDebito.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnEndosso_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEndosso.CheckedChanged
        Try
            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities
            Dim strIdade As String = "0"
            Dim strPremio As String = "0"
            Dim strCategoria As String = "0"
            Dim strSegmento As String = "0"

            strIdade = clsU.FormataStringSQL(txtIdade.Text, cls_Utilities.TipoDado.Numerico)
            strPremio = clsU.FormataStringSQL(txtPremio.Text, cls_Utilities.TipoDado.Numerico)
            strCategoria = clsU.FormataStringSQL(cboCateg.SelectedValue, cls_Utilities.TipoDado.Numerico)
            strSegmento = clsU.FormataStringSQL(cboSeg.SelectedValue, cls_Utilities.TipoDado.Numerico)

            If rbtnEndosso.Checked = True Then
                If Not txtDtFimVig.Text = Nothing Then
                    ValidaRenov(txtDtFimVig.Text)
                End If
                ZeraPainel(Panel81)
                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel821)
                ZeraPainel(Panel831)
                cboMotivo.DataSource = Nothing
                rbtnArgumentacao.Checked = False
                cboDesfecho.Text = "Retido"
                strSqlCbo = "EXEC FRPF_SP_RET_MOTIVOS_CBO @CodId_TipoRet=2,@CodId_Prod_Grupo=" & intGrupo
                clsU.GetCboItems(strSqlCbo, cboMotivo, 2)
                cboMotivo.Visible = True
                lMotivo.Visible = True
                cboMotivo.DropDownWidth = 450
                cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList
                cboMotivo2.Visible = False
                If txtGrupoProd.Text = "VIDA" Then
                    strSqlCbo = "EXEC FRPF_SP_GET_ENDOSSO_PLANO_CBO @CodProduto=" & intCodProdutoVC & ",@VlrBase=" & strPremio & ",@Idade=" & strIdade & ",@Categoria=" & strCategoria & ",@Segmento=" & strSegmento
                Else
                    strSqlCbo = "EXEC FRPF_SP_GET_ENDOSSO_PLANO_CBO @CodProduto=" & intCodProdutoVC & ",@VlrBase=" & strPremio & ",@Idade=0, @Categoria=" & strCategoria & ",@Segmento=" & strSegmento
                End If

                clsU.GetCboItems(strSqlCbo, cboEndossoPlano, 2)
                SendKeys.Send("{TAB}")
                SendKeys.Send("{F4}")

                Panel841.Visible = True

            Else
                Panel841.Visible = False

                cboMotivo.Visible = False
                lMotivo.Visible = False
                cboEndossoPlano.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnClienteAtrito_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnClienteAtrito.CheckedChanged
        Try

            If rbtnClienteAtrito.Checked = True Then

                cboDesfecho.Text = "Não Retido"

                MessageBox.Show("ATENÇÂO: Este encaminhamento é exclusivo para situações de clientes em atrito, para estorno superior a 90 dias." + vbNewLine + "É OBRIGATÓRIO a aprovação do Supervisor para encaminhamento do chamado." _
                                + vbNewLine + "Não é necessário abrir GCA/Ocorrência...", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
                ZeraPainel(Panel821)
                ZeraPainel(Panel831)
                ZeraPainel(Panel841)
                cboMotivo.DataSource = Nothing
                cboMotivo.Visible = False
                cboMotivo2.Visible = False


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnCancNEfetuado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCancNEfetuado.CheckedChanged
        Try

            If rbtnCancNEfetuado.Checked = True Then

                cboDesfecho.Text = "Não Retido"

                ZeraPainel(Panel82)
                ZeraPainel(Panel83)
                ZeraPainel(Panel84)
                ZeraPainel(Panel821)
                ZeraPainel(Panel831)
                ZeraPainel(Panel841)
                cboMotivo.Visible = False
                cboMotivo2.Visible = False

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

    Private Sub cboDiaDebito_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboDiaDebito.Validating
        Dim intDia As Integer
        Dim intDiaPagto As Integer
        Dim dtDataBase As Date
        Dim dtDataAgend As Date

        If Not cboDiaDebito.Text = Nothing Then

            dtDataBase = Today
            intDia = Day(dtDataBase)
            intDiaPagto = cboDiaDebito.Text

            If intDia >= intDiaPagto Then
                dtDataBase = DateAdd("m", 1, Today)
            End If

            dtDataAgend = DateSerial(Year(dtDataBase), Month(dtDataBase), intDiaPagto)
            txtDataDebito.Text = dtDataAgend

            MsgBox("Informar ao cliente que a cobertura terá início a partir da data do 1º débito!", vbInformation, "Atenção")


        Else

            MsgBox("Selecione o dia para agendamento do débito!", vbCritical, "Atenção")

        End If
    End Sub

    Private Sub cboOfertaProd_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboOfertaProd.Validating
        Try

            Dim strSqlCbo As String
            Dim clsU As New cls_Utilities
            Dim cls As New cls_SqlConnect
            Dim intIdade As Integer = 0
            Dim intLimiteIdade As Integer = 0

            If Not cboOfertaProd.SelectedIndex = -1 Then
                intIdade = CInt(txtIdade.Text)
                intLimiteIdade = CInt(cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_LIMITE_IDADE " & cboOfertaProd.SelectedValue, 2))

                If intLimiteIdade > 0 And intIdade > intLimiteIdade Then
                    rbtnOferta.Checked = False
                    Throw New Exception("Idade do segurado superior a permitida para venda do produto selecionado")
                End If

                strSqlCbo = "EXEC FRPF_SP_GET_OFERTA_PLANO_CBO " & cboOfertaProd.SelectedValue & "," & clsU.FormataStringSQL(txtPremio.Text, cls_Utilities.TipoDado.Numerico)
                clsU.GetCboItems(strSqlCbo, cboOfertaPlan, 2)
                cboOfertaPlan.DroppedDown = True

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cboOfertaPlan_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboOfertaPlan.Validating
        Dim cls As New cls_SqlConnect
        Dim ArrVlr As Array
        Dim dblFator As Double

        If Not cboOfertaPlan.SelectedIndex = -1 Then
            txtPremioOferta.Text = FormatNumber(CDbl(cboOfertaPlan.Text), 2)
            txtImpSegOferta.Text = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_IMPSEG_PLANO " & cboOfertaPlan.SelectedValue, 2)
            ArrVlr = Split(cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_OFERTA_VLR " & cboOferta.SelectedValue, 2), ";")
            txtQt_Parcela.Text = ArrVlr(1).ToString
            dblFator = ArrVlr(0).ToString

            If dblFator > 0.99 Then
                txtVlrParcela.Text = dblFator
            Else
                txtVlrParcela.Text = FormatNumber(CDbl(txtPremioOferta.Text) * dblFator, 2)
            End If

            MsgBox("Atenção: " & txtQt_Parcela.Text & " primeiras parcelas no valor de " & txtVlrParcela.Text & " o restante no valor de " _
                 & txtPremioOferta.Text & vbCrLf & vbCrLf & "selecione o dia do débito!", vbInformation, "Atenção")

            btnSalvar.Focus()
        Else
            txtPremioOferta.Text = Nothing
            txtImpSegOferta.Text = Nothing
            txtVlrParcela.Text = Nothing
            txtQt_Parcela.Text = Nothing
        End If
    End Sub


    Private Sub cboEndossoPlano_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboEndossoPlano.Validating
        Dim cls As New cls_SqlConnect

        If Not cboEndossoPlano.SelectedIndex = -1 Then
            txtImpSegEndosso.Text = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_IMPSEG_PLANO " & cboEndossoPlano.SelectedValue, 2)
            txtPremioEndosso.Text = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_PREMIO_PLANO " & cboEndossoPlano.SelectedValue, 2)
            cboMotivo.DroppedDown = True
        End If

    End Sub

    Private Sub cboProdutoVenda_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboProdutoVenda.Validating
        Try
            Dim cls As New cls_SqlConnect
            Dim clsu As New cls_Utilities
            Dim ArrVlr As Array
            Dim strSql As String
            Dim strSqlCbo As String
            Dim strGrupo As String
            Dim arrGrupo As Array
            Dim intApolice As Integer = 0
            Dim intSeg As Integer
            Dim intIdade As Integer = 0
            Dim intLimiteIdade As Integer = 0

            If Not cboProdutoVenda.SelectedIndex = -1 Then

                intIdade = CInt(txtIdade.Text)
                intLimiteIdade = CInt(cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_LIMITE_IDADE " & cboProdutoVenda.SelectedValue, 2))


                If intLimiteIdade > 0 And intIdade > intLimiteIdade Then
                    rbtnVenda.Checked = False
                    Throw New Exception("Idade do segurado superior a permitida para venda do produto selecionado")
                End If


                strGrupo = cls.Exec_Command_Scalar("FRPF_SP_GET_GRUPO_VC " & cboProdutoVenda.SelectedValue, 2)
                arrGrupo = Split(strGrupo, ";")

                With Me
                    .GrupoVenda = CInt(arrGrupo(0))
                    .ProdRectorVenda = CInt(arrGrupo(3))
                    intApolice = CInt(arrGrupo(2))
                    If intApolice > 0 Then .ApoliceVenda = CInt(arrGrupo(2)) Else .ApoliceVenda = 0
                    SegVenda = CInt(arrGrupo(4))
                End With

                strSql = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_VENDA_RES_CATEG @CodProduto=" & cboProdutoVenda.SelectedValue, 2)

                ArrVlr = Split(strSql, ";")

                intTipoResVenda = ArrVlr(0).ToString
                intCategVenda = ArrVlr(1).ToString

                If intTipoResVenda = 1 Then
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_TIPO_RES"
                    clsu.GetCboItems(strSqlCbo, cboTipoResVenda, 2)
                    cboTipoResVenda.Enabled = True
                    cboTipoResVenda.DroppedDown = True
                Else
                    cboTipoResVenda.DataSource = Nothing
                    cboTipoResVenda.Refresh()
                    cboTipoResVenda.Enabled = False
                End If
                If intCategVenda = 1 Then
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_CATEG @CodProduto=" & cboProdutoVenda.SelectedValue
                    clsu.GetCboItems(strSqlCbo, cboCategoriaVenda, 2)
                    cboCategoriaVenda.Enabled = True
                    If intTipoResVenda = 0 Then cboCategoriaVenda.DroppedDown = True
                Else
                    cboCategoriaVenda.DataSource = Nothing
                    cboCategoriaVenda.Refresh()
                    cboCategoriaVenda.Enabled = False
                End If

                If intCategVenda = 0 And intTipoResVenda = 0 Then
                    If Me.SegVenda = 1 Then intSeg = cboSeg.SelectedValue Else intSeg = 0
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_PLANO @CodProduto=" & cboProdutoVenda.SelectedValue & ",@Tipo_Res=0, @Categoria=0,@Segmento=" & intSeg
                    cboPlanoVenda.DataSource = Nothing
                    clsu.GetCboItems(strSqlCbo, cboPlanoVenda, 2)
                    cboPlanoVenda.DroppedDown = True
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub cboCategoriaVenda_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboCategoriaVenda.Validating
        Dim clsu As New cls_Utilities
        Dim strSqlCbo As String
        Dim intSeg As Integer

        If Not cboCategoriaVenda.SelectedIndex = -1 Then

            If intTipoResVenda = 1 And cboTipoResVenda.SelectedIndex = -1 Then
                MessageBox.Show("Selecione o tipo de residência!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboTipoResVenda.DroppedDown = True
                cboCategoriaVenda.SelectedIndex = -1
                e.Cancel = True
            Else
                If Me.SegVenda = 1 Then intSeg = cboSeg.SelectedValue Else intSeg = 0
                If intTipoResVenda = 1 Then
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_PLANO @CodProduto=" & cboProdutoVenda.SelectedValue & ",@Tipo_Res=" & cboTipoResVenda.SelectedValue & ",@Categoria=" & cboCategoriaVenda.SelectedValue & ",@Segmento=" & intSeg
                ElseIf intCategVenda = 1 Then
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_PLANO @CodProduto=" & cboProdutoVenda.SelectedValue & ",@Tipo_Res=0, @Categoria=" & cboCategoriaVenda.SelectedValue & ",@Segmento=" & intSeg
                Else
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_PLANO @CodProduto=" & cboProdutoVenda.SelectedValue & ",@Tipo_Res=0, @Categoria=0,@Segmento=" & intSeg
                End If
                cboPlanoVenda.DataSource = Nothing
                clsu.GetCboItems(strSqlCbo, cboPlanoVenda, 2)
                cboPlanoVenda.DroppedDown = True
            End If
        Else
            cboPlanoVenda.DataSource = Nothing
            cboPlanoVenda.Refresh()
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
            If rbtnOferta.Checked = True Then
                intDesfecho = 6
                strDesfecho = "Panel831"
            End If
            If rbtnEndosso.Checked = True Then
                intDesfecho = 7
                strDesfecho = "Panel841"
            End If
            If rbtnVenda.Checked = True Then
                intDesfecho = 8
                strDesfecho = "Panel821"
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
                'Oferta Diferenciada
                If intDesfecho = 6 Then
                    If cboMotivo.SelectedIndex = -1 Then
                        Return False
                    ElseIf cboDiaDebito.SelectedIndex = -1 Then
                        Return False
                    Else
                        For Each ctl As Control In Me.Panel83.Controls(strDesfecho).Controls
                            If ctl.GetType().Name = "ComboBox" Then
                                Dim cbo As ComboBox
                                cbo = ctl
                                If cbo.SelectedIndex = -1 Then
                                    Return False
                                End If
                            End If
                        Next
                        Return True
                    End If
                End If
                'Endosso
                If intDesfecho = 7 Then
                    If cboMotivo.SelectedIndex = -1 Then
                        Return False
                    Else
                        For Each ctl As Control In Me.Panel84.Controls(strDesfecho).Controls
                            If ctl.GetType().Name = "ComboBox" Then
                                Dim cbo As ComboBox
                                cbo = ctl
                                If cbo.SelectedIndex = -1 Or cbo.Text = Nothing Then
                                    Return False
                                End If
                            End If
                        Next
                        Return True
                    End If
                End If
                'Venda
                If intDesfecho = 8 Then
                    If cboMotivo.SelectedIndex = -1 Then
                        Return False
                    ElseIf cboDiaDebito.SelectedIndex = -1 Then
                        Return False
                    Else
                        For Each ctl As Control In Me.Panel82.Controls(strDesfecho).Controls
                            If ctl.GetType().Name = "ComboBox" Then
                                Dim cbo As ComboBox
                                cbo = ctl
                                If intTipoResVenda = 1 Then
                                    If intCategVenda = 1 Then
                                        If cbo.SelectedIndex = -1 Then
                                            Return False
                                        End If
                                    Else
                                        If Not cbo.Name = "cboCategoriaVenda" Then
                                            If cbo.SelectedIndex = -1 Then
                                                Return False
                                            End If
                                        End If
                                    End If

                                Else
                                    If intCategVenda = 1 Then
                                        If Not cbo.Name = "cboTipoResVenda" Then
                                            If cbo.SelectedIndex = -1 Then
                                                Return False
                                            End If
                                        End If
                                    Else
                                        If Not cbo.Name = "cboCategoriaVenda" Then
                                            If cbo.SelectedIndex = -1 Then
                                                Return False
                                            End If
                                        End If
                                    End If

                                End If

                            End If
                        Next
                        Return True
                    End If
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

                        ErrProv.SetError(txtCC, "A devolução só poderá ser feita na conta de titularidade do segurado, portanto esta conta não está apta pra receber estorno!")
                        e.Cancel = True
                        MessageBox.Show("A devolução só poderá ser feita na conta de titularidade do segurado, portanto esta conta não está apta pra receber estorno!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        ErrProv.SetError(txtCC, "")
                    End If

                End If
            End If
            If IsNumeric(txtCC.Text) = False And Not txtCC.Text = Nothing Then
                ErrProv.SetError(txtCC, "Caractere inválido na Conta Corrente!")
                e.Cancel = True
                MessageBox.Show("Caractere inválido na Conta Corrente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ErrProv.SetError(txtCC, "")
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

    Private Sub cboPlanoVenda_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboPlanoVenda.Validating
        Try
            Dim cls As New cls_SqlConnect

            If Not cboPlanoVenda.SelectedIndex = -1 Then
                txtImpSegVenda.Text = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_IMPSEG_PLANO " & cboPlanoVenda.SelectedValue, 2)
                txtPremioVenda.Text = cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_PREMIO_PLANO " & cboPlanoVenda.SelectedValue, 2)
                If Me.GrupoVenda = 3 Then
                    If Not cboTipoResVenda.SelectedIndex = -1 Then
                        frm_Endereco.Tag = cboTipoResVenda.SelectedValue
                    End If
                    frm_Endereco.ShowDialog()
                End If
                btnSalvar.Focus()
            Else
                txtImpSegVenda.Text = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
                btnSimular.Enabled = False
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

    Private Sub btnSimular_Click(sender As Object, e As EventArgs) Handles btnSimular.Click
        Try
            Dim cls As New cls_SqlConnect
            Dim dblPercent As Double
            Dim intDiasVigAtual As Integer
            Dim intDiasVigTotal As Integer
            Dim intDiasNaoUtilizados As Integer
            Dim dblValorDev As Double
            Dim dblValorLiqIof As Double
            Dim blnPrazoCurto As Boolean
            Dim dblIndicePC As Double

            Dim strDateIni As String = Strings.Left(txtDtIniVig.Text, 2) & "/" & Strings.Mid(txtDtIniVig.Text, 3, 2) & "/" & Strings.Right(txtDtIniVig.Text, 4)

            intDiasVigAtual = DateDiff("D", CDate(strDateIni), Today)

            Dim strDateFim As String = Strings.Left(txtDtFimVig.Text, 2) & "/" & Strings.Mid(txtDtFimVig.Text, 3, 2) & "/" & Strings.Right(txtDtFimVig.Text, 4)

            intDiasVigTotal = DateDiff("D", CDate(strDateIni), CDate(strDateFim))

            blnPrazoCurto = CBool(cls.Exec_Command_Scalar("EXEC FRPF_SP_GET_GRUPO_PRAZO_CURTO @CodId_Grupo=" & intGrupo, 2))
            If blnPrazoCurto = True Then
                dblIndicePC = cls.Exec_Command_Scalar("SELECT PercDevolucao FROM dbo.FRPF_FN_GET_INDICE_PRAZO_CURTO (" & CDbl(intDiasVigAtual) & ", " & CDbl(intDiasVigTotal) & ")", 2)
                dblValorDev = Round(CDbl(txtPremio.Text) * dblIndicePC, 2)
            Else
                dblValorLiqIof = CDbl(txtPremio.Text) - (CDbl(txtPremio.Text) * 0.0038)
                intDiasNaoUtilizados = intDiasVigTotal - intDiasVigAtual
                dblPercent = CDbl(intDiasNaoUtilizados) / CDbl(intDiasVigTotal)
                dblValorDev = dblValorLiqIof * dblPercent
            End If

            MessageBox.Show("Valor aproximado a devolver: " & Format(dblValorDev, "#,##0.00"), "Simular Devolução", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cboProdutoVenda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdutoVenda.SelectedIndexChanged
        Try
            cboTipoResVenda.DataSource = Nothing
            cboTipoResVenda.Text = Nothing
            cboCategoriaVenda.DataSource = Nothing
            cboCategoriaVenda.Text = Nothing
            cboPlanoVenda.DataSource = Nothing
            cboPlanoVenda.Text = Nothing
            txtPremioVenda.Text = Nothing
            txtImpSegVenda.Text = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboTipoResVenda_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboTipoResVenda.Validating
        Try
            Dim clsu As New cls_Utilities
            Dim strSqlCbo As String
            Dim intSeg As Integer

            If Not cboTipoResVenda.SelectedIndex = -1 Then
                If intCategVenda = 0 Then
                    If Me.SegVenda = 1 Then intSeg = cboSeg.SelectedValue Else intSeg = 0
                    strSqlCbo = "EXEC FRPF_SP_GET_VENDA_PLANO @CodProduto=" & cboProdutoVenda.SelectedValue & ",@Tipo_Res=" & cboTipoResVenda.SelectedValue & ", @Categoria=0,@Segmento=" & intSeg
                    cboPlanoVenda.DataSource = Nothing
                    clsu.GetCboItems(strSqlCbo, cboPlanoVenda, 2)
                    cboPlanoVenda.DroppedDown = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub cboOferta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOferta.SelectedIndexChanged

    End Sub

    Private Sub txtQt_Parcela_TextChanged(sender As Object, e As EventArgs) Handles txtQt_Parcela.TextChanged

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
                MessageBox.Show("Digite o celular corretamente !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub txtApolice_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtApolice.Validating

        If IsNumeric(txtApolice.Text) = False And Len(txtApolice.Text) > 0 Then
            MessageBox.Show("Caractere inválido na apólice !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApolice.Focus()
        End If
    End Sub

    Private Sub txtProtocoloSac_TextChanged(sender As Object, e As EventArgs) Handles txtProtocoloSac.TextChanged
        Call DesativarRetencao(sender)
    End Sub

    Private Sub txtProtocoloSac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProtocoloSac.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

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
    Private Sub ValidaRenov(strData As String)

        Try
            Dim strDateFimVig As String = Strings.Left(strData, 2) & "/" & Strings.Mid(strData, 3, 2) & "/" & Strings.Right(strData, 4)
            Dim intFimVig As Integer

            Dim dtDateFimVig As Date = Date.ParseExact(strDateFimVig, "dd/MM/yyyy",
                       System.Globalization.DateTimeFormatInfo.InvariantInfo)

            intFimVig = DateDiff(DateInterval.Day, Today(), dtDateFimVig)

            If intFimVig <= 30 Then
                MessageBox.Show("Atenção: Seguro em período de renovação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
   
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If blnFarol Then
            My.Application.DoEvents()
            imgFarol.Visible = Not imgFarol.Visible
        End If

    End Sub
End Class