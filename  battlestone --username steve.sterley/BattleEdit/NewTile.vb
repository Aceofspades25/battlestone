Public Class NewTile
    Dim dtGroups As DataTable

    Public Property GroupsTable() As DataTable
        Get
            Return dtGroups
        End Get
        Set(ByVal value As DataTable)
            dtGroups = value
            Populate_Groups()
        End Set
    End Property

    Public Property SelectedGroup() As Integer
        Get
            Return ddlGroups.SelectedValue
        End Get
        Set(ByVal value As Integer)
            ddlGroups.SelectedValue = value
        End Set
    End Property

    Public Property SelectedType() As String
        Get
            Return ddlTypes.Text
        End Get
        Set(ByVal value As String)
            ddlTypes.SelectedItem = value
        End Set
    End Property

    Private Sub Populate_Groups()
        ddlGroups.ValueMember = "Group_Id"
        ddlGroups.DisplayMember = "GroupName"
        ddlGroups.DataSource = dtGroups
    End Sub

    Private Sub NewTile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.ddlTypes.SelectedIndex = -1 Then
            Me.ddlTypes.SelectedIndex = 0
        End If
    End Sub

End Class