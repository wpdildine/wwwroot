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
public partial class admin_controls_images_ctlImageManager : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {


        //PlaceHolder1.Controls.Add("~/RadControls/Editor/Dialogs/ImageManager.ascx");
        //RadEditor1.Controls.Add(LoadControl(Server.MapPath(epicCMSLib.Navigation.SiteRoot + "RadControls/Editor/Dialogs/ImageManager.ascx")));
        Page.RegisterStartupScript("MyScript", "<script type='text/javascript'  language='javascript'>" + " function ShowImageDialog(){var editor =" + RadEditor1.ClientID + ";editor.Fire('ImageManager', callBackFn); }" + "</script>");
        Page.RegisterStartupScript("MyScript", "<script type='text/javascript'  language='javascript'>" + "function callBackFn(result){ if (result) {var imageArea = document.getElementById('ImageArea');  var img = document.createElement ('IMG'); img.src = result.imagePath;imageArea.appendChild (img); }; }" + "</script>");

        //GetDirectories();
        string[] imagepath = { "~/App_Uploads_Img/" };
        RadEditor1.UploadImagesPaths = imagepath;
        RadEditor1.ImagesPaths = imagepath;
        RadEditor1.DeleteImagesPaths = imagepath;

        //manual.HRef = epicCMSLib.Navigation.PopupPageLink("controls/images/resizing.aspx?id=1", 450, 400);
        //auto.HRef = epicCMSLib.Navigation.PopupPageLink("controls/images/resizing.aspx?id=2", 450, 400);
    }
}