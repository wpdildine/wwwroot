<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cms_selectImageTimeline.ascx.cs" Inherits="admin_controls_cms_selectImage" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">

    function checkDropdown(sender, eventArgs) {
        var btnUpload = document.getElementById("<%= lbUploadImage.ClientID %>");
    var tbNewDirectory = $get("<%= tbDirectoryImage.ClientID %>");

    btnUpload.style.visibility = 'visible';
    if (eventArgs.get_item().get_index() == 0 && tbNewDirectory.value == "") {
        btnUpload.style.visibility = 'hidden';
        alert('Please Select or Create a directory to place this document inside.');
    }
}

function myOnClientFileSelected(radUpload, eventArgs) {
    var btnUpload = document.getElementById("<%= lbUploadImage.ClientID %>");
    var tbNewDirectory = $get("<%= tbDirectoryImage.ClientID %>");
    var dd = $find("<%= DropDownList1I.ClientID %>");

    btnUpload.style.visibility = 'visible';
    if ((dd.get_selectedItem().get_index() == 0) && (eventArgs.get_fileInputField().value != "") && (tbNewDirectory.value == "") && (document.getElementById("spacer1").style.display == 'block')) {
        btnUpload.style.visibility = 'hidden';
        alert('Please Select or Create a directory to place this IMAGE inside.');
    }

}
function conditionalPostback(sender, args) {
    if (args.EventTarget == "<%= lbUploadImage.UniqueID  %>") {
        args.EnableAjax = false;
    }
}

function showAddDirectory() {

    $find("<%= tbDirectoryImage.ClientID %>").set_visible(true);
        document.getElementById("spacer1").style.display = "block";

    }

    function hideAddDirectory() {

        $find("<%= tbDirectoryImage.ClientID %>").set_visible(false);
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
    .dd_norm { background: #fff; border: 1px solid #AEAEAE; font-size: 11px; color: #242424; font-family: Arial; padding-left: 2px; margin-bottom: 2px }
    .resize_options { float: right; }
    .resize_options label { font-size: 10px; }
    .resize_note { font-size: 10px; display: block; margin-bottom: 3px;}
--></style>
<div id="scriptpanel" runat="server"></div>   
<cc1:TabContainer ID="TabContainer1"   runat="server" ActiveTabIndex="0" OnClientActiveTabChanged="hideAddDirectory">
    <cc1:TabPanel ID="TabPanel2" runat="server"  HeaderText="TabPanel2" TabIndex="0">
        <HeaderTemplate>
            Select Image
        </HeaderTemplate>
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel1Image" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%"><tr><td style="border: 0px;">
                        <div style="float:left; width:250px;">
                            <telerik:RadDropDownList Skin="Silk" ID="ddCatImage" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddCatImage_SelectedIndexChanged" Width="250px"></telerik:RadDropDownList><br/>
                            <span style="padding-bottom: 3px; border: 0px">
                                <telerik:RadDropDownList Skin="Silk" ID="ddFilesImage" runat="server"  AutoPostBack="true" Width="250px" DropDownWidth="400px" Enabled="False" OnSelectedIndexChanged="ddFilesImage_SelectedIndexChanged"></telerik:RadDropDownList>
                            </span>
                        </div>
                        <div style="float:left;padding-left:10px"><img id="img" runat="server" src="/admin/images/spacer.gif" alt=""  /></div>
                    </td></tr></table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" TabIndex="1">
        <HeaderTemplate>
            Upload New Image
        </HeaderTemplate>
        <ContentTemplate>
            <div style="padding: 2px;">
                <asp:updatepanel runat="server" id="UpdatePanel3Image" UpdateMode="Always" RenderMode="Inline">
                    <contenttemplate>
                        <input style="display:none" class="upload_error" id="Label1Image" type="text"  value="Please Select or Create a Directory." />
                        <telerik:RadDropDownList Skin="Silk" ID="DropDownList1I" OnClientItemSelected="checkDropdown" runat="server"  Width="250px"></telerik:RadDropDownList>
                        <span style="padding-left:5px">
                            <a onclick="showAddDirectory();" style="cursor:pointer" id="CreateDirectory" runat="server" class="popup_btn popup_submit">Create Directory</a>
                        </span>
                        <div id="spacer1" style="height: 5px; width: 10px; display:none;"></div>
                        <telerik:RadTextBox Skin="Silk" ID="tbDirectoryImage" runat="server" Width="250px"></telerik:RadTextBox>
                        <div id="spacer2" style="height: 13px; width: 10px;"></div>
                   
                    <div class="resize_options" runat="server" id="resize_options" visible="false">
                    
                    <asp:CheckBox runat="server" Text="Resize Image" ID="chkResize" /><br />
                    <span id="resize_area">
                    <asp:CheckBox runat="server" Text="Constrain Size" ID="chkConstrain"/><br />
                    <br />
                    Width <asp:TextBox CssClass="tdwidth" Width="50px" ToolTip="Thumbnail Width" ID="resize_Width" runat="server"></asp:TextBox>px<br />
                    <span id="height_container">Height <asp:TextBox CssClass="tdwidth" Width="50px" ToolTip="Thumbnail Width" ID="resize_Height" runat="server"></asp:TextBox>px<br /></span>
                    Suffix <asp:TextBox ToolTip="Additional Unique Suffix for your Thumbnail." Width="50px" ID="resize_Suffix" runat="server"></asp:TextBox>
                    </span>
                    </div>
                    
                    
                    
                    </contenttemplate>
                </asp:updatepanel>
                
                <asp:Panel ID="Panel2" runat="server" CssClass="upload_control">
                    <asp:updatepanel runat="server" id="UpdatePanel2Image" UpdateMode="Conditional" RenderMode="Inline">
                        <contenttemplate>
                            <div><telerik:RadUpload Width="300px" Skin="Silk" MaxFileSize="102400000" runat="server" ControlObjectsVisibility="None" AllowedFileExtensions=".png,.jpeg,.jpg,.gif,.JPG,.GIF,.PNG,.JPEG" onclientfileselected="myOnClientFileSelected" id="RadUpload1" OnFileExists="RadUpload1_FileExists1" /></div>
                            <asp:Label runat="server" CssClass="resize_note" ID="resize_note" />
                            <div style="height: 25px;"><asp:LinkButton runat="server" ID="lbUploadImage"  Text="Upload" CssClass="popup_btn popup_submit" OnClick="LinkButton1_Click" /></div>
                        </contenttemplate>
                        <triggers>
                            <asp:postbacktrigger controlid="lbUploadImage" />
                        </triggers>
                    </asp:updatepanel>
                </asp:Panel>
            </div>  
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
