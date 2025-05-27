Imports MySql.Data.MySqlClient

Public Class main
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGridView()
        BindCardView()
    End Sub
    Public Class ActionTemplate
        Implements ITemplate

        Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
            ' Detail Button
            Dim detailBtn As New LinkButton()
            detailBtn.ID = "btnDetail"
            detailBtn.CssClass = "action-btn detail"
            detailBtn.Text = "<i class='fas fa-info-circle'></i>"
            detailBtn.CommandName = "Detail"
            detailBtn.EnableViewState = False
            detailBtn.CausesValidation = False
            detailBtn.ToolTip = "Lihat Detail"
            detailBtn.Attributes.Add("runat", "server")
            detailBtn.Attributes.Add("style", "text-decoration:none;")
            AddHandler detailBtn.Click, AddressOf OnDetailClick
            container.Controls.Add(detailBtn)

            ' Presensi Button
            Dim presensiBtn As New LinkButton()
            presensiBtn.ID = "btnPresensi"
            presensiBtn.CssClass = "action-btn presensi"
            presensiBtn.Text = "<i class='fas fa-user-check'></i>"
            presensiBtn.CommandName = "Presensi"
            presensiBtn.EnableViewState = False
            presensiBtn.CausesValidation = False
            presensiBtn.ToolTip = "Presensi"
            presensiBtn.Attributes.Add("runat", "server")
            presensiBtn.Attributes.Add("style", "text-decoration:none;")
            AddHandler presensiBtn.Click, AddressOf OnPresensiClick
            container.Controls.Add(presensiBtn)

            ' Update Button
            Dim updateBtn As New LinkButton()
            updateBtn.ID = "btnUpdate"
            updateBtn.CssClass = "action-btn update"
            updateBtn.Text = "<i class='fas fa-edit'></i>"
            updateBtn.CommandName = "Update"
            updateBtn.EnableViewState = False
            updateBtn.CausesValidation = False
            updateBtn.ToolTip = "Update"
            updateBtn.Attributes.Add("runat", "server")
            updateBtn.Attributes.Add("style", "text-decoration:none;")
            AddHandler updateBtn.Click, AddressOf OnUpdateClick
            container.Controls.Add(updateBtn)

            ' Delete Button
            Dim deleteBtn As New LinkButton()
            deleteBtn.ID = "btnDelete"
            deleteBtn.CssClass = "action-btn delete"
            deleteBtn.Text = "<i class='fas fa-trash-alt'></i>"
            deleteBtn.CommandName = "Delete"
            deleteBtn.EnableViewState = False
            deleteBtn.CausesValidation = False
            deleteBtn.ToolTip = "Hapus"
            deleteBtn.Attributes.Add("runat", "server")
            deleteBtn.Attributes.Add("style", "text-decoration:none;")
            deleteBtn.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this item?');")
            AddHandler deleteBtn.Click, AddressOf OnDeleteClick
            container.Controls.Add(deleteBtn)
        End Sub

        Private Sub OnDetailClick(sender As Object, e As EventArgs)
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim ID As String = btn.CommandArgument
            HttpContext.Current.Response.Redirect("detailkehadiran.aspx?id=" & ID)
        End Sub

        Private Sub OnPresensiClick(sender As Object, e As EventArgs)
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim ID As String = btn.CommandArgument
            HttpContext.Current.Response.Redirect("kehadiran.aspx?id=" & ID)
        End Sub

        Private Sub OnDeleteClick(sender As Object, e As EventArgs)
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim ID As String = btn.CommandArgument
            Using koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
                koneksi.Open()
                Dim query As String = "DELETE FROM agendas WHERE id=@id"
                Using cmd As New MySqlCommand(query, koneksi)
                    cmd.Parameters.AddWithValue("@id", ID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            HttpContext.Current.Response.Redirect("main.aspx")
        End Sub

        Private Sub OnUpdateClick(sender As Object, e As EventArgs)
            Dim btn As LinkButton = CType(sender, LinkButton)
            Dim ID As String = btn.CommandArgument
            HttpContext.Current.Response.Redirect("agenda.aspx?method=update&id=" & ID)
        End Sub
    End Class
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataItem As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim id As String = dataItem("ID").ToString()

            CType(e.Row.FindControl("btnDetail"), LinkButton).CommandArgument = id
            CType(e.Row.FindControl("btnPresensi"), LinkButton).CommandArgument = id
            CType(e.Row.FindControl("btnUpdate"), LinkButton).CommandArgument = id
            CType(e.Row.FindControl("btnDelete"), LinkButton).CommandArgument = id
        End If
    End Sub

    Private Sub BindCardView()
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()
        Dim query As String = "SELECT 
                                    COUNT(DISTINCT a.id) AS 'Jumlah Agenda',
                                    COUNT(p.agenda_id) AS 'Total Jumlah Kehadiran'
                                FROM 
                                    agendas a
                                LEFT JOIN 
                                    presences p ON a.id = p.agenda_id;"
        Dim cmd As New MySqlCommand(query, koneksi)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        If reader.Read() Then
            Label1.Text = reader("Jumlah Agenda").ToString()
            Label2.Text = reader("Total Jumlah Kehadiran").ToString()
        End If
    End Sub
    Private Sub BindGridView()
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()
        Dim query As String = "SELECT a.id as 'ID',
                                  a.name as 'Nama Acara',
                                  place as 'Tempat',
                                  DATE_FORMAT(started_at, '%Y-%m-%d') as Tanggal,
                                  DATE_FORMAT(started_at,'%H:%i:%s') as 'Jam Mulai',
                                  COUNT(p.agenda_id) as 'Jumlah Kehadiran'
                           FROM agendas AS a
                           LEFT JOIN presences AS p ON a.id = p.agenda_id
                           GROUP BY a.id
                           ORDER BY a.id ASC"
        Dim cmd As New MySqlCommand(query, koneksi)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)

        GridView1.Columns.Clear()
        GridView1.AutoGenerateColumns = False

        For Each col As DataColumn In ds.Tables(0).Columns
            Dim boundField As New BoundField()
            boundField.DataField = col.ColumnName
            boundField.HeaderText = col.ColumnName
            GridView1.Columns.Add(boundField)
        Next

        Dim actionField As New TemplateField()
        actionField.HeaderText = "Action"
        actionField.ItemTemplate = New ActionTemplate()
        GridView1.Columns.Add(actionField)

        GridView1.DataSource = ds
        GridView1.DataBind()

        koneksi.Close()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()

        Dim query As String = "SELECT a.id AS 'ID',
                                 a.name AS 'Nama Acara',
                                 place AS 'Tempat',
                                 DATE_FORMAT(started_at, '%Y-%m-%d') AS Tanggal,
                                 DATE_FORMAT(started_at,'%H:%i:%s') AS 'Jam Mulai',
                                 COUNT(p.agenda_id) AS 'Jumlah Kehadiran'
                          FROM agendas AS a
                          LEFT JOIN presences AS p ON a.id = p.agenda_id
                          WHERE a.name LIKE @searchText
                          AND (@selectedDate IS NULL OR DATE(a.started_at) = @selectedDate)
                          GROUP BY a.id
                          ORDER BY a.id ASC"

        Dim cmd As New MySqlCommand(query, koneksi)
        Dim searchText As String = "%" & TextBox2.Text.Trim() & "%"
        cmd.Parameters.AddWithValue("@searchText", searchText)

        If String.IsNullOrEmpty(TextBox1.Text.Trim()) Then
            cmd.Parameters.AddWithValue("@selectedDate", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@selectedDate", TextBox1.Text.Trim())
        End If

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)

        GridView1.Columns.Clear()
        GridView1.AutoGenerateColumns = False

        For Each col As DataColumn In ds.Tables(0).Columns
            Dim boundField As New BoundField()
            boundField.DataField = col.ColumnName
            boundField.HeaderText = col.ColumnName
            GridView1.Columns.Add(boundField)
        Next

        Dim actionField As New TemplateField()
        actionField.HeaderText = "Action"
        actionField.ItemTemplate = New ActionTemplate()
        GridView1.Columns.Add(actionField)

        GridView1.DataSource = ds
        GridView1.DataBind()

        koneksi.Close()
    End Sub
End Class