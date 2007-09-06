Imports System.Net

Public Class frmDownload
    Private Shared _source As String
    Private Shared _destination As String
    Private Shared _fName As String
    Private Shared Ended As Boolean = False

    Public Shared Property Destination() As String
        Get
            Return _destination
        End Get
        Set(ByVal value As String)
            _destination = value
            _fName = value.Split("\")(value.Split("\").Length - 1)
        End Set
    End Property

    Public Shared Property Source() As String
        Get
            Return _source
        End Get
        Set(ByVal value As String)
            _source = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            lblVersion.Text = "v" & value
            Me.Text = "Downloading HackPets v" & value
        End Set
    End Property

    Delegate Sub DelUpdateUI(ByVal length As Long, ByVal SoFar As Long)

    Private Sub DownloadFailed()
        Ended = True
        Me.Close()
    End Sub

    Private Sub DownloadCancelled()
        Ended = True
        Me.Close()
    End Sub

    Private Sub DownloadComplete()
        UpdateUI(100, 100)
        MessageBox.Show("Download complete. Close HackPets and extract the contents of " & _
        vbCrLf & _fName & " over your existing copy of HackPets.exe in order to " & _
        vbCrLf & "upgrade it.", "Download complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Ended = True
        Me.Close()
    End Sub

    Private Sub UpdateUI(ByVal length As Long, ByVal soFar As Long)
        Me.ProgressBar1.Value = soFar / length * 100
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim Response As HttpWebResponse
        Dim Request As HttpWebRequest
        Try 'Checks if the file exist
            Request = WebRequest.Create(_source)
            Response = Request.GetResponse
        Catch ex As Exception
            MessageBox.Show("An error occurred while downloading file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Invoke(New MethodInvoker(AddressOf DownloadFailed))
            Exit Sub
        End Try

        Dim length As Long = Response.ContentLength 'Size of the response (in bytes)
        ' Reset the progress bar
        Me.Invoke(New DelUpdateUI(AddressOf UpdateUI), New Object() {length, 0})
        Dim writeStream As New IO.FileStream(Destination, IO.FileMode.Create)

        'Replacement for Stream.Position (webResponse stream doesn't support seek)
        Dim nRead As Integer
        Do
            If BackgroundWorker1.CancellationPending Then 'If user abort download
                Exit Do
            End If
            Dim readBytes(4095) As Byte
            Dim bytesread As Integer = Response.GetResponseStream.Read(readBytes, 0, 4096)
            nRead += bytesread
            Me.Invoke(New DelUpdateUI(AddressOf UpdateUI), New Object() {length, nRead})
            If bytesread = 0 Then Exit Do
            writeStream.Write(readBytes, 0, bytesread)
        Loop
        'Close the streams
        Response.GetResponseStream.Close()
        writeStream.Close()

        If BackgroundWorker1.CancellationPending Then
            IO.File.Delete(Destination)
            Me.Invoke(New MethodInvoker(AddressOf DownloadCancelled))
            Exit Sub
        End If
        Me.Invoke(New MethodInvoker(AddressOf DownloadComplete))
    End Sub

    Private Sub Start_Download()
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub frmDownload_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Ended Then
            Me.BackgroundWorker1.CancelAsync()
            e.Cancel = True
        End If
    End Sub

    Private Sub frmDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Start_Download()
    End Sub
End Class