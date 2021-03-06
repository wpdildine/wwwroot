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
using Microsoft.Web.AJAXExtensions;
using Telerik.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
public partial class admin_controls_cms_selectImage : System.Web.UI.UserControl
{

    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();

    bool ResizeImage = true;
    string ResizeWidth1 = "118";
    string ResizeHeight1 = "";
    string ResizePrefix1 = "";
    string ResizeSuffix1 = "sm";

    string ResizeWidth2 = "800";
    string ResizeHeight2 = "";
    string ResizePrefix2 = "";
    string ResizeSuffix2 = "";

    string ResizeWidth3 = "123";
    string ResizeHeight3 = "";
    string ResizePrefix3 = "special";
    string ResizeSuffix3 = "special";

    protected void Page_Load(object sender, EventArgs e)
    {

        //Button myButton = new Button();
        //myButton = (Button)Parent.FindControl("btnSendImages");
        //myButton.Click += new EventHandler(SetImages);


        //admin_controls_cms_selectImage imgSelect2 = (admin_controls_cms_selectImage)Parent.FindControl("cms_selectImage2");
        //UserControl imgSelect2 = (UserControl)Parent.FindControl("cms_selectImage2");
        //admin_controls_cms_selectImage imgSelect22 = new admin_controls_cms_selectImage();

        //imgSelect22 = (admin_controls_cms_selectImage)imgSelect2;
        //Control selectContainer2 = new Control();
        
        //admin_controls_cms_selectImage imgSelect22
        //foreach(Control ctrl in Parent.Controls) 
        //{
        //    if (ctrl.ID != null)
        //        Response.Write(ctrl.ID + "<br>");
        //    if (ctrl.ID == "panelImages")
        //        selectContainer2 = ctrl;
        //}

        //foreach (UserControl ctrl2 in selectContainer2.Controls)
        //{
        //    if (ctrl2.ID != null)
        //        Response.Write(ctrl2.ID + "<br>");
        //}
        //imgSelect2.ImageLoc = "woo";
        
        

        //imgSelect2.Controls.Find
        //imgSelect22 = (admin_controls_cms_selectImage)imgSelect2;

        //chkResize.Attributes.Add("onclick", "checkResize(this)");
        //chkConstrain.Attributes.Add("onclick", "checkConstrain(this)");
        if (Request["langId"] != null)
        {
            ViewState["_langId"] = Convert.ToInt32(Request["langId"]);
        }
        if (ViewState["selcat"] != null)
            _selCatImage = ViewState["selcat"].ToString();

        if (ViewState["selimg"] != null)
            _selImg = ViewState["selimg"].ToString();

        //resize_note.Text = "*note: Your image will automatically be resized to a width of "+ResizeWidth+"px.";

        if (!Page.IsPostBack)
        {

            Session["cat"] = null;
            Session["Files"] = null;
            getfolders(ref al, Server.MapPath("~/App_Uploads_Img/"));
            getallfolders(ref al2, Server.MapPath("~/App_Uploads_Img/"));
            try
            {

                string root = getTextVal().ToString();
                string cat = root.Substring(0, root.LastIndexOf("/"));
                ddCatImage.SelectedValue = cat;
                ddFilesImage.Enabled = true;
                getfiles(Server.MapPath("~/App_Uploads_Img/") + ddCatImage.SelectedItem.Value);
                ddFilesImage.SelectedValue = root.Substring((cat.Length) + 1);
                getTemp();
                if ((getTextVal().Contains("--Select--")) || (getTextVal().Contains("Select a Folder")) || (getTextVal().Length <= 0) || (getTextVal() == ""))
                {
                    img.Src = "/admin/images/spacer.gif";
                    img.Alt = "";
                }
                else
                {
                    showimage(ddCatImage.SelectedValue, ddFilesImage.SelectedValue);
                    img.Alt = ddCatImage.SelectedValue + "/" + ddFilesImage.SelectedValue;
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
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);

                if (files.Length > 0)
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

        //ddCatImage.DataSource = al;
        //ddCatImage.DataBind();
        ddCatImage.Items.Clear();
        foreach (string a in al)
            ddCatImage.Items.Add(new Telerik.Web.UI.DropDownListItem(a, a));
        ddCatImage.Items.Insert(0, new Telerik.Web.UI.DropDownListItem("- Select a Folder -"));

    }

    private void getallfolders(ref ArrayList al2, string dir)
    {

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if ((!foldername.Contains("_svn")) && (!foldername.Contains(".svn")))
            {
                string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);

                    al2.Add(foldername.Replace("\\", "/"));
            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {

            getallfolders(ref al2, dir2);

        }

        //DropDownList1I.DataSource = al2;
        //DropDownList1I.DataBind();
        DropDownList1I.Items.Clear();
        foreach (string a in al2)
            DropDownList1I.Items.Add(new Telerik.Web.UI.DropDownListItem(a, a));
        DropDownList1I.Items.Insert(0, new Telerik.Web.UI.DropDownListItem("- Select a Folder -"));
    }

    private string _selCatImage;
    private string _selImg;
    public string ImageLoc
    {
        get
        {
            string cat = ddCatImage.SelectedValue;
            return (cat + "/" + ddFilesImage.SelectedValue);
        }
        set
        {
            if (value.Length > 0)
            {
                _selCatImage = value.Substring(0, value.LastIndexOf("/"));
                _selImg = value.Substring(value.LastIndexOf("/") + 1);
                
             }
        }
    }

    public void getfiles(string dir)
    {
        ddFilesImage.Items.Clear();


        Telerik.Web.UI.DropDownListItem li1 = new Telerik.Web.UI.DropDownListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFilesImage.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] files = Directory.GetFiles(dir);
        foreach (string file in files)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/") + ddCatImage.SelectedValue;
            string filename = file.Substring(appdir.Length + 1);

            if ((!filename.Contains("_svn")) && (!filename.Contains(".svn")))
            {
                if (filename.ToLower().Contains(".png") || filename.ToLower().Contains(".gif") || filename.ToLower().Contains(".jpeg") || filename.ToLower().Contains(".bmp") || filename.ToLower().Contains(".tif") || filename.ToLower().Contains(".jpg"))
                {
                    Telerik.Web.UI.DropDownListItem li = new Telerik.Web.UI.DropDownListItem();
                    li.Text = filename;
                    li.Value = filename;
                    ddFilesImage.Items.Add(li);
                }
            }
        }
        UpdatePanel1Image.Update();

    }

