<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlImageManager.ascx.cs" Inherits="admin_controls_images_ctlImageManager" %>

<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="radU" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
 <%@ Register Assembly="RadWindow.Net2" Namespace="Telerik.WebControls" TagPrefix="radW" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    <script type="text/javascript" language="javascript">
function ShowResize(id)
            {
                window.radopen("<%= epicCMSLib.Navigation.SiteRoot %>admin/controls/images/resizing.aspx?id=" + id, "EditReImage");
                return false;
            }
            function ShowCrop()
            {
                window.radopen("<%= epicCMSLib.Navigation.SiteRoot %>admin/controls/images/cropping.aspx", "CropImage");
                return false;
            }
function loadpage()
{
window.location.href = "<%=epicCMSLib.Navigation.SiteRoot %>admin/default.aspx?pg=image";
}
    </script>
    

    <p>Would you like to <a href="#" id="manual" runat="server" onclick="return ShowResize(1);">Manual Resize</a> or 
    <a href="#" onclick="return ShowResize(2);" id="auto" runat="server">Auto Resize</a> or 
    <a href="#" id="crop" runat="server" onclick="return ShowCrop();">Crop</a>?</p>


    <div style="position:absolute;top:-10000px;left:-1000px;" > 
             <radE:RadEditor ID="RadEditor1" runat="server" UseEmbeddedScripts="false"                  
                AllowThumbGeneration="false" ImagesFilters="*.gif,*.jpg,*.jpeg,*.bmp,*.tif,*.png" MaxImageSize="204800000" StripAbsoluteImagesPaths="False" >
           </radE:RadEditor>
    </div>
      
            <script language="javascript" type="text/javascript">
            function ShowImageDialog() 
            { 
                //get a reference to the editor
                var editor = <%= RadEditor1.ClientID %>; 
                editor.Fire("ImageManager", callBackFn); 
           
            } 
            function callBackFn(result) 
            { 
                //Do something with the returned link     
                if (result) 
                { 
                    var imageArea = document.getElementById("ImageArea"); 
                    var img = document.createElement ("IMG"); 
                    img.src = result.imagePath; 
                    imageArea.appendChild (img); 
                }; 
            } 
            function ShowDocumentDialog() 
				{ 
					var editor = <%= RadEditor1.ClientID %>; 
					editor.Fire("DocumentManager", callBackFn); 
					
					function callBackFn(retValue) 
					{ 									
						if (retValue.href) 
						{ 
							//Do something with the returned link												
							var textArea = document.getElementById("ImageArea"); 
							var aLink = document.createElement("A"); 
							aLink.href  = retValue.href; 
							aLink.innerHTML = retValue.href;
							textArea.appendChild (aLink); 						
						}; 
					} 
				} 

            </script>
     
 <radW:RadWindowManager ID="RadWindowManager1" runat="server" Left="" NavigateUrl="" SkinsPath="~/RadControls/Window/Skins/"  OnClientClose="loadpage();" Skin="Default" Title="" Top="">
             <Windows>
              <radW:RadWindow  ID="EditReImage" Height="550px" Width="450px" runat="server" Left="" SkinsPath="~/RadControls/Window/Skins/"  Skin="Default"
                     Title="Resizing Images"  ReloadOnShow="True" Modal="true" Top="" ShowContentDuringLoad="true"  />
           
              <radW:RadWindow  ID="CropImage" Height="550px" Width="750px" runat="server" Left="" SkinsPath="~/RadControls/Window/Skins/"  Skin="Default"
                     Title="Crop Image"  ReloadOnShow="True" Modal="true" Top="" ShowContentDuringLoad="true"  />
               
                 </Windows>
</radW:RadWindowManager>
      
