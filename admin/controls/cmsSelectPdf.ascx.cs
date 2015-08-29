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

public partial class admin_controls_cmsSelectPdf : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink1.NavigateUrl = epicCMSLib.Navigation.PopupPageLink(epicCMSLib.Navigation.SiteRoot + "admin/AddPdf.aspx", "editimage", 320, 150);

        if (!Page.IsPostBack)
        {
            loadPdfs();
        }
        else
        {
            if (ViewState["mypdf"] != null)
                _pdfid = Int32.Parse(ViewState["mypdf"].ToString());
        }
    }

    private void loadPdfs()
    {
        tblPdfAssets assets = new tblPdfAssets();
        assets.LoadAll();

        int sel = -1;
        if (_itemId > -1)
        {
            tblItems itm = new tblItems();
            itm.LoadByPrimaryKey(_itemId);

            tblItemFieldsXValue val = new tblItemFieldsXValue();
            val.Where.ItemId.Value = _itemId;
            val.Where.ItemFieldId.Value = 5;
            val.Where.LanguageId.Value = int.Parse(Request["langId"]);

            val.Query.Load();

            if (val.RowCount > 0)
            {
                val.Rewind();
                if (_temp)
                    sel = val.ItemFieldPdfAssetTempId;
                else
                    sel = val.ItemFieldPdfAssetId;
                HyperLink2.Text = "View PDF";
                HyperLink2.Target = "_blank";
                HyperLink2.NavigateUrl = "~/renderpdf.aspx?itemid=" + _itemId.ToString()+"&langid=" + Request["langid"];
            }
            else
            {
                val.AddNew();
                val.ItemId = _itemId;
                val.ItemFieldId = 5;
                val.LanguageId = int.Parse(Request["langId"]);
                val.ItemFieldPdfAssetId = -1;
                val.Save();
            }
        }
        else
        {
            if (_pdfid > -1)
            {
                HyperLink2.NavigateUrl = "~/renderpdf.aspx?pdfid=" + _pdfid.ToString();
                HyperLink2.Text = "View PDF";
                HyperLink2.Target = "_blank";
                sel = _pdfid;
            }
            else
            {
                HyperLink2.Visible = false;
                LinkButton1.Visible = false;
            }
        }

        ListItem li2 = new ListItem("--Select--");
        DropDownList1.Items.Add(li2);
        if (assets.RowCount > 0)
        {
            assets.Rewind();
            do
            {
                ListItem li = new ListItem(assets.PdfTitle, assets.PdfAssetId.ToString());

                if (sel == assets.PdfAssetId)
                {
                    li.Selected = true;
                }

                DropDownList1.Items.Add(li);
            } while (assets.MoveNext());
        }

        if (DropDownList1.SelectedIndex == 0)
        {
            HyperLink2.Visible = false;
            LinkButton1.Visible = false;
        }
    }

    public void SaveValue()
    {
        if (DropDownList1.SelectedIndex > 0)
        {
            tblItems itm = new tblItems();
            itm.LoadByPrimaryKey(_itemId);

            tblItemFieldsXValue val = new tblItemFieldsXValue();
            val.Where.ItemId.Value = _itemId;
            val.Where.ItemFieldId.Value = 5;
            val.Where.LanguageId.Value = int.Parse(Request["langId"]);

            val.Query.Load();

            if (val.RowCount == 0)
            {
                val.AddNew();
                val.ItemId = _itemId;
                val.ItemId = 5;
                val.LanguageId = int.Parse(Request["langId"]);
            }

            if (val.ItemFieldPdfAssetId != Int32.Parse(DropDownList1.SelectedValue))
                val.ItemFieldPdfAssetTempId = Int32.Parse(DropDownList1.SelectedValue);
            val.Save();
        }
    }

    private bool _temp;
    public bool IsTemp()
    {
        getTemp();
        return _temp;
    }
    private void getTemp()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 5;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        try
        {
            int ret = val.ItemFieldPdfAssetTempId;
            _temp = true;
        }
        catch
        {
            _temp = false;
        }
    }

    public void RejectChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 5;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        val.s_ItemFieldPdfAssetTempId = "";
        val.Save();
    }

    public void ApproveChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 5;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        val.ItemFieldPdfAssetId = val.ItemFieldPdfAssetTempId;
        val.s_ItemFieldPdfAssetTempId = "";

        val.Save();
    }

    private int _pdfid = -1;
    public int PdfId
    {
        get { return _pdfid; }
        set { _pdfid = value; }
    }

    private int _itemId = -1;
    public int ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex > 0)
        {
            _pdfid = Int32.Parse(DropDownList1.SelectedValue);
            // Image1.ImageUrl = "~/renderimage.aspx?imageid=" + DropDownList1.SelectedValue + "&hei=100";
            HyperLink2.NavigateUrl = "~/renderpdf.aspx?pdfid=" + _pdfid.ToString();
            HyperLink2.Text = "View PDF";
            HyperLink2.Target = "_blank";
            HyperLink2.Visible = true;
        }
        else
        {
            _pdfid = -1;
        }
        ViewState["mypdf"] = _pdfid;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        tblPdfAssets pdfs = new tblPdfAssets();
        pdfs.LoadByPrimaryKey(_pdfid);

        pdfs.MarkAsDeleted();
        pdfs.Save();

        Response.Redirect(Request.RawUrl);
    }
}
