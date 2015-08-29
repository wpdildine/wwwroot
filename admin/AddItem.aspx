<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="admin_AddItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../App_Css/epicCMS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table><tr><td>Item Title:</td><td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
    <tr><td>Item Type:</td><td>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList></td></tr>
        <tr><td align="center" colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /></td></tr>
    </table>
    </div>
        <asp:Label ID="lbJs" runat="server"></asp:Label>
    </form>
</body>
</html>
