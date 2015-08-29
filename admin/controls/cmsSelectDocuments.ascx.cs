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

public partial class admin_controls_cmsSelectDocuments : System.Web.UI.UserControl
{
    ArrayList al = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbDirectoryDoc.Text = "";
        }
        if (Request["langId"] != null)
        {
            ViewState["_langId"] = Convert.ToInt32(Request["langId"]);
        }
        if (ViewState["selcatdoc"] != null)
            _selCatDoc = ViewState["selcatdoc"].ToString();

        if (ViewState["seldoc"] != null)
            _selDoc = ViewState["seldoc"].ToString();

     

        if (!Page.IsPostBack)
        {

            Session["catdoc"] = null;
            Session["Filesdoc"] = null;
            getfolders(ref al, Server.MapPath("~/App_Uploads_Docs/"));
            try
            {

                string root = getTextVal().ToString();
                string catdoc = root.Substring(0, root.LastIndexOf("/"));
                ddCatDoc.SelectedValue = catdoc;
                ddFilesDoc.Enabled = true;
                getfiles(Server.MapPath("~/App_Uploads_Docs/") + ddCatDoc.SelectedItem.Value);
                ddFilesDoc.SelectedValue = root.Substring((catdoc.Length) + 1);
                getTemp();
                if ((ddFilesDoc.SelectedValue.Length > 0) && (ddFilesDoc.SelectedValue == "-1"))
                { atagDoc.Visible = false; }
                else
                { atagDoc.Visible = true; }
            }
            catch { }
        }

    }


    private void getfolders(ref ArrayList al, string dir)
    {

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Docs/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] Filesdoc = Directory.GetFiles(Server.MapPath("~/App_Uploads_Docs/") + foldername);

                if (Filesdoc.Length > 0)
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

        ddCatDoc.DataSource = al;
        ddCatDoc.DataBind();


        ddCatDoc.Items.Insert(0, new ListItem("- Select a Folder -"));

        DropDownList1D.DataSource = al;
        DropDownList1D.DataBind();
        DropDownList1D.Items.Insert(0, new ListItem("- Select a Folder -"));
    }



    private string _selCatDoc;
    private string _selDoc;
    public string DocLoc
    {
        get
        {
            string catdoc = ddCatDoc.SelectedValue;
            return (catdoc + "/" + ddFilesDoc.SelectedValue);


        }
        set
        {
            if (value.Length > 0)
            {
                _selCatDoc = value.Substring(0, value.LastIndexOf("/"));
                _selDoc = value.Substring(value.LastIndexOf("/") + 1);
            }
        }
    }

    public void getfiles(string dir)
    {
        ddFilesDoc.Items.Clear();

        ListItem li1 = new ListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFilesDoc.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] Filesdoc = Directory.GetFiles(dir);
        foreach (string file in Filesdoc)
        {
            string appdir = Server.MapPath("~/App_Uploads_Docs/") + ddCatDoc.SelectedValue;
            string filename = file.Substring(appdir.Length + 1);

            if ((!filename.Contains("_svn")) && (!filename.Contains(".svn")))
            {
                if (filename.ToLower().Contains(".zip")||filename.ToLower().Contains(".doc") || filename.ToLower().Contains(".pdf") || filename.ToLower().Contains(".xls"))
                {
                    ListItem li = new ListItem();
                    li.Text = filename;
                    li.Value = filename;
                    ddFilesDoc.Items.Add(li);
                }
            }
        }
        UpdatePanel1Doc.Update();

    }

    protected void ddCatDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCatDoc.SelectedIndex > 0)
        {
            ddFilesDoc.Enabled = true;
            getfiles(Server.MapPath("~/App_Uploads_Docs/") + ddCatDoc.SelectedItem.Value);
            UpdatePanel1Doc.Update();
        }
    }

    protected void ddFilesDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        showdoc(ddCatDoc.SelectedItem.Value, ddFilesDoc.SelectedItem.Value);

    }
    private void showdoc(string folder, string file)
    {
        atagDoc.Visible = true;
        atagDoc.HRef = "~/App_Uploads_Docs/" + folder + "/" + file;
        atagDoc.Title = file;
        
        UpdatePanel1Doc.Update();
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
            return _selCatDoc + "/" + _selDoc;
        }
    }


    protected void LinkButton1D_Click(object sender, EventArgs e)
    {
        RadUploadContext upContext = RadUploadContext.Current;

        string dirdoc = Server.MapPath("~/App_Uploads_Docs/");
        if (RadUploadDoc.UploadedFiles.Count > 0)
        {
            foreach (UploadedFile filedoc in RadUploadDoc.UploadedFiles)
            {
                if ((DropDownList1D.SelectedIndex == 0) && (tbDirectoryDoc.Text.Length == 0))
                {
                    Session["catdoc"] = null;
                    Session["Filesdoc"] = null;
                    TabPanel3Docs.Focus();
                }
                else if ((DropDownList1D.SelectedIndex == 0) && (tbDirectoryDoc.Text.Length > 0))
                {
                    Directory.CreateDirectory(dirdoc + tbDirectoryDoc.Text);
                    filedoc.SaveAs(Server.MapPath("~/App_Uploads_Docs/" + tbDirectoryDoc.Text + "/" + filedoc.GetName()), true);
                    Session["catdoc"] = tbDirectoryDoc.Text;
                    Session["Filesdoc"] = filedoc.GetName();
                }

                else if ((DropDownList1D.SelectedIndex != 0) && (tbDirectoryDoc.Text.Length > 0))
                {
                    Directory.CreateDirectory(dirdoc + DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDoc.Text);
                    filedoc.SaveAs(Server.MapPath("~/App_Uploads_Docs/" + DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDoc.Text + "/" + filedoc.GetName()), true);
                    Session["catdoc"] = DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDoc.Text;
                    Session["Filesdoc"] = filedoc.GetName();

                }

                else if ((DropDownList1D.SelectedIndex > 0) && (tbDirectoryDoc.Text.Length == 0))
                {
                    filedoc.SaveAs(Server.MapPath("~/App_Uploads_Docs/" + DropDownList1D.SelectedItem.Text + "/" + filedoc.GetName()), true);

                    Session["catdoc"] =DropDownList1D.SelectedItem.Text;
                    Session["Filesdoc"] = filedoc.GetName();

                }
            }
        }


        getfolders(ref al, Server.MapPath("~/App_Uploads_Docs/"));
          
        UpdatePanel1Doc.Update();
        UpdatePanel2Doc.Update();
        getcontentdoc();
    }
    protected void getcontentdoc()
    {
        if ((Session["catdoc"] != null) && (Session["Filesdoc"] != null))
        {
            ddCatDoc.SelectedValue = Session["catdoc"].ToString().Replace("\\", "/");
            getfiles(Server.MapPath("~/App_Uploads_Docs/") + ddCatDoc.SelectedValue);
            ddFilesDoc.SelectedValue = Session["Filesdoc"].ToString();
            showdoc(ddCatDoc.SelectedValue, ddFilesDoc.SelectedValue);
        }

        UpdatePanel1Doc.Update();   

    
    }

}
