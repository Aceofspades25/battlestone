Imports HackPets.FightBattle
Imports HackPets.SellItems

Public Class frmMain

#Region " Commented code "
    ''Dim cookieJar As New Net.CookieContainer()
    ''Request.CookieContainer = cookieJar

    'Dim postString As String = tbxName1.Text & "=" & tbxValue1.Text
    'postString &= "&" & tbxName2.Text & "=" & tbxValue2.Text
    'postString &= "&" & tbxName3.Text & "=" & tbxValue3.Text
    'postString &= "&" & tbxName4.Text & "=" & tbxValue4.Text
    'postString = ""
    'MessageBox.Show(postString)

    'Request.ContentLength = postString.Length

    'Dim SW As New IO.StreamWriter(Request.GetRequestStream())
    'SW.Write(postString)
    'SW.Close()
    ' Try a byte stream instead
    'Dim S As IO.Stream = Request.GetRequestStream()
    'Dim postData() As Byte = System.Text.Encoding.ASCII.GetBytes(postString)
    'S.Write(postData, 0, postData.Length)
    'S.Close()

    'Private Sub PostData()
    '    Dim URL = "http://www.eggmon.com/?cpid=1095585"
    '    Dim Request As Net.HttpWebRequest = Net.WebRequest.Create(tbxURL.Text)
    '    Dim Response As Net.HttpWebResponse
    '    Request.Method = "HTTP_POST" '
    '    Request.ContentType = "application/x-www-form-urlencoded"
    '    ' Add cookies for authentication (These can be fetched from the persons URL)
    '    Request.Headers.Add(Net.HttpRequestHeader.Cookie, "692cc73d766279a46f0aaac1d104771e_user=613866500;" & _
    '    "692cc73d766279a46f0aaac1d104771e_session_key=0555774305c35c4214c8006d-613866500;" & _
    '    "692cc73d766279a46f0aaac1d104771e=59fa7025b215c7a9abdf234e01cafe02")
    '692cc73d766279a46f0aaac1d104771e

    '    Response = Request.GetResponse()
    '    Dim SR As New IO.StreamReader(Response.GetResponseStream())
    '    Dim ResponseData As String = SR.ReadToEnd()
    '    SR.Close()
    '    Me.tbxResult.Text = ResponseData
    '    'MessageBox.Show(Response.ResponseUri.AbsoluteUri)
    'End Sub
#End Region

#Region " Global variables and structures "
    Public Structure Creature
        Dim mcID As Integer
        Dim mPic As System.Drawing.Bitmap
        Dim mName As String
        Dim powerRating As Integer
        Dim location As String
        ' Each monster is given a power rating to try work out how much they will damage you at their various levels
        ' It is assumed a pwr rating of 10 will knock off all of your HP 1 level below you
        ' A pwr rating of 1 will do insig. damage one level below you
        ' etc.
    End Structure

    Private Enum FormMode
        Settings
        Run
    End Enum

    ' This persons current pet ID (fetched from the query string)
    Dim cpid As String
    ' The api key for this application (fetched from the query string)
    Dim fbAPIKey As String
    ' The session key for this user (fetched from the query string)
    Dim fbSessionKey As String
    ' This persons facebook user ID (fetched from the query string)
    Dim fbUser As String
    ' A secret passcode, not contained in the query string, but needed as part of the session cookie
    ' this is obtained from the return cookie, after making an initial request  to the URL entered.
    Dim fbPassCode As String

    ' An array of the various options shown in the monster selector (setup in Init())
    Public creatures(10) As Creature
    ' The currently selected creature in ther monster selector
    Dim currentCreature As Integer = 1
    ' The size of the creature array for the monster selector
    Dim numCreatures As Integer = 10

    Dim reconnectNecessary As Boolean = True
    ' Store whether or not they have already tested the connect string, if they have, don't do this again.
    ' If the text for cbURL ever changes then reset reconnectNecessary to True
    Dim requestClosing As Boolean = False
    ' If this is ever set to true, this application will close, the moment battling is stopped

    Dim currentFormMode As FormMode = FormMode.Settings
    ' The thread on which to conduct the battles
    Dim fightThread As System.Threading.Thread
    Dim sellThread As System.Threading.Thread
    Dim visitedTab1 As Boolean = False
#End Region

    'Private Declare Function IsThemeActive Lib "uxtheme.dll" () As Boolean
    'Private Declare Function IsAppThemed Lib "uxtheme.dll" () As Boolean

#Region " Check for updates "

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
            Return Nothing
        End Try
        If ds.Tables.Count = 0 Then Return Nothing
        Return ds.Tables(0)
    End Function

    Private Function ChooseToDownload(ByVal dt As DataTable) As Boolean
        Dim dRow() As DataRow = dt.Select("Version > 2.2")
        If dRow.Length = 0 Then Return False
        frmNewVersion.Version = dRow(dRow.Length - 1).Item("Version")
        frmNewVersion.FileSize = dRow(dRow.Length - 1).Item("FileSize")
        Dim strUpdates = ""
        For Each row As DataRow In dRow
            Dim lines() As String = row.Item("Note").Split("|")
            For Each line As String In lines
                Dim subLines() As String = line.Split(";")
                strUpdates &= "»    " & subLines(0) & vbCrLf
                For i As Integer = 0 To subLines.Length - 1
                    If i <> 0 Then strUpdates &= "     " & subLines(i) & vbCrLf
                Next i
            Next
        Next
        frmNewVersion.Updates = strUpdates
        frmNewVersion.ShowInTaskbar = False
        If frmNewVersion.ShowDialog(Me) = Windows.Forms.DialogResult.Yes Then
            Return True
        End If
        Return False
    End Function

    Private Sub Check_Updates()
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

#End Region

