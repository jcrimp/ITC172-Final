<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Tracker Fan Login</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Show Tracker Fan Login</h1>
        <p>Log in below to find shows</p>

        <table>
            <tr>
                <td>User name</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Log in" OnClick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="lbRegister" runat="server" PostBackUrl="~/fanregister.aspx" CausesValidation="false">Register</asp:LinkButton>
        
        <asp:RequiredFieldValidator ID="UserNameRequired" ControlToValidate="txtUserName" runat="server" ErrorMessage="Enter your user name" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="PasswordRequired" ControlToValidate="txtPassword" runat="server" ErrorMessage="Enter your password" Display="None"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="noborder" />
    </div>
    </form>
</body>
</html>
