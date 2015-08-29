<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmsImageEditControl.ascx.cs" Inherits="admin_controls_cmsImageEditControl" %>
<table><tr><td valign="top">Image:</td><td>
<asp:Image ID="Image1" runat="server" /><br />
<asp:FileUpload ID="FileUpload1" runat="server" /></td>
</tr>
<tr><td>
Alternate Text:</td><td>
<asp:TextBox ID="tbAltText" runat="server"></asp:TextBox>
</td></tr></table>