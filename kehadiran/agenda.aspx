<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="agenda.aspx.vb" Inherits="kehadiran.agenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kehadiran</title>
    <link rel="stylesheet" href="./agenda.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <h2>Logo</h2>
            <ul>
                <li><a href="main.aspx">Kehadiran</a></li>
                <li><a href="agenda.aspx">Buat Acara</a></li>
            </ul>
        </div>
        <div class="main-container">
            <h1>Buat Acara</h1>
            <div class="input-name">
                <asp:Label ID="Label1" runat="server" Text="Nama Acara: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Tempat: "></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Tanggal Acara: "></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Jam Mulai Acara: "></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Time"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Simpan" />
            </div>
        </div>
    </form>
</body>
</html>
