<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlImageEditAdmin.ascx.cs" Inherits="admin_controls_images_ctlImageEditAdmin" %>
<table cellpadding="0" border="0" cellspacing="0">
<tr><td valign="top" style="padding-bottom:10px">
<asp:HyperLink ID="hlAdd" runat="server" CssClass="addLink">Add New Image</asp:HyperLink></td></tr>
<tr><td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
    OnRowDataBound="GridView1_RowDataBound" DataKeyNames="ImageAssetId" DataMember="DefaultView">
    <Columns>
        <asp:BoundField DataField="ImageTitle" HeaderText="Title" SortExpression="ImageTitle" HeaderStyle-CssClass="basicColumnHeader" ItemStyle-CssClass="basicColumn" />
        <asp:TemplateField HeaderText="Image" SortExpression="ImageData">
            <ItemTemplate>
                <asp:Image ID="img1" runat="server" ></asp:Image>
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField ShowHeader="true" HeaderText="Edit">
            <ItemTemplate>
                <asp:HyperLink ID="hlEdit" CssClass="editLink" runat="server" Text=""></asp:HyperLink>
            </ItemTemplate>
             <ItemStyle CssClass="editDeleteColumn" />
                <HeaderStyle CssClass="editDeleteColumn" />
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="true" HeaderText="Delete">
            <ItemTemplate >
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="" CssClass="deleteLink"></asp:LinkButton>
            </ItemTemplate>
             <ItemStyle CssClass="editDeleteColumn" />
             <HeaderStyle CssClass="editDeleteColumn" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:epicCMS %>"
    SelectCommand="uspSelectImagesByCategory" SelectCommandType="StoredProcedure" DeleteCommand="proc_tblImageAssetsDelete" DeleteCommandType="StoredProcedure">
    <SelectParameters>
        <asp:QueryStringParameter Name="CategoryId" QueryStringField="img" Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:ControlParameter ControlID="GridView1" Name="ImageAssetId" PropertyName="SelectedValue"
            Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource></td></tr></table>
