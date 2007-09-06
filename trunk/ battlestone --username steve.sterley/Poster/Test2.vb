Public Class Test2

    Private Function GetVersionHistory() As DataTable
        Dim ds As New DataSet()
        Try
            Dim Request As Net.HttpWebRequest = Net.WebRequest.Create("http://www.aceofspades.somee.com/version.xml")
            Dim Response As Net.HttpWebResponse
            Response = Request.GetResponse()
            Dim SR As New IO.StreamReader(Response.GetResponseStream())
            ds.ReadXml(SR, XmlReadMode.InferSchema)
            SR.Close()
        Catch ex As Exception
        End Try
        Return ds.Tables(0)
    End Function

    Private Function ChooseToDownload(ByVal dt As DataTable) As Boolean
        Dim dRow() As DataRow = dt.Select("Version > 2.0")
        frmNewVersion.Version = dRow(dRow.Length - 1).Item("Version")
        frmNewVersion.FileSize = dRow(dRow.Length - 1).Item("FileSize")
        Dim strUpdates = ""
        For Each row As DataRow In dRow
            Dim lines() As String = row.Item("Note").Split("|")
            For Each line As String In lines
                strUpdates &= "»    " & line & vbCrLf
            Next
        Next
        frmNewVersion.Updates = strUpdates
        frmNewVersion.ShowInTaskbar = False
        If frmNewVersion.ShowDialog(Me) = Windows.Forms.DialogResult.Yes Then
            Return True
        End If
        Return False
    End Function

    Private Sub Test2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Show()
        Dim dt As DataTable = GetVersionHistory()
        If Not dt Is Nothing Then
            If ChooseToDownload(dt) Then
                Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
                Dim strSource As String = dt.Rows(dt.Rows.Count - 1).Item("File")
                Me.SaveFileDialog1.FileName = dt.Rows(dt.Rows.Count - 1).Item("FileName")
                If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Me.WindowState = FormWindowState.Normal
                    frmDownload.Destination = Me.SaveFileDialog1.FileName
                    frmDownload.Source = strSource
                    frmDownload.Version = dt.Rows(dt.Rows.Count - 1).Item("Version")
                    frmDownload.ShowInTaskbar = False
                    frmDownload.ShowDialog(Me)
                Else
                    Me.WindowState = FormWindowState.Normal
                End If
            End If
        End If
    End Sub
End Class