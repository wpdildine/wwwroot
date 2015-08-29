using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

using System.Collections.Specialized;

using epicCMS;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global : HttpApplication
{

    public string epicSiteURL = "";

    void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext incoming = HttpContext.Current;
        string url = incoming.Request.Url.ToString().ToLower();

        // checkConnString();

        if (url.Contains(".aspx"))
        {
            /* string url_beg = url.Substring(0, 10);
             if (!url_beg.Contains("www"))
             {
                 string beg = url.Substring(0, 7);
                 int len = url.Length;
                 string end = url.Substring(7);

                 Response.Redirect(beg + "www." + end);
             }
             */

            //string url_beg = url.Substring(0, 11);
            //if (!url_beg.Contains("www"))
            //{
            //    string beg = url.Substring(0, 8);
            //    string end = "";
            //    if (beg == "https://")
            //    {
            //        end = url.Substring(8);
            //    }
            //    else
            //    {
            //        end = url.Substring(7);
            //    }
            //    beg = "http://";

            //    Response.Redirect(beg + "www." + end);
            //}
            //else
            //{

            //    string[] dirs = epicShared.GetProductDirsFromUrl();
            //    try
            //    {
            //        if (dirs[3] == "store" || dirs[2] == "contact" || dirs[4] == "account")
            //        {
            //            string beg = url.Substring(0, 8);
            //            if (beg != "https://")
            //            {
            //                beg = "https://";
            //                string end = url.Substring(7);
            //                Response.Redirect(beg + end);
            //            }
            //        }
            //        else
            //        {
            //            string beg = url.Substring(0, 8);
            //            if (beg == "https://")
            //            {
            //                beg = "http://";
            //                string end = url.Substring(8);
            //                Response.Redirect(beg + end);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}

            //if (!url.Contains("admin"))
            //{




            // it's not an asset
            if (validPage(url))
            {
                // it's a page to render
                int siteId = getSiteId(url);
                int langId = getLangId(url, siteId);

                int pageId = getPageId(url, siteId, langId);


                string rew = "~/render.aspx?pg=" + pageId.ToString() + "&siteId=" + siteId.ToString() + "&langId=" + langId.ToString();

                #region pass the querystrings
                NameValueCollection coll = incoming.Request.QueryString;
                for (int x = 0; x < coll.Count; x++)
                {
                    rew += "&" + coll.GetKey(x) + "=" + coll.Get(x);
                }
                #endregion

                if (getQA(url))
                    rew += "&qa=1";

                incoming.RewritePath(rew);
                //Server.Transfer("~/render.aspx?pg=" + pageId.ToString() + "&siteId=" + siteId.ToString() + "&langId=" + langId.ToString(), true);
            }
            else
            {

                if (url.Contains("/admin/"))
                {
                    if (!url.Contains("siteid"))
                    {
                        int siteId = getSiteId(url);

                        string rew = "";
                        if (url.IndexOf("?") > -1)
                        {
                            rew = "&siteId=" + siteId.ToString();
                        }
                        else
                        {
                            rew = "?siteId=" + siteId.ToString();
                        }
                        #region pass the querystrings
                        /*NameValueCollection coll = incoming.Request.QueryString;
                            for (int x = 0; x < coll.Count; x++)
                            {
                                if (rew.Contains("?"))
                                    rew += "&" + coll.GetKey(x) + "=" + coll.Get(x);
                                else
                                    rew += "?" + coll.GetKey(x) + "=" + coll.Get(x);
                            } */
                        #endregion

                        url = url.Substring(url.IndexOf("admin"));

                        //  rew = "&siteId=" + siteId.ToString();
                        incoming.RewritePath("~/" + url + rew);
                    }
                }
                else
                {
                    if (url.Contains("render.aspx"))
                        incoming.RewritePath("~/render.aspx");
                }
            }
        }
        /*else if (url.Contains(".asmx"))
        {
            string urlReg = incoming.Request.Url.ToString();
            if (urlReg.Contains(" "))
                Response.Redirect(urlReg.Replace(" ", "%20"));

        }*/
    }

    private bool validPage(string url)
    {
        string[] invalidPages = new string[14];
        invalidPages[0] = "render.aspx";
        invalidPages[1] = "masteradmin";
        invalidPages[2] = "radcontrols";
        invalidPages[3] = "admin";
        invalidPages[4] = "renderimage.aspx";
        invalidPages[5] = "rendertext.aspx";
        invalidPages[6] = "imagemanager";
        invalidPages[7] = "mediamanager";
        invalidPages[8] = "documentmanager";
        invalidPages[9] = "docmanager";
        invalidPages[10] = "renderpdf.aspx";
        invalidPages[11] = "welcome";
        invalidPages[12] = "pdf";

        invalidPages[13] = "funct";

        for (int x = 0; x < invalidPages.Length; x++)
        {
            if (url.Contains(invalidPages[x]))
                return false;
        }
        return true;
    }

    private int getPageId(string url, int siteId, int langId)
    {
        tblSites site = new tblSites();
        site.LoadByPrimaryKey(siteId);

        tblPagesXLanguage page = new tblPagesXLanguage();
        int start = url.ToLower().IndexOf(epicSiteURL.ToLower()) + epicSiteURL.Length + 7;

        if (getQA(url))
            start += 3;

        string pageName = url.Substring(start);
        if (url.Contains(".aspx"))
        {
            pageName = url.Substring(start, url.IndexOf(".aspx") + 5 - start);
        }

        page.Where.PageTitle.Value = pageName;
        page.Where.LanguageId.Value = langId;
        page.Query.Load();

        if (page.RowCount > 0)
        {
            page.Rewind();
            return page.PageId;
        }
        else
        {
            return -1;
        }
    }


    private void Application_AcquireRequestState(object sender, EventArgs e)
    {

    }

    private int getSiteId(string url)
    {
        tblSites sites = new tblSites();

        sites.LoadAll();

        do
        {
            if (url.ToLower().Contains(sites.SiteURL.ToLower()))
            {
                epicSiteURL = sites.SiteURL.ToLower();
                return sites.SiteId;
            }
            else if (url.ToLower().Contains(sites.SiteBetaURL.ToLower()))
            {
                epicSiteURL = sites.SiteBetaURL.ToLower();
                return sites.SiteId;
            }

        } while (sites.MoveNext());

        return -1;

    }

    private bool getQA(string url)
    {
        if (url.ToLower().Contains("/qa/"))
            return true;
        else
            return false;
    }

    private int getLangId(string url, int siteId)
    {
        int langId = -1;
        try
        {
            Regex exp = new Regex(@"/\w\w-\w\w/");
            MatchCollection MatchList = exp.Matches(url);
            Match FirstMatch = MatchList[0];

            tblLanguages lang = new tblLanguages();
            lang.Where.CultureTag.Value = FirstMatch.Value.Replace("/", "");
            lang.Where.SiteId.Value = siteId;

            lang.Query.Load();
            langId = lang.LanguageId;
        }
        catch (Exception e3)
        {

            if (HttpContext.Current.Request.Url.OriginalString.Contains("admin/login.aspx"))
            {
                if (HttpContext.Current.Request.RawUrl.Contains("www"))
                {

                    // no language specified
                    tblLanguages lang = new tblLanguages();
                    lang.Where.DefaultLanguage.Value = true;
                    lang.Where.SiteId.Value = siteId;
                    lang.Query.Load();

                    tblSites site = new tblSites();
                    site.LoadByPrimaryKey(siteId);
                    Response.Redirect("http://" + epicSiteURL + "/admin/login.aspx");
                }
                else
                {
                    // no language specified
                    tblLanguages lang = new tblLanguages();
                    lang.Where.DefaultLanguage.Value = true;
                    lang.Where.SiteId.Value = siteId;
                    lang.Query.Load();

                    tblSites site = new tblSites();
                    site.LoadByPrimaryKey(siteId);
                    Response.Redirect("http://" + epicSiteURL + "/admin/login.aspx");
                }
            }
            else
            {
                if (HttpContext.Current.Request.RawUrl.Contains("www"))
                {

                    // no language specified
                    tblLanguages lang = new tblLanguages();
                    lang.Where.DefaultLanguage.Value = true;
                    lang.Where.SiteId.Value = siteId;
                    lang.Query.Load();

                    tblSites site = new tblSites();
                    site.LoadByPrimaryKey(siteId);
                    Response.Redirect("http://" + epicSiteURL + "/" + lang.CultureTag + "/default.aspx");
                }
                else
                {
                    // no language specified
                    tblLanguages lang = new tblLanguages();
                    lang.Where.DefaultLanguage.Value = true;
                    lang.Where.SiteId.Value = siteId;
                    lang.Query.Load();

                    tblSites site = new tblSites();
                    site.LoadByPrimaryKey(siteId);
                    Response.Redirect("http://" + epicSiteURL + "/" + lang.CultureTag + "/default.aspx");
                }
            }
        }

        return langId;
    }

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
}
