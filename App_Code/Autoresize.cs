using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

/// <summary>
/// Summary description for Autoresize
/// </summary>
[WebService(Namespace = "http://www.marnelltanner.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Autoresize : System.Web.Services.WebService 
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
    StringBuilder sb = new StringBuilder();
    [WebMethod(EnableSession = true)]
    public void getimages(string contextKey)
    {
        contextKey = contextKey.Replace("\\", "/");
        if (!contextKey.Contains("Select a Folder"))
        {
            Session["autoresize"] = contextKey;
            checksubfolders(ref alcheck, Server.MapPath("~/App_Uploads_Img/" + contextKey + "/"), contextKey);
            autogenerateimage(Server.MapPath("~/App_Uploads_Img/" + contextKey + "/"), contextKey);
            
        }
      
    }
    public void checksubfolders(ref ArrayList alcheck, string dir,string key)
    {
        
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = dir;
            //string foldername = folder.Substring(appdir.Length);
            string foldername = folder;
            if (!foldername.Contains("_svn") && (!foldername.Contains(".svn")))
            {
                alcheck.Add(foldername);
            }

        }
        string key2 = key;
        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            checksubfolders(ref alcheck, dir2,key2);
        }
        for (int x = 0; x <= alcheck.Count; x++)
        {
            if (!alcheck.ToString().Contains("medium"))
            {
                try
                {
                    Directory.CreateDirectory(Server.MapPath("~/App_Uploads_Img/" + key) + "\\medium");
                }
                catch (Exception e)
                {
                    //errorlabelauto.Text = e.Message;
                }
            }
            if (!alcheck.ToString().Contains("small"))
            {
                try
                {
                    Directory.CreateDirectory(Server.MapPath("~/App_Uploads_Img/" + key) + "\\small");
                }
                catch (Exception e)
                {
                    //errorlabelauto.Text = e.Message;
                }
            }
            //if (!alcheck.ToString().Contains("large"))
            //{
            //    try
            //    {
            //        Directory.CreateDirectory(Server.MapPath("~/App_Uploads_Img/" + key) + "\\large");
            //    }
            //    catch (Exception e)
            //    {
            //        errorlabelauto.Text = e.Message;
            //    }
            //}
        }
    }
    private void autogenerateimage(string dir,string folder)
    {

        int i = 0;

        string[] files = Directory.GetFiles(dir);
        foreach (string file in files)
        {

            string appdir = dir;
            string filename = file.Substring(appdir.Length);
            af.Add(filename);
            if (!filename.Contains("_svn")&&(!filename.Contains(".svn")))
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
                // these values can change depending on what sizes the client wants
                
                int widthsmall = 75;
                int widthmedium = 310;
                //int widthlarge = 640;

                int heightsmall = 50;
                fn = filename;

                System.Drawing.Image origImg = System.Drawing.Image.FromFile(appdir + @"\" + fn);
                maxWidth = Convert.ToDecimal(origImg.Width);
                maxHeight = Convert.ToDecimal(origImg.Height);
                auto = Math.Round((maxWidth / maxHeight), 4);

                newheightsmall = heightsmall;
                //newheightsmall = Math.Round((widthsmall / auto), 0);
                newheightmedium = Math.Round((widthmedium / auto), 0);
                //newheightlarge = Math.Round((640 / auto), 0);

                string path_small = Server.MapPath("~/App_Uploads_Img/" + folder) + "\\small";
                string path_medium = Server.MapPath("~/App_Uploads_Img/" + folder) + "\\medium";
                //string path_large = Server.MapPath("~/App_Uploads_Img/" + contextkey) + "\\large";
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
                origImg.Dispose();
                GC.Collect();
            }

        }

    }
    public void delete(string key)
    {
        //lbSuccess2.Controls.Clear();
        //lbSuccess2.Controls.Add(new LiteralControl("Files will be deleted. This may take a few minutes."));
        string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/" + key));
        foreach (string file in files)
        {
            af.Add(file);
            //System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/" + contextkey + "/") + file);
           // origImg.
        }
        System.Threading.Thread.Sleep(af.Count * files.Length);
        deletefilesfromfolder(Server.MapPath("~/App_Uploads_Img/" + key));
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
                    catch
                    {
                        // ConfirmationLabel.Text = "The Directory is still in use please log out and log back in to delete the images."; 
                    }
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
                        // ConfirmationLabel.Text = "Files Deleted - ";
                        // ConfirmationLabel.Style.Add("font-weight", "bold");
                        // ConfirmationLabel.Style.Add("color", "green");
                        // StatusLabel.Text = "<script>localization.setAttribute('refreshButtonLink', 'title', 'Refresh')</script>";
                    }
                    catch
                    {
                        // ConfirmationLabel.Text = "The Directory is still in use.";
                        deletefilesfromfolder(del_directory);
                    }
                    // }



                }
            }



        }

    }
    public string GenerateThumbNail(string savePath, string sPhysicalPath, string sOrgFileName,
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
                GC.Collect();
                //if (Request["id"] == "1")
                //{
                //    //lbSuccess.ForeColor = System.Drawing.Color.Green;
                //    //updateProgress1.lb.Text = "Image " + sThumbNailFileName + " created.";
                //    ddFiles.SelectedItem.Text = sThumbNailFileName;
                //    System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text);
                //    Label3.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
                //    divimage.InnerHtml = "<img src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text + "></img>";
                //}
                //else
                //{
                    sb.Append(sThumbNailFileName);
                    sb.Append("<br/>");
                //}
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
                GC.Collect();

                //if (Request["id"] == "1")
                //{
                //    //lbSuccess.ForeColor = System.Drawing.Color.Green;
                //    //lbSuccess.Text = "Image " + sThumbNailFileName + " created.";
                //    ddFiles.SelectedItem.Text = sThumbNailFileName;
                //    System.Drawing.Image origImg = System.Drawing.Image.FromFile(Server.MapPath("~/App_Uploads_Img/") + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text);
                //    Label3.Text = "Your selected Image's Width is " + origImg.Width.ToString() + "px and Height is " + origImg.Height.ToString() + "px.";
                //    divimage.InnerHtml = "<img src=" + epicCMSLib.Navigation.SiteRoot + "App_Uploads_Img/" + ddCat2.SelectedItem.Text + "/" + ddFiles.SelectedItem.Text + "></img>";
                //}
                //else
                //{
                    //lbSuccess2.ForeColor = System.Drawing.Color.Green;
                    sb.Append("<p>"+sThumbNailFileName + " created.</p>");
                    sb.Append("<br/>");
               // }
            }
        }
        catch (Exception e1) { sb.Append(e1.Message.ToString()); }
        
        return sb.ToString();
    }

}

