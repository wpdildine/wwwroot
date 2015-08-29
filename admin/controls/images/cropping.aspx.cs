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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;

public partial class admin_controls_images_cropping : System.Web.UI.Page
{
 

    int h = 0;
    string sFileName = "";
    string sThumbName = "";
    decimal maxWidth = 0;
    decimal auto = 0;
    decimal newheight = 0;
    decimal newheightlarge = 0;
    decimal maxHeight = 0;
    ArrayList af = new ArrayList();
    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();
    ArrayList alcheck = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Image Cropping";
        if (!Page.IsPostBack)
        {
            getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
        }
        errorlabelcrop.Text = "";
            lbSuccess3.Text = "";
        if (Page.IsPostBack)
        {
            errorlabelcrop.Text = "";
            Button1.Attributes.Add("onclick", "crop();");
            drag.Visible = false;
        }
    }

    private void getallfolders(ref ArrayList al2, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if (!foldername.Contains("_svn"))
            {
                if (!foldername.Contains("toresize"))
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);
                    al2.Add(foldername);
                }
            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            getallfolders(ref al2, dir2);
        }

        ddSaveTo.DataSource = al2;
        ddSaveTo.DataBind();
    }
    private void getfold(ref ArrayList al, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if (!foldername.Contains("_svn"))
            {
                if (!foldername.Contains("toresize"))
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);

                    if (files.Length > 0)
                    {
                        al.Add(foldername);
                    }
                }
            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            getfold(ref al, dir2);
        }

        ddCat3.DataSource = al;
        ddCat3.DataBind();
        ddCat3.Items.Insert(0, new ListItem("- Select a Folder -"));
        ddCat3.SelectedIndex = 0;
    }
    protected void ddCat3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCat3.SelectedIndex > 0)
        {
            lbSuccess3.Text = "";
            ddFiles2.Enabled = true;
            ddSaveTo.Enabled = true;
            getfilescrop(Server.MapPath("~/App_Uploads_Img/") + ddCat3.SelectedItem.Value);
            getallfolders(ref al2, Server.MapPath("~/App_Uploads_Img/"));
            ddSaveTo.SelectedIndex = ddCat3.SelectedIndex - 1;
            UpdatePanel3.Update();

        }
    }
    protected void ddFiles2_SelectedIndexChanged(object sender, EventArgs e)
    {
        drag.Visible = false;
        System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat3.SelectedItem.Text + "/" + ddFiles2.SelectedItem.Text);
        Hidden1.Value = origImg.Width.ToString();
        Hidden2.Value = origImg.Height.ToString();
        Label8.Text = "";
        Label8.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
        divimage.Visible = true;
        divimage.InnerHtml ="<img src="+ epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat3.SelectedItem.Text + "/" + ddFiles2.SelectedItem.Text+"></img>";
        divimage.Style.Add("width" , origImg.Width.ToString());
        divimage.Style.Add("height", origImg.Height.ToString());
        UpdatePanel3.Update();

    }
    public void getfilescrop(string dir)
    {
        ddFiles2.Items.Clear();

        ListItem li1 = new ListItem();
        li1.Text = "-- select --";
        li1.Value = "-1";

        ddFiles2.Items.Add(li1);

        ArrayList af = new ArrayList();
        string[] files = Directory.GetFiles(dir);
        foreach (string file in files)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat3.SelectedItem.Value + "/");
            string filename = file.Substring(appdir.Length);
            //string filename = file;
            if (!filename.Contains("_svn"))
            {
                af.Add(filename);
                ListItem li = new ListItem();
                li.Text = filename;
                li.Value = filename;
                ddFiles2.Items.Add(li);

            }
        }
        UpdatePanel3.Update();

    }
    public void CropImageFile(string savePath, string sPhysicalPath, string sOrgFileName, string sThumbNailFileName, ImageFormat oFormat, int targetW, int targetH, int targetX, int targetY)
    {
        try
        {
            Size tsize = new Size(targetW, targetH);
            System.Drawing.Image oImg = System.Drawing.Image.FromFile(sPhysicalPath + @"\" + sOrgFileName);
            System.Drawing.Image oThumbNail = new Bitmap(tsize.Width, tsize.Height, oImg.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            oGraphic.DrawImage(oImg, new Rectangle(0, 0, targetW, targetH), targetX, targetY, targetW, targetH, GraphicsUnit.Pixel);
            oThumbNail.Save(savePath + @"\" + sThumbNailFileName, oFormat);
            oGraphic.Dispose();
            oThumbNail.Dispose();

            oImg.Dispose();
            drag.Visible = false;
            ddFiles2.SelectedItem.Text = sThumbNailFileName;
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat3.SelectedItem.Text + "/" + sThumbNailFileName);
            divimage.InnerHtml = "<img src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat3.SelectedItem.Text + "/" + ddFiles2.SelectedItem.Text + "></img>";
            Label8.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
            Hidden1.Value = origImg.Width.ToString();
            Hidden2.Value = origImg.Height.ToString();
            UpdatePanel3.Update();
            lbSuccess3.ForeColor = System.Drawing.Color.Green;
            lbSuccess3.Text = "Image " + sThumbNailFileName + " created.";
        }
        catch (Exception e1) { errorlabelcrop.ForeColor = System.Drawing.Color.Red; 
            errorlabelcrop.Text = e1.Message; }
    }
    public void showresizedimage(string savePath, string sPhysicalPath, string sOrgFileName,
                                                                  string sThumbNailFileName, ImageFormat oFormat, int widthnew, int heightnew)
    {
        Size thumsize = new Size(widthnew, heightnew);
        try
        {

            System.Drawing.Image oImg = System.Drawing.Image.FromFile(sPhysicalPath + @"\" + sOrgFileName);
            System.Drawing.Image oThumbNail = new Bitmap(thumsize.Width, thumsize.Height, oImg.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, thumsize.Width, thumsize.Height);
            oGraphic.DrawImage(oImg, oRectangle);
            oThumbNail.Save(savePath + @"\" + sThumbNailFileName, oFormat);

            ddFiles2.SelectedItem.Text = sThumbNailFileName;
         
            
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat3.SelectedItem.Text + "/" + sThumbNailFileName);
           
            if (cbCropConstraint.Checked == false)
            {
                if (tbcropHeight.Text.Length > 0)
                {
                    h = Convert.ToInt32(tbcropHeight.Text);
                }
                else { h = 0; }
     
            }
            else
            {
               
                maxWidth = Convert.ToDecimal(origImg.Width);
                maxHeight = Convert.ToDecimal(origImg.Height);
                auto = Math.Round((maxWidth / maxHeight), 4);

                 newheight = Math.Round(( Convert.ToInt32(tbcropWidth.Text) / auto), 0);
    
            }
            //divimage.InnerHtml = "~/App_Uploads_Img/" + ddCat3.SelectedItem.Text + "/" + sThumbNailFileName;
            divimage.InnerHtml = "<img src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat3.SelectedItem.Text + "/" + ddFiles2.SelectedItem.Text + "></img>";
            Label8.Text = "";
            Label8.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
            tbcropHeight.Text = "";
            tbcropHeight.Enabled = true;
            cbCropConstraint.Checked = false;
            tbCropSuffix.Text = "";
            tbcropWidth.Text = "";
            lbSuccess3.ForeColor = System.Drawing.Color.Green;
            lbSuccess3.Text = "Image " + sThumbNailFileName + " created.";
            oGraphic.Dispose();
            oThumbNail.Dispose();
            oImg.Dispose();
            UpdatePanel3.Update();

        }
        catch (Exception e1) { errorlabelcrop.ForeColor = System.Drawing.Color.Red;
                                errorlabelcrop.Text = e1.Message; }

    }
   
    protected void Button5_Click(object sender, EventArgs e)
    {
        lbSuccess3.Text = "";
        errorlabelcrop.Text = "";
        if (!ddCat3.SelectedItem.Text.Contains("Select a Folder") && !ddFiles2.SelectedItem.Text.Contains("Select a Folder") && tbcropWidth.Text.Length > 0 && tbCropSuffix.Text.Length > 0 && tbCropSuffix.Text != ddFiles2.SelectedItem.Text.Substring(0, ddFiles2.SelectedItem.Text.IndexOf(".")))
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat3.SelectedItem.Text + "/");
            string savepath = Server.MapPath("~/App_Uploads_Img/" + ddSaveTo.SelectedItem.Text + "/");
            string Name = ddFiles2.SelectedItem.Text;
            string thumb = Name.ToLower();

            string ThumbNailName = tbCropSuffix.Text;
            Size ThumbNailSize = new Size();
            sFileName = Name.ToLower();
   
            //sThumbName = sFileName.Replace(".", ThumbNailName + ".");
            string na = sFileName.Substring(0, sFileName.IndexOf("."));
            string format = sFileName.Substring(na.Length);
            sThumbName = tbCropSuffix.Text + format;

            int width = Convert.ToInt32(tbcropWidth.Text);
            if (cbCropConstraint.Checked == false)
            {
                if (tbcropHeight.Text.Length > 0)
                {
                    h = Convert.ToInt32(tbcropHeight.Text);
                }
                else { h = 0; }
                ThumbNailSize = new Size(width, h);
            }
            else
            {
                System.Drawing.Image origImg = System.Drawing.Image.FromFile(appdir + Name);
                maxWidth = Convert.ToDecimal(origImg.Width);
                maxHeight = Convert.ToDecimal(origImg.Height);
                auto = Math.Round((maxWidth / maxHeight), 4);

                newheight = Math.Round((width / auto), 0);
                ThumbNailSize = new Size(width, Convert.ToInt32(newheight));
            }
            if (Name.ToLower().IndexOf(".gif") > 0)
            {
                showresizedimage(savepath, appdir, Name, sThumbName, ImageFormat.Gif, ThumbNailSize.Width, ThumbNailSize.Height);
            }
            if (Name.ToLower().IndexOf(".jpg") > 0)
            {
                showresizedimage(savepath, appdir, Name, sThumbName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
            }
            if (Name.ToLower().IndexOf(".jpeg") > 0)
            {
                showresizedimage(savepath, appdir, Name, sThumbName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
            }
            if (Name.ToLower().IndexOf(".bmp") > 0)
            {
                showresizedimage(savepath, appdir, Name, sThumbName, ImageFormat.Bmp, ThumbNailSize.Width, ThumbNailSize.Height);
            }
            if (Name.ToLower().IndexOf(".png") > 0)
            {
                showresizedimage(savepath, appdir, Name, sThumbName, ImageFormat.Png, ThumbNailSize.Width, ThumbNailSize.Height);
            }
            if (Name.ToLower().IndexOf(".tif") > 0)
            {
                showresizedimage(savepath, appdir, Name, sThumbName, ImageFormat.Tiff, ThumbNailSize.Width, ThumbNailSize.Height);
            }
        }
        else 
        {
            errorlabelcrop.ForeColor = System.Drawing.Color.Red;
            errorlabelcrop.Text = "Your Information is not complete!" + Environment.NewLine; ;
            if(ddCat3.SelectedItem.Text.Contains("Select a Folder")||ddFiles2.SelectedItem.Text.Contains("Select a Folder"))
                errorlabelcrop.Text += "Image not selected." +Environment.NewLine;
            if(tbcropWidth.Text.Length == 0)
                errorlabelcrop.Text += "Width not selected." + Environment.NewLine; ;
            if (cbCropConstraint.Checked==false&&tbcropHeight.Text.Length==0)
                errorlabelcrop.Text += "Enter Height or check Auto Constraint." + Environment.NewLine; 
            if (tbCropSuffix.Text.Length == 0)
                errorlabelcrop.Text += "Name not selected." + Environment.NewLine; ;
            if (tbCropSuffix.Text ==  ddFiles2.SelectedItem.Text)
                errorlabelcrop.Text += "Name can not be the same as Original File." + Environment.NewLine; ;
            UpdatePanel3.Update();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat3.SelectedItem.Text + "/" + ddFiles2.SelectedItem.Text);
            drag.Visible = true;
            
            drag.Style.Add("width", origImg.Width / 2 + "px");
            drag.Style.Add("height", origImg.Height / 2 + "px");
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if (browser.Browser == "IE")
            {
                drag.Style.Add("left", "9px");
                drag.Style.Add("top", "403px");
            }
            else
            {
                drag.Style.Add("left", "7px");
                drag.Style.Add("top", "361px");
            }
            drag.Style.Add("text-align", "center");
        
       
    }
    
    protected void cbContstraint_CheckedChanged(object sender, EventArgs e)
    {
        if (cbCropConstraint.Checked == true)
            tbcropHeight.Enabled = false;
        else
            tbcropHeight.Enabled = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
 errorlabelcrop.Text = "";
 if (tbCropSuffix.Text.Length > 0 &&Hidden3.Value.Length >0&& tbCropSuffix.Text != ddFiles2.SelectedItem.Text.Substring(0, ddFiles2.SelectedItem.Text.IndexOf(".")))
 {
     string x = Hidden3.Value.Substring(0, Hidden3.Value.IndexOf("/"));
     string y = Hidden3.Value.Substring(x.Length + 1, Hidden3.Value.IndexOf("/"));
     int start = ((x.Length + 1) + (y.Length + 1));
     string w2 = Hidden3.Value.Substring(start);
     string w = Hidden3.Value.Substring(start, w2.IndexOf("/"));
     string h = Hidden3.Value.Substring(((x.Length + 1) + (y.Length + 1) + (w.Length + 1)));

     string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat3.SelectedItem.Text + "/");
     string savepath = Server.MapPath("~/App_Uploads_Img/" + ddSaveTo.SelectedItem.Text + "/");
     string Name = ddFiles2.SelectedItem.Text;
     sFileName = Name.ToLower();
     string ThumbNailName = "_crp";
     //sThumbName = sFileName.Replace(".", ThumbNailName + ".");
     string na = sFileName.Substring(0, sFileName.IndexOf("."));
     string format = sFileName.Substring(na.Length);
     sThumbName = tbCropSuffix.Text + format;

     //sThumbName = sFileName.Replace(".", ThumbNailName + ".");
     if (Name.ToLower().IndexOf(".gif") > 0)
     {
         CropImageFile(savepath, appdir, sFileName, sThumbName, ImageFormat.Gif, Convert.ToInt32(w), Convert.ToInt32(h), Convert.ToInt32(x), Convert.ToInt32(y));
     }
     if (Name.ToLower().IndexOf(".jpg") > 0)
     {
         CropImageFile(savepath, appdir, sFileName, sThumbName, ImageFormat.Jpeg, Convert.ToInt32(w), Convert.ToInt32(h), Convert.ToInt32(x), Convert.ToInt32(y));
     }
     if (Name.ToLower().IndexOf(".jpeg") > 0)
     {
         CropImageFile(savepath, appdir, sFileName, sThumbName, ImageFormat.Jpeg, Convert.ToInt32(w), Convert.ToInt32(h), Convert.ToInt32(x), Convert.ToInt32(y));
     }
     if (Name.ToLower().IndexOf(".bmp") > 0)
     {
         CropImageFile(savepath, appdir, sFileName, sThumbName, ImageFormat.Bmp, Convert.ToInt32(w), Convert.ToInt32(h), Convert.ToInt32(x), Convert.ToInt32(y));
     }
     if (Name.ToLower().IndexOf(".png") > 0)
     {
         CropImageFile(savepath, appdir, sFileName, sThumbName, ImageFormat.Png, Convert.ToInt32(w), Convert.ToInt32(h), Convert.ToInt32(x), Convert.ToInt32(y));
     }
     if (Name.ToLower().IndexOf(".tif") > 0)
     {
         CropImageFile(savepath, appdir, sFileName, sThumbName, ImageFormat.Tiff, Convert.ToInt32(w), Convert.ToInt32(h), Convert.ToInt32(x), Convert.ToInt32(y));
     }
 }
 else
 {
     errorlabelcrop.ForeColor = System.Drawing.Color.Red;
     errorlabelcrop.Text = "Your Information is not complete!" + Environment.NewLine;
     if (Hidden3.Value.Length == 0)
         errorlabelcrop.Text += "You have to drag the handle first to select the Area you would like to crop out." + Environment.NewLine;
     if (tbCropSuffix.Text.Length == 0)
         errorlabelcrop.Text += "Name not selected." + Environment.NewLine;
     if (tbCropSuffix.Text == ddFiles2.SelectedItem.Text.Substring(0, ddFiles2.SelectedItem.Text.IndexOf(".")))
         errorlabelcrop.Text += "Name can not be the same as Original File." + Environment.NewLine;
     UpdatePanel3.Update();
 }
    }
}
