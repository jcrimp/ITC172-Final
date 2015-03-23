<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchbyartist.aspx.cs" Inherits="searchbyartist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Shows by Artist</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Search for Shows by Artist</h1>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <h2>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ArtistName") %>'></asp:Label>
                </h2>
                <h3>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ShowName") %>'></asp:Label>
                </h3>
                <p>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ShowDate") %>'></asp:Label><br />
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ShowTime") %>'></asp:Label><br />
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ShowTicketInfo") %>'></asp:Label>
                </p>

            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
