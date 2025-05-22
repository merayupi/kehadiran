Imports MySql.Data.MySqlClient

Public Class agenda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim method As String = Request.QueryString("method")
            If method = "update" Then
                Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
                koneksi.Open()
                Dim id As String = Request.QueryString("id")
                Dim query As String = "Select * from agendas where id='" & id & "'"
                Dim cmd As New MySqlCommand(query, koneksi)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim tgl_agenda As DateTime = reader("started_at")
                    Dim tanggal As String = tgl_agenda.ToString("yyyy-MM-dd")
                    Dim jam As String = tgl_agenda.ToString("HH:mm")

                    TextBox1.Text = jam
                    TextBox2.Text = tanggal
                    TextBox3.Text = reader("name").ToString()
                    TextBox4.Text = reader("place").ToString()
                End If

                reader.Close()
                koneksi.Close()
            End If
        End If
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim koneksi As New MySqlConnection("data source=localhost; user=root; pwd=''; initial catalog=db_kehadiran")
        koneksi.Open()

        Dim method As String = Request.QueryString("method")
        Dim tgl_agenda As DateTime = DateTime.Parse(TextBox2.Text & " " & TextBox1.Text)
        If method = "update" Then
            Dim id As String = Request.QueryString("id")
            Debug.Print(TextBox3.Text)
            Dim query As String = "UPDATE agendas 
                           SET name = @name, place = @place, started_at = @tgl_agenda 
                           WHERE id = @id"
            Dim cmd As New MySqlCommand(query, koneksi)
            cmd.Parameters.AddWithValue("@name", TextBox3.Text)
            cmd.Parameters.AddWithValue("@place", TextBox4.Text)
            cmd.Parameters.AddWithValue("@tgl_agenda", tgl_agenda)
            cmd.Parameters.AddWithValue("@id", id)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MsgBox("Data berhasil diupdate", MsgBoxStyle.Information)
            Else
                MsgBox("Data gagal diupdate atau ID tidak ditemukan", MsgBoxStyle.Exclamation)
            End If
        Else
            Dim query As String = "INSERT INTO agendas (name, place, started_at) 
                           VALUES (@name, @place, @tgl_agenda)"
            Dim cmd As New MySqlCommand(query, koneksi)
            cmd.Parameters.AddWithValue("@name", TextBox3.Text)
            cmd.Parameters.AddWithValue("@place", TextBox4.Text)
            cmd.Parameters.AddWithValue("@tgl_agenda", tgl_agenda)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MsgBox("Data berhasil disimpan", MsgBoxStyle.Information)
            Else
                MsgBox("Data gagal disimpan", MsgBoxStyle.Exclamation)
            End If
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        koneksi.Close()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HttpContext.Current.Response.Redirect("main.aspx")
    End Sub
End Class