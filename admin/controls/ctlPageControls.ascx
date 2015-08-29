<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlPageControls.ascx.cs" Inherits="admin_controls_ctlPageControls" %>
<%@ Register Src="ctlEditItem.ascx" TagName="ctlEditItem" TagPrefix="uc1" %>

<table cellpadding="0" cellspacing="0" width="100%">
<tr><td>
<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
</td>
</tr>
<tr>
<td>
<div style="position: absolute; top: 170px; right: 12px;">
<asp:LinkButton ID="Button1" runat="server" OnClick="Button1_Click" Text="Save Text" CssClass="main_submit_btn" />
</div>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</td>
</tr></table>