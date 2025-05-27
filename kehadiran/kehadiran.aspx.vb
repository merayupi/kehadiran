Imports MySql.Data.MySqlClient

Public Class kehadiran
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
            koneksi.Open()
            Dim id As String = Request.QueryString("id")
            Dim query As String = "Select * from agendas where id='" & id & "'"
            Dim cmd As New MySqlCommand(query, koneksi)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim nama_agenda As String = reader("name").ToString()
                HeaderTitle.InnerText = HeaderTitle.InnerText & " " & nama_agenda
            End If
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()

        Dim id As String = Request.QueryString("id")
        Dim query As String = "Insert Into presences (name,agenda_id,created_at) 
                               values('" & TextBox1.Text & "', @id, Now())"
        Dim cmd As New MySqlCommand(query, koneksi)
        cmd.Parameters.AddWithValue("@id", id)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        MsgBox("Data Berhasil di simpan", MsgBoxStyle.Information)
        TextBox1.Text = ""
        koneksi.Close()
    End Sub
End Class