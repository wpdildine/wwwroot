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

public partial class admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder phNav = (ContentPlaceHolder)Master.FindControl("NavContent");
        Label1.Text = "Welcome to you content management system. Please click make your selection from the left navigation";
        phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));
        
    }
}
