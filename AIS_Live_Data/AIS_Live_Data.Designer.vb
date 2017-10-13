<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AIS_Live_Data
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Label4 As System.Windows.Forms.Label
        Me.AIS_Read_Data_Time = New System.Windows.Forms.Timer(Me.components)
        Me.CollectDataBtn = New System.Windows.Forms.Button()
        Me.EndTime = New System.Windows.Forms.Label()
        Me.StartTime = New System.Windows.Forms.Label()
        Me.btnClearDir = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblElapsed = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Close = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'AIS_Read_Data_Time
        '
        Me.AIS_Read_Data_Time.Enabled = True
        Me.AIS_Read_Data_Time.Interval = 500
        '
        'CollectDataBtn
        '
        Me.CollectDataBtn.DialogResult = System.Windows.Forms.DialogResult.No
        Me.CollectDataBtn.Location = New System.Drawing.Point(20, 105)
        Me.CollectDataBtn.Name = "CollectDataBtn"
        Me.CollectDataBtn.Size = New System.Drawing.Size(134, 23)
        Me.CollectDataBtn.TabIndex = 2
        Me.CollectDataBtn.Text = "Start Collecting Data"
        Me.CollectDataBtn.UseVisualStyleBackColor = True
        '
        'EndTime
        '
        Me.EndTime.AutoSize = True
        Me.EndTime.Location = New System.Drawing.Point(186, 160)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(55, 13)
        Me.EndTime.TabIndex = 4
        Me.EndTime.Text = "End Time:"
        '
        'StartTime
        '
        Me.StartTime.AutoSize = True
        Me.StartTime.Location = New System.Drawing.Point(183, 110)
        Me.StartTime.Name = "StartTime"
        Me.StartTime.Size = New System.Drawing.Size(58, 13)
        Me.StartTime.TabIndex = 3
        Me.StartTime.Text = "Start Time:"
        '
        'btnClearDir
        '
        Me.btnClearDir.Location = New System.Drawing.Point(20, 155)
        Me.btnClearDir.Name = "btnClearDir"
        Me.btnClearDir.Size = New System.Drawing.Size(134, 23)
        Me.btnClearDir.TabIndex = 5
        Me.btnClearDir.Text = "Reset Database"
        Me.btnClearDir.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30"})
        Me.ComboBox1.Location = New System.Drawing.Point(120, 49)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(17, 38)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblElapsed
        '
        Me.lblElapsed.AutoSize = True
        Me.lblElapsed.Location = New System.Drawing.Point(24, 155)
        Me.lblElapsed.Name = "lblElapsed"
        Me.lblElapsed.Size = New System.Drawing.Size(74, 13)
        Me.lblElapsed.TabIndex = 8
        Me.lblElapsed.Text = "Elapsed Time:"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(17, 91)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 9
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.StartTime)
        Me.Panel1.Controls.Add(Me.CollectDataBtn)
        Me.Panel1.Controls.Add(Me.EndTime)
        Me.Panel1.Controls.Add(Me.btnClearDir)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(370, 203)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.btnStart)
        Me.Panel2.Controls.Add(Me.btnStop)
        Me.Panel2.Controls.Add(Me.lblElapsed)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(398, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 203)
        Me.Panel2.TabIndex = 13
        '
        'Close
        '
        Me.Close.Location = New System.Drawing.Point(283, 256)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(215, 23)
        Me.Close.TabIndex = 14
        Me.Close.Text = "Exit"
        Me.Close.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(114, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Collect data on selected interval time in seconds"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(491, 15)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(155, 13)
        Label4.TabIndex = 12
        Label4.Text = "Collecting data on time demand"
        '
        'AIS_Live_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 291)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AIS_Live_Data"
        Me.ShowIcon = False
        Me.Text = "AIS Live Data"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AIS_Read_Data_Time As System.Windows.Forms.Timer
    Friend WithEvents CollectDataBtn As System.Windows.Forms.Button
    Friend WithEvents EndTime As System.Windows.Forms.Label
    Friend WithEvents StartTime As System.Windows.Forms.Label
    Friend WithEvents btnClearDir As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblElapsed As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Close As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