#Region " Initialisation "
    Private Sub SetNoStyles()
        Me.btnLeft.Image = Global.HackPets.My.Resources.Resources.LeftWhite
        Me.btnRight.Image = Global.HackPets.My.Resources.Resources.RightWhite
        Me.btnFight.ForeColor = Color.White
        Me.btnSell.ForeColor = Color.White
        Me.btnClearHistory.ForeColor = Color.White
        Me.btnSaveLog.ForeColor = Color.White
        Me.btnExit.ForeColor = Color.White
        frmNewVersion.btnNo.ForeColor = Color.White
        frmNewVersion.btnYes.ForeColor = Color.White
        frmDownload.btnCancel.ForeColor = Color.White
    End Sub

    Private Sub Init()

        creatures(0).mName = "Random"
        creatures(0).mPic = Global.HackPets.My.Resources.Resources.Random

        creatures(1).mName = "Greenwich"
        creatures(1).mPic = Global.HackPets.My.Resources.Resources.GreenwhichForest

        creatures(2).mName = "Black cove"
        creatures(2).mPic = Global.HackPets.My.Resources.Resources.BlackCove

        creatures(3).mName = "Ant"
        creatures(3).mPic = Global.HackPets.My.Resources.Resources.Ant
        creatures(3).mcID = 3
        creatures(3).powerRating = 1
        creatures(3).location = "Greenwich Forest"

        creatures(4).mName = "Spider"
        creatures(4).mPic = Global.HackPets.My.Resources.Resources.Spider
        creatures(4).mcID = 4
        creatures(4).powerRating = 3
        creatures(4).location = "Greenwich Forest"

        creatures(5).mName = "Scorpion"
        creatures(5).mPic = Global.HackPets.My.Resources.Resources.Scorpion
        creatures(5).mcID = 1
        creatures(5).powerRating = 5
        creatures(5).location = "Greenwich Forest"

        creatures(6).mName = "Mantis"
        creatures(6).mPic = Global.HackPets.My.Resources.Resources.Mantis
        creatures(6).mcID = 2
        creatures(6).powerRating = 4
        creatures(6).location = "Greenwich Forest"

        creatures(7).mName = "Water mok"
        creatures(7).mPic = Global.HackPets.My.Resources.Resources.WaterMok
        creatures(7).mcID = 5
        creatures(7).powerRating = 6
        creatures(7).location = "The Black Cove"

        creatures(8).mName = "Toxic monster"
        creatures(8).mPic = Global.HackPets.My.Resources.Resources.ToxicMonster
        creatures(8).mcID = 9
        creatures(8).powerRating = 8
        creatures(8).location = "The Black Cove"

        creatures(9).mName = "Baracod"
        creatures(9).mPic = Global.HackPets.My.Resources.Resources.Baracod
        creatures(9).mcID = 6
        creatures(9).powerRating = 10
        creatures(9).location = "The Black Cove"

        '
        ' Check if the user is using visual styles... if not, make the button contents white
        '
        'MessageBox.Show("App themed : " & IsAppThemed())
        'MessageBox.Show("Theme active : " & IsThemeActive())
        Try
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\ThemeManager")
            If key Is Nothing Then
                ' If they have an old OS that doesn't know about theming
                SetNoStyles()
            Else
                If CType(key.GetValue("ThemeActive"), String) = "0" Then
                    ' If they have disabled theming
                    SetNoStyles()
                End If
            End If
        Catch Ex As Exception
        End Try

        Me.pbCurrent.Image = creatures(currentCreature).mPic
        Me.pbNext.Image = creatures(nextMon).mPic
        Me.tbxCName.Text = creatures(currentCreature).mName

        If My.Settings.LastWindowSize = "Max" Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
            Me.Width = CType(My.Settings.LastWindowSize.Split(",")(0), Integer)
            Me.Height = CType(My.Settings.LastWindowSize.Split(",")(1), Integer)
        End If

        Populate_URL_History()

        Me.tbxConsole.Text = "-- Hack Pets results console v2.2 © --" & vbCrLf & vbCrLf & "CONSOLE>  "
        Check_Updates()
    End Sub
#End Region