    protected void ddCatImage_SelectedIndexChanged(object sender, EventArgs e)
    {
        img.Src = "/admin/images/spacer.gif";
        img.Alt = "";
        UpdatePanel1Image.Update();
        if (ddCatImage.SelectedIndex > 0)
        {
            ddFilesImage.Enabled = true;
            getfiles(Server.MapPath("~/App_Uploads_Img/") + ddCatImage.SelectedItem.Value);
            UpdatePanel1Image.Update();
        }
    }

    protected void ddFilesImage_SelectedIndexChanged(object sender, EventArgs e)
    {
        img.Src = "/admin/images/spacer.gif";
        img.Alt = "";
        showimage(ddCatImage.SelectedItem.Value, ddFilesImage.SelectedItem.Value);

    }
    private void showimage(string folder, string file)
    {
        img.Src = "/admin/images/spacer.gif";
        img.Alt = "";
        if (file != "-1")
        {
            img.Src = "~/App_Uploads_Img/" + folder + "/" + file;
            img.Alt = file;
            Bitmap ImageOrig = new Bitmap(Server.MapPath("~/App_Uploads_Img/") + folder + "/" + file, true);
            int ImageOrigHeight = ImageOrig.Height;
            int ImageOrigWidth = ImageOrig.Width;

            if ((ImageOrigHeight > 100) || (ImageOrigWidth > 100))
            {
                ImageOrigWidth = 100;
                ImageOrigHeight = getdimensions(100, ImageOrig.Width, ImageOrig.Height);


            }
            Size sz = new Size(ImageOrigWidth, ImageOrigHeight);

            img.Width = ImageOrigWidth;
            img.Height = ImageOrigHeight;

        }
        else
        {
            img.Src = "/admin/images/spacer.gif";
            img.Alt = "";
        }
        UpdatePanel1Image.Update();
    }
    public int getdimensions(int newwidth, int origwidth, int origheight)
    {
        decimal maxWidth = Convert.ToDecimal(origwidth);
        decimal maxHeight = Convert.ToDecimal(origheight);
        decimal auto = Math.Round((maxWidth / maxHeight), 4);

        decimal newheight = Math.Round((newwidth / auto), 0);

        origheight = Convert.ToInt32(newheight);

        return origheight;
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
            return _selCatImage + "/" + _selImg;
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        RadUploadContext upContext = RadUploadContext.Current;
        string dir = Server.MapPath("~/App_Uploads_Img/");
        if (RadUpload1.UploadedFiles.Count > 0)
        {
            foreach (Telerik.Web.UI.UploadedFile file in RadUpload1.UploadedFiles)
            {

                string name = file.GetName().ToLower();
                name = name.Replace(" ", "_");
                name = name.Replace("%20", "_");
                name = name.Replace("#", "");
                if ((DropDownList1I.SelectedIndex == 0) && (tbDirectoryImage.Text.Length == 0))
                {

                    Session["cat"] = null;
                    Session["Files"] = null;
                    TabPanel3.Focus();

                }
                else if ((DropDownList1I.SelectedIndex == 0) && (tbDirectoryImage.Text.Length > 0))
                {
                    Directory.CreateDirectory(dir + tbDirectoryImage.Text);

                    // Save original high res, we'll use this for our resizing then delete it after
                    string physicalpath = Server.MapPath("~/App_Uploads_Img/" + tbDirectoryImage.Text + "/");
                    file.SaveAs(physicalpath + name, true);

                    string path = tbDirectoryImage.Text + "/";
                    string width1 = ResizeWidth1;
                    string height1 = ResizeHeight1;
                    string prefix1 = ResizePrefix1;
                    string suffix1 = ResizeSuffix1;

                    string width2 = ResizeWidth2;
                    string height2 = ResizeHeight2;
                    string prefix2 = ResizePrefix2;
                    string suffix2 = ResizeSuffix2;

                    string width3 = ResizeWidth3;
                    string height3 = ResizeHeight3;
                    string prefx3 = ResizePrefix3;
                    string suffix3 = ResizeSuffix3;

                    // Begin resize function
                    resize(name, path, physicalpath, width1, height1, prefix1, suffix1);
                    resize(name, path, physicalpath, width2, height2, prefix2, suffix2);
                    //resize(name, path, physicalpath, width3, height3, prefix3, suffix3);
                    
                    Session["cat"] = tbDirectoryImage.Text;
                    string sFileName = file.GetName().ToLower();
                    string na = sFileName.Substring(0, sFileName.LastIndexOf("."));
                    string format = sFileName.Substring(na.Length);
                    if (prefix2 != "")
                        prefix2 += "_";
                    if (suffix2 != "")
                        suffix2 = "_" + suffix2;
                    sImageName = prefix2 + na + suffix2 + format;
                    Session["Files"] = sImageName;
                }

                else if ((DropDownList1I.SelectedIndex != 0) && (tbDirectoryImage.Text.Length > 0))
                {
                    Directory.CreateDirectory(dir + DropDownList1I.SelectedItem.Text + "/" + tbDirectoryImage.Text);
                    
                    // Save original high res, we'll use this for our resizing then delete it after
                    string physicalpath = Server.MapPath("~/App_Uploads_Img/" + DropDownList1I.SelectedItem.Text + "/" + tbDirectoryImage.Text + "/");
                    file.SaveAs(physicalpath + name, true);

                    string path = tbDirectoryImage.Text + "/";
                    string width1 = ResizeWidth1;
                    string height1 = ResizeHeight1;
                    string prefix1 = ResizePrefix1;
                    string suffix1 = ResizeSuffix1;

                    string width2 = ResizeWidth2;
                    string height2 = ResizeHeight2;
                    string prefix2 = ResizePrefix2;
                    string suffix2 = ResizeSuffix2;

                    string width3 = ResizeWidth3;
                    string height3 = ResizeHeight3;
                    string prefx3 = ResizePrefix3;
                    string suffix3 = ResizeSuffix3;

                    // Begin resize function
                    resize(name, path, physicalpath, width1, height1, prefix1, suffix1);
                    resize(name, path, physicalpath, width2, height2, prefix2, suffix2);
                    //resize(name, path, physicalpath, width3, height3, prefix3, suffix3);

                    Session["cat"] = (DropDownList1I.SelectedItem.Text + "/" + tbDirectoryImage.Text);
                    string sFileName = file.GetName().ToLower();
                    string na = sFileName.Substring(0, sFileName.LastIndexOf("."));
                    string format = sFileName.Substring(na.Length);
                    if (prefix2 != "")
                        prefix2 += "_";
                    if (suffix2 != "")
                        suffix2 = "_" + suffix2;
                    sImageName = prefix2 + na + suffix2 + format;
                    Session["Files"] = sImageName;

                }

                else if ((DropDownList1I.SelectedIndex > 0) && (tbDirectoryImage.Text.Length == 0))
                {

                    
                    // Save original high res, we'll use this for our resizing then delete it after
                    string physicalpath = Server.MapPath("~/App_Uploads_Img/" + DropDownList1I.SelectedItem.Text + "/");
                    file.SaveAs(physicalpath + name, true);

                    string path = tbDirectoryImage.Text + "/";
                    string width1 = ResizeWidth1;
                    string height1 = ResizeHeight1;
                    string prefix1 = ResizePrefix1;
                    string suffix1 = ResizeSuffix1;

                    string width2 = ResizeWidth2;
                    string height2 = ResizeHeight2;
                    string prefix2 = ResizePrefix2;
                    string suffix2 = ResizeSuffix2;

                    string width3 = ResizeWidth3;
                    string height3 = ResizeHeight3;
                    string prefx3 = ResizePrefix3;
                    string suffix3 = ResizeSuffix3;

                    // Begin resize function
                    resize(name, path, physicalpath, width1, height1, prefix1, suffix1);
                    resize(name, path, physicalpath, width2, height2, prefix2, suffix2);
                    //resize(name, path, physicalpath, width3, height3, prefix3, suffix3);

                    // Assign a session variable so we can auto-select it from the dropdown
                    Session["cat"] = DropDownList1I.SelectedItem.Text;
                    string sFileName = name.ToLower();
                    string na = sFileName.Substring(0, sFileName.LastIndexOf("."));
                    string format = sFileName.Substring(na.Length);
                    if (prefix2 != "")
                        prefix2 += "_";
                    if (suffix2 != "")
                        suffix2 = "_" + suffix2;
                    sImageName = prefix2 + na + suffix2 + format;
                    Session["Files"] = sImageName;
                }
            }
            GC.Collect();
        }

            getfolders(ref al, Server.MapPath("~/App_Uploads_Img/"));
            getallfolders(ref al2, Server.MapPath("~/App_Uploads_Img/"));
            if ((Session["cat"] != null) && (Session["Files"] != null))
            {
                ddCatImage.SelectedValue = Session["cat"].ToString().Replace("\\", "/");
                getfiles(Server.MapPath("~/App_Uploads_Img/") + ddCatImage.SelectedItem.Value);
                string myfiles = Session["Files"].ToString();
                try
                {
                    ddFilesImage.SelectedValue = myfiles.ToLower();
                }
                catch (Exception ex)
                { }
                showimage(ddCatImage.SelectedValue, ddFilesImage.SelectedValue);
            }
            tbDirectoryImage.Text = "";

           

            

            //UpdatePanel1Image.Update();
            //UpdatePanel2Image.Update();
    }

