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

public partial class admin_controls_images_ctlImageEditAdmin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hlAdd.NavigateUrl = epicCMSLib.Navigation.PopupPageLink("addImage.aspx?catid=" +Request["img"], 300, 250);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img =(Image) e.Row.Cells[1].Controls[1];
            img.ImageUrl = "~/renderimage.aspx?imageid="+ DataBinder.Eval(e.Row.DataItem, "ImageAssetId").ToString() + "&hei=50";

            // edit
            HyperLink hl = (HyperLink)e.Row.Cells[2].Controls[1];
            hl.NavigateUrl = epicCMSLib.Navigation.PopupPageLink("AddImage.aspx?img=" + DataBinder.Eval(e.Row.DataItem, "ImageAssetId").ToString() + "&catid=" +Request["img"] , 350, 250);

            LinkButton lb = (LinkButton)e.Row.Cells[3].Controls[1];
            lb.Attributes.Add("onclick", "return confirm_delete();");
        }
    }
}
