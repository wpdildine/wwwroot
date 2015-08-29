using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using epicCMS;
using epicCMSControls;

/// <summary>
/// Summary description for epicCMSLib
/// </summary>
public static class epicCMSLib
{
    public class Navigation
    {
        /// <summary>
        /// Returns the language specific site root
        /// </summary>
        public static string SiteRootLang
        {
            get
            {
                try
                {
                    tblSites site = new tblSites();
                    site.LoadByPrimaryKey(int.Parse(HttpContext.Current.Request["siteid"]));

                    if (HttpContext.Current.Request.RawUrl.Contains("/qa/"))
                        return "http://" + site.SiteBetaURL + "/qa/" + CultureTag + "/";
                    else
                        return "http://" + site.SiteBetaURL + "/" + CultureTag + "/";
                }
                catch { return ConfigurationManager.AppSettings["siteRoot"] +  ConfigurationManager.AppSettings["lang"] +"/"; }
            }
        }

        public static string CultureTag
        {
            get
            {
                tblLanguages lang = new tblLanguages();
                lang.LoadByPrimaryKey(int.Parse(HttpContext.Current.Request["langid"]));

                return lang.CultureTag;
            }
        }

        public static string SiteRootQA
        {
            get
            {
                tblSites site = new tblSites();
                site.LoadByPrimaryKey(int.Parse(HttpContext.Current.Request["siteid"]));

                tblLanguages lang = new tblLanguages();
                lang.LoadByPrimaryKey(int.Parse(HttpContext.Current.Request["langid"]));

                return "http://" + site.SiteBetaURL + "/qa/" + lang.CultureTag + "/";
            }
        }

        /// <summary>
        /// Returns the site root without culture tag
        /// </summary>
        public static string SiteRoot
        {
            get
            {
                try
                {
                    tblSites site = new tblSites();
                    site.LoadByPrimaryKey(int.Parse(HttpContext.Current.Request["siteid"]));

                    return "http://" + site.SiteBetaURL + "/";
                }
                catch
                {
                    return ConfigurationManager.AppSettings["siteRoot"];
                }
            }
        }
        public static string PopupPageLink(string pageURL, int width, int height){
            string addtl = "";
            if (!pageURL.ToLower().Contains("langid"))
            {
                if (HttpContext.Current.Request["langId"] != null)
                {
                    if (pageURL.Contains("?"))
                        addtl = "&langId=" + HttpContext.Current.Request["langId"];
                    else
                        addtl = "?langId=" + HttpContext.Current.Request["langId"];
                }
            }
            return "javascript:NewWindow('" + pageURL + addtl +"','Edit'," + width.ToString() + "," + height.ToString() + ",true)";
       }
        public static string PopupPageLink(string pageURL, string title, int width, int height)
        {
            string addtl = "";
            if (!pageURL.ToLower().Contains("langid"))
            {
                if (HttpContext.Current.Request["langId"] != null)
                {
                    if (pageURL.Contains("?"))
                        addtl = "&langId=" + HttpContext.Current.Request["langId"];
                    else
                        addtl = "?langId=" + HttpContext.Current.Request["langId"];
                }
            }
            title = title.Replace(" ", "");
            return "javascript:NewWindow('" + pageURL + addtl + "','" + title + "'," + width.ToString() + "," + height.ToString() + ",true)";
        }
        public static string PopupPageLink(string pageURL, string title, int width, int height, bool nolang)
        {
            string addtl = "";
            if (!nolang)
            {
                if (!pageURL.ToLower().Contains("langid"))
                {
                    if (HttpContext.Current.Request["langId"] != null)
                    {
                        if (pageURL.Contains("?"))
                            addtl = "&langId=" + HttpContext.Current.Request["langId"];
                        else
                            addtl = "?langId=" + HttpContext.Current.Request["langId"];
                    }
                }
            }
            title = title.Replace(" ", "");
            return "javascript:NewWindow('" + pageURL + addtl + "','" + title + "'," + width.ToString() + "," + height.ToString() + ",true)";
        }
        public static string CloseWindowString
        {
            get
            {
                return "<script>window.close(); window.opener.location.href=window.opener.document.location.href</script>";
            }
        }

        public static void AddConfirm(ref LinkButton lb)
        {
            lb.Attributes.Add("onclick", "return confirm_delete();");
        }
    }

    public enum epicCMSAccessLevels
    {
        NoAccess,
        ReadOnly,
        CmsUpdate
    }
}
