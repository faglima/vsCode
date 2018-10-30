Imports System.Data.SqlClient
Imports System.Data

Public Class cls_SqlConnect

    '#If CONFIG = "Debug" Then
    '    Private Const strStringConexao As String = "Server=ITL20031;Database=DB_FRPJ;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0; Pooling=false"
    '    Private Const strStringConexao2 As String = "Server=ITL20031;Database=DB_FRPF;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0; Pooling=false"
    '    Public Const strAmbiente = "Desenvolvimento"
    '#ElseIf CONFIG = "Release" Then
    '    Private Const strStringConexao As String = "Server=SR80010000S001;Database=DB_FRPJ;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0;Pooling=false"
    '    Private Const strStringConexao2 As String = "Server=SR80010000S001;Database=DB_FRPF;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0;Pooling=false"
    '    Public Const strAmbiente = "Produção"
    '#ElseIf CONFIG = "HM" Then
    '    Private Const strStringConexao As String = "Server=D2053095;Database=DB_FRPJ;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0;Pooling=false"
    '    Private Const strStringConexao2 As String = "Server=D2053095;Database=DB_FRPF;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0;Pooling=false"
    '    Public Const strAmbiente = "Homologação"
    '#End If

    '    Public Function Open_Db(Optional ByVal intStrSql As Integer = 1) As String

    '        Try
    '            Dim Conn As String = Nothing

    '            With Conn

    '                If intStrSql = 1 Then
    '                    Conn = strStringConexao 'BASE PJ
    '                Else
    '                    Conn = strStringConexao2 'BASE PF
    '                End If

    '            End With

    '            Return Conn

    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '            Return Nothing
    '        End Try

    '    End Function
#If CONFIG = "Debug" Then

    Private Const strStringConexao As String = "Server=ITLNB023;Database=DB_FRPJ;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0;Pooling=false"
    Private Const strStringConexao2 As String = "Server=ITLNB023;Database=DB_FRPF;Uid=frpf_user;Pwd=frpf 2012!*;Connection Timeout=0;Pooling=false"

    Private Const strStringConexaoBulk_PJ As String = "Server=ITLNB023;Database=DB_FRPJ;Uid=frpj_user;Pwd=frpj 2012!*;Connection Timeout=0;Pooling=false"
    Private Const strStringConexaoBulk_PF As String = "Server=ITLNB023;Database=DB_FRPF;Uid=frpf_user;Pwd=frpf 2012!*;Connection Timeout=0;Pooling=false"

    'Private Const strStringConexaoBulk_PJ As String = "Server=DBSCXDVWBR01,5000;Database=DB_FRPJ;Uid=SCXBULK;Pwd=GRTY7896;Connection Timeout=0;Pooling=false"
    'Private Const strStringConexaoBulk_PF As String = "Server=DBSCXDVWBR01,5000;Database=DB_FRPF;Uid=SCXBULK;Pwd=GRTY7896;Connection Timeout=0;Pooling=false"

    Public Const strAmbiente = "Desenvolvimento"

#ElseIf CONFIG = "Release" Then

    Private strPwd As String = cls_Crypto.Decrypt("zmBoHx/KZ3Mk2AVP6Pr5sg==", "KQWERsdsarIUTSqweasxc!@345Rt")
    Private strStringConexao As String = "Server=dbscxpvwbr05,8000;Database=DB_FRPJ;Uid=SCXTUSER;Pwd=" & strPwd & ";Connection Timeout=0;Pooling=false"
    Private strStringConexao2 As String = "Server=dbscxpvwbr05,8000;Database=DB_FRPF;Uid=SCXTUSER;Pwd=" & strPwd & ";Connection Timeout=0;Pooling=false"

    Private strStringConexaoBulk_PJ As String = "Server=dbscxpvwbr05,8000;Database=DB_FRPJ;Uid=SCXBULK;Pwd=" & strPwd & ";Connection Timeout=0;Pooling=false"
    Private strStringConexaoBulk_PF As String = "Server=dbscxpvwbr05,8000;Database=DB_FRPF;Uid=SCXBULK;Pwd=" & strPwd & ";Connection Timeout=0;Pooling=false"

    Public Const strAmbiente = "Produção"

#ElseIf CONFIG = "HM" Then

    Private Const strStringConexao As String = "Server=DBSCXHVWBR01,7000;Database=DB_FRPJ;Uid=SCXTUSER;Pwd=BOMB3698;Connection Timeout=0;Pooling=false"
    Private Const strStringConexao2 As String = "Server=DBSCXHVWBR01,7000;Database=DB_FRPF;Uid=SCXTUSER;Pwd=BOMB3698;Connection Timeout=0;Pooling=false"

    Private Const strStringConexaoBulk_PJ As String = "Server=DBSCXDVWBR01,5000;Database=DB_FRPJ;Uid=SCXBULK;Pwd=GRTY7896;Connection Timeout=0;Pooling=false"
    Private Const strStringConexaoBulk_PF As String = "Server=DBSCXDVWBR01,5000;Database=DB_FRPF;Uid=SCXBULK;Pwd=GRTY7896;Connection Timeout=0;Pooling=false"

    Public Const strAmbiente = "Homologação"

