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
        Dim Label4 As System.Windows.Forms.Label
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
        Me.rtbProcessingMsg = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(155, 9)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(122, 13)
        Label4.TabIndex = 12
        Label4.Text = "Collecting AIS Live Data"
        '
        'btnClearDir
        '
        Me.btnClearDir.Enabled = False
        Me.btnClearDir.Location = New System.Drawing.Point(36, 182)
        Me.btnClearDir.Name = "btnClearDir"
        Me.btnClearDir.Size = New System.Drawing.Size(134, 23)
        Me.btnClearDir.TabIndex = 5
        Me.btnClearDir.Text = "Reset Database"
        Me.btnClearDir.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(36, 36)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblElapsed
        '
        Me.lblElapsed.AutoSize = True
        Me.lblElapsed.Location = New System.Drawing.Point(41, 151)
        Me.lblElapsed.Name = "lblElapsed"
        Me.lblElapsed.Size = New System.Drawing.Size(70, 13)
        Me.lblElapsed.TabIndex = 8
        Me.lblElapsed.Text = "Elapsed time:"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(36, 103)
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
        Me.lblCurrentTime.Location = New System.Drawing.Point(160, 108)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(69, 13)
        Me.lblCurrentTime.TabIndex = 11
        Me.lblCurrentTime.Text = "Current time: "
        '
        'lblProcessing
        '
        Me.lblProcessing.AutoSize = True
        Me.lblProcessing.Location = New System.Drawing.Point(160, 79)
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
        Me.Panel2.Size = New System.Drawing.Size(374, 227)
        Me.Panel2.TabIndex = 13
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(160, 41)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(57, 13)
        Me.lblStartTime.TabIndex = 12
        Me.lblStartTime.Text = "Start time: "
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(84, 592)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(215, 23)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'rtbProcessingMsg
        '
        Me.rtbProcessingMsg.Location = New System.Drawing.Point(12, 304)
        Me.rtbProcessingMsg.Name = "rtbProcessingMsg"
        Me.rtbProcessingMsg.Size = New System.Drawing.Size(374, 282)
        Me.rtbProcessingMsg.TabIndex = 17
        Me.rtbProcessingMsg.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 277)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Processing Messages"
        '
        'AIS_Live_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(400, 619)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbProcessingMsg)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AIS_Live_Data"
        Me.Text = "AIS Live Data"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents rtbProcessingMsg As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
