Public Class frmNewVersion

    Public Property FileSize() As String
        Get
            Return lblFileSize.Text
        End Get
        Set(ByVal value As String)
            lblFileSize.Text = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return lblVersion.Text
        End Get
        Set(ByVal value As String)
            lblVersion.Text = value
        End Set
    End Property

    Public Property Updates() As String
        Get
            Return tbxUpdates.Text
        End Get
        Set(ByVal value As String)
            tbxUpdates.Focus()
            tbxUpdates.Text = value
            tbxUpdates.SelectionStart = tbxUpdates.Text.Length()
            tbxUpdates.ScrollToCaret()
            tbxUpdates.Refresh()
        End Set
    End Property

    Private Sub frmNewVersion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Me.DialogResult = Nothing Then
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
    End Sub

    Private Sub frmNewVersion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class