Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Timers


Public Class xTcpIP
    Private AIS_Log_Path As String
    Private AIS_Record_Log_Path As String
    Dim Message As String
    Dim server As String
    Dim port As Int32
    Dim client As TcpClient
    Dim data As [Byte]()
    Dim stream As NetworkStream
    Dim stopProcess As Boolean
    Public Sub New(ByVal AIS_Path As String)
        ' Initialize with a specific course in mind
        AIS_Log_Path = AIS_Path
        stopProcess = False
        AIS_Record_Log_Path = "C:\AIS_Data\recordLog.log"
    End Sub


    Public Sub OpenConnection()
        Try
            Message = "Read Data From AIS"
            server = "10.200.76.54"
            port = 31414
            client = New TcpClient(server, port)
            data = System.Text.Encoding.ASCII.GetBytes(Message)
            'stream = NetworkStream
            stream = client.GetStream()
        Catch ex As Exception
            Console.WriteLine("OpenConnection error: " + ex.Message)
        End Try
    End Sub

    Public Sub RemoveLogFile()
        IO.File.Delete(AIS_Log_Path)
    End Sub

    Public Sub xConnect()
        Try
            'set buffer size. if this buffer is full the process of reading will stop and the app will be hang
            ' client = New TcpClient(server, port)
            client.SendBufferSize = 655000000
            stream.Write(data, 0, data.Length)
            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            data = New [Byte](256) {}
            ' String to store the response ASCII representation.
            Dim responseData As [String] = [String].Empty
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
            'Console.WriteLine("Received: {0}", responseData)
            WriteToTextFile(responseData, AIS_Log_Path)
            WriteToTextFile(responseData, AIS_Record_Log_Path)
        Catch ex As Exception
            Console.WriteLine("xConnect error: " + ex.Message)
        End Try

       

    End Sub 'Connect

    Public Sub WriteToTextFile(ByRef AisString As String, ByVal filePath As String)
        Try
            Using writer As StreamWriter = New StreamWriter(filePath, True)
                writer.WriteLine(AisString)
            End Using

        Catch ex As Exception
            Console.WriteLine("WriteToTextFile error: " + ex.Message)
        End Try
    End Sub

    Public Sub BuildCSVData()
        Try
            'Console.WriteLine("Start building CSV ais_live_data.csv")
            Dim dir As String = "C:\AIS_Miner"
            Directory.SetCurrentDirectory(dir)
            Dim CSVProcess As New System.Diagnostics.Process()
            CSVProcess = Process.Start("C:\AIS_Miner\AISMiner.exe", "-i C:\AIS_Data\ais_live_data.log -o C:\AIS_Data\ais_live.csv -m 0")
            CSVProcess.WaitForExit()
            'Console.WriteLine("CSV file has successfully been created")
        Catch ex As Exception
            Console.WriteLine("BuildCSVData error: " + ex.Message)
        End Try
    End Sub

    Public Sub CreatingFeatureClass()
        Try

            Dim ArcPyProc As New System.Diagnostics.Process()
            ' this is the name of the process we want to execute 
            ArcPyProc.StartInfo.FileName = "C:\Python27\ArcGIS10.3\python.exe"
            ArcPyProc.StartInfo.Arguments = "C:\AIS_Py\xCsvToTable.py"
            ' need to set this to false to redirect output
            ArcPyProc.StartInfo.UseShellExecute = False
            'ArcPyProc.StartInfo.RedirectStandardOutput = True
            ArcPyProc.StartInfo.CreateNoWindow = True
            ' start the process 
            ArcPyProc.Start()
            ' read all the output
            ' here we could just read line by line and display it
            ' in an output window 
            'Dim output As String = ArcPyProc.StandardOutput.ReadToEnd
            'Console.WriteLine(output)
            ' wait for the process to terminate 
            ArcPyProc.WaitForExit()
            If stopProcess = True Then
                ' MessageBox.Show("AIS data has been created!")
            End If

        Catch ex As Exception
            Console.WriteLine("CreatingFeatureClass error: " + ex.Message)
        End Try


    End Sub

    Public Sub PublishingAISWebServices()
        Try

            Dim ArcPyProc As New System.Diagnostics.Process()
            ' this is the name of the process we want to execute 
            ArcPyProc.StartInfo.FileName = "C:\Python27\ArcGIS10.3\python.exe"
            ArcPyProc.StartInfo.Arguments = "C:\AIS_Py\PublishMapModule.py"
            ' need to set this to false to redirect output
            ArcPyProc.StartInfo.UseShellExecute = False
            ArcPyProc.StartInfo.RedirectStandardOutput = True
            ArcPyProc.StartInfo.CreateNoWindow = True
            ' start the process 
            ArcPyProc.Start()
            ' read all the output
            ' here we could just read line by line and display it
            ' in an output window 
            Dim output As String = ArcPyProc.StandardOutput.ReadToEnd()

            Console.WriteLine(output)
            ' wait for the process to terminate 
            ArcPyProc.WaitForExit()

        Catch ex As Exception
            Console.WriteLine("PublishingAISWebServices error: " + ex.Message)
        End Try


    End Sub


    Public Sub CloseConnection()
        Try
            stream.Close()
            client.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub getProcessStatus(ByVal _stopProcess As Boolean)
        Try
            stopProcess = _stopProcess
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub DeleteFile()
        Dim x As Integer
        Dim paths() As String = IO.Directory.GetFiles("C:\AIS_Data\", "ais_live.csv")
        If paths.Length > 0 Then
            For x = 0 To paths.Length - 1
                IO.File.Delete(paths(x))
            Next
        End If
    End Sub

End Class


