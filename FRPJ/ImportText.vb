Imports System.Data.SqlClient
Imports System.Text

Public Class ImportText

    Public Sub BulkInsert(ByVal dt As DataTable, ByVal columns() As String, intOpt As Integer)
        Try
            Dim cls As New cls_SqlConnect
            Dim Conn As New SqlConnection(cls.Open_Db(intOpt))
            Dim cnn As String

            cnn = Conn.ConnectionString

            dt.AcceptChanges()
            Dim bulk As SqlBulkCopy = New SqlBulkCopy(cnn)
            bulk.BatchSize = 5000
            bulk.DestinationTableName = String.Format("{0}", dt.TableName)
            bulk.BulkCopyTimeout = 0
            For Each col As String In columns
                bulk.ColumnMappings.Add(col, col)
            Next
            bulk.WriteToServer(dt)
            bulk.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function OpenFile(ByVal filePath As String, ByVal columnsNameIndex() As Integer, ByVal columnsName() As String, ByVal separator As Char, ignorefirstline As Boolean) As DataTable
        Try
            Dim dt As DataTable = ReadToDataTable(filePath, columnsName.Length, separator, ignorefirstline)
            If (columnsName Is Nothing) Then
                columnsName = New String(-1) {}
            End If

            If (columnsNameIndex Is Nothing) Then
                columnsNameIndex = New Integer(-1) {}
            End If

            If (columnsName.Length > 0) Then
                If (columnsNameIndex.Length > 0) Then
                    Dim c As Integer = 0
                    For Each i In columnsNameIndex.ToList()
                        dt.Columns(i).ColumnName = columnsName(c)
                        c = (c + 1)
                    Next
                Else
                    Dim c As Integer = 0
                    Do While (c < dt.Columns.Count)
                        If (c > (columnsName.Length - 1)) Then
                            Throw New Exception(String.Format("O Arquivo possui {0} colunas: Qtde acima do definido.", dt.Columns.Count))
                        End If

                        dt.Columns(c).ColumnName = columnsName(c)
                        c = (c + 1)
                    Loop

                End If

            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Public Function ReadToDataTable(ByVal filePath As String, ByVal numberOfColumns As Integer, ByVal separator As Char, ignorefistline As Boolean) As DataTable
        Dim tbl As DataTable = New DataTable
        Dim col As Integer = 0
        Dim startline As Integer = 0
        Dim l As Integer

        Do While (col < numberOfColumns)
            tbl.Columns.Add(New DataColumn(("Coluna" + (col + 1).ToString)))
            col = (col + 1)
        Loop

        Dim lines() As String = System.IO.File.ReadAllLines(filePath, Encoding.GetEncoding("iso-8859-1"))

        If ignorefistline Then col = 1

        For l = col To lines.Length - 1

            Dim cols = lines(l).Split(separator)
            Dim dr As DataRow = tbl.NewRow
            Dim cIndex As Integer = 0
            Do While (cIndex < cols.Length)
                dr(cIndex) = cols(cIndex).Replace("""", " ").Replace(", ", ".")
                cIndex = (cIndex + 1)
            Loop

            tbl.Rows.Add(dr)
        Next
        Return tbl
    End Function

    Public Sub BulkInsertByChunks(filePath As String, destinationTable As String, ByVal columnsName() As String, separator As Char, startAtLine As Long, chunkSize As Long,intOpt As Integer )

        Dim Beggin As DateTime = DateAndTime.Now

        Dim tblchunk As DataTable = New DataTable(destinationTable)
        Dim col As Integer = 0
        Dim contador As Long
        Dim chunkCounter As Integer = 1
        Dim QtdRegisImport As Long = 0


        Try
            'Console.WriteLine("Processo iniciado às: " & Beggin)
            Do While (col < columnsName.Length)
                tblchunk.Columns.Add(New DataColumn((columnsName(col).ToString)))
                col = (col + 1)
            Loop

            If startAtLine > chunkSize Then Throw New Exception("Não é possível iniciar após o tamanho do Chunk (Bloco). Defina linha inicial menor que o tamanho do Chunk")

            For Each linha As String In System.IO.File.ReadLines(filePath)

                'If contador = 0 Then Console.WriteLine("Preparando Bloco " & chunkCounter)
                If contador > startAtLine Then
                    Dim cols = linha.Split(separator)
                    Dim dr As DataRow = tblchunk.NewRow


                    Dim cIndex As Integer = 0

                    Do While (cIndex < cols.Length)
                        dr(cIndex) = cols(cIndex).Replace("""", " ").Replace(", ", ".")
                        cIndex = (cIndex + 1)
                        QtdRegisImport += 1
                    Loop

                    tblchunk.Rows.Add(dr)
                End If
                contador = contador + 1

                If contador = chunkSize Then
                    BulkInsert(tblchunk, columnsName, intOpt)
                    'Console.WriteLine("Bloco " & chunkCounter & " Importado com sucesso ")
                    'Console.WriteLine("Quantidade de registros importados até o momento: " & QtdRegisImport)
                    'Console.WriteLine("")
                    tblchunk.Clear()
                    contador = 0
                    chunkCounter = chunkCounter + 1

                End If


            Next


        Catch ex As Exception
            Throw ex
        End Try


        'Dim EndProcess As DateTime = DateAndTime.Now
        'Dim TimeTill As TimeSpan

        'TimeTill = EndProcess.Subtract(Beggin)
        'Console.WriteLine("Tempo Gasto no porcesso: " & TimeTill.ToString)
        'Console.WriteLine("Quantidade de Blocos Importados: " & chunkCounter)
        'Console.WriteLine("Quantidade de Registros Importados:" & QtdRegisImport)

        'Console.WriteLine("")

    End Sub
End Class
