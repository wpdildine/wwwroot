<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/epicCMS.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<style type="text/css">
.chk_test input { margin-right: 5px; }
</style>
<table width="100%" style="border-left: 1px solid #fff; margin-left: -1px;">
    <tr>
        <td style="padding-left:120px;padding-top:50px;padding-bottom:80px">
            <table class="sidenav" style="width: 400px">
                <tr><td colspan="2" class="sidenav">Login</td></tr>
                <tr>
                    <td colspan="2" align="center" style="padding-top:3px">
                      <asp:Login ID="Login1" runat="server" Height="125px" LoginButtonText="Login" LoginButtonStyle-CssClass="login_submit" OnAuthenticate="Login1_Authenticate" TitleText="" Width="259px"> </asp:Login></td>
      
                    </tr>
                </table>
</td></tr></table>  
        
</asp:Content>

