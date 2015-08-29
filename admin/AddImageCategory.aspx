<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/blank.master" AutoEventWireup="true" CodeFile="AddImageCategory.aspx.cs" Inherits="admin_AddImageCategory" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table><tr><td>Category Title</td><td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
   </tr>
       <tr runat="server" id="trLang" visible="true">
           <td>
               Language</td>
           <td>
               <asp:DropDownList ID="ddLanguages" runat="server">
               </asp:DropDownList></td>
       </tr>
   <tr><td align="center" colspan="2">
       <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /></td></tr></table>
</asp:Content>

