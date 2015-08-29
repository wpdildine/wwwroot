using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserContext
/// </summary>
public class UserContext
{
	public UserContext()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void SetContextItem(string key, object value)
    {
        HttpContext context = HttpContext.Current;

        if (value == null)
            value = "";

        HttpCookie cookie = new HttpCookie(key);
        cookie.Value = value.ToString();
        cookie.Expires = DateTime.Now.AddDays(1);

        context.Response.Cookies.Add(cookie);
    }

    public static void SetContextItemWithDuration(string key, object value, int days)
    {
        HttpContext context = HttpContext.Current;

        if (value == null)
            value = "";

        HttpCookie cookie = new HttpCookie(key);
        cookie.Value = value.ToString();
        cookie.Expires = DateTime.Now.AddDays(days);

        context.Response.Cookies.Add(cookie);
    }

    public static int? GetContextItemAsInt(string key)
    {
        string ret = GetContextItem(key);
        if (string.IsNullOrEmpty(ret))
            return null;
        else
            return Int32.Parse(ret);
    }

    public static string GetContextItem(string key)
    {
        HttpContext context = HttpContext.Current;

        if (context.Request.Cookies[key] != null)
        {
            HttpCookie cookie = context.Request.Cookies[key];
            return cookie.Value;
        }
        else
            return null;
    }
}
