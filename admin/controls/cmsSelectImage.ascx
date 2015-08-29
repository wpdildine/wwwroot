<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmsSelectImage.ascx.cs" Inherits="admin_controls_cmsSelectImage" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional" >  
        
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0">
        <tr><td style="padding-bottom: 3px"> <asp:Image ID="Image1" runat="server" /> </td></tr>
          <tr><td style="padding-bottom: 3px"><asp:DropDownList ID="ddCat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddCat_SelectedIndexChanged" Width="250px"></asp:DropDownList></td></tr>
          <tr><td style="padding-bottom: 3px"><asp:DropDownList ID="ddFiles" runat="server" AutoPostBack="True" Width="250px" Enabled="False" OnSelectedIndexChanged="ddFiles_SelectedIndexChanged"></asp:DropDownList></td></tr>
           </table>  
          </ContentTemplate>
    </asp:UpdatePanel>

  
            