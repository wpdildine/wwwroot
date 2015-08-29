<%@ Control Language="C#" AutoEventWireup="true" CodeFile="filebrowser.ascx.cs" Inherits="admin_controls_filebrowser" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="RadSplitter.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="RadTreeView.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="RadGrid.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<style type="text/css">
body
{
   
}
  
* {
 outline: 0;
}
div.wrapper {
    width: 100%;
    float: left;
    margin-bottom:10px;
    padding: 0px 0px 0px 0px;
    background: transparent url(Images/div_topFrame.jpg) no-repeat 0 0;
}

div.wrapper2 {
    margin: 0;
    padding: 0;
    float: left;
    width: 100%;
}

div.wrapper3 {
    padding: 0 0px;
    float: left;
    background: transparent url('Images/div_innerFrame.gif') repeat-y 0 0;
}

div.wrapper div.leftPaneHeader {
    /* background: url('Images/leftPaneHeader.gif') repeat-x; */
    background-color: #fcfcfc;
    border-top: solid 1px black;
    border-bottom: solid 1px #9eb6ce;
    height: 18px;
    color: #1f3695;
    font-size: 12px;
    padding: 4px 0 0 5px;
}

div.innerWrapper {
    float: left;
}

div.footer {
    padding: 0 0 0 30px;
    background: transparent url('Images/div_bottomFrame.jpg') no-repeat 0 0;
    height: 79px;
    /* width: 713px; */
    overflow: hidden;
    clear: both;
}
h3.browser {
    margin: 0;
    padding: 0 0 0 50px;
    height: 23px;
    font-size: 12px;
    font-weight: normal;
}

.RadSplitter_Vista .resizeBar, .RadSplitter_Vista .resizeBarOver, .RadSplitter_Vista .resizeBarInactive, .RadSplitter_Vista .slideContainerResize, .RadSplitter_Vista .slideContainerResizeOver {
    width: 2px !important;
}
.RadSplitter_Vista .resizeBar, .RadSplitter_Vista .resizeBarOver, .RadSplitter_Vista .resizeBarInactive {
    padding: 0 !important;
}
.RadGrid_Vista {
    background-color: #fff !important;
    border: 0 !important;
}
</style>
 <script type="text/javascript">
    function conditionalPostback(sender, args)
   {
        if(args.EventTarget == "<%= ButtonSubmit.UniqueID %>")
       {
           args.EnableAjax = false;
       }
   } 
   
   function show()
   {
   alert('here');
   }
   </script>
        <div id="scriptpanel" runat="server"></div>

    

 <div class="wrapper">
            <div class="wrapper2"><rad:RadAjaxPanel ClientEvents-OnRequestStart="show();"  ID="RadAjaxPanel1" runat="server"  LoadingPanelID="AjaxLoadingPanel1">
            
                  <div class="wrapper3">
                  
                    
                    <div class="innerWrapper">
                        
                        <rad:RadSplitter ID="RadSplitterBrowser" runat="server" ResizeMode="Proportional"
                            Height="610px"
                            Width="708px"
                            EnableClientDebug="False"
                            BorderSize="0"
                            BorderStyle="None"
                            Skin="Default2006" ResizeWithBrowserWindow="true"
                            >
                            <rad:RadPane ID="RadPaneTreeView" runat="server" Height="610px" Width="300px" Scrolling="Y">
                                <div class="leftPaneHeader">Folders</div>
                                
                                <rad:RadTreeView ID="RadTreeView1" runat="server" CausesValidation="True" 
                                    AutoPostBack="true"                                
                                    Width="100%"
                                    Height="577px"
                                    BeforeClientClick="BeforeClick"
                                    BeforeClientContextMenu="ShowRadMenu"
                                    AllowNodeEditing="True"
                                    OnNodeEdit="RadTreeView1_NodeEdit"
                                    AccessKey="T"
                                    ExpandDelay="1"
                                    DragAndDrop="True" 
                 
                                    OnNodeDrop="RadTreeView1_NodeDrop"
                                    OnNodeExpand="RadTreeView1_NodeExpand" SkinID="Default2006" 
                                    >
                                </rad:RadTreeView>
                            </rad:RadPane>
                            
                            <rad:RadSplitBar ID="RadSplitBar1" runat="server" Width="1px" />

                            <rad:RadPane ID="RadPaneGrid" runat="server" Width="480px" SkinID="Default2006">
                                <fieldset style="FLOAT:right;WIDTH:455px;HEIGHT:590px"><legend><rad:AjaxLoadingPanel ID="AjaxLoadingPanel1" runat="server" Height="600px" Width="475px" IsSticky="false"  BackColor="White" >
                        <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/RadControls/Ajax/Skins/Default/loading5.gif" CssClass="UpdateImage"/>
                    </rad:AjaxLoadingPanel></legend>
                            <legend>
                    Preview</legend>
                            <table style="WIDTH:100%;HEIGHT:100%">
                             
                                <tr>
                                    <td id="previewPane" align="center" valign="middle">Click an image to see its
                                        preview...<img id="image"  alt="" /> 
                                        </td>
                                </tr>
                            </table>
                        </fieldset>       
                            </rad:RadPane>
                        </rad:RadSplitter>
                    </div>
                    
                    <rad:RadMenu ID="treeContextMenu" runat="server" Skin="Default"
                        IsContext="true"
                              ContextMenuElementID="RadTreeView1"
                        Style="left: 2px"
                        OnItemClick="RadMenu1_ItemClick"
                        OnClientItemClicked="MenuClick"
                        >
                        <Items>
                            <rad:RadMenuItem Text="New Item" ImageUrl="~/RadControls/Grid/Skins/Default2006/AddRecord.gif" />
                            <rad:RadMenuItem Text="Delete Item" ImageUrl="~/RadControls/Grid/Skins/Default2006/Delete.gif" />
                            <rad:RadMenuItem Text="Rename Item" ImageUrl="~/RadControls/Grid/Skins/Default2006/rename.gif" />
                           
                        </Items>
                    </rad:RadMenu>
                     
                   <rad:RadMenu ID="treeContextMenu2" runat="server" Skin="Default"
                        IsContext="true"
                              ContextMenuElementID="RadTreeView1"
                        Style="left: 2px"
                        OnItemClick="RadMenu1_ItemClick"
                        OnClientItemClicked="MenuClick"
                        >
                        <Items>
                            <rad:RadMenuItem Text="Delete Item" ImageUrl="~/RadControls/Grid/Skins/Default2006/Delete.gif" />
                            <rad:RadMenuItem Text="Rename Item" ImageUrl="~/RadControls/Grid/Skins/Default2006/rename.gif" />
                           
                        </Items>
                    </rad:RadMenu>
                     </div>
              
           
           </rad:RadAjaxPanel>

        <br />

  <rad:radajaxpanel runat="server" id="RadAjaxPanel2" clientevents-onrequeststart="conditionalPostback">
       <rad:radupload runat="server" id="RadUpload1" Skin="Default2006" InitialFileInputsCount="2" ControlObjectsVisibility="AddButton" />
       <asp:button id="ButtonSubmit" runat="server" text="Upload" OnClick="ButtonSubmit_Click" /></rad:radajaxpanel>
                      <asp:repeater ID="reportResults" Runat="server" Visible="False">
                            <headertemplate>
                                Uploaded files:<br />
                            </headertemplate>
                            <itemtemplate>
                                '<%#DataBinder.Eval(Container.DataItem, "FileName")%>'
                             
                                ('<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>' )<br />
                            </itemtemplate>
                        </asp:repeater>       </div> </div>
