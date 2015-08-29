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
using epicImageTools;
public partial class rendertext : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // pass this page textval, font, size, fc(forecolor), bc(backcolor, style)
        // example: rendertext.aspx?textval=Testing&fc=000000&bc=FFFFFF&font=Arial&size=16&style=regular
        Response.ContentType = "image/gif";
        System.Drawing.Image img = epicImageTools.epicImage.CreateTextImage(Request["textval"], Request["fc"], Request["bc"], Convert.ToInt32(Request["size"]), Request["font"], Request["style"]);

        epicImageTools.OctreeQuantizer quantizer = new epicImageTools.OctreeQuantizer(255,8);
        using (System.Drawing.Bitmap quantized = quantizer.Quantize(img))
        {
            Response.ContentType = "image/gif";
            quantized.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
}
