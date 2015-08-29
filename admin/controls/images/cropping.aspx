<%@ Page Language="C#" MasterPageFile="~/App_MasterPages/blank.master" AutoEventWireup="true" CodeFile="cropping.aspx.cs" Inherits="admin_controls_images_cropping" Title="Untitled Page" %>


<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="radU" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
 <%@ Register Assembly="RadWindow.Net2" Namespace="Telerik.WebControls" TagPrefix="radW" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<style type="text/css">

/* Required CSS classes: must be included in all pages using this script */

/* Apply the element you want to drag/resize */

.drsElement {
 position: absolute;
 border: 1px solid #333;

}

/*
 The main mouse handle that moves the whole element.
 You can apply to the same tag as drsElement if you want.
*/
.drsMoveHandle {
 height: 10px;
 border-bottom: 1px solid #666;
 cursor: move;
}

/*
 The DragResize object name is automatically applied to all generated
 corner resize handles, as well as one of the individual classes below.
*/
.dragresize {
 position: absolute;
 width: 5px;
 height: 5px;
 font-size: 1px;
 background: #EEE;
 border: 1px solid #333;
}

/*
 Individual corner classes - required for resize support.
 These are based on the object name plus the handle ID.
*/
.dragresize-tl {
 top: -8px;
 left: -8px;
 cursor: nw-resize;
}
.dragresize-tm {
 top: -8px;
 left: 50%;
 margin-left: -4px;
 cursor: n-resize;
}
.dragresize-tr {
 top: -8px;
 right: -8px;
 cursor: ne-resize;
}

.dragresize-ml {
 top: 50%;
 margin-top: -4px;
 left: -8px;
 cursor: w-resize;
}
.dragresize-mr {
 top: 50%;
 margin-top: -4px;
 right: -8px;
 cursor: e-resize;
}

.dragresize-bl {
 bottom: -8px;
 left: -8px;
 cursor: sw-resize;
}
.dragresize-bm {
 bottom: -8px;
 left: 50%;
 margin-left: -4px;
 cursor: s-resize;
}
.dragresize-br {
 bottom: -8px;
 right: -8px;
 cursor: se-resize;
}
.td{ margin-left: 29px; }
</style>

<!--[if IE]>
    <style type="text/css">
    .td { margin-left: 26px; }
    </style>
    <![endif]-->
              
<div id="crop" runat="server"><p>Please choose a File to resize or to crop.</p>
   <p></p><br/>
   <asp:UpdatePanel ID="UpdatePanel3" runat="server"  UpdateMode="Conditional" >         
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" border="0">
          <tr><td colspan="2" style="padding-bottom: 6px"><asp:Label ID="errorlabelcrop"  runat="server" Text="" /></td></tr>
          <tr><td colspan="2" style="padding-bottom: 3px"><asp:DropDownList ID="ddCat3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddCat3_SelectedIndexChanged" Width="350px"></asp:DropDownList></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:DropDownList ID="ddFiles2" runat="server" AutoPostBack="True" Width="350px" Enabled="False" OnSelectedIndexChanged="ddFiles2_SelectedIndexChanged"></asp:DropDownList></td></tr>
          <tr><td colspan="2" style="padding-bottom: 3px; height: 31px;"><asp:Label ID="Label7" runat="server" Text="Please choose Folder where you would like to save this file to:" /></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:DropDownList ID="ddSaveTo" runat="server" AutoPostBack="True" Width="350px" Enabled="false" ></asp:DropDownList></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:Label ID="Label8"  runat="server" Text=""></asp:Label></td></tr>
          <tr><td colspan="2" style="padding-bottom: 10px"><asp:Label ToolTip="Additional Unique Suffix for your Thumbnail." ID="Label11" runat="server" Text="Suffix for Thumbnail:" Width="140px"></asp:Label>   <asp:TextBox style="margin-left:24px" ToolTip="Additional Unique Suffix for your Thumbnail." Width="150px" ID="tbCropSuffix" runat="server"></asp:TextBox></td></tr>
          <tr><td colspan="2" style="padding-bottom: 3px"><asp:Label ToolTip="Thumbnail Width" ID="Label9" runat="server" Text="Width in Pixels:" Width="140px"></asp:Label>   <asp:TextBox CssClass="td" Width="50px" ToolTip="Thumbnail Width" ID="tbcropWidth" runat="server"></asp:TextBox><asp:CheckBox style="padding-left:10px"  AutoPostBack="true" Text="Auto Constraint" ID="cbCropConstraint" runat="server" ToolTip="Autoconstraints Proportions - No Height needed!" OnCheckedChanged="cbContstraint_CheckedChanged" /></td></tr>
          <tr><td colspan="2" style="padding-bottom: 3px"><asp:Label ID="Label10" ToolTip="Thumbnail Height" runat="server" Text="Height in Pixels:" Width="140px"></asp:Label>  <asp:TextBox ToolTip="Thumbnail Height" style="margin-left:26px" Width="50px" ID="tbcropHeight" runat="server"></asp:TextBox></td></tr>
         <tr><td colspan="2" style="padding-bottom: 10px"><input id="Hidden1"  type="hidden" runat="server" /><input id="Hidden2" type="hidden" runat="server" /><asp:Button BackColor="white" ID="Button5" runat="server" Text="Resize" OnClick="Button5_Click" /></td></tr>
         <tr><td colspan="2" style="padding-bottom: 6px"><asp:Label ID="Label1"  runat="server" Text="Crop Image - Drag the black box on the Top Handle to the position you would like to have it."></asp:Label></td></tr>
         <tr><td colspan="2" style="padding-bottom: 6px"><input id="tbX" type="text" readonly="readonly" /><input id="tbY" type="text" readonly="readonly" /><input id="tbW" type="text" readonly="readonly" /><input id="tbH" type="text" readonly="readonly" /></td></tr>
         <tr><td colspan="2" style="padding-bottom: 6px"><asp:Button BackColor="white" OnClick="Button1_Click" style="margin-right:15px"  ID="Button1" runat="server" Text="Get Crop Tool" /><asp:Button ID="Button4" runat="server" Text="Crop Image" BackColor="white" OnClick="Button4_Click" /><asp:Label style="margin-left:10px" ID="lbSuccess3"  runat="server" Text=""></asp:Label><input id="Hidden3" runat="server" type="hidden" /></td></tr>
         <tr><td colspan="2" style="padding-bottom: 3px" ><div class="drsElement"  visible="false"  id="drag" runat="server" > <div class="drsMoveHandle" >Drag/ Resize Me</div></div><div id="divimage" visible="false" runat="server"></div></td></tr>
           </table>  
          </ContentTemplate>
    </asp:UpdatePanel><br/><br/>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="clickButton();" Text="Close" CssClass="link" BackColor="White"/>
     <p>
         
