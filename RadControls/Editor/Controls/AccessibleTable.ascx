<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AccessibleTable.ascx.cs" Inherits="Telerik.WebControls.EditorControls.AccessibleTable" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="telerik" TagName="AlignmentSelector" Src="./AlignmentSelector.ascx" %>
<table id="TABLE_PROPS_<%=this.ClientID%>" id=Table1>
	<tr>
		<td>
			<table width="100%" id="TABLE_PROPS_HEADING_<%=this.ClientID%>">
				<tr>
					<td class="Label" nowrap><script>localization.showText("Sec508HeadingRows");</script></td>
					<td nowrap><input  class="RadETextBox" type="text" id="TXT_HEAD_ROWS_<%=this.ClientID%>">&nbsp;<span id="MAX_HEAD_ROWS_<%=this.ClientID%>"  class="Label"></span></td>
				</tr>
				<tr>
					<td class="Label" nowrap><script>localization.showText("Sec508HeadingCols");</script></td>
					<td nowrap><input class="RadETextBox" type="text" id="TXT_HEAD_COLS_<%=this.ClientID%>">&nbsp;<span id="MAX_HEAD_COLS_<%=this.ClientID%>"  class="Label"></span></td>
				</tr>
			</table>
		</td>		
	</tr>	
	<tr>
		<td class="Label">
			<script>localization.showText("Sec508CaptionAlign");</script>
			<telerik:alignmentselector id="AlignmentSelector1" runat="server" Mode="CAPTION"></telerik:alignmentselector>
		</td>
	</tr>	

	<tr>
		<td class="Label"><script>localization.showText("Sec508Caption");</script></td>
	</tr>
	<tr>
		<td>
			<textarea  class="TextArea" id="TXT_CAPTION_<%=this.ClientID%>" style="WIDTH:100%" rows="3"></textarea>
		</td>
	</tr>
		<tr>
		<td class="Label"><script>localization.showText("Sec508Summary");</script></td>
	</tr>
	<tr>
		<td>
			<textarea  class="TextArea" id="TXT_SUMMARY<%=this.ClientID%>" style="WIDTH:100%" rows="3"></textarea>
		</td>
	</tr>
	<tr>
		<td class="Label"><input type="checkbox" id="SET_CELL_ID_<%=this.ClientID%>"><script>localization.showText("Sec508AssocCellHeaders");</script></td>
	</tr>	
</table>

<script>
	var <%=this.ClientID%> = new AccessibleTable('<%=this.ClientID%>', <%=AlignmentSelector1.ClientID%>);
</script>