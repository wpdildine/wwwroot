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

public partial class admin_controls_cmsImageEditControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = getImageUrl();
    }

    private string getImageUrl()
    {
        //tblItemFieldsXValue val = new tblItemFieldsXValue();
        //val.Where.LanguageId.Value = Int32.Parse(Request["langId"]);

        //// 3 is image location
        //val.Where.ItemFieldId.Value = 3;
        //val.Where.ItemId.Value = _itemId;

        //val.Query.Load();

        //if (val.RowCount > 0)
        //{
        //    val.Rewind();
        //    return "~/renderimage.aspx?itemId=" + _itemId.ToString() +"&hei=100";
        //}
        //else
        //{
        //    return "~/images/spacer.gif";
        //}
        if (Request["img"] != null)
        {
            return "~/renderimage.aspx?imageId=" + Request["img"] + "&hei=100";
        }
        else
        {
            return "~/images/spacer.gif";
        }
    }

    public void SaveValue()
    {
        if (FileUpload1.PostedFile.ContentLength > 0)
        {
            //tblItemFieldsXValue val = new tblItemFieldsXValue();
            //val.Where.ItemId.Value = _itemId;

            //// hard coded
            //val.Where.ItemFieldId.Value = 3;
            //val.Where.LanguageId.Value = int.Parse(Request["langId"]);

            //val.Query.Load();

            tblImageAssets imgAsset = new tblImageAssets();
            if (_imageId > -1)
                imgAsset.LoadByPrimaryKey(_imageId);
            else
                imgAsset.AddNew();

            int sizeFile = FileUpload1.PostedFile.ContentLength;
            imgAsset.ImageData = getImageBits(FileUpload1.PostedFile.InputStream, sizeFile);
            imgAsset.ImageTitle = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("\\") + 1);
            imgAsset.ImageCategory = Convert.ToInt32(Request["catid"]);

            imgAsset.Save();
        }
    }

    private byte[] getImageBits(Stream fs, int size)
    {
        byte[] img = new byte[size];
        fs.Read(img, 0, size);
        return img;
    }



    private int _imageId=-1;
    public int ImageId
    {
        set { _imageId = value; }
        get { return _imageId; }
    }
 
}
