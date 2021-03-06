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

public partial class admin_controls_cms_selectAudio : System.Web.UI.UserControl
{
    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbDirectoryAudio.Text = "";
        }
        if (Request["langId"] != null)
        {
            ViewState["_langId"] = Convert.ToInt32(Request["langId"]);
        }
        if (ViewState["selcataudio"] != null)
            _selCatAudio = ViewState["selcataudio"].ToString();

        if (ViewState["selaudio"] != null)
            _selAudio = ViewState["selaudio"].ToString();


       
        if (!Page.IsPostBack)
        {

            Session["cataudio"] = null;
            Session["Filesaudio"] = null;
            getfolders(ref al, Server.MapPath("~/App_Uploads_Audio/"));
            getallfolders(ref al2, Server.MapPath("~/App_Uploads_Audio/"));
            try
            {

                string root = getTextVal().ToString();
                string cataudio = root.Substring(0, root.LastIndexOf("/"));
                ddCatAudio.SelectedValue = cataudio;
                ddFilesAudio.Enabled = true;
                getfiles(Server.MapPath("~/App_Uploads_Audio/") + ddCatAudio.SelectedItem.Value);
                ddFilesAudio.SelectedValue = root.Substring((cataudio.Length) + 1);

                getTemp();
                if ((ddFilesAudio.SelectedValue.Length > 0) && (ddFilesAudio.SelectedValue == "-1"))
                { atagAudio.Visible = false; }
                else
                { atagAudio.Visible = true;
                showaudio(ddCatAudio.SelectedItem.Value, ddFilesAudio.SelectedItem.Value);
            }
            }
            catch { }
        }

    }


    private void getfolders(ref ArrayList al, string dir)
    {

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Audio/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] Filesaudio = Directory.GetFiles(Server.MapPath("~/App_Uploads_Audio/") + foldername);

                if (Filesaudio.Length > 0)
                {
                    al.Add(foldername.Replace("\\", "/"));
                }

            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {

            getfolders(ref al, dir2);

        }

        ddCatAudio.DataSource = al;
        ddCatAudio.DataBind();
        ddCatAudio.Items.Insert(0, new ListItem("- Select a Folder -"));
    }

    private void getallfolders(ref ArrayList a2, string dir)
    {

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Audio/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] Filesaudio = Directory.GetFiles(Server.MapPath("~/App_Uploads_Audio/") + foldername);

                    al2.Add(foldername.Replace("\\", "/"));

            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {

            getallfolders(ref al2, dir2);

        }

        ddCatAudio.DataSource = al2;
        ddCatAudio.DataBind();


        ddCatAudio.Items.Insert(0, new ListItem("- Select a Folder -"));

        DropDownList1A.DataSource = al2;
        DropDownList1A.DataBind();
        DropDownList1A.Items.Insert(0, new ListItem("- Select a Folder -"));
    }

    private string _selCatAudio;
    private string _selAudio;
    public string AudioLoc
    {
        get
        {
            string cataudio = ddCatAudio.SelectedValue;
            return (cataudio + "/" + ddFilesAudio.SelectedValue);


        }
        set
        {
            if (value.Length > 0)
            {
                _selCatAudio = value.Substring(0, value.LastIndexOf("/"));
                _selAudio = value.Substring(value.LastIndexOf("/") + 1);
               
            }

        }
    }

    public void getfiles(string dir)
    {
        ddFilesAudio.Items.Clear();

        ListItem li1 = new ListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFilesAudio.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] Filesaudio = Directory.GetFiles(dir);
        foreach (string fileaudio in Filesaudio)
        {
            string appdir = Server.MapPath("~/App_Uploads_Audio/") + ddCatAudio.SelectedValue;
            string filename = fileaudio.Substring(appdir.Length + 1);

            if ((!filename.Contains("_svn")) && (!filename.Contains(".svn")))
            {
                if (filename.ToLower().Contains(".mp3"))
                {
                    ListItem li = new ListItem();
                    li.Text = filename;
                    li.Value = filename;
                    ddFilesAudio.Items.Add(li);
                }
            }
        }
        UpdatePanel1Audio.Update();

    }

    protected void ddCatAudio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCatAudio.SelectedIndex > 0)
        {
            ddFilesAudio.Enabled = true;
            getfiles(Server.MapPath("~/App_Uploads_Audio/") + ddCatAudio.SelectedItem.Value);
            UpdatePanel1Audio.Update();
        }
    }

    protected void ddFilesAudio_SelectedIndexChanged(object sender, EventArgs e)
    {
        showaudio(ddCatAudio.SelectedItem.Value, ddFilesAudio.SelectedItem.Value);

    }
    private void showaudio(string folder, string file)
    {
        atagAudio.Visible = true;
        atagAudio.HRef = "~/App_Uploads_Audio/" + folder.Replace("\\","/") + "/" + file;
        atagAudio.Title = file;

        UpdatePanel1Audio.Update();
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
            return _selCatAudio + "/" + _selAudio;
        }
    }


    protected void LinkButton1A_Click(object sender, EventArgs e)
    {
        RadUploadContext upContext = RadUploadContext.Current;
        string faudio = "";
        string diraudio = Server.MapPath("~/App_Uploads_Audio/");
        if (RadUploadAudio.UploadedFiles.Count > 0)
        {
           
            foreach (UploadedFile fileaudio in RadUploadAudio.UploadedFiles)
            {
                if (fileaudio.FileName.Contains("'"))
                {
                    faudio = fileaudio.FileName.Replace("'", "");
                }
                else 
                {
                    faudio = fileaudio.FileName;
                }
                if ((DropDownList1A.SelectedIndex == 0) && (tbDirectoryAudio.Text.Length == 0))
                {
                    Session["cataudio"] = null;
                    Session["Filesaudio"] = null;
                    TabPanel3Audio.Focus();
                }
                else if ((DropDownList1A.SelectedIndex == 0) && (tbDirectoryAudio.Text.Length > 0))
                {
                    Directory.CreateDirectory(diraudio + tbDirectoryAudio.Text);
                    fileaudio.SaveAs(Server.MapPath("~/App_Uploads_Audio/" + tbDirectoryAudio.Text + "/" + faudio), true);
                    Session["cataudio"] = tbDirectoryAudio.Text;
                    Session["Filesaudio"] = faudio;
                }

                else if ((DropDownList1A.SelectedIndex != 0) && (tbDirectoryAudio.Text.Length > 0))
                {
                    Directory.CreateDirectory(diraudio + DropDownList1A.SelectedItem.Text + "/" + tbDirectoryAudio.Text);
                    fileaudio.SaveAs(Server.MapPath("~/App_Uploads_Audio/" + DropDownList1A.SelectedItem.Text + "/" + tbDirectoryAudio.Text + "/" + faudio), true);
                    Session["cataudio"] = DropDownList1A.SelectedItem.Text + "/" + tbDirectoryAudio.Text;
                    Session["Filesaudio"] = faudio;

                }

                else if ((DropDownList1A.SelectedIndex > 0) && (tbDirectoryAudio.Text.Length == 0))
                {
                    fileaudio.SaveAs(Server.MapPath("~/App_Uploads_Audio/" + DropDownList1A.SelectedItem.Text + "/" + faudio), true);

                    Session["cataudio"] = DropDownList1A.SelectedItem.Text;
                    Session["Filesaudio"] = faudio;

                }
                GC.Collect();
            }
        }

        getfolders(ref al, Server.MapPath("~/App_Uploads_Audio/"));
        getallfolders(ref al2, Server.MapPath("~/App_Uploads_Audio/"));

       
        UpdatePanel1Audio.Update();
        UpdatePanel2Audio.Update();
        getcontent();
    }
    protected void getcontent()
    {
        if ((Session["cataudio"] != null) && (Session["Filesaudio"] != null))
        {

            ddCatAudio.SelectedValue = Session["cataudio"].ToString().Replace("\\", "/");
            getfiles(Server.MapPath("~/App_Uploads_Audio/") + ddCatAudio.SelectedValue);
            ddFilesAudio.SelectedValue = Session["Filesaudio"].ToString();
            showaudio(ddCatAudio.SelectedItem.Value, ddFilesAudio.SelectedItem.Value);
        }
        UpdatePanel1Audio.Update();
    

    }
}
