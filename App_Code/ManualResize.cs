using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
/// <summary>
/// Summary description for ManualResize
/// </summary>
[WebService(Namespace = "http://www.marnelltanner.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class ManualResize : System.Web.Services.WebService 
{
    StringBuilder sb = new StringBuilder();

    string sPhysicalPath = "";
    string sFileName = "";
    string sThumbName = "";
    int amount = 0;
    ArrayList af = new ArrayList();
    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();
    ArrayList alcheck = new ArrayList();
    string cat = "";
    [WebMethod(EnableSession = true)]
    public void resize(string contextKey)
    {
        
        string filepath = contextKey.Substring(0, contextKey.IndexOf(";"));
        string s = contextKey.Substring(filepath.Length + 1);
        string saveto = s.Substring(0,s.IndexOf(";"));
        string w = s.Substring(saveto.Length + 1);
        string width = w.Substring(0, w.IndexOf(";"));
        string h = w.Substring(width.Length + 1);
        string height = h.Substring(0, h.IndexOf(";"));
        string suff = h.Substring(height.Length + 1);
        string suffix = suff;
        string appdir = Server.MapPath("~/App_Uploads_Img/");
        string name = filepath.Substring(filepath.LastIndexOf("\\")+1);
        string path = filepath.Substring(0,filepath.LastIndexOf("\\") );
        
        if (height.Length == 0)
        {
            height = "0";
        }
        else { height = height; }

        checkimageformat(appdir + saveto, path, name, "_" + suffix, Convert.ToInt32(width), Convert.ToInt32(height));

       
    }
    public void checkimageformat(string savepath, string sPhysicalPath, string FName, string ThumbNailName, int width, int height)
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
        sThumbName = ThumbNailName + format;
        if (height > 0)
        {
            ThumbNailSize = new Size(width, height);
        }
        else
        {
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(sPhysicalPath +"\\"+ FName);
            maxWidth = Convert.ToDecimal(origImg.Width);
            maxHeight = Convert.ToDecimal(origImg.Height);
            auto = Math.Round((maxWidth / maxHeight), 4);

            newheight = Math.Round((width / auto), 0);
            ThumbNailSize = new Size(width, Convert.ToInt32(newheight));
        }

        if (sFileName.ToLower().IndexOf(".gif") > 0)
        {
            this.GenerateThumbNail(savepath, sPhysicalPath, sFileName, sThumbName, ImageFormat.Gif, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".jpg") > 0)
        {
            this.GenerateThumbNail(savepath, sPhysicalPath, sFileName, sThumbName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);

        }
        if (sFileName.ToLower().IndexOf(".jpeg") > 0)
        {
            this.GenerateThumbNail(savepath, sPhysicalPath, sFileName, sThumbName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".bmp") > 0)
        {
            this.GenerateThumbNail(savepath, sPhysicalPath, sFileName, sThumbName, ImageFormat.Bmp, ThumbNailSize.Width, ThumbNailSize.Height);
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

    public string GenerateThumbNail(string savePath, string sPhysicalPath, string sOrgFileName,
                                                                  string sThumbNailFileName, ImageFormat oFormat, int widthnew, int heightnew)
    {
        string filename = sOrgFileName.Substring(0,sOrgFileName.LastIndexOf("."));
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
                oThumbNail.Save(savePath + @"\" + filename + sThumbNailFileName, oFormat);
                oGraphic.Dispose();
                oThumbNail.Dispose();
                oImg.Dispose();
                GC.Collect();
                sb.Append(savePath + "\\" + filename+sThumbNailFileName);
            }
            else
            {
                Bitmap bm = new Bitmap(sPhysicalPath + @"\" + sOrgFileName);

                Bitmap bm2 = new Bitmap(thumsize.Width, thumsize.Height, PixelFormat.Format64bppPArgb);
                Graphics g2 = Graphics.FromImage(bm2);
                Rectangle subRect = new Rectangle(0, 0, thumsize.Width, thumsize.Height);
                g2.DrawImage(bm, subRect);
                bm2.Save(savePath + @"\" + filename + sThumbNailFileName, oFormat);
                g2.Dispose();
                bm2.Dispose();
                bm.Dispose();
                GC.Collect();

                sb.Append(savePath + "\\" + filename + sThumbNailFileName);
                
            }
            Session["manualresize"] = savePath + "\\" + filename + sThumbNailFileName; 
        }
        catch (Exception e1) { sb.Append(e1.Message); }
        return sb.ToString();
    }
    
    
}

