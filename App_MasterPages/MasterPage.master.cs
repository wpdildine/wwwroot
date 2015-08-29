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
using System.IO;
using System.Text;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Master_Pages_MasterPage : System.Web.UI.MasterPage
{


    protected void Page_Load(object sender, EventArgs e)
    {


        CheckLogin();

        string[] dirs = epicShared.GetProductDirsFromUrl();
        if (dirs[2].ToLower() == "default.aspx")
        {
            html_body.Attributes.Add("class", "pg_welcome");
            //meta_desc.Attributes.Add("content", "");
            //meta_keywords.Attributes.Add("content", "");
        }
        else if (dirs[2] == "steps")
        {
            html_body.Attributes.Add("class", "pg_steps");

            if (dirs[3] == "follow")
            {
                html_body.Attributes.Add("class", "pg_steps sect_2_1");
            }
            else if (dirs[3] == "challenge")
            {
                html_body.Attributes.Add("class", "pg_steps sect_2_2");
            }
            else if (dirs[3] == "expand")
            {
                html_body.Attributes.Add("class", "pg_steps sect_2_3");
            }
            //meta_desc.Attributes.Add("content", "");
            //meta_keywords.Attributes.Add("content", "");
        }
        else if (dirs[2] == "types")
        {

            string c = "pg_types";

            if (dirs[3].ToLower().Contains("default.aspx"))
            {
                c = "pg_types sect_3_0";
            }
            else if (dirs[3] == "sensory")
            {
                c = "pg_types sect_3_1";
            }
            else if (dirs[3] == "object")
            {
                c = "pg_types sect_3_2";
            }
            else if (dirs[3] == "symbolic")
            {
                c = "pg_types sect_3_3";
            }

            if (dirs.Length > 4)
            {
                if (dirs[4].ToLower().Contains("follow"))
                {
                    c = c + " sect_follow";
                }
                else if (dirs[4].ToLower().Contains("challenge"))
                {
                    c = c + " sect_challenge";
                }
            }

            html_body.Attributes.Add("class", c);
            //meta_desc.Attributes.Add("content", "");
            //meta_keywords.Attributes.Add("content", "");
        }
        else if (dirs[2] == "troubleshooting")
        {
            html_body.Attributes.Add("class", "pg_troubleshooting");
            //meta_desc.Attributes.Add("content", "");
            //meta_keywords.Attributes.Add("content", "");
        }
        else if (dirs[2] == "tools")
        {
            html_body.Attributes.Add("class", "pg_tools");
            //meta_desc.Attributes.Add("content", "");
            //meta_keywords.Attributes.Add("content", "");
        }
        else if (dirs[2] == "yourFT")
        {
            string c = "pg_types pg_yourft";

            if (dirs[3].ToLower().Contains("default.aspx"))
            {
                c = "pg_yourft";
            }
            else if (dirs[3] == "setup")
            {
                c = "pg_yourft sect_4_1";
            }
            else if (dirs[3] == "evaluate")
            {
                c = "pg_yourft sect_4_2";
            }
            html_body.Attributes.Add("class", c);

        }
        
    }

    public void CheckLogin()
    {


        if (UserContext.GetContextItem("LoggedIn") != null && UserContext.GetContextItem("LoggedIn") == "Yes")
        {





        }
        else
        {


            Response.Redirect("/funct/noaccess.aspx");

        }
    }
 

}