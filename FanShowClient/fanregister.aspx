<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fanregister.aspx.cs" Inherits="fanregister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fan Registration</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Register</h1>
        <p>Enter your info below to create a Show Tracker Fan account</p>
        <table>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>User name</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Retype Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="lbLogIn" runat="server" CausesValidation="false" PostBackUrl="~/Default.aspx">Log In</asp:LinkButton>

        <asp:RequiredFieldValidator ID="FirstNameRequired" ControlToValidate="txtFirstName" runat="server" ErrorMessage="First name is required" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="LastNameRequired" ControlToValidate="txtLastName" runat="server" ErrorMessage="Last name is required" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="EmailRequired" ControlToValidate="txtemail" runat="server" ErrorMessage="Email is required" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="UserRequired" ControlToValidate="txtUser" runat="server" ErrorMessage="You must choose a user name" Display="None"></asp:RequiredFieldValidator> 
        <asp:RequiredFieldValidator ID="PassRequired" ControlToValidate="txtPass" runat="server" ErrorMessage="You must enter a password" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="ConfirmPassRequired" ControlToValidate="txtConfirmPass" runat="server" ErrorMessage="Please retype your password" Display="None"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="ComparePasswords" ControlToValidate="txtConfirmPass" ControlToCompare="txtPass" runat="server" ErrorMessage="Passwords do not match" Display="None"></asp:CompareValidator>
        <asp:RegularExpressionValidator ID="EmailRegularExpression" ControlToValidate="txtEmail" runat="server" ErrorMessage="Not a valid email" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="noborder" />
      </div>
    </form>
</body>
</html>
