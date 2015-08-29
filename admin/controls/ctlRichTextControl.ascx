<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlRichTextControl.ascx.cs" Inherits="admin_controls_ctlRichTextControl" %>

<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
  <link href="../../main.css" type="text/css" rel="stylesheet" />
<radE:RadEditor ID="RadEditor1" runat="server"  Height="260px" Width="350px" AllowCustomColors="False"  RadControlsDir="~/radcontrols/" SkinsPath="~/radcontrols/Editor/Skins"  ConvertFontToSpan="False" ImagesPaths="/RAD_Images/" NewLineBr="true" ShowPreviewMode="False" UploadImagesPaths="/RAD_Images/" ShowSubmitCancelButtons="False" ToolsFile="~/radcontrols/Editor/ToolsFile.xml">
</radE:RadEditor>