#Region " UI Functions and subroutines "
    Private Function nextMon() As Integer
        Dim res As Integer = currentCreature + 1
        If res = numCreatures Then res = 0
        Return res
    End Function

    Private Function prevMon() As Integer
        Dim res As Integer = currentCreature - 1
        If res = -1 Then res = numCreatures - 1
        Return res
    End Function

    Private Sub Scroll_Creatures_Right()
        pbNext.Location = New Point(100, 0)
        Me.pbNext.Image = creatures(nextMon).mPic
        For i As Integer = 1 To 10
            pbCurrent.Location = New Point(-10 * i, 0)
            pbNext.Location = New Point(100 - 10 * i, 0)
            Me.pnlMonster.Refresh()
            System.Threading.Thread.Sleep(10)
        Next i
        currentCreature = nextMon()
        pbCurrent.Location = New Point(0, 0)
        pbNext.Location = New Point(100, 0)
        pbCurrent.Image = creatures(currentCreature).mPic
        pbNext.Image = creatures(nextMon).mPic
        Me.tbxCName.Text = creatures(currentCreature).mName
    End Sub

    Private Sub Scroll_Creatures_Left()
        pbNext.Location = New Point(-100, 0)
        Me.pbNext.Image = creatures(prevMon).mPic
        For i As Integer = 1 To 10
            pbCurrent.Location = New Point(10 * i, 0)
            pbNext.Location = New Point(-100 + 10 * i, 0)
            Me.pnlMonster.Refresh()
            System.Threading.Thread.Sleep(10)
        Next i
        currentCreature = prevMon()
        pbCurrent.Location = New Point(0, 0)
        pbNext.Location = New Point(100, 0)
        Me.pbCurrent.Image = creatures(currentCreature).mPic
        pbNext.Image = creatures(nextMon).mPic
        Me.tbxCName.Text = creatures(currentCreature).mName
    End Sub

    Public Sub Write(ByVal newLine As String)
        newLine = newLine.Replace(vbCrLf, vbCrLf & "CONSOLE>  ")
        tbxConsole.Focus()
        tbxConsole.Text &= newLine & vbCrLf & "CONSOLE>  "
        tbxConsole.SelectionStart = tbxConsole.Text.Length()
        tbxConsole.ScrollToCaret()
        tbxConsole.Refresh()
    End Sub

    Private Sub Update_Notify_Icon()
        Me.NotifyIcon1.Text = "Status: " & lblStatus.Text
        Me.StatusToolStripMenuItem.Text = "Status: " & lblStatus.Text
        If Me.Text.IndexOf("(") <> -1 Then
            Me.PercentageToolStripMenuItem.Text = "Percentage: " & Me.Text.Split("(")(1).Split(")")(0)
        Else
            Me.PercentageToolStripMenuItem.Text = "Percentage: "
        End If
        Me.TimeRemainingToolStripMenuItem.Text = "Time remaining: " & lblTimeRemaining.Text
    End Sub

    Public Sub Set_Status(ByVal newStatus As String)
        lblStatus.Text = newStatus
        Update_Notify_Icon()
    End Sub

    Public Sub Set_Percent(ByVal newVal As Double)
        Me.ProgressBar1.Value = newVal
        Me.Text = "HackPets v2.2 " & "(" & newVal.ToString("0") & "%)"
        Update_Notify_Icon()
    End Sub

    Public Sub Set_Time_Remaining(ByVal newVal As String)
        Me.lblTimeRemaining.Text = newVal
        Update_Notify_Icon()
    End Sub

    Private Sub SwitchToRunMode()
        ' Switches the form to fight mode. Most Input fields become disabled
        ' Fight button disables, play button disables pause and stop buttons enable
        'Recursively_Set_Enabled(Me.pnlData, False)
        Me.btnFight.Enabled = False
        Me.btnSell.Enabled = False
        Me.btnPlay.Enabled = False
        Me.btnPlay.Image = Global.HackPets.My.Resources.Resources.playDisabled

        Me.btnPause.Enabled = True
        Me.btnPause.Image = Global.HackPets.My.Resources.Resources.pause
        Me.btnStop.Enabled = True
        Me.btnStop.Image = Global.HackPets.My.Resources.Resources._stop

        ' The Notify Icon toolstrip
        Me.PauseBattlesToolStripMenuItem.Enabled = True
        Me.PauseBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.pause
        Me.ResumeBattlesToolStripMenuItem.Enabled = False
        Me.ResumeBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.playDisabled
        Me.StopBattlesToolStripMenuItem.Enabled = True
        Me.StopBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources._stop

        currentFormMode = FormMode.Run
    End Sub

    Private Sub SwitchToSettingsMode()
        ' Switches the form to settings mode. Most Input fields become enabled
        ' Fight button enables, pause and stop and play buttons disable
        'Recursively_Set_Enabled(Me.pnlData, True)
        Me.btnFight.Enabled = True
        Me.btnSell.Enabled = True
        Me.btnPlay.Enabled = False
        Me.btnPlay.Image = Global.HackPets.My.Resources.Resources.playDisabled

        Me.btnPause.Enabled = False
        Me.btnPause.Image = Global.HackPets.My.Resources.Resources.pauseDisabled
        Me.btnStop.Enabled = False
        Me.btnStop.Image = Global.HackPets.My.Resources.Resources.stopDisabled

        ' The Notify Icon toolstrip
        Me.PauseBattlesToolStripMenuItem.Enabled = False
        Me.PauseBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.pauseDisabled
        Me.ResumeBattlesToolStripMenuItem.Enabled = False
        Me.ResumeBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.playDisabled
        Me.StopBattlesToolStripMenuItem.Enabled = False
        Me.StopBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.stopDisabled
        currentFormMode = FormMode.Settings
    End Sub

    Public Function FilterOutTags(ByVal strHTML As String, ByRef filePointer As Integer, ByVal strSearch As String, ByVal tagLayers As String) As String
        ' This function, takes a long string of HTML... searches for the first instance of the search string
        ' Digs down into the tag layers specified and retrieves the result embeded between the last and 2nd to last tag
        ' First: Find the index of the searchString
        If Not strHTML.Contains(strSearch) Then Return "???"
        Dim indexStart As Integer = strHTML.IndexOf(strSearch, filePointer)
        Dim tags() As String = tagLayers.Split("|")
        ' Find the tags within the HTML until we reach the 2nd to last one
        For i As Integer = 1 To tags.Length - 1
            indexStart = strHTML.IndexOf(tags(i - 1), indexStart) + 1
        Next i
        ' Move to the closing brace of the second to last tag
        indexStart = strHTML.IndexOf(">", indexStart) + 1
        Dim indexEnd As Integer = strHTML.IndexOf(tags(tags.Length - 1), indexStart)
        Return strHTML.Substring(indexStart, indexEnd - indexStart).Trim()
    End Function

    Public Function FilterIntoTags(ByVal strHTML As String, ByRef filePointer As Integer, ByVal strSearch As String, ByVal tagLayers As String, ByVal attribName As String) As String
        ' This function, takes a long string of HTML... searches for the first instance of the search string, after filePointer
        ' Digs down into the tag layers specified and retrieves the attribute specified embeded within the last tag.
        ' First: Find the index of the searchString
        If strHTML.IndexOf(strSearch, filePointer) = -1 Then Return Nothing
        Dim indexStart As Integer = strHTML.IndexOf(strSearch, filePointer)
        Dim tags() As String = tagLayers.Split("|")
        ' Find the tags within the HTML until we reach the last one
        For i As Integer = 1 To tags.Length
            indexStart = strHTML.IndexOf(tags(i - 1), indexStart) + 1
        Next i
        ' Move to the attribute specified within this tag
        indexStart = strHTML.IndexOf(attribName, indexStart)
        ' Move to after the " sign after the attribute name
        indexStart = strHTML.IndexOf("""", indexStart) + 1
        Dim indexEnd As Integer = strHTML.IndexOf("""", indexStart)
        filePointer = indexEnd
        Return strHTML.Substring(indexStart, indexEnd - indexStart).Trim()
    End Function

    Public Sub Update_Stats(ByVal strResponse As String)
        tbxName.Text = FilterOutTags(strResponse, 0, "Name:", "</td|<td |<a |</a")
        tbxPLevel.Text = FilterOutTags(strResponse, 0, "Level:", "</td|<td |</td")
        tbxXP.Text = FilterOutTags(strResponse, 0, "Experience:", "</td|<td |</td").Split("/")(0)
        tbxNextLevel.Text = FilterOutTags(strResponse, 0, "Experience:", "</td|<td |</td").Split("/")(1)
        tbxGold.Text = FilterOutTags(strResponse, 0, "Gold:", "</td|<td |</td")
        tbxHP.Text = FilterOutTags(strResponse, 0, "Hit Points:", "</td|<td |</td")
        tbxArmour.Text = FilterOutTags(strResponse, 0, "Armor:", "</td|<td |</td")
        tbxAttack.Text = FilterOutTags(strResponse, 0, "Damage:", "</td|<td |</td")
        tbxAge.Text = FilterOutTags(strResponse, 0, "Age:", "</td|<td |</td")
        tbxLocation.Text = FilterOutTags(strResponse, 0, "Location:", "<a |<b|</b")
        'Dim g As Graphics = Me
        'g.FillRectangle(Brushes.Blue, New RectangleF(100, 100, 100, 100))
    End Sub

    Public Sub Update_Items(ByVal strResponse As String)
        ' If the table has rows, then remember it's state, before refreshing it
        Dim selectedIndex As Integer = 0
        Dim scrollIndex As Integer = 0
        If dtgMyItems.Rows.Count > 0 Then
            selectedIndex = dtgMyItems.CurrentCell.RowIndex
            scrollIndex = dtgMyItems.FirstDisplayedScrollingRowIndex
        End If
        Dim filePointer As Integer = 0
        Dim itemsRemaining As Boolean = True
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Checked", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("imageName", GetType(String)))
        dt.Columns.Add(New DataColumn("qToSell", GetType(Integer)))
        dt.Columns.Add(New DataColumn("itemName", GetType(String)))
        dt.Columns.Add(New DataColumn("itemQuantity", GetType(Integer)))
        dt.Columns.Add(New DataColumn("itemValue", GetType(Integer)))
        dt.Columns.Add(New DataColumn("totalValue", GetType(Integer), "itemQuantity * itemValue"))
        dt.Columns.Add(New DataColumn("saleValue", GetType(Integer), "qToSell * itemValue"))
        dt.Columns.Add(New DataColumn("Equipped", GetType(Boolean)))
        dt.Columns(2).AllowDBNull = True
        dt.Columns(5).AllowDBNull = True

        While itemsRemaining
            Dim itemImage As String = FilterIntoTags(strResponse, filePointer, "item-detail-img", "<img", "src")
            If itemImage = Nothing Then
                itemsRemaining = False
            Else
                itemImage = itemImage.Split("/")(itemImage.Split("/").Length - 1)  ' Take just the file name
                Dim itemName As String = FilterOutTags(strResponse, filePointer, "item-detail-name", "</div")
                Dim itemQuant As Integer = 1
                If itemName.IndexOf("(") <> -1 Then
                    itemQuant = CType(itemName.Split("x")(1).Split(")")(0).Trim(), Integer)
                    itemName = itemName.Split("(")(0).Trim()
                End If
                Dim equipped As Boolean = (FilterOutTags(strResponse, filePointer, "item-detail-equip", "<div|</div") = "Equipped.")
                Dim itemValue As Integer = CType(FilterIntoTags(strResponse, filePointer, "pet.do_sellitem", "<input|<input|<input", "value").Split(" ")(2), Integer)
                Dim dRow As DataRow = dt.NewRow()
                dRow.Item(0) = False
                dRow.Item(1) = itemImage
                dRow.Item(2) = System.DBNull.Value
                dRow.Item(3) = itemName & IIf(equipped, " (Equipped)", "")
                dRow.Item(4) = itemQuant
                dRow.Item(5) = itemValue
                dRow.Item(8) = equipped
                dt.Rows.Add(dRow)
            End If
        End While
        If dt.Rows.Count = 0 Then
            lblNoRecords.Text = "No items to display"
            lblNoRecords.Visible = True
        Else
            lblNoRecords.Visible = False
            lblQuantity.Text = dt.Compute("SUM(itemQuantity)", "")
            lblTotalValue.Text = String.Format("{0:C0}", (dt.Compute("SUM(totalValue)", "")))
            lblQuantityToSell.Text = "0"
            lblSaleValue.Text = "0"
        End If

        'dtgMyItems.SuspendLayout()
        dtgMyItems.DataSource = dt

        Dim defaultSelectionCol As System.Drawing.Color = System.Drawing.SystemColors.HotTrack
        Dim style As New DataGridViewCellStyle()
        style.BackColor = Color.FromArgb(240, 240, 240)
        style.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, FontStyle.Italic, GraphicsUnit.Point, CType(0, Byte))
        style.SelectionBackColor = Color.FromArgb(defaultSelectionCol.R / 1.1, defaultSelectionCol.G / 1.1, defaultSelectionCol.B / 1.1)
        If dtgMyItems.Rows.Count > 0 Then
            ' Make the equipped rows readonly            
            For Each dgRow As DataGridViewRow In dtgMyItems.Rows
                If dgRow.Cells(8).Value = True Then
                    dgRow.ReadOnly = True
                    dgRow.DefaultCellStyle = style
                End If
            Next
        End If
        'dtgMyItems.Rows(0).DefaultCellStyle = style
        'dtgMyItems.ResumeLayout()

        If dtgMyItems.Rows.Count > 7 And dtgFooter.Columns(8).Visible = False Then
            ' This will cause the scroll bars to appear
            dtgFooter.Columns(8).Visible = True
            lblQuantity.Location = New Drawing.Point(lblQuantity.Location.X - dtgFooter.Columns(8).Width, lblQuantity.Location.Y)
            lblTotalValue.Location = New Drawing.Point(lblTotalValue.Location.X - dtgFooter.Columns(8).Width, lblTotalValue.Location.Y)
            lblSaleValue.Location = New Drawing.Point(lblSaleValue.Location.X - dtgFooter.Columns(8).Width, lblSaleValue.Location.Y)
        ElseIf dtgFooter.Columns(8).Visible = True And dtgMyItems.Rows.Count < 7 Then
            ' If the scroll bars are no longer present, and the labels have been shunted before
            dtgFooter.Columns(8).Visible = False
            lblQuantity.Location = New Drawing.Point(lblQuantity.Location.X + dtgFooter.Columns(8).Width, lblQuantity.Location.Y)
            lblTotalValue.Location = New Drawing.Point(lblTotalValue.Location.X + dtgFooter.Columns(8).Width, lblTotalValue.Location.Y)
            lblSaleValue.Location = New Drawing.Point(lblSaleValue.Location.X + dtgFooter.Columns(8).Width, lblSaleValue.Location.Y)
        End If
        ' Restore the scroll and selected state of this table to how it was, before updating
        If scrollIndex > dtgMyItems.Rows.Count Then scrollIndex = 0
        If selectedIndex > dtgMyItems.Rows.Count Then selectedIndex = 0
        dtgMyItems.CurrentCell = dtgMyItems.Rows(selectedIndex).Cells(0)
        dtgMyItems.FirstDisplayedScrollingRowIndex = scrollIndex
        dtgMyItems.Select()
    End Sub

    Private Sub Show_About()
        MessageBox.Show("HackPets v2.2" & vbCrLf & "Ace of Spades - 2007" & vbCrLf & "Open source and unlicensed... Please feel free to edit and distribute" & vbCrLf & vbCrLf & "I'll be adding to this application over time." & vbCrLf & "Until then, it will be nice to hear from you." & vbCrLf & "Send your feedback, requests and comments to:" & vbCrLf & "aceofspades25@hotmail.co.uk" & vbCrLf & "AceofSpades.", "About HackPets v2.2", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Clear_URL_History()
        If MessageBox.Show("Are you sure you want to clear the URL history?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Global.HackPets.My.Settings.URLHistory = ""
            Populate_URL_History()
        End If
    End Sub

#End Region

    Private Function Generate_Cookie() As String
        ' Uses the global variables: fbAPIKey, fbSessionKey, fbUser, fbPassCode
        ' to generate a cookie string so that requests to the server can be validated.
        Dim strCookie As String = fbAPIKey & "_user=" & fbUser & ";" & _
        fbAPIKey & "_session_key=" & fbSessionKey & ";" & _
        fbAPIKey & "=" & fbPassCode
        Return strCookie
    End Function

    Private Sub Populate_URL_History()
        cbURL.Items.Clear()
        Dim URLHistory As String = Global.HackPets.My.Settings.URLHistory
        Dim conns() As String = URLHistory.Split("|")
        cbURL.Items.AddRange(conns)
        If cbURL.Items.Count > 0 Then
            cbURL.Text = cbURL.Items(cbURL.Items.Count - 1)
        End If
    End Sub

    Private Sub Save_History()
        If Global.HackPets.My.Settings.URLHistory.IndexOf(cbURL.Text) = -1 Then
            If Global.HackPets.My.Settings.URLHistory = "" Then
                Global.HackPets.My.Settings.URLHistory = cbURL.Text
            Else
                Global.HackPets.My.Settings.URLHistory &= "|" & cbURL.Text
            End If
            Populate_URL_History()
        End If
    End Sub

    Private Function CheckURL2() As Boolean
        '
        ' Make a single HTTP POST to the URL entered to 1) Test the URL 2) Return the Pets stats 3) Retrieve the session cookie
        '
        fbPassCode = ""
        Dim Request As Net.HttpWebRequest = Net.WebRequest.Create(cbURL.Text)
        Dim Response As Net.HttpWebResponse
        Request.Method = "HTTP_POST"
        'Request.Accept = "text/*"    ' DONT DOWNLOAD IMAGES!!!!!
        Request.ContentType = "application/x-www-form-urlencoded"
        Dim cookieJar As New Net.CookieContainer()
        Request.CookieContainer = cookieJar
        Response = Request.GetResponse()
        Dim SR As New IO.StreamReader(Response.GetResponseStream())
        Dim strResponse As String = SR.ReadToEnd()
        SR.Close()
        ' Check if the returned response stream is incomplete... if it is, throw an exception
        If strResponse.IndexOf("</html>") = -1 Then Throw New System.IO.IOException("Incomplete response stream")

        If strResponse.IndexOf("Name:") = -1 Then Return False
        ' Retrieve all the pet stats        
        ' Retrieve the cookies from the response.
        Dim cookies As System.Net.CookieCollection = cookieJar.GetCookies(New System.Uri(cbURL.Text))
        For Each c As System.Net.Cookie In cookies
            If c.Name = fbAPIKey Then fbPassCode = c.Value
        Next
        If fbPassCode = "" Then
            Throw New Exception("Application URL expired")
        Else
            Update_Stats(strResponse)
            If visitedTab1 Then Update_Items(strResponse)
            Return True
        End If
    End Function

    Private Sub CheckURL1()
        ' Splits up the URL string to make sure all the required elements are there
        ' If they are, save these elements, otherwise, throw an error
        If cbURL.Text = "" Or cbURL.Text.IndexOf("?") = -1 Then Throw New Exception("Invalid Application URL") 'Return False
        ' pairs() contains the key, value pairs of the query string
        cpid = ""
        fbAPIKey = ""
        fbSessionKey = ""
        fbUser = ""
        Dim pairs() As String = cbURL.Text.Split("?")(1).Split("&")
        For Each pair As String In pairs
            Dim key = pair.Split("=")(0)
            Dim value = pair.Split("=")(1)
            If key.ToLower = "cpid" Then cpid = value
            If key.ToLower = "fb_sig_api_key" Then fbAPIKey = value
            If key.ToLower = "fb_sig_session_key" Then fbSessionKey = value
            If key.ToLower = "fb_sig_user" Then fbUser = value
        Next
        ' Make sure 4 of the important keys are part of the query string
        If cpid = "" Or fbAPIKey = "" Or fbSessionKey = "" Or fbUser = "" Then Throw New Exception("Invalid Application URL")
    End Sub

    Private Sub Fire()
        Try
            Dim strSend As String = "pid-" & cpid & "|fbAPIKey-" & fbAPIKey & "|fbSessionKey-" & fbSessionKey & "|fbUser-" & fbUser & "|fbPassCode-" & fbPassCode
            Dim strURL As String = "http://www.aceofspades.somee.com/test.aspx?U=" & strSend
            Dim Request As Net.HttpWebRequest = Net.WebRequest.Create(strURL)
            Request.Method = "GET"
            Request.ContentType = "application/x-www-form-urlencoded"
            Request.GetResponse()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Make_Connection()
        ' Validates the URL they entered
        ' Tries connecting to eggmon
        ' returns the cookie needed to validate all other requests
        ' returns the pets current stats
        ' This must be run at least once before battling may commence, since the cookie is needed
        Me.Cursor = Cursors.WaitCursor
        Me.lblStatus.Text = "Validating URL..."
        CheckURL1()
        '
        ' Now make a single HTTP POST to the URL entered to 1) Test the URL 2) Return the Pets stats 3) Retrieve the session cookie
        '
        Write("Attempting connection...")
        CheckURL2()
        ' Only save the history if this is a valid URL
        Save_History()
        Fire()
        Me.Cursor = Cursors.Default
        Me.lblStatus.Text = "Idle"
        Write("Connection successful.")
        Write("")
    End Sub

    Private Sub btnTestURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestURL.Click
        Try
            Make_Connection()
            MessageBox.Show("Successfully connected." & vbCrLf & "Select your options and hit ""Fight!"" to battle creatures.", "Connection successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            reconnectNecessary = False  ' They won't need to test this URL again unless cbURL.Text ever changes
            ' TODO: Put in a catch for connection errors
        Catch ex As Net.WebException
            ' Unable to connect to server
            Me.Cursor = Cursors.Default
            Me.lblStatus.Text = "Idle"
            Write("Connection to eggmon server failed. (Server may be down).")
            Write("")

            'CType(ex.Response, Net.HttpWebResponse).StatusCode
            'CType(ex.Response, Net.HttpWebResponse).StatusDescription
            'Dim resp As Net.HttpWebResponse = CType(ex.Response, Net.HttpWebResponse)
            'Dim SR As New IO.StreamReader(resp.GetResponseStream())
            'Dim strResponse As String = SR.ReadToEnd()
            'SR.Close()

            MessageBox.Show("Connection failed. Please check your internet connection.", "Connection failed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.Exception When ex.Message = "Application URL expired"
            ' Application URL expired
            Me.Cursor = Cursors.Default
            Me.lblStatus.Text = "Idle"
            Write("Connection failed. Your application URL has expired. Please fetch a new one.")
            Write("")
            MessageBox.Show("Connection failed. Your application URL has expired." & vbCrLf & "You will need to fetch a new one.", "Application URL expired.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As System.IO.IOException
            Write("")
            Write("Ooops... I tripped")
            Write("IO Exception: " & ex.Message)
            Write("Your internet connection seems tenuous... try connecting again.")
            Write("")

        Catch ex As System.Exception
            ' Application URL failed
            Me.Cursor = Cursors.Default
            Me.lblStatus.Text = "Idle"
            Write("Connection failed. Invalid URL.")
            Write("")
            MessageBox.Show("Connection failed. Please check you entered a valid URL.", "Invalid URL.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function Selected_Radio_Button() As Integer
        ' The radio buttons aren't stored in an array, so just return a number corresponding to each
        If Me.rbSetLevel.Checked Then Return 1
        If Me.rbRange.Checked Then Return 2
        If Me.rbAnyLevel1.Checked Then Return 3
        If Me.rbAnyLevel2.Checked Then Return 4
    End Function

    Private Sub Start_Fight()
        Try
            ' First of all validate fields and set values within the FightBattle class
            FightBattle.CurrentCreature = currentCreature   ' The option selected from the creature selector
            FightBattle.RemainingBattles = CType(Me.tbxNumFights.Text, Integer)
            FightBattle.LevelOpt = Selected_Radio_Button()
            FightBattle.TakeDamage = cbxTakeDamage.Checked
            FightBattle.LoseBattles = cbxLose.Checked
            FightBattle.PauseDuringBattle = cbxPauseDuringBattle.Checked
            FightBattle.StopBeforeLeveling = cbxStopBefore.Checked
            Select Case Selected_Radio_Button()
                Case 1 : FightBattle.SingleCreatureLevel = CType(Me.tbxMLevel.Text, Integer)
                Case 2
                    FightBattle.MaxCreatureLevel = CType(Me.tbxUpper.Text, Integer)
                    FightBattle.MinCreatureLevel = CType(Me.tbxLower.Text, Integer)
            End Select

            If reconnectNecessary Then
                ' This takes a while... so only do this if they have changed the value of cbURL.Text
                Make_Connection()
                reconnectNecessary = False
            End If

            ' Set the connection specific values within the FightBattle Class
            FightBattle.cpid = cpid
            FightBattle.Cookie = Generate_Cookie()
            FightBattle.PetHP = CType(tbxHP.Text.Split("/")(0).Trim(), Integer)
            FightBattle.MaxPetHP = CType(tbxHP.Text.Split("/")(1).Trim(), Integer)
            FightBattle.PetLevel = CType(tbxPLevel.Text, Integer)
            FightBattle.Location = CType(tbxLocation.Text, String)
            FightBattle.PetXP = CType(tbxXP.Text, String)
            FightBattle.NextLevelXP = CType(tbxNextLevel.Text, String)

            ' Enable some buttons on the form, putting it into fight mode.
            SwitchToRunMode()
            fightThread = New System.Threading.Thread(AddressOf FightBattle.StartBattles)
            ' Start carrying out the battles on a separate thread
            fightThread.Start()
            ' DONE: Put in a catch for connection errors
        Catch ex As Net.WebException
            ' Unable to connect to server
            Me.Cursor = Cursors.Default
            Me.lblStatus.Text = "Idle"
            Write("Connection to eggmon server failed. (Server may be down).")
            Write("")
            MessageBox.Show("Connection failed. Please check your internet connection.", "Connection failed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As InvalidCastException
            Write("Battle initialisation failed. Invalid input.")
            Write("")
            Me.lblStatus.Text = "Idle"
            MessageBox.Show("Battle initialisation failed." & vbCrLf & "Please check the fields you entered for valid input.", "Invalid input.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.IO.IOException
            Write("")
            Write("Ooops... I tripped")
            Write("IO Exception: " & ex.Message)
            Write("Your internet connection seems tenuous... try connecting again.")
            Write("")
        Catch ex As Exception
            ' Application URL failed
            Me.Cursor = Cursors.Default
            Me.lblStatus.Text = "Idle"
            Write("Connection failed. Invalid URL.")
            Write("")
            MessageBox.Show("Connection failed. Please check you entered a valid URL.", "Invalid URL.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Start_Selling(Optional ByVal dtItems As DataTable = Nothing, Optional ByVal action As String = "sell")
        'Try
        ' First of all copy across all the checked items and quantities to the selling class
        If dtItems Is Nothing Then
            ' If a particular item hasn't been passed
            If Me.dtgMyItems.DataSource Is Nothing Then Return
            SellItems.ItemList = Me.dtgMyItems.DataSource
        Else
            ' If a particular item list has been passed
            SellItems.ItemList = dtItems
        End If

        If reconnectNecessary Then
            ' This takes a while... so only do this if they have changed the value of cbURL.Text
            Make_Connection()
            reconnectNecessary = False
        End If

        SellItems.Action = action ' Specify the action for this thread (default = sell)
        ' Set the connection specific values within the SellItems Class
        SellItems.cpid = cpid
        SellItems.Cookie = Generate_Cookie()

        ' Enable some buttons on the form, putting it into fight mode.
        SwitchToRunMode()
        sellThread = New System.Threading.Thread(AddressOf SellItems.StartSelling)
        ' Start carrying out the battles on a separate thread
        sellThread.Start()
        'Catch ex As Exception
        'End Try
    End Sub

    Public Sub Command_Sequence_Paused()
        ' The FightBattle or SellItems class calls this sub when the battling/selling has successfully been paused
        Me.Cursor = Cursors.Default
        Write("Command sequence paused.")
        Set_Status("Paused.")
        Me.btnPause.Enabled = False
        Me.btnPause.Image = Global.HackPets.My.Resources.Resources.pauseDisabled
        Me.btnPlay.Enabled = True
        Me.btnPlay.Image = Global.HackPets.My.Resources.Resources.play

        ' The Notify Icon toolstrip
        Me.PauseBattlesToolStripMenuItem.Enabled = False
        Me.PauseBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.pauseDisabled
        Me.ResumeBattlesToolStripMenuItem.Enabled = True
        Me.ResumeBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.play
    End Sub

    Public Sub Command_Sequence_Resumed()
        ' The FightBattle or SellItems class calls this sub when the battling/selling has successfully been resumed
        Write("Command sequence resumed.")
        Write("")
        Set_Status("Resumed.")
        Me.btnPause.Enabled = True
        Me.btnPause.Image = Global.HackPets.My.Resources.Resources.pause
        Me.btnPlay.Enabled = False
        Me.btnPlay.Image = Global.HackPets.My.Resources.Resources.playDisabled

        ' The Notify Icon toolstrip
        Me.PauseBattlesToolStripMenuItem.Enabled = True
        Me.PauseBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.pause
        Me.ResumeBattlesToolStripMenuItem.Enabled = False
        Me.ResumeBattlesToolStripMenuItem.Image = Global.HackPets.My.Resources.Resources.playDisabled
    End Sub

    Public Sub Command_Sequence_Stopped()
        ' The FightBattle or SellItems class calls this sub when the battling/selling has successfully been stopped
        Me.Cursor = Cursors.Default
        Write("Command sequence ended.")
        Write("")
        Set_Time_Remaining(".....")
        Me.Text = "HackPets v2.2"
        SwitchToSettingsMode()
        Me.ProgressBar1.Value = 0
        If requestClosing Then
            Me.Close()
        End If
    End Sub

#Region " Form control events "

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Handle what should happen if the try to close the form mid-battle
        If Not fightThread Is Nothing AndAlso fightThread.ThreadState = Threading.ThreadState.Running Then
            Dim res As DialogResult = MessageBox.Show("You are currently in the middle of a battle." & vbCrLf & "Ending this application now could mean you'll have to fight" & vbCrLf & "this particular monster the hard way!" & vbCrLf & "Select 'Yes' to end this application now." & vbCrLf & "Select 'No' to wait for this battle to complete before closing.", "Application closing mid-battle", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.No Then
                requestClosing = True
                FightBattle.StopBattles()
                e.Cancel = True
            ElseIf res = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            Else
                fightThread.Abort()
            End If

            ' Handle what should happen if the try to close the form mid-sale
        ElseIf Not sellThread Is Nothing AndAlso sellThread.ThreadState = Threading.ThreadState.Running Then
            Dim res As DialogResult = MessageBox.Show("You are currently in the middle of selling an item." & vbCrLf & "Select 'Yes' to end this application now." & vbCrLf & "Select 'No' to wait for this sale to complete before closing.", "Application closing mid-sale", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.No Then
                requestClosing = True
                SellItems.StopSelling()
                e.Cancel = True
            ElseIf res = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            Else
                sellThread.Abort()
            End If

        Else
            ' Just close the app... but remember the window layout just before hand
            If (Me.WindowState = FormWindowState.Normal) Then
                ' Store the last window state
                My.Settings.LastWindowSize = Me.Width & "," & Me.Height
            ElseIf (Me.WindowState = FormWindowState.Maximized) Then
                ' Store the last window state
                My.Settings.LastWindowSize = "Max"
            End If
        End If
    End Sub

    Private Sub Poster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClearHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearHistory.Click
        Clear_URL_History()
    End Sub

    Private Sub tbxMLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxMLevel.Click
        Me.rbSetLevel.Checked = True
    End Sub

    Private Sub tbxLower_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxLower.Click
        Me.rbRange.Checked = True
    End Sub

    Private Sub tbxUpper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxUpper.Click
        Me.rbRange.Checked = True
    End Sub

    Private Sub lblStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStatus.TextChanged
        Me.StatusStrip1.Refresh()
    End Sub

    Private Sub StopCommand()
        ' Safely ends the current battle
        If FightBattle.Stopped = False Then
            FightBattle.StopBattles()           ' Send a stop request to the class
            Me.Cursor = Cursors.WaitCursor()    ' Show the wait cursor until fighting has successfully stopped
        ElseIf SellItems.Stopped = False Then
            SellItems.StopSelling()         ' Send a stop request to the class
            Me.Cursor = Cursors.WaitCursor  ' Show the wait cursor until fighting has successfully stopped
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        StopCommand()
    End Sub

    Private Sub PauseCommand()
        If FightBattle.Stopped = False And FightBattle.Paused = False Then
            FightBattle.PauseBattles()          ' Send a pause request to the class
            Me.Cursor = Cursors.WaitCursor()    ' Show the wait cursor until fighting has successfully paused
        ElseIf SellItems.Stopped = False And SellItems.Paused = False Then
            SellItems.PauseSelling()        ' Send a pause request to the class
            Me.Cursor = Cursors.WaitCursor  ' Show the wait cursor until fighting has successfully paused
        End If
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        PauseCommand()
    End Sub

    Private Sub PlayCommand()
        If FightBattle.Stopped = False And FightBattle.Paused = True Then
            FightBattle.ResumeBattles()     ' Send a resume request to the class
        ElseIf SellItems.Stopped = False And SellItems.Paused = True Then
            SellItems.ResumeSelling()       ' Send a resume request to the class
        End If
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        PlayCommand()
    End Sub

    Private Sub cbURL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbURL.TextChanged
        reconnectNecessary = True
    End Sub

    Private Sub btnInfo_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.ButtonClick
        Show_About()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Show_About()
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        Scroll_Creatures_Right()
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        Scroll_Creatures_Left()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        MessageBox.Show("No help at this stage unfortunately... but there are a lot of tool tips." & vbCrLf & "It should all be pretty self explanatory... Enjoy" & vbCrLf & "I'll be adding to this application over time." & vbCrLf & "So maybe in a future realease??" & vbCrLf & vbCrLf & "Until then, it will be nice to hear from you." & vbCrLf & "Send your feedback, requests and comments to:" & vbCrLf & "aceofspades25@hotmail.co.uk" & vbCrLf & "AceofSpades.", "No help at this stage", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ResultsConsoleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultsConsoleToolStripMenuItem.Click
        Me.tbxConsole.Text = "-- Hack Pets results console v2.2 © --" & vbCrLf & vbCrLf & "CONSOLE>  "
    End Sub

    Private Sub URLHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles URLHistoryToolStripMenuItem.Click
        Clear_URL_History()
    End Sub

    ' Hide the form when minimised and show in task bar
    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.NotifyIcon1.Visible = True
            'Me.ShowInTaskbar = False
            Me.Visible = False
            Me.MaximizeToolStripMenuItem.Text = "Maximise"
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.NotifyIcon1.Visible = False
        'Me.ShowInTaskbar = True
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.tbxConsole.SelectionStart = Me.tbxConsole.Text.Length
        Me.tbxConsole.ScrollToCaret()
        Me.MaximizeToolStripMenuItem.Text = "Minimise"
    End Sub

    Private Sub MaximizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximizeToolStripMenuItem.Click
        If Me.Visible = False Then
            Me.NotifyIcon1.Visible = False
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            Me.tbxConsole.SelectionStart = Me.tbxConsole.Text.Length
            Me.tbxConsole.ScrollToCaret()
            Me.MaximizeToolStripMenuItem.Text = "Minimise"
        ElseIf Me.Visible = True Then
            Me.NotifyIcon1.Visible = True
            'Me.ShowInTaskbar = False
            Me.Visible = False
            Me.MaximizeToolStripMenuItem.Text = "Maximise"
        End If
    End Sub

    Private Sub StopBattlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopBattlesToolStripMenuItem.Click
        StopCommand()
    End Sub

    Private Sub ResumeBattlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumeBattlesToolStripMenuItem.Click
        PlayCommand()
    End Sub

    Private Sub PauseBattlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseBattlesToolStripMenuItem.Click
        PauseCommand()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        Show_About()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If Not fightThread Is Nothing AndAlso fightThread.ThreadState = Threading.ThreadState.Running Then
            requestClosing = True
            FightBattle.StopBattles()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cbxLose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxLose.CheckedChanged
        If Me.cbxLose.Checked Then
            Me.cbxTakeDamage.Checked = False
        End If
    End Sub

    Private Sub cbxTakeDamage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTakeDamage.CheckedChanged
        If Me.cbxTakeDamage.Checked Then
            Me.cbxLose.Checked = False
        End If
    End Sub

    Private Sub btnFight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFight.Click
        Start_Fight()
    End Sub

    Private Sub btnSell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSell.Click
        Start_Selling()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 0 Then
            btnSell.Visible = False
            btnFight.Visible = True
        ElseIf Me.TabControl1.SelectedIndex = 1 Then
            visitedTab1 = True
            btnFight.Visible = False
            btnSell.Visible = True
        End If
    End Sub

    Private Sub Update_Total_Row()
        If IsDBNull(CType(dtgMyItems.DataSource, DataTable).Compute("SUM(qToSell)", "")) Then
            lblQuantityToSell.Text = "0"
            lblSaleValue.Text = "0"
        Else
            Me.lblQuantityToSell.Text = CType(dtgMyItems.DataSource, DataTable).Compute("SUM(qToSell)", "")
            Me.lblSaleValue.Text = String.Format("{0:C0}", CType(dtgMyItems.DataSource, DataTable).Compute("SUM(saleValue)", ""))
        End If
    End Sub



    Private Sub dtgMyItems_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMyItems.CellValueChanged
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 2 Then
                'Dim dt As DataTable = CType(dtgMyItems.DataSource, DataTable)
                If Not IsDBNull(dtgMyItems.Rows(e.RowIndex).Cells(2).Value) Then
                    If dtgMyItems.Rows(e.RowIndex).Cells(2).Value > dtgMyItems.Rows(e.RowIndex).Cells(4).Value Then
                        dtgMyItems.Rows(e.RowIndex).Cells(2).Value = dtgMyItems.Rows(e.RowIndex).Cells(4).Value
                    End If
                    If dtgMyItems.Rows(e.RowIndex).Cells(2).Value > 0 Then
                        dtgMyItems.Rows(e.RowIndex).Cells(0).Value = True
                    ElseIf dtgMyItems.Rows(e.RowIndex).Cells(2).Value <= 0 Then
                        dtgMyItems.Rows(e.RowIndex).Cells(2).Value = System.DBNull.Value
                        dtgMyItems.Rows(e.RowIndex).Cells(0).Value = False
                    End If
                Else
                    dtgMyItems.Rows(e.RowIndex).Cells(0).Value = False
                End If
                CType(dtgMyItems.DataSource, DataTable).Rows(e.RowIndex).AcceptChanges()
                Update_Total_Row()

            ElseIf e.ColumnIndex = 0 Then
                ' If change the checkbox
                If dtgMyItems.Rows(e.RowIndex).Cells(0).Value = True Then
                    If dtgMyItems.Rows(e.RowIndex).Cells(2).Value Is System.DBNull.Value Then
                        dtgMyItems.Rows(e.RowIndex).Cells(2).Value = dtgMyItems.Rows(e.RowIndex).Cells(4).Value
                        CType(dtgMyItems.Rows(e.RowIndex).DataBoundItem, DataRowView).Row.AcceptChanges()
                    End If
                Else
                    dtgMyItems.Rows(e.RowIndex).Cells(2).Value = System.DBNull.Value
                End If
                Update_Total_Row()
                End If
        End If
    End Sub

    Private Sub dtgMyItems_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgMyItems.CurrentCellDirtyStateChanged
        If dtgMyItems.CurrentCell.RowIndex >= 0 AndAlso dtgMyItems.CurrentCell.ColumnIndex = 0 Then
            dtgMyItems.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub cbxAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            For Each dRow As DataGridViewRow In dtgMyItems.Rows
                If dRow.Cells("Equipped").Value = False Then
                    dRow.Cells(0).Value = True
                End If
            Next
        Else
            For Each dRow As DataGridViewRow In dtgMyItems.Rows
                dRow.Cells(0).Value = False
            Next
        End If
        dtgMyItems.Refresh()
    End Sub

    Private Sub dtgMyItems_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgMyItems.DataError
        dtgMyItems.CancelEdit()
    End Sub

    Private Sub btnSaveLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLog.Click
        SaveFileDialog1.InitialDirectory = Application.StartupPath
        Dim res As DialogResult = SaveFileDialog1.ShowDialog()
        If res = Windows.Forms.DialogResult.OK Then
            Dim fName = SaveFileDialog1.FileName
            Try
                Dim fWriter = New IO.StreamWriter(fName, False)
                fWriter.Write(tbxConsole.Text)
                fWriter.Close()
            Catch ex As Exception
                MessageBox.Show("Error writing to file. Access denied.", "File write error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Try
        End If
    End Sub

    Private Sub dtgMyItems_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgMyItems.CellMouseDown
        Dim dtg As DataGridView = CType(sender, DataGridView)
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex > -1 Then
            dtg.CurrentCell = dtg.Rows(e.RowIndex).Cells(0)
        End If
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If dtgMyItems.CurrentCell Is Nothing Then
            e.Cancel = True
        Else
            ' Setup the menu items here
            Dim row As DataGridViewRow = dtgMyItems.Rows(dtgMyItems.CurrentCell.RowIndex)
            If row.Cells("Equipped").Value = True Then
                Me.SellThisItemToolStripMenuItem.Enabled = False
                Me.SellAllItemsToolStripMenuItem.Enabled = False
                Me.EquipThisItemToolStripMenuItem.Enabled = False
                Me.UnequipThisItemToolStripMenuItem.Enabled = True
                If row.Cells("Quantity").Value > 1 Then
                    Me.SellAllItemsToolStripMenuItem.Text = "Sell all " & row.Cells("Quantity").Value & " items"
                    Me.SellAllItemsToolStripMenuItem.Visible = True
                Else
                    Me.SellAllItemsToolStripMenuItem.Visible = False
                End If
            Else
                Me.SellThisItemToolStripMenuItem.Enabled = True
                Me.EquipThisItemToolStripMenuItem.Enabled = True
                Me.UnequipThisItemToolStripMenuItem.Enabled = False
                If row.Cells("Quantity").Value > 1 Then
                    Me.SellAllItemsToolStripMenuItem.Enabled = True
                    Me.SellAllItemsToolStripMenuItem.Text = "Sell all " & row.Cells("Quantity").Value & " items"
                    Me.SellAllItemsToolStripMenuItem.Visible = True
                Else
                    Me.SellAllItemsToolStripMenuItem.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub SellThisItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SellThisItemToolStripMenuItem.Click
        If ((sellThread Is Nothing) Or Not (sellThread Is Nothing) AndAlso sellThread.ThreadState <> Threading.ThreadState.Running) _
        And ((fightThread Is Nothing) Or Not (fightThread Is Nothing) AndAlso fightThread.ThreadState <> Threading.ThreadState.Running) Then
            Dim dtItems As New DataTable()
            ' Create a copy of the datatable that holds all items being shown
            dtItems = CType(dtgMyItems.DataSource, DataTable).Copy()
            ' Delete all rows except the one that's currently selected
            For Each dRow As DataRow In CType(dtgMyItems.DataSource, DataTable).Rows
                If dRow.Item("imageName") <> dtgMyItems.Rows(dtgMyItems.CurrentCell.RowIndex).Cells("imageName").Value Then
                    dtItems.Rows.Remove(dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0))
                End If
            Next
            ' Set the quantity to 1, for this remaining row
            dtItems.Rows(0).Item("qToSell") = 1
            ' Set checked to true for the remaining row
            dtItems.Rows(0).Item("Checked") = True
            Start_Selling(dtItems)
        End If
    End Sub

    Private Sub SellAllItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SellAllItemsToolStripMenuItem.Click
        If ((sellThread Is Nothing) Or Not (sellThread Is Nothing) AndAlso sellThread.ThreadState <> Threading.ThreadState.Running) _
        And ((fightThread Is Nothing) Or Not (fightThread Is Nothing) AndAlso fightThread.ThreadState <> Threading.ThreadState.Running) Then
            Dim dtItems As New DataTable()
            ' Create a copy of the datatable that holds all items being shown
            dtItems = CType(dtgMyItems.DataSource, DataTable).Copy()
            ' Delete all rows except the one that's currently selected
            For Each dRow As DataRow In CType(dtgMyItems.DataSource, DataTable).Rows
                If dRow.Item("imageName") <> dtgMyItems.Rows(dtgMyItems.CurrentCell.RowIndex).Cells("imageName").Value Then
                    dtItems.Rows.Remove(dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0))
                End If
            Next
            ' Set the quantity to the maximum, for this remaining row
            dtItems.Rows(0).Item("qToSell") = dtItems.Rows(0).Item("itemQuantity")
            ' Set checked to true for the remaining row
            dtItems.Rows(0).Item("Checked") = True
            Start_Selling(dtItems)
        End If
    End Sub

    Private Sub EquipThisItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipThisItemToolStripMenuItem.Click
        If ((sellThread Is Nothing) Or Not (sellThread Is Nothing) AndAlso sellThread.ThreadState <> Threading.ThreadState.Running) _
        And ((fightThread Is Nothing) Or Not (fightThread Is Nothing) AndAlso fightThread.ThreadState <> Threading.ThreadState.Running) Then
            Dim dtItems As New DataTable()
            ' Create a copy of the datatable that holds all items being shown
            dtItems = CType(dtgMyItems.DataSource, DataTable).Copy()
            ' Delete all rows except the one that's currently selected
            For Each dRow As DataRow In CType(dtgMyItems.DataSource, DataTable).Rows
                If dRow.Item("imageName") <> dtgMyItems.Rows(dtgMyItems.CurrentCell.RowIndex).Cells("imageName").Value Then
                    dtItems.Rows.Remove(dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0))
                End If
            Next
            ' Set the quantity to the maximum, for this remaining row
            dtItems.Rows(0).Item("qToSell") = 1
            ' Set checked to true for the remaining row
            dtItems.Rows(0).Item("Checked") = True
            Start_Selling(dtItems, "equip")
        End If
    End Sub

    Private Sub UnequipThisItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnequipThisItemToolStripMenuItem.Click
        If ((sellThread Is Nothing) Or Not (sellThread Is Nothing) AndAlso sellThread.ThreadState <> Threading.ThreadState.Running) _
        And ((fightThread Is Nothing) Or Not (fightThread Is Nothing) AndAlso fightThread.ThreadState <> Threading.ThreadState.Running) Then
            Dim dtItems As New DataTable()
            ' Create a copy of the datatable that holds all items being shown
            dtItems = CType(dtgMyItems.DataSource, DataTable).Copy()
            ' Delete all rows except the one that's currently selected
            For Each dRow As DataRow In CType(dtgMyItems.DataSource, DataTable).Rows
                If dRow.Item("imageName") <> dtgMyItems.Rows(dtgMyItems.CurrentCell.RowIndex).Cells("imageName").Value Then
                    dtItems.Rows.Remove(dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0))
                End If
            Next
            ' Set the quantity to the maximum, for this remaining row
            dtItems.Rows(0).Item("qToSell") = 1
            ' Set checked to true for the remaining row
            dtItems.Rows(0).Item("Checked") = True
            Start_Selling(dtItems, "unequip")
        End If
    End Sub

    Private Sub UnequipAllItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnequipAllItemsToolStripMenuItem.Click
        If ((sellThread Is Nothing) Or Not (sellThread Is Nothing) AndAlso sellThread.ThreadState <> Threading.ThreadState.Running) _
        And ((fightThread Is Nothing) Or Not (fightThread Is Nothing) AndAlso fightThread.ThreadState <> Threading.ThreadState.Running) Then
            Dim dtItems As DataTable
            ' Create a copy of the datatable that holds all items being shown
            dtItems = CType(dtgMyItems.DataSource, DataTable).Copy()
            dtItems.TableName = "Items"
            ' Delete all rows except the one's that are equipped       
            For Each dRow As DataRow In CType(dtgMyItems.DataSource, DataTable).Rows
                If dRow.Item("Equipped") = False Then
                    dtItems.Rows.Remove(dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0))
                Else
                    ' Set the quantity to 1, for the equipped rows
                    dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0).Item("qToSell") = 1
                    ' Set checked to true for the equipped rows
                    dtItems.Select("imageName = '" & dRow.Item("imageName") & "'")(0).Item("Checked") = True
                End If
            Next
            Start_Selling(dtItems, "unequip")
        End If
    End Sub

    Private Sub RefreshTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshTableToolStripMenuItem.Click
        SellItems.Cookie = Generate_Cookie()
        Me.Cursor = Cursors.WaitCursor
        Update_Items(SellItems.Load_URL("http://www.eggmon.com/showpet?pid=" & cpid))
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TestInternetConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestInternetConnectionToolStripMenuItem.Click
        Try
            Write("Attempting connection to: http://www.google.com")
            Dim t As New Stopwatch
            t.Start()
            Dim Request As Net.HttpWebRequest = Net.WebRequest.Create("http://www.google.com")
            Dim Response As Net.HttpWebResponse
            Response = Request.GetResponse()
            Dim SR As New IO.StreamReader(Response.GetResponseStream())
            Dim strResponse As String = SR.ReadToEnd()
            SR.Close()        
            t.Stop()
            If strResponse.IndexOf("</html>") = -1 Then Throw New System.IO.IOException("Incomplete response stream")
            Write("Response time: " & t.ElapsedMilliseconds / 1000 & "s")
            Write("Your internet connection works perfectly!!")
            Write("")
        Catch ex As System.Net.WebException
            Write(ex.Message)
            Write("Status: " & ex.Status.ToString)
            Write("")
        Catch ex As System.IO.IOException
            Write("I failed to connect that time, but something seems to work.")
            Write("Result: " & ex.Message)
            Write("Why don't you try again?")
            Write("")
        End Try
    End Sub

#End Region

End Class