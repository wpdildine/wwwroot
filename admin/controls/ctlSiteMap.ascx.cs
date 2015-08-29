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
using System.Data.Sql;
using System.Data.SqlClient;
using epicCMS;
using Telerik.WebControls;

public partial class admin_controls_ctlSiteMap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int langId=-1;
        if (Request["langId"] != null)
        {
            langId = Int32.Parse(Request["langId"]);
        }
        else
        {
            string siteId = "";
            if ((Request["siteId"] != null) && (Request["siteId"].ToString() != "-1"))
            {
                siteId = Request["siteId"].ToString();
            }
            else
            {
                tblSites s = new tblSites();
                s.Where.SiteTitle.Value = epicShared.GetSiteIdURL();
                s.Query.Load();
                siteId = s.SiteId.ToString();

            }
            tblLanguages lang = new tblLanguages();
            lang.Where.DefaultLanguage.Value = true;
            lang.Where.SiteId.Value = Int32.Parse(siteId);

            lang.Query.Load();

            langId = lang.LanguageId;
        }

        //if (!Page.IsPostBack)
        //    CreateLanguages();

        DisplayMap(langId);
    }

  
    public void DisplayMap(int langId)
    {
     //   TreeView1.Nodes.Clear();
        RadTreeView1.Nodes.Clear();

        tblPagesXLanguage pageL = new tblPagesXLanguage();
        pageL.Where.LanguageId.Value = langId;
        pageL.Where.ParentPage.Value = -1;
        pageL.Where.ShowInCMS.Value = false;
        pageL.Where.ShowInCMS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual;

        pageL.Query.Load();

        pageL.Sort = "SortOrder ASC";

        tblUserPageAccess access = new tblUserPageAccess();
        access.Where.UserId.Value = (int)UserContext.GetContextItemAsInt("userid");

        access.Query.Load();

        // find all the top level pages
        if (pageL.RowCount > 0)
        {
            pageL.Rewind();
            do
            {
                if (pageL.ShowInCMS != false)
                {
                    access.Filter = "PageXLanguageId=" + pageL.PageXLanguageId.ToString();
                    if (access.RowCount > 0 && access.AccessLevel == 2)
                    {
                        HyperLink hl = new HyperLink();
                        hl.Text = pageL.PageFriendlyName;

                        RadTreeNode rtn = new RadTreeNode();

                        if (pageL.PageId == 103)
                            pageL.PageId = 105;
                        else if (pageL.PageId == 111)
                            pageL.PageId = 112;

                        if (hl.Text == "Contact Information")
                            rtn.Text = "Contact Submissions";

                        else if (hl.Text == "Welcome!")
                            rtn.Text = "Meta Tags";

                        else
                            rtn.Text = hl.Text;


                        hl.NavigateUrl = "~/admin/default.aspx?pageId=" + pageL.PageId.ToString() + "&langId=" + langId.ToString();

                        rtn.NavigateUrl = hl.NavigateUrl;
                        RadTreeView1.Nodes.Add(rtn);
                        if (rtn.Text != "About Us" && rtn.Text != "Legal Resources" && rtn.Text != "Recognition" && rtn.Text != "Clients")
                            rtn.CssClassSelect = "selected";
                        else
                            rtn.CssClassSelect = "white_selected";
                        
                        if (Request["pageId"] == null)
                        {
                            // need to redirect
                            //Response.Redirect(hl.NavigateUrl);
                            rtn.Expanded = true;
                        }
                        else
                        {
                            rtn.Expanded = true;
                            if (int.Parse(Request["pageId"]) == pageL.PageId)
                            {
                               rtn.Selected = true;
                            }
                        }

                        hl.CssClass = "navlink";
                        if (Request["pageId"] != null)
                        {
                            if (int.Parse(Request["pageId"]) == pageL.PageId)
                            {
                                hl.NavigateUrl = "";
                                hl.CssClass = "navlinkde";
                            }
                        }
                        PlaceHolder1.Controls.Add(new LiteralControl("<div style='padding-left:0px'>"));
                        hl.Style.Add("padding-left", "0px");
                        PlaceHolder1.Controls.Add(hl);
                        PlaceHolder1.Controls.Add(new LiteralControl("</div>"));

                        placeSubs(pageL.PageXLanguageId, langId, 1, rtn);

                    }
                }
            }
            while (pageL.MoveNext());
        }
    }

    private void placeSubs(int pageId, int langId, int level, RadTreeNode rtn)
    {
        tblPagesXLanguage pageL = new tblPagesXLanguage();
        pageL.Where.LanguageId.Value = langId;
        pageL.Where.ParentPage.Value = pageId;

        pageL.Query.Load();

        pageL.Sort = "SortOrder ASC";



            if (pageL.RowCount > 0)
            {
                tblUserPageAccess access = new tblUserPageAccess();
                access.Where.UserId.Value = (int)UserContext.GetContextItemAsInt("userid");

                access.Query.Load();

                pageL.Rewind();
                do
                {
                    if (pageL.ShowInCMS != false)
                    {
                        access.Filter = "PageXLanguageId=" + pageL.PageXLanguageId.ToString();

                        if (access.RowCount > 0 && access.AccessLevel == 2)
                        {
                            HyperLink hl = new HyperLink();
                            hl.Text = pageL.PageFriendlyName;
                            hl.NavigateUrl = "~/admin/default.aspx?pageId=" + pageL.PageId.ToString() + "&langId=" + langId.ToString();
                            hl.CssClass = "navlink";


                            //if (hl.Text.Contains("Recipes -> "))
                            //hl.Text.Replace("Recipes -> ", "");

                            if (hl.Text.Contains("About Us -> "))
                                hl.Text = hl.Text.Replace("About Us -> ", "");

                            if (hl.Text.Contains("Legal Resources -> "))
                                hl.Text = hl.Text.Replace("Legal Resources -> ", "");

                            if (hl.Text.Contains("News & Events -> "))
                                hl.Text = hl.Text.Replace("News & Events -> ", "");

                            if (hl.Text.Contains("Attorneys & Staff -> "))
                                hl.Text = hl.Text.Replace("Attorneys & Staff -> ", "");

                            if (hl.Text == "LawClips Newsletter")
                                hl.Text = "LawClips";

                            if (hl.Text == "LawClips Newsletter -> Details")
                                hl.Text = "Signups";

                            if (hl.Text == "Site Map")
                                hl.Text = "Project Spotlights";

                            if (hl.Text == "History")
                                hl.Text = "Events Promo";

                            if (hl.Text == "Our Facility")
                                hl.Text = "Timeline";

                            if (hl.Text == "Details")
                                hl.Text = "Badge Images";


                            RadTreeNode rcn = new RadTreeNode(hl.Text, "", hl.NavigateUrl);

                            rcn.Expanded = true;
                            rcn.CssClassSelect = "selected";
                            rtn.Nodes.Add(rcn);

                            if (Request["pageId"] != null)
                            {
                                if (int.Parse(Request["pageId"]) == pageL.PageId)
                                {

                                    rcn.Selected = true;
                                    rcn.Expanded = true;

                                    RadTreeNode tn2 = rcn.Parent;
                                    while (tn2 != null)
                                    {
                                        tn2.Expanded = true;
                                        tn2 = tn2.Parent;
                                    }

                                    hl.NavigateUrl = "";
                                    hl.CssClass = "navlinkde";
                                }
                            }
                            Image img = new Image();
                            img.ImageUrl = "~/App_Images/arrow.gif";
                            img.Width = 10;
                            img.Height = 10;
                            PlaceHolder1.Controls.Add(new LiteralControl("<div style='padding-left:" + (level * 10).ToString() + "px'>"));
                            hl.Style.Add("background-image", "url('../../App_Images/arrow.gif')");
                            PlaceHolder1.Controls.Add(hl);
                            PlaceHolder1.Controls.Add(new LiteralControl("</div>"));

                            placeSubs(pageL.PageXLanguageId, langId, level + 1, rcn);
                        }
                    }
                }
                while (pageL.MoveNext());
            }
    }
   
}
