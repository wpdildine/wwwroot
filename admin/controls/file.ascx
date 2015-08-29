<%@ Control Language="C#" AutoEventWireup="true" CodeFile="file.ascx.cs" Inherits="admin_controls_file" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <%@ Register Assembly="RadWindow.Net2" Namespace="Telerik.WebControls" TagPrefix="radW" %>

<style type="text/css">
.confirm { width: 200px; }


.inner { padding: 10px 8px;}
.upload_panel { position: absolute; top: -5px; left: 399px; display: none; padding: 8px 4px; border: 1px solid #ccc; background: #f7f7f7; width: 405px; margin-top: 5px}
.upload_panel .ruInputs { background: none; border: 0px; width: 408px; padding:  4px 0px}
.upload_panel .ruCheck, .upload_panel .ruDelete { display: none; }
.upload_panel .ruFakeInput, .upload_panel .ruFileInput { width: 258px; }

.upload_panel .ruBrowse, .upload_panel .ruRemove, .upload_panel .ruAdd { cursor: pointer; }

.upload_panel .ruRemove { margin-left: -4px; }
.upload_panel .hdnBtn { display: none; }
.popup_btn {text-decoration: none; cursor: pointer; padding: 4px 8px; font: normal .9em verdana; text-transform: uppercase; }
.popup_submit {  border: 1px solid #ccc; background: #FFF4BF; }
.upload_panel .popup_btn { margin-top: -25px; float: right;}

.preview { display:none;margin: 0px 0px 0px -3px; padding: 4px; border: 1px solid #ccc; float: left; }

.movieupload label { width: 90px; display: inline; clear: left; float: left;}
.movieupload input.txt { border: 1px solid #cfcfcf; width: 100px; }
.movieupload .ruFakeInput { width: 258px; }

.directory { clear: left; float:left; display: inline; width: 400px; margin-right: 2px; }
.directory .structure { border: 1px solid #ccc; padding: 4px; position: relative; padding-left: 0px; padding-right: 0px; height: inherit;}

.autoresize, .manualresize { clear: both; left: 399px; top: 9px; }
.autoresize .popup_btn { float: none; }
.manualresize .popup_btn { margin-top: 0px; }
#progressBackgroundFilter {
    position:fixed; 
    top:0px; 
    bottom:0px; 
    left:0px;
    right:0px;
    overflow:hidden; 
    padding:0; 
    margin:0; 
    background-color:#000; 
    filter:alpha(opacity=100); 
    opacity:0.5; 
    z-index:1000; 
}

#processMessage { 
    position:fixed; 
    top:30%; 
    left:43%;
    padding:10px; 
    width:14%; 
    z-index:1001; 
    background-color:#fff;
    border:solid 1px #000;
}

</style>
<!--[if IE]>
    <style type="text/css">.upload_panel .ruFileInput { margin-left: 80px}
    </style>
    <![endif]-->
<script type="text/javascript" src="/App_Js/tools.js"></script>
<script type="text/javascript">
  //  keeps track of the delete button for the row
    //  that is going to be removed
    var _source;
    // keep track of the popup div
    var _popup;
     var fpath;
function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
      
         function showConfirmFolder(source){
        this._source = source;
        this._popup = $find('mdlPopupFolder');
      
        
        //  find the confirm ModalPopup and show it    
        this._popup.show();
    }
      function showConfirm(source){
        this._source = source;
        this._popup = $find('mdlPopup');

        
        //  find the confirm ModalPopup and show it    
        this._popup.show();
    }
    
     function okClickFolder(){
        
        // If we are previewing an image, we can't delete it.  So we must set all of the images srcs to "" in order to delete
        var imgs =document.getElementsByTagName("img");
        for(var i = 0; i <= imgs.length; i++) {
            
            if(imgs[i]) {
                if(imgs[i].className == "preview_image") {
                    imgs[i].src = "";
                }
            }
        }
        
        //  find the confirm ModalPopup and hide it  
        this._popup.hide();
         var Pbd = document.getElementById('<%=PostbackDelete.ClientID %>');
        Pbd.click();
        //  use the cached button as the postback source
    }
    
    
     function okClick(){
        if(document.getElementById("preview_image"))
            document.getElementById("preview_image").src = "";
        //  find the confirm ModalPopup and hide it    
        this._popup.hide();
         var Pbd = document.getElementById('<%=PostbackDelete.ClientID %>');
         Pbd.click();
        //  use the cached button as the postback source
       
    }
    function RemoveNode(node)
    {
        var treeView = $find('<%=RadTreeView1.ClientID %>');
        var parentNode = node.get_parent();
        treeView.trackChanges();
        parentNode.get_nodes().remove(node);
        treeView.commitChanges();
        
    }
    
    function cancelClick(){
     
        //  find the confirm ModalPopup and hide it 
        this._popup.hide();
         
        //  clear the event source
        this._source = null;
        this._popup = null;
        
    }  
      function hideallpanel()
      {
        var upimage = document.getElementById('uploadimagepanel');
        var panel = document.getElementById('preview');
        upimage.style.display = 'none';
         
      }
      function hideresize()
      {
          var aure = document.getElementById('<%= autoresize.ClientID %>');
              var mare = document.getElementById('<%= manualresize.ClientID %>');
      aure.style.display = 'none';
          mare.style.display = 'none';
      }
    function onNodeClicking(sender, args)
            {
            var file=document.getElementById('<%=txtFile.ClientID %>');
            var pan = document.getElementById('preview');
              var path= args.get_node().get_value();
              var text= args.get_node().get_text();
              var cat = args.get_node().get_category();
              if (cat != "Folder")
              {
               pan.style.display = 'inline';
               updateDateKey(path+':'+text);
              }
              else
              {
              pan.style.display = 'inline';
              updateDateKey2(path+':'+text);
              }

              file.value=path;
            hideallpanel();
            hideresize();
            }
      function onClientContextMenuItemClicked(sender, args)
                {
                      var upimage = document.getElementById('uploadimagepanel');
              var updocs = document.getElementById('uploaddocspanel');
              //var upmovie = document.getElementById('uploadmoviepanel');
              var upaudio = document.getElementById('uploadaudiopanel');
              var uppodcast = document.getElementById('uploadpodcastpanel');
              var panel = document.getElementById('preview');
              var aure = document.getElementById('<%= autoresize.ClientID %>');
              var mare = document.getElementById('<%= manualresize.ClientID%>');
              var dll=document.getElementById('<%=ddCat.ClientID %>');
              var file=document.getElementById('<%=txtFile.ClientID %>');
              var filep=document.getElementById('<%=txtroot.ClientID %>');
                    var menuItem = args.get_menuItem();
                    var treeNode = args.get_node();
                    var treeNodetext = args.get_node().get_text();
                   var path= args.get_node().get_value();
                            var cat = args.get_node().get_category();
                   var level = args.get_node().get_level();
                    switch(menuItem.get_value())
                    {
                        case "Copy":
                            break;
                        case "Rename":
                            /*if(document.getElementById("preview_image_cont"))
                                document.getElementById("preview_image_cont").innerHTML = "";
                            if(document.getElementById("preview_image"))
                                document.getElementById("preview_image").src = "";*/
                            treeNode.get_treeView()._startEdit(treeNode);
                            break;
                        case "NewFolder":
                            break;
                        case "Resize":                       
                         setFocus(path);
                             mare.style.display = 'none';
                             aure.style.display = 'block';
                             hideallpanel();
                             panel.style.display = 'none';
                            break;
                             case "ResizeFile":
                             var image=document.getElementById("<% = image.ClientID%>");
                              updateDateKeyimage(path+':'+treeNodetext);
                             image.alt = treeNodetext;
                             file.value=path;
                              var height = document.getElementById('<%= height.ClientID %>');
                              var check = document.getElementById('<%= cbContstraint.ClientID %>');
                              var width = document.getElementById('<%= tbwidth.ClientID %>');
                              var suffix = document.getElementById('<%= tbThumb.ClientID %>');
                               check.checked=false;
                               height.style.visibility = 'visible';
                               width.value = "";
                               suffix.value="";
                             aure.style.display = 'none';
                             mare.style.display = 'block';
                             hideallpanel();
                             panel.style.display = 'none';
                             
                            break;
                            case "Delete": 
                            file.value=path;
                                           
                            if(level != '0')
                            { 
                            
                            if (cat == 'Folder')
                            {
                            showConfirmFolder(this,path); 
                            
                            }
                            else
                            {
      
                            showConfirm(this,path); 
                            }
                            }
                            
                            break;
                         case "AddFile":
                            hideresize();
                        
              if (path.match('App_Uploads_Img'))
              {
               upimage.style.display = 'block';
               updocs.style.display = 'none';
               //upmovie.style.display = 'none';
               panel.style.display = 'none';
               upaudio.style.display = 'none';
               uppodcast.style.display = 'none';
              }
              else if (path.match('App_Uploads_Docs'))
              {
               upimage.style.display = 'none';
               updocs.style.display = 'block';
                 //upmovie.style.display = 'none';
               panel.style.display = 'none';
               upaudio.style.display = 'none';
               uppodcast.style.display = 'none';
              }
              else if (path.match('App_Uploads_Movie'))
              {
               upimage.style.display = 'none';
               updocs.style.display = 'none';
               //upmovie.style.display = 'block';
               panel.style.display = 'none';
               upaudio.style.display = 'none';
               uppodcast.style.display = 'none';
              }
              else if (path.match('App_Uploads_Audio'))
              {
               upaudio.style.display = 'block';
               upimage.style.display = 'none';
               updocs.style.display = 'none';
               //upmovie.style.display = 'none';
               panel.style.display = 'none';
               uppodcast.style.display = 'none';
              }
              else if (path.match('App_Uploads_Podcasts'))
              {
               uppodcast.style.display = 'block';
               upaudio.style.display = 'none';
               upimage.style.display = 'none';
               updocs.style.display = 'none';
               //upmovie.style.display = 'none';
               panel.style.display = 'none';
              }
                                break;
                    }
                }
function OnSelectedIndexChange()

{
var ddl = document.getElementById('<%=ddCat.ClientID %>').value;
setFocus(ddl);
}
   function setFocus(nodevalue)
{
var dom = document.getElementById('<%=txtFilePath.ClientID %>').value;
var dll=document.getElementById('<%=ddCat.ClientID %>');
var error=document.getElementById('<%=errorlabelauto.ClientID %>');
     var panel2=document.getElementById('<%=Panel2.ClientID %>');
     var folder=document.getElementById('<%=txtFile.ClientID %>');
var found=false;
for (i=0;i<dll.options.length;i++)
{
if (nodevalue.replace(dom,'').replace('/','\\') == dll.options[i].value)
{
found=true;
break;
}
}
if (found==true)
{
error.innerHTML ="";
dll.options[i].selected=true;
panel2.style.visibility = 'visible';
folder.value = nodevalue.replace(dom,'').replace('/','\\');
updateDateKeyResizeImages(nodevalue.replace(dom,'').replace('/','\\'));
}
else
{
dll.selectedIndex=0;

           panel2.style.visibility = 'hidden';  
error.style.color = "red";
error.innerHTML ="The selected Folder does not include image files. Please choose another folder.";
}
return;
}
  
  


   function AutoResizeImages()
   {

   updateDateKeyAutoResizeImages('hello');
   var aure = document.getElementById('<%= autoresize.ClientID %>');
   aure.style.display = 'block';
   var but = document.getElementById('<%= Postbtn.ClientID %>');
   but.click();

   }    
 function onNodeDragging(sender, args)
                {
                    var target = args.get_htmlElement();    
                    
                    if(!target) return;
                    
                    if (target.tagName == "INPUT")
                    {        
                        target.style.cursor = "hand";
                    }

                  
                }
        
                function dropOnHtmlElement(args)
                {                    
                 if(droppedOnInput(args))
                 return;
              }
                function droppedOnGrid(args)
                {
                 var target = args.get_htmlElement();
                
                 while(target)
                 {
               
                
                 target = target.parentNode;
                 }
                 args.set_cancel(true);
                }
                
                function droppedOnInput(args)
                {
                 var target = args.get_htmlElement();
                    if (target.tagName == "INPUT")
                    {
                        target.style.cursor = "default";
                        target.value = args.get_sourceNode().get_text();        
                        args.set_cancel(true);
                        return true;
                    }                         
                }
        
                function dropOnTree(args)
                {
                    var text = "";

                    if(args.get_sourceNodes().length)
                    {    
                        var i;
                        for(i=0; i < args.get_sourceNodes().length; i++)
                        {
                            var node = args.get_sourceNodes()[i];
                            text = text + ', ' +node.get_text();
                        }
                    }
                }
                
              
                function setMenuItemsState(menuItems, treeNode)
                {
                    for (var i=0; i<menuItems.get_count(); i++)
                    {
                        var menuItem = menuItems.getItem(i);
                        switch(menuItem.get_value())
                        {
                           
                            case "Rename":
   
                             if (treeNode.get_parent() == treeNode.get_treeView())
                                {
                                    menuItem.set_enabled(false);
                                }
                                else
                                {
                                    menuItem.set_enabled(true);
                                    formatMenuItem(menuItem, treeNode, 'Rename');
                                }
                                
                                break;
                            case "Delete":
   
                                if (treeNode.get_parent() == treeNode.get_treeView())
                                {
                                    menuItem.set_enabled(false);
                                }
                                else
                                {
                                    menuItem.set_enabled(true);
                                }
                                break;
                            case "NewFolder":
                                if (treeNode.get_parent() == treeNode.get_treeView())
                                {
                                    menuItem.set_enabled(true);
                                }
                                else
                                {
                                    menuItem.set_enabled(true);
                                }
                                break;
                         case "AddFile":
   
                               
                                break;
                        }
                    }
                }
                
                function formatMenuItem(menuItem, treeNode, formatString)
                {
                    var nodeValue = treeNode.get_value();
                    if (nodeValue && nodeValue.indexOf("_Private_") == 0)
                    {
                        menuItem.set_enabled(false);
                    }
                    else
                    {
                        menuItem.set_enabled(true);
                    }
                    var newText = String.format(formatString, extractTitleWithoutMails(treeNode));
                    menuItem.set_text(newText);
                }
            
             
                function extractTitleWithoutMails(treeNode)
                {
                    return treeNode.get_text().replace(/\s*\([\d]+\)\s*/ig, "");
                }
                
             
                function onClientContextMenuShowing(sender, args)
                {
                    var treeNode = args.get_node();
                    treeNode.set_selected(true);
                    setMenuItemsState(args.get_menu().get_items(), treeNode);
                }

           

        function updateDateKey(value) {
          
            var behavior = $find('dp1');
            if (behavior) {

                behavior.populate(value);  
                    
            }
            }
             function updateDateKey2(value) {
          
            var behavior = $find('dp2');
            if (behavior) {

                behavior.populate(value);  
                    
            }
      }
        function updateDateKeyimage(value) {
          
            var behavior = $find('dpimage');
            if (behavior) {

                behavior.populate(value);  
                    
            }
      }
       function updateDateKeyResizeImages(value) {
    
            var behavior = $find('dpResize');
            if (behavior) {
        
                behavior.populate(value);  
                               
          
            }
            }
            function changechecked(){
                var check = document.getElementById('<%= cbContstraint.ClientID %>');
                var hei = document.getElementById('<%= height.ClientID %>');
                var hei1 = document.getElementById('<%= tbheight.ClientID %>');

                if (check.checked == true){
                    hei1.value='';
                    hei.style.visibility = 'hidden';
                }else{
                    hei.style.visibility = 'visible';
                }
            }
            function manualresize(){
                updateDateKeyManualResizeImages('hello');
                var ma = document.getElementById('<%= manualresize.ClientID %>');
                ma.style.display = 'block';
                var butt = document.getElementById('<%= btnManual.ClientID %>');
                butt.click();
            }
             function updateDateKeyManualResizeImages(value) {
    
            var savepath = document.getElementById('<%= ddSavePath.ClientID %>').value;
            var but = document.getElementById('<%= Button4.ClientID %>').value;
            var width = document.getElementById('<%= tbwidth.ClientID %>').value;
            var height = document.getElementById('<%= tbheight.ClientID %>').value;
            var suffix = document.getElementById('<%=tbThumb.ClientID %>').value;
              
            var prop = savepath+";"+width+";"+height+";"+suffix;
              
            var behavior = $find('dpManual');
            if (behavior) {
         value=document.getElementById('<%=txtFile.ClientID %>').value + ";"+prop;

                behavior.populate(value);  
                               
          
            }
            
            }
            function updateDateKeyAutoResizeImages(value) {
    
            var behavior = $find('dpAutoResize');
            if (behavior) {

            value=document.getElementById('<%=txtFile.ClientID %>').value;
                behavior.populate(value);  
        
            }
            
           
            }
        
      function conditionalPostback(sender, args)
   {
      if(args.EventTarget == "<%# ButtonSubmit.UniqueID %>")
       {
           args.EnableAjax = false;
       } 
   } 
   function showWait()
{
    if ($get('RadUpload1').value.length > 0)
    {
        $get('UpdateProgress1').style.display = 'block';
    }
}

function ShowError() {
    var savepath = document.getElementById('<%= ddSavePath.ClientID %>');
    var but = document.getElementById('<%= Button4.ClientID %>');
    var width = document.getElementById('<%= tbwidth.ClientID %>');
    var suffix = document.getElementById('<%=tbThumb.ClientID %>').value;
    var error = 0;
    if(savepath.selectedIndex==0){
        alert("Please select or create a directory for the resized image");
        error = 1;
    }
    
    if(width.value.length==0){
        alert("Please enter a Width/Height, or a Width and checkmark Auto/Constraint");
        error = 1;
    }
    
    if(suffix.length==0){
        alert("Please enter a suffix for your resized image.  ");
        error = 1;
    }
    if(error == 1)
        return false;
    else
        manualresize();
}

function increaseFileInputWidth(radUpload, args)
{
  //If the Checkboxes in RadUpload are not visible, change the index to 0
  //var cell = args.Row.cells[1];
  var inputs = document.getElementsByTagName('INPUT');
  for (var i=0; i<inputs.length; i++)
  {
    if (inputs[i].type == "file")
    {
      //Set the size property according to your preference
      if(inputs[i].className == "ruFileInput") {
        
        /*inputs[i].style.position = "relative";
        alert(inputs[i].style.position);
        inputs[i].style.position = "absolute";
        inputs[i].style.background = "#ff0000"; */
      }  
        
        
      /*if(BrowserDetect.OS == "Mac" && BrowserDetect.browser == "Firefox")
        inputs[i].size = 35;
      else*/
        inputs[i].size = 40;
    }
  }
}
function checkImageExtension(source, arguments){
    arguments.IsValid = getRadUpload('<%= RadUpload1.ClientID %>').validateExtensions();
}
function checkDocumentExtension(source, arguments){
    arguments.IsValid = getRadUpload('<%= RadUpload2.ClientID %>').validateExtensions();
}
function checkAudioExtension(source, arguments){
    arguments.IsValid = getRadUpload('<%= RadUpload4.ClientID %>').validateExtensions();
}
function checkPodcastExtension(source, arguments){
    arguments.IsValid = getRadUpload('<%= RadUpload60.ClientID %>').validateExtensions();
}
</script>
<style type="text/css">
    .myFileInput { top: 0px; left: 0px; background: #f00; position: absolute; }
</style>

<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
<div class="inner">



  
<div style="position:absolute;top:-10000px;left:-1000px;" > 
    <asp:TextBox ID="txtFilePath" runat="server"></asp:TextBox>
    <asp:TextBox Text="d:\\sites\\marnelltanner_com2010\\" ID="txtroot" runat="server" ></asp:TextBox>
</div>

<strong>Current Directory</strong>
<p>Below is a listing of all of the directories you currently have created. If you right-click on a directory for a list of options. </p>  
   
<div style="clear: both; float: left; position: relative;"> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
 <div style="position:absolute;top:-10000px;left:-1000px;" > <asp:TextBox ID="txtFile" runat="server" ></asp:TextBox></div>
        <cc1:DynamicPopulateExtender ID="dp" BehaviorID="dp1" runat="server" TargetControlID="panel" ClearContentsDuringUpdate="true" ServicePath="/App_Service/div_files.asmx" ServiceMethod="getcontent"></cc1:DynamicPopulateExtender>
        <cc1:DynamicPopulateExtender ID="DynamicPopulateExtender1" BehaviorID="dp2" runat="server" TargetControlID="panel" ClearContentsDuringUpdate="true" ServicePath="/App_Service/div_files.asmx" ServiceMethod="getallinfolder"></cc1:DynamicPopulateExtender>

<br style="clear:both;" />


<div style="clear: both; float: left; position:relative; z-index: 500">
<div class="directory"> 
    <telerik:RadSplitter ID="RadSplitterBrowser" runat="server" ResizeMode="Proportional" BorderSize="0" BorderStyle="None" Skin="Silk" CssClass="structure" ResizeWithBrowserWindow="true" >
    <telerik:RadPane ID="RadPaneTreeView" Skin="Silk" runat="server" Width="100%" Scrolling="Y">
    <telerik:RadTreeView id="RadTreeView1" Skin="Silk" Runat="server" AllowNodeEditing="true" EnableDragAndDrop="False" 
         OnClientNodeClicked="onNodeClicking" 
         OnClientContextMenuItemClicked="onClientContextMenuItemClicked"
         OnContextMenuItemClick="RadTreeView1_ContextMenuItemClick"
         OnClientContextMenuShowing="onClientContextMenuShowing" 
         OnNodeDrop="RadTreeView1_HandleDrop"              
         OnClientNodeDragging="onNodeDragging" OnNodeEdit="RadTreeView1_NodeEdit">
                     <ContextMenus>
                          <telerik:RadTreeViewContextMenu Skin="Silk" ID="RootContextMenu" runat="server">
                            <Items>
                                <telerik:RadMenuItem Value="NewFolder" Text="New Folder" ImageUrl="/admin/images/AddRecord.gif"></telerik:RadMenuItem>
                            </Items>
                        </telerik:RadTreeViewContextMenu>
                        <telerik:RadTreeViewContextMenu Skin="Silk" ID="MainContextMenu" runat="server">
                            <Items>                                       
                                <telerik:RadMenuItem Visible="false" Value="Rename" PostBack="false"  Text="Rename ..."  ImageUrl="/admin/images/rename.gif"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Value="NewFolder" Text="New Folder" ImageUrl="/admin/images/AddRecord.gif"></telerik:RadMenuItem>
                                <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Value="Delete"  Text="Delete" PostBack="false" ImageUrl="/admin/images/delete.gif"></telerik:RadMenuItem>
                                <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Value="AddFile" Text="Add Files" PostBack="false" ImageUrl="/admin/images/ico_addfiles.gif"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Visible="false" Value="Resize" Text="Resize All Images" PostBack="false" ImageUrl="/admin/images/ico_resize.gif"></telerik:RadMenuItem>
                            </Items>
                        </telerik:RadTreeViewContextMenu>
                         <telerik:RadTreeViewContextMenu Skin="Silk" ID="ContextMenuFiles" runat="server">
                            <Items>                                       
                                <telerik:RadMenuItem Visible="false" Value="Rename" PostBack="false" Text="Rename ..."  ImageUrl="/admin/images/rename.gif"></telerik:RadMenuItem>
                                <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                                <telerik:RadMenuItem  Value="Delete" Text="Delete"   PostBack="false" ImageUrl="/admin/images/delete.gif"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Visible="false" Value="ResizeFile" Text="Resize File" PostBack="false" ImageUrl="/admin/images/ico_resize.gif"></telerik:RadMenuItem>
                            </Items>
                        </telerik:RadTreeViewContextMenu>
                    </ContextMenus>
        </telerik:RadTreeView>
    </telerik:RadPane></telerik:RadSplitter>
</div>


<div id="preview" class="preview">
    <div id="panel" runat="server" style="margin-top: 5px"></div>     
</div>  
<div style="position:absolute;top:-10000px;left:-1000px;"><asp:Button ID="PostbackDelete" runat="server" Text="" CausesValidation="true" OnClick="btnDelete_Click"  />  </div>
<cc1:ModalPopupExtender  runat="server" BehaviorID="mdlPopupFolder" ID="modulpopupextender" 
    TargetControlID="popupFolder" PopupControlID="popupFolder" OkControlID="btnOkF" OnOkScript="okClickFolder();" 
    CancelControlID="btnNoF" OnCancelScript="cancelClick();"
   BackgroundCssClass="modalBackground" >
</cc1:ModalPopupExtender>
<div id="popupFolder" runat="server" align="center" class="confirm" style="display:none;">
                Are you sure you want to delete this folder?
                <div class="btn_cont"><asp:LinkButton ID="btnOkF" runat="server" Text="Yes" CssClass="btn yes"/>
                <asp:LinkButton ID="btnNoF" runat="server" Text="No" CssClass="btn no" /></div>
            </div> 


<cc1:ModalPopupExtender  runat="server" BehaviorID="mdlPopup" ID="ModalPopupExtender1" 
    TargetControlID="popup" PopupControlID="popup" OkControlID="btnOk" OnOkScript="okClick();" 
    CancelControlID="btnNo" OnCancelScript="cancelClick();"
   BackgroundCssClass="modalBackground" >
</cc1:ModalPopupExtender>
<div id="popup" runat="server" align="center" class="confirm" style="display:none;">
                Are you sure you want to delete this item?
                <div class="btn_cont"><asp:LinkButton ID="btnOk" runat="server" Text="Yes" CssClass="btn yes"/>
                <asp:LinkButton ID="btnNo" runat="server" Text="No" CssClass="btn no" /></div>
            </div> 
          


<div id="uploadimagepanel" class="upload_panel imageupload"> 
    <strong>Upload Image(s)</strong>
    <p>Use this form to upload images to your CMS. Clicking on <strong>Add</strong> below will allow you allow you to upload more than one image at a time. At any time you can remove a row by clicking <strong>Remove</strong>. When you are finished, click on <strong>Upload Images</strong>.</p>
    <asp:updatepanel runat="server" id="UpdatePanel2" UpdateMode="Always">
    <contenttemplate>
          <telerik:RadUpload MaxFileSize="102400000" EnableAjaxSkinRendering="true" EnableFileInputSkinning="false" OnFileExists="RadUpload1_FileExists"  OnClientAdded="increaseFileInputWidth" Width="485px" AllowedFileExtensions=".png,.jpeg,.jpg,.gif,.JPG,.GIF,.PNG,.JPEG"  Runat="server" id="RadUpload1" Skin="Default" InitialFileInputsCount="2" ControlObjectsVisibility="Default" />
    <asp:LinkButton CssClass="popup_btn popup_submit" id="ButtonSubmit" runat="server" text="Upload Images" OnClick="ButtonSubmit1_Click" />
    <asp:customvalidator id="Customvalidator1" runat="server" display="Dynamic" clientvalidationfunction="checkImageExtension"><span style="font-size: 11px;">ERROR: Please upload an image file with one of the following extensions: .png,.jpeg,.jpg,.gif,.JPG,.GIF,.PNG,.JPEG.</span></asp:customvalidator>
    
    <asp:repeater ID="reportResults" Runat="server" Visible="False">
        <headertemplate>
            Uploaded files:<br />
        </headertemplate>
        <itemtemplate>
            '<%#DataBinder.Eval(Container.DataItem, "FileName")%>'
         
            ('<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>' )<br />
        </itemtemplate>
    </asp:repeater>
 </contenttemplate>
  <triggers>
    <asp:postbacktrigger controlid="ButtonSubmit" />
  </triggers>
</asp:updatepanel>
    
    
</div> 
<div id="uploaddocspanel" class="upload_panel docupload"> 
    <strong>Upload Document(s)</strong><br />
    <p>Use this form to upload documents to your CMS. Clicking on <strong>Add</strong> below will allow you allow you to upload more than one image at a time. At any time you can remove a row by clicking <strong>Remove</strong>. When you are finished, click on <strong>Upload Documents</strong>.</p>
     <asp:updatepanel runat="server" id="UpdatePanel3" UpdateMode="Always"  >
    <contenttemplate>
    <telerik:RadUpload MaxFileSize="102400000" EnableFileInputSkinning="false" OnFileExists="RadUpload2_FileExists" OnClientAdded="increaseFileInputWidth" AllowedFileExtensions=".doc,.pdf,.xls,.zip,.html" Runat="server" id="RadUpload2" Skin="Default" InitialFileInputsCount="2" ControlObjectsVisibility="Default" />
    <asp:LinkButton id="Button2" runat="server" text="Upload Documents" OnClick="ButtonSubmit2_Click" CssClass="popup_btn popup_submit"/>
    <asp:customvalidator id="Customvalidator2" runat="server" display="Dynamic" clientvalidationfunction="checkDocumentExtension"><span style="font-size: 11px;">ERROR: Please upload a document file with one of the following extensions: .doc,.pdf,.xls,.zip,.html.</span></asp:customvalidator>
    <asp:repeater ID="Repeater2" Runat="server" Visible="False">
        <headertemplate>
            Uploaded files:<br />
        </headertemplate>
        <itemtemplate>
            '<%#DataBinder.Eval(Container.DataItem, "FileName")%>'
            ('<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>' )<br />
        </itemtemplate>
    </asp:repeater>
    </contenttemplate>
  <triggers>
    <asp:postbacktrigger controlid="Button2" />
  </triggers>
</asp:updatepanel>
</div> 

<div id="uploadaudiopanel" class="upload_panel movieupload"> 
    <strong>Upload Audio</strong><br />
    <p>Use this form to upload an audio file to your CMS. When you are finished, click on <strong>Upload Audio</strong>.</p>
     <asp:updatepanel runat="server" id="UpdatePanel7" UpdateMode="Always"  >
    <contenttemplate>
     <telerik:RadUpload MaxFileSize="102400000" EnableFileInputSkinning="false" OnFileExists="RadUpload4_FileExists" AllowedFileExtensions=".mp3" OnClientAdded="increaseFileInputWidth"  Runat="server" id="RadUpload4" Skin="Default" InitialFileInputsCount="1" ControlObjectsVisibility="Default" />
     <asp:LinkButton id="Button12" runat="server" text="Upload Audio" CssClass="popup_btn popup_submit" OnClick="ButtonSubmit4_Click" />
    <asp:customvalidator id="Customvalidator4" runat="server" display="Dynamic" clientvalidationfunction="checkAudioExtension"><span style="font-size: 11px;">ERROR: Please upload an audio file with the following extension: .mp3.</span></asp:customvalidator>
    <asp:repeater ID="Repeater3" Runat="server" Visible="False">
        <headertemplate>
            Uploaded files:<br />
        </headertemplate>
        <itemtemplate>
            '<%#DataBinder.Eval(Container.DataItem, "FileName")%>'
         
            ('<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>' )<br />
        </itemtemplate>
    </asp:repeater>
  
 </contenttemplate>
  <triggers>
    <asp:postbacktrigger controlid="Button12" />
  </triggers>
</asp:updatepanel>

</div> 

<div id="uploadpodcastpanel" class="upload_panel movieupload"> 
    <strong>Upload Podcast</strong><br />
    <p>Use this form to upload a podcast file to your CMS. When you are finished, click on <strong>Upload Podcast</strong>.</p>
     <asp:updatepanel runat="server" id="UpdatePanel60" UpdateMode="Always"  >
    <contenttemplate>
     <telerik:RadUpload MaxFileSize="102400000" OnFileExists="RadUpload60_FileExists" AllowedFileExtensions=".zip" OnClientAdded="increaseFileInputWidth"  Runat="server" id="RadUpload60" Skin="Default" InitialFileInputsCount="1" ControlObjectsVisibility="Default" />
     <asp:LinkButton id="LinkButton1" runat="server" text="Upload Podcast" CssClass="popup_btn popup_submit" OnClick="ButtonSubmit60_Click" />
    <asp:customvalidator id="Customvalidator3" runat="server" display="Dynamic" clientvalidationfunction="checkPodcastExtension"><span style="font-size: 11px;">ERROR: Please upload a podcast file with the following extension: .zip.</span></asp:customvalidator>
    <asp:repeater ID="Repeater1" Runat="server" Visible="False">
        <headertemplate>
            Uploaded files:<br />
        </headertemplate>
        <itemtemplate>
            '<%#DataBinder.Eval(Container.DataItem, "FileName")%>'
         
            ('<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>' )<br />
        </itemtemplate>
    </asp:repeater>
  
 </contenttemplate>
  <triggers>
    <asp:postbacktrigger controlid="LinkButton1" />
  </triggers>
</asp:updatepanel>

</div> 
 

</ContentTemplate>
</asp:UpdatePanel>
</div> 
 
<script type="text/javascript">

 </script> 

 <div id="manualresize" runat="server" class="upload_panel manualresize"> 
    <strong>Resize Image</strong><br />
    <div id="manual" runat="server"><p>Please choose a Width, Height or Auto Constraint and a Prefix for your Image.<br/><br/>
    Please choose Folder where you would like to save this file to:</p>
   <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always" >         
        <ContentTemplate>
         <cc1:DynamicPopulateExtender ID="dpManual" BehaviorID="dpManual" runat="server" TargetControlID="image" ClearContentsDuringUpdate="true" ServicePath="/App_Service/ManualResize.asmx" ServiceMethod="resize"></cc1:DynamicPopulateExtender>
         <cc1:DynamicPopulateExtender ID="dpimage" BehaviorID="dpimage" runat="server" TargetControlID="image" ClearContentsDuringUpdate="true" ServicePath="/App_Service/div_files.asmx" ServiceMethod="getimageforpop"></cc1:DynamicPopulateExtender>
            <table cellpadding="0" cellspacing="0">
                <tr><td colspan="2" style="padding-bottom: 10px">
                    <asp:DropDownList ID="ddSavePath" runat="server"  Width="350px"></asp:DropDownList></td>
                </tr>
                <tr><td colspan="2" style="padding-bottom: 5px">
                    <asp:Label ID="Label3"  runat="server" Text=""></asp:Label></td>
                </tr>
                <tr><td colspan="2" style="padding-bottom: 10px">
                    <asp:Label ID="Label4"  runat="server" style="margin-right:24px" Text="Image Preview:"></asp:Label>
                    <div runat="server" id="image"></div></td>
                </tr>
                <tr>
                    <td style="padding-bottom: 3px">
                        <span style="float: left; width: 135px;"><asp:Label ToolTip="Thumbnail Width" ID="Label1" runat="server" Text="Width in Pixels:"></asp:Label></span>   
                        <asp:TextBox CssClass="tdwidth" Width="50px" ToolTip="Thumbnail Width" ID="tbwidth" runat="server"></asp:TextBox>px
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tbwidth"  FilterType="Numbers" /></td>
                    <td align="left"><input type="checkbox" onclick="changechecked();" value="" id="cbContstraint" runat="server"  />Auto Constraint</td>
                </tr>
                <tr><td colspan="2" runat="server" id="height" style="padding-bottom: 3px">
                    <span style="float: left; width: 135px;"><asp:Label ID="Label2" ToolTip="Thumbnail Height" runat="server" Text="Height in Pixels:" ></asp:Label>  </span>
                    <asp:TextBox ToolTip="Thumbnail Height" CssClass="td" Width="50px" ID="tbheight" runat="server"></asp:TextBox>px
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="tbheight"  FilterType="Numbers" /></td>
                </tr>
                <tr><td colspan="2"  style="padding-bottom: 3px">
                    <span style="float: left; width: 135px;"><asp:Label ToolTip="Additional Unique Suffix for your Thumbnail." ID="Label5" runat="server" Text="Suffix for Thumbnail:"></asp:Label>   </span>
                    <asp:TextBox ToolTip="Additional Unique Suffix for your Thumbnail." Width="150px" ID="tbThumb" runat="server"></asp:TextBox></td>
                </tr>
            </table>  
     <asp:LinkButton ID="Button4" Text="Resize Image"  runat="server"  CssClass="popup_btn popup_submit"  OnClientClick="ShowError();" />
    <asp:Button ID="btnManual" runat="server" Text=""  OnClick="btnSizeMa_Click" CssClass="hdnBtn"/>

</ContentTemplate>
</asp:UpdatePanel>
  
</div> 
 
 
  </div>
 <div id="autoresize" runat="server" class="upload_panel autoresize">
    <strong>Automatically Resize Images</strong><br />
    <p>This method will automatically resize all images found in this directory. It will not, however, resize images found inside of sub-directories.
    </p>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server"  UpdateMode="Always" >         
        <ContentTemplate>
        <cc1:DynamicPopulateExtender ID="dpResize" BehaviorID="dpResize" runat="server"
      TargetControlID="Panel2"
      ClearContentsDuringUpdate="true"
            ServicePath="/App_Service/getImagesForResize.asmx"
            ServiceMethod="showfiles"></cc1:DynamicPopulateExtender>
    <cc1:DynamicPopulateExtender ID="dpAutoResize" BehaviorID="dpAutoResize" runat="server"
      TargetControlID="Panel2"
      ClearContentsDuringUpdate="true"
            ServicePath="/App_Service/Autoresize.asmx"
            ServiceMethod="getimages"></cc1:DynamicPopulateExtender>
        <table cellpadding="0" cellspacing="0">
          <tr><td style="padding-bottom: 10px;visibility:hidden;"> <asp:DropDownList ID="ddCat" runat="server"   Width="350px" ></asp:DropDownList></td></tr>
         <tr><td style="padding-bottom: 3px"><asp:Panel ID="Panel2" runat="server" ScrollBars="Auto"  Height="150px" Width="348px" HorizontalAlign="Justify" ></asp:Panel></td></tr>
         <tr><td style="padding-bottom: 3px;padding-top: 10px"><asp:Label ID="errorlabelauto"  runat="server" /></td></tr> 
        </table><br/>
 
<asp:LinkButton ID="Button5" runat="server" Text="Resize Images" CssClass="popup_btn popup_submit" OnClientClick="AutoResizeImages();"   />
<asp:Button ID="Postbtn" runat="server" Text="" OnClick="btnSize_Click" CssClass="hdnBtn" />
<asp:LinkButton ID="Button6" runat="server" Text="Delete Source Images (recommended)"  CssClass="popup_btn popup_cancel" OnClick="Button2_Click" /> 
                </ContentTemplate>
    </asp:UpdatePanel>            
</div>
</div>


<asp:updateprogress AssociatedUpdatePanelID="UpdatePanel1" id="updateProgress" runat="server">

    <progresstemplate>
        <div id="progressBackgroundFilter"></div>
        <div id="processMessage"> Loading...<br /><br /><img alt="Loading" src="/admin/images/loading.gif" /></div>
    </progresstemplate>

</asp:updateprogress>  




  
