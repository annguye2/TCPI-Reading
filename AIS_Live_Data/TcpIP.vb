
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Timers
Public Class TcpIP

    Dim proc As New System.Diagnostics.Process()
    Private PathStr As String
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim aTimer As System.Timers.Timer
    Dim second As Integer
    Dim count As Integer = 0

    Dim Message = "Read Data From AIS"
    Dim AIS_Read_Data_Time As System.Windows.Forms.Timer

    Public Sub New(ByVal _AIS_Read_Data_Time As System.Windows.Forms.Timer, ByVal _PathStr As String)
        ' Initialize with a specific course in mind
        PathStr = ""
        PathStr = _PathStr
        AIS_Read_Data_Time = _AIS_Read_Data_Time
    End Sub
    Public Sub New()
        ' Initialize without a course
    End Sub

    Public Sub DisplayPathStr()
        MsgBox(PathStr)

    End Sub

    Public Sub Connect()
        AIS_Read_Data_Time.Start() 'Timer stops functioning
        ' StartTime.Text = DateTime.Now.ToString
        ' combination.
        Dim server = "10.200.76.54"
        Dim port As Int32 = 31414
        Dim client As New TcpClient(server, port)
        '' Translate the passed message into ASCII and store it as a Byte array.
        Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(Message)
        ' Get a client stream for reading and writing.
        ' Stream stream = client.GetStream();
        Dim stream As NetworkStream = client.GetStream()
        ' Send the message to the connected TcpServer. 
        stream.Write(data, 0, data.Length)
        Console.WriteLine("Sent: {0}", Message)
        ' Receive the TcpServer.response.
        ' Buffer to store the response bytes.
        data = New [Byte](256) {}

        ' String to store the response ASCII representation.
        Dim responseData As [String] = [String].Empty
        second = 0
        Console.WriteLine("Start reading and writing data")
        While (second <= AIS_Read_Data_Time.Interval)
            second = second + 1
            count += 1
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
            ' Console.WriteLine("Received: {0}", responseData)
            WriteToTextFile(responseData)

        End While

        AIS_Read_Data_Time.Stop() 'Timer stops functioning
        Console.WriteLine("Stop reading and writing data")
        count = 0
        stream.Close()
        client.Close()
        BuildCSVData()
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
            Console.WriteLine("Change current directory to AIS app locationo to get full details data: ")
            Console.Write(Directory.GetCurrentDirectory)
            proc = Process.Start("C:\AIS_Miner\AISMiner.exe", "-i C:\AIS_Data\ais_live_data.log -o C:\AIS_Data\ais_live.csv -m 0")

            'Test appending data to log file
            'proc = Process.Start("C:\AIS_Miner\AISMiner.exe", "-i C:\AIS_Data\appending.log -o C:\AIS_Data\appending.csv -m 0")
            Console.WriteLine("ais_live_data.csv is already created")
            ' initialize the python process to run CsvToTable.py to create 
            'Dim psi = New ProcessStartInfo("c:\python27\python.exe", "C:\AIS_Py\CsvToTable.py")
            'Dim procpy = Process.Start(psi)
            'procpy.WaitForExit()

            'creating AIS feature class 
            Dim ArcPyProc As New System.Diagnostics.Process()
            ArcPyProc = Process.Start("C:\Python27\ArcGIS10.3\python.exe", "C:\AIS_Py\xCsvToTable.py")


            MsgBox("Processing is done!!")
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Sub


    
    Public Sub cleanDir(ByVal aisData)
        'Remove all file in data
        For Each deleteFile In Directory.GetFiles(aisData, "*.*", SearchOption.TopDirectoryOnly)
            File.Delete(deleteFile)
        Next

        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & aisData
        System.IO.Directory.Delete(aisData & "\ais.gdb", True)

    End Sub
    Public Sub deleteSchemaIni()
        Dim FileToDelete As String

        FileToDelete = "C:\AIS_Data\schema.ini"

        If System.IO.File.Exists(FileToDelete) = True Then

            System.IO.File.Delete(FileToDelete)
            MsgBox("File Deleted")

        End If
    End Sub


    Public Sub AppendDataToFile(ByRef AisString)
        Dim filePath As String = String.Format("C:\AIS_Data\appending.log")

        Dim fileExists As Boolean = File.Exists(filePath)

        Using writer As New StreamWriter(filePath, True)
            If Not fileExists Then
                writer.WriteLine("Start Error Log for today")
            Else
                writer.WriteLine(AisString)
            End If

        End Using
    End Sub
End Class
