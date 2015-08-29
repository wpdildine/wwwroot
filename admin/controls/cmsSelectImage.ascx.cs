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
using epicCMS;
using AjaxControlToolkit;

public partial class admin_controls_cmsSelectImage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Request["langId"] != null)
        {
            ViewState["_langId"] = Convert.ToInt32(Request["langId"]);
        }
        if (ViewState["selcat"] != null)
            _selCat = ViewState["selcat"].ToString();

        if (ViewState["selimg"] != null)
            _selImg = ViewState["selimg"].ToString();

        if (!Page.IsPostBack)
        {
            ArrayList al = new ArrayList();
            getfolders(ref al, Server.MapPath("~/App_Uploads_Img/"));
            try
            {

                if ((getTextVal().Contains("Select a Folder")) || (getTextVal().Length <= 0) || (getTextVal()==""))
                { Image1.ImageUrl = "~/images/spacer.gif"; }
                else
                { Image1.ImageUrl = epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + getTextVal(); }
                string root = getTextVal().ToString();
                string cat = root.Substring(0, root.LastIndexOf("/"));
                ddCat.SelectedValue = cat;
                ddFiles.Enabled = true;
                getfiles(Server.MapPath("~/App_Uploads_Img/") + ddCat.SelectedItem.Value);
                ddFiles.SelectedValue = root.Substring((cat.Length) + 1);
                getTemp();
            }
            catch { }
        }
       
    }
    #region
    //private void loadImages()
    //{
    //    tblImageCategories cats = new tblImageCategories();
    //    cats.Where.LanguageId.Value = Convert.ToInt32(Request["langid"]);

    //    cats.Query.Load();

    //    cats.Sort = "ImageCategoryTitle ASC";

    //    if (cats.RowCount > 0)
    //    {
    //        ddCat.Items.Clear();
    //        ddCat.Items.Add(new ListItem("--Select--", "-1"));

    //        cats.Rewind();

    //        do
    //        {
    //            ListItem lic = new ListItem();
    //            lic.Text = cats.ImageCategoryTitle;
    //            lic.Value = cats.ImageCategoryId.ToString();

    //            if (_selCat == cats.ImageCategoryId)
    //            {
    //                lic.Selected = true;
    //            }
    //            ddCat.Items.Add(lic);


    //        } while (cats.MoveNext());

    //    }
    //}

    //public void SaveValue()
    //{
    //   // tblItems itm = new tblItems();
    //   // itm.LoadByPrimaryKey(_itemId);

    //    tblItemFieldsXValue val = new tblItemFieldsXValue();
    //    val.Where.ItemId.Value = _itemId;
    //    val.Where.ItemFieldId.Value = 3;
    //    val.Where.LanguageId.Value = int.Parse(Request["langId"]);

    //    val.Query.Load();

    //    //val.ItemFieldImageAssetId = Int32.Parse(DropDownList1.SelectedValue);
    //    if (val.ItemFieldImageAssetId != Int32.Parse(DropDownList1.SelectedValue))
    //        val.ItemFieldImageAssetTempId = Int32.Parse(DropDownList1.SelectedValue);
    //    val.Save();
    //}

    //public void RejectChange()
    //{
    //    tblItemFieldsXValue val = new tblItemFieldsXValue();
    //    val.Where.ItemId.Value = _itemId;

    //    // hard coded
    //    val.Where.ItemFieldId.Value = 3;
    //    val.Where.LanguageId.Value = int.Parse(Request["langId"]);

    //    val.Query.Load();

    //    val.s_ItemFieldImageAssetTempId = "";
    //    val.Save();
    //}

    //public void ApproveChange()
    //{
    //    tblItemFieldsXValue val = new tblItemFieldsXValue();
    //    val.Where.ItemId.Value = _itemId;

    //    // hard coded
    //    val.Where.ItemFieldId.Value = 3;
    //    val.Where.LanguageId.Value = int.Parse(Request["langId"]);

    //    val.Query.Load();

    //    val.ItemFieldImageAssetId = val.ItemFieldImageAssetTempId;
    //    val.s_ItemFieldImageAssetTempId = "";

    //    val.Save();
    //}

    //private bool _temp;
    //public bool IsTemp()
    //{
    //    getTemp();
    //    return _temp;
    //}
    //private void getTemp()
    //{
    //    tblItemFieldsXValue val = new tblItemFieldsXValue();
    //    val.Where.ItemId.Value = _itemId;

    //    // hard coded
    //    val.Where.ItemFieldId.Value = 3;
    //    val.Where.LanguageId.Value = int.Parse(Request["langId"]);

    //    val.Query.Load();

    //    try
    //    {
    //        int ret = val.ItemFieldImageAssetTempId;
    //        _temp = true;
    //    }
    //    catch
    //    {
    //        _temp = false;
    //    }
    //}

    //private int _imageId=-1;
    //public int ImageId
    //{
    //    get { return _imageId; }
    //    set
    //    {
    //        _imageId = value;
    //        ViewState["myimg"] = _imageId;
    //    }
    //}

    //private int _selCat=-1;
    //private int _itemId=-1;
    //public int ItemId
    //{
    //    get { return _itemId; }
    //    set
    //    {
    //        _itemId = value;
    //    }
    //}
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DropDownList1.SelectedIndex > 0)
    //    {
    //        _imageId = Int32.Parse(DropDownList1.SelectedValue);
    //        _itemId = -1;
    //        //Image1.ImageUrl = "~/renderimage.aspx?imageid=" + DropDownList1.SelectedValue + "&hei=100";
    //        ViewState["myimg"] = _imageId;
    //    }
    //    else
    //    {
    //        _imageId = -1;
    //        _itemId = -1;
    //        ViewState["myimg"] = -1;
    //    }
    //    displayImage();

    //}
    //protected void ddCat_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    _itemId = -1;
    //    _imageId = -1;
    //    displayImageDD();
    //}

    //private void displayImage()
    //{
    //    if (_itemId > -1)
    //    {
    //        tblItemFieldsXValue val = new tblItemFieldsXValue();
    //        val.Where.ItemId.Value = _itemId;
    //        val.Where.LanguageId.Value = Convert.ToInt32(Request["langid"]);
    //        val.Where.ItemFieldId.Value = 3;

    //        val.Query.Load();

    //        if (val.RowCount == 0)
    //        {
    //            val.AddNew();
    //            val.ItemId = _itemId;
    //            val.ItemFieldId = 3;
    //            val.LanguageId = int.Parse(Request["langId"]);
    //            val.ItemFieldImageAssetId = -1;
    //            val.ItemFieldImageAssetTempId = -1;

    //            val.Save();
    //        }

    //        try
    //        {
    //            Image1.ImageUrl = "~/renderimage.aspx?imageid=" + val.ItemFieldImageAssetTempId.ToString() + "&hei=100";
    //        }
    //        catch
    //        {
    //            try
    //            {
    //                Image1.ImageUrl = "~/renderimage.aspx?imageid=" + val.ItemFieldImageAssetId.ToString() + "&hei=100";
    //            }
    //            catch
    //            {
    //                Image1.ImageUrl = "";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (_imageId > -1)
    //            Image1.ImageUrl = "~/renderimage.aspx?imageId=" + _imageId.ToString() + "&hei=100";
    //        else
    //            Image1.ImageUrl = "~/App_images/spacer.gif";
    //    }
    //}

    //private void setSelectedCat()
    //{
    //    int img = getSelected();

    //    if (img > -1)
    //    {
    //        tblImageAssets imga = new tblImageAssets();
    //        imga.Where.ImageAssetId.Value = img;

    //        imga.Query.Load();

    //        if (imga.RowCount > 0)
    //        {
    //            _selCat = imga.ImageCategory;
    //        }
    //    }

    //    loadImages();

    //    displayImageDD();
    //}

    //private int getSelected()
    //{
    //    //tblImageAssets assets = new tblImageAssets();
    //    //assets.Where.ImageCategory.Value = Convert.ToInt32(ddCat.SelectedValue);

    //    //assets.Query.Load();

    //    int sel = -1;
    //    if (_itemId > -1)
    //    {
    //        tblItems itm = new tblItems();
    //        itm.LoadByPrimaryKey(_itemId);

    //        tblItemFieldsXValue val = new tblItemFieldsXValue();
    //        val.Where.ItemId.Value = _itemId;
    //        val.Where.ItemFieldId.Value = 3;
    //        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

    //        val.Query.Load();

    //        if (val.RowCount > 0)
    //        {
    //            val.Rewind();
    //            try
    //            {
    //                sel = val.ItemFieldImageAssetTempId;
    //            }
    //            catch
    //            {
    //                sel = val.ItemFieldImageAssetId;
    //            }
    //        }
    //    }
    //    if (_imageId > -1)
    //    {
    //        sel = _imageId;
    //    }

    //    return sel;
    //}

    //private void displayImageDD()
    //{
    //    if (ddCat.SelectedIndex > 0)
    //    {
    //        tblImageAssets assets = new tblImageAssets();
    //        assets.Where.ImageCategory.Value = Convert.ToInt32(ddCat.SelectedValue);

    //        assets.Query.Load();

    //        int sel = getSelected();

    //        DropDownList1.Items.Clear();
    //        ListItem li2 = new ListItem("--Select--");
    //        DropDownList1.Items.Add(li2);
    //        if (assets.RowCount > 0)
    //        {
    //            assets.Rewind();
    //            do
    //            {
    //                ListItem li = new ListItem(assets.ImageTitle, assets.ImageAssetId.ToString());

    //                if (sel == assets.ImageAssetId)
    //                {
    //                    li.Selected = true;
    //                }
    //                DropDownList1.Items.Add(li);
    //            } while (assets.MoveNext());
    //        }
    //    }
    //    else
    //    {
    //        DropDownList1.Items.Clear();
    //        DropDownList1.Items.Add(new ListItem("None", "-1"));
    //        _imageId = -1;
    //        ViewState["myimg"] = -1;
    //    }
    //    displayImage();

    //}
    #endregion

    private void getfolders(ref ArrayList al, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) || (!foldername.Contains(".svn")))
            {
                string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);

                if (files.Length > 0)
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
 
        ddCat.DataSource = al;
        ddCat.DataBind();

       
         ddCat.Items.Insert(0, new ListItem("- Select a Folder -"));
        
    }

 

    private string _selCat;
    private string _selImg;
    public string ImageLoc
    {
        get 
        {
            string cat = ddCat.SelectedValue.Replace("\\", "/");
            return (cat + "/" + ddFiles.SelectedValue);
            
           
        }
        set
        {
            if (value.Length > 0)
            {
                _selCat = value.Substring(0, value.LastIndexOf("/")).Replace("/","\\");
                _selImg = value.Substring(value.LastIndexOf("/") + 1);
            }
        }
    }

    public void getfiles(string dir)
    {
        ddFiles.Items.Clear();

        ListItem li1 = new ListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFiles.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] files = Directory.GetFiles(dir);
        foreach (string file in files)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Value + "/");
            string filename = file.Substring(appdir.Length);

            if (!filename.Contains("_svn"))
            {
                ListItem li = new ListItem();
                li.Text = filename;
                li.Value = filename;
                ddFiles.Items.Add(li);
            }
        }
        UpdatePanel1.Update();
        
        //DropDownList1.Items.Insert(0, new RadComboBoxItem("- Select a Files -"));
        //DropDownList1.Items.Insert(0,new ListItem("- Select a Files -"));
        //PlaceHolder1.Controls.Add(DropDownList1);

    }

    protected void ddCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCat.SelectedIndex > 0)
        {
            ddFiles.Enabled = true;
            getfiles(Server.MapPath("~/App_Uploads_Img/") + ddCat.SelectedItem.Value);
            UpdatePanel1.Update();
        }
    }
   
    protected void ddFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Image1.ImageUrl = "";
        Image1.ImageUrl = "~/App_Uploads_Img/" + ddCat.SelectedItem.Value + "/" + (ddFiles.SelectedItem.Value);
        //Response.Write("~/App_Uploads_Img/" + ddCat.SelectedItem.Value.Replace("'\'", "'/'") + "/" + ddFiles.SelectedItem.Value);
        UpdatePanel1.Update();
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
            return _selCat + "/" + _selImg;
        }
    }

    public void RejectChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 3;
        val.Where.LanguageId.Value = (int)ViewState["_langId"];

        val.Query.Load();

        // load the temp
        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        txt.LoadByPrimaryKey(val.ItemFieldStringTempId);

        val.ItemFieldStringTempId = -1;
        txt.MarkAsDeleted();
        txt.Save();
        val.Save();
    }

    public void ApproveChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 3;
        val.Where.LanguageId.Value = (int)ViewState["_langId"];

        val.Query.Load();

        // load the temp
        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        txt.LoadByPrimaryKey(val.ItemFieldStringTempId);

        // load the live
            tblItemFieldStringValues txt2 = new tblItemFieldStringValues();
            if (val.ItemFieldStringId > -1)
            {
                txt2.LoadByPrimaryKey(val.ItemFieldStringId);
            }
            else
            {
                txt2.AddNew();
            }

        // make them equal
        txt2.ItemFieldValue = txt.ItemFieldValue;

        // save
        txt2.Save();

        val.ItemFieldStringId = txt2.ItemFieldStringValueId;

        // delete the old reference
        val.ItemFieldStringTempId = -1;
        val.Save();

        // delete the old
        txt.MarkAsDeleted();
        txt.Save();
    }
    public void SaveValue()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 3;
        val.Where.LanguageId.Value = (int)ViewState["_langId"];

        val.Query.Load();

        if (val.RowCount == 0)
        {
            val.AddNew();
            val.ItemFieldId = 3;
            val.LanguageId = (int)ViewState["_langId"];
            val.ItemId = _itemId;

        }

        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        try
        {
            if (val.ItemFieldStringTempId > -1)
            {
                txt.LoadByPrimaryKey(val.ItemFieldStringTempId);
            }
            else { txt.AddNew(); }
        }
        catch
        {
            txt.AddNew();
        }

        // check if we need an update
        tblItemFieldStringValues valtxt = new tblItemFieldStringValues();

        bool update = true;
        string imgroot = ddCat.SelectedItem.Value + "/" + ddFiles.SelectedItem.Value;
        try
        {
            valtxt.LoadByPrimaryKey(val.ItemFieldStringId);

            if (valtxt.ItemFieldValue == imgroot)
            {
                update = false;
            }
        }
        catch
        {
        }

        if (update)
        {
            txt.ItemFieldValue = imgroot;
            txt.Save();

            val.ItemFieldStringTempId = txt.ItemFieldStringValueId;
            val.Save();
        }
    }

    public int ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }
}
