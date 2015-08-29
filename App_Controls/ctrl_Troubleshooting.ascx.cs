using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Controls_ctrl_Troubleshooting : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(Request.QueryString["sect"] != null && Request.QueryString["sect"] != "")
        {

            JSHolder.InnerHtml = "<script type=\"text/javascript\">$(document).ready(function () { goTo('sect" + Request.QueryString["sect"] + "'); });</script>";

        }

    }
}