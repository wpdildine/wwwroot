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

public partial class admin_controls_cms_selectDocument : System.Web.UI.UserControl
{
    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbDirectoryDocument.Text = "";
        }
        if (Request["langId"] != null)
        {
            ViewState["_langId"] = Convert.ToInt32(Request["langId"]);
        }
        if (ViewState["selcatdocument"] != null)
            _selCatDocument = ViewState["selcatdocument"].ToString();

        if (ViewState["seldocument"] != null)
            _selDocument = ViewState["seldocument"].ToString();


       
        if (!Page.IsPostBack)
        {

            Session["catdocument"] = null;
            Session["Filesdocument"] = null;
            getfolders(ref al, Server.MapPath("~/App_Uploads_Docs/"));
            getallfolders(ref al2, Server.MapPath("~/App_Uploads_Docs/"));
            try
            {

                string root = getTextVal().ToString();
                string catdocument = root.Substring(0, root.LastIndexOf("/"));
                ddCatDocument.SelectedValue = catdocument;
                ddFilesDocument.Enabled = true;
                getfiles(Server.MapPath("~/App_Uploads_Docs/") + ddCatDocument.SelectedItem.Value);
                ddFilesDocument.SelectedValue = root.Substring((catdocument.Length) + 1);

                getTemp();
                if ((ddFilesDocument.SelectedValue.Length > 0) && (ddFilesDocument.SelectedValue == "-1"))
                { atagDocument.Visible = false; }
                else
                { atagDocument.Visible = true;
                showdocument(ddCatDocument.SelectedItem.Value, ddFilesDocument.SelectedItem.Value);
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
            string appdir = Server.MapPath("~/App_Uploads_Docs/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] Filesdocument = Directory.GetFiles(Server.MapPath("~/App_Uploads_Docs/") + foldername);

                if (Filesdocument.Length > 0)
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

        //ddCatDocument.DataSource = al;
        //ddCatDocument.DataBind();
        ddCatDocument.Items.Clear();
        foreach (string a in al)
            ddCatDocument.Items.Add(new Telerik.Web.UI.DropDownListItem(a, a));
        ddCatDocument.Items.Insert(0, new Telerik.Web.UI.DropDownListItem("- Select a Folder -"));
    }

    private void getallfolders(ref ArrayList a2, string dir)
    {

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Docs/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] Filesdocument = Directory.GetFiles(Server.MapPath("~/App_Uploads_Docs/") + foldername);

                    al2.Add(foldername.Replace("\\", "/"));

            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {

            getallfolders(ref al2, dir2);

        }

        //DropDownList1D.DataSource = al2;
        //DropDownList1D.DataBind();
        DropDownList1D.Items.Clear();
        foreach (string a in al2)
            DropDownList1D.Items.Add(new Telerik.Web.UI.DropDownListItem(a, a));
        DropDownList1D.Items.Insert(0, new Telerik.Web.UI.DropDownListItem("- Select a Folder -"));
    }

    private string _selCatDocument;
    private string _selDocument;
    public string DocLoc
    {
        get
        {
            string catdocument = ddCatDocument.SelectedValue;
            return (catdocument + "/" + ddFilesDocument.SelectedValue);


        }
        set
        {
            if (value.Length > 0)
            {
                _selCatDocument = value.Substring(0, value.LastIndexOf("/"));
                _selDocument = value.Substring(value.LastIndexOf("/") + 1);
               
            }

        }
    }

    public void getfiles(string dir)
    {
        ddFilesDocument.Items.Clear();

        Telerik.Web.UI.DropDownListItem li1 = new Telerik.Web.UI.DropDownListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFilesDocument.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] Filesdocument = Directory.GetFiles(dir);
        foreach (string filedocument in Filesdocument)
        {
            string appdir = Server.MapPath("~/App_Uploads_Docs/") + ddCatDocument.SelectedValue;
            string filename = filedocument.Substring(appdir.Length + 1);

            if ((!filename.Contains("_svn")) && (!filename.Contains(".svn")))
            {
                if (filename.ToLower().Contains(".doc") || filename.ToLower().Contains(".zip") || filename.ToLower().Contains(".pdf") || filename.ToLower().Contains(".vcf") || filename.ToLower().Contains(".xls"))
                {
                    Telerik.Web.UI.DropDownListItem li = new Telerik.Web.UI.DropDownListItem();
                    li.Text = filename;
                    li.Value = filename;
                    ddFilesDocument.Items.Add(li);
                }
            }
        }
        UpdatePanel1Document.Update();

    }

    protected void ddCatDocument_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCatDocument.SelectedIndex > 0)
        {
            ddFilesDocument.Enabled = true;
            getfiles(Server.MapPath("~/App_Uploads_Docs/") + ddCatDocument.SelectedItem.Value);
            UpdatePanel1Document.Update();
        }
    }

    protected void ddFilesDocument_SelectedIndexChanged(object sender, EventArgs e)
    {
        showdocument(ddCatDocument.SelectedItem.Value, ddFilesDocument.SelectedItem.Value);

    }
    private void showdocument(string folder, string file)
    {
        atagDocument.Visible = true;
        atagDocument.HRef = "~/App_Uploads_Docs/" + folder.Replace("\\","/") + "/" + file;
        atagDocument.Title = file;

        UpdatePanel1Document.Update();
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
            return _selCatDocument + "/" + _selDocument;
        }
    }


    protected void LinkButton1A_Click(object sender, EventArgs e)
    {
        RadUploadContext upContext = RadUploadContext.Current;
        string fdocument = "";
        string dirdocument = Server.MapPath("~/App_Uploads_Docs/");
        if (RadUploadDocument.UploadedFiles.Count > 0)
        {
           
            foreach (Telerik.Web.UI.UploadedFile filedocument in RadUploadDocument.UploadedFiles)
            {
                fdocument = filedocument.GetName();
                if (fdocument.Contains("'"))
                {
                    fdocument = fdocument.Replace("'", "");
                }

                if ((DropDownList1D.SelectedIndex == 0) && (tbDirectoryDocument.Text.Length == 0))
                {
                    Session["catdocument"] = null;
                    Session["Filesdocument"] = null;
                    TabPanel3Document.Focus();
                }
                else if ((DropDownList1D.SelectedIndex == 0) && (tbDirectoryDocument.Text.Length > 0))
                {
                    Directory.CreateDirectory(dirdocument + tbDirectoryDocument.Text);
                    if(!File.Exists(Server.MapPath("~/App_Uploads_Docs/" + tbDirectoryDocument.Text + "/" + fdocument)))
                        filedocument.SaveAs(Server.MapPath("~/App_Uploads_Docs/" + tbDirectoryDocument.Text + "/" + fdocument), true);
                    Session["catdocument"] = tbDirectoryDocument.Text;
                    Session["Filesdocument"] = fdocument;
                }

                else if ((DropDownList1D.SelectedIndex != 0) && (tbDirectoryDocument.Text.Length > 0))
                {
                    Directory.CreateDirectory(dirdocument + DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDocument.Text);
                    if (!File.Exists(Server.MapPath("~/App_Uploads_Docs/" + DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDocument.Text + "/" + fdocument)))
                        filedocument.SaveAs(Server.MapPath("~/App_Uploads_Docs/" + DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDocument.Text + "/" + fdocument), true);
                    Session["catdocument"] = DropDownList1D.SelectedItem.Text + "/" + tbDirectoryDocument.Text;
                    Session["Filesdocument"] = fdocument;

                }

                else if ((DropDownList1D.SelectedIndex > 0) && (tbDirectoryDocument.Text.Length == 0))
                {
                    if(!File.Exists(Server.MapPath("~/App_Uploads_Docs/" + DropDownList1D.SelectedItem.Text + "/" + fdocument)))
                        filedocument.SaveAs(Server.MapPath("~/App_Uploads_Docs/" + DropDownList1D.SelectedItem.Text + "/" + fdocument), true);

                    Session["catdocument"] = DropDownList1D.SelectedItem.Text;
                    Session["Filesdocument"] = fdocument;

                }
                GC.Collect();
            }
        }

        getfolders(ref al, Server.MapPath("~/App_Uploads_Docs/"));
        getallfolders(ref al2, Server.MapPath("~/App_Uploads_Docs/"));

       
        //UpdatePanel1Document.Update();
        //UpdatePanel2Document.Update();
        getcontent();
    }
    protected void getcontent()
    {
        if ((Session["catdocument"] != null) && (Session["Filesdocument"] != null))
        {

            ddCatDocument.SelectedValue = Session["catdocument"].ToString().Replace("\\", "/");
            getfiles(Server.MapPath("~/App_Uploads_Docs/") + ddCatDocument.SelectedValue);
            ddFilesDocument.SelectedValue = Session["Filesdocument"].ToString();
            showdocument(ddCatDocument.SelectedItem.Value, ddFilesDocument.SelectedItem.Value);
        }
        UpdatePanel1Document.Update();
    

    }
}
