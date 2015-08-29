<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlUserAdmin.ascx.cs" Inherits="admin_controls_users_ctlUserAdmin" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
 <%@ Register Assembly="RadWindow.Net2" Namespace="Telerik.WebControls" TagPrefix="radW" %>
 <script type="text/javascript">

function stopRKey(evt) {
  var evt = (evt) ? evt : ((event) ? event : null);
  var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
  if (evt.keyCode == 13)   {return false;}
}

document.onkeypress = stopRKey;

</script>
<h2>User Administration</h2>
<input id="txtLangId" type="hidden" runat="server" /> 
<a href="#" onclick="return ShowInsertFormUser();" class="top_link"><asp:Image ID="Image1" runat="server" ImageUrl="~/RadControls/Grid/Skins/Default2006/AddRecord.gif" AlternateText="Add Record" /> Add New CMS User</a>
<div style="clear: both;"></div>

<asp:UpdatePanel runat="server"  id="UpdatePanel1" UpdateMode="Always">
<ContentTemplate>
<input id="textb" runat="server" value="0" type="hidden" /> 
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server"  id="aspUpdPanTaskList" UpdateMode="Always" >
<ContentTemplate>

   <asp:GridView ID="ctlGridView" OnSelectedIndexChanged="OnSelectedIndexChanged"  OnDataBound="OnDataBound"  OnRowCommand="OnRowCommand" OnRowDataBound="GridView1_RowDataBound"  AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" DataSourceID="SqlDataSource1" PageSize="25" DataKeyNames="UserId"  runat="server" CssClass="tblGrid" CellPadding="0" CellSpacing="0" >
     <Columns>

<asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="True" SortExpression="User Name" />
<asp:TemplateField Visible="false">
<ItemTemplate>
<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"UserId") %>' />
</ItemTemplate>
</asp:TemplateField>


     <asp:BoundField DataField="Email" HeaderText="Email Address" ReadOnly="True" SortExpression="Email" />
   
     <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="tool" ItemStyle-CssClass="tool">

     <ItemTemplate>
       <asp:HyperLink ID="EditLink" runat="server" ImageUrl="/admin/images/Edit.gif" Text="Edit"></asp:HyperLink>
     </ItemTemplate>
   
     </asp:TemplateField>
      <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="tool" ItemStyle-CssClass="tool" >
   <ItemTemplate>
         <asp:ImageButton  id="DeleteButton" CommandName="Delete" AlternateText="Delete"  OnClientClick="showConfirm(this); return false;" ImageUrl="/admin/images/Delete.gif" runat="server" />
    </ItemTemplate>
</asp:TemplateField>

 </Columns>
       <PagerTemplate>
        <asp:ImageButton ID="ImageButton1" runat="server"
            ImageUrl="/admin/images/ico_rewind.gif" CommandArgument="First" CommandName="Page" />
        <asp:ImageButton ID="ImageButton2" runat="server"
            ImageUrl="/admin/images/ico_fastrewind.gif" CommandArgument="Prev" CommandName="Page" />

Page
        <asp:DropDownList ID="ddlPages" runat="server"
            AutoPostBack="True" OnSelectedIndexChanged="ddlPages_SelectedIndexChanged" >
        </asp:DropDownList> of <asp:Label ID="lblPageCount"
            runat="server"></asp:Label>

<asp:ImageButton ID="ImageButton3" runat="server"
            ImageUrl="/admin/images/ico_fastforward.gif"  CommandArgument="Next" CommandName="Page" />
        <asp:ImageButton ID="ImageButton4" runat="server"
            ImageUrl="/admin/images/ico_forward.gif" CommandArgument="Last" CommandName="Page" />

</PagerTemplate>

    </asp:GridView>

    </ContentTemplate>

</asp:UpdatePanel>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:epicCMS %>"
    DeleteCommand="Epic.proc_tblUsersDelete" DeleteCommandType="StoredProcedure" SelectCommand="Epic.proc_tblUsersLoadAll"
    SelectCommandType="StoredProcedure">
    <DeleteParameters>
        <asp:Parameter Name="UserId" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>

<radW:RadWindowManager ID="RadWindowManager1" runat="server" Width="600" Height="450" Left="" NavigateUrl="" SkinsPath="~/RadControls/Window/Skins/"  OnClientClose="window.location.reload()" Skin="CMS" Title="" Top="">
             <Windows>
             

                <radW:RadWindow  ID="EditUser" Width="650px" runat="server" Left="" SkinsPath="~/RadControls/Window/Skins/"  Skin="CMS"
                  Behavior="Close" OnClientClose="this.Close();"      Title="Edit/Add User"  ReloadOnShow="True" Modal="True" Top="20px" />

             </Windows>
