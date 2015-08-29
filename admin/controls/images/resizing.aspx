<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/blank.master" AutoEventWireup="true" CodeFile="resizing.aspx.cs" Inherits="admin_controls_images_resizing" Title="Untitled Page" %>

<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="radU" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
 <%@ Register Assembly="RadWindow.Net2" Namespace="Telerik.WebControls" TagPrefix="radW" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
var starttime;
var total;
function GetRadWindow()    
    {    
        var oWindow = null;    
        if (window.radWindow) oWindow = window.radWindow;  
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;   
                
        return oWindow;    
    }    
     
    function clickButton() 
    { 
        var radWindow = GetRadWindow(); 
        radWindow.Close(); 
    } 
function OnRequestStart(ajaxPanel, eventArgs)
{
    time = new Date();
    starttime = time.getTime();
       
    UpdateStatusLabel("Processing... please wait.", "red");
    
    // clear data from previous request
    var confirmationLabel = document.getElementById("MainContent_ctl00_ConfirmationLabel");
    confirmationLabel.innerHTML = "";
}

function OnRequestSent(ajaxPanel, eventArgs)
{
    
    DisableControls();    
}

function OnResponseReceived(ajaxPanel, eventArgs)
{                    

    EnableControls();        
}

function OnResponseEnd(ajaxPanel, eventArgs)
{
  var confirmationLabel = document.getElementById("MainContent_ctl00_ConfirmationLabel");
    confirmationLabel.innerHTML = "";
  UpdateStatusLabel(" ", "green");
    UpdateStatusLabel("Success!", "green");
      var updatelabel = document.getElementById("MainContent_ctl00_UpdateStatusLabel");
    updatelabel.innerHTML = "";
    var refresh = document.getElementById("refreshButtonLink");
   refresh.setAttribute('refreshButtonLink', 'title', 'Refresh');
}

function DisableControls()
{
    for (var i=0; i<document.forms[0].elements.length; i++)
    {            
        var obj = document.forms[0].elements[i];
        obj.disabled = true;
    }
}

function EnableControls()
{
    for (var i=0; i<document.forms[0].elements.length; i++)
    {        
        var obj = document.forms[0].elements[i];
        obj.disabled = false;
    }
}

var output;


function UpdateStatusLabel(text, fontColor)
{
    var label = document.getElementById("MainContent_ctl00_StatusLabel");
    label.innerHTML = text;
    label.style.color = fontColor;
    label.style.fontWeight = "bold";
}

 function Showresize(id)
            {
                window.radopen("<%= epicCMSLib.Navigation.SiteRoot %>admin/controls/images/resizing.aspx?id="+id, "EditReImage");
                return false;
            }
</script>
<style type="text/css">
.td{ margin-left: 26px; }
.tdwidth{ margin-left: 29px; }
</style>

<!--[if IE]>
    <style type="text/css">
    .td { margin-left: 25px; }
    .tdwidth{ margin-left: 25px; }
    </style>
    <![endif]-->

