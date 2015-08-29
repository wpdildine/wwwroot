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
using System.Threading;

public partial class admin_controls_users_AddUser : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        fillPages();

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request["id"] != null)
        {
            Page.Title = "Edit User";
            changepass.Visible = false;
        }
        else
        {
            Page.Title = "Add User";
            changepass.Visible = false;
        }


        if (!Page.IsPostBack)
        {
            fillUserLevels();
        }
        if (Request["id"] != null)
        {

            ViewState["_id"] = Convert.ToInt32(Request["id"]);
            if (!Page.IsPostBack)
            {
                DoBind();
                LinkButton1.Visible = true;
            }

        }
        else
        {

            LinkButton1.Visible = false;
        }



    }

    private void DoBind()
    {
        int id = (int)ViewState["_id"];
        tblUsers user = new tblUsers();
        user.LoadByPrimaryKey(id);

        tbUsername.Text = user.UserName;
        tbPassword.Text = user.Password;

        tbEmail.Text = user.Email;
        if (user.UserLevel == 1)
        {
            ddUserLevel.Visible = false;
            userlevel.Visible = false;
        }
        else
        {
            ddUserLevel.SelectedValue = user.UserLevel.ToString();
            tbEmail.Text = user.Email;
        }
    }

    private void fillUserLevels()
    {
        tblUserLevels levels = new tblUserLevels();
        levels.LoadAll();

        do
        {
            if (levels.UserLevelId >= UserContext.GetContextItemAsInt("userlevel"))
            {
                ddUserLevel.Items.Add(new ListItem(levels.UserLevelTitle, levels.UserLevelId.ToString()));
            }
        } while (levels.MoveNext());
    }

    private void fillPages()
    {
        ViewState["_id"] = Convert.ToInt32(Request["id"]);
        int id = (int)ViewState["_id"];
        tblLanguages langs = new tblLanguages();
        langs.Where.SiteId.Value = (int)Session["siteid"];
        langs.Query.Load();

        do
        {
            tblPagesXLanguage lang = new tblPagesXLanguage();
            lang.Where.LanguageId.Value = langs.LanguageId;
            lang.Where.ShowInCMS.Value = true;
            lang.Query.Load();
            lang.Sort = "SortOrder ASC"; 
            TableRow tr = new TableRow();
            TableCell tc2 = new TableCell();
            tc2.ColumnSpan = 3;
            Image img = new Image();
            //lb.Text = langs.LanguageTitle;
            img.ImageUrl = epicCMSLib.Navigation.SiteRoot + "rendertext.aspx?textval=" + langs.LanguageTitle + "&fc=FF0000&bc=FFFFFF&size=16&font=Verdana&style=regular";
            //tc2.Controls.Add(img);
            //tr.Cells.Add(tc2);

            Table1.Rows.Add(tr);
            tr = new TableRow();

            if (lang.RowCount > 0)
            {
                lang.Rewind();
                do
                {
                    tblUserPageAccess access = new tblUserPageAccess();

                    CheckBox cb = new CheckBox();
                    cb.Text = "";
                    cb.ID = lang.PageXLanguageId.ToString();

                    if (id != null)
                    {
                        access.Where.PageXLanguageId.Value = lang.PageXLanguageId;
                        access.Where.UserId.Value = id;

                        access.Query.Load();

                        if (access.RowCount > 0)
                        {
                            access.Rewind();
                            if (access.AccessLevel == (int)epicCMSLib.epicCMSAccessLevels.CmsUpdate)
                                cb.Checked = true;
                        }
                    }
                    else
                    {
                        cb.Checked = true;
                    }

                    TableCell tc = new TableCell();
                    tc.VerticalAlign = VerticalAlign.Top;
                    //tc.Width = 125;
                    HyperLink lb2 = new HyperLink();


                    if (lang.PageFriendlyName == "Legal Resources -> LawClips Newsletter")
                        lb2.Text = "Legal Resources -> LawClips";
                    else if (lang.PageFriendlyName == "Welcome!")
                        lb2.Text = "Meta Tags";
                    else if (lang.PageFriendlyName == "Legal Resources -> LawClips Newsletter -> Details")
                        lb2.Text = "Legal Resources -> LawClips -> Signups";
                    else if (lang.PageFriendlyName == "Contact Information")
                        lb2.Text = "Contact Submissions";
                    else if (lang.PageFriendlyName == "About Us -> Our Facility")
                        lb2.Text = "About Us -> Timeline";
                    else if (lang.PageFriendlyName == "Attorneys & Staff -> Details")
                        lb2.Text = "Attorneys & Staff -> Badge Images";
                    else
                        lb2.Text = lang.PageFriendlyName;
                    
                    
                    lb2.NavigateUrl = epicCMSLib.Navigation.SiteRoot + langs.CultureTag + "/" + lang.PageTitle;
                    lb2.Target = "_blank";
                    tc.Controls.Add(cb);

                    tc.Controls.Add(lb2);

                    if (lang.PageFriendlyName != "What's New" && lang.PageFriendlyName != "Products" && lang.PageFriendlyName != "Career Opportunities")
                        tr.Cells.Add(tc);

                    if (tr.Cells.Count > 0)
                    {
                        Table1.Rows.Add(tr);
                        tr = new TableRow();
                    }

                } while (lang.MoveNext());
            }
            if (tr.Cells.Count > 0)
                Table1.Rows.Add(tr);
        } while (langs.MoveNext());
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        createuser();
        txtSubmit.Attributes.Add("onfocus", "Save()");
        txtSubmit.Focus();
    }
    public void createuser()
    {
        tblUsers user = new tblUsers();
        int id = (int)ViewState["_id"];
        if (id == 0)
        {
            user.AddNew();
        }
        else
        {
            user.LoadByPrimaryKey(id);
        }
        user.UserName = tbUsername.Text;
        if (NewPassword.Text.Length > 0)
        {
            user.Password = NewPassword.Text;
        }
        else
        {
            user.Password = tbPassword.Text;
        }
        user.Email = tbEmail.Text;
        user.UserLevel = int.Parse(ddUserLevel.SelectedValue);

        user.Save();


        // update the page access
        foreach (TableRow tr in Table1.Rows)
        {
            foreach (TableCell tc in tr.Cells)
            {
                try
                {
                    CheckBox cb = (CheckBox)tc.Controls[0];
                    tblUserPageAccess pxl = new tblUserPageAccess();
                    pxl.Where.UserId.Value = user.UserId;
                    pxl.Where.PageXLanguageId.Value = int.Parse(cb.ID);

                    pxl.Query.Load();

                    if (pxl.RowCount == 0)
                    {
                        // new 
                        pxl.AddNew();
                        pxl.UserId = user.UserId;
                        pxl.PageXLanguageId = int.Parse(cb.ID);
                    }

                    if (cb.Checked)
                        pxl.AccessLevel = (int)epicCMSLib.epicCMSAccessLevels.CmsUpdate;
                    else
                        pxl.AccessLevel = (int)epicCMSLib.epicCMSAccessLevels.ReadOnly;

                    pxl.Save();
                }
                catch
                {
                }
            }
        }

        // lbJs.Text = "<script type=\"text/javascript\" language=\"javascript\"> function clickButton() { var radWindow = GetRadWindow(); radWindow.Close(); } </script>";
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        int id = (int)ViewState["_id"];
        tblUsers user = new tblUsers();
        user.LoadByPrimaryKey(id);
        tbPassword.Text = user.Password;
        LinkButton1.Visible = false;
        changepass.Visible = true;
    }

}

