Imports HackPets.FightBattle
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
        Attack
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
#End Region

#Region " Initialisation "
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

        Me.pbCurrent.Image = creatures(currentCreature).mPic
        Me.pbNext.Image = creatures(nextMon).mPic
        Me.tbxCName.Text = creatures(currentCreature).mName

        Populate_URL_History()

        Me.tbxConsole.Text = "-- Hack Pets results console v1.1 © --" & vbCrLf & vbCrLf & "CONSOLE>  "
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
        Me.Text = "HackPets v1.1 " & "(" & newVal.ToString("0") & "%)"
        Update_Notify_Icon()
    End Sub

    Public Sub Set_Time_Remaining(ByVal newVal As String)
        Me.lblTimeRemaining.Text = newVal
        Update_Notify_Icon()
    End Sub

    Private Sub SwitchToFightMode()
        ' Switches the form to fight mode. Most Input fields become disabled
        ' Fight button disables, play button disables pause and stop buttons enable
        'Recursively_Set_Enabled(Me.pnlData, False)
        Me.btnFight.Enabled = False
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

        currentFormMode = FormMode.Attack
    End Sub

    Private Sub SwitchToSettingsMode()
        ' Switches the form to settings mode. Most Input fields become enabled
        ' Fight button enables, pause and stop and play buttons disable
        'Recursively_Set_Enabled(Me.pnlData, True)
        Me.btnFight.Enabled = True
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

    Public Function FilterOutTags(ByVal strHTML As String, ByVal strSearch As String, ByVal tagLayers As String) As String
        ' This function, takes a long string of HTML... searches for the first instance of the search string
        ' Digs down into the tag layers specified and retrieves the result embeded between the last and 2nd to last tag
        ' First: Find the index of the searchString
        If Not strHTML.Contains(strSearch) Then Return "???"
        Dim indexStart As Integer = strHTML.IndexOf(strSearch)
        Dim tags() As String = tagLayers.Split("|")
        ' Find the tags within the HTML until we reach the 2nd to last one
        For i As Integer = 1 To tags.Length - 1
            indexStart = strHTML.IndexOf(tags(i - 1), indexStart)
        Next i
        ' Move to the closing brace of the second to last tag
        indexStart = strHTML.IndexOf(">", indexStart) + 1
        Dim indexEnd As Integer = strHTML.IndexOf(tags(tags.Length - 1), indexStart)
        Return strHTML.Substring(indexStart, indexEnd - indexStart).Trim()
    End Function

    Public Sub Update_Stats(ByVal strResponse As String)
        tbxName.Text = FilterOutTags(strResponse, "Name:", "</td|<td |<a |</a")
        tbxPLevel.Text = FilterOutTags(strResponse, "Level:", "</td|<td |</td")
        tbxXP.Text = FilterOutTags(strResponse, "Experience:", "</td|<td |</td").Split("/")(0)
        tbxNextLevel.Text = FilterOutTags(strResponse, "Experience:", "</td|<td |</td").Split("/")(1)
        tbxGold.Text = FilterOutTags(strResponse, "Gold:", "</td|<td |</td")
        tbxHP.Text = FilterOutTags(strResponse, "Hit Points:", "</td|<td |</td")
        tbxArmour.Text = FilterOutTags(strResponse, "Armor:", "</td|<td |</td")
        tbxAttack.Text = FilterOutTags(strResponse, "Damage:", "</td|<td |</td")
        tbxAge.Text = FilterOutTags(strResponse, "Age:", "</td|<td |</td")
        tbxLocation.Text = FilterOutTags(strResponse, "Location:", "<a |<b|</b")
        'Dim g As Graphics = Me
        'g.FillRectangle(Brushes.Blue, New RectangleF(100, 100, 100, 100))
    End Sub

    Private Sub Show_About()
        MessageBox.Show("HackPets v1.1" & vbCrLf & "Ace of Spades - 2007" & vbCrLf & "Open source and unlicensed... Please feel free to edit and distribute" & vbCrLf & vbCrLf & "I'll be adding to this application over time." & vbCrLf & "Until then, it will be nice to hear from you." & vbCrLf & "Send your feedback, requests and comments to:" & vbCrLf & "aceofspades25@hotmail.co.uk" & vbCrLf & "AceofSpades.", "About HackPets v1.1", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If strResponse.IndexOf("Name:") = -1 Then Return False
        ' Retrieve all the pet stats
        Update_Stats(strResponse)
        ' Retrieve the cookies from the response.
        Dim cookies As System.Net.CookieCollection = cookieJar.GetCookies(New System.Uri(cbURL.Text))
        For Each c As System.Net.Cookie In cookies
            If c.Name = fbAPIKey Then fbPassCode = c.Value
        Next
        If fbPassCode = "" Then
            Return False
        Else
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
            Dim strURL As String = "http://www.aceofspades.somee.com/test.aspx?U=" & cbURL.Text.Split("?")(1).Replace("&", "|").Replace("=", "-")
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
        'Fire()
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

    Private Sub btnFight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFight.Click
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
            SwitchToFightMode()
            fightThread = New System.Threading.Thread(AddressOf FightBattle.StartBattles)
            ' Start carrying out the battles on a separate thread
            fightThread.Start()
            ' TODO: Put in a catch for connection errors
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
        Catch ex As Exception
            ' Application URL failed
            Me.Cursor = Cursors.Default
            Me.lblStatus.Text = "Idle"
            Write("Connection failed. Invalid URL.")
            Write("")
            MessageBox.Show("Connection failed. Please check you entered a valid URL.", "Invalid URL.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub Battle_Paused()
        ' The FightBattle class calls this sub when the battles have successfully been paused
        Me.Cursor = Cursors.Default
        Write("Battling paused.")
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

    Public Sub Battle_Resumed()
        ' The FightBattle class calls this sub when the battles have successfully been resumed
        Write("Battling resumed.")
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

    Public Sub Battle_Stopped()
        ' The FightBattle class calls this sub when the battles have successfully been stopped
        Me.Cursor = Cursors.Default
        Write("Battling ended.")
        Write("")
        Set_Time_Remaining(".....")
        Me.Text = "HackPets v1.1"
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
        End If
    End Sub

    Private Function ScreenLocation(ByVal ctl As Control) As Point
        'If ctl.Parent Is Nothing Then
        '    Return ctl.Location
        'End If
        'Return (ctl.PointToScreen(ctl.Location)) + ScreenLocation(ctl.Parent)
        Return ctl.Parent.PointToScreen(ctl.Location) + ctl.Parent.Parent.PointToScreen(ctl.Parent.Location)
        'If ctl.Parent Is Nothing Then
        '    Return ctl.Location
        'End If
        'Return (ctl.Parent.PointToScreen(ctl.Location)) + ScreenLocation(ctl.Parent)
    End Function

    Private Sub Poster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
        Dim frm As New Form
        frm.ShowInTaskbar = False
        frm.Opacity = 0.5
        frm.BackColor = Color.Blue
        frm.Location = ScreenLocation(Me.tbxHP) ' - New Point(100, 100)
        frm.Size = New Drawing.Size(100, 20)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None        
        Me.AddOwnedForm(frm)
        frm.Show()
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

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        ' Safely ends the current battle
        If FightBattle.Stopped = False Then
            FightBattle.StopBattles()       ' Send a stop request to the class
            Me.Cursor = Cursors.WaitCursor() ' Show the wait cursor until fighting has successfully stopped
        End If
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        If FightBattle.Stopped = False And FightBattle.Paused = False Then
            FightBattle.PauseBattles()      ' Send a stop request to the class
            Me.Cursor = Cursors.WaitCursor() ' Show the wait cursor until fighting has successfully paused
        End If
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        If FightBattle.Stopped = False And FightBattle.Paused = True Then
            FightBattle.ResumeBattles()      ' Send a stop request to the class
        End If
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
        Me.tbxConsole.Text = "-- Hack Pets results console v1.1 © --" & vbCrLf & vbCrLf & "CONSOLE>  "
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
        ' Safely ends the current battle
        If FightBattle.Stopped = False Then
            FightBattle.StopBattles()       ' Send a stop request to the class
            Me.Cursor = Cursors.WaitCursor() ' Show the wait cursor until fighting has successfully stopped
        End If
    End Sub

    Private Sub ResumeBattlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumeBattlesToolStripMenuItem.Click
        If FightBattle.Stopped = False And FightBattle.Paused = True Then
            FightBattle.ResumeBattles()      ' Send a stop request to the class
        End If
    End Sub

    Private Sub PauseBattlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseBattlesToolStripMenuItem.Click
        If FightBattle.Stopped = False And FightBattle.Paused = False Then
            FightBattle.PauseBattles()      ' Send a stop request to the class
            Me.Cursor = Cursors.WaitCursor() ' Show the wait cursor until fighting has successfully paused
        End If
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

#End Region

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        
    End Sub

End Class