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

using epicCMS;
using System.IO;

public partial class admin_controls_cmsPDFEditControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  hlPdf.NavigateUrl = getPdfURL();
    }

    private string getPdfURL()
    {
        if (_itemId > 0)
        {
            tblItemFieldsXValue val = new tblItemFieldsXValue();
            val.Where.LanguageId.Value = Int32.Parse(Request["langId"]);

            // 4 is PDF location
            val.Where.ItemFieldId.Value = 4;
            val.Where.ItemId.Value = _itemId;

            val.Query.Load();

            if (val.RowCount > 0)
            {
                val.Rewind();
                return "~/renderpdf.aspx?itemId=" + _itemId.ToString() + "&hei=100";
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "~/renderpdf.aspx?pdfid=" + _pdfId.ToString();
        }
    }

    private int _itemId=-1;
    public int ItemId
    {
        set { _itemId = value; }
        get { return _itemId; }
    }

    private int _pdfId;
    public int PdfId
    {
        set { _pdfId = value; }
        get { return _pdfId; }
    }

    public void SaveValue()
    {
        if (FileUpload1.PostedFile.ContentLength > 0)
        {
            tblItemFieldsXValue val = new tblItemFieldsXValue();
            val.Where.ItemId.Value = _itemId;

            // hard coded
            val.Where.ItemFieldId.Value = 3;
            val.Where.LanguageId.Value = int.Parse(Request["langId"]);

            val.Query.Load();

           // tblItemFieldBlobValues imgAsset = new tblItemFieldBlobValues();
            //imgAsset.AddNew();
            tblPdfAssets imgAsset = new tblPdfAssets();
            imgAsset.AddNew();

            int sizeFile = FileUpload1.PostedFile.ContentLength;
            imgAsset.PdfData = getImageBits(FileUpload1.PostedFile.InputStream, sizeFile);
           // imgAsset.ImageTitle = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("\\") + 1);
            imgAsset.PdfTitle = TextBox1.Text;

            imgAsset.Save();
        }
    }

    private byte[] getImageBits(Stream fs, int size)
    {
        byte[] img = new byte[size];
        fs.Read(img, 0, size);
        return img;
    }
}
