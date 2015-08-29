<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/popup.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="admin_controls_users_AddUser" Title="Untitled Page" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">
function Save(){
clickButton(); 
RefreshParentPage();
}

function GetRadWindow()    
    {    
        var oWindow = null;    
        if (window.radWindow) oWindow = window.radWindow;  
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;   
                
        return oWindow;    
    }    
      function SizeToFit()
      {
       window.setTimeout(
         function()
         {
            var oWnd = GetRadWindow();
            oWnd.SetWidth(650);
            oWnd.SetHeight(document.body.scrollHeight + 70);
              }, 400);
      }
    function clickButton() 
    { 
        GetRadWindow().Close(); 

    } 
     function close() 
    { 
        GetRadWindow().Close(); 
    } 
      function RefreshParentPage()  
    {  
     GetRadWindow().Close(); 
    var oWnd=GetRadWindow().BrowserWindow;  
    oWnd.location.href=oWnd.location.href.split('#')[0];  
    } 
   
</script>

  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate> 
<table cellspacing="0" cellpadding="0" class="popupTBL">
<tr>
    <th>Username:</th>
    <td><asp:TextBox ID="tbUsername" runat="server" Width="286px"></asp:TextBox></td>
</tr>
<tr>
    <th>Password:</th>
    <td valign="top">
        <asp:TextBox ID="tbPassword" runat="server" ></asp:TextBox>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >Change Password</asp:LinkButton><br/>
          <asp:Panel visible="false"  id="changepass" runat="server" Width="286px">
        <div style="margin-top: -17px;"><table border="0" cellpadding="0" cellspacing="0">
                    <tr><td valign="middle">New Password:</td><td valign="middle"><asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator></td></tr>
                    <tr><td valign="middle">Confirm Password:</td><td valign="middle"><asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator></td></tr>
                    <tr><td align="center" colspan="2" style="color: red"><asp:Label ID="FailureText" runat="server" ></asp:Label></td></tr>
                   <tr><td align="center" colspan="2"><asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ChangePassword1"></asp:CompareValidator></td></tr>
              
        </table></asp:Panel></div></ContentTemplate></asp:UpdatePanel>
    </td>
</tr>
<tr>
    <th>E-Mail:</th>
    <td><asp:TextBox ID="tbEmail" runat="server" Width="286px"></asp:TextBox></td>
</tr>
<tr>
    <th runat="server" id="userlevel">User Level:</th>
    <td><asp:DropDownList ID="ddUserLevel" runat="server"></asp:DropDownList></td>
</tr>
<tr>
    <th>Can Modify Pages:</th>
    <td><asp:Table ID="Table1" runat="server"></asp:Table></td>
</tr>
<tr>
    <th>&nbsp;</th>
    <td class="submit"><asp:LinkButton ID="Submit" runat="server" OnClick="Button1_Click"  Text="Save Changes" CssClass="popup_btn popup_submit"  />
    <asp:Button id="btnPostBackSubmit" runat="server"   style="position:absolute;top:-100px;left:-200px"></asp:Button> 
    
    <asp:LinkButton ID="Button2" runat="server" OnClientClick="clickButton();" Text="Cancel" CssClass="popup_btn popup_cancel" /></td>
</tr>
</table>
   </ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="Submit" />
</Triggers>
</asp:UpdatePanel>
<asp:updateprogress AssociatedUpdatePanelID="UpdatePanel1" id="updateProgress" runat="server">

    <progresstemplate>
        <div id="progressBackgroundFilter"></div>
        <div id="processMessage"> Loading...<br /><br /><img alt="Loading" src="../../../admin/images/loading7.gif" /></div>
    </progresstemplate>

</asp:updateprogress>  
 <div style="position:absolute;top:-10000px;left:-1000px;" > <asp:TextBox ID="txtSubmit"  runat="server" ></asp:TextBox></div>    
</asp:Content>

