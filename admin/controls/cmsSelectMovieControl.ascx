<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmsSelectMovieControl.ascx.cs" Inherits="admin_controls_cmsSelectMovieControl" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI.Controls"
    TagPrefix="cc3" %>

<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">
function changemovie()
{
var labelMovies = $get('Label1Movie');
var labelMoviebut = document.getElementById('<%=lbUploadMovie.ClientID %>');
var tbMovies = $get('<%=tbDirectoryMovie.ClientID %>');
var ddMovies = document.getElementById('<%=DropDownList1M.ClientID %>');
if ((ddMovies.selectedIndex==0)&&(tbMovies.value.length==0))
{
labelMovies.style.display = 'inline';
tbMovies.style.display = 'inline';
tbMovies.style.color = 'red';
ddMovies.style.color='red';
labelMoviebut.style.visibility = 'hidden';
}

else if((ddMovies.selectedIndex==0)&&(tbMovies.value.length>0))
{
labelMovies.style.display = 'none';
labelMoviebut.style.visibility = 'visible';
ddMovies.style.color='black';
tbMovies.style.color = 'black';
tbMovies.style.display = 'inline';
}
else if((ddMovies.selectedIndex>0)&&(tbMovies.value.length==0))
{
tbMovies.style.color = '';
tbMovies.style.display = 'none';
ddMovies.style.color='';
labelMovies.style.display ='none';
labelMoviebut.style.visibility = 'visible';
}
else if ((ddMovies.selectedIndex>0)&&(tbMovies.value.length>0))
{
labelMovies.style.display = 'none';
labelMoviebut.style.visibility = 'visible';
ddMovies.style.color='black';
tbMovies.style.color = 'black';
tbMovies.style.display = 'inline';
}
}
function changeddmovie()
{
var labelMovies = $get('Label1Movie');
var labelMoviebut = document.getElementById('<%=lbUploadMovie.ClientID %>');
var tbMovies = $get('<%=tbDirectoryMovie.ClientID %>');
var ddMovies = document.getElementById('<%=DropDownList1M.ClientID %>');
if ((ddMovies.selectedIndex==0)&&(tbMovies.value.length==0))
{
labelMovies.style.display = 'inline';
tbMovies.style.display = 'inline';
tbMovies.style.color = 'red';
ddMovies.style.color='red';
labelMoviebut.style.visibility = 'hidden';
}

else if((ddMovies.selectedIndex==0)&&(tbMovies.value.length>0))
{
labelMovies.style.display = 'none';
labelMoviebut.style.visibility = 'visible';
ddMovies.style.color='black';
tbMovies.style.color = 'black';
tbMovies.style.display = 'inline';
}
else if((ddMovies.selectedIndex>0)&&(tbMovies.value.length==0))
{
tbMovies.style.color = '';
tbMovies.style.display = 'none';
ddMovies.style.color='';
labelMovies.style.display ='none';
labelMoviebut.style.visibility = 'visible';
}
else if ((ddMovies.selectedIndex>0)&&(tbMovies.value.length>0))
{
labelMovies.style.display = 'none';
labelMoviebut.style.visibility = 'visible';
ddMovies.style.color='black';
tbMovies.style.color = 'black';
tbMovies.style.display = 'inline';
}
}
function myOnClientMovieSelected(radUpload, eventArgs)
{
var labelMovies = $get('Label1Movie');
var labelMoviebut = document.getElementById('<%=lbUploadMovie.ClientID %>');
var tbMovies = $get('<%=tbDirectoryMovie.ClientID %>');
var ddMovies = document.getElementById('<%=DropDownList1M.ClientID %>');

if ((ddMovies.selectedIndex==0)&&(tbMovies.value.length==0))
{
labelMovies.style.display = 'inline';
tbMovies.style.display = 'inline';
tbMovies.style.color = 'red';
ddMovies.style.color='red';
labelMoviebut.style.visibility = 'hidden';
}

else if((ddMovies.selectedIndex==0)&&(tbMovies.value.length>0))
{
labelMovies.style.display = 'none';
labelMoviebut.style.visibility = 'visible';
ddMovies.style.color='black';
tbMovies.style.color = 'black';
tbMovies.style.display = 'inline';
}
else if((ddMovies.selectedIndex>0)&&(tbMovies.value.length==0))
{
tbMovies.style.color = '';
tbMovies.style.display = 'none';
ddMovies.style.color='';
labelMovies.style.display ='none';
labelMoviebut.style.visibility = 'visible';
}
else if ((ddMovies.selectedIndex>0)&&(tbMovies.value.length>0))
{
labelMovies.style.display = 'none';
labelMoviebut.style.visibility = 'visible';
ddMovies.style.color='black';
tbMovies.style.color = 'black';
tbMovies.style.display = 'inline';
}

}
function showMovie()
{
var textboxm = $get('<%=tbDirectoryMovie.ClientID %>');
if (textboxm.style.display =='none')
{
textboxm.style.display = 'inline';
}
else
{
textboxm.style.display ='none';
}

}

    //on upload button click temporarily disables ajax to perform upload actions
    function conditionalPostback(sender, args)
   {
        if(args.EventTarget == "<%= lbUploadMovie.UniqueID  %>")
       {
           args.EnableAjax = false;
       }
   }
   
 
  function togglePopupMovie(){
            var ddl1m = document.getElementById('<%=ddCatMovie.ClientID %>');
            var ddl2m = document.getElementById('<%=ddFilesMovie.ClientID %>');
            var atagm = document.getElementById('<%=atagMovie.ClientID %>');
            atagm.src = "/App_Uploads_Movies/"+ ddl1m.selectedvalue+"/"+ ddl2m.selectedvalue ;  
            }           
