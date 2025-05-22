Imports MySql.Data.MySqlClient
Public Class detailkehadiran
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()
        Dim id As String = Request.QueryString("id")
        Dim query As String = "Select name as 'Nama Peserta',
                                      DATE_FORMAT(created_at,'%H:%i:%s') as 'Jam Hadir'
                              From presences
                              Where agenda_id = @id"
        Dim cmd As New MySqlCommand(query, koneksi)
        cmd.Parameters.AddWithValue("@id", id)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        GridView1.Columns.Clear()
        GridView1.DataSource = ds
        GridView1.DataBind()

        Dim query2 As String = "Select name from agendas where id=@id"
        Dim cmd2 As New MySqlCommand(query2, koneksi)
        cmd2.Parameters.AddWithValue("@id", id)
        Dim reader As MySqlDataReader = cmd2.ExecuteReader()
        If reader.Read() Then
            Label1.Text = "List Kehadiran Acara " + reader("name").ToString()
        End If
        koneksi.Close()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HttpContext.Current.Response.Redirect("agenda.aspx")
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HttpContext.Current.Response.Redirect("main.aspx")
    End Sub
End Class