<div style="float:left;padding:10px 10px 10px 10px">
<div id="manual" runat="server"><p>Please choose a File, Width, Height or Auto Constraint and a Prefix for your Image.</p><br/>
   <p><asp:Label ID="errorlabel"  runat="server" Text="" /></p><br/>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional" >         
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0">
          <tr><td colspan="2" style="padding-bottom: 3px"><asp:DropDownList ID="ddCat2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddCat2_SelectedIndexChanged" Width="350px"></asp:DropDownList></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:DropDownList ID="ddFiles" runat="server" AutoPostBack="True" Width="350px" Enabled="False" OnSelectedIndexChanged="ddFiles_SelectedIndexChanged"></asp:DropDownList></td></tr>
          <tr><td colspan="2" style="padding-bottom: 5px"><asp:Label ID="Label6" runat="server" Text="Please choose Folder where you would like to save this file to:" /></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:DropDownList ID="ddSavePath" runat="server" AutoPostBack="True" Width="350px" Enabled="false" ></asp:DropDownList></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:Label ID="Label3"  runat="server" Text=""></asp:Label></td></tr>
           <tr><td colspan="2" style="padding-bottom: 10px"><asp:Label ID="Label4"  runat="server" style="margin-right:24px" Text="Image Preview:"></asp:Label><div id="divimage" visible="false" runat="server"></div></td></tr>
          <tr><td style="padding-bottom: 3px"><asp:Label ToolTip="Thumbnail Width" ID="Label1" runat="server" Text="Width in Pixels:" Width="140px"></asp:Label>   <asp:TextBox CssClass="tdwidth" Width="50px" ToolTip="Thumbnail Width" ID="tbwidth" runat="server"></asp:TextBox></td><td align="left" style="padding-left:-20px"><asp:CheckBox  AutoPostBack="true" Text="Auto Constraint" ID="cbContstraint" runat="server" ToolTip="Autoconstraints Proportions - No Height needed!" OnCheckedChanged="cbContstraint_CheckedChanged" /></td></tr>
          <tr><td colspan="2" style="padding-bottom: 3px"><asp:Label ID="Label2" ToolTip="Thumbnail Height" runat="server" Text="Height in Pixels:" Width="140px"></asp:Label>  <asp:TextBox ToolTip="Thumbnail Height" CssClass="td" Width="50px" ID="tbheight" runat="server"></asp:TextBox></td></tr>
           </table>  
          </ContentTemplate>
    </asp:UpdatePanel><br/>

    
    <br/>
     <p><asp:Label ToolTip="Additional Unique Suffix for your Thumbnail." ID="Label5" runat="server" Text="Suffix for Thumbnail:" Width="140px"></asp:Label>   <asp:TextBox style="margin-left:24px" ToolTip="Additional Unique Suffix for your Thumbnail." Width="150px" ID="tbThumb" runat="server"></asp:TextBox></p>
     <br/>
     <br/>
     <p><radA:RadAjaxPanel ID="RadAjaxPanel2" EnableAJAX="true" ClientEvents-OnRequestStart="OnRequestStart" 
                ClientEvents-OnRequestSent="OnRequestSent" 
                ClientEvents-OnResponseReceived="OnResponseReceived" 
                ClientEvents-OnResponseEnd="OnResponseEnd" runat="server" Width="300px" >
         <asp:Button ID="Button3" runat="server" Text="Resize Image" BackColor="white" OnClick="Button3_Click"  /><br/><br/>
        <asp:Label ID="lbSuccess"  runat="server" Text=""></asp:Label>
        </radA:RadAjaxPanel>
        <br/><br/>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="clickButton();" Text="Close" CssClass="link" BackColor="White"/></p>
</div>




<div id="auto" runat="server">
    <p>Please select a Folder to resize its content.</p><br/>
    <p><asp:Label ID="errorlabelauto"  runat="server" Text="" /></p><br/>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server"  UpdateMode="Conditional" >         
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0">
          <tr><td style="padding-bottom: 10px"> <asp:DropDownList ID="ddCat" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCat_SelectedIndexChanged" Width="350px" ></asp:DropDownList></td></tr>
         <tr><td style="padding-bottom: 3px"><asp:Panel ID="Panel1" runat="server"  Height="150px" Width="348px" Visible="false"></asp:Panel></td></tr>
        </table>  
          </ContentTemplate>
    </asp:UpdatePanel><br/>
    <p><radA:RadAjaxPanel ID="RadAjaxPanel1" EnableAJAX="true" ClientEvents-OnRequestStart="OnRequestStart" 
                ClientEvents-OnRequestSent="OnRequestSent" 
                ClientEvents-OnResponseReceived="OnResponseReceived" 
                ClientEvents-OnResponseEnd="OnResponseEnd" runat="server" Width="390px" >
                <span style="padding-right:10px;"><asp:Button ID="Button1" runat="server" Text="Resize Images" BackColor="white" OnClick="Button1_Click"  /></span><asp:Button
                 ID="Button2" runat="server" Text="Delete Source Images (recommended)"  BackColor="white" OnClick="Button2_Click" />
        <br/><br/>
        <asp:Panel ID="lbSuccess2" width="360px" runat="server" Wrap="true" ></asp:Panel><br/>
        <asp:Label ID="ConfirmationLabel"  runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="StatusLabel"  runat="server" Text=""></asp:Label>
        </radA:RadAjaxPanel><br/><br/>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="clickButton();" Text="Close" CssClass="link" BackColor="White"/>
    </p></div>


</div></asp:Content>

