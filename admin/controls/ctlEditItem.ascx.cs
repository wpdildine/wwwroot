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

public partial class admin_controls_ctlEditItem : System.Web.UI.UserControl
{
    private string _itemTypeTitle;
    private int _itemId;
    private bool _custom = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((int)UserContext.GetContextItemAsInt("userlevel") > 1)
            LinkButton1.Visible = false;
    }

    public void SaveItem()
    {
        if (_custom)
        {
            epicCMSCustomControl ctl = (epicCMSCustomControl)PlaceHolder1.Controls[0];
            ctl.SaveData();
        }
        else
        {
            switch (_itemTypeTitle)
            {
                case "epicCMSRichTextControl":
                    admin_controls_cmsTextEditControl txt = (admin_controls_cmsTextEditControl)PlaceHolder1.Controls[0];
                    txt.SaveValue();
                    break;
                case "epicCMSTextControl":
                    admin_controls_cmsBasicTextEditControl txt2 = (admin_controls_cmsBasicTextEditControl)PlaceHolder1.Controls[0];
                    txt2.SaveValue();
                    break;
                case "epicCMSImageControl":
                    admin_controls_cmsSelectImage img = (admin_controls_cmsSelectImage)PlaceHolder1.Controls[0];
                    img.SaveValue();
                    break;
                case "epicCMSPDFControl":
                    admin_controls_cmsSelectPdf pdf = (admin_controls_cmsSelectPdf)PlaceHolder1.Controls[0];
                    pdf.SaveValue();
                    break;
                case "epicCMSImageTextControl":
                    admin_controls_cmsTextImageEditControl te = (admin_controls_cmsTextImageEditControl)PlaceHolder1.Controls[0];
                    te.SaveValue();
                    break;
            }
        }
    }

    public void LoadCustomItem(string customLoc)
    {
        _custom = true;

        epicCMSCustomControl ctl = (epicCMSCustomControl)Page.LoadControl("~/Admin_Custom/" + customLoc);
        PlaceHolder1.Controls.Add(ctl);

        if (ctl.CompareData())
        {
            if ((int)UserContext.GetContextItemAsInt("userlevel") > 2)
            {
                Label1.Visible = false;
            }
            else
            {
                lbApprove.Visible = false;
                lbReject.Visible = false;
            }
        }
        else
        {
            lbApprove.Visible = false;
            lbReject.Visible = false;
        }
    }


    public void LoadItem(int itemId)
    {
        _itemId = itemId;

        tblItems item = new tblItems();
        item.LoadByPrimaryKey(itemId);

        tblItemTypes type = new tblItemTypes();
        type.LoadByPrimaryKey(item.ItemTypeId);

        lbItemName.Text = item.ItemTitle;
        if ((int)UserContext.GetContextItemAsInt("userlevel") == 1)
            lbItemName.Text += "[" + item.ItemId.ToString() + "]";

        _itemTypeTitle = type.ItemTypeTitle;
        switch (_itemTypeTitle)
        {
            case "epicCMSRichTextControl":
              // cmsTextEditControl edit = new adm
                admin_controls_cmsTextEditControl txt = (admin_controls_cmsTextEditControl)Page.LoadControl("~/admin/controls/cmsTextEditControl.ascx");
                txt.ItemId = itemId;
                PlaceHolder1.Controls.Add(txt);

                lbApprove.Visible = false;
                    lbReject.Visible = false;
                    if (txt.IsTemp())
                    {
                        if ((int)UserContext.GetContextItemAsInt("userlevel") > 2)
                        {
                            Label1.Visible = false;
                        }
                        else
                        {
                            tblItemFieldsXValue val = new tblItemFieldsXValue();
                            val.Where.ItemId.Value = _itemId;
                            val.Where.ItemFieldId.Value = 7;
                            val.Where.LanguageId.Value = int.Parse(Request["langId"]);

                            val.Query.Load();

                            //if (val.ItemFieldStringTempId > -1)
                            //{
                            //    lbApprove.Visible = true;
                            //    lbReject.Visible = true;
                            //}
                        }
                    }
                break;
            case "epicCMSTextControl":
                admin_controls_cmsBasicTextEditControl txt4 = (admin_controls_cmsBasicTextEditControl)Page.LoadControl("~/admin/controls/cmsBasicTextEditControl.ascx");
                txt4.ItemId = itemId;
                PlaceHolder1.Controls.Add(txt4);

                lbApprove.Visible = false;
                lbReject.Visible = false;
                if (txt4.IsTemp())
                {
                    if ((int)UserContext.GetContextItemAsInt("userlevel") > 2)
                    {
                        Label1.Visible = false;
                    }
                    else
                    {
                        tblItemFieldsXValue val = new tblItemFieldsXValue();
                        val.Where.ItemId.Value = _itemId;
                        val.Where.ItemFieldId.Value = 7;
                        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

                        val.Query.Load();

                        //if (val.ItemFieldStringTempId > -1)
                        //{
                        //    lbApprove.Visible = true;
                        //    lbReject.Visible = true;
                        //}
                    }
                }
                break;
            case "epicCMSImageControl":
               //admin_controls_cmsImageEditControl img = (admin_controls_cmsImageEditControl)Page.LoadControl("~/admin/controls/cmsImageEditControl.ascx");
                admin_controls_cmsSelectImage img = (admin_controls_cmsSelectImage)Page.LoadControl("~/admin/controls/cmsSelectImage.ascx");
               img.ItemId = itemId;
                PlaceHolder1.Controls.Add(img);

                lbApprove.Visible = false;
                lbReject.Visible = false;
                if (img.IsTemp())
                {
                    if ((int)UserContext.GetContextItemAsInt("userlevel") > 2)
                    {
                        Label1.Visible = false;
                    }
                    else
                    {
                         tblItemFieldsXValue val = new tblItemFieldsXValue();
                         val.Where.ItemId.Value = _itemId;
                         val.Where.ItemFieldId.Value = 3;
                         val.Where.LanguageId.Value = int.Parse(Request["langId"]);

                         val.Query.Load();

                         //if (val.ItemFieldStringTempId > -1)
                         //{
                         //lbApprove.Visible = true;
                         // lbReject.Visible = true;
                         //}
                    }
                }
                break;
            case "epicCMSPDFControl":
                admin_controls_cmsPDFEditControl img2 = (admin_controls_cmsPDFEditControl)Page.LoadControl("~/admin/controls/cmsPDFEditControl.ascx");
                admin_controls_cmsSelectPdf pdf = (admin_controls_cmsSelectPdf)Page.LoadControl("~/admin/controls/cmsSelectPDF.ascx");
                img2.ItemId = itemId;
                pdf.ItemId = itemId;
                PlaceHolder1.Controls.Add(pdf);

                lbApprove.Visible = false;
                lbReject.Visible = false;
                if (pdf.IsTemp())
                {
                    if ((int)UserContext.GetContextItemAsInt("userlevel") > 2)
                    {
                        Label1.Visible = false;
                    }
                    //else
                    //{
                    //    lbApprove.Visible = true;
                    //    lbReject.Visible = true;
                    //}
                }
                break;
            case "epicCMSImageTextControl":
                admin_controls_cmsTextImageEditControl te = (admin_controls_cmsTextImageEditControl)Page.LoadControl("~/admin/controls/cmsTextImageEditControl.ascx");
                te.ItemId = itemId;
                PlaceHolder1.Controls.Add(te);
                break;

        }
        if (ConfigurationManager.AppSettings["usesApprovals"] != "true")
        {
            lbApprove.Visible = false;
            lbReject.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        #region remove value stores
        tblItemFieldsXValue vals = new tblItemFieldsXValue();
        vals.Where.ItemId.Value = _itemId;

        vals.Query.Load();

        if (vals.RowCount > 0)
        {
            vals.Rewind();
            do
            {
                if (vals.s_ItemFieldStringId != "")
                {
                    tblItemFieldStringValues val = new tblItemFieldStringValues();
                    val.LoadByPrimaryKey(vals.ItemFieldStringId);
                    val.MarkAsDeleted();
                    val.Save();
                }
                if (vals.s_ItemFieldTextId != "")
                {
                    tblItemFieldTextValues val = new tblItemFieldTextValues();
                    val.LoadByPrimaryKey(vals.ItemFieldTextId);
                    val.MarkAsDeleted();
                    val.Save();
                }
                if (vals.s_ItemFieldStringId != "")
                {
                    tblItemFieldStringValues val = new tblItemFieldStringValues();
                    val.LoadByPrimaryKey(vals.ItemFieldStringId);
                    val.MarkAsDeleted();
                    val.Save();
                }
                if (vals.s_ItemFieldPdfAssetId != "")
                {
                    tblPdfAssets val = new tblPdfAssets();
                    val.LoadByPrimaryKey(vals.ItemFieldPdfAssetId);
                    val.MarkAsDeleted();
                    val.Save();
                } 
            } while (vals.MoveNext());
        }
        #endregion

        tblItems item = new tblItems();
        item.LoadByPrimaryKey(_itemId);

        item.MarkAsDeleted();
        item.Save();
        
        Response.Redirect(Request.RawUrl);
    }
    protected void lbApprove_Click(object sender, EventArgs e)
    {
        if (_custom)
        {
            epicCMSCustomControl ctl = (epicCMSCustomControl)PlaceHolder1.Controls[0];
            ctl.SyncData();
        }
        else
        {
            switch (_itemTypeTitle)
            {
                case "epicCMSRichTextControl":
                    admin_controls_cmsTextEditControl txt = (admin_controls_cmsTextEditControl)PlaceHolder1.Controls[0];
                    txt.ApproveChange();
                    break;
                case "epicCMSImageControl":
                    admin_controls_cmsSelectImage img = (admin_controls_cmsSelectImage)PlaceHolder1.Controls[0];
                   img.ApproveChange();
                    break;
                case "epicCMSPDFControl":
                    admin_controls_cmsSelectPdf pdf = (admin_controls_cmsSelectPdf)PlaceHolder1.Controls[0];
                    pdf.ApproveChange();
                    break;
                case "epicCMSImageTextControl":
                    admin_controls_cmsTextImageEditControl te = (admin_controls_cmsTextImageEditControl)PlaceHolder1.Controls[0];
                    break;
                case "epicCMSTextControl":
                    admin_controls_cmsBasicTextEditControl bte = (admin_controls_cmsBasicTextEditControl)PlaceHolder1.Controls[0];
                    bte.ApproveChange();
                    break;
            }
        }
        Response.Redirect(Request.RawUrl);
    }
    protected void lbReject_Click(object sender, EventArgs e)
    {
        if (_custom)
        {
            epicCMSCustomControl ctl = (epicCMSCustomControl)PlaceHolder1.Controls[0];
            ctl.RejectData();
        }
        else
        {
            switch (_itemTypeTitle)
            {
                case "epicCMSRichTextControl":
                    admin_controls_cmsTextEditControl txt = (admin_controls_cmsTextEditControl)PlaceHolder1.Controls[0];
                    txt.RejectChange();
                    break;
                case "epicCMSImageControl":
                    admin_controls_cmsSelectImage img = (admin_controls_cmsSelectImage)PlaceHolder1.Controls[0];
                   img.RejectChange();
                    break;
                case "epicCMSPDFControl":
                    admin_controls_cmsSelectPdf pdf = (admin_controls_cmsSelectPdf)PlaceHolder1.Controls[0];
                    pdf.RejectChange();
                    break;
                case "epicCMSImageTextControl":
                    admin_controls_cmsTextImageEditControl te = (admin_controls_cmsTextImageEditControl)PlaceHolder1.Controls[0];
                    break;
                case "epicCMSTextControl":
                    admin_controls_cmsBasicTextEditControl bte = (admin_controls_cmsBasicTextEditControl)PlaceHolder1.Controls[0];
                    bte.RejectChange();
                    break;
            }
        }
        Response.Redirect(Request.RawUrl);
    }
}
