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

public partial class admin_AddImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["img"] != null)
        {
            CmsImageEditControl1.ImageId = Convert.ToInt32(Request["img"]);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CmsImageEditControl1.SaveValue();
        Label1.Text = epicCMSLib.Navigation.CloseWindowString;
    }
}