</p>
</div>

<script language="javascript" type="text/javascript">
//<![CDATA[

//// Using DragResize is simple!
// You first declare a new DragResize() object, passing its own name and an object
// whose keys constitute optional parameters/settings:
function crop()
{
var divimage = document.getElementById('ContentPlaceHolder1_Image1');
var hid1 = document.getElementById('ContentPlaceHolder1_Hidden1');
var hid2 = document.getElementById('ContentPlaceHolder1_Hidden2');
var td  = document.getElementById('tdimage');
var maxt = parseInt(hid2.value); 
var top=0;
var left=0;
var browserName=navigator.appName; 
                if (browserName=="Microsoft Internet Explorer")

			    {
				left = 9 ;
			    top = 403;
			    }
			    else
			    {
				left = 7 ;
			    top = 361 ;
			    }

var dragresize = new DragResize('dragresize',
 { minWidth: parseInt(hid1.value)/4, minHeight: parseInt(hid2.value)/4, minLeft: left, minTop:top, maxLeft: parseInt(hid1.value)+left, maxTop: parseInt(hid2.value)+top });
//var dragresize = new DragResize('dragresize',
// { minWidth: 50, minHeight: 50, minLeft: 5, minTop: 180, maxLeft: 600, maxTop: 600 });

// Optional settings/properties of the DragResize object are:
//  enabled: Toggle whether the object is active.
//  handles[]: An array of drag handles to use (see the .JS file).
//  minWidth, minHeight: Minimum size to which elements are resized (in pixels).
//  minLeft, maxLeft, minTop, maxTop: Bounding box (in pixels).

// Next, you must define two functions, isElement and isHandle. These are passed
// a given DOM element, and must "return true" if the element in question is a
// draggable element or draggable handle. Here, I'm checking for the CSS classname
// of the elements, but you have have any combination of conditions you like:

dragresize.isElement = function(elm)
{
 if (elm.className && elm.className.indexOf('drsElement') > -1) return true;
};
dragresize.isHandle = function(elm)
{
 if (elm.className && elm.className.indexOf('drsMoveHandle') > -1) return true;
};

// You can define optional functions that are called as elements are dragged/resized.
// Some are passed true if the source event was a resize, or false if it's a drag.
// The focus/blur events are called as handles are added/removed from an object,
// and the others are called as users drag, move and release the object's handles.
// You might use these to examine the properties of the DragResize object to sync
// other page elements, etc.

dragresize.ondragfocus = function() { };
dragresize.ondragstart = function(isResize) { };
dragresize.ondragmove = function(isResize) { };
dragresize.ondragend = function(isResize) { };
dragresize.ondragblur = function() { };

// Finally, you must apply() your DragResize object to a DOM node; all children of this
// node will then be made draggable. Here, I'm applying to the entire document.
dragresize.apply(document);

//]]>


    } 
 function getvalues(x,y,w,h)
{
var txX = document.getElementById('tbX');
var txY = document.getElementById('tbY');
var txW = document.getElementById('tbW');
var txH = document.getElementById('tbH');
var x2;var y2; var w2;var h2;
var browserName=navigator.appName; 
               
			    w2 = Math.round(w);
			    txW.value = w2+ 'px';
			    h2 = Math.round(h);
                txH.value = h2+ 'px';
                if (browserName=="Microsoft Internet Explorer")

			    {
			   
			    x2 = parseInt(x)-9;
			    y2 = parseInt(y)-399;
                txX.value = x2 + 'px';
                txY.value = y2+ 'px';
                        }
                else
                {
                x2 = parseInt(x)-9;
			    y2 = parseInt(y)-359;
                txX.value = x2+ 'px';
                txY.value = y2+ 'px';
                
                
                }

var txHid = document.getElementById('ContentPlaceHolder1_Hidden3');

txHid.value = x2+"/"+ y2+"/"+ w2+"/"+ h2;
}       
</script>
</asp:Content>