</script>


<asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server" >
</asp:ScriptManagerProxy>


 <div id="scriptpanel" runat="server"></div>   
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" >
    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2Movie" TabIndex="0">
        <HeaderTemplate>
            Select File
        </HeaderTemplate>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" >
            
            <asp:UpdatePanel ID="UpdatePanel1Movie"  runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
         <table width="100%"><tr><td>
        <div style="float:left; width:250px;">
        <asp:DropDownList ID="ddCatMovie" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddCatMovie_SelectedIndexChanged" Width="250px"></asp:DropDownList>
          <span style="padding-bottom: 3px; border: 0px"><asp:DropDownList ID="ddFilesMovie" runat="server"  AutoPostBack="true" Width="250px" Enabled="False" OnSelectedIndexChanged="ddFilesMovie_SelectedIndexChanged"></asp:DropDownList></span></div>
           <div style="float:left;padding-left:10px">
           <tr><td><a id="atagMovie" visible="false" runat="server" href="" target="_blank" >Preview File</a></div>
          </td></tr></table>
          </ContentTemplate>
         
    </asp:UpdatePanel></asp:Panel></ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel3Movie" runat="server" HeaderText="TabPanel3" TabIndex="1">
        <HeaderTemplate>
            Upload New Movie
        </HeaderTemplate>
        <ContentTemplate>
        
        <style type="text/css">
            .upload_control { margin-top: -5px;  }
            .upload_control .popup_btn { float: left; }
        </style>
        <div style="padding: 2px;">
            
         <asp:updatepanel runat="server" id="UpdatePanel3Movie" UpdateMode="Always" RenderMode="Inline">
         <contenttemplate>
            <input style="display:none" class="upload_error" id="Label1Movie" type="text"  value="Please select/ create a Directory." />
            <asp:DropDownList ID="DropDownList1M" onchange="changeddmovie();"  runat="server"  Width="250px"></asp:DropDownList>
            
             <span style="padding-left:5px"><a onclick="showMovie();" style="cursor:pointer" id="A1" runat="server" class="popup_btn popup_submit">Add Directory</a></span>
            <asp:TextBox style="display:none"  onchange="changemovie();" ID="tbDirectoryMovie" runat="server" Width="245px"></asp:TextBox>
             </contenttemplate></asp:updatepanel>
   
            <asp:Panel ID="Panel2" runat="server" CssClass="upload_control"><asp:updatepanel runat="server" id="UpdatePanel2Movie" UpdateMode="Conditional" RenderMode="Inline">
                <contenttemplate>
                    <div><rad:radupload runat="server" Skin="Default2006" ControlObjectsVisibility="None" onclientfileselected="myOnClientMovieSelected" AllowedFileExtensions=".mov,.flv,.wmv,.mp3" id="RadUploadMovie" /></div>
                    <div style="height: 25px;"><asp:LinkButton runat="server" ID="lbUploadMovie"  Text="Upload" CssClass="popup_btn popup_submit" OnClick="LinkButton1M_Click" /></div>
                </contenttemplate>
                <triggers>
                    <asp:postbacktrigger controlid="lbUploadMovie" />
                </triggers>
            </asp:updatepanel></asp:Panel>
        
        </div>
       </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>