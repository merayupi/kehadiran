<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kehadiran.aspx.vb" Inherits="kehadiran.kehadiran" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kehadiran</title>
    <link rel="stylesheet" href="./kehadiran.css" />
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
            <h1 id="HeaderTitle" runat="server">Kehadiran Acara</h1>
            <div class="input-name">
                <asp:Label ID="Label1" runat="server" Text="Nama: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Height="25px"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Simpan" />
            </div>
        </div>
    </form>
</body>
</html>
