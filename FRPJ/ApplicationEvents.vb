﻿Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication

        Public Sub Me_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim cls As New cls_SqlConnect


            Dim strFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FR_SISTEMA\Off.txt"

            If IO.File.Exists(strFile) Then
                Me.ApplicationContext.MainForm = frm_MainForm_Off
            Else
                Me.ApplicationContext.MainForm = frm_MainForm
            End If

        End Sub
        
    End Class


End Namespace

