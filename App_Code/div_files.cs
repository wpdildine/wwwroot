using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Text;
using System.Drawing;

/// <summary>
/// Summary description for div_files
/// </summary>
[WebService(Namespace = "http://www.marnelltanner.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class div_files : System.Web.Services.WebService 
{
        string caption = "";
    int width = 0;
    string servicepath = "http://" + HttpContext.Current.Request.Url.Host + "/";
    string folder = HttpContext.Current.Request.PhysicalApplicationPath;
    [WebMethod]
    public string getcontent(string contextKey)
    {
       
        string path = contextKey.Substring(0, contextKey.LastIndexOf(":"));
        string file = contextKey.Substring(path.Length + 1);
        string ext = file.Substring(file.LastIndexOf("."));
        StringBuilder swa = new StringBuilder();
        
        string imageurl = servicepath + "App_Uploads_Img/";
        string movieurl = servicepath + "App_Uploads_Movies/";
        string docsurl = servicepath + "App_Uploads_Docs/";
        string audiourl = servicepath + "App_Uploads_Audio/";
        path = servicepath + path.Replace(folder,"");
        path = path.Replace("\\","/");

        if (checkfile(ext) == "image")
        {

            Bitmap ImageOrig = new Bitmap(@contextKey.Substring(0, contextKey.LastIndexOf(":")), true);
            int ImageOrigHeight = ImageOrig.Height;
            int ImageOrigWidth = ImageOrig.Width;
            
            if ((ImageOrigHeight > 200)||(ImageOrigWidth > 200))
            {
                //ImageOrigHeight = ImageOrigHeight / 2;
               
                width = 200;
                ImageOrigHeight=getdimensions(width, ImageOrig.Width, ImageOrig.Height);
                ImageOrigWidth = width;

            }
            caption = getcaption(file,ImageOrigHeight, ImageOrigWidth);
            swa.Append("<strong>Image Preview</strong>");
            swa.Append("<p>Click on the thumbnail to view the original version of it.</p>");
            swa.Append("<a target=\"_blank\" href=\"" + path + "\"" + "  title=\"" + file + "\"" + " ><img id=\"preview_image\"" + "alt=" + "\"" + file + "\"" + "height=" + "\"" + ImageOrigHeight.ToString() + "\"" + "width=" + "\"" + ImageOrigWidth.ToString() + "\"" + "src=\"" + path + "\"" + "/></a>");
        }
        if (checkfile(ext) == "docs")
        {
            
            path = path.Replace(folder, "");
            path = path.Replace("\\", "/");
            swa.Append("<strong>Document Preview</strong>");
            swa.Append("<p>Click on the thumbnail to view your document.</p>");
            swa.Append("<a target=\"blank\" href=\"" + path + "\"" + " ><img  id=\"" + file + "\"" + "alt=" + "\"" + file + "\"" + "height=\"150px\" width=\"100px\" src=" + "\"" + getimage(ext) + "\"" + " /></a>");
        
        }
        if (checkfile(ext) == "movie")
        {
            path = path.Replace(folder, "");
            path = path.Replace("\\", "/");
            swa.Append("<strong>Movie Preview</strong>");
            swa.Append("<p>Click on the thumbnail to view the movie.</p>");
            swa.Append("<a target=\"blank\" href=\"" + path + "\"" + " ><img  id=\"" + file + "\"" + "alt=" + "\"" + file + "\"" + "height=\"150px\" width=\"100px\" src=" + "\"" + getimage(ext) + "\"" + " /></a>");
        }
        if (checkfile(ext) == "audio")
        {
            path = path.Replace(folder, "");
            path = path.Replace("\\", "/");
            swa.Append("<strong>Audio Preview</strong>");
            swa.Append("<p>Click on the thumbnail to view the audio.</p>");
            swa.Append("<a target=\"blank\" href=\"" + path + "\"" + " ><img  id=\"" + file + "\"" + "alt=" + "\"" + file + "\"" + "height=\"150px\" width=\"100px\" src=" + "\"" + getimage(ext) + "\"" + " /></a>");
        }
        return swa.ToString();
    }
    [WebMethod]
    public string getimageforpop(string contextKey)
    {

        string path = contextKey.Substring(0, contextKey.LastIndexOf(":"));
        string file = contextKey.Substring(path.Length + 1);
        string ext = file.Substring(file.LastIndexOf("."));
        StringBuilder swa = new StringBuilder();

        string imageurl = servicepath + "App_Uploads_Img/";

        path = servicepath + path.Replace(folder, "");
        path = path.Replace("\\", "/");

        if (checkfile(ext) == "image")
        {

            Bitmap ImageOrig = new Bitmap(@contextKey.Substring(0, contextKey.LastIndexOf(":")), true);
            int ImageOrigHeight = ImageOrig.Height;
            int ImageOrigWidth = ImageOrig.Width;

            if ((ImageOrigHeight > 200) || (ImageOrigWidth > 200))
            {
                //ImageOrigHeight = ImageOrigHeight / 2;

                width = 200;
                ImageOrigHeight = getdimensions(width, ImageOrig.Width, ImageOrig.Height);
                ImageOrigWidth = width;

            }
            caption = getcaption(file, ImageOrigHeight, ImageOrigWidth);

            swa.Append("<img  id=\"" + file + "\"" + "alt=" + "\"" + file + "\"" + "height=" + "\"" + ImageOrigHeight.ToString() + "\"" + "width=" + "\"" + ImageOrigWidth.ToString() + "\"" + "src=\"" + path + "\"" + "/>");
        
        }
      
        return swa.ToString();
    }
    [WebMethod]
    public string getallinfolder(string contextKey)
    {
        string path = contextKey.Substring(0, contextKey.LastIndexOf(":"));
        string file = contextKey.Substring(path.Length + 1);       
        StringBuilder swa = new StringBuilder();
             
        string[] files = Directory.GetFiles(contextKey.Substring(0, contextKey.LastIndexOf(":")));
        if (path.Contains("App_Uploads_Img"))
        {
            swa.Append("<strong>Image Preview - " + file + "</strong>");
            swa.Append("<p>Click on the image to preview.  Select a folder <br />to preview its contents.</p>");
        }
        else if (path.Contains("App_Uploads_Docs"))
        {
         swa.Append("<strong>Document Preview - " + file + "</strong>");
         swa.Append("<p>Click on the link below to preview.  Select a folder <br />to preview its contents.</p>");
        }
        else if (path.Contains("App_Uploads_Movies"))
        {
            swa.Append("<strong>Movie Preview - " + file + "</strong>");
            swa.Append("<p>Click on the link below to preview.  Select a folder <br />to preview its contents.</p>");
        }
        else if (path.Contains("App_Uploads_Audio"))
        {
            swa.Append("<strong>Audio Preview - " + file + "</strong>");
            swa.Append("<p>Click on the link below to preview.  Select a folder <br />to preview its contents.</p>");
        }
        swa.Append("<table id=\"preview_image_cont\">");

        
        int x = 0;
        foreach (string fil in files)
        {
          
            if (!Path.GetFileName(fil).Contains("_svn") && !Path.GetFileName(fil).Contains(".svn"))
            {
                if (checkfile(Path.GetExtension(fil))=="image")
                {
                    Bitmap ImageOrig = new Bitmap(Path.GetFullPath(fil), true);
                    int ImageOrigHeight = ImageOrig.Height;
                    int ImageOrigWidth = ImageOrig.Width;
                    if (ImageOrig.Width > 100)
                    {
                        width = 100;
                    }
                    else
                    {
                        width = ImageOrigWidth;
                    }
                    ImageOrigHeight = getdimensions(width, ImageOrig.Width, ImageOrig.Height);
                    ImageOrigWidth = width;
                    caption = getcaption(Path.GetFileName(fil), ImageOrigHeight, ImageOrigWidth);

                    string imageurl = Path.GetFullPath(fil).ToString().Replace(folder, servicepath);
                    imageurl = imageurl.Replace("\\", "/");
                    if (x == 0)
                    {
                       swa.Append("<tr>");
                    }
                    swa.Append("<td>");
                    swa.Append("<a target=\"blank\" class=\"preview_image\" href=\"" + imageurl + "\"" + "  title=\"" + Path.GetFileName(fil).ToString() + "\"" + " ><img  id=\"" + Path.GetFileName(fil).ToString() + "\"" + "alt=" + "\"" + Path.GetFileName(fil).ToString() + "\"" + "height=" + "\"" + ImageOrigHeight.ToString() + "\"" + "width=" + "\"" + ImageOrigWidth.ToString() + "\"" + "src=\"" + imageurl + "\"" + "/></a>");
                    
                    swa.Append("</td>");
                    if  (x == 2)
                    {
                        swa.Append("</tr>");
                    }
                    x++;
                    if (x > 2)
                        x = 0;
                }
                else if (checkfile(Path.GetExtension(fil)) == "docs")
                {

                    string url = Path.GetFullPath(fil).ToString().Replace(folder, servicepath);
                    url = url.Replace("\\", "/");

                    if (x == 0)
                    {
                        swa.Append("<tr>");
                    }
                    swa.Append("<td><p style=\"margin-bottom: 5px;\"><span style=\"font-size: 11px; font-weight: bold; display: block;\">");
                    swa.Append(Path.GetFileName(fil).ToString());
                    swa.Append("</span><a target=\"blank\" href=\"" + url + "\"" + " ><img  id=\"" + Path.GetFileName(fil).ToString() + "\"" + "alt=\"" + Path.GetFileName(fil).ToString() + "\"" + "height=\"25px\" width=\"200px\" src=" + "\"" + getbigimage(Path.GetExtension(fil)) + "\"" + "   /></a>");
                    swa.Append("</p></td><tr>");
                    
                }
                else if (checkfile(Path.GetExtension(fil)) == "movie")
                {

                    string url = Path.GetFullPath(fil).ToString().Replace(folder, servicepath);
                    url = url.Replace("\\", "/");

                    if (x == 0)
                    {
                        swa.Append("<tr>");
                    }
                    swa.Append("<td><p style=\"margin-bottom: 5px;\"><span style=\"font-size: 11px; font-weight: bold; display: block;\">");
                    swa.Append(Path.GetFileName(fil).ToString());
                    swa.Append("</span><a target=\"blank\" href=\"" + url + "\"" + " ><img  id=\"" + Path.GetFileName(fil).ToString() + "\"" + "alt=\"" + Path.GetFileName(fil).ToString() + "\"" + "height=\"25px\" width=\"200px\" src=" + "\"" + getbigimage(Path.GetExtension(fil)) + "\"" + "   /></a>");
                    swa.Append("</p></td><tr>");

                }
                else if (checkfile(Path.GetExtension(fil)) == "audio")
                {

                    string url = Path.GetFullPath(fil).ToString().Replace(folder, servicepath);
                    url = url.Replace("\\", "/");

                    if (x == 0)
                    {
                        swa.Append("<tr>");
                    }
                    swa.Append("<td><p style=\"margin-bottom: 5px;\"><span style=\"font-size: 11px; font-weight: bold; display: block;\">");
                    swa.Append(Path.GetFileName(fil).ToString());
                    swa.Append("</span><a target=\"blank\" href=\"" + url + "\"" + " ><img  id=\"" + Path.GetFileName(fil).ToString() + "\"" + "alt=\"" + Path.GetFileName(fil).ToString() + "\"" + "height=\"25px\" width=\"200px\" src=" + "\"" + getbigimage(Path.GetExtension(fil)) + "\"" + "   /></a>");
                    swa.Append("</p></td><tr>");

                }
            }
        }


        swa.Append("</table>");
        return swa.ToString();
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
  

    public string getcaption(string name,int height,int width)
    {
        if ((height <= 100) || (width <= 100))
        {
            caption = "";
        }
        else
        {
            caption = name + "    width:" + width.ToString() + "px height:" + height.ToString() + "px";
        }
        return caption;
    }
    private string getimage(string fileName)
    {
        string image = "File.gif";

        switch (fileName.ToLower())
        {


            case ".html":
                image = "/admin/images/html_preview.gif";
                break;


            case ".pdf":
                image = "/admin/images/ico_pdf_preview.gif";
                break;
          
            case ".doc":
                image = "/admin/images/ico_word_preview.gif";
                break;

            case ".xls":
                image = "/admin/images/ico_excel_preview.gif";
                break;
            case ".zip":
                image = "/admin/images/ico_zip_preview.gif";
                break;
            case ".mov":
                image = "/admin/images/ico_quicktime_preview.gif";
                break;
            case ".flv":
                image = "/admin/images/ico_flv_preview.gif";
                break;
            case ".mp3":
                image = "/admin/images/ico_mp3_preview.gif";
                break;
            case ".wmv":
                image = "/admin/images/ico_flv_preview.gif";
                break;
            case ".png":
            case ".bmp":
            case ".tif":
            case ".jpeg":
            case ".gif":
            case ".jpg":
                image = "/admin/images/gif.gif";
                break;

            case "":
                image = "/admin/images/folder.gif";
                break;
        }

        return image;
    }
    private string getbigimage(string fileName)
    {
        string image = "File.gif";

        switch (fileName.ToLower())
        {


            case ".html":
                image = "/admin/images/html_preview_sm.gif";
                break;


            case ".pdf":
                image = "/admin/images/ico_pdf_preview_sm.gif";
                break;
           
            case ".doc":
                image = "/admin/images/ico_word_preview_sm.gif";
                break;

            case ".xls":
                image = "/admin/images/ico_excel_preview_sm.gif";
                break;
            case ".zip":
                image = "/admin/images/ico_zip_preview_sm.gif";
                break;
         
            case ".mov":
                image = "/admin/images/ico_quicktime_preview_sm.gif";
                break;
            case ".flv":
                image = "/admin/images/ico_flv_preview_sm.gif";
                break;
            case ".mp3":
                image = "/admin/images/ico_mp3_preview_sm.gif";
                break;
            case ".wmv":
                image = "/admin/images/ico_flv_preview_sm.gif";
                break;

            case ".png":
            case ".bmp":
            case ".tif":
            case ".jpeg":
            case ".gif":
            case ".jpg":
                image = "/admin/images/gif.gif";
                break;

            case "":
                image = "/admin/images/folder.gif";
                break;
        }

        return image;
    }
    public string checkfile(string ext)
    {
        switch (ext.ToLower())
        {


            case ".html":
            case ".pdf":
            case ".doc":
            case ".xls":
            case ".ppt":
            case ".zip":
                ext = "docs";
                break;

            case ".png":
            case ".bmp":
            case ".tif":
            case ".jpeg":
            case ".gif":
            case ".jpg":
                ext = "image";
                break;

            case ".mov":
            case ".flv":
                ext = "movie";
                break;

            case ".mp3":
                ext = "audio";
                break;
        }
        return ext;


    }
    
}