</radW:RadWindowManager>
<cc2:ModalPopupExtender  runat="server" BehaviorID="mdlPopup" ID="modulpopupextender" 
    TargetControlID="popup" PopupControlID="popup" OkControlID="btnOk" OnOkScript="okClick();" 
    CancelControlID="btnNo" OnCancelScript="cancelClick();"
   BackgroundCssClass="modalBackground" >
</cc2:ModalPopupExtender>
<div id="popup" runat="server" align="center" class="confirm" style="display:none;">
                Are you sure you want to delete this item?
                <asp:Button ID="btnOk" runat="server" Text="Yes" Width="50px" CssClass="btn yes"/>
                <asp:Button ID="btnNo" runat="server" Text="No" Width="50px" CssClass="btn no" />
            </div> 
            
<cc2:ModalPopupExtender ID="mdlPopupedit" BehaviorID="mdlPopupedit" runat="server"  TargetControlID="popupedit" PopupControlID="popupedit" OkControlID="btnOKedit" OnOkScript="okClick();" 
    CancelControlID="btnNoedit" OnCancelScript="canceleditClick();"
   BackgroundCssClass="modalBackground">
</cc2:ModalPopupExtender>           
     <div id="popupedit" runat="server" align="center" class="confirm" style="display:none">
                Are you sure you want to edit this item?
                <asp:Button ID="btnOKedit" runat="server" Text="Yes" Width="50px" CssClass="btn yes" />
                <asp:Button ID="btnNoedit" runat="server" Text="No" Width="50px" CssClass="btn no" />
            </div>        
<script type="text/javascript" language="javascript">

           function ShowEditFormUser(id)
            {
                window.radopen("/admin/controls/users/AddUser.aspx?id=" + id, "EditUser");
                return false;
            }
            function ShowInsertFormUser()
            {
               window.radopen("/admin/controls/users/AddUser.aspx", "EditUser");
               return false;
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
     function showConfirmedit(source){
        this._source = source;
        this._popup = $find('mdlPopupedit');
        
        //  find the confirm ModalPopup and show it    
        this._popup.show();
    }
    function okClick(){
        //  find the confirm ModalPopup and hide it    
        this._popup.hide();
        //  use the cached button as the postback source
        __doPostBack(this._source.name, '');
    }
    
    function cancelClick(){
     
        //  find the confirm ModalPopup and hide it 
        this._popup.hide();
         
        //  clear the event source
        this._source = null;
        this._popup = null;
        
    }
     function canceleditClick(){
      var hiddenField =  document.getElementById('<%=textb.ClientID%>');
            if (hiddenField.value = "0") {
                hiddenField.value = "1";
                }
        //  find the confirm ModalPopup and hide it 
        __doPostBack(this._source.name, '');
        this._popup.hide();
        //  clear the event source
        this._source = null;
        this._popup = null;
       
    }
      function isNumeric(str) {

       return /^\d$/.match(str);

      }
      
    var gridViewCtlId = '<%=ctlGridView.ClientID%>';
    var gridViewCtl = null;
    var curSelRow = null;
    var curRowIdx = -1;
    function getGridViewControl()
    {
        if (null == gridViewCtl)
        {
            gridViewCtl = document.getElementById(gridViewCtlId);
        }
    }
    
    function onGridViewRowSelected(rowIdx)
    {
        var selRow = getSelectedRow(rowIdx);
        if (null != selRow)
        {
            curSelRow = selRow;
            var cellValue = getCellValue(rowIdx, 1);
            alert(cellValue);
        }
    }
    
    function getSelectedRow(rowIdx)
    {
        return getGridRow(rowIdx);
    }
    
    function getGridRow(rowIdx)
    {
        getGridViewControl();
        if (null != gridViewCtl)
        {
            return gridViewCtl.rows[rowIdx];
        }
        return null;
    }
    
 
     function getGridColumn(rowIdx, colIdx)
    {
        var gridRow = getGridRow(rowIdx);
        if (null != gridRow)
        {
            return gridRow.cells[colIdx];
        }
        return null;
    }
    
    function getCellValue(rowIdx, colIdx)
    {
        var gridCell = getGridColumn(rowIdx, 0);
        if (null != gridCell)
        {
            return gridCell.innerText;
        }
        return null;
    }
</script>
  