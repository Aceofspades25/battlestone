Imports System.IO
Imports System.Data.sqlClient

Public Class ParseDocs
    Dim tExecute As System.Threading.Thread
    Dim total As Integer
    Dim cnt As Integer

    Private Sub Parse_Documents()
        If tbxFolder.Text = "" Then
            MessageBox.Show("Lets have a folder to deal with here!!!!", "WTF???", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If cbDataBase.Text = "" Then
            MessageBox.Show("Lets have a database name already!!!!", "WTF???", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim successful As Integer = 0
        Dim failed As Integer = 0
        Dim count As Integer = 0
        Dim strText As String = ""
        tbxResults.Text = ""
        Dim strClaimsCon As String = "server=$SERVERNAME;user=sbsuser;pwd=sbsuser;database=site"
        strClaimsCon = strClaimsCon.Replace("$SERVERNAME", cbDataBase.Text)
        Dim di As New DirectoryInfo(tbxFolder.Text)
        Dim files() As FileInfo = di.GetFiles("*.pdf")
        total = files.Length
        Dim startTime As DateTime = Date.Now
        For Each singleFile As FileInfo In files
            strText = ""
            'Last here.... trying to get the text box updating nicely
            strText &= "Parsing document " & singleFile.Name & vbCrLf
            Dim claimID As String = singleFile.Name.Split("_")(0).Replace("claim", "")
            Dim docID As String = singleFile.Name.Split("_")(1).Split(".")(0).Replace("doc", "")
            Dim dateCreated As DateTime = singleFile.LastWriteTime
            strText &= "Claim ID: " & claimID & vbTab & "Document ID: " & _
            docID & vbTab & "Date created: " & dateCreated.ToString() & vbCrLf
            strText &= "Creating record..." & vbCrLf
            'tbxResults.ScrollToCaret()
            'System.Threading.Thread.Sleep(100)
            'tbxResults.Refresh()
            Dim myCon As New SqlConnection(strClaimsCon)
            Try
                Dim strCommand As String = "IF (SELECT COUNT(DocumentID) FROM TblInsuranceClaimDocument " & _
                "WHERE InsuranceClaimID = " & claimID & " AND DocTypeID = " & docID & ") = 0 " & _
                "INSERT TblInsuranceClaimDocument(InsuranceClaimID, DateAdded, DocTypeID, DocName)" & _
                "VALUES (" & claimID & ", '" & dateCreated.ToString("yyyy/MM/dd HH:mm:ss") & "', " & docID & ", '" & singleFile.Name & "')"
                Dim sqlInsert As New SqlCommand(strCommand, myCon)
                myCon.Open()
                Dim numRows = sqlInsert.ExecuteNonQuery()
                myCon.Close()
                If numRows = 1 Then
                    successful += 1
                    strText &= "Done." & vbCrLf & vbCrLf

                    'tbxResults.Refresh()
                Else
                    failed += 1
                    strText &= "Insert failed. This documents record already exists." & vbCrLf & vbCrLf

                    'tbxResults.Refresh()
                End If
            Catch ex As Exception
                Me.btnDirectory.Cursor = Cursors.Default
                Me.cbDataBase.Cursor = Cursors.Default
                Me.btnExecute.Cursor = Cursors.Default
                MessageBox.Show("DB Connection failed! Are you sure you know what you're doing by running this?", "WTF???", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                tbxResults.Text &= "Job failed." & vbCrLf & vbCrLf & "GAME OVER."
                If myCon.State = ConnectionState.Open Then myCon.Close()
                Return
            End Try
            'System.Threading.Thread.Sleep(500)
            count += 1
            cnt = count
            Dim perc As Single = count / files.Length * 100
            ProgressBar1.Value = perc
            Me.Text = "Parse SBS documents (" & perc.ToString("0.0") & "%)"
            Dim ts As System.TimeSpan = Date.Now.Subtract(startTime)
            Dim tsRemain As New TimeSpan(0, 0, (100 - perc) * (ts.TotalSeconds / perc))
            lblStatus.Text = count & "/" & files.Length & "      (" & perc.ToString("0.0") & "%)      " & tsRemain.ToString() & " remaining"
            lblStatus.Update()
            'tbxResults.Text &= strText
            'tbxResults.SelectionStart = tbxResults.Text.Length
            'tbxResults.ScrollToCaret()
            'System.Threading.Thread.CurrentThread.Suspe()
        Next
        Me.btnDirectory.Cursor = Cursors.Default
        Me.cbDataBase.Cursor = Cursors.Default
        Me.btnExecute.Cursor = Cursors.Default
        MessageBox.Show(successful & " document records created successfully." & vbCrLf & failed & " records failed.", "Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Me.btnDirectory.Cursor = Cursors.WaitCursor
        Me.cbDataBase.Cursor = Cursors.WaitCursor
        Me.btnExecute.Cursor = Cursors.WaitCursor

        tExecute = New System.Threading.Thread(AddressOf Parse_Documents)
        tExecute.Start()
    End Sub

    Private Sub btnDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectory.Click
        Dim res As DialogResult = Me.FolderBrowserDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            tbxFolder.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If tExecute.IsAlive Then
            tExecute.Suspend()
            'tExecute.Th()
            If MessageBox.Show("Are you sure you want to end this process here?", "WTF???", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                tExecute.Resume()
                tExecute.Abort()
                MessageBox.Show("Process aborted!! " & cnt & " of " & total & " files parsed.", "Bummer man.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                tExecute.Resume()
            End If
        End If
    End Sub
End Class