<rad:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" > 
        <AjaxSettings> 
            <rad:AjaxSetting AjaxControlID="ButtonSubmit"> 
                <UpdatedControls> 
                    <rad:AjaxUpdatedControl ControlID="RadTreeView1" LoadingPanelID="AjaxLoadingPanel1" /> 
                </UpdatedControls> 
            </rad:AjaxSetting> 
            
             <rad:AjaxSetting AjaxControlID="treeContextMenu"> 
                <UpdatedControls> 
                    <rad:AjaxUpdatedControl ControlID="RadTreeView1" LoadingPanelID="AjaxLoadingPanel1" /> 
                </UpdatedControls> 
            </rad:AjaxSetting> 
        </AjaxSettings> 
     </rad:RadAjaxManager> 
 
 <script type="text/javascript">
 function InitiateAsyncRequest(argument) 
{ 
    var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>"); 
    ajaxManager.ajaxRequest(argument); 
} 
  function Scale(img, width, height)
        {
            var hRatio = img.height/height;
            var wRatio = img.width/width;

            if (img.width > width && img.height > height)
            {
                var ratio = (hRatio>=wRatio ? hRatio:wRatio);
                img.width = (img.width /ratio);
                img.height = (img.height /ratio);
            }
            else
            {
                if (img.width > width)
                {
                    img.width = (img.width /wRatio);
                    img.height = (img.height /wRatio);
                }
                else
                {
                    if (img.height > height)
                    {
                        img.width = (img.width /hRatio);
                        img.height = (img.height /hRatio);
                    }
                }
            }
        }
        function BeforeClick(source, dest, events)
        {
            var object = document.getElementById('image');
            
           
            if (source.Category == "Folder")
            {
                return;
            }
            else
            {
            object.src = source.Value;
            var previewPane = document.getElementById('previewPane');
     
            previewPane.innerHTML = "";
            }
            
            
                   
              
        }
      
function ShowRadMenu(node, e)
        {    
            var menu = null;
            if (node.Category == "Folder")
            {
                menu = window["<%= treeContextMenu.ClientID %>"];
            }
            else
            {
             menu = window["<%= treeContextMenu2.ClientID %>"];
            }
           
            if (menu)
            {
                menu.Show(e);
                e.cancelBubble = true;
                if (e.stopPropagation)
                {
     e.stopPropagation();
                }
                e.returnValue = false;
                if (e.preventDefault)
                {
                    e.preventDefault();
                }
            }
        }
  
     function ContextMenuClick(node, itemText)
        {
            if (itemText == "Rename Item")
            {
                node.StartEdit();
            }
     return true;
        }
        
       function MenuClick(sender, args)
        {
            if (args.Item.Text == "Rename Item")
            {
                var treeview = <%= RadTreeView1.ClientID %>;
                if (treeview.SelectedNode != null)
                {
                    treeview.SelectedNode.StartEdit();
                }
            }
        }
        
      
      
      function GetSelectedNodesOfATree()
{

   var tree = <%= RadTreeView1.ClientID %>;
   var selectedNodes = tree.GetSelectedNodes();
   var i;
   for(i=0; i<= selectedNodes.length; i++)
   {
       alert(selectedNodes[i].Text);
   }
}

 function MenuClose()
        {
            var menu = <%= treeContextMenu.ClientID %>;
             var menu = <%= treeContextMenu2.ClientID %>;
            menu.Close();
        }
        </script>