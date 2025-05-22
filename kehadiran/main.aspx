<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="main.aspx.vb" Inherits="kehadiran.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 33px;
        }
        .auto-style3 {
            width: 113px;
        }
        .auto-style4 {
            height: 33px;
            width: 113px;
        }
        .auto-style5 {
        }
        .auto-style6 {
            height: 33px;
            width: 191px;
        }
        .auto-style7 {
            width: 113px;
            height: 38px;
        }
        .auto-style8 {
            width: 191px;
            height: 38px;
        }
        .auto-style9 {
            height: 38px;
        }
        .auto-style10 {
            height: 34px;
            width: 113px;
        }
        .auto-style11 {
            height: 34px;
            width: 191px;
        }
        .auto-style12 {
            height: 34px;
        }
        .auto-style17 {
            width: 540px;
        }
        .auto-style18 {
            height: 34px;
            width: 540px;
        }
        .auto-style19 {
            height: 38px;
            width: 540px;
        }
        .auto-style20 {
            height: 33px;
            width: 540px;
        }
        .auto-style21 {
            width: 247px;
        }
        .auto-style22 {
            height: 34px;
            width: 247px;
        }
        .auto-style23 {
            height: 38px;
            width: 247px;
        }
        .auto-style24 {
            height: 33px;
            width: 247px;
        }
        .auto-style25 {
            width: 113px;
            height: 31px;
        }
        .auto-style26 {
            width: 191px;
            height: 31px;
        }
        .auto-style27 {
            width: 247px;
            height: 31px;
        }
        .auto-style28 {
            width: 540px;
            height: 31px;
        }
        .auto-style29 {
            height: 31px;
        }
        .auto-style30 {
            width: 113px;
            height: 32px;
        }
        .auto-style31 {
            width: 191px;
            height: 32px;
        }
        .auto-style32 {
            width: 247px;
            height: 32px;
        }
        .auto-style33 {
            width: 540px;
            height: 32px;
        }
        .auto-style34 {
            height: 32px;
        }
        .auto-style35 {
            width: 161px;
        }
        .auto-style36 {
            height: 34px;
            width: 161px;
        }
        .auto-style37 {
            height: 31px;
            width: 161px;
        }
        .auto-style38 {
            height: 38px;
            width: 161px;
        }
        .auto-style39 {
            height: 33px;
            width: 161px;
        }
        .auto-style40 {
            height: 32px;
            width: 161px;
        }
        .auto-style41 {
            width: 191px;
        }
        .auto-style42 {
            width: 113px;
            height: 30px;
        }
        .auto-style43 {
            width: 191px;
            height: 30px;
        }
        .auto-style44 {
            width: 247px;
            height: 30px;
        }
        .auto-style45 {
            width: 540px;
            height: 30px;
        }
        .auto-style46 {
            height: 30px;
            width: 161px;
        }
        .auto-style47 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11">
                <asp:Button ID="Button3" runat="server" BorderStyle="None" Text="Home" Width="135px" />
            </td>
            <td class="auto-style22"></td>
            <td class="auto-style18"></td>
            <td class="auto-style36">
                <asp:Button ID="Button1" runat="server" Text="Buat Acara" Width="135px" />
            </td>
            <td class="auto-style12">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style25"></td>
            <td class="auto-style26"></td>
            <td class="auto-style27"></td>
            <td class="auto-style28"></td>
            <td class="auto-style37"></td>
            <td class="auto-style29"></td>
        </tr>
        <tr>
            <td class="auto-style25"></td>
            <td class="auto-style26">
                <asp:Label ID="Label1" runat="server" Text="Daftar Acara"></asp:Label>
            </td>
            <td class="auto-style27"></td>
            <td class="auto-style28"></td>
            <td class="auto-style37"></td>
            <td class="auto-style29"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5" colspan="3">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="1107px">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style8"></td>
            <td class="auto-style23"></td>
            <td class="auto-style19"></td>
            <td class="auto-style38"></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style25"></td>
            <td class="auto-style26"></td>
            <td class="auto-style27"></td>
            <td class="auto-style28"></td>
            <td class="auto-style37"></td>
            <td class="auto-style29"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style6"></td>
            <td class="auto-style24"></td>
            <td class="auto-style20"></td>
            <td class="auto-style39"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style42"></td>
            <td class="auto-style43"></td>
            <td class="auto-style44"></td>
            <td class="auto-style45"></td>
            <td class="auto-style46"></td>
            <td class="auto-style47"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style30"></td>
            <td class="auto-style31"></td>
            <td class="auto-style32"></td>
            <td class="auto-style33"></td>
            <td class="auto-style40"></td>
            <td class="auto-style34"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
