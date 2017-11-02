Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Timers


Public Class xTcpIP
    'Dim proc As New System.Diagnostics.Process()
    Private PathStr As String
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim Message = "Read Data From AIS"
    Dim server = "10.200.76.54"
    Dim port As Int32 = 31414
    Dim client As New TcpClient(server, port)
    Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(Message)
    Dim stream As NetworkStream = client.GetStream()
    Dim stopProcess As Boolean
    Public Sub New(ByVal _PathStr As String)
        ' Initialize with a specific course in mind
        PathStr = _PathStr
        stopProcess = False
    End Sub

    Public Sub xConnect()

        'set buffer size. if this buffer is full the process of reading will stop and the app will be hang
        client.SendBufferSize = 655000000
        stream.Write(data, 0, data.Length)
        ' Receive the TcpServer.response.
        ' Buffer to store the response bytes.
        data = New [Byte](256) {}
        ' String to store the response ASCII representation.
        Dim responseData As [String] = [String].Empty
        Dim bytes As Int32 = stream.Read(data, 0, data.Length)
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
        ' Console.WriteLine("Received: {0}", responseData)
        WriteToTextFile(responseData)

    End Sub 'Connect

    Public Sub WriteToTextFile(ByRef AisString)
        Try
            Using writer As StreamWriter = New StreamWriter(PathStr, True)
                writer.WriteLine(AisString)
            End Using
        Catch ex As Exception
            Console.Write("File doesn't exist")
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
            Console.WriteLine("CSV file has successfully been created")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
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
            ' Dim output As String = ArcPyProc.StandardOutput.ReadToEnd
            'Console.WriteLine(output)
            ' wait for the process to terminate 
            ArcPyProc.WaitForExit()
            Console.WriteLine("AIS feature class has successfully been created")
            If stopProcess = True Then
                MessageBox.Show("Done!!")
            Else
                Console.WriteLine("Start another time: " & Now.ToString)
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
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

    Public Sub OpenConnection()
        Try
            client = New TcpClient(server, port)
            data = System.Text.Encoding.ASCII.GetBytes(Message)
            stream = client.GetStream()
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
