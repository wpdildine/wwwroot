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
using Telerik.WebControls;
using epicCMS;
using System.Text;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class admin_controls_ctl_Welcome : System.Web.UI.UserControl
{


    protected void Page_Load(object sender, EventArgs e)
    {
        GetWelcometext();
        GetCMSManual();
        
    }
    private void GetWelcometext()
    {
        StringBuilder sb = new StringBuilder();
        //sb.Append("<h2>Welcome to your Content Management System.</h2>");
        sb.Append("<p>Greetings, " + getuser() + "! Welcome to your very own Content Management System.  This area allows you to manage the content of a variety of areas of your website -- with little to zero knowledge of any programming languages! Exciting, isn't it?</p>");
        sb.Append("<p>If you look in the gray bar on the top of this window you will find a series of links that will bring you to different areas of your CMS.</p>");
        sb.Append("<ul>");
        sb.Append("<li><strong>Users:</strong> In this section you can add, edit, or remove the various users that you have given permission to use this CMS.</li>");
        sb.Append("<li><strong>Pages:</strong> The majority of your time will be spent here.  This is the section in which you edit the content found throughout your website.</li>");
        sb.Append("<li><strong>Images:</strong> This also contains the image-repository, which houses all of the images that you have control over on your website.</li>");
        sb.Append("<li><strong>Documents:</strong> This section contains the document-repository, which houses all of the documents that you can change throughout your website.</li>");
        //sb.Append("<li><strong>Audio:</strong> Found here is the audio-repository, which houses a variety of audio files that you can change.</li>");
        //sb.Append("<li><strong>Podcasts:</strong> All of your podcasts can be stored in the podcast-repository.</li>");
        sb.Append("</ul><p>You are currently located in the <strong>Pages</strong> section of your CMS.</p>");
        sb.Append("<p>On the left hand side, under the heading <strong>Select a Page</strong>, you will find different categories of you website that you can manage. Each category represents a different area of your website that you can manage.</p>");
        sb.Append("<p>Have some questions? Please reference the Instruction Manual for Detail Instructions on the CMS Usage.</p>");
        PlaceHolder1.Controls.Add(new LiteralControl(sb.ToString()));
    }
    private string getuser()
    {
        string name = "";
        if (Page.User.Identity.Name != null)
        {
            name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase((Page.User.Identity.Name).ToLower());
        }
        else
        {
            name = "";
        }
        return name;
    }
    private void GetCMSManual()
    {
            HyperLink hl = new HyperLink();
            tblSites site = new tblSites();
            site.LoadByPrimaryKey((int)Session["siteid"]);
            hl.Text = "CMS Manual For " + site.SiteTitle;
            hl.NavigateUrl = "/admin/CMS_Manual.pdf";
            hl.Target = "_blank";
            StringBuilder sb = new StringBuilder();
            sb.Append("<strong>CMS MANUAL:</strong>");
            PlaceHolder1.Controls.Add(new LiteralControl(sb.ToString()));
            PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
            PlaceHolder1.Controls.Add(hl);
            PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
    
    }

 


}
