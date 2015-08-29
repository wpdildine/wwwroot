<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TableDesignControl.ascx.cs" Inherits="Telerik.WebControls.EditorControls.TableDesignControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="100%" cellpadding="0" cellspacing="0">
	<tr>
		<td valign="bottom" class="SizeButtonHolder">
			<div nowrap style="DISPLAY:inline;WIDTH:1px" class="Label"><script language="javascript">localization.showText('Columns')</script></div>
			&nbsp;
			<img id="<%=this.ClientID%>_delCol" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.DeleteLastColumn(this);" src="<%=this.SkinPath%>Dialogs/minus1.gif" border="0">&nbsp;
			<img id="<%=this.ClientID%>_addCol" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.AddNewColumn(this);" src="<%=this.SkinPath%>Dialogs/plus1.gif" border="0">&nbsp;&nbsp;&nbsp;
			<div nowrap style="DISPLAY:inline;WIDTH:1px" class="Label"><script language="javascript">localization.showText('ColumnSpan')</script></div>
			&nbsp;
			<img id="<%=this.ClientID%>_delColSpan" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.DecreaseColSpan(this);" src="<%=this.SkinPath%>Dialogs/minus1.gif" border="0" class="Disabled">&nbsp;
			<img id="<%=this.ClientID%>_addColSpan" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.IncreaseColSpan(this);" src="<%=this.SkinPath%>Dialogs/plus1.gif" border="0" class="Disabled">
		</td>
		<td></td>
	</tr>
	<tr>
		<td height="5"></td>
	</tr>
	<tr>
		<td valign="top" class="TableDialogTableHolder">
			<span id="<%=this.ClientID%>_PreviewTableHolder"></span>
		</td>
		<td width="10" style="padding-left:2px;" align="right" valign="top">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td class="label">
					<script language="javascript">localization.showSpacedText('Rows')</script>
					
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td class="SizeButtonHolder"><img id="<%=this.ClientID%>_delRow" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.DeleteLastRow(this);" src="<%=this.SkinPath%>Dialogs/minus1.gif" border="0"></td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr>
					<td class="SizeButtonHolder"><img id="<%=this.ClientID%>_addRow" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.AddNewRow();" src="<%=this.SkinPath%>Dialogs/plus1.gif" border="0"></td>
				</tr>
				<tr>
					<td height="15"></td>
				</tr>
				<tr>
					<td class="Label">
						<script language="javascript">localization.showSpacedText('RowSpan')</script>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td class="SizeButtonHolder"><img id="<%=this.ClientID%>_delRowSpan" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.DecreaseRowSpan(this);" src="<%=this.SkinPath%>Dialogs/minus1.gif" border="0" class="Disabled"></td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr>
					<td class="SizeButtonHolder"><img id="<%=this.ClientID%>_addRowSpan" onmouseover="<%=this.ClientID%>.OnButtonOver(this);" onmouseout="<%=this.ClientID%>.OnButtonOut(this);" onclick="<%=this.ClientID%>.IncreaseRowSpan(this);" src="<%=this.SkinPath%>Dialogs/plus1.gif" border="0" class="Disabled"></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<script language="javascript">
	<%=this.ClientID%> = new TableDesignControl('<%=this.ClientID%>');
</script>