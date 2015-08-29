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

public partial class admin_login : System.Web.UI.Page
{
      
    protected void Page_Load(object sender, EventArgs e)
    {
      
        Page.Title = epicShared.GetSiteIdURL();
        
        if (!Page.IsPostBack)
        {
            UserContext.SetContextItem("userid", null);
            UserContext.SetContextItem("userlevel", null);

        }
        Login1.CheckBoxStyle.CssClass = "chk_test";
    }

   
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
            if (Request.Cookies["userinfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("userinfo");
                Login1.UserName = cookie.Values["username"];

                Login1.RememberMeSet = (!String.IsNullOrEmpty(Login1.UserName));

            }
            else
            {
                TextBox txtUser = Login1.FindControl("UserName") as TextBox;
                if (txtUser != null)
                    this.SetFocus(txtUser);
            }
        }
        // Note this
        Response.Cache.SetNoStore();

    }

    bool AuthenticateUser(string username, string password)
    {
        tblUsers user = new tblUsers();

        user.Where.UserName.Value = username;
        user.Where.Password.Value = password;

        user.Query.Load();

        if (user.RowCount > 0)
        {
            UserContext.SetContextItem("userid", user.UserId);
            UserContext.SetContextItem("userlevel", user.UserLevel);
            return true;
        }
        else
            return false;
    }
    protected void setsession(string uname, string pass)
    {
        tblUsers user = new tblUsers();

        user.Where.UserName.Value = uname;
        user.Where.Password.Value = pass;

        user.Query.Load();

        if (user.RowCount > 0)
        {
            UserContext.SetContextItem("userid", user.UserId);
            UserContext.SetContextItem("userlevel", user.UserLevel);

        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

        if (AuthenticateUser(Login1.UserName, Login1.Password))
        {
            Int32 persistDays = 15;
            Int32 persistMinutes = 30;
             HttpCookie aCookie = new HttpCookie("userInfo");
            if (Request["returnurl"] == null)
            {
                if (Login1.RememberMeSet == true)
                {
                    aCookie.Values.Add("username",Login1.UserName);
                    aCookie.Expires = DateTime.Now.AddDays(persistDays);
                   
                }
                else
                {
                    aCookie.Values.Add("username",string.Empty);
                    aCookie.Expires = DateTime.Now.AddMinutes(persistMinutes);
                   
                }
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                Response.Cookies.Add(aCookie);
                Response.Redirect("default.aspx?pg=welcome&siteId=13");
            }
            else
            {
                if (Login1.RememberMeSet == true)
                {
                    aCookie.Values.Add("username",Login1.UserName);
                    aCookie.Expires = DateTime.Now.AddDays(persistDays);
                    
                }
                else
                {
                    aCookie.Values.Add("username",string.Empty);
                    aCookie.Expires = DateTime.Now.AddMinutes(persistMinutes);
                }
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                Response.Cookies.Add(aCookie);               
                Response.Redirect("default.aspx?pg=welcome&siteId=13");
            }

            setsession(Login1.UserName, Login1.Password);
        }
        else 
        {
            FormsAuthentication.SignOut();
        }
    }
   
}
