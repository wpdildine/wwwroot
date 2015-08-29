<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cms_selectAudio.ascx.cs" Inherits="admin_controls_cms_selectAudio" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">
function checkAudioDropdown(dd) {

    var path = dd.id.replace(/DropDownList1A/, "");
    var btnUpload = document.getElementById(path + 'lbUploadAudio');
    var tbNewDirectory = document.getElementById(path + 'tbDirectoryAudio');
    
    if(dd.selectedIndex != 0) {
        dd.className = "dd_norm";
        btnUpload.style.visibility = "visible";
    }
    else if(dd.selectedIndex == 0 && tbNewDirectory.value == ""){
        btnUpload.style.visibility = 'hidden';
        dd.className = "dd_error";
        alert('Please Select or Create a directory to place this audio inside.');
    }
}

function myOnClientAudioSelected(radUpload, eventArgs){
    var path = eventArgs.FileInputField.id.replace(/RadUploadAudiofile0/, "");
    
    var btnUpload = document.getElementById(path + 'lbUploadAudio');
    var tbNewDirectory = document.getElementById(path + 'tbDirectoryAudio');
    var ddAudio = document.getElementById(path + 'DropDownList1A');
      
    if((ddAudio.selectedIndex==0)&&(eventArgs.FileInputField.value != "")&&(tbNewDirectory.value == "")){
        btnUpload.style.visibility = 'hidden';
        ddAudio.className = "dd_error";
        alert('Please Select or Create a directory to place this audio inside.');
    }

}
function showAudio(link){
    var path = link.id.replace(/CreateDirectory/, "");

    textboxA = document.getElementById(path + 'tbDirectoryAudio');
    if (textboxA.style.display =='none'){
        textboxA.style.display = 'inline';
    }
    else{
        textboxA.style.display ='none';
    }
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
<cc1:TabContainer ID="TabContainer1"   runat="server" ActiveTabIndex="0" >
    <cc1:TabPanel ID="TabPanel2Audio" runat="server"  HeaderText="TabPanel2" TabIndex="0">
        <HeaderTemplate>
            Select Audio
        </HeaderTemplate>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" >
                <asp:UpdatePanel ID="UpdatePanel1Audio"  runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <table width="100%"><tr><td>
                            <div style="float:left; width:250px;">
                                <asp:DropDownList ID="ddCatAudio" CssClass="dd_norm" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddCatAudio_SelectedIndexChanged" Width="250px"></asp:DropDownList>
                                <span style="padding-bottom: 3px; border: 0px">
                                    <asp:DropDownList ID="ddFilesAudio" CssClass="dd_norm" runat="server"  AutoPostBack="true" Width="250px" Enabled="False" OnSelectedIndexChanged="ddFilesAudio_SelectedIndexChanged"></asp:DropDownList>
                                </span>
                            </div>
                            <div style="float:left;padding-left:10px"></div>
                        </td></tr>
                        <tr><td><a id="atagAudio" visible="false" runat="server" href="" target="_blank" >Preview File</a>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3Audio" runat="server" HeaderText="TabPanel3" TabIndex="1">
        <HeaderTemplate>
            Upload New Audio
        </HeaderTemplate>
        <ContentTemplate>
            <div style="padding: 2px;">
                 <asp:updatepanel runat="server" id="UpdatePanel3Audio" RenderMode="Inline">
                     <contenttemplate>
                        <input style="display:none" class="upload_error" id="Label1Audio" type="text"  value="Please select/ create a Directory." />
                        <asp:DropDownList ID="DropDownList1A" CssClass="dd_norm" onchange="checkAudioDropdown(this);" runat="server"  Width="250px"></asp:DropDownList>
                        <span style="padding-left:5px">
                            <a onclick="showAudio(this);" style="cursor:pointer" id="CreateDirectory" runat="server" class="popup_btn popup_submit">Add Directory</a>
                        </span>
                        <asp:TextBox style="display:none" CssClass="txt"  ID="tbDirectoryAudio" runat="server" Width="245px"></asp:TextBox>
                    </contenttemplate>
                </asp:updatepanel>
                        
                        
                <asp:Panel ID="Panel2" runat="server" CssClass="upload_control">
                    <asp:updatepanel runat="server" id="UpdatePanel2Audio" UpdateMode="Conditional" RenderMode="Inline">
                        <contenttemplate>
                            <div><rad:radupload runat="server" onclientfileselected="myOnClientAudioSelected" Skin="Default" ControlObjectsVisibility="None"  AllowedFileExtensions=".mov,.flv,.wmv,.mp3" id="RadUploadAudio" /></div>
                            <div style="height: 25px;"><asp:LinkButton runat="server" ID="lbUploadAudio"  Text="Upload" CssClass="popup_btn popup_submit" OnClick="LinkButton1A_Click" /></div>
                        </contenttemplate>
                        <triggers>
                            <asp:postbacktrigger controlid="lbUploadAudio" />
                        </triggers>
                    </asp:updatepanel>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>