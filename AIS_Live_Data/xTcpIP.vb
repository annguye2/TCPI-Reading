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

    Public Sub CloseConnection()
        Try
            stream.Close()
            client.Close()
        Catch ex As Exception
        End Try
    End Sub

End Class
