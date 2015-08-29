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

public partial class admin_controls_images_resizing : System.Web.UI.Page
{
    string sPhysicalPath = "";
    string sFileName = "";
    string sThumbName = "";
    int amount = 0;
    ArrayList af = new ArrayList();
    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();
    ArrayList alcheck = new ArrayList();
    string cat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] == "1")
        {
            Page.Title = "Image Resizing Manual";
        }
        else { Page.Title = "Image Resizing Automatic"; }
          if (!Page.IsPostBack)
        {
            getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
            if(Request["id"]=="1")
            {
                 auto.Visible = false;
            }
            else{
               
                  
                    manual.Visible = false;
              }
           

        }
    }
    private void getfold(ref ArrayList al, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if (!foldername.Contains("_svn")&&(!foldername.Contains(".svn")))
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

        ddCat2.DataSource = al;
        ddCat2.DataBind();

        ddCat.DataSource = al;
        ddCat.DataBind();
        ddCat2.Items.Insert(0, new ListItem("- Select a Folder -"));
        ddCat.Items.Insert(0, new ListItem("- Select a Folder -"));
        ddCat.SelectedIndex = 0;
        ddCat2.SelectedIndex = 0;

        Label6.Visible = true;


      
    }
    #region manual
    protected void cbContstraint_CheckedChanged(object sender, EventArgs e)
    {
        if (cbContstraint.Checked == true)
            tbheight.Enabled = false;
        else
            tbheight.Enabled = true;
    }
    protected void ddCat2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCat2.SelectedIndex > 0)
        {
            ddFiles.Enabled = true;
            ddSavePath.Enabled = true;
            getfilesmanual(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Value);
            getallfolders(ref al2, Server.MapPath("~/App_Uploads_Img/"));
            ddSavePath.SelectedIndex = ddCat2.SelectedIndex-1;
            UpdatePanel1.Update();

        }
    }

    protected void ddFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
            //getsize(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text);
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text);
            Label3.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
            divimage.Visible = true;
            divimage.InnerHtml = "<img width=\"75px\" height=\"75px\" src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text + "></img>";
            tbThumb.Text = "";
            lbSuccess.Text = "";
            UpdatePanel1.Update();  
      
    }
    protected void ddCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        showfiles(ddCat.SelectedItem.Value);
      
    }
    private void showfiles(string fold)
    {
        Panel1.Visible = true;
        ArrayList af2 = new ArrayList();
        string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + fold);
       
            foreach (string file in files)
            { 
                if (files.Length > 0)
              {
                string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Value + "/");
                string filename = file.Substring(appdir.Length);
                //string filename = file;
                if (!filename.Contains("_svn"))
                {
                    af2.Add(filename);
                    Panel1.Controls.Add(new LiteralControl(filename));
                    Panel1.Controls.Add(new LiteralControl("<br/>"));
                }
            }
        }
        if (af2.Count > 10)
        {
            Panel1.ScrollBars = ScrollBars.Vertical;
        }
        else { Panel1.ScrollBars = ScrollBars.None; }
    }
    private void getallfolders(ref ArrayList al2, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if (!foldername.Contains("_svn") && (!foldername.Contains(".svn")))
            {
                if (!foldername.Contains("toresize"))
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);
                    if (files.Length > 0)
                    {

                        al2.Add(foldername);
                    }
                    
                }
            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            getallfolders(ref al2, dir2);
        }

        ddSavePath.DataSource = al2;
        ddSavePath.DataBind();
        
    }
   
    public void getfilesmanual(string dir)
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
            if (files.Length > 0)
            {
                string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat2.SelectedItem.Value + "/");
                string filename = file.Substring(appdir.Length);
                //string filename = file;
                if (!filename.Contains("_svn"))
                {
                    af.Add(filename);
                    ListItem li = new ListItem();
                    li.Text = filename;
                    li.Value = filename;
                    ddFiles.Items.Add(li);

                }
            }
        }
        UpdatePanel1.Update();

    }
  
   


    public void GenerateThumbNail(string savePath,string sPhysicalPath, string sOrgFileName,
                                                                  string sThumbNailFileName, ImageFormat oFormat, int widthnew, int heightnew)
    {
        Size thumsize = new Size(widthnew, heightnew);
        try
        {
            if (oFormat != ImageFormat.Gif)
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
                oGraphic.Dispose();
                oThumbNail.Dispose();
                oImg.Dispose();
                if (Request["id"] == "1")
                {
                    lbSuccess.ForeColor = System.Drawing.Color.Green;
                    lbSuccess.Text = "Image " + sThumbNailFileName + " created.";
                    ddFiles.SelectedItem.Text = sThumbNailFileName;
                    System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text);
                     Label3.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
                    divimage.InnerHtml = "<img src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text + "></img>";
                }
                else
                {
                    lbSuccess2.ForeColor = System.Drawing.Color.Green;
                    lbSuccess2.Controls.Add(new LiteralControl(sThumbNailFileName + " created."));
                    lbSuccess2.Controls.Add(new LiteralControl("<br/>"));
                }
            }
            else
            {
                Bitmap bm = new Bitmap(sPhysicalPath + @"\" + sOrgFileName);

                Bitmap bm2 = new Bitmap(thumsize.Width, thumsize.Height, PixelFormat.Format64bppPArgb);
                Graphics g2 = Graphics.FromImage(bm2);
                Rectangle subRect = new Rectangle(0, 0, thumsize.Width, thumsize.Height);
                g2.DrawImage(bm, subRect);
                bm2.Save(savePath + @"\" + sThumbNailFileName, oFormat);
                g2.Dispose();
                bm2.Dispose();
                bm.Dispose();

                if (Request["id"] == "1")
                {
                    lbSuccess.ForeColor = System.Drawing.Color.Green;
                    lbSuccess.Text = "Image " + sThumbNailFileName + " created.";
                    ddFiles.SelectedItem.Text = sThumbNailFileName;
                    System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text);
                    Label3.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
                    divimage.InnerHtml = "<img src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text + "></img>";
                }
                else
                {
                    lbSuccess2.ForeColor = System.Drawing.Color.Green;
                    lbSuccess2.Controls.Add(new LiteralControl(sThumbNailFileName + " created."));
                    lbSuccess2.Controls.Add(new LiteralControl("<br/>"));
                }
            }
        }
        catch (Exception e1) { errorlabel.Text = e1.Message; }

    }
   
    public void checkimageformat(string savepath,string sPhysicalPath, string FName, string ThumbNailName,int width,int height,bool constraint)
    {
        decimal maxWidth = 0;
        decimal auto = 0;
        decimal newheight = 0;
        decimal newheightlarge = 0;
        decimal maxHeight = 0;
        Size ThumbNailSize = new Size();
        sFileName = FName.ToLower();
        //sThumbName = sFileName.Replace(".", ThumbNailName + ".");
        string na = sFileName.Substring(0, sFileName.IndexOf("."));
        string format = sFileName.Substring(na.Length);
        sThumbName = tbThumb.Text + format;
        if (constraint == false)
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
        }

                if (sFileName.ToLower().IndexOf(".gif") > 0)
                {
                    this.GenerateThumbNail(savepath,sPhysicalPath, sFileName, sThumbName, ImageFormat.Gif, ThumbNailSize.Width, ThumbNailSize.Height);
                }
                if (sFileName.ToLower().IndexOf(".jpg") > 0)
                {
                    this.GenerateThumbNail(savepath,sPhysicalPath, sFileName, sThumbName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);

                }
                if (sFileName.ToLower().IndexOf(".jpeg") > 0)
                {
                    this.GenerateThumbNail(savepath,sPhysicalPath, sFileName, sThumbName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
                }
                if (sFileName.ToLower().IndexOf(".bmp") > 0)
                {
                    this.GenerateThumbNail(savepath,sPhysicalPath, sFileName, sThumbName, ImageFormat.Bmp, ThumbNailSize.Width, ThumbNailSize.Height);
                }
                if (sFileName.ToLower().IndexOf(".png") > 0)
                {
                    this.GenerateThumbNail(savepath, sPhysicalPath, sFileName, sThumbName, ImageFormat.Png, ThumbNailSize.Width, ThumbNailSize.Height);
                }
                if (sFileName.ToLower().IndexOf(".tif") > 0)
                {
                    this.GenerateThumbNail(savepath, sPhysicalPath, sFileName, sThumbName, ImageFormat.Tiff, ThumbNailSize.Width, ThumbNailSize.Height);
                }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        errorlabel.Text = "";
        string save ="";
        if (!ddCat2.SelectedItem.Text.Contains("Select a Folder") && !ddFiles.SelectedItem.Text.Contains("Select a Folder") && tbwidth.Text.Length > 0 && tbThumb.Text.Length > 0)
        {
            int h = 0;
            string appdir = Server.MapPath("~/App_Uploads_Img/" + ddCat2.SelectedItem.Text + "/");
            save= Server.MapPath("~/App_Uploads_Img/" + ddSavePath.SelectedItem.Text + "/");
            string Name = ddFiles.SelectedItem.Text;
            if (tbheight.Text.Length > 0)
            {
                h = Convert.ToInt32(tbheight.Text);
            }
            else { h = 0; }
            checkimageformat(save,appdir, Name, "_" + tbThumb.Text, Convert.ToInt32(tbwidth.Text), h, cbContstraint.Checked);
        }
        else 
        {
            errorlabel.ForeColor = System.Drawing.Color.Red;
            errorlabel.Text = "Your Information is not complete!" + Environment.NewLine; ;
            if(ddCat2.SelectedItem.Text.Contains("Select a Folder")||ddFiles.SelectedItem.Text.Contains("Select a Folder"))
                errorlabel.Text += "Image not selected." +Environment.NewLine;
            if(tbwidth.Text.Length == 0)
                errorlabel.Text += "Width not selected." + Environment.NewLine; ;
            if (cbContstraint.Checked==false&&tbheight.Text.Length==0)
                errorlabel.Text += "Enter Height or check Auto Constraint." + Environment.NewLine; 
            if (tbThumb.Text.Length == 0)
                errorlabel.Text += "Name not selected." + Environment.NewLine; ;
        }
    }
    #endregion
    #region autosize
    protected void Button1_Click(object sender, EventArgs e)
    {
        errorlabelauto.Text = "";
        if (!ddCat.SelectedItem.Text.Contains("Select a Folder"))
        {
           
            checksubfolders(ref alcheck, Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text + "/"));
            autogenerateimage(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text + "/"));
            showfiles(ddCat.SelectedItem.Value);
        }
        else
        {
            errorlabelauto.ForeColor = System.Drawing.Color.Red;
            errorlabelauto.Text = "Your Information is not complete!" + Environment.NewLine;
            if (ddCat.SelectedItem.Text.Contains("Select a Folder") )
                errorlabelauto.Text += "Folder not selected." + Environment.NewLine;
        }
    }
    public void checksubfolders(ref ArrayList alcheck, string dir)
    {
        errorlabelauto.Text = "";
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = dir;
            //string foldername = folder.Substring(appdir.Length);
            string foldername = folder;
            if (!foldername.Contains("_svn"))
            {
                alcheck.Add(foldername);
            }
           
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            checksubfolders(ref alcheck, dir2);
        }
        for (int x = 0; x <= alcheck.Count; x++)
        {
            if (!alcheck.ToString().Contains("medium"))
            {
                try
                {
                    Directory.CreateDirectory(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text) + "\\medium");
                }
                catch (Exception e)
                {
                    errorlabelauto.Text = e.Message;
                }
            }
            if (!alcheck.ToString().Contains("small"))
            {
                 try
                {
                Directory.CreateDirectory(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text) + "\\small");
                }
                catch (Exception e)
                {
                    errorlabelauto.Text = e.Message;
                }
            }
            //if (!alcheck.ToString().Contains("large"))
            //{
            //    try
            //    {
            //        Directory.CreateDirectory(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text) + "\\large");
            //    }
            //    catch (Exception e)
            //    {
            //        errorlabelauto.Text = e.Message;
            //    }
            //}
        }
    }
    private void autogenerateimage(string dir)
    {

        int i = 0;
        
        string[] files = Directory.GetFiles(dir);
        foreach (string file in files)
        {

            string appdir = dir;
            string filename = file.Substring(appdir.Length);
            af.Add(filename);
            if (!filename.Contains("_svn"))
            {
                decimal maxWidth = 0;
                decimal auto = 0;
                decimal newheight = 0;
                decimal widthlarge = 0;
                decimal newheightsmall = 0;
                decimal newheightmedium = 0;
                decimal newheightlarge = 0;
                decimal maxHeight = 0;
                string sThumbName = "";
                string fn = "";
                //set your dimensions here do not forget if you comment out one of the sizes to comment out the folder generation for it (checksubfolders)
                int widthsmall = 91;
                int widthmedium = 350;
                //int widthlarge = 640;
                fn = filename;
            
                System.Drawing.Image origImg = System.Drawing.Image.FromFile(appdir + @"\" + fn);
                maxWidth = Convert.ToDecimal(origImg.Width);
                maxHeight = Convert.ToDecimal(origImg.Height);
                auto = Math.Round((maxWidth / maxHeight), 4);

                newheightsmall = Math.Round((widthsmall / auto), 0);
                newheightmedium = Math.Round((widthmedium / auto), 0);
                //newheightlarge = Math.Round((640 / auto), 0);
                
                string path_small = Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text) + "\\small";
                string path_medium = Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text) + "\\medium";
                //string path_large = Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text) + "\\large";
                if (fn.IndexOf(".gif") > 0)
                {
                    GenerateThumbNail(path_small, appdir, fn, fn.Replace(".", "_sm" + "."), ImageFormat.Gif, widthsmall, Convert.ToInt32(newheightsmall));
                    GenerateThumbNail(path_medium, appdir, fn, fn.Replace(".", "_med" + "."), ImageFormat.Gif, widthmedium, Convert.ToInt32(newheightmedium));
                    //GenerateThumbNail(path_large,appdir, fn, fn.Replace(".", "_lg" + "."), ImageFormat.Gif, widthlarge, Convert.ToInt32(newheight));
                }
                if (fn.ToLower().IndexOf(".jpg") > 0)
                {
                    GenerateThumbNail(path_small, appdir, fn, fn.Replace(".", "_sm" + "."), ImageFormat.Jpeg, widthsmall, Convert.ToInt32(newheightsmall));
                    GenerateThumbNail(path_medium, appdir, fn, fn.Replace(".", "_med" + "."), ImageFormat.Jpeg, widthmedium, Convert.ToInt32(newheightmedium));
                    //GenerateThumbNail(path_large,appdir, fn, fn.Replace(".", "_lg" + "."), ImageFormat.Jpeg, widthlarge, Convert.ToInt32(newheight));
                }
                if (fn.ToLower().IndexOf(".jpeg") > 0)
                {
                    GenerateThumbNail(path_small, appdir, fn, fn.Replace(".", "_sm" + "."), ImageFormat.Jpeg, widthsmall, Convert.ToInt32(newheightsmall));
                    GenerateThumbNail(path_medium, appdir, fn, fn.Replace(".", "_med" + "."), ImageFormat.Jpeg, widthmedium, Convert.ToInt32(newheightmedium));
                    // GenerateThumbNail(path_large,appdir, fn, fn.Replace(".", "_lg" + "."), ImageFormat.Jpeg, widthlarge, Convert.ToInt32(newheight));
                }
                if (fn.ToLower().IndexOf(".bmp") > 0)
                {
                    GenerateThumbNail(path_small, appdir, fn, fn.Replace(".", "_sm" + "."), ImageFormat.Bmp, widthsmall, Convert.ToInt32(newheightsmall));
                    GenerateThumbNail(path_medium, appdir, fn, fn.Replace(".", "_med" + "."), ImageFormat.Bmp, widthmedium, Convert.ToInt32(newheightmedium));
                    // GenerateThumbNail(path_large,appdir, fn, fn.Replace(".", "_lg" + "."), ImageFormat.Bmp, widthlarge, Convert.ToInt32(newheight));
                }
                if (fn.ToLower().IndexOf(".png") > 0)
                {
                    GenerateThumbNail(path_small, appdir, fn, fn.Replace(".", "_sm" + "."), ImageFormat.Png, widthsmall, Convert.ToInt32(newheightsmall));
                    GenerateThumbNail(path_medium, appdir, fn, fn.Replace(".", "_med" + "."), ImageFormat.Png, widthmedium, Convert.ToInt32(newheightmedium));
                    // GenerateThumbNail(path_large, appdir, fn, fn.Replace(".", "_lg" + "."), ImageFormat.Png, widthlarge, Convert.ToInt32(newheight));
                }
                if (fn.ToLower().IndexOf(".tif") > 0)
                {
                    GenerateThumbNail(path_small, appdir, fn, fn.Replace(".", "_sm" + "."), ImageFormat.Tiff, widthsmall, Convert.ToInt32(newheightsmall));
                    GenerateThumbNail(path_medium, appdir, fn, fn.Replace(".", "_med" + "."), ImageFormat.Tiff, widthmedium, Convert.ToInt32(newheightmedium));
                    // GenerateThumbNail(path_large, appdir, fn, fn.Replace(".", "_lg" + "."), ImageFormat.Tiff, widthlarge, Convert.ToInt32(newheight));
                }
            }

        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        lbSuccess2.Controls.Clear();
        lbSuccess2.Controls.Add(new LiteralControl("Files will be deleted. This may take a few minutes."));
        string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text));
        foreach (string file in files)
        {
            af.Add(file);
        }
        System.Threading.Thread.Sleep(af.Count * 1000);
        Panel1.Visible = false;
        deletefilesfromfolder(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text));
    }
    public void deletefilesfromfolder(string del_directory)
    {
        //lbSuccess2.Text = "Files will be deleted. This may take a few minutes.";

        DirectoryInfo[] Dire;
        FileInfo[] file;
        int i;

        if (del_directory != "")
        {
            DirectoryInfo dir = new DirectoryInfo(del_directory);

            Dire = dir.GetDirectories();
            file = dir.GetFiles();

            if (Dire.Length > 0)
            {

                for (i = 0; i <= Dire.Length - 1; i++)
                {
                    try
                    {
                        Dire[1].Delete();
                    }
                    catch { ConfirmationLabel.Text = "The Directory is still in use please log out and log back in to delete the images."; }
                }
            }
            if (file.Length > 0)
            {

                for (i = 0; i <= file.Length - 1; i++)
                {
                    //if (file.IsReadOnly == false)
                    //{
                    try
                    {
                        file[i].Delete();
                        ConfirmationLabel.Text = "Files Deleted - ";
                        ConfirmationLabel.Style.Add("font-weight", "bold");
                        ConfirmationLabel.Style.Add("color", "green");
                        StatusLabel.Text = "<script>localization.setAttribute('refreshButtonLink', 'title', 'Refresh')</script>";
                    }
                    catch
                    {
                        ConfirmationLabel.Text = "The Directory is still in use.";
                        deletefilesfromfolder(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedItem.Text));
                    }
                    // }



                }
            }



        }

    }
   
    #endregion
    
}
