<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="main.aspx.vb" Inherits="kehadiran.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kehadiran</title>
    <link rel="stylesheet" href="./main.css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet"/>
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
        <h1>Daftar Kehadiran</h1>
        <div class="container">
            <div class="card-container">
                <div class="card red">
                    <div class="card-header">
                        <div class="card-icon">📅</div>
                        <h3>Acara</h3>
                    </div>
                    <div class="card-content">
                        <p><asp:Label ID="Label1" runat="server" Text="Label" CssClass="custom-label"></asp:Label></p>
                    </div>
                </div>

                <div class="card green">
                    <div class="card-header">
                        <div class="card-icon">👤</div>
                        <h3>Kehadiran</h3>
                    </div>
                    <div class="card-content">
                        <p><asp:Label ID="Label2" runat="server" Text="Label" CssClass="custom-label"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="search-agenda">
                <asp:Label ID="Label3" runat="server" Text="Nama Acara: "></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="139px"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Tanggal Acara: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Cari" Width="74px" />
            </div>
            <asp:GridView ID="GridView1" runat="server" Width="973px" CssClass="custom-grid">
                
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
