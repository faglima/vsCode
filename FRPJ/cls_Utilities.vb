Imports System.IO
Imports System.Threading.Thread
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Linq
Imports System.Text

Public Class cls_Utilities
    Public Function CPF(ByVal strCPF As String) As Boolean

        Dim strChar As String
        Dim strCpfOk As String

        strCpfOk = Replace(Replace(strCPF, ".", ""), "-", "")


        If Not Len(strCpfOk) = 11 Then
            Return False
        End If

        Select Case strCpfOk
            Case Is = "00000000000"
                Return False
            Case Is = "11111111111"
                Return False
            Case Is = "22222222222"
                Return False
            Case Is = "33333333333"
                Return False
            Case Is = "44444444444"
                Return False
            Case Is = "55555555555"
                Return False
            Case Is = "66666666666"
                Return False
            Case Is = "77777777777"
                Return False
            Case Is = "88888888888"
                Return False
            Case Is = "99999999999"
                Return False
        End Select


        'Verifica se o dígito verificador confere
        strChar = Mid$(strCpfOk, 10, 2)
        If fGetDigCPF(strCpfOk) = strChar Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function fGetDigCPF(ByVal strCPF As String) As Integer


        'Calcula os dígitos verificadores do CPF

        Dim i As Integer
        Dim intFator As Integer
        Dim intTotal As Integer


        'Verifica se tem 9 ou 11 dígitos
        If Not (Len(strCPF) = 9 Or Len(strCPF) = 11) Then
            Return 999
        Else
            'Verifica se é numérico
            If Not IsNumeric(strCPF) Then
                Return 999
            Else
                'Trunca o CPF em 9 caracteres
                strCPF = Left$(strCPF, 9)
            End If
        End If

