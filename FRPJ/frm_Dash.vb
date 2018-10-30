Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
'Imports Microsoft.Office.Interop.PowerPoint
Imports System.Runtime.InteropServices
Imports System.Reflection
'Imports Microsoft.Office.Core

Public Class frm_Dash
    Private Sub GeraGraph1(ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = ""
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH1_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH1'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH1_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH1'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH1_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH1'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph12(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph12(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH12_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH12'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH12_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH12'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH12_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH12'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph13(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph13(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""
            Dim strMeta As String = "0"
            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH13_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH13'")
                End If


                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH13_PJ'")
                        strMeta = Replace(cls.Exec_Command_Scalar("SELECT Meta_Open FROM tbl_Retencao_Meta_PJ WHERE Mesref=" & strMesrefB), ",", ".")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH13'")
                        strMeta = Replace(cls.Exec_Command_Scalar("SELECT Meta_Open FROM tbl_Retencao_Meta WHERE Mesref=" & strMesrefB), ",", ".")
                    End If

                    strSql = Replace(strSql, "[Meta]", strMeta)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph14(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph14(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""
            Dim strMeta As String = "0"
            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH14_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH14'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH14_PJ'")
                        strMeta = Replace(cls.Exec_Command_Scalar("SELECT Meta_Related FROM tbl_Retencao_Meta_PJ WHERE Mesref=" & strMesrefB), ",", ".")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH14'")
                        strMeta = Replace(cls.Exec_Command_Scalar("SELECT Meta_Related FROM tbl_Retencao_Meta WHERE Mesref=" & strMesrefB), ",", ".")
                    End If
                    

                    strSql = Replace(strSql, "[Meta]", strMeta)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                cls.Exec_Command_NQ(strSql, 1)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frm_Dash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clsU As New cls_Utilities
            Dim strSql As String

            clsU.SetMesRef(cboMesref, #2/1/2017#, Date.Today)
            cboMesref.Text = clsU.fGetMesref(Date.Today)

            strSql = "EXEC FRPJ_SP_GRAPH_EPS_CBO"
            clsU.GetCboItems(strSql, cboEps, 1)
            cboEps.SelectedValue = 0

            Dim lstItems As New List(Of String)
            lstItems.AddRange({"PJ", "PF"})
            clsU.GetCboItems_List(cboOrigem, lstItems)
            cboOrigem.SelectedValue = 1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnGrapf_Click(sender As Object, e As EventArgs) Handles btnGrapf.Click
        Try
            Dim clsU As New cls_Utilities
            Dim strChartRange As String
            Dim pptAssemb = Assembly.GetExecutingAssembly
            Dim pptFile As String = ""
            Dim xlsFile As String = "Retencao.xlsx"
            Dim pptDir As String = Path.Combine(Path.GetTempPath, Path.GetRandomFileName)
            Dim pptFilePath As String = ""
            Dim xlsFilePath As String = ""
            Dim intOrigem As Int16 = 0
            Dim intMesref As Integer = "0"
            Dim intEps As Int16 = "0"
            Dim strPptOutFile As String
            Dim strSql As String = ""
            Dim strText As String = ""

            Me.Cursor = Cursors.WaitCursor

            intOrigem = CInt(cboOrigem.SelectedValue) + 1
            intMesref = CInt(cboMesref.Text)
            intEps = CInt(cboEps.SelectedValue)

            If intOrigem = 1 Then
                pptFile = "Modelo_pj.pptx"
                strPptOutFile = "Indicadores_PJ_" & cboOrigem.Text & "_" & cboMesref.Text & "_" & cboEps.Text & ".pptx"
            Else
                pptFile = "Modelo.pptx"
                strPptOutFile = "Indicadores_PF_" & cboOrigem.Text & "_" & cboMesref.Text & "_" & cboEps.Text & ".pptx"
            End If

            pptFilePath = Path.Combine(pptDir, pptFile)
            xlsFilePath = Path.Combine(pptDir, xlsFile)


            GeraGraph1(intOrigem)
            GeraGraph3(intOrigem)
            If intOrigem = 2 Then GeraGraph5()
            GeraGraph7(intOrigem)
            GeraGraph8(intOrigem)
            GeraGraph9(intOrigem)

            Using Stream As Stream = pptAssemb.GetManifestResourceStream(String.Format("{0}.{1}", pptAssemb.GetName().Name, pptFile))
                Using reader As New StreamReader(Stream, Encoding.Default)
                    Directory.CreateDirectory(pptDir)
                    Using writer As New StreamWriter(pptFilePath, False, Encoding.Default)
                        writer.Write(reader.ReadToEnd)
                    End Using
                End Using
            End Using
            Using Stream1 As Stream = pptAssemb.GetManifestResourceStream(String.Format("{0}.{1}", pptAssemb.GetName().Name, xlsFile))
                Using reader1 As New StreamReader(Stream1, Encoding.Default)
                    Using writer1 As New StreamWriter(xlsFilePath, False, Encoding.Default)
                        writer1.Write(reader1.ReadToEnd)
                    End Using
                End Using
            End Using

            'Dim oApp As New Microsoft.Office.Interop.PowerPoint.Application
            Dim oApp As Object
            oApp = CreateObject("PowerPoint.Application")
            'Dim oPpt = oApp.Presentations.Open(pptFilePath, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse)
            Dim oPpt = oApp.Presentations.Open(pptFilePath, 0, 0, 0)

            'Slide1
            Dim oSlide = oPpt.Slides(1)

            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH1 @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 1, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Retenção Mensal (R$) - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide2
            oSlide = oPpt.Slides(2)

            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH2 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 2, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Tipos Atendimentos (R$) - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide3
            oSlide = oPpt.Slides(3)

            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH3 @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 3, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Tipos Atendimentos (R$) - Anual - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            If intOrigem = 2 Then
                'Slide4
                oSlide = oPpt.Slides(4)

                With oSlide.Shapes("Graph1").LinkFormat
                    .SourceFullName = xlsFilePath
                End With

                oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
                oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

                strSql = "FRPJ_SP_GRAPH4 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

                strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 4, 1, 1)

                oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
                strText = "Retenção (R$) - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
                oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

                oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
                oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()
            End If

            If intOrigem = 2 Then
                'Slide5
                oSlide = oPpt.Slides(5)

                With oSlide.Shapes("Graph1").LinkFormat
                    .SourceFullName = xlsFilePath
                End With

                oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
                oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

                strSql = "FRPJ_SP_GRAPH5 @Origem=" & intOrigem & ",@Eps=" & intEps

                strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 5, 1, 1)

                oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
                strText = "Retenção (R$) - Anual - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
                oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

                oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
                oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()
            End If

            'Slide6 PF - Slide4 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(4)
            Else
                oSlide = oPpt.Slides(6)
            End If


            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH6 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 6, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Cancelamentos (R$) - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide7 - Slide5 PJ
            If intOrigem Then
                oSlide = oPpt.Slides(5)
            Else
                oSlide = oPpt.Slides(7)
            End If


            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH7 @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 7, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Cancelamento (R$) - Anual - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide8 - Slide6 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(6)
            Else
                oSlide = oPpt.Slides(8)
            End If

            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With
            With oSlide.Shapes("Graph12").LinkFormat
                .SourceFullName = xlsFilePath
            End With
            With oSlide.Shapes("Graph13").LinkFormat
                .SourceFullName = xlsFilePath
            End With
            With oSlide.Shapes("Graph14").LinkFormat
                .SourceFullName = xlsFilePath
            End With
            With oSlide.Shapes("Graph15").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH8 @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 8, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Cliente em Atrito (Qtde) - Anual - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            oSlide.Shapes("Graph12").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph12").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH8_1_AP @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph12").Chart.ChartData.Workbook, 1, 8, 1, 13)
            'oSlide.Shapes("Graph12").Chart.SetSourceData(strChartRange)
            oSlide.Shapes("Graph12").Chart.Refresh()
            oSlide.Shapes("Graph12").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph12").Chart.ChartData.Workbook.Close()

            oSlide.Shapes("Graph13").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph13").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH8_1_RESIDENCIAL @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph13").Chart.ChartData.Workbook, 1, 8, 9, 13)
            'oSlide.Shapes("Graph13").Chart.SetSourceData(strChartRange)
            oSlide.Shapes("Graph13").Chart.Refresh()
            oSlide.Shapes("Graph13").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph13").Chart.ChartData.Workbook.Close()

            oSlide.Shapes("Graph14").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph14").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH8_1_VIDA @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph14").Chart.ChartData.Workbook, 1, 8, 18, 13)
            'oSlide.Shapes("Graph14").Chart.SetSourceData(strChartRange)
            oSlide.Shapes("Graph14").Chart.Refresh()
            oSlide.Shapes("Graph14").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph14").Chart.ChartData.Workbook.Close()

            oSlide.Shapes("Graph15").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph15").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH8_1_PRESTAMISTA @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph15").Chart.ChartData.Workbook, 1, 8, 27, 13)
            'oSlide.Shapes("Graph15").Chart.SetSourceData(strChartRange)
            oSlide.Shapes("Graph15").Chart.Refresh()
            oSlide.Shapes("Graph15").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph15").Chart.ChartData.Workbook.Close()

            'Slide9 - Slide7 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(7)
            Else
                oSlide = oPpt.Slides(9)
            End If

            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH9 @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 9, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Cancelamento Não Efetuado (Qtde) - Anual - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide10 - Slide8 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(8)
            Else
                oSlide = oPpt.Slides(10)
            End If


            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH10 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 10, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            strText = "Pedido do Cliente (Qtde) - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide11  - Slide9 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(9)
            Else
                oSlide = oPpt.Slides(11)
            End If

            With oSlide.Shapes("Graph1").LinkFormat
                .SourceFullName = xlsFilePath
            End With

            oSlide.Shapes("Graph1").Chart.ChartData.ActivateChartDataWindow()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Parent.Visible = False

            strSql = "FRPJ_SP_GRAPH11 @Origem=" & intOrigem & ",@Eps=" & intEps

            strChartRange = clsU.GeraExcel_DataTable_PPT(strSql, oSlide.Shapes("Graph1").Chart.ChartData.Workbook, 1, 11, 1, 1)

            oSlide.Shapes("Graph1").Chart.SetSourceData(strChartRange)
            oSlide.Shapes("Graph1").Chart.Refresh()
            strText = "Pedido do Cliente (Qtde) - Anual - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text
            oSlide.Shapes("txtGraph1").TextFrame.TextRange.Text = strText

            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Save()
            oSlide.Shapes("Graph1").Chart.ChartData.Workbook.Close()

            'Slide12   - Slide10 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(10)
            Else
                oSlide = oPpt.Slides(12)
            End If

            strSql = "FRPJ_SP_GRAPH12 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

            clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 12, 1, 1, oSlide, 60, 38)

            strText = "Visão por Produto - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
            oSlide.Shapes("txt1").TextFrame.TextRange.Text = strText

            If intOrigem = 2 Then
                'Slide13()
                oSlide = oPpt.Slides(13)

                strSql = "FRPJ_SP_GRAPH13 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

                clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 13, 1, 1, oSlide, 60, 38)

                strSql = "FRPJ_SP_GRAPH13_1 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

                clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 13, 1, 6, oSlide, 60, 700)

                strSql = "FRPJ_SP_GRAPH13_2"

                clsU.GeraExcel_DataTable_PPT_SLA(strSql, 1, xlsFilePath, 13, 1, 9, oSlide, 430, 38)


                strText = "Inconsistências Emissão 1º Nível - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
                oSlide.Shapes("txt1").TextFrame.TextRange.Text = strText
            End If


            'Slide14   - Slide11 PJ
            If intOrigem = 1 Then
                oSlide = oPpt.Slides(11)
            Else
                oSlide = oPpt.Slides(14)
            End If

            strSql = "FRPJ_SP_GRAPH14 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

            clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 14, 1, 1, oSlide, 60, 38)

            strSql = "FRPJ_SP_GRAPH14_1 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

            clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 14, 1, 6, oSlide, 60, 700)

            strSql = "FRPJ_SP_GRAPH14_2 @Origem=" & intOrigem

            clsU.GeraExcel_DataTable_PPT_SLA(strSql, 1, xlsFilePath, 13, 1, 9, oSlide, 430, 38)

            strText = "Inconsistências Cancelamento 2º Nível - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
            oSlide.Shapes("txt1").TextFrame.TextRange.Text = strText

            If intOrigem = 2 Then
                'Slide15()
                oSlide = oPpt.Slides(15)

                strSql = "FRPJ_SP_GRAPH15 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

                clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 15, 1, 1, oSlide, 60, 38)

                strSql = "FRPJ_SP_GRAPH15_1 @Origem=" & intOrigem & ",@Eps=" & intEps & ",@Mesref=" & intMesref

                clsU.GeraExcel_DataTable_PPT_Sheet(strSql, 1, xlsFilePath, 15, 1, 6, oSlide, 60, 700)

                strSql = "FRPJ_SP_GRAPH15_2"

                clsU.GeraExcel_DataTable_PPT_SLA(strSql, 1, xlsFilePath, 13, 1, 9, oSlide, 430, 38)

                strText = "Inconsistências de Endosso 2º Nível - Origem: " & cboOrigem.Text & " - Eps: " & cboEps.Text & " - Mesref: " & intMesref
                oSlide.Shapes("txt1").TextFrame.TextRange.Text = strText
            End If



            Dim pptOut As String = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), strPptOutFile)

            oPpt.SaveAs(pptOut)

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()

            oPpt.Close()
            Marshal.ReleaseComObject(oPpt)
            oApp.Quit()
            Marshal.ReleaseComObject(oApp)
            oApp = Nothing
            Shell("taskkill /f /im powerpnt.exe", , True)

            Dim psi As New ProcessStartInfo(pptOut)
            psi.WindowStyle = ProcessWindowStyle.Maximized
            Process.Start(psi)

            'Kill(pptFilePath)
            'Directory.Delete(pptDir)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GeraGraph3(ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = ""
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH3'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph31(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph31(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH31_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH31'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH31_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH31'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH31_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH31'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph32(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph32(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH32_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH32'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH32_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH32'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH32_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH32'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph33(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph33(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH33_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH33'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH33_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH33'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH33_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH33'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                cls.Exec_Command_NQ(strSql, 1)


            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    '---------------
    Private Sub GeraGraph5()
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = ""
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH5'")

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH5'")

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    
                    strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH5'")

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH5'")

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH5'")

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", .FormataStringSQL(strMes, cls_Utilities.TipoDado.Texto))
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

               strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH5'")

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph51(strSql)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph51(ByVal strSqlOn As String)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH51'")

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH51'")

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", .FormataStringSQL(strMes, cls_Utilities.TipoDado.Texto))
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH51'")

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph52(strSql)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph52(ByVal strSqlOn As String)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH52'")

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH52'")

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", .FormataStringSQL(strMes, cls_Utilities.TipoDado.Texto))
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH52'")

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph53(strSql)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph53(ByVal strSqlOn As String)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH53'")

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)

                    strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH53'")

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", .FormataStringSQL(strMes, cls_Utilities.TipoDado.Texto))
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH53'")

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                cls.Exec_Command_NQ(strSql, 1)


            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    '---------------
    Private Sub GeraGraph7(Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = ""
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", .FormataStringSQL(strMes, cls_Utilities.TipoDado.Texto))
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7'")
                    End If


                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)
                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH7'")
                End If


                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph71(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph71(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH71_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH71'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH71_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH71'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH71_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH71'")
                End If


                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph72(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph72(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH72_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH72'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH72_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH72'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH72_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH72'")
                End If


                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph73(strSql, Origem)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph73(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH73_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH73'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH73_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH73'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH73_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH73'")
                End If

                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                GeraGraph74(strSql, Origem)


            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph74(ByVal strSqlOn As String, ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = strSqlOn
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH74_PJ'")
                Else
                    strSql = " UNION ALL " & cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH74'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH74_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH74'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH74_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH74'")
                End If


                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                cls.Exec_Command_NQ(strSql, 1)


            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph8(ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = ""
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH8'")
                End If


                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                cls.Exec_Command_NQ(strSql, 1)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub GeraGraph9(ByVal Origem As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim clsU As New cls_Utilities
            Dim strSql As String = ""
            Dim StrSqlSb As New StringBuilder
            Dim dtDataBase As Date = Today
            Dim strMesref As String = ""
            Dim strMesrefB As String = ""
            Dim strMes As String = ""

            With clsU
                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)
                strMesref = .fGetMesref(Today)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVar_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT BodyVarSet_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9'")
                    End If
                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                dtDataBase = DateAdd(DateInterval.Month, -12, Today)

                If dtDataBase < #2/1/2017# Then dtDataBase = #2/1/2017#

                strMesrefB = .fGetMesref(dtDataBase)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT Body2 FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9'")
                End If

                StrSqlSb.AppendLine(strSql)

                Do While CInt(strMesref) >= CInt(strMesrefB)
                    If Origem = 1 Then
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9_PJ'")
                    Else
                        strSql = cls.Exec_Command_Scalar("SELECT Body_Loop FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9'")
                    End If

                    strSql = Replace(strSql, "[Mesref]", strMesrefB)
                    strMes = .fGetMesExt(dtDataBase)
                    strSql = Replace(strSql, "[Mes]", strMes)
                    StrSqlSb.AppendLine(strSql)
                    dtDataBase = DateAdd(DateInterval.Month, 1, dtDataBase)
                    strMesrefB = .fGetMesref(dtDataBase)
                Loop

                strSql = StrSqlSb.ToString
                strSql = Strings.Left(strSql, Len(strSql) - 3)

                StrSqlSb.Clear()
                StrSqlSb.AppendLine(strSql)

                If Origem = 1 Then
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9_PJ'")
                Else
                    strSql = cls.Exec_Command_Scalar("SELECT From_Where FROM tbl_Dash_Template WHERE Proc_Dash='FRPJ_SP_GRAPH9'")
                End If


                StrSqlSb.AppendLine(strSql)

                strSql = StrSqlSb.ToString

                cls.Exec_Command_NQ(strSql, 1)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class