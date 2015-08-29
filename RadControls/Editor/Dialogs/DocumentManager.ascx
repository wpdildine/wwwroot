<%@ Control Language="c#" Inherits="Telerik.WebControls.EditorDialogControls.DocumentManager" AutoEventWireUp="false" CodeBehind="DocumentManager.ascx.cs" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="telerik" NameSpace="Telerik.WebControls.EditorControls" Assembly="RadEditor.Net2" %>
<%@ Register TagPrefix="telerik" TagName="TabControl" Src="../Controls/TabControl.ascx" %>
<%@ Register TagPrefix="telerik" TagName="DocumentPreviewer" Src="../Controls/DocumentPreviewer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="FileBrowser" Src="../Controls/FileBrowser.ascx" %>
<%@ Register TagPrefix="telerik" TagName="FileUploader" Src="../Controls/FileUploader.ascx" %>
<asp:literal ID="messageHolder" Runat="server"></asp:literal>
<asp:panel id="actionControlsHolder" Runat="server">
<table width="800px" id="MainTable" class="MainTable" cellpadding="0" cellspacing="0">
	<tr>
		<th align="left" valign="bottom">
			<telerik:tabcontrol id="TabHolder" runat="server" ResizeControlId="MainTable">
				<telerik:tab elementid="DocumentViewer" selected="True" text="<script>localization.showText('Tab1HeaderText');</script>" image="Dialogs/TabIcons/DocumentTab1.gif"/>
				<telerik:tab elementid="DocumentUploader" onclientclick="ConfigureUploadPanel()" text="<script>localization.showText('Tab2HeaderText');</script>" image="Dialogs/TabIcons/DocumentTab2.gif" enabled="false"/>
			</telerik:tabcontrol>
		</th>
	</tr>
	<tr>
		<td class="MainTableContentCell">
			<div class="ErrorMessage" id="divErrorMessage" runat="server" visible="false"></div>
			<div id="DocumentViewer" style="OVERFLOW:hidden;HEIGHT:594px">
				<table cellspacing="0" cellpadding="0" border="0">
					<tr>
						<td colspan="3" class="Label" nowrap>
							&nbsp;<script>localization.showText('DocumentFile');</script>
							<input type="text" style="width:370px" class="RadETextBox" id="FolderPathBox">
						</td>
					
					</tr>
					<tr>
						<td valign="top">
							<telerik:filebrowser id="fileBrowser" runat="server"></telerik:filebrowser>
						</td>
						<td class="VerticalSeparator" nowrap></td>
						<td valign="top">
							<telerik:documentpreviewer id="previewer" runat="server"></telerik:documentpreviewer>
						</td>
					</tr>
				</table>
			</div>
			<div id="DocumentUploader" style="OVERFLOW:hidden;HEIGHT:300px">
				<telerik:FileUploader id="fileUploader" runat="server"/>
			</div>
		</td>
	</tr>
</table>
<asp:literal id="javascriptInitialize" Runat="server"></asp:literal>
<script language="javascript">
/*----------------Common functions------------------------*/
function ConfigureUploadPanel()
{
	if (messageHolderRowID)
	{
		if (isErrorVisible)
		{
			isErrorVisible = false;
		}
		else
		{
			var tr = document.getElementById(messageHolderRowID);
			if (tr && tr.style.display != "none") tr.style.display = "none";
		}
	}
	if (fileBrowser.CurrentItem)
	{
		document.getElementById('CurrentDirectoryBox').value = fileBrowser.CurrentItem.GetPath();
	}
}

function ShowPath(path)
{
	document.getElementById("FolderPathBox").value = path;
}

/* OK button clicked */
function OkClicked()
{
	if (fileBrowser.SelectedItem.Type == "D")
	{
		alert(localization["NoDocumentSelectedToInsert"]);
		return;
	}

	var fileNames = fileBrowser.SelectedItem.GetUrl().split('/');
	fileName = fileNames[fileNames.length -1];
	var linkText = '';
	if (dialogArgs.showText)
	{
		linkText = (dialogArgs.text == "")?fileName:dialogArgs.text;
	}
	
	var returnObject = {
		realLinkObject: dialogArgs.realLinkObject
		, text	 : linkText
		, name	 : ""
		, href	 : fileBrowser.SelectedItem.GetUrl()
		, title	 : previewer.GetAltText()
		, target : document.getElementById("linkTarget").value
	};
	CloseDlg(returnObject);
}

fileBrowser.OnFolderChange = function(browserItem)
{
	ShowPath(browserItem.GetPath());
	previewer.Clear();
	TabHolder.SetTabEnabled(1, browserItem.Permissions & fileBrowser.UploadPermission);
};

fileBrowser.OnClientClick = function(browserItem)
{
	if (browserItem.Type != "D")
	{
		previewer.LoadObjectFromPath(browserItem.GetUrl());
		if (browserItem.Attributes && browserItem.Attributes[0])
		{
			previewer.SetAltText(browserItem.Attributes[0]);
		}
	}
	else previewer.LoadObjectFromPath(null);
	ShowPath(browserItem.GetPath());
};

function OnLoad()
{	
	dialogArgs = GetDialogArguments();
	if (dialogArgs && dialogArgs.href)
	{
		//ERJO:TODO - Add the prenavigation to the flash object!
		//fileBrowser.SelectFileByFullName(dialogArgs.href);
	}
	TabHolder.SetTabEnabled(1, fileBrowser.CurrentItem.Permissions & fileBrowser.UploadPermission);
	TabHolder.SelectCurrentTab();
	var itemToShow = fileBrowser.SelectedItem != null?fileBrowser.SelectedItem:fileBrowser.CurrentItem;
	ShowPath(itemToShow.GetPath());

}

AttachEvent(window, "load", OnLoad);
</script>
</asp:panel>