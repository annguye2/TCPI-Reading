Imports System.Windows.Forms
Imports System.IO

Public Class AIS_Live_Data
    Dim TcpIP As TcpIP

    Dim dataDir
    Dim xTcpIP As xTcpIP


    Dim start_time As DateTime
    Dim stop_time As DateTime
    Dim curr_time As DateTime
    Dim elapsed_time As TimeSpan


    Private Sub AIS_Live_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TcpIP = New TcpIP(AIS_Read_Data_Time, "C:\AIS_Data\ais_live_data.log")
        CleanDir("C:\AIS_Data")
        SelectTime.SelectedIndex = 0

    End Sub

    Private Sub CollectDataBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectDataBtn.Click
  
        TcpIP.deleteSchemaIni()
        StartTime.Text = DateTime.Now.ToString
        TcpIP.Connect()
        EndTime.Text = DateTime.Now.ToString

    End Sub

    Private Sub btnClearDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDir.Click
        'Clean up old data 
        CleanDir("C:\AIS_Data")

    End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        CreatingSchema()
        xTcpIP = New xTcpIP("C:\AIS_Data\ais_live_data.log")

        btnStart.Enabled = False
        btnStop.Enabled = True

        '' these properties should be set to True (at design-time or runtime) before calling the RunWorkerAsync
        '' to ensure that it supports Cancellation and reporting Progress
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.WorkerReportsProgress = True

        '' call this method to start your asynchronous Task.
        BackgroundWorker1.RunWorkerAsync()
        start_time = Now

        elapsed_time = stop_time.Subtract(start_time)
        lblElapsed.Text = "Elapsed time: " & "0.0" & " seconds"
        lblStartTime.Text = "Start time: " & Now.ToString
    End Sub

    Private Sub btnStop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        lblElapsed.Text = "Elapsed time: " & elapsed_time.TotalSeconds.ToString("0.0") & " seconds"
        btnStop.Enabled = False
        BackgroundWorker1.CancelAsync()
        KillArcGISProcesses()
        xTcpIP.BuildCSVData()
        xTcpIP.CreatingFeatureClass()


    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '' The asynchronous task you want to perform goes here
        '' the following is an example of how it typically goes.

        Const Max As Integer = 10000
        For i = 1 To Max
            BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Collecting .... ") '
            '' check at regular intervals for CancellationPending
            If BackgroundWorker1.CancellationPending Then
                BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Stop")
                Exit For
            End If
            xTcpIP.xConnect()
        Next

        '' any cleanup code go here
        '' ensure that you close all open resources before exitting out of this Method.
        '' try to skip off whatever is not desperately necessary if CancellationPending is True

        '' set the e.Cancel to True to indicate to the RunWorkerCompleted that you cancelled out
        If BackgroundWorker1.CancellationPending Then
            e.Cancel = True
            BackgroundWorker1.ReportProgress(100, "Completed.")
            xTcpIP.CloseConnection()
        End If
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
        lblCurrentTime.Text = "End time: " & Now.ToString()
    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        Try
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CleanDir(ByVal aisData)

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
        Using sw As New System.IO.StreamWriter("C:\AIS_Data\schema.ini", False)
            sw.WriteLine("test text")
        End Using

        'Using sr As New System.IO.StreamReader("c:\myfile.ini")
        '    Dim Line As String = sr.ReadLine
        '    Do While Line IsNot Nothing
        '        MsgBox(Line)
        '    Loop
        'End Using
    End Sub

End Class
