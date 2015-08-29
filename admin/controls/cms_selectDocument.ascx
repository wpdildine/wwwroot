<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cms_selectDocument.ascx.cs" Inherits="admin_controls_cms_selectDocument" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">
function checkDocumentDropdown(sender, eventArgs) {
   
    var btnUpload = document.getElementById("<%= lbUploadDocument.ClientID %>");
    var tbNewDirectory = $get("<%= tbDirectoryDocument.ClientID %>");

    if (eventArgs.get_item().get_index() != 0) {
        btnUpload.style.visibility = "visible";
    }
    else if (eventArgs.get_item().get_index() == 0 && tbNewDirectory.value == "") {
        btnUpload.style.visibility = 'hidden';
        alert('Please Select or Create a directory to place this document inside.');
    }
}

function myOnClientDocumentSelected(radUpload, eventArgs){
   
    var btnUpload = document.getElementById("<%= lbUploadDocument.ClientID %>");
    var tbNewDirectory = $get("<%= tbDirectoryDocument.ClientID %>");
    var dd = $find("<%= DropDownList1D.ClientID %>");
    
    if ((dd.get_selectedItem().get_index() == 0) && (eventArgs.get_fileInputField().value != "") && (tbNewDirectory.value == "") && (document.getElementById("spacer1").style.display == 'block')) {
        btnUpload.style.visibility = 'hidden';
        alert('Please Select or Create a directory to place this document inside.');
    }

}

function showAddDirectoryDoc(){
    
    $find("<%= tbDirectoryDocument.ClientID %>").set_visible(true);
    document.getElementById("spacer1").style.display = "block";

}

    function hideAddDirectoryDoc() {

    $find("<%= tbDirectoryDocument.ClientID %>").set_visible(false);
    document.getElementById("spacer1").style.display = "none";

}
  
</script>

<asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server" ></asp:ScriptManagerProxy>
<style type="text/css"><!--
    .RadUploadTable { background: none; border: 0px; }
    .RadUploadTable td { border: 0px; padding: 0px;}
    .RadUploadInputField { border: 1px solid #cfcfcf; margin: 0px 0px 0px -2px; }
    .upload_control { margin-top: -5px;  }
    .upload_control .popup_btn { float: left; }
    .dd_error { background: #ffffcb; color: #930; }
    .dd_norm { background: #fff; border: 1px solid #AEAEAE; font-size: 11px; color: #242424; font-family: Arial; padding-left: 2px; margin-bottom: 2px}
--></style>
<div id="scriptpanel" runat="server"></div>   
<cc1:TabContainer ID="TabContainer1"   runat="server" ActiveTabIndex="0" OnClientActiveTabChanged="hideAddDirectoryDoc">
    <cc1:TabPanel ID="TabPanel2Document" runat="server"  HeaderText="TabPanel2" TabIndex="0">
        <HeaderTemplate>
            Select Document
        </HeaderTemplate>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" >
                <asp:UpdatePanel ID="UpdatePanel1Document"  runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <table width="100%"><tr><td>
                            <div style="float:left; width:250px;">
                                <telerik:RadDropDownList Skin="Silk" ID="ddCatDocument" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddCatDocument_SelectedIndexChanged" Width="250px"></telerik:RadDropDownList>
                                <span style="padding-bottom: 3px; border: 0px">
                                    <telerik:RadDropDownList Skin="Silk" ID="ddFilesDocument" runat="server"  AutoPostBack="true" Width="250px" DropDownWidth="400px" Enabled="False" OnSelectedIndexChanged="ddFilesDocument_SelectedIndexChanged"></telerik:RadDropDownList>
                                </span>
                            </div>
                            <div style="float:left;padding-left:10px"></div>
                        </td></tr>
                        <tr><td><a id="atagDocument" visible="false" runat="server" href="" target="_blank" >Preview File</a>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3Document" runat="server" HeaderText="TabPanel3" TabIndex="1">
        <HeaderTemplate>
            Upload New Document
        </HeaderTemplate>
        <ContentTemplate>
            <div style="padding: 2px;">
                 <asp:updatepanel runat="server" id="UpdatePanel3Document" RenderMode="Inline">
                     <contenttemplate>
                        <input style="display:none" class="upload_error" id="Label1Document" type="text"  value="Please select/ create a Directory." />
                        <telerik:RadDropDownList ID="DropDownList1D" Skin="Silk" OnClientItemSelected="checkDocumentDropdown" runat="server"  Width="250px"></telerik:RadDropDownList>
                        <span style="padding-left:5px">
                            <a onclick="showAddDirectoryDoc();" style="cursor:pointer" id="CreateDirectory" runat="server" class="popup_btn popup_submit">Add Directory</a>
                        </span>
                        <div id="spacer1" style="height: 5px; width: 10px; display:none;"></div>
                        <telerik:RadTextBox Skin="Silk" ID="tbDirectoryDocument" runat="server" Width="250px"></telerik:RadTextBox>
                        <div id="spacer2" style="height: 13px; width: 10px;"></div>
                    </contenttemplate>
                </asp:updatepanel>
                        
                        
                <asp:Panel ID="Panel2" runat="server" CssClass="upload_control">
                    <asp:updatepanel runat="server" id="UpdatePanel2Document" UpdateMode="Conditional" RenderMode="Inline">
                        <contenttemplate>
                            <div><telerik:RadUpload Width="300px" Skin="Silk" runat="server" onclientfileselected="myOnClientDocumentSelected" ControlObjectsVisibility="None"  AllowedFileExtensions=".doc,.zip,.pdf,.xls,.vcf" id="RadUploadDocument" /></div>
                            <div style="height: 25px;"><asp:LinkButton runat="server" ID="lbUploadDocument"  Text="Upload" CssClass="popup_btn popup_submit" OnClick="LinkButton1A_Click" /></div>
                        </contenttemplate>
                        <triggers>
                            <asp:postbacktrigger controlid="lbUploadDocument" />
                        </triggers>
                    </asp:updatepanel>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
