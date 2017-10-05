Public Class AIS_Live_Data
    Dim TcpIP As TcpIP
    Dim dataDir
    Private Sub AIS_Live_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TcpIP = New TcpIP(AIS_Read_Data_Time, "C:\AIS_Data\ais_live_data.log")

    End Sub

    Private Sub CollectDataBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectDataBtn.Click
        TcpIP.deleteSchemaIni()
        StartTime.Text = DateTime.Now.ToString
        TcpIP.Connect()
        EndTime.Text = DateTime.Now.ToString

    End Sub

    Private Sub btnClearDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDir.Click
        TcpIP.cleanDir("C:\AIS_Data")

    End Sub
End Class
