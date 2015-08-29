<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlSiteMap.ascx.cs" Inherits="admin_controls_ctlSiteMap" %>
<%@ Register Assembly="RadTreeView.Net2" Namespace="Telerik.WebControls" TagPrefix="radT" %>
<h2>Select a Page</h2>
<radt:radtreeview id="RadTreeView1" runat="server" ExpandDelay="1" Height="650px" Width="220px"></radt:radtreeview>
<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False"></asp:PlaceHolder>



