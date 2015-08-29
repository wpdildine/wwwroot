<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/blank.master" AutoEventWireup="true" CodeFile="AddPdf.aspx.cs" Inherits="admin_AddPdf" Title="Untitled Page" %>

<%@ Register Src="controls/cmsPDFEditControl.ascx" TagName="cmsPDFEditControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:cmsPDFEditControl ID="CmsPDFEditControl1" runat="server" />
    <br />
     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>

