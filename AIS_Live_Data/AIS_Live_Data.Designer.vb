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
        Me.AIS_Read_Data_Time = New System.Windows.Forms.Timer(Me.components)
        Me.CollectDataBtn = New System.Windows.Forms.Button()
        Me.EndTime = New System.Windows.Forms.Label()
        Me.StartTime = New System.Windows.Forms.Label()
        Me.btnClearDir = New System.Windows.Forms.Button()
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
        Me.CollectDataBtn.Location = New System.Drawing.Point(12, 117)
        Me.CollectDataBtn.Name = "CollectDataBtn"
        Me.CollectDataBtn.Size = New System.Drawing.Size(134, 23)
        Me.CollectDataBtn.TabIndex = 2
        Me.CollectDataBtn.Text = "Start Collecting Data"
        Me.CollectDataBtn.UseVisualStyleBackColor = True
        '
        'EndTime
        '
        Me.EndTime.AutoSize = True
        Me.EndTime.Location = New System.Drawing.Point(205, 158)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(55, 13)
        Me.EndTime.TabIndex = 4
        Me.EndTime.Text = "End Time:"
        '
        'StartTime
        '
        Me.StartTime.AutoSize = True
        Me.StartTime.Location = New System.Drawing.Point(205, 92)
        Me.StartTime.Name = "StartTime"
        Me.StartTime.Size = New System.Drawing.Size(58, 13)
        Me.StartTime.TabIndex = 3
        Me.StartTime.Text = "Start Time:"
        '
        'btnClearDir
        '
        Me.btnClearDir.Location = New System.Drawing.Point(12, 158)
        Me.btnClearDir.Name = "btnClearDir"
        Me.btnClearDir.Size = New System.Drawing.Size(134, 23)
        Me.btnClearDir.TabIndex = 5
        Me.btnClearDir.Text = "Reset Database"
        Me.btnClearDir.UseVisualStyleBackColor = True
        '
        'AIS_Live_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 262)
        Me.Controls.Add(Me.btnClearDir)
        Me.Controls.Add(Me.EndTime)
        Me.Controls.Add(Me.StartTime)
        Me.Controls.Add(Me.CollectDataBtn)
        Me.Name = "AIS_Live_Data"
        Me.ShowIcon = False
        Me.Text = "AIS Live Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AIS_Read_Data_Time As System.Windows.Forms.Timer
    Friend WithEvents CollectDataBtn As System.Windows.Forms.Button
    Friend WithEvents EndTime As System.Windows.Forms.Label
    Friend WithEvents StartTime As System.Windows.Forms.Label
    Friend WithEvents btnClearDir As System.Windows.Forms.Button

End Class
