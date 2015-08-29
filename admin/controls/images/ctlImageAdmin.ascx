<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlImageAdmin.ascx.cs" Inherits="admin_controls_images_ctlImageAdmin" %>
<table cellpadding="0" border="0" cellspacing="0">
<tr><td valign="top" style="padding-bottom:5px">
    Select Langauage
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
    </asp:DropDownList><br /><br />
<asp:HyperLink ID="hlAdd" runat="server" CssClass="addLink">Add New Image Category</asp:HyperLink>
    
    </td></tr>
<tr><td><asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="ImageCategoryId" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" PageSize="50">
    <Columns>
        <asp:TemplateField HeaderText="Category" SortExpression="ImageCategoryTitle">
            <ItemTemplate>
                <asp:HyperLink ID="Label1" runat="server" CssClass="internalLink" Text='<%# Bind("ImageCategoryTitle") %>'></asp:HyperLink>
            </ItemTemplate>
            <ItemStyle CssClass="basicColumn" />
            <HeaderStyle CssClass="basicColumnHeader" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
                <asp:HyperLink ID="hlEdit" CssClass="editLink" runat="server" Text=""></asp:HyperLink>
            </ItemTemplate>
             <ItemStyle CssClass="editDeleteColumn" />
                <HeaderStyle CssClass="editDeleteColumn" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
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
    SelectCommand="uspSelectImageCategoriesByLanguage" SelectCommandType="StoredProcedure" DeleteCommand="proc_tblImageCategoriesDelete" DeleteCommandType="StoredProcedure">
    <DeleteParameters>
        <asp:ControlParameter ControlID="GridView1" Name="ImageCategoryId" PropertyName="SelectedValue"
            Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="DropDownList1" Name="LangId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
</td></tr></table>
