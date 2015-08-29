using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using epicCMS;

public partial class admin_controls_images_ctlImageAdmin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hlAdd.NavigateUrl = epicCMSLib.Navigation.PopupPageLink("AddImageCategory.aspx", 300, 250);

        if (!Page.IsPostBack)
            getLang();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // drilldown
            HyperLink hl = (HyperLink)e.Row.Cells[0].Controls[1];
            hl.NavigateUrl = "~/admin/default.aspx?pg=imgedit&img=" + DataBinder.Eval(e.Row.DataItem, "ImageCategoryId").ToString() + "&langid=" + DataBinder.Eval(e.Row.DataItem, "LanguageId").ToString();

            // edit
            HyperLink hl2 = (HyperLink)e.Row.Cells[1].Controls[1];
            hl2.NavigateUrl = epicCMSLib.Navigation.PopupPageLink("AddImageCategory.aspx?catid=" + DataBinder.Eval(e.Row.DataItem, "ImageCategoryId").ToString() + "&langid=" + DataBinder.Eval(e.Row.DataItem, "LanguageId").ToString(), 300, 125);

        }
    }

    private void getLang()
    {
        tblLanguages lang = new tblLanguages();
        lang.LoadAll();

        do
        {
            ListItem li = new ListItem(lang.LanguageTitle, lang.LanguageId.ToString());
            DropDownList1.Items.Add(li);
        } while (lang.MoveNext());

        if (DropDownList1.Items.Count == 0)
            DropDownList1.Visible = false;
    }
}
