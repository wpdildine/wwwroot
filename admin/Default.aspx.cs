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
public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.MasterPageFile = "~/App_MasterPages/epicCMS.master";
    }
   protected void Page_Init(object sender, EventArgs e)
    {

        if (UserContext.GetContextItemAsInt("userlevel") == null && UserContext.GetContextItemAsInt("userid") == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
           

            // record the site
            if (Request["siteid"] != null)
                Session["siteid"] = int.Parse(Request["siteid"]);

            tblSites site = new tblSites();
            site.LoadByPrimaryKey((int)Session["siteid"]);
            Page.Title = site.SiteTitle + " CMS";

            // find the nav
            ContentPlaceHolder phMain = (ContentPlaceHolder)Master.FindControl("MainContent");
            ContentPlaceHolder phNav = (ContentPlaceHolder)Master.FindControl("NavContent");
            HtmlTableCell tcMain = (HtmlTableCell)Master.FindControl("contentcell");
          
                
                    if (Request["pg"] == "user")
                    {
                        phMain.Controls.Add(Page.LoadControl("controls/users/ctlUserAdmin.ascx"));
                        phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));
                    }
                   
                    else
                    {
                        if (Request["pg"] == "audio")
                        {
                            phMain.Controls.Add(Page.LoadControl("controls/file.ascx"));
                            phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));

                        }
                        else
                        {
                            if (Request["pg"] == "image")
                            {
                                phMain.Controls.Add(Page.LoadControl("controls/file.ascx"));
                                phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));

                            }
                            else
                            {
                                if (Request["pg"] == "docs")
                                {
                                    //phMain.Controls.Add(Page.LoadControl("controls/Docs/ctlDocManager.ascx"));
                                    phMain.Controls.Add(Page.LoadControl("controls/file.ascx"));
                                    phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));

                                }
                                else
                                {
                                    if (Request["pg"] == "movie")
                                    {
                                        //phMain.Controls.Add(Page.LoadControl("controls/Movies/ctlMovieManager.ascx"));
                                        phMain.Controls.Add(Page.LoadControl("controls/file.ascx"));
                                        phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));
                                    }
                                    else
                                    {
                                        if (Request["pg"] == "podcasts")
                                        {
                                            phMain.Controls.Add(Page.LoadControl("controls/file.ascx"));
                                            phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));

                                        }
                                        else
                                        {
                                            if (Request["pg"] == "welcome")
                                            {
                                                phMain.Controls.Add(Page.LoadControl("controls/ctl_Welcome.ascx"));
                                                phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));

                                            }
                                            else
                                            {

                                                phMain.Controls.Add(Page.LoadControl("controls/ctlPageControls.ascx"));
                                                phNav.Controls.Add(Page.LoadControl("controls/ctlSiteMap.ascx"));
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
        }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
}
