<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmsSelectDocuments.ascx.cs" Inherits="admin_controls_cmsSelectDocuments" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI.Controls"
    TagPrefix="cc3" %>

<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">

function changedocs()
{
var labelDocs = $get('Label1Doc');
var labelDocbut = document.getElementById('<%=lbUploadDoc.ClientID %>');
var tbDocs = $get('<%=tbDirectoryDoc.ClientID %>');
var ddDocs = document.getElementById('<%=DropDownList1D.ClientID %>');
if ((ddDocs.selectedIndex==0)&&(tbDocs.value.length==0))
{
labelDocs.style.display = 'inline';
tbDocs.style.display = 'inline';
tbDocs.style.color = 'red';
ddDocs.style.color='red';
labelDocbut.style.visibility = 'hidden';
}

else if((ddDocs.selectedIndex==0)&&(tbDocs.value.length>0))
{
labelDocs.style.display = 'none';
labelDocbut.style.visibility = 'visible';
ddDocs.style.color='black';
tbDocs.style.color = 'black';
tbDocs.style.display = 'inline';
}
else if((ddDocs.selectedIndex>0)&&(tbDocs.value.length==0))
{
tbDocs.style.color = '';
tbDocs.style.display = 'none';
ddDocs.style.color='';
labelDocs.style.display ='none';
labelDocbut.style.visibility = 'visible';
}
else if ((ddDocs.selectedIndex>0)&&(tbDocs.value.length>0))
{
labelDocs.style.display = 'none';
labelDocbut.style.visibility = 'visible';
ddDocs.style.color='black';
tbDocs.style.color = 'black';
tbDocs.style.display = 'inline';
}
}
function changedddocs()
{
var labelDocs = $get('Label1Doc');
var labelDocbut = document.getElementById('<%=lbUploadDoc.ClientID %>');
var tbDocs = $get('<%=tbDirectoryDoc.ClientID %>');
var ddDocs = document.getElementById('<%=DropDownList1D.ClientID %>');
if ((ddDocs.selectedIndex==0)&&(tbDocs.value.length==0))
{
labelDocs.style.display = 'inline';
tbDocs.style.display = 'inline';
tbDocs.style.color = 'red';
ddDocs.style.color='red';
labelDocbut.style.visibility = 'hidden';
}

else if((ddDocs.selectedIndex==0)&&(tbDocs.value.length>0))
{
labelDocs.style.display = 'none';
labelDocbut.style.visibility = 'visible';
ddDocs.style.color='black';
tbDocs.style.color = 'black';
tbDocs.style.display = 'inline';
}
else if((ddDocs.selectedIndex>0)&&(tbDocs.value.length==0))
{
tbDocs.style.color = '';
tbDocs.style.display = 'none';
ddDocs.style.color='';
labelDocs.style.display ='none';
labelDocbut.style.visibility = 'visible';
}
else if ((ddDocs.selectedIndex>0)&&(tbDocs.value.length>0))
{
labelDocs.style.display = 'none';
labelDocbut.style.visibility = 'visible';
ddDocs.style.color='black';
tbDocs.style.color = 'black';
tbDocs.style.display = 'inline';
}
}
function myOnClientDocsSelected(radUpload, eventArgs)
{
var labelDocs = $get('Label1Doc');
var labelDocbut = document.getElementById('<%=lbUploadDoc.ClientID %>');
var tbDocs = $get('<%=tbDirectoryDoc.ClientID %>');
var ddDocs = document.getElementById('<%=DropDownList1D.ClientID %>');

if ((ddDocs.selectedIndex==0)&&(tbDocs.value.length==0))
{
labelDocs.style.display = 'inline';
tbDocs.style.display = 'inline';
tbDocs.style.color = 'red';
ddDocs.style.color='red';
labelDocbut.style.visibility = 'hidden';
}

else if((ddDocs.selectedIndex==0)&&(tbDocs.value.length>0))
{
labelDocs.style.display = 'none';
labelDocbut.style.visibility = 'visible';
ddDocs.style.color='black';
tbDocs.style.color = 'black';
tbDocs.style.display = 'inline';
}
else if((ddDocs.selectedIndex>0)&&(tbDocs.value.length==0))
{
tbDocs.style.color = '';
tbDocs.style.display = 'none';
ddDocs.style.color='';
labelDocs.style.display ='none';
labelDocbut.style.visibility = 'visible';
}
else if ((ddDocs.selectedIndex>0)&&(tbDocs.value.length>0))
{
labelDocs.style.display = 'none';
labelDocbut.style.visibility = 'visible';
ddDocs.style.color='black';
tbDocs.style.color = 'black';
tbDocs.style.display = 'inline';
}

}


