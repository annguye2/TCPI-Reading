Imports System.Windows.Forms
Imports System.IO


Public Class AIS_Live_Data
    'Dim TcpIP As TcpIP

    Dim dataDir
    Public Shared xTcpIP As xTcpIP
    Dim start_time As DateTime
    Dim stop_time As DateTime
    Dim elapsed_time As TimeSpan
    Private Shared WithEvents myTimer As New System.Windows.Forms.Timer()
    Private stopProcessing As Boolean

    Private Sub AIS_Live_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CleanDir("C:\AIS_Data")
        stopProcessing = False

    End Sub


    Private Sub btnClearDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDir.Click
        'Clean up old data 
        CleanDir("C:\AIS_Data")
        btnClearDir.Enabled = False
    End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
 
        CreatingSchema()
        xTcpIP = New xTcpIP("C:\AIS_Data\ais_live_data.log")
        btnStart.Enabled = False
        btnClearDir.Enabled = False
        btnStop.Enabled = True

        '' these properties should be set to True (at design-time or runtime) before calling the RunWorkerAsync
        '' to ensure that it supports Cancellation and reporting Progress
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.WorkerReportsProgress = True

        '' call this method to start your asynchronous Task.
        BackgroundWorker1.RunWorkerAsync()
        start_time = Now

        'elapsed_time = stop_time.Subtract(start_time)
        lblElapsed.Text = "Elapsed time: " & "0.0" & " seconds"
        lblStartTime.Text = "Start time: " & Now.ToString
    End Sub

    Private Sub btnStop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        'this worked well, just temporary close for testing
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        lblElapsed.Text = "Elapsed time: " & elapsed_time.TotalSeconds.ToString("0.0") & " seconds"
        btnStop.Enabled = False
        BackgroundWorker1.CancelAsync()
        KillArcGISProcesses()
        stopProcessing = True
        xTcpIP.getProcessStatus(True)
        'xTcpIP.BuildCSVData()
        'xTcpIP.CreatingFeatureClass()
        btnClearDir.Enabled = True
        'end test


    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '' The asynchronous task you want to perform goes here
        '' the following is an example of how it typically goes.
        Const Max As Integer = 1000000  '  100 seconds
        For i = 1 To Max
            '' check at regular intervals for CancellationPending
            'xTcpIP.xConnect()
            '===========================Testing section
            myTimer = New System.Windows.Forms.Timer()
            myTimer.Interval = 5000  ' time inteval for 5 seconds
            Console.WriteLine("Start time: " & Now.ToString)
            While BackgroundWorker1.CancellationPending = False
                ' Processes all the events in the queue.
                myTimer.Start()
                'Console.WriteLine("Start time: " & Now.ToString)
                BackgroundWorker1.ReportProgress(100, "Collecting .... ") '
                xTcpIP.xConnect()
                System.Windows.Forms.Application.DoEvents()

            End While

            If BackgroundWorker1.CancellationPending Then
                e.Cancel = True
                BackgroundWorker1.ReportProgress(100, "Completed.")
                xTcpIP.CloseConnection()
                Exit For
            Else
            End If
        Next

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '' This event is fired when you call the ReportProgress method from inside your DoWork.
        '' Any visual indicators about the progress should go here.
        lblProcessing.Text = CType(e.UserState, String)
        lblCurrentTime.Text = "Current time: " & Now.ToString()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        '' This event is fired when your BackgroundWorker exits.
        '' It may have exitted Normally after completing its task, 
        '' or because of Cancellation, or due to any Error.
        Try
            If e.Error IsNot Nothing Then
                '' if BackgroundWorker terminated due to error
                MessageBox.Show(e.Error.Message)
                lblProcessing.Text = "Error occurred!"

            ElseIf e.Cancelled Then
                '' otherwise if it was cancelled
                ''MessageBox.Show("Complete Collecting Data!")
                lblProcessing.Text = "Complete Collecting Data!"

            Else
                '' otherwise it completed normally
                MessageBox.Show("Task completed!")
                lblProcessing.Text = "Error completed!"
            End If

            btnStart.Enabled = True
            btnStop.Enabled = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
       
        lblCurrentTime.Text = "End time: " & Now.ToString()
    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Dispose()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub CleanDir(ByVal aisData)
        Try
            'close ArcCatalog Application
            KillArcGISProcesses()
            'Remove all file in data
            For Each deleteFile In Directory.GetFiles(aisData, "*.*", SearchOption.TopDirectoryOnly)
                'If (deleteFile <> "C:\AIS_Data\schema.ini") Then

                File.Delete(deleteFile)
                ' End If
            Next
            'Remove gdb
            'Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & aisData
            If Directory.Exists(aisData & "\ais.gdb") Then
                System.IO.Directory.Delete(aisData & "\ais.gdb", True)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub KillArcGISProcesses()
        Try
            Dim arrArcCatalogProcess() As Process = System.Diagnostics.Process.GetProcessesByName("ArcCatalog")
            For Each arcCatalog As Process In arrArcCatalogProcess
                arcCatalog.Kill()
            Next
            'close ArcCatalog Application
            Dim arrArcMapProcess() As Process = System.Diagnostics.Process.GetProcessesByName("ArcMap")
            For Each arcMap As Process In arrArcMapProcess
                arcMap.Kill()
            Next
            System.Threading.Thread.Sleep(1000)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Sub CreatingSchema()
        'This schema file is one of the most important part that provide control for creating field types to geospatial table. 
        'Without this schema.ini, the field type with changes most of the time. From there fields types in table are changed and app has no control over Lat, Lon, Date type to build table and then feature class.
        'To control more field type, just add in more line in the same format between Using statement

        Try
            Using sw As New System.IO.StreamWriter("C:\AIS_Data\schema.ini", False)
                sw.WriteLine("[ais_live.csv]")
                sw.WriteLine("Col2=Longitude Double")
                sw.WriteLine("Col3=Latitude Double")
                sw.WriteLine("Col5=" & ControlChars.Quote & "Time tag last rpt (GMT)" & ControlChars.Quote & " Text")
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    ' This is the method to run when the timer is raised.
    Private Shared Sub TimerEventProcessor(ByVal myObject As Object, ByVal myEventArgs As EventArgs) Handles myTimer.Tick
        Try
            Console.WriteLine("Stop time: " & Now.ToString)
            myTimer.Stop()
            'MessageBox.Show(Now.ToString)
            xTcpIP.BuildCSVData()
            xTcpIP.CreatingFeatureClass()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

End Class
