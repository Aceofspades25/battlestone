'Imports Poster

Public Class FightBattle
    ' This class initiates and fights a battle on a separate thread so that the UI remains responsive
    Private Shared _creature As Integer
    Private Shared _numBattles As Integer
    Private Shared _levelOpt As Integer
    Private Shared _clevel As Integer
    Private Shared _cLevelMin As Integer
    Private Shared _cLevelMax As Integer
    Private Shared _takeDamage As Boolean
    Private Shared _loseBattles As Boolean
    Private Shared _pauseDuringBattle As Boolean
    Private Shared _stopBeforeLeveling As Boolean

    Private Shared _cpid As Integer
    Private Shared _cookie As String
    ' These values below must be updated after every battle
    Private Shared _petHP As Integer
    Private Shared _maxPetHP As Integer
    Private Shared _petLevel As Integer
    Private Shared _location As String
    Private Shared _petXP As Integer
    Private Shared _nextLevelXP As Integer
    '*******************************************************

    Private Shared _paused As Boolean = False
    Private Shared _pausing As Boolean = False
    Private Shared _stopped As Boolean = True
    Private Shared _stopRequested As Boolean = False
    Private Shared battleStarted As DateTime

    Private Shared fightingCreature As Integer  ' Stores the Creature ID of the last creature challenged
    Private Shared fightingLevel As Integer     ' Stores the Level of the last creature challenged
    Private Shared battlesRemaining As Integer  ' Stores the number of battles remaining

    ' TODO: Set Properties for all the things that shouldn't change while battling
    Public Shared Property CurrentCreature() As Integer
        Get
            Return _creature
        End Get
        Set(ByVal value As Integer)
            _creature = value
        End Set
    End Property

    Public Shared ReadOnly Property Paused() As Boolean
        Get
            Return _paused
        End Get
    End Property

    Public Shared ReadOnly Property Stopped() As Boolean
        Get
            Return _stopped
        End Get
    End Property

    Public Shared Property cpid() As Integer
        Get
            Return _cpid
        End Get
        Set(ByVal value As Integer)
            _cpid = value
        End Set
    End Property

    Public Shared Property Cookie()
        Get
            Return _cookie
        End Get
        Set(ByVal value)
            _cookie = value
        End Set
    End Property

    Public Shared Property RemainingBattles() As Integer
        Get
            Return _numBattles
        End Get
        Set(ByVal value As Integer)
            Validate_Int(value, 1)
            _numBattles = value
        End Set
    End Property

    Public Shared Property LevelOpt() As Integer
        Get
            Return _levelOpt
        End Get
        Set(ByVal value As Integer)
            _levelOpt = value
        End Set
    End Property

    Public Shared Property TakeDamage() As Boolean
        Get
            Return _takeDamage
        End Get
        Set(ByVal value As Boolean)
            _takeDamage = value
        End Set
    End Property

    Public Shared Property LoseBattles() As Boolean
        Get
            Return _loseBattles
        End Get
        Set(ByVal value As Boolean)
            _loseBattles = value
        End Set
    End Property

    Public Shared Property PauseDuringBattle() As Boolean
        Get
            Return _pauseDuringBattle
        End Get
        Set(ByVal value As Boolean)
            _pauseDuringBattle = value
        End Set
    End Property

    Public Shared Property StopBeforeLeveling() As Boolean
        Get
            Return _stopBeforeLeveling
        End Get
        Set(ByVal value As Boolean)
            _stopBeforeLeveling = value
        End Set
    End Property

    Public Shared Property PetHP() As Integer
        Get
            Return _petHP
        End Get
        Set(ByVal value As Integer)
            _petHP = value
        End Set
    End Property

    Public Shared Property MaxPetHP() As Integer
        Get
            Return _maxPetHP
        End Get
        Set(ByVal value As Integer)
            _maxPetHP = value
        End Set
    End Property

    Public Shared Property PetLevel() As Integer
        Get
            Return _petLevel
        End Get
        Set(ByVal value As Integer)
            _petLevel = value
        End Set
    End Property

    Public Shared Property Location() As String
        Get
            Return _location
        End Get
        Set(ByVal value As String)
            _location = value
        End Set
    End Property

    Public Shared Property PetXP() As Integer
        Get
            Return _petXP
        End Get
        Set(ByVal value As Integer)
            _petXP = value
        End Set
    End Property

    Public Shared Property NextLevelXP() As Integer
        Get
            Return _nextLevelXP
        End Get
        Set(ByVal value As Integer)
            _nextLevelXP = value
        End Set
    End Property

    Public Shared Property SingleCreatureLevel() As Integer
        Get
            Return _clevel
        End Get
        Set(ByVal value As Integer)
            ' Make sure the value being set is between 0 and 30
            Validate_Int(value, 0, 30)
            _clevel = value
        End Set
    End Property

    Public Shared Property MinCreatureLevel() As Integer
        Get
            Return _cLevelMin
        End Get
        Set(ByVal value As Integer)
            ' Make sure the value being set is between 0 and 30
            Validate_Int(value, 0, 30)
            _cLevelMin = value
            If Not _cLevelMax = Nothing AndAlso _cLevelMax < _cLevelMin Then
                ' If the entered max creature level is less than the min creature level then just swap them
                Swap(_cLevelMin, _cLevelMax)
            End If
        End Set
    End Property

    Public Shared Property MaxCreatureLevel() As Integer
        Get
            Return _cLevelMax
        End Get
        Set(ByVal value As Integer)
            ' Make sure the value being set is between 0 and 30
            Validate_Int(value, 0, 30)
            _cLevelMax = value
            If Not _cLevelMin = Nothing AndAlso _cLevelMin > _cLevelMax Then
                ' If the entered min creature level is greater than the max creature level then just swap them
                Swap(_cLevelMin, _cLevelMax)
            End If
        End Set
    End Property

    Delegate Sub StringFunction(ByVal str As String)
    Delegate Sub DoubleFunction(ByVal val As Double)

    Private Shared Sub Validate_Int(ByVal val As Integer, ByVal lower As Integer, Optional ByVal upper As Integer = -1)
        If (upper = -1) And (val >= lower) Then Return
        If ((val < lower) Or (val > upper)) Then Throw New System.InvalidCastException
    End Sub

    Private Shared Sub Swap(ByRef val1 As Integer, ByRef val2 As Integer)
        Dim hold As Integer = val1
        val1 = val2
        val2 = hold
    End Sub

    Private Shared Function Extract_Message(ByVal strResponse As String) As String
        ' Extracts and returns messages from HTML pages in the form of
        ' <div class="msg">...Message...</div>
        ' <br />
        'strResponse = "<div class=""msg"">...Message...</div"
        Dim startIndex As Integer = strResponse.IndexOf("<div class=""msg"">")
        startIndex = strResponse.IndexOf(">", startIndex) + 1
        Dim endIndex = strResponse.IndexOf("</div>", startIndex)
        Return strResponse.Substring(startIndex, endIndex - startIndex).Replace("<b>", "").Replace("</b>", "").Replace("<br />", vbCrLf)
    End Function

    Private Shared Function Load_URL(ByVal strURL As String) As String
        Dim Request As Net.HttpWebRequest = Net.WebRequest.Create(strURL)
        Dim Response As Net.HttpWebResponse
        Request.Method = "HTTP_POST"
        'Request.Accept = "text/*"    ' DONT DOWNLOAD IMAGES!!!!!
        Request.ContentType = "application/x-www-form-urlencoded"
        ' Add cookies for authentication
        Request.Headers.Add(Net.HttpRequestHeader.Cookie, _cookie)
        Response = Request.GetResponse()
        Dim SR As New IO.StreamReader(Response.GetResponseStream())
        Dim strResponse As String = SR.ReadToEnd()
        SR.Close()
        ' Check if the returned response stream is incomplete... if it is, throw an exception
        If strResponse.IndexOf("</html>") = -1 Then Throw New System.IO.IOException("Incomplete response stream")
        Return strResponse
    End Function

    Private Shared Function Pick_Creature() As Integer
        Dim r As New Random(System.DateTime.Now.Millisecond)
        If _creature = 0 Then
            ' Random creature (3-9)
            Return r.Next(3, 10)
        End If
        If _creature = 1 Then
            ' Random creature from Greenwhich forest (3-6)
            Return r.Next(3, 7)
        End If
        If _creature = 2 Then
            ' Random creature from Black cove (7-9)
            Return r.Next(7, 10)
        End If
        ' Else just return the selected creature
        Return _creature
    End Function

    Private Shared Function Pick_Level() As Integer
        Dim r As New Random(System.DateTime.Now.Millisecond)
        If _levelOpt = 1 Then
            ' Set level
            Return _clevel
        End If
        If _levelOpt = 2 Then
            ' Set range
            Return r.Next(_cLevelMin, _cLevelMax + 1)
        End If
        If _levelOpt = 3 Then
            ' Any level available to me
            If _petLevel - 4 < 0 Then
                Return r.Next(0, _petLevel + 3)
            Else
                Return r.Next(_petLevel - 4, _petLevel + 3)
            End If

        End If
        If _levelOpt = 4 Then
            ' Any level I could win at
            If _petLevel - 4 < 0 Then
                Return r.Next(0, _petLevel)
            Else
                Return r.Next(_petLevel - 4, _petLevel)
            End If
        End If
    End Function

    Private Shared Sub Change_Location(ByVal loc As String)
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        If loc = "Greenwich Forest" Then
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Changing location to Greenwhich Forest"})
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
            fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Changing location..."})
            Dim strResponse As String = Load_URL("http://www.eggmon.com/askfight?loc=3&fb_sig=&cpid=" & _cpid)
            fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
        End If
        If loc = "The Black Cove" Then
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Changing location to The Black Cove"})
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
            fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Changing location..."})
            Dim strResponse As String = Load_URL("http://www.eggmon.com/askfight?loc=4&fb_sig=&cpid=" & _cpid)
            fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
        End If
    End Sub

    Private Shared Function Challenge_Monster(ByVal bRemaining As Integer) As Integer
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        ' DONE: Decide on which creature and level to fight
        fightingCreature = Pick_Creature()
        fightingLevel = Pick_Level()

        ' DONE: check if I need to change to a different area
        If fUI.creatures(fightingCreature).location <> _location Then
            Change_Location(fUI.creatures(fightingCreature).location)
        End If
        Dim cName As String = fUI.creatures(fightingCreature).mName
        Dim mcID As String = fUI.creatures(fightingCreature).mcID

        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Challenging monster. (" & cName & " - Level: " & fightingLevel & ")"})
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Initiating challenge... (" & _numBattles - bRemaining + 1 & "/" & _numBattles & ")"})

        Dim strResponse As String = Load_URL("http://www.eggmon.com/askfight?cpid=" & _cpid & "&form_action=pet.do_fight&level=" & fightingLevel & "&mcid=" & mcID & "&type=fightmonster")
        ' Extract the battle ID from the HTML response string
        Dim startIndex As Integer = strResponse.IndexOf("'id'")
        startIndex = strResponse.IndexOf(":", startIndex) + 1
        Dim endIndex = strResponse.IndexOf(",", startIndex)
        Dim battleID As Integer = CType(strResponse.Substring(startIndex, endIndex - startIndex).Trim(), Integer)
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Challenge successful."})
        fUI.Invoke(New DoubleFunction(AddressOf fUI.Set_Percent), New Object() {((_numBattles - bRemaining) * 2 + 1) / (_numBattles * 2) * 100})
        Return battleID
    End Function

    Private Shared Function Calculate_Damage(ByVal petHP As Integer, ByVal mLevel As Integer, ByVal mNo As Integer) As Integer
        ' This function makes up a value for how many HP should be lost in a particular battle.
        ' It works on the assumption that fighting a class 10 creature one level below you, you'll loose all HP
        ' Fighting a class 5 creature one level below you, you'll loose 1/2 your HP
        ' Fighting a class 1 creature one level below you, you'll loose 1/10 your HP
        ' For each level up, * the number of HP you'd loose by 1.5
        ' If the HP you'd loose drops below petHP, you will be left with a random no. of HP between 0.1% and 1%
        If _loseBattles = True Then
            ' If they have chosen to lose battles, return 0 HP
            Return 0
        End If
        If _takeDamage = False Then
            ' If they have chosen to not take damage during battles
            Return petHP
        End If
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        Dim mClass As Integer = fUI.creatures(mNo).powerRating
        Dim percLoss As Single = mClass * 10
        ' We subtract another 1, the percentage calculated above, applies
        Dim levelDiff As Integer = (mLevel - _petLevel) + 1
        Dim multiplier As Single = Math.Pow(1.5, levelDiff)
        percLoss *= multiplier
        Dim r As New Random(System.DateTime.Now.Millisecond)
        percLoss += r.Next(0, 3)   ' Add a random value to the perc loss
        Dim result As Integer = petHP - ((_maxPetHP * percLoss) / 100)

        If result < 1 Then
            result = Math.Truncate(r.NextDouble() / 100 * _maxPetHP) + 1
        End If

        Return result
    End Function

    Private Shared Function Calculate_Time(ByVal petLevel As Integer, ByVal mLevel As Integer) As Integer
        ' If the user has chosen to pause during battle, use this to calculate how long to wait
        ' If pet and creature are on the same level, wait 12 secs
        ' Wait 1.5 times more or less per degree of level difference
        Dim levelDiff As Integer = (mLevel - petLevel)
        Return 12 * Math.Pow(1.5, levelDiff) * 1000 ' Multiply by 1000 to return the time in msec        
    End Function

    Private Shared Function Defeat_Monster(ByVal battleID As Integer, ByVal bRemaining As Integer) As String
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        'DONE: Calculate how much health should remain
        If _pauseDuringBattle Then
            Dim msec As Integer = Calculate_Time(_petLevel, fightingLevel)
            fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Waiting " & (msec / 1000).ToString("0.0") & " seconds..."})
            Threading.Thread.Sleep(msec)
            fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
        End If
        Dim hpRemain As Integer = Calculate_Damage(_petHP, fightingLevel, fightingCreature)

        Dim cName As String = fUI.creatures(fightingCreature).mName
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Fighting battle... (" & _numBattles - bRemaining + 1 & "/" & _numBattles & ")"})
        Dim strType As String = "lootbody"
        ' If they loose all HP, then set type to died
        If hpRemain = 0 Then strType = "died"
        Dim strResponse As String = Load_URL("http://www.eggmon.com/fightjs?cpid=" & _cpid & "&form_action=pet.do_fight&type=" & strType & "&fid=" & battleID.ToString() & "&last_pet_hp=" & hpRemain.ToString())
        If hpRemain > 0 Then
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {cName & " defeated. " & (_petHP - hpRemain).ToString() & " HP lost."})
        Else
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Your pet was defeated. ¤~¤~DEATH~¤~¤ ."})
        End If
        ' Analyse the response for the message returned
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {Extract_Message(strResponse)})
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
        _petHP = hpRemain
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
        fUI.Invoke(New DoubleFunction(AddressOf fUI.Set_Percent), New Object() {((_numBattles - bRemaining) * 2 + 2) / (_numBattles * 2) * 100})
        Return strResponse
    End Function

    Private Shared Sub Update_Stats(ByVal strResponse As String)
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        _petHP = CType(fUI.FilterOutTags(strResponse, 0, "Hit Points:", "</td|<td |</td").Split("/")(0).Trim(), Integer)
        _maxPetHP = CType(fUI.FilterOutTags(strResponse, 0, "Hit Points:", "</td|<td |</td").Split("/")(1).Trim(), Integer)
        _petLevel = CType(fUI.FilterOutTags(strResponse, 0, "Level:", "</td|<td |</td"), Integer)
        _location = CType(fUI.FilterOutTags(strResponse, 0, "Location:", "<a |<b|</b"), String)
        _petXP = CType(fUI.FilterOutTags(strResponse, 0, "Experience:", "</td|<td |</td").Split("/")(0), Integer)
        _nextLevelXP = CType(fUI.FilterOutTags(strResponse, 0, "Experience:", "</td|<td |</td").Split("/")(1), Integer)
        fUI.Invoke(New StringFunction(AddressOf fUI.Update_Stats), New Object() {strResponse})
    End Sub

    Private Shared Sub Feed_Pet()
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Feeding pet..."})
        Dim strResponse As String = Load_URL("http://www.eggmon.com/showpet?&form_action=pet.do_action&pid=" & _cpid & "&type=feed")
        Update_Stats(strResponse)
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Pet fed... HP Restored"})
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
    End Sub

    Private Shared Sub Calculate_Time_Remaining(ByVal remBattles As Integer)
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        Dim battleCount As Integer = _numBattles - remBattles
        Dim timeSoFar As Integer = Date.Now.Subtract(battleStarted).TotalSeconds
        Dim secsPerBattle As Double = timeSoFar / battleCount
        Dim tRemain As New TimeSpan(0, 0, Math.Truncate(secsPerBattle * remBattles))
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Time_Remaining), New Object() {tRemain.ToString()})
    End Sub

    Private Shared Function About_To_Level() As Boolean
        ' The relationship between maximum exp earned and monster level can be estimated with the following function
        ' XP = (Level^2.6)*2.378 I then double this function and add 10, so that were safe all the time at any level above 3 or so

        Dim maxMonsterLevel As Integer  ' The maximum monster level that can be fought with the current settings
        Select Case _levelOpt
            Case 1 : maxMonsterLevel = _clevel
            Case 2 : maxMonsterLevel = _cLevelMax
            Case 3 : maxMonsterLevel = _petLevel + 2
            Case 4 : maxMonsterLevel = _petLevel
        End Select
        Dim maxMonsterXP As Integer = Math.Pow(maxMonsterLevel, 2.6) * 2.378

        If _petXP + maxMonsterXP * 2 + 10 >= _nextLevelXP Then
            Dim fUI As frmMain = My.Application.OpenForms("frmMain")
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Fighting stopped. You are about to level up..."})
            fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
            Return True
        End If
        Return False
    End Function

    Public Shared Sub StartBattles()
        ' The main program loop is contained within this sub
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        _stopped = False
        _paused = False
        battlesRemaining = _numBattles
        battleStarted = Date.Now
        While Not _stopped
            '
            ' Check if the pet is about to level up
            '
            If _stopBeforeLeveling AndAlso About_To_Level() Then
                ' If the pet is about to level up and they want to stop before this, then stop
                _stopped = True
                _stopRequested = False
                _paused = True
            End If
            If Not _paused Then
                ' Don't carry out the next battle if paused                
                Try
                    '
                    ' If HP is less than 2/3... feed pet here (don't feed pet if were losing battles)
                    '
                    If _petHP < (_maxPetHP * 2 / 3) AndAlso LoseBattles = False Then
                        Feed_Pet()
                    End If
                    '
                    ' Carry out each battle in 3 phases (phase1: challenge, phase2: win, phase3: update stats)
                    '
                    Dim battleID As Integer = Challenge_Monster(battlesRemaining)
                    Dim strResponse As String = Defeat_Monster(battleID, battlesRemaining)
                    ' Update internal stats and the stats panel
                    Update_Stats(strResponse)
                    ' Decrement the number of battles that need to be fought
                    battlesRemaining -= 1
                    Calculate_Time_Remaining(battlesRemaining)
                Catch ex As System.Net.WebException
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Connection failed..."})
                    Threading.Thread.Sleep(5000)    ' Wait 5 seconds, then try again.
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Attempting reconnection...."})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                Catch ex As System.TimeoutException
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Connection timed out after 100s."})
                    Threading.Thread.Sleep(5000)    ' Wait 5 seconds, then try again.
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Attempting reconnection...."})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                Catch ex As System.IO.IOException
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Ooops... I tripped"})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"IO Exception: " & ex.Message})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Will try to keep going..."})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                End Try
            End If
            '
            ' If all the fights have taken place, then stop automatically
            '
            If battlesRemaining = 0 Then
                _stopped = True
                _stopRequested = False
            End If
            '
            ' If the user has requested a pause, then pause here at a safe place
            '
            If _pausing Then
                _paused = True
                _pausing = False
                ' Display a message on the console to show that battle has been paused
                fUI.Invoke(New MethodInvoker(AddressOf fUI.Command_Sequence_Paused))
            End If
            '
            ' If the user has requested a stop, then stop here at a safe place
            '
            If _stopRequested Then
                _stopped = True
                _stopRequested = False
                _paused = False
                _pausing = False
            End If
        End While
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {(_numBattles - battlesRemaining).ToString & "/" & _numBattles.ToString() & " Battles completed successfully."})
        ' Display a message on the console to show that battle has stopped
        fUI.Invoke(New MethodInvoker(AddressOf fUI.Command_Sequence_Stopped))
    End Sub

    Public Shared Sub PauseBattles()
        ' When this is called, a pause request is made
        _pausing = True
    End Sub

    Public Shared Sub ResumeBattles()
        ' When this is called, battling resumes immediately
        _paused = False
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        fUI.Invoke(New MethodInvoker(AddressOf fUI.Command_Sequence_Resumed))
    End Sub

    Public Shared Sub StopBattles()
        ' When this is called, a stop request is made
        _stopRequested = True
    End Sub
End Class