#End If

    Public Function Open_Db(Optional ByVal intStrSql As Integer = 1) As String

        Try
            Dim Conn As String = Nothing

            With Conn

                Select Case intStrSql
                    Case Is = 1
                        Conn = strStringConexao 'BASE PJ
                    Case Is = 2
                        Conn = strStringConexao2 'BASE PF
                    Case Is = 3
                        Conn = strStringConexaoBulk_PJ
                    Case Is = 4
                        Conn = strStringConexaoBulk_PF
                End Select

            End With

            Return Conn

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function
    Public Function Exec_Command_Scalar(ByVal strQuery As String, Optional ByVal intStrSql As Integer = 1) As String

        Using Conn As New SqlConnection(Open_Db(intStrSql))
            Try

                Dim strReturn As String
                Conn.Open()

                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strQuery
                    .CommandType = CommandType.Text
                    .Connection = Conn
                    .CommandTimeout = 0
                End With

                strReturn = cmdComando.ExecuteScalar


                Return strReturn

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return Nothing
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try

        End Using



    End Function

    Public Function Return_DataReader(ByVal strQuery As String, Optional ByVal intStrSql As Integer = 1) As SqlDataReader

        Try
            Dim Conn As New SqlConnection(Open_Db(intStrSql))
            Conn.Open()

            Dim cmdComando As New SqlCommand("SET NOEXEC ON")
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandTimeout = 0
            End With

            Return cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

        Catch ex As Exception
            Throw New Exception("Erro na Camada 1: " & ex.Message)
        End Try

    End Function

    Public Function Return_DataSet(ByVal strQuery As String, Optional ByVal intStrSql As Integer = 1) As DataSet


        Using Conn As New SqlConnection(Open_Db(intStrSql))
            Try

                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strQuery
                    .CommandType = CommandType.Text
                    .Connection = Conn
                    .CommandTimeout = 0
                End With

                Dim daAdaptador As New SqlDataAdapter
                Dim dsDataSet As New DataSet
                daAdaptador.SelectCommand = cmdComando
                daAdaptador.Fill(dsDataSet)

                Return dsDataSet

            Catch ex As Exception
                Throw New Exception("Erro na Camada 1: " & ex.Message)
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try

        End Using



    End Function
    Public Function Return_DataAdapter(ByVal strQuery As String, Optional ByVal intStrSql As Integer = 1) As SqlDataAdapter

        Try
            Dim Conn As New SqlConnection(Open_Db(intStrSql))
            Conn.Open()

            Dim cmdComando As New SqlCommand
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.Text
                .Connection = Conn
                .CommandTimeout = 0
            End With

            Dim daAdaptador As New SqlDataAdapter
            Dim dsDataSet As New DataSet
            daAdaptador.SelectCommand = cmdComando
            daAdaptador.Fill(dsDataSet)

            Dim cmdBuilder As New SqlCommandBuilder(daAdaptador)

            cmdComando.Connection.Close()

            Return daAdaptador


        Catch ex As Exception
            Throw New Exception("Erro na Camada 1: " & ex.Message)
        End Try

    End Function
    Public Function Exec_Command_NQ(ByVal strQuery As String, Optional ByVal intStrSql As Integer = 1) As Long


        Using Conn As New SqlConnection(Open_Db(intStrSql))
            Try
                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strQuery
                    .CommandType = CommandType.Text
                    .Connection = Conn
                    .CommandTimeout = 0

                End With

                Return cmdComando.ExecuteNonQuery()

            Catch ex As Exception
                Return 0
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try

        End Using

    End Function
    Public Function Exec_Command_NQ_Param(ByVal strProcedure As String, ByVal Param() As SqlParameter, Optional ByVal intStrSql As Integer = 1) As String

        Using Conn As New SqlConnection(Open_Db(intStrSql))
            Try
                Conn.Open()
                Dim cmdComando As New SqlCommand
                With cmdComando
                    .CommandText = strProcedure
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Conn
                    .Parameters.AddRange(Param)
                    .CommandTimeout = 0
                    .ExecuteNonQuery()
                End With

                Return cmdComando.Parameters(0).Value.ToString

            Catch ex As Exception
                Return "0"
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try
        End Using



    End Function

    Public Function Return_DataTable(ByVal SqlCommand As String, Optional ByVal intStrSql As Integer = 1) As DataTable

        Using Conn As New SqlConnection(Open_Db(intStrSql))
            Try
                Dim daAdapter As SqlDataAdapter
                Dim dtaTable As DataTable
                Dim dtaSet As New DataSet

                Conn.Open()
                Dim cmdComando As New SqlCommand("SET NOEXEC ON")
                With cmdComando
                    .CommandText = SqlCommand
                    .CommandType = CommandType.Text
                    .Connection = Conn
                    .CommandTimeout = 0
                End With

                daAdapter = New SqlDataAdapter
                daAdapter.SelectCommand = cmdComando
                Dim commandBuilder As New SqlCommandBuilder(daAdapter)
                daAdapter.Fill(dtaSet)
                dtaTable = New DataTable
                dtaTable = dtaSet.Tables(0)

                Return dtaTable

            Catch ex As Exception
                Throw New Exception("Erro na Camada 1: " & ex.Message)
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try

        End Using




    End Function


    Private Sub Close_Db(ByVal Conn As SqlConnection)
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Enum TipoConn
        RedeLocal = 1
        RedeServidor = 2
        Sql = 3
    End Enum
    Public Function fTestConn(ByVal t As TipoConn) As Boolean
        Try
            Dim blnReturn As Boolean = False

            If t = 1 Then
                If My.Computer.Network.IsAvailable Then
                    blnReturn = True
                Else
                    Throw New System.Exception("Este computador não está conectado a uma rede...")
                    blnReturn = False
                End If

            ElseIf t = 2 Then
                blnReturn = False
            ElseIf t = 3 Then
                Dim conn As New SqlConnection
                conn.ConnectionString = strStringConexao
                conn.Open()
                conn.Close()
                blnReturn = True
            End If

            Return blnReturn

        Catch ex As SqlClient.SqlException
            MessageBox.Show("Erro conexão com o Banco de Dados..", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class



