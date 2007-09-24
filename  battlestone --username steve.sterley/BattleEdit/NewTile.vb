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
            'ddlGroups.SelectedValue = value
        End Set
    End Property

    Private Sub Populate_Groups()
        ddlGroups.ValueMember = "Group_Id"
        ddlGroups.DisplayMember = "GroupName"
        ddlGroups.DataSource = dtGroups
    End Sub

    Private Sub NewTile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ddlTypes.SelectedIndex = 2
    End Sub
End Class