function showDocs()
{
var textboxDoc = $get('<%=tbDirectoryDoc.ClientID %>');
if (textboxDoc.style.display =='none')
{
textboxDoc.style.display = 'inline';
}
else
{
textboxDoc.style.display ='none';
}

}

    //on upload button click temporarily disables ajax to perform upload actions
    function conditionalPostback(sender, args)
   {
        if(args.EventTarget == "<%= lbUploadDoc.UniqueID  %>")
       {
           args.EnableAjax = false;
       }
   }
   
 //  keeps track of the delete button for the row
    //  that is going to be removed
    var _source;
    // keep track of the popup div
    var _popup;
    
    function onTextChange(source){
        this._source = source;

if ((key == Sys.UI.Key.Space) || (key == Sys.UI.Key.Return) || (window.event.keyCode == 13)) 
                     showConfirmedit(this._source); 
                     return false;

}
    
    function showConfirm(source){
        this._source = source;
        this._popup = $find('mdlPopup');
        
        //  find the confirm ModalPopup and show it    
        this._popup.show();
    }
 
    function cancelClick(){
     
        //  find the confirm ModalPopup and hide it 
        this._popup.hide();
         
        //  clear the event source
        this._source = null;
        this._popup = null;
        
    }
  function togglePopupImage(){
            var ddl1d = document.getElementById('<%=ddCatDoc.ClientID %>');
            var ddl2d = document.getElementById('<%=ddFilesDoc.ClientID %>');
            var atagDoc = document.getElementById('<%=atagDoc.ClientID %>');
            atagDoc.src = "/App_Uploads_Docs/"+ ddl1d.selectedvalue+"/"+ ddl2d.selectedvalue ;  
            }           
</script>


<asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server" >
</asp:ScriptManagerProxy>
<style type="text/css">
    .RadUploadTable { background: none; border: 0px; }
    .RadUploadTable td { border: 0px; padding: 0px;}
    .RadUploadInputField { border: 1px solid #cfcfcf; margin: 0px 0px 0px -2px; }
   
</style>

 <div id="scriptpanel" runat="server"></div>   
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" >
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" TabIndex="0">
        <HeaderTemplate>
            Select Document
        </HeaderTemplate>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" >
            
            <asp:UpdatePanel ID="UpdatePanel1Doc"  runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
         <table width="100%"><tr><td style="border:0px">
        <div style="float:left; width:250px;">
        <asp:DropDownList ID="ddCatDoc" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddCatDoc_SelectedIndexChanged" Width="250px"></asp:DropDownList>
          <span style="padding-bottom: 3px; border: 0px"><asp:DropDownList ID="ddFilesDoc" runat="server"  AutoPostBack="true" Width="250px" Enabled="False" OnSelectedIndexChanged="ddFilesDoc_SelectedIndexChanged"></asp:DropDownList></span></div>
           <div style="float:left;padding-left:10px">
           <tr><td style="border:0px"><a id="atagDoc" visible="false" runat="server" href="" target="_blank" >Preview File</a></div>
          </td></tr></table>
          </ContentTemplate>
         
    </asp:UpdatePanel></asp:Panel></ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3Docs" runat="server" HeaderText="TabPanel3" TabIndex="1">
        <HeaderTemplate>
            Upload New Document
        </HeaderTemplate>
        <ContentTemplate>
       
        <style type="text/css">
            .upload_control { margin-top: -5px;  }
            .upload_control .popup_btn { float: left; }
        </style>
        <div style="padding: 2px;">
 
 
       <asp:updatepanel runat="server" id="UpdatePanel3Docs" UpdateMode="Always" RenderMode="Inline">
         <contenttemplate>
            <input style="display:none" class="upload_error" id="Label1Doc" type="text"  value="Please select/ create a Directory." />
            <asp:DropDownList ID="DropDownList1D" onchange="changedddocs();"  runat="server"  Width="250px"></asp:DropDownList>
            
            <span style="padding-left:5px"><a onclick="showDocs();" style="cursor:pointer" id="Submit" runat="server" class="popup_btn popup_submit">Add Directory</a></span>
            <asp:TextBox style="display:none" onchange="changedocs();" ID="tbDirectoryDoc" runat="server" Width="245px"></asp:TextBox>
             </contenttemplate></asp:updatepanel>
 

            <asp:Panel ID="Panel2" runat="server" CssClass="upload_control">
            <asp:updatepanel runat="server" id="UpdatePanel2Doc" UpdateMode="Conditional" RenderMode="Inline">
                <contenttemplate>
                    <div><rad:radupload onclientfileselected="myOnClientDocsSelected" runat="server" Skin="Default" ControlObjectsVisibility="None" AllowedFileExtensions=".doc,.zip,.pdf,.xls" id="RadUploadDoc" /></div>
                    <div style="height: 25px;"><asp:LinkButton runat="server" ID="lbUploadDoc"  Text="Upload" CssClass="popup_btn popup_submit" OnClick="LinkButton1D_Click" /></div>
                    
                </contenttemplate>
                <triggers>
                    <asp:postbacktrigger controlid="lbUploadDoc" />
                </triggers>
            </asp:updatepanel></asp:Panel>
        
        </div>
       </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>