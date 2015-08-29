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

public partial class Master_Pages_epicCMS : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int? ul = UserContext.GetContextItemAsInt("userlevel");
            if (ul == null)
                CmsNav1.Visible = false;

            if (Request["langid"] != null)
            {
                string pg = "";
                if (Request["pageid"] != null)
                {
                    tblPagesXLanguage pgs = new tblPagesXLanguage();
                    pgs.Where.LanguageId.Value = Convert.ToInt32(Request["langid"]);
                    pgs.Where.PageId.Value = Convert.ToInt32(Request["pageid"]);
                    pgs.Query.Load();

                    pg = pgs.PageTitle;
                }

                hlQA.NavigateUrl = epicCMSLib.Navigation.SiteRootQA + pg;
                hlLive.NavigateUrl = epicCMSLib.Navigation.SiteRootLang + pg;
            }
            else
            {
                hlQA.Visible = false;
                hlLive.Visible = false;
                lblSpc.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("/admin/login.aspx");
        }
    }
}
