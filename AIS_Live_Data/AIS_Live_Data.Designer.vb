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
        Me.btnClearDir = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblElapsed = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.lblProcessing = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SelectTime = New System.Windows.Forms.ComboBox()
        Me.EndTime = New System.Windows.Forms.Label()
        Me.CollectDataBtn = New System.Windows.Forms.Button()
        Me.StartTime = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Label4 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(115, 9)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(122, 13)
        Label4.TabIndex = 12
        Label4.Text = "Collecting AIS Live Data"
        '
        'AIS_Read_Data_Time
        '
        Me.AIS_Read_Data_Time.Enabled = True
        Me.AIS_Read_Data_Time.Interval = 500
        '
        'btnClearDir
        '
        Me.btnClearDir.Enabled = False
        Me.btnClearDir.Location = New System.Drawing.Point(17, 191)
        Me.btnClearDir.Name = "btnClearDir"
        Me.btnClearDir.Size = New System.Drawing.Size(134, 23)
        Me.btnClearDir.TabIndex = 5
        Me.btnClearDir.Text = "Reset Database"
        Me.btnClearDir.UseVisualStyleBackColor = True
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
        Me.lblElapsed.Location = New System.Drawing.Point(22, 150)
        Me.lblElapsed.Name = "lblElapsed"
        Me.lblElapsed.Size = New System.Drawing.Size(70, 13)
        Me.lblElapsed.TabIndex = 8
        Me.lblElapsed.Text = "Elapsed time:"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(17, 105)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 9
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.AutoSize = True
        Me.lblCurrentTime.Location = New System.Drawing.Point(141, 110)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(69, 13)
        Me.lblCurrentTime.TabIndex = 11
        Me.lblCurrentTime.Text = "Current time: "
        '
        'lblProcessing
        '
        Me.lblProcessing.AutoSize = True
        Me.lblProcessing.Location = New System.Drawing.Point(141, 81)
        Me.lblProcessing.Name = "lblProcessing"
        Me.lblProcessing.Size = New System.Drawing.Size(50, 13)
        Me.lblProcessing.TabIndex = 10
        Me.lblProcessing.Text = "Message"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblStartTime)
        Me.Panel2.Controls.Add(Me.btnStart)
        Me.Panel2.Controls.Add(Me.btnStop)
        Me.Panel2.Controls.Add(Me.lblElapsed)
        Me.Panel2.Controls.Add(Me.lblCurrentTime)
        Me.Panel2.Controls.Add(Me.btnClearDir)
        Me.Panel2.Controls.Add(Me.lblProcessing)
        Me.Panel2.Location = New System.Drawing.Point(12, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(477, 265)
        Me.Panel2.TabIndex = 13
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(141, 43)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(57, 13)
        Me.lblStartTime.TabIndex = 12
        Me.lblStartTime.Text = "Start time: "
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(158, 309)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(215, 23)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(101, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(248, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Collecting data on selected interval time in seconds"
        '
        'SelectTime
        '
        Me.SelectTime.FormattingEnabled = True
        Me.SelectTime.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30"})
        Me.SelectTime.Location = New System.Drawing.Point(120, 30)
        Me.SelectTime.Name = "SelectTime"
        Me.SelectTime.Size = New System.Drawing.Size(49, 21)
        Me.SelectTime.TabIndex = 6
        '
        'EndTime
        '
        Me.EndTime.AutoSize = True
        Me.EndTime.Location = New System.Drawing.Point(186, 141)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(51, 13)
        Me.EndTime.TabIndex = 4
        Me.EndTime.Text = "End time:"
        '
        'CollectDataBtn
        '
        Me.CollectDataBtn.DialogResult = System.Windows.Forms.DialogResult.No
        Me.CollectDataBtn.Location = New System.Drawing.Point(20, 86)
        Me.CollectDataBtn.Name = "CollectDataBtn"
        Me.CollectDataBtn.Size = New System.Drawing.Size(134, 23)
        Me.CollectDataBtn.TabIndex = 2
        Me.CollectDataBtn.Text = "Start Collecting Data"
        Me.CollectDataBtn.UseVisualStyleBackColor = True
        '
        'StartTime
        '
        Me.StartTime.AutoSize = True
        Me.StartTime.Location = New System.Drawing.Point(183, 91)
        Me.StartTime.Name = "StartTime"
        Me.StartTime.Size = New System.Drawing.Size(54, 13)
        Me.StartTime.TabIndex = 3
        Me.StartTime.Text = "Start time:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "seconds"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 141)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Reset Database"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.StartTime)
        Me.Panel1.Controls.Add(Me.CollectDataBtn)
        Me.Panel1.Controls.Add(Me.EndTime)
        Me.Panel1.Controls.Add(Me.SelectTime)
        Me.Panel1.Location = New System.Drawing.Point(495, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(353, 186)
        Me.Panel1.TabIndex = 12
        Me.Panel1.Visible = False
        '
        'AIS_Live_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(497, 340)
        Me.ControlBox = False
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AIS_Live_Data"
        Me.Text = "AIS Live Data"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AIS_Read_Data_Time As System.Windows.Forms.Timer
    Friend WithEvents btnClearDir As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblElapsed As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents lblProcessing As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SelectTime As System.Windows.Forms.ComboBox
    Friend WithEvents EndTime As System.Windows.Forms.Label
    Friend WithEvents CollectDataBtn As System.Windows.Forms.Button
    Friend WithEvents StartTime As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
