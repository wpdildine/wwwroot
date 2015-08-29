<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/blank.master" AutoEventWireup="true" CodeFile="AddImage.aspx.cs" Inherits="admin_AddImage" Title="Untitled Page" %>

<%@ Register Src="controls/cmsImageEditControl.ascx" TagName="cmsImageEditControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table><tr><td><uc1:cmsImageEditControl ID="CmsImageEditControl1" runat="server" /></td></tr>
    <tr><td align="center"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
    <asp:Label ID="Label1" runat="server"></asp:Label></td></tr></table>
</asp:Content>

