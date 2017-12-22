' ''' ref: https://www.developer.com/net/net/article.php/11087_3599261_2/Redirect-IO-to-a-TextBoxWriter-in-NET.htm'''
' ''' Modified for mutil threading and richboxtext: An Nguyen '''
' ''' 


Imports System.Windows.Forms
Imports System.Text

Public Class RichTextBoxWriter
    Inherits System.IO.TextWriter

    Private control As TextBoxBase
    Private Builder As StringBuilder

    Public Sub New(ByVal control As RichTextBox)
        Me.control = control
        AddHandler control.HandleCreated, _
           New EventHandler(AddressOf OnHandleCreated)
    End Sub

    Public Overrides Sub Write(ByVal ch As Char)
        Write(ch.ToString())
    End Sub

    Public Overrides Sub Write(ByVal s As String)
        If (control.IsHandleCreated) Then
            AppendText(s)
        Else
            BufferText(s)
        End If
    End Sub

    Public Overrides Sub WriteLine(ByVal s As String)
        Write(s + Environment.NewLine)
    End Sub

    Private Sub BufferText(ByVal s As String)
        If (Builder Is Nothing) Then
            Builder = New StringBuilder()
        End If

        Builder.Append(s)
    End Sub

    Private Sub AppendText(ByVal s As String)
        If (Builder Is Nothing = False) Then
            control.AppendText(Builder.ToString())
            Builder = Nothing
        End If
        If control.InvokeRequired Then

            Dim del As New UpdateTextBoxDelegate(AddressOf AppendText)
            Dim args As Object() = {s}
            control.Invoke(del, args)
        Else
            control.AppendText(s)
        End If

    End Sub

    Private Delegate Sub UpdateTextBoxDelegate(ByVal Text As String)




    Private Sub OnHandleCreated(ByVal sender As Object, _
   ByVal e As EventArgs)
        If (Builder Is Nothing = False) Then
            control.AppendText(Builder.ToString())
            Builder = Nothing
        End If
    End Sub

    Public Overrides ReadOnly Property Encoding() As System.Text.Encoding
        Get
            Return Encoding.Default
        End Get
    End Property
End Class
