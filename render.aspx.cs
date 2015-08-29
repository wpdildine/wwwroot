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

public partial class render : System.Web.UI.Page
{
   
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request["pg"] != null)
        {
            if (int.Parse(Request["pg"]) > -1)
            {
                // first, grab the pageID
                int page = Int32.Parse(Request["pg"]);

                // then site id
                int site = Int32.Parse(Request["siteId"]);

                tblPages pages = new tblPages();
                pages.Where.PageId.Value = page;

                pages.Query.Load();

                tblMasterPages master = new tblMasterPages();
                master.LoadByPrimaryKey(pages.MasterPageId);

                Page.MasterPageFile = "~/App_MasterPages/" + master.MasterPageTitle;

                // find the place holders
                tblContentPanes panes = new tblContentPanes();
                panes.Where.MasterPageId.Value = pages.MasterPageId;
                panes.Query.Load();

                do
                {
                    tblPageXControl pgx = new tblPageXControl();

                    pgx.Where.PageId.Value = page;
                    pgx.Where.ContentPaneId.Value = panes.ContentPaneId;

                    pgx.Query.Load();

                    if (pgx.RowCount > 0)
                    {
                        pgx.Rewind();
                        do
                        {
                            ContentPlaceHolder ph1 = (ContentPlaceHolder)Master.FindControl(panes.ContentPaneTitle);

                            tblControls control = new tblControls();
                            control.LoadByPrimaryKey(pgx.ControlId);
                           ph1.Controls.Add(Page.LoadControl("~/App_Controls/" + control.ControlLocation));
                        } while (pgx.MoveNext());
                    }
                } while (panes.MoveNext());

                tblSites ts = new tblSites();
                ts.LoadByPrimaryKey(site);
                tblPagesXLanguage pg = new tblPagesXLanguage();
                pg.Where.PageId.Value = page;
                pg.Where.LanguageId.Value = Convert.ToInt32(Request["langid"]);
                pg.Query.Load();

                Page.Title = ts.SiteTitle + " - " + pg.PageFriendlyName;
            }
        }
    }
}
