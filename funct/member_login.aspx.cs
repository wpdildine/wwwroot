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
using System.Security.Cryptography;
using System.Text;
public partial class funct_member_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string daysLeft = Server.UrlDecode(Request.QueryString["daysLeft"]);
        string token = Server.UrlDecode(Request.QueryString["Token"]);
        string salt = "gr33nsp4n2o15";

        // Adjust incoming querystring for date to transform YYYYMMDD to YYYY-MM-DD
        //expirationdate = expirationdate.Substring(0, 4) + "-" + expirationdate.Substring(4, expirationdate.Length - 4);
        // expirationdate = expirationdate.Substring(0, 7) + "-" + expirationdate.Substring(7, expirationdate.Length - 7);

        //DateTime myExpDate = Convert.ToDateTime(expirationdate);

        //Response.Write("id: " + foreignid + "<br>");
        //Response.Write("firstname: " + firstname + "<br>");
        //Response.Write("lastname: " + lastname + "<br>");
        //Response.Write("expirationdate: <br>");
        //Response.Write("memberlevel: " + memberlevel + "<br>");
        //Response.Write("email: " + email + "<br><br>");

        // Check if the this is a valid GET url
        if (CheckToken(token, salt, daysLeft))
        {

            // let's log them in
            Login(daysLeft);

            // Third let's redirect them to the appropriate member landing page
            Response.Redirect("/en-us/default.aspx");

        }
        else
        {
            //Response.Write("STOP TRYING TO HACK!");
            //Response.Redirect("http://www.womenofgrace.com");
        }




    }

    protected bool CheckToken(string token, string salt, string daysLeft)
    {

        bool validLogin = false;

        Response.Write("token = " + token + "<br />");
        Response.Write("userstring = daysLeft=" + daysLeft + "<br />");
        Response.Write("userstring hashed (should equal token) = " + SHA1String(salt + SHA1String("daysLeft=" + daysLeft)) + "<br />");

        //Response.Write(token + "==" + MD5String(salt + MD5String("User_id=" + foreignid + "&user_level=" + memberlevel + "&expDate=" + Request["expDate"] + "&email=" + email)));

        if (token == SHA1String(salt + SHA1String("daysLeft=" + daysLeft)))
            validLogin = true;

        //if (token == MD5String("Hwtnewh@ven" + MD5String(email)))
        //

        Response.Write("<br /><br />Is this a valid connection? " + validLogin);

        if (validLogin)
            Response.Write("<br /><br />For testing purposes, please click here to <a href=\"/en-us/default.aspx\">continue to the site</a>, then check your cookies to ensure you have a cookie called 'LoggedIn', set to true, with a proper expiration");

        return validLogin;

    }


    protected string SHA1String(string input)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }

    protected string MD5String(string myText)
    {
        byte[] textBytes = System.Text.Encoding.Default.GetBytes(myText);
        System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
        cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hash = cryptHandler.ComputeHash(textBytes);
        string ret = "";
        foreach (byte a in hash)
        {
            if (a < 16)
                ret += "0" + a.ToString("x");
            else
                ret += a.ToString("x");
        }
        return ret;
    }

    

    public static void Login(string daysLeft)
    {
        
            
        UserContext.SetContextItemWithDuration("LoggedIn", "Yes", Convert.ToInt32(daysLeft));

    }
}