Inicio:
        'Percorre as colunas (de trás para frente),
        'multiplicando por seus respectivos fatores
        intFator = 2
        intTotal = 0
        For i = Len(strCPF) To 1 Step -1
            intTotal = intTotal + ((CInt(Mid(strCPF, i, 1)) * intFator))
            intFator = intFator + 1
        Next i

        'Obtém o resto da divisão por 11
        i = intTotal Mod 11
        'Subtrai 11 do resto
        i = 11 - i
        'O dígito verificador é i
        If i = 10 Or i = 11 Then i = 0
        'Concatena ao CPF
        strCPF = strCPF & CStr(i)

        If Len(strCPF) = 10 Then
            'Calcula o segundo dígito
            GoTo Inicio
        End If

        'Retorna os dígitos verificadores
        Return Right$(strCPF, 2)


    End Function
    Enum xlsOption
        xlsSaveAs
        xlsOpen
        xlsSave
    End Enum
    Public Function GeraExcel_DataGrid(ByVal dtrGrid As DataGridView, ByVal [option] As xlsOption, Optional ByVal FileName As String = Nothing, Optional ByVal Pwd As String = Nothing) As Boolean

        Dim objExcelApp As Object
        Dim objExcelBook As Object
        Dim objExcelSheet As Object

        Try

            objExcelApp = CreateObject("Excel.Application")
            ' Altera o tipo/localização para Inglês. Existe incompatibilidade  
            ' entre algumas versões de Excel vs Sistema Operativo 
            Dim oldCI As CultureInfo = CurrentThread.CurrentCulture
            CurrentThread.CurrentCulture = New CultureInfo("en-US")
            ' Adiciona um workbook e activa a worksheet actual 
            objExcelBook = objExcelApp.Workbooks.Add

            If Not Pwd = Nothing Then
                objExcelBook.Password = Pwd
            End If

            objExcelSheet = CType(objExcelBook.Worksheets(1), Object)
            ' Ciclo nos cabeçalhos para escrever os títulos a bold/negrito 
            Dim dgvColumnIndex As Int16 = 1
            For Each col As DataGridViewColumn In dtrGrid.Columns
                objExcelSheet.Cells(1, dgvColumnIndex) = col.HeaderText
                objExcelSheet.Cells(1, dgvColumnIndex).Font.Bold = True
                dgvColumnIndex += 1
            Next
            ' Ciclo nas linhas/células 
            Dim dgvRowIndex As Integer = 2

            For Each row As DataGridViewRow In dtrGrid.Rows
                Dim dgvCellIndex As Integer = 1

                For Each cell As DataGridViewCell In row.Cells
                    objExcelSheet.Cells(dgvRowIndex, dgvCellIndex) = cell.Value
                    dgvCellIndex += 1
                Next
                dgvRowIndex += 1
            Next
            ' Ajusta o largura das colunas automaticamente 
            objExcelSheet.Columns.AutoFit()
            ' Caso a opção seja gravar (xlsSaveAs) grava o ficheiro e fecha 
            ' o Workbook/Excel. Caso contrário (xlsOpen) abre o Excel 
            If [option] = xlsOption.xlsSaveAs Then
                objExcelBook.SaveAs(FileName)
                objExcelBook.Close()
                objExcelApp.Quit()
                MessageBox.Show("Arquivo gerado com sucesso para: " & FileName, "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                objExcelApp.Visible = True
            End If
            ' Altera a tipo/localização para actual 
            CurrentThread.CurrentCulture = oldCI


            Return True

        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return False
        Finally
            objExcelSheet = Nothing
            objExcelBook = Nothing
            objExcelApp = Nothing
            ' O GC(garbage collector) recolhe a memória não usada pelo sistema.  
            ' O método Collect() força a recolha e a opção WaitForPendingFinalizers 
            ' espera até estar completo. Desta forma o EXCEL.EXE não fica no  
            ' Task Manager(gestor tarefas) ocupando memória desnecessariamente 
            ' (devem ser chamados duas vezes para maior garantia) 
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try


    End Function
    Public Function GeraExcel_DataTable(ByVal strDataObject As String, ByVal [option] As xlsOption, Optional ByVal FileName As String = Nothing, _
                                        Optional ByVal Pwd As String = Nothing, Optional ByVal intStrSql As Integer = 1, Optional ByVal SheetIndex As Integer = 1) As Boolean

        Dim cls As New cls_SqlConnect
        Dim objExcelApp As Object
        Dim objExcelBook As Object
        Dim objExcelSheet As Object
        Dim dttData As DataTable
        Dim intCols As Integer
        Dim intRows As Integer

        Try

            objExcelApp = CreateObject("Excel.Application")
            ' Altera o tipo/localização para Inglês. Existe incompatibilidade  
            ' entre algumas versões de Excel vs Sistema Operativo 
            Dim oldCI As CultureInfo = CurrentThread.CurrentCulture
            CurrentThread.CurrentCulture = New CultureInfo("en-US")

            If [option] = xlsOption.xlsOpen And Not FileName = Nothing Then
                ' Abre um workbook e activa a worksheet informada
                objExcelBook = objExcelApp.Workbooks.Open(FileName)
            Else
                ' Adiciona um workbook e activa a worksheet actual 
                objExcelBook = objExcelApp.Workbooks.Add
            End If

            If Not Pwd = Nothing Then
                objExcelBook.Password = Pwd
            End If

            objExcelSheet = CType(objExcelBook.Worksheets(SheetIndex), Object)

            dttData = cls.Return_DataTable(strDataObject, intStrSql)
            intCols = dttData.Columns.Count - 1
            intRows = dttData.Rows.Count - 1

            ' Ciclo nos cabeçalhos para escrever os títulos a bold/negrito 
            Dim dgvColumnIndex As Int16 = 1
            Dim i As Int16 = 0
            For i = 0 To intCols
                objExcelSheet.Cells(1, dgvColumnIndex) = dttData.Columns(i).ColumnName
                objExcelSheet.Cells(1, dgvColumnIndex).Font.Bold = True
                dgvColumnIndex += 1
            Next

            ' Ciclo nas linhas/células 
            Dim dgvRowIndex As Integer = 2
            i = 0
            Dim j As Int16 = 0

            For i = 0 To intRows
                Dim dgvCellIndex As Integer = 1

                For j = 0 To intCols
                    objExcelSheet.Cells(dgvRowIndex, dgvCellIndex) = dttData.Rows(i)(j).ToString
                    dgvCellIndex += 1
                Next
                dgvRowIndex += 1
            Next


            ' Ajusta o largura das colunas automaticamente 
            objExcelSheet.Columns.AutoFit()
            ' Caso a opção seja gravar (xlsSaveAs) grava o ficheiro e fecha 
            ' o Workbook/Excel. Caso contrário (xlsOpen) abre o Excel 
            If [option] = xlsOption.xlsSaveAs Then
                objExcelBook.SaveAs(FileName)
                objExcelBook.Close()
                objExcelApp.Quit()
                MessageBox.Show("Arquivo gerado com sucesso para: " & FileName, "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If [option] = xlsOption.xlsSave Then
                    objExcelBook.Save()
                    objExcelApp.Quit()
                End If
            ElseIf [option] = xlsOption.xlsOpen And Not FileName = Nothing Then
                objExcelBook.Save()
                objExcelApp.Visible = True
            Else
                objExcelApp.Visible = True
            End If
            ' Altera a tipo/localização para actual 
            CurrentThread.CurrentCulture = oldCI


            Return True

        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return False
        Finally
            objExcelSheet = Nothing
            objExcelBook = Nothing
            objExcelApp = Nothing
            ' O GC(garbage collector) recolhe a memória não usada pelo sistema.  
            ' O método Collect() força a recolha e a opção WaitForPendingFinalizers 
            ' espera até estar completo. Desta forma o EXCEL.EXE não fica no  
            ' Task Manager(gestor tarefas) ocupando memória desnecessariamente 
            ' (devem ser chamados duas vezes para maior garantia) 
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try



    End Function
    Public Function GeraExcel_DataTable_PPT(ByVal strDataObject As String, ByVal WorkBook As Object, _
                                        ByVal intStrSql As Integer, ByVal SheetIndex As Integer, ByVal IniRow As Integer, ByVal IniCol As Integer) As String 'retorna a range do gráfico

        Dim cls As New cls_SqlConnect
        'Dim objExcelApp As Object
        Dim objExcelBook As Object
        Dim objExcelSheet As Object

        Dim dttData As System.Data.DataTable
        Dim intCols As Integer
        Dim intRows As Integer
        Dim strRange As String = ""

        Try

            'objExcelApp = CreateObject("Excel.Application")
            ' Altera o tipo/localização para Inglês. Existe incompatibilidade  
            ' entre algumas versões de Excel vs Sistema Operativo 
            Dim oldCI As CultureInfo = CurrentThread.CurrentCulture
            CurrentThread.CurrentCulture = New CultureInfo("en-US")


            objExcelBook = WorkBook

            objExcelSheet = CType(objExcelBook.Worksheets(SheetIndex), Object)

            dttData = cls.Return_DataTable(strDataObject, intStrSql)
            intCols = dttData.Columns.Count - 1
            intRows = dttData.Rows.Count - 1

            strRange = "='" & objExcelBook.Worksheets(SheetIndex).name & "'!" & objExcelBook.Worksheets(SheetIndex).cells(IniRow, IniCol).Address(True, True) & ":" _
                         & objExcelBook.Worksheets(SheetIndex).cells(intRows + 2, (IniCol + intCols)).Address(True, True)


            ' Ciclo nos cabeçalhos para escrever os títulos a bold/negrito 
            Dim dgvColumnIndex As Int16 = IniCol
            Dim i As Int16 = 0
            For i = 0 To intCols
                objExcelSheet.Cells(IniRow, dgvColumnIndex) = dttData.Columns(i).ColumnName
                objExcelSheet.Cells(IniRow, dgvColumnIndex).Font.Bold = True
                dgvColumnIndex += 1
            Next

            ' Ciclo nas linhas/células 
            Dim dgvRowIndex As Integer = IniRow + 1
            i = 0
            Dim j As Int16 = 0

            For i = 0 To intRows
                Dim dgvCellIndex As Integer = IniCol

                For j = 0 To intCols
                    objExcelSheet.Cells(dgvRowIndex, dgvCellIndex) = dttData.Rows(i)(j).ToString
                    dgvCellIndex += 1
                Next
                dgvRowIndex += 1
            Next


            ' Ajusta o largura das colunas automaticamente 
            objExcelSheet.Columns.AutoFit()
            ' Caso a opção seja gravar (xlsSaveAs) grava o ficheiro e fecha 
            ' o Workbook/Excel. Caso contrário (xlsOpen) abre o Excel 

            'objExcelBook.Close()
            'objExcelApp.Quit()

            ' Altera a tipo/localização para actual 
            CurrentThread.CurrentCulture = oldCI

            Return strRange

        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return Nothing
        Finally
            objExcelSheet = Nothing
            objExcelBook = Nothing
            'objExcelApp = Nothing
            ' O GC(garbage collector) recolhe a memória não usada pelo sistema.  
            ' O método Collect() força a recolha e a opção WaitForPendingFinalizers 
            ' espera até estar completo. Desta forma o EXCEL.EXE não fica no  
            ' Task Manager(gestor tarefas) ocupando memória desnecessariamente 
            ' (devem ser chamados duas vezes para maior garantia) 
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try



    End Function
    Public Function GeraTxt_DataGrid(ByVal dtrGrid As DataGridView, Optional strFile As String = Nothing, Optional boolAppend As Boolean = False) As Boolean

        'boolAppend = append de informações em arquivo já existente

        Dim intCols As Integer
        Dim intRows As Integer
        Dim i As Integer
        Dim j As Integer
        Dim fdPath As SaveFileDialog
        Dim strValue As String
        Dim dtProcesso As DataTable = DirectCast(DirectCast(dtrGrid.DataSource, BindingSource).DataSource, DataTable).Copy

        Try
            If strFile = "" Then

                fdPath = New SaveFileDialog
                With fdPath
                    .Filter = "Arquivo CSV|*.csv"
                    .Title = "Salvar Arquivo CSV"
                    .ShowDialog()
                End With

                If fdPath.FileName <> Nothing Then
                    strFile = fdPath.FileName
                Else
                    Throw New Exception("Nome de Arquivo não informado !")
                End If

                fdPath.Dispose()
            End If

            intCols = dtProcesso.Columns.Count - 1
            intRows = dtProcesso.Rows.Count - 1

            Using swFile As New StreamWriter(strFile, boolAppend, Encoding.UTF8)

                For i = 0 To intCols
                    swFile.Write(dtProcesso.Columns(i).ColumnName)
                    If i < intCols Then swFile.Write(";")
                Next

                swFile.WriteLine()

                For i = 0 To intRows
                    If dtProcesso.Rows(i)(0).ToString IsNot Nothing Then
                        For j = 0 To intCols
                            strValue = Replace(Replace(Replace(dtProcesso.Rows(i)(j).ToString, vbCrLf, ""), vbCr, ""), vbLf, "")
                            swFile.Write(strValue)
                            If j < intCols Then swFile.Write(";")
                        Next
                        swFile.WriteLine()
                    End If
                Next

                swFile.Close()
            End Using

            MessageBox.Show("Arquivo gerado com sucesso para: " & strFile, "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start(strFile)

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        Finally

            dtProcesso.Clear()
            dtProcesso.Dispose()
            dtProcesso = Nothing

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()

        End Try

    End Function
    Public Function GeraTxt_DataTable(strDataObject As String, strFile As String, Header As Boolean, Delim As String, Optional ByVal intStrSql As Integer = 1, Optional ByVal MinLinhas As Integer = 0) As Boolean



        Dim cls As New cls_SqlConnect
        Dim dttData As DataTable = cls.Return_DataTable(strDataObject, intStrSql)
        Dim intCols As Integer
        Dim intRows As Integer
        Dim i As Integer
        Dim j As Integer

        Try

            If MinLinhas > 0 Then
                If dttData.Rows.Count < MinLinhas Then
                    Throw New Exception()
                End If
            End If

            intCols = dttData.Columns.Count - 1
            intRows = dttData.Rows.Count - 1

            ' Dim dr As DataRow
            'dr = dttData.Rows(1).ItemArray
            'For xx As Int32 = 0 To dr.ItemArray.Length


            'Next

            Using swFile As New StreamWriter(strFile)

                If Header Then

                    For i = 0 To intCols
                        swFile.Write(dttData.Columns(i).ColumnName)
                        If i < intCols Then swFile.Write(Delim)
                    Next

                    swFile.WriteLine()

                End If


                For i = 0 To intRows
                    For j = 0 To intCols
                        swFile.Write(dttData.Rows(i)(j).ToString)
                        If j < intCols Then swFile.Write(Delim)
                    Next
                    swFile.WriteLine()
                Next

                swFile.Close()

            End Using


            Return True

        Catch ex As Exception
            Return False
        Finally
            dttData.Clear()
            dttData.Dispose()
            dttData = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try


    End Function
    Public Function GeraTxt_DataGrid_Tab(ByVal dtrGrid As DataGridView, strFile As String) As Boolean


        Dim swFile As StreamWriter
        Dim intCols As Integer
        Dim intRows As Integer
        Dim i As Integer
        Dim j As Integer



        Try

            intCols = dtrGrid.ColumnCount - 1
            intRows = dtrGrid.RowCount - 1


            swFile = New StreamWriter(strFile)

            For i = 0 To intCols
                swFile.Write(dtrGrid.Columns(i).HeaderText)
                If i < intCols Then swFile.Write(vbTab)
            Next

            swFile.WriteLine()

            For i = 0 To intRows
                For j = 0 To intCols
                    swFile.Write(dtrGrid.Rows(i).Cells(j).Value)
                    If j < intCols Then swFile.Write(vbTab)
                Next
            Next
            swFile.WriteLine()
            swFile.Close()

            Return True


        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return False
        End Try

    End Function

    Private iUser As String
    Private iPerfil As Integer
    Private iUserName As String
    Private iRelease As String

    Public Property Release() As String
        Get
            Return iRelease
        End Get
        Set(ByVal Value As String)
            iRelease = Value
        End Set
    End Property

    Public Property Perfil() As Integer
        Get
            Return iPerfil
        End Get
        Set(ByVal Value As Integer)
            iPerfil = Value
        End Set
    End Property
    Public Property UserLogin() As String
        Get
            Return iUser
        End Get
        Set(ByVal Value As String)
            iUser = Value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return iUserName
        End Get
        Set(ByVal Value As String)
            iUserName = Value
        End Set
    End Property
    Public Function FormataStringSQL(ByVal str As String, Optional ByVal t As TipoDado = TipoDado.Texto, Optional ByVal Padrao As String = "NULL") As String

        'Omita o tipo de dado para tratar como String, retornando aspas na saída.

        Dim r As String

        If (str IsNot Nothing) Then

            If (str = "") Or (str = "__/__/____") Or (str = "  /  /") Then

                r = Padrao

            Else

                Select Case t
                    Case TipoDado.Texto
                        r = "'" + Strings.Replace(str, "'", "") + "'"
                    Case TipoDado.Numerico
                        r = Replace(Replace(str, ".", ""), ",", ".")
                    Case TipoDado.Booleano
                        Select Case str
                            Case "True", "1"
                                r = "1"
                            Case "False", "0"
                                r = "0"
                            Case Else
                                r = "null"
                        End Select
                    Case TipoDado.Datetime
                        r = "'" & CStr(CDate(str).Year) & "-" & Strings.Right("00" & CStr(CDate(str).Month), 2) & "-" & Strings.Right("00" & CStr(CDate(str).Day), 2) & " " & Strings.Right("00" & CStr(CDate(str).Hour), 2) & ":" & Strings.Right("00" & CStr(CDate(str).Minute), 2) & ":" & Strings.Right("00" & CStr(CDate(str).Second), 2) & "'"
                    Case Else
                        r = str
                End Select

            End If

        Else

            r = Padrao

        End If

        Return r

    End Function

    Enum TipoDado
        Texto = 0
        Numerico = 1
        Booleano = 2
        Datetime = 3
    End Enum

    Public Sub SetMesRef(ByRef cboDtBase As ComboBox, ByRef DtIni As Date, ByRef DtFim As Date)


        Try

            Dim DtBase As Date
            Dim strDtIni As String
            Dim strDtFim As String
            Dim strDtAdd As String

            strDtIni = fGetMesref(DtIni)
            strDtFim = fGetMesref(DtFim)

            DtBase = DtFim
            strDtAdd = fGetMesref(DtBase)

            Do While CInt(strDtAdd) >= CInt(strDtIni)
                cboDtBase.Items.Add(strDtAdd)
                DtBase = DateAdd(DateInterval.Month, -1, DtBase)
                strDtAdd = fGetMesref(DtBase)
            Loop

            cboDtBase.Text = fGetMesref(DateAdd(DateInterval.Month, -1, Today))


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub



    Public Sub GetCboItems(strSql As String, ByRef combo As ComboBox, Optional ByVal intStrSql As Integer = 1)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql, intStrSql)

            If dtr.HasRows Then
                Do While dtr.Read
                    cboItems.Add(New cls_Populate(dtr.Item(0).ToString(), dtr.Item(1).ToString()))
                Loop
            Else
                cboItems.Add(New cls_Populate(0, ""))
            End If

            combo.DataSource = Nothing
            combo.Items.Clear()
            combo.DataSource = cboItems
            combo.DisplayMember = "Item"
            combo.ValueMember = "Id"
            combo.SelectedIndex = -1

            dtr.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub SetCboItems(ByRef combo As ComboBox, ByVal lstItems As List(Of String))

        Try
            'Exemplo da Chamada da função:
            'Dim lstItems As New List(Of String)
            'lstItems.AddRange({"Recuperado", "Estornado", "Cancelado"})

            combo.Items.AddRange(lstItems.ToArray)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub GetCboItems_List(ByRef combo As ComboBox, ByVal lstItems As List(Of String))
        Try

            Dim i As Integer
            Dim strItems As Array
            strItems = lstItems.ToArray

            Dim cboItems = New List(Of cls_Populate)

            For i = 0 To UBound(strItems)
                cboItems.Add(New cls_Populate(i, strItems(i).ToString))
            Next

            combo.Items.Clear()
            combo.DataSource = cboItems
            combo.DisplayMember = "Item"
            combo.ValueMember = "Id"
            combo.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetCboItems_Xml(ByRef combo As ComboBox, ByVal xmlFile As String)
        Try


            Dim intCodId As Integer
            Dim strItem As String
            Dim m_xmlr As New XmlTextReader(xmlFile)

            m_xmlr.WhitespaceHandling = WhitespaceHandling.None
            m_xmlr.Read()
            m_xmlr.Read()

            Dim cboItems = New List(Of cls_Populate)

            While Not m_xmlr.EOF
                m_xmlr.Read()

                If Not m_xmlr.IsStartElement() Then
                    Exit While
                End If

                m_xmlr.Read()

                intCodId = CInt(m_xmlr.ReadElementString("CodId"))
                strItem = m_xmlr.ReadElementString("Item")

                cboItems.Add(New cls_Populate(intCodId, strItem))

            End While

            m_xmlr.Close()

            combo.Items.Clear()
            combo.DataSource = cboItems
            combo.DisplayMember = "Item"
            combo.ValueMember = "Id"
            combo.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetCboItems_DataGrid(strSql As String, ByRef combo As DataGridViewComboBoxColumn, ByVal pptyName As String, ByVal hdText As String, Optional ByVal intStrSql As Integer = 1)

        Dim cls As New cls_SqlConnect
        Dim dtr As SqlDataReader

        Try

            Dim cboItems = New List(Of cls_Populate)

            dtr = cls.Return_DataReader(strSql, intStrSql)

            If dtr.HasRows Then
                Do While dtr.Read
                    cboItems.Add(New cls_Populate(dtr.Item(0).ToString(), dtr.Item(1).ToString()))
                Loop
            Else
                cboItems.Add(New cls_Populate(0, ""))
            End If

            combo.Items.Clear()
            combo.DataSource = cboItems
            combo.DisplayMember = "Item"
            combo.ValueMember = "Id"
            combo.DataPropertyName = pptyName
            combo.HeaderText = hdText

            dtr.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Function fGetMesref(ByVal DtBase As Date) As String

        Try

            Dim strMesref As String

            strMesref = Strings.Right("0000" & CStr(Year(DtBase)), 4) & Strings.Right("00" & CStr(Month(DtBase)), 2)

            Return strMesref

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Function fGetDiaref(ByVal DtBase As Date) As String

        Try

            Dim strDiaref As String

            strDiaref = Strings.Right("0000" & CStr(Year(DtBase)), 4) & Strings.Right("00" & CStr(Month(DtBase)), 2) & Strings.Right("00" & CStr(DateAndTime.Day(DtBase)), 2)

            Return strDiaref

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function fDigCNPJ(CNPJ As String) As String

        'Calcula os dígitos verificadores do CNPJ
        Dim i As Integer
        Dim intFator As Integer
        Dim intTotal As Integer


        'Verifica se tem 12 ou 14 dígitos
        If Not (Len(CNPJ) = 12 Or Len(CNPJ) = 14) Then
            Exit Function
        Else
            'Verifica se é numérico
            If Not IsNumeric(CNPJ) Then
                Exit Function
            Else
                'Trunca o CNPJ em 12 caracteres
                CNPJ = Left$(CNPJ, 12)
            End If
        End If

Inicio:
        'Percorre as colunas (de trás para frente),
        'multiplicando por seus respectivos fatores
        intFator = 2
        intTotal = 0
        For i = Len(CNPJ) To 1 Step -1
            If intFator > 9 Then intFator = 2
            intTotal = intTotal + ((CInt(Mid(CNPJ, i, 1)) * intFator))
            intFator = intFator + 1
        Next i

        'Obtém o resto da divisão por 11
        i = intTotal Mod 11
        'Subtrai 11 do resto
        i = 11 - i
        'O dígito verificador é i
        If i = 10 Or i = 11 Then i = 0
        'Concatena ao CNPJ
        CNPJ = CNPJ & CStr(i)

        If Len(CNPJ) = 13 Then
            'Calcula o segundo dígito
            GoTo Inicio
        End If

        'Retorna os dígitos verificadores
        Return Right$(CNPJ, 2)


    End Function
    Public Function fCNPJ(CNPJ As String) As Boolean
        'Verifica se o CNPJ é válido
        Dim strChar As String

        'Verifica se tem 14 caracteres
        If Not Len(CNPJ) = 14 Then
            fCNPJ = False
            Exit Function
        End If

        'Verifica se o dígito verificador confere
        strChar = Mid$(CNPJ, 13, 2)
        If fDigCNPJ(CNPJ) = strChar Then
            Return True
        Else
            Return False
        End If

    End Function

    '---------------------------------------------------------------------------------------
    ' Procedure : fValidaCC
    ' Author    : fabio.lima
    ' Date      : 18/09/2008
    ' Purpose   : Checar a validade de agência e conta corrente Santander
    '---------------------------------------------------------------------------------------
    '
    Public Function fValidaCC(Agencia As String, Conta As String, Dig As Integer) As Boolean
        Try
            Dim tokens(15) As Long
            Dim tokens1(15) As Long
            Dim i As Integer
            Dim strAgConta As String
            Dim lngSoma As Long = 0
            Dim intDig As Integer

            strAgConta = Right$("0000" & Agencia, 4) & Right$("00000000000" & Conta, 11)

            tokens = {9, 7, 3, 1, 0, 0, 0, 9, 7, 1, 3, 1, 9, 7, 3}   'fator

            For i = 1 To 15
                tokens1(i - 1) = CLng(Strings.Mid(strAgConta, i, 1)) * tokens(i - 1)
                lngSoma = lngSoma + CInt(Strings.Right(tokens1(i - 1), 1))
            Next

            intDig = 10 - CInt(Right(CStr(lngSoma), 1))

            If intDig = 10 Then
                intDig = 0
            End If

            If intDig = Dig Then
                Return True
            Else
                Return False
            End If


            'Cálculo do dígito verificador de conta corrente utilizado no BG.
            '
            '
            ' -  Usamos como fator os algarismos 9 7 3 1 0 0 0 9 7 1 3 1 9 7 3;
            '
            '- Temos como estrutura de número um campo de X (15), sendo como exemplo a conta 056400060024362-4, menos  o dígito que é 4, conforme abaixo:
            '   Agencia   X (04);   0564
            '   Conta      X (11);   00060024362
            '9 7 3 1 0 0 0 9 7 1 3 1 9 7 3 (algarismos do fator)
            '0 5 6 4 0 0 0 6 0 0 2 4 3 6 2 (algarismos da estrutura da conta)
            '- Multiplica-se cada algarismo do fator acima pelo correspontente da estrutura de número da conta, como no exemplo:
            '9       x 0 = 0
            '7       x 5 = 35
            '3       x 6 = 18
            '1       x 4 = 4
            '0       x 0 = 0
            '0       x 0 = 0
            '0       x 0 = 0
            '9       x 6 = 54
            '7       x 0 = 0
            '1       x 0 = 0
            '3       x 2 = 6
            '1       x 4 = 4
            '9       x 3 = 27
            '7       x 6 = 42
            '3       x 2 = 6
            '
            '- soma-se a unidade de cada resultado da multiplação acima.
            '   Ex: 5+8+4+4+6+4+7+2+6 = 46;
            '
            '- subtrai-se a unidade do resultado acima da constante de valor 10.
            '   Ex: 10 - 6 = 4.  O dígito verificador será então 4.
            '   OBS: Quando a unidade do resultado da soma dos produtos for zero, o dígito é zero.

        Catch ex As Exception
            Return False
        End Try

    End Function
    Enum DiaMes
        Inicio = 1
        Fim = 2
    End Enum
    Public Function fMesrefToDate(ByVal Mesref As String, ByVal Opt As DiaMes) As Date
        Try

            Dim intAno As Integer = Year(Today)
            Dim intMes As Integer = 1
            Dim intDia As Integer = 1
            Dim dtDateReturn As Date = Nothing

            intAno = CInt(Strings.Left(Mesref, 4))
            intMes = CInt(Strings.Right(Mesref, 2))

            If Opt = 1 Then
                dtDateReturn = DateSerial(intAno, intMes, 1)
            Else
                dtDateReturn = DateSerial(intAno, (intMes + 1), 0)
            End If

            Return dtDateReturn

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function GeraXml_DataTable(ByVal dtrGrid As DataTable, strFile As String) As Boolean
        Try

            Dim xmlW As New XmlTextWriter(strFile, Nothing)
            Dim intCols As Integer
            Dim intRows As Integer
            Dim i As Integer
            Dim j As Integer
            Dim strHead As String = ""

            intCols = dtrGrid.Columns.Count - 1
            intRows = dtrGrid.Rows.Count - 1

            xmlW.WriteStartDocument()
            xmlW.Formatting = Formatting.Indented
            xmlW.WriteStartElement("XmlData")

            For i = 0 To intRows
                xmlW.WriteStartElement("Registro")
                For j = 0 To intCols
                    If j = 0 Then
                        strHead = "CodId"
                    ElseIf j = 1 Then
                        strHead = "Item"
                    Else
                        strHead = dtrGrid.Columns(j).ColumnName
                    End If

                    xmlW.WriteElementString(strHead, dtrGrid.Rows(i).Item(j))

                Next
                xmlW.WriteEndElement()
            Next

            xmlW.WriteEndElement()

            xmlW.Close()
            MsgBox("XML gerado com sucesso: " & strFile)

            Return True

        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return False
        End Try

    End Function
    Public Function GetProdutoPJ_Xml(ByVal xmlFile As String, Produto As Integer) As String

        Try

            Dim intCodId As Integer = 0
            Dim intItem As Integer = 0
            Dim m_xmlr As New XmlTextReader(xmlFile)

            m_xmlr.WhitespaceHandling = WhitespaceHandling.None
            m_xmlr.Read()
            m_xmlr.Read()

            Dim cboItems = New List(Of cls_Populate)

            While Not m_xmlr.EOF
                intCodId = 0
                intItem = 0

                m_xmlr.Read()

                If Not m_xmlr.IsStartElement() Then
                    Exit While
                End If

                m_xmlr.Read()

                intCodId = CInt(m_xmlr.ReadElementString("CodId"))
                intItem = CInt(m_xmlr.ReadElementString("Item"))

                If Produto = intCodId Then
                    Exit While
                End If

            End While

            m_xmlr.Close()

            Return intCodId & ";" & intItem

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function
    Public Function GetProdutoPF_Xml(ByVal xmlFile As String, Produto As Integer) As String

        Try

            Dim intCodId As Integer = 0
            Dim intItem As Integer = 0
            Dim strAtm As String = "False"

            Dim m_xmlr As New XmlTextReader(xmlFile)

            m_xmlr.WhitespaceHandling = WhitespaceHandling.None
            m_xmlr.Read()
            m_xmlr.Read()

            Dim cboItems = New List(Of cls_Populate)

            While Not m_xmlr.EOF
                intCodId = 0
                intItem = 0
                strAtm = "False"

                m_xmlr.Read()

                If Not m_xmlr.IsStartElement() Then
                    Exit While
                End If

                m_xmlr.Read()

                intCodId = CInt(m_xmlr.ReadElementString("CodId"))
                intItem = CInt(m_xmlr.ReadElementString("Item"))
                strAtm = m_xmlr.ReadElementString("ATM")

                If Produto = intCodId Then
                    Exit While
                End If

            End While

            m_xmlr.Close()

            Return intCodId & ";" & intItem & ";" & strAtm

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function
    Public Function fGetMesExt(ByVal DataIn As Date) As String
        Try

            Dim strMesExt As String = ""
            Dim oldCI As CultureInfo = CurrentThread.CurrentCulture
            CurrentThread.CurrentCulture = New CultureInfo("pt-BR")

            strMesExt = Strings.Left(MonthName(Month(DataIn)), 3) & "_" & Strings.Right(DataIn.Year, 2)

            CurrentThread.CurrentCulture = oldCI

            Return strMesExt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Function GeraExcel_DataTable_PPT_Sheet(ByVal DataObject As String, Conn As Integer, ByVal Filename As String, ByVal SheetIndex As Integer, _
                                                  ByVal IniRow As Integer, ByVal IniCol As Integer, ByVal pptSlide As Object, _
                                                  ByVal ShapeTop As Integer, ByVal ShapeLeft As Integer)


        'ByVal strDataObject As String, ByVal WorkBook As Object, _
        'ByVal intStrSql As Integer, ByVal SheetIndex As Integer, ByVal IniRow As Integer, ByVal IniCol As Integer) As Boolean


        Dim cls As New cls_SqlConnect

        'Dim oApp As New Excel.Application
        'Dim oWkb As Excel.Workbook
        'Dim oWks As Excel.Worksheet
        'Dim oRange As Excel.Range

        Dim oApp As Object
        Dim oWkb As Object
        Dim oWks As Object
        Dim oRange As Object

        Dim dttData As System.Data.DataTable
        Dim intCols As Integer
        Dim intRows As Integer

        Try

            oApp = CreateObject("Excel.Application")

            ' Altera o tipo/localização para Inglês. Existe incompatibilidade  
            ' entre algumas versões de Excel vs Sistema Operativo 
            Dim oldCI As CultureInfo = CurrentThread.CurrentCulture
            CurrentThread.CurrentCulture = New CultureInfo("en-US")

            oWkb = oApp.Workbooks.Open(Filename)
            oWks = oWkb.Worksheets(SheetIndex)

            dttData = cls.Return_DataTable(DataObject, Conn)
            intCols = dttData.Columns.Count - 1
            intRows = dttData.Rows.Count - 1

            ' Ciclo nos cabeçalhos para escrever os títulos a bold/negrito 
            Dim dgvColumnIndex As Int16 = IniCol
            Dim i As Int16 = 0
            For i = 0 To intCols
                oWks.Cells(IniRow, dgvColumnIndex) = dttData.Columns(i).ColumnName
                oWks.Cells(IniRow, dgvColumnIndex).Font.Bold = True
                dgvColumnIndex += 1
            Next

            ' Ciclo nas linhas/células 
            Dim dgvRowIndex As Integer = IniRow + 1
            i = 0
            Dim j As Int16 = 0

            For i = 0 To intRows
                Dim dgvCellIndex As Integer = IniCol

                For j = 0 To intCols
                    oWks.Cells(dgvRowIndex, dgvCellIndex) = dttData.Rows(i)(j).ToString
                    dgvCellIndex += 1
                Next
                dgvRowIndex += 1
            Next

            oWks.Columns.AutoFit()


            oRange = oWks.Range(oWks.Cells(IniRow, IniCol).Address(True, True) & ":" _
                     & oWks.Cells(intRows + 2, (IniCol + intCols)).Address(True, True))
            oRange.Copy()


            pptSlide.Shapes.PasteSpecial(10) 'Paste Ole Object

            Dim MyShape As Object = pptSlide.Shapes(pptSlide.Shapes.Count)

            MyShape.Left = ShapeLeft
            MyShape.Top = ShapeTop


            oWkb.Save()
            oWkb.Close()
            oApp.Quit()


            ' Altera a tipo/localização para actual 
            CurrentThread.CurrentCulture = oldCI



            Return True

        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return Nothing
        Finally
            oWks = Nothing
            oWkb = Nothing
            'objExcelApp = Nothing
            ' O GC(garbage collector) recolhe a memória não usada pelo sistema.  
            ' O método Collect() força a recolha e a opção WaitForPendingFinalizers 
            ' espera até estar completo. Desta forma o EXCEL.EXE não fica no  
            ' Task Manager(gestor tarefas) ocupando memória desnecessariamente 
            ' (devem ser chamados duas vezes para maior garantia) 
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try



    End Function
    Public Function GeraExcel_DataTable_PPT_SLA(ByVal DataObject As String, Conn As Integer, ByVal Filename As String, ByVal SheetIndex As Integer, _
                                              ByVal IniRow As Integer, ByVal IniCol As Integer, ByVal pptSlide As Object, _
                                              ByVal ShapeTop As Integer, ByVal ShapeLeft As Integer)


        'ByVal strDataObject As String, ByVal WorkBook As Object, _
        'ByVal intStrSql As Integer, ByVal SheetIndex As Integer, ByVal IniRow As Integer, ByVal IniCol As Integer) As Boolean


        Dim cls As New cls_SqlConnect

        'Dim oApp As New Excel.Application
        'Dim oWkb As Excel.Workbook
        'Dim oWks As Excel.Worksheet
        'Dim oRange As Excel.Range

        Dim oApp As Object
        Dim oWkb As Object
        Dim oWks As Object
        Dim oRange As Object

        Dim dtrData As SqlDataReader
        Dim intCol As Integer
        Dim intRow As Integer


        Try

            oApp = CreateObject("Excel.Application")

            ' Altera o tipo/localização para Inglês. Existe incompatibilidade  
            ' entre algumas versões de Excel vs Sistema Operativo 
            Dim oldCI As CultureInfo = CurrentThread.CurrentCulture
            CurrentThread.CurrentCulture = New CultureInfo("en-US")

            oWkb = oApp.Workbooks.Open(Filename)
            oWks = oWkb.Worksheets(SheetIndex)

            dtrData = cls.Return_DataReader(DataObject, Conn)

            intCol = IniCol
            intRow = IniRow + 1

            If dtrData.HasRows Then

                Do While dtrData.Read
                    oWks.Cells(intRow, intCol) = dtrData.Item("SLA").ToString
                    oWks.Cells(intRow + 1, intCol) = dtrData.Item("Mes").ToString
                    intCol += 1
                Loop

            End If

            'oWks.Columns.AutoFit()

            oRange = oWks.Range(oWks.Cells(IniRow, IniCol).Address(True, True) & ":" _
                     & oWks.Cells(IniRow + 2, IniCol + 11).Address(True, True))
            oRange.Copy()


            pptSlide.Shapes.PasteSpecial(10) 'Paste Ole Object

            Dim MyShape As Object = pptSlide.Shapes(pptSlide.Shapes.Count)

            MyShape.Left = ShapeLeft
            MyShape.Top = ShapeTop


            oWkb.Save()
            oWkb.Close()
            oApp.Quit()


            ' Altera a tipo/localização para actual 
            CurrentThread.CurrentCulture = oldCI

            dtrData.Close()

            Return True

        Catch ex As Exception
            MessageBox.Show("Erro não identificado. Mensagem original:" & vbNewLine + ex.Message)
            Return Nothing
        Finally
            oWks = Nothing
            oWkb = Nothing
            'objExcelApp = Nothing
            ' O GC(garbage collector) recolhe a memória não usada pelo sistema.  
            ' O método Collect() força a recolha e a opção WaitForPendingFinalizers 
            ' espera até estar completo. Desta forma o EXCEL.EXE não fica no  
            ' Task Manager(gestor tarefas) ocupando memória desnecessariamente 
            ' (devem ser chamados duas vezes para maior garantia) 
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try

    End Function
    'Public Sub FormatGrid(Grid As DataGridView, Bd As BindingSource, Optional ByVal HiddenCol As List(Of String) = Nothing)

    '    'Ajusta os textos
    '    With Grid
    '        '.Columns("MesRef").HeaderText = "Mês Ref"
    '    End With

    '    'Centraliza o texto dos headers
    '    For i As Integer = 0 To Grid.Columns.Count - 1
    '        Grid.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    Next

    '    'Alinha os conteúdos
    '    Dim dt As DataTable = Bd.DataSource
    '    For i As Integer = 0 To dt.Columns.Count - 1
    '        'Centraliza campo Date e inteiros
    '        If Grid.Columns(dt.Columns(i).ColumnName).CellType.Name = "DataGridViewComboBoxCell" Then
    '            Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        Else
    '            If dt.Columns(i).DataType = System.Type.GetType("System.DateTime") Or dt.Columns(i).DataType = System.Type.GetType("System.Int32") Then
    '                Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
    '            End If
    '            'Alinha à direita decimais
    '            If dt.Columns(i).DataType = System.Type.GetType("System.Decimal") Then
    '                Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '            End If
    '        End If
    '    Next
    '    'Alinha exceções
    '    'With Grid
    '    '    .Columns("COD_ESTIP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    '    .Columns("NUM_PROP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    'End With

    '    'Formata os conteúdos
    '    For i As Integer = 0 To dt.Columns.Count - 1
    '        'Decimais com duas casas
    '        If dt.Columns(i).DataType = System.Type.GetType("System.Decimal") Then
    '            Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Format = "#,##0.00"
    '        End If
    '    Next

    '    'Oculta colunas
    '    If Not HiddenCol Is Nothing Then
    '        With Grid
    '            For i = 0 To HiddenCol.Count - 1
    '                .Columns(HiddenCol.Item(i)).Visible = False
    '            Next
    '        End With
    '    End If

    '    'Ajusta as larguras
    '    Grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

    'End Sub
    Public Function GeraTxt_DataGrid_Delim(ByVal dtrGrid As DataGridView, Head As Boolean, Optional ByVal Delim As String = Nothing, Optional strFile As String = Nothing, Optional boolAppend As Boolean = False) As Boolean

        Dim intCols As Integer
        Dim intRows As Integer
        Dim i As Integer
        Dim j As Integer
        Dim fdPath As SaveFileDialog
        Dim strValue As String
        Dim dtProcesso As DataTable = DirectCast(DirectCast(dtrGrid.DataSource, BindingSource).DataSource, DataTable).Copy

        Try
            If strFile = "" Then

                fdPath = New SaveFileDialog
                With fdPath
                    .Filter = "Arquivo TXT|*.txt"
                    .Title = "Salvar Arquivo TXT"
                    .ShowDialog()
                End With

                If fdPath.FileName <> Nothing Then
                    strFile = fdPath.FileName
                Else
                    Throw New Exception("Nome de Arquivo não informado !")
                End If

                fdPath.Dispose()
            End If

            intCols = dtProcesso.Columns.Count - 1
            intRows = dtProcesso.Rows.Count - 1

            Using swFile As New StreamWriter(strFile, boolAppend, Encoding.UTF8)

                If Head = True Then
                    For i = 0 To intCols
                        swFile.Write(dtProcesso.Columns(i).ColumnName)
                        If i < intCols Then swFile.Write(Delim)
                    Next
                    swFile.WriteLine()
                End If

                For i = 0 To intRows
                    If dtProcesso.Rows(i)(0).ToString IsNot Nothing Then
                        For j = 0 To intCols
                            strValue = Replace(Replace(Replace(dtProcesso.Rows(i)(j).ToString, vbCrLf, ""), vbCr, ""), vbLf, "")
                            swFile.Write(strValue)
                            If j < intCols Then swFile.Write(Delim)
                        Next
                        swFile.WriteLine()
                    End If
                Next

                swFile.Close()
            End Using


            'Process.Start(strFile)

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        Finally

            dtProcesso.Clear()
            dtProcesso.Dispose()
            dtProcesso = Nothing

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()

        End Try

    End Function
   

    Public Sub FormatGrid(Grid As DataGridView, Bd As BindingSource, Optional ByVal HiddenCol As List(Of String) = Nothing, Optional CellFormat As List(Of FormatCellStyle) = Nothing)

        'Chamada da função com a exceção decimal específica ou data específica
        'Dim FormatList As New List(Of FormatCellStyle)
        'FormatList.Add(New FormatCellStyle("Meta_Open", FormatCellStyle.FormatType._Percent, 2))
        'FormatList.Add(New FormatCellStyle("Meta_Related", FormatCellStyle.FormatType._Percent, 2))

        Dim clsF As New FormatCellStyle()

        'Ajusta os textos
        With Grid
            '.Columns("MesRef").HeaderText = "Mês Ref"
        End With

        'Centraliza o texto dos headers
        For i As Integer = 0 To Grid.Columns.Count - 1
            Grid.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        'Alinha os conteúdos
        Dim dt As DataTable = Bd.DataSource
        For i As Integer = 0 To dt.Columns.Count - 1

            'Centraliza campo Date e inteiros
            If Grid.Columns(dt.Columns(i).ColumnName).CellType.Name = "DataGridViewComboBoxCell" Then
                Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            Else
                If dt.Columns(i).DataType = System.Type.GetType("System.DateTime") Or dt.Columns(i).DataType = System.Type.GetType("System.Int32") Then
                    Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                End If
                'Alinha à direita decimais
                If dt.Columns(i).DataType = System.Type.GetType("System.Decimal") Then
                    Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End If
            End If
        Next
        'Alinha exceções
        'With Grid
        '    .Columns("COD_ESTIP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .Columns("NUM_PROP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With

        'Formata os conteúdos
        For i As Integer = 0 To dt.Columns.Count - 1
            'Decimais com duas casas
            If dt.Columns(i).DataType = System.Type.GetType("System.Decimal") Then
                Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Format = clsF.FormatConstant(FormatCellStyle.FormatType._Decimal, 2)
                'ElseIf dt.Columns(i).DataType = System.Type.GetType("System.DateTime") Then
                '   Grid.Columns(dt.Columns(i).ColumnName).DefaultCellStyle.Format = clsF.FormatConstant(FormatCellStyle.FormatType._ShortDateHour) 'padrão _ShortDateHour para este sistema, porque é o mais utilizado
            End If
        Next

        'Oculta colunas
        If Not HiddenCol Is Nothing Then
            With Grid
                For i = 0 To HiddenCol.Count - 1
                    .Columns(HiddenCol.Item(i)).Visible = False
                Next
            End With
        End If

        'Formata colunas com exceção percentual e outros tipos numéricos e datas específicas
        If Not CellFormat Is Nothing Then
            With Grid
                For i = 0 To CellFormat.Count - 1
                    .Columns(CellFormat.Item(i).Column).DefaultCellStyle.Format = CellFormat.Item(i).Format
                Next
            End With
        End If

        'Ajusta as larguras
        Grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

    End Sub
End Class
Public Class FormatCellStyle

    Enum FormatType
        _Percent
        _Currency
        _Exponential
        _Decimal
        _Number
        _ShortDate
        _ShortDateHour
        _FullDate
    End Enum

    Public Column As String
    Public Format As String

    Public Sub New(ByVal ColumnName As String, ByVal FormatOption As FormatType, Optional NumberPrecision As String = Nothing)

        Column = ColumnName
        Format = FormatConstant(FormatOption, NumberPrecision)

    End Sub
    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String

        Return String.Format("{0} Format:{1}", Column, Format)

    End Function
    Public Function FormatConstant(ByVal opt As FormatType, Optional NumberPrecision As String = Nothing) As String
        Dim StringConstant As String = Nothing

        Select Case opt
            Case FormatType._Currency
                StringConstant = "C" + NumberPrecision

            Case FormatType._Decimal
                StringConstant = "N" + NumberPrecision

            Case FormatType._Exponential
                StringConstant = "E" + NumberPrecision

            Case FormatType._Percent
                StringConstant = "P" + NumberPrecision

            Case FormatType._Number
                StringConstant = "N" + NumberPrecision

            Case FormatType._ShortDateHour
                StringConstant = "G"

            Case FormatType._ShortDate
                StringConstant = "d"

            Case FormatType._FullDate
                StringConstant = "F"

        End Select

        Return StringConstant

    End Function
End Class