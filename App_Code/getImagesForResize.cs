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
public class getImagesForResize : System.Web.Services.WebService {
      
    [WebMethod]
    public string showfiles(string contextKey)
    {
        StringBuilder sb = new StringBuilder();
        string fold = contextKey;
        string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + fold);
        
        foreach (string file in files)
        {
            if (files.Length > 0)
            {
              
                string appdir = Server.MapPath("~/App_Uploads_Img/" + fold + "/");
                string filename = file.Substring(appdir.Length);
                //string filename = file;
                if (!filename.Contains("_svn") && (!filename.Contains(".svn")))
                {
                    sb.Append(filename);
                    sb.Append("<br/>");
                   
                }
            }
        }
       return sb.ToString();
    }
    
}




