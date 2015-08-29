<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmsSelectPdf.ascx.cs" Inherits="admin_controls_cmsSelectPdf" %>
<table><tr><td><asp:HyperLink ID="HyperLink1" CssClass="addLink" runat="server">Add New PDF</asp:HyperLink></td><td><asp:HyperLink ID="HyperLink2" CssClass="internalLink" runat="server"></asp:HyperLink></td><td>
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="removeLink" OnClick="LinkButton1_Click">Delete PDF</asp:LinkButton></td>
</tr><tr><td colspan="3"><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList>
</td></tr></table>
