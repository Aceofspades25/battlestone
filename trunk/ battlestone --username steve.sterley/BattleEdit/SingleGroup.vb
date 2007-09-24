Public Class SingleGroup
    Public Property GroupName() As String
        Get
            Return tbxGroupName.Text
        End Get
        Set(ByVal value As String)
            tbxGroupName.Text = value
        End Set
    End Property

    Public Property GroupID() As Integer
        Get
            Return lblID.Text
        End Get
        Set(ByVal value As Integer)
            lblID.Text = value
        End Set
    End Property

    Private Sub SingleGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnOkay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkay.Click
        If tbxGroupName.Text = "Not specified" Then
            MessageBox.Show("The name of this group is invalid", "Invalid group name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub
End Class