    protected void RadUpload1_FileExists1(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
    {
        int counter = 1;
        Telerik.Web.UI.UploadedFile file = e.UploadedFile;
        string targetFolder = Server.MapPath("~/App_Uploads_Img/" + DropDownList1I.SelectedItem.Text+"/");
        string targetFileName = Path.Combine(targetFolder,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while (System.IO.File.Exists(targetFileName))
        {
            counter++;
            targetFileName = Path.Combine(targetFolder,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
        GC.Collect();
    }
    string sPhysicalPath = "";
    string sFileName = "";
    string sTempFileName = "";
    string sImageName = "";
    StringBuilder sb = new StringBuilder();
    public void resize(string name, string path, string physicalpath, string width, string height, string prefix, string suffix)
    {
        
        if (height.Length == 0)
            height = "0";
        else 
            height = height;

        if (prefix != "")
            prefix = prefix + "_";

        if (suffix != "")
            suffix = "_" + suffix;

        checkimageformat(path, physicalpath, name, prefix, suffix, Convert.ToInt32(width), Convert.ToInt32(height));


    }
    public void checkimageformat(string savepath, string sPhysicalPath, string FName, string prefix, string suffix, int width, int height)
    {
        decimal maxWidth = 0;
        decimal auto = 0;
        decimal newheight = 0;
        decimal maxHeight = 0;
        Size ThumbNailSize = new Size();
        sFileName = FName.ToLower();
        //sThumbName = sFileName.Replace(".", ThumbNailName + ".");
        string na = sFileName.Substring(0, sFileName.LastIndexOf("."));
        string format = sFileName.Substring(na.Length);
        sImageName = prefix + na + suffix + format;
        if (height > 0)
        {
            ThumbNailSize = new Size(width, height);
        }
        else
        {
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(sPhysicalPath + FName);
            maxWidth = Convert.ToDecimal(origImg.Width);
            maxHeight = Convert.ToDecimal(origImg.Height);
            auto = Math.Round((maxWidth / maxHeight), 4);
            newheight = Math.Round((width / auto), 0);
            ThumbNailSize = new Size(width, Convert.ToInt32(newheight));
            origImg.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        if (sFileName.ToLower().IndexOf(".gif") > 0)
        {
            this.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Gif, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".jpg") > 0)
        {
            this.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".jpeg") > 0)
        {
            this.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".bmp") > 0)
        {
            this.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Bmp, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".png") > 0)
        {
            this.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Png, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".tif") > 0)
        {
            this.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Tiff, ThumbNailSize.Width, ThumbNailSize.Height);
        }
    }

    public string GenerateImage(string savePath, string sPhysicalPath, string sOrgFileName, string sImageFileName, ImageFormat oFormat, int widthnew, int heightnew)
    {
        string filename = sOrgFileName.Substring(0, sOrgFileName.LastIndexOf("."));
        Size thumsize = new Size(widthnew, heightnew);
        try
        {
            if (oFormat != ImageFormat.Gif)
            {
                System.Drawing.Image oImg = System.Drawing.Image.FromFile(sPhysicalPath + @"\" + sOrgFileName);
                System.Drawing.Image oThumbNail = new Bitmap(thumsize.Width, thumsize.Height, oImg.PixelFormat);

                Graphics oGraphic = Graphics.FromImage(oThumbNail);
                oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                oGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                ImageAttributes attribute = new ImageAttributes();
                attribute.SetWrapMode(WrapMode.TileFlipXY);
                oGraphic.DrawImage(oImg, new Rectangle(new Point(0, 0), thumsize), 0, 0, oImg.Width, oImg.Height, GraphicsUnit.Pixel, attribute);

                oImg.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // First delete the image
                //FileInfo fi = new FileInfo(sPhysicalPath + sOrgFileName);
                //fi.Attributes = FileAttributes.Normal;
                //fi.Delete();

                // Then resave it with its new size
                oThumbNail.Save(sPhysicalPath + sImageFileName, oFormat);

                // Empty Garbage
                oGraphic.Dispose();
                oThumbNail.Dispose();
                GC.Collect();
                sb.Append(sPhysicalPath + sImageFileName);
            }
            else
            {
                Bitmap bm = new Bitmap(sPhysicalPath + @"\" + sOrgFileName);
                Bitmap bm2 = new Bitmap(thumsize.Width, thumsize.Height, PixelFormat.Format64bppArgb);
                Graphics g2 = Graphics.FromImage(bm2);

                Rectangle subRect = new Rectangle(0, 0, thumsize.Width, thumsize.Height);
                g2.DrawImage(bm, subRect);
                bm.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                bm2.Save(sPhysicalPath + sImageFileName, ImageFormat.Jpeg);
                g2.Dispose();
                bm2.Dispose();
                GC.Collect();

                sb.Append(sPhysicalPath + sImageFileName);

            }
        }
        catch (Exception e1) { sb.Append(e1.Message); }
        return sb.ToString();
    }
}



