Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Timers


Public Class xTcpIP
    Dim proc As New System.Diagnostics.Process()
    Private PathStr As String
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim Message = "Read Data From AIS"
    Dim server = "10.200.76.54"
    Dim port As Int32 = 31414
    Dim client As New TcpClient(server, port)
    Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(Message)
    Dim stream As NetworkStream = client.GetStream()

    Public Sub New(ByVal _PathStr As String)
        ' Initialize with a specific course in mind
        PathStr = _PathStr

    End Sub

    Public Sub xConnect()

        'set buffer size. if this buffer is full the process of reading will stop and the app will be hang
        client.SendBufferSize = 6550000
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

            Console.WriteLine("Start building CSV ais_live_data.csv")
            Dim dir As String = "C:\AIS_Miner"
            Directory.SetCurrentDirectory(dir)
            Dim proc As New System.Diagnostics.Process()
            proc = Process.Start("C:\AIS_Miner\AISMiner.exe", "-i C:\AIS_Data\ais_live_data.log -o C:\AIS_Data\ais_live.csv -m 0")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub CreatingFeatureClass()
        Try
            'creating AIS feature class 
            Dim ArcPyProc As New System.Diagnostics.Process()
            ArcPyProc = Process.Start("C:\Python27\ArcGIS10.3\python.exe", "C:\AIS_Py\xCsvToTable.py")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Sub CloseConnection()
        Try
            stream.Close()
            client.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub deleteSchemaIni()
        'Dim FileToDelete As String
        'FileToDelete = "C:\AIS_Data\schema.ini"
        'If System.IO.File.Exists(FileToDelete) = True Then
        '    System.IO.File.Delete(FileToDelete)
        '    MsgBox("File Deleted")
        'End If
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
