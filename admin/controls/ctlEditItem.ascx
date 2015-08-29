<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlEditItem.ascx.cs" Inherits="admin_controls_ctlEditItem" %>
<%@ Register Src="cmsSelectPdf.ascx" TagName="cmsSelectPdf" TagPrefix="uc7" %>
<%@ Register Src="cmsBasicTextEditControl.ascx" TagName="cmsBasicTextEditControl"
    TagPrefix="uc6" %>
<%@ Register Src="cmsTextImageEditControl.ascx" TagName="cmsTextImageEditControl"
    TagPrefix="uc5" %>
<%@ Register Src="cmsPDFEditControl.ascx" TagName="cmsPDFEditControl" TagPrefix="uc4" %>
<%@ Register Src="cmsSelectImage.ascx" TagName="cmsSelectImage" TagPrefix="uc3" %>
<%@ Register Src="cmsImageEditControl.ascx" TagName="cmsImageEditControl" TagPrefix="uc2" %>
<%@ Register Src="cmsTextEditControl.ascx" TagName="cmsTextEditControl" TagPrefix="uc1" %>


<table cellpadding="0" cellspacing="0" width="100%">
  <!--<tr>
    <td style="background:#eaeaea; padding: 4px 8px;">
      <strong>
        <asp:Label ID="lbItemName" runat="server" Text=""></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">D</asp:LinkButton>
      </strong>
    </td>
  </tr>-->
  <tr>
    <td style="padding: 4px 15px 4px 0px;">
      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </td>
  </tr>
  <tr>
    <td style="padding: 0px;">
      <asp:LinkButton ID="lbApprove" runat="server" CssClass="checkLink" Visible="false" OnClick="lbApprove_Click">Approve</asp:LinkButton>
      <asp:LinkButton ID="lbReject" runat="server" CssClass="removeLink" Visible="false" OnClick="lbReject_Click">Reject</asp:LinkButton>
      <asp:Label ID="Label1" runat="server" Font-Italic="True" Text="Awaiting Approval" Visible="False"></asp:Label>
    </td>
  </tr>
</table>
