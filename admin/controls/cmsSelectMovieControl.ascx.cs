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
using System.IO;
using epicCMS;

public partial class admin_controls_cmsSelectMovieControl : System.Web.UI.UserControl
{
    ArrayList al = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        tbDirectoryMovie.Text = "";
        if (Request["langId"] != null)
        {
            ViewState["_langId"] = Convert.ToInt32(Request["langId"]);
        }
        if (ViewState["selcat"] != null)
            _selCatMovie = ViewState["selcat"].ToString();

        if (ViewState["selimg"] != null)
            _selMov = ViewState["selimg"].ToString();

     

        if (!Page.IsPostBack)
        {

            Session["catmovie"] = null;
            Session["Filesmovie"] = null;
            getfolders(ref al, Server.MapPath("~/App_Uploads_Movies/"));
            try
            {

                string root = getTextVal().ToString();
                string catmovie = root.Substring(0, root.LastIndexOf("/"));
                ddCatMovie.SelectedValue = catmovie;
                ddFilesMovie.Enabled = true;
                getfiles(Server.MapPath("~/App_Uploads_Movies/") + ddCatMovie.SelectedItem.Value);
                ddFilesMovie.SelectedValue = root.Substring((catmovie.Length) + 1);
        
                getTemp();
                if ((ddFilesMovie.SelectedValue.Length > 0)&&(ddFilesMovie.SelectedValue =="-1"))
                { atagMovie.Visible = false; }
                else
                { atagMovie.Visible = true; }
            }
            catch { }
        }

    }


    private void getfolders(ref ArrayList al, string dir)
    {

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Movies/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] Filesmovie = Directory.GetFiles(Server.MapPath("~/App_Uploads_Movies/") + foldername);

                if (Filesmovie.Length > 0)
                {
                    al.Add(foldername);
                }

            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {

            getfolders(ref al, dir2);

        }

        ddCatMovie.DataSource = al;
        ddCatMovie.DataBind();


        ddCatMovie.Items.Insert(0, new ListItem("- Select a Folder -"));

        DropDownList1M.DataSource = al;
        DropDownList1M.DataBind();
        DropDownList1M.Items.Insert(0, new ListItem("- Select a Folder -"));
    }



    private string _selCatMovie;
    private string _selMov;
    public string MovieLoc
    {
        get
        {
            string catmovie = ddCatMovie.SelectedValue.Replace("\\", "/");
            return (catmovie + "/" + ddFilesMovie.SelectedValue);


        }
        set
        {
            if (value.Length > 0)
            {
                _selCatMovie = value.Substring(0, value.LastIndexOf("/")).Replace("/", "\\");
                _selMov = value.Substring(value.LastIndexOf("/") + 1);
            }
            
        }
    }

    public void getfiles(string dir)
    {
        ddFilesMovie.Items.Clear();

        ListItem li1 = new ListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFilesMovie.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] Filesmovie = Directory.GetFiles(dir);
        foreach (string file in Filesmovie)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/") + ddCatMovie.SelectedValue;
            string filename = file.Substring(appdir.Length + 1);

            if ((!filename.Contains("_svn")) && (!filename.Contains(".svn")))
            {
                if (filename.ToLower().Contains(".mov") || filename.ToLower().Contains(".flv") || filename.ToLower().Contains(".wmv") )
                {
                    ListItem li = new ListItem();
                    li.Text = filename;
                    li.Value = filename;
                    ddFilesMovie.Items.Add(li);
                }
            }
        }
        UpdatePanel1Movie.Update();

    }

    protected void ddCatMovie_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCatMovie.SelectedIndex > 0)
        {
            ddFilesMovie.Enabled = true;
            getfiles(Server.MapPath("~/App_Uploads_Movies/") + ddCatMovie.SelectedItem.Value);
            UpdatePanel1Movie.Update();
        }
    }

    protected void ddFilesMovie_SelectedIndexChanged(object sender, EventArgs e)
    {
        showmovie(ddCatMovie.SelectedItem.Value, ddFilesMovie.SelectedItem.Value);

    }
    private void showmovie(string folder, string file)
    {
        if (file.Substring(0, file.LastIndexOf(".") + 1) != "flv")
        {
            atagMovie.Visible = true;
            atagMovie.HRef = "~/App_Uploads_Movies/" + folder + "/" + file;
            atagMovie.Title = file;

            UpdatePanel1Movie.Update();
        }
    }
  
    private void getTemp()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 3;

        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        try
        {
            int ret = val.ItemFieldStringTempId;
            _temp = true;
        }
        catch
        {
            _temp = false;
        }
    }

    private int _itemId;

    private bool _temp = false;
    public bool IsTemp()
    {
        getTemp();
        return _temp;
    }

    private string getTextVal()
    {
        if (_itemId > 0)
        {
            tblItemFieldsXValue val = new tblItemFieldsXValue();
            //val.Where.ItemId.Value = _itemId;
            val.Where.ItemId.Value = _itemId;

            // hard coded
            val.Where.ItemFieldId.Value = 3;
            val.Where.LanguageId.Value = (int)ViewState["_langId"];

            val.Query.Load();

            tblItemFieldStringValues txt = new tblItemFieldStringValues();

            if (val.ItemFieldStringTempId > -1)
            {
                txt.LoadByPrimaryKey(val.ItemFieldStringTempId);
            }
            else
            {
                txt.LoadByPrimaryKey(val.ItemFieldStringId);
            }

            return txt.ItemFieldValue;
        }
        else
        {
            return _selCatMovie + "/" + _selMov;
        }
    }


    protected void LinkButton1M_Click(object sender, EventArgs e)
    {
        RadUploadContext upContext = RadUploadContext.Current;
        string moviefile = "";
        string dir = Server.MapPath("~/App_Uploads_Movies/");
        if (RadUploadMovie.UploadedFiles.Count > 0)
        {
            foreach (UploadedFile filemov in RadUploadMovie.UploadedFiles)
            {
                if (filemov.FileName.Contains("'"))
                {
                    moviefile = filemov.FileName.Replace("'", "");
                }
                else
                {
                    moviefile = filemov.FileName;
                }
                if ((DropDownList1M.SelectedIndex == 0) && (tbDirectoryMovie.Text.Length == 0))
                {
                    Session["catmovie"] = null;
                    Session["Filesmovie"] = null;
                    TabPanel3Movie.Focus();
                }
                else if ((DropDownList1M.SelectedIndex == 0) && (tbDirectoryMovie.Text.Length > 0))
                {
                    Directory.CreateDirectory(dir + tbDirectoryMovie.Text);
                    filemov.SaveAs(Server.MapPath("~/App_Uploads_Movies/" + tbDirectoryMovie.Text + "/" + moviefile), true);
                    Session["catmovie"] = tbDirectoryMovie.Text;
                    Session["Filesmovie"] = moviefile;
                }

                else if ((DropDownList1M.SelectedIndex != 0) && (tbDirectoryMovie.Text.Length > 0))
                {
                    Directory.CreateDirectory(dir + DropDownList1M.SelectedItem.Text + "/" + tbDirectoryMovie.Text);
                    filemov.SaveAs(Server.MapPath("~/App_Uploads_Movies/" + DropDownList1M.SelectedItem.Text + "/" + tbDirectoryMovie.Text + "/" + moviefile), true);
                    Session["catmovie"] = DropDownList1M.SelectedItem.Text + "/" + tbDirectoryMovie.Text;
                    Session["Filesmovie"] = moviefile;

                }

                else if ((DropDownList1M.SelectedIndex > 0) && (tbDirectoryMovie.Text.Length == 0))
                {
                    filemov.SaveAs(Server.MapPath("~/App_Uploads_Movies/" + DropDownList1M.SelectedItem.Text + "/" + moviefile), true);

                    Session["catmovie"] = DropDownList1M.SelectedItem.Text;
                    Session["Filesmovie"] = moviefile;

                }
            }
        }


        getfolders(ref al, Server.MapPath("~/App_Uploads_Movies/"));

        if ((Session["catmovie"] != null) && (Session["Filesmovie"] != null))
        {
            ddCatMovie.SelectedValue = Session["catmovie"].ToString().Replace("\\", "/");
            getfiles(Server.MapPath("~/App_Uploads_Movies/") + ddCatMovie.SelectedValue);
            ddFilesMovie.SelectedValue = Session["Filesmovie"].ToString();
            showmovie(ddCatMovie.SelectedValue, ddFilesMovie.SelectedValue);
        }

        UpdatePanel1Movie.Update();
        UpdatePanel2Movie.Update();
    }
}
