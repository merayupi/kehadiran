<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="detailkehadiran.aspx.vb" Inherits="kehadiran.detailkehadiran" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kehadiran</title>
    <link rel="stylesheet" href="./detailkehadiran.css" />
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
            <asp:GridView ID="GridView1" runat="server" Width="250px" CssClass="custom-grid"></asp:GridView>
        </div>
    </form>
</body>
</html>
