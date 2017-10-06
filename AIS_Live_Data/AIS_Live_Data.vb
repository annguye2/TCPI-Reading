Public Class AIS_Live_Data
    Dim TcpIP As TcpIP

    Dim dataDir
    Dim xTcpIP As xTcpIP
   

    Dim start_time As DateTime
    Dim stop_time As DateTime
    Dim elapsed_time As TimeSpan


    Private Sub AIS_Live_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TcpIP = New TcpIP(AIS_Read_Data_Time, "C:\AIS_Data\ais_live_data.log")
        xTcpIP = New xTcpIP("C:\AIS_Data\ais_live_data.log")
        TcpIP.cleanDir("C:\AIS_Data")
    

    End Sub

    Private Sub CollectDataBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectDataBtn.Click
        'delete schema...
        TcpIP.deleteSchemaIni()
        StartTime.Text = DateTime.Now.ToString
        TcpIP.Connect()
        EndTime.Text = DateTime.Now.ToString

    End Sub

    Private Sub btnClearDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDir.Click
        'Clean up old data 
        TcpIP.cleanDir("C:\AIS_Data")

    End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        btnStart.Enabled = False
        btnStop.Enabled = True

        '' these properties should be set to True (at design-time or runtime) before calling the RunWorkerAsync
        '' to ensure that it supports Cancellation and reporting Progress
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.WorkerReportsProgress = True

        '' call this method to start your asynchronous Task.
        BackgroundWorker1.RunWorkerAsync()
        start_time = Now

    End Sub

    Private Sub btnStop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        lblElapsed.Text = elapsed_time.TotalSeconds.ToString("0.000000")
        btnStop.Enabled = False
        BackgroundWorker1.CancelAsync()
        TcpIP.BuildCSVData()


    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '' The asynchronous task you want to perform goes here
        '' the following is an example of how it typically goes.

        'Const Max As Integer = 1000

        'For i = 1 To Max
        '    '' do something
        '    '' (I put a sleep to simulate time consumed)
        '    Threading.Thread.Sleep(100)

        '    '' report progress at regular intervals
        '    BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Running..." & i.ToString)

        '    '' check at regular intervals for CancellationPending
        '    If BackgroundWorker1.CancellationPending Then
        '        BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Cancelling...")
        '        Exit For
        '    End If
        '    Dim count As Integer = 0
        '    While (BackgroundWorker1.CancellationPending = False)
        '        xTcpIP.xConnect()
        '    End While
        'Next

        While (Not BackgroundWorker1.CancellationPending)
            xTcpIP.xConnect()


        End While


        '' any cleanup code go here
        '' ensure that you close all open resources before exitting out of this Method.
        '' try to skip off whatever is not desperately necessary if CancellationPending is True

        '' set the e.Cancel to True to indicate to the RunWorkerCompleted that you cancelled out
        If BackgroundWorker1.CancellationPending Then
            e.Cancel = True
            BackgroundWorker1.ReportProgress(100, "Completed.")
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '' This event is fired when you call the ReportProgress method from inside your DoWork.
        '' Any visual indicators about the progress should go here.
        Label1.Text = CType(e.UserState, String)
        Label2.Text = e.ProgressPercentage.ToString & "% complete."
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        '' This event is fired when your BackgroundWorker exits.
        '' It may have exitted Normally after completing its task, 
        '' or because of Cancellation, or due to any Error.

        If e.Error IsNot Nothing Then
            '' if BackgroundWorker terminated due to error
            MessageBox.Show(e.Error.Message)
            Label1.Text = "Error occurred!"

        ElseIf e.Cancelled Then
            '' otherwise if it was cancelled
            MessageBox.Show("Complete Collecting Data!")
            Label1.Text = "Complete Collecting Data!"

        Else
            '' otherwise it completed normally
            MessageBox.Show("Task completed!")
            Label1.Text = "Error completed!"
        End If

        btnStart.Enabled = True
        btnStop.Enabled = False
    End Sub



End Class
