Public Class SellItems
    Private Shared _itemList As New DataTable
    Private Shared _action As String    ' The action the user would like this class to carry out: sell, equip, unequip

    Private Shared _cpid As Integer
    Private Shared _cookie As String

    Private Shared _paused As Boolean = False
    Private Shared _pausing As Boolean = False
    Private Shared _stopped As Boolean = True
    Private Shared _stopRequested As Boolean = False
    Private Shared sellingStarted As DateTime
    Private Shared totalItems As Integer

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

    Public Shared Property ItemList() As DataTable
        Get
            Return _itemList
        End Get
        Set(ByVal value As DataTable)
            If _itemList.Columns.Count = 0 Then
                _itemList.Columns.Add("imageName", GetType(String))
                _itemList.Columns.Add("quantity", GetType(Integer))
                _itemList.Columns.Add("itemName", GetType(String))
                _itemList.Columns.Add("itemValue", GetType(Integer))
            End If
            For Each dRow As DataRow In value.Rows
                If dRow.Item("Checked") = True Then
                    Dim newRow As DataRow = _itemList.NewRow()
                    newRow.Item("imageName") = dRow.Item("imageName")
                    newRow.Item("quantity") = dRow.Item("qToSell")
                    newRow.Item("itemName") = dRow.Item("itemName")
                    newRow.Item("itemValue") = dRow.Item("itemValue")
                    _itemList.Rows.Add(newRow)
                End If
            Next
            If _itemList.Rows.Count > 0 Then
                totalItems = _itemList.Compute("SUM(quantity)", "")
            Else
                totalItems = 0
            End If
        End Set
    End Property

    Public Shared Property Action() As String
        Get
            Return _action
        End Get
        Set(ByVal value As String)
            _action = value
        End Set
    End Property

    Delegate Sub StringFunction(ByVal str As String)
    Delegate Sub DoubleFunction(ByVal val As Double)

    Private Shared Function Extract_Message(ByVal strResponse As String) As String
        ' Extracts and returns messages from HTML pages in the form of
        ' <div class="msg">...Message...</div>
        ' <br />
        Dim startIndex As Integer = strResponse.IndexOf("<div class=""msg"">")
        If startIndex = -1 Then Return ""
        startIndex = strResponse.IndexOf(">", startIndex) + 1
        Dim endIndex = strResponse.IndexOf("</div>", startIndex)
        Return strResponse.Substring(startIndex, endIndex - startIndex).Replace("<b>", "").Replace("</b>", "").Replace("<br />", vbCrLf)
    End Function

    Public Shared Function Load_URL(ByVal strURL As String) As String
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
        ' Check if the returned response stream is incomplete... if it is, throw an exception
        If strResponse.IndexOf("</html>") = -1 Then Throw New System.IO.IOException("Incomplete response stream")
        SR.Close()
        Return strResponse
    End Function

    Private Shared Function FilterIntoTags(ByVal strHTML As String, ByRef filePointer As Integer, ByVal strSearch As String, ByVal tagLayers As String, ByVal attribName As String) As String
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

    Private Shared Function GetItemID(ByVal imageName As String, ByVal lastResponseStream As String) As Integer
        ' The items image name is used to reference the item, since it's unique
        ' Looks through the lastResponseStream for the item corresponding to imageName
        ' returns the corresponding itemID As an integer        
        Dim seekIndex As Integer = lastResponseStream.IndexOf(imageName)
        Dim strItemID As String = FilterIntoTags(lastResponseStream, seekIndex, """pid""", "<input", "value")
        Return CType(strItemID, Integer)
    End Function

    Private Shared Function SellItem(ByVal itemID As Integer) As String
        ' Sells the item (given by itemID), and returns the response stream
        Dim requestURL As String = "http://www.eggmon.com/?cpid=" & _cpid & "&form_action=pet.do_sellitem" & "&pid=" & _cpid & "&iid=" & itemID.ToString()
        Dim strResponse As String = Load_URL(requestURL)
        Return strResponse
    End Function

    Private Shared Function EquipItem(ByVal itemID As Integer) As String
        ' Sells the item (given by itemID), and returns the response stream
        Dim requestURL As String = "http://www.eggmon.com/?cpid=" & _cpid & "&form_action=pet.do_equipitem" & "&pid=" & _cpid & "&iid=" & itemID.ToString()
        Dim strResponse As String = Load_URL(requestURL)
        Return strResponse
    End Function

    Private Shared Function UnequipItem(ByVal itemID As Integer) As String
        ' Sells the item (given by itemID), and returns the response stream
        Dim requestURL As String = "http://www.eggmon.com/?cpid=" & _cpid & "&form_action=pet.do_unequipitem" & "&pid=" & _cpid & "&iid=" & itemID.ToString()
        Dim strResponse As String = Load_URL(requestURL)
        Return strResponse
    End Function

    Private Shared Sub Calculate_Time_Remaining(ByVal remainingSales As Integer)
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        Dim saleCount As Integer = totalItems - remainingSales
        Dim timeSoFar As Integer = Date.Now.Subtract(sellingStarted).TotalSeconds
        Dim secsPerSale As Double = timeSoFar / saleCount
        Dim tRemain As New TimeSpan(0, 0, Math.Truncate(secsPerSale * remainingSales))
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Time_Remaining), New Object() {tRemain.ToString()})
    End Sub

    Private Shared Function Capitalise(ByVal str As String) As String
        ' Returns the string passed, with a capitalised first letter
        Dim chr As Char = Char.ToUpper(str(0), System.Threading.Thread.CurrentThread.CurrentCulture)
        str = str.Remove(0, 1)
        Return str.Insert(0, chr)
    End Function

    Public Shared Sub StartSelling()
        ' The main program loop is contained within this sub        
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        If totalItems = 0 Then
            fUI.Invoke(New MethodInvoker(AddressOf fUI.Command_Sequence_Stopped)) ' If there are no items to sell, don't even start
            Return
        End If
        _stopped = False
        _paused = False
        sellingStarted = Date.Now
        Dim itemsSoFar As Integer = 0
        Dim moneySoFar As Integer = 0
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Initiating " & _action & "ing..."})
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {"Initiating " & _action & "ing..."})
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
        Dim lastResponseStream As String = Load_URL("http://www.eggmon.com/showpet?pid=" & _cpid)
        fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
        Dim feedBack As String = ""
        Dim failedActions As Integer = 0
        While Not _stopped
            If Not _paused Then
                Try
                    ' The current item being sold is always in row 0, as a row gets sold off, it gets deleted
                    itemsSoFar += 1
                    fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {Capitalise(_action) & "ing item " & itemsSoFar & "/" & totalItems})
                    fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {Capitalise(_action) & "ing item " & itemsSoFar & "/" & totalItems})

                    ' Sell an item from row 0 in two phases
                    ' Step1: Get the item ID
                    Dim itemID As Integer = GetItemID(_itemList.Rows(0).Item("imageName"), lastResponseStream)
                    ' Step2: Act on the item with this ID                
                    Select Case _action
                        Case "sell"
                            lastResponseStream = SellItem(itemID)
                            feedBack = " sold for " & String.Format("{0:C0}", _itemList.Rows(0).Item("itemValue"))
                        Case "unequip"
                            lastResponseStream = UnequipItem(itemID)
                            feedBack = " unequiped."
                        Case "equip"
                            lastResponseStream = EquipItem(itemID)
                            If Extract_Message(lastResponseStream) <> "Item equipped." Then
                                feedBack = " could not be equiped. " & Extract_Message(lastResponseStream)
                                failedActions += 1
                            Else
                                feedBack = " equiped."
                            End If
                    End Select

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

                moneySoFar += _itemList.Rows(0).Item("itemValue")

                ' Feedback status to the UI
                Calculate_Time_Remaining(totalItems - itemsSoFar)
                fUI.Invoke(New DoubleFunction(AddressOf fUI.Set_Percent), New Object() {itemsSoFar / totalItems * 100})
                fUI.Invoke(New StringFunction(AddressOf fUI.Set_Status), New Object() {"Idle"})
                fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {_itemList.Rows(0).Item("itemName") & feedBack})
                fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {""})
                ' Decrement the quantity of the item being sold
                _itemList.Rows(0).Item("quantity") -= 1
                ' If the quantity reaches 0, delete the row
                If _itemList.Rows(0).Item("quantity") = 0 Then _itemList.Rows(0).Delete()
            End If
            '
            ' If no rows are remaining, selling is complete (Stop automatically)
            '
            If _itemList.Rows.Count = 0 Then
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
        '
        ' When selling is complete, update the items grid on the UI, send other messages to the UI
        '
        fUI.Invoke(New StringFunction(AddressOf fUI.Update_Items), New Object() {lastResponseStream})
        Select Case _action
            Case "sell"
                feedBack = " items sold successfully. " & String.Format("{0:C0}", moneySoFar) & " earned altogether"
            Case "unequip"
                feedBack = " items unequiped successfully"
            Case "equip"
                feedBack = " items equiped successfully"
        End Select
        fUI.Invoke(New StringFunction(AddressOf fUI.Write), New Object() {itemsSoFar - failedActions & "/" & totalItems & feedBack})
        ' Display a message on the console to show that battle has stopped
        fUI.Invoke(New MethodInvoker(AddressOf fUI.Command_Sequence_Stopped))
    End Sub

    Public Shared Sub PauseSelling()
        ' When this is called, a pause request is made
        _pausing = True
    End Sub

    Public Shared Sub ResumeSelling()
        ' When this is called, battling resumes immediately
        _paused = False
        Dim fUI As frmMain = My.Application.OpenForms("frmMain")
        fUI.Invoke(New MethodInvoker(AddressOf fUI.Command_Sequence_Resumed))
    End Sub

    Public Shared Sub StopSelling()
        ' When this is called, a stop request is made
        _stopRequested = True
    End Sub

End Class
