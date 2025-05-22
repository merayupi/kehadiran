Imports MySql.Data.MySqlClient

Public Class main
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()
        Dim query As String = "Select a.id as 'ID',
                                      a.name as 'Nama Acara',
	                                  place as 'Tempat',
	                                  DATE_FORMAT(started_at, '%Y-%m-%d') as Tanggal,
	                                  DATE_FORMAT(started_at,'%H:%i:%s') as 'Jam Mulai',
	                                  count(p.agenda_id) as 'Jumlah Kehadiran'
                               from agendas as a
                               left join presences as p on a.id = p.agenda_id
                               group by p.agenda_id
                               order by a.id asc"

        Dim cmd As New MySqlCommand(query, koneksi)
        Dim adapter As New MySqlDataAdapter(cmd)

        Dim ds As New DataSet()
        adapter.Fill(ds)
        GridView1.Columns.Clear()
        GridView1.AutoGenerateColumns = False

        For Each col As DataColumn In ds.Tables(0).Columns
            If col.ColumnName <> "Action" Then
                Dim boundField As New BoundField()
                boundField.DataField = col.ColumnName
                boundField.HeaderText = col.ColumnName
                GridView1.Columns.Add(boundField)
            End If
        Next

        Dim actionField As New TemplateField()
        actionField.HeaderText = "Action"

        actionField.ItemTemplate = New ActionTemplate()
        GridView1.Columns.Add(actionField)

        GridView1.DataSource = ds
        GridView1.DataBind()

        koneksi.Close()

    End Sub
    Public Class ActionTemplate
        Implements ITemplate
        Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
            Dim detailBtn As New Button()
            detailBtn.ID = "btnDetail"
            detailBtn.Text = "Detail"
            detailBtn.CommandName = "Detail"
            AddHandler detailBtn.Click, AddressOf OnDetailClick
            container.Controls.Add(detailBtn)

            Dim space As New LiteralControl(" ")
            container.Controls.Add(space)

            Dim presensiBtn As New Button()
            presensiBtn.ID = "btnPresensi"
            presensiBtn.Text = "Presensi"
            presensiBtn.CommandName = "Presensi"
            AddHandler presensiBtn.Click, AddressOf OnPresensiClick
            container.Controls.Add(presensiBtn)

            container.Controls.Add(space)

            Dim updateBtn As New Button()
            updateBtn.ID = "btnUpdate"
            updateBtn.Text = "Update"
            updateBtn.CommandName = "Update"
            AddHandler updateBtn.Click, AddressOf onUpdateClick
            container.Controls.Add(updateBtn)

            container.Controls.Add(space)

            Dim deleteBtn As New Button()
            deleteBtn.ID = "btnDelete"
            deleteBtn.Text = "Delete"
            deleteBtn.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this item?');")
            AddHandler deleteBtn.Click, AddressOf OnDeleteClick
            container.Controls.Add(deleteBtn)
        End Sub

        Private Sub OnDetailClick(sender As Object, e As EventArgs)
            Dim btn As Button = CType(sender, Button)
            Dim ID As String = btn.CommandArgument
            HttpContext.Current.Response.Redirect("detailkehadiran.aspx?id=" & ID)
        End Sub

        Private Sub OnPresensiClick(sender As Object, e As EventArgs)
            Dim btn As Button = CType(sender, Button)
            Dim ID As String = btn.CommandArgument
            HttpContext.Current.Response.Redirect("kehadiran.aspx?id=" & ID)
        End Sub

        Private Sub OnDeleteClick(sender As Object, e As EventArgs)
            Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
            koneksi.Open()
            Dim btn As Button = CType(sender, Button)
            Dim ID As String = btn.CommandArgument
            Dim query As String = "DELETE FROM agendas WHERE id=@id"
            Dim cmd As New MySqlCommand(query, koneksi)
            cmd.Parameters.AddWithValue("@id", ID)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            MsgBox("Data Berhasil di hapus", MsgBoxStyle.Information)
            koneksi.Close()
        End Sub

        Private Sub OnUpdateClick(sender As Object, e As EventArgs)
            Dim btn As Button = CType(sender, Button)
            Dim ID As String = btn.CommandArgument
            HttpContext.Current.Response.Redirect("agenda.aspx?method=update&id=" & ID)
        End Sub
    End Class

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataItem As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim id As String = dataItem("ID").ToString()

            Dim detailBtn As Button = CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btnDetail"), Button)
            If detailBtn IsNot Nothing Then
                detailBtn.CommandArgument = id
            End If

            Dim presensiBtn As Button = CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btnPresensi"), Button)
            If presensiBtn IsNot Nothing Then
                presensiBtn.CommandArgument = id
            End If

            Dim deleteBtn As Button = CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btnDelete"), Button)
            If deleteBtn IsNot Nothing Then
                deleteBtn.CommandArgument = id
            End If

            Dim updateBtn As Button = CType(e.Row.Cells(e.Row.Cells.Count - 1).FindControl("btnUpdate"), Button)
            If updateBtn IsNot Nothing Then
                updateBtn.CommandArgument = id
            End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HttpContext.Current.Response.Redirect("agenda.aspx")
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HttpContext.Current.Response.Redirect("main.aspx")
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class