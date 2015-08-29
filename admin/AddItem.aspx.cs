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

public partial class admin_AddItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            getTypes();
    }

    private void getTypes()
    {
        tblItemTypes types = new tblItemTypes();
        types.LoadAll();

        do
        {
            DropDownList1.Items.Add(new ListItem(types.ItemTypeTitle, types.ItemTypeId.ToString()));
        } while (types.MoveNext());

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        tblItems item = new tblItems();
        item.AddNew();

        item.ItemTitle = TextBox1.Text;
        item.ItemTypeId = int.Parse(DropDownList1.SelectedValue);

        item.Save();

        tblItemFieldsXValue fxv = new tblItemFieldsXValue();
         // now, create the field values
        switch (DropDownList1.SelectedValue)
        {
            case "1":
                tblItemFieldStringValues txt21 = new tblItemFieldStringValues();
                txt21.AddNew(); 
                txt21.ItemFieldValue = " ";
                txt21.Save();

                fxv.AddNew();
                fxv.ItemId = item.ItemId;
                fxv.LanguageId = int.Parse(Request["langId"]);
                fxv.ItemFieldId = 7; // text
                fxv.ItemFieldStringId = -1;
                if (ConfigurationManager.AppSettings["usesApprovals"] == "true")
                {
                    fxv.ItemFieldStringTempId = txt21.ItemFieldStringValueId;
                }
                else 
                {
                    fxv.ItemFieldStringId = txt21.ItemFieldStringValueId;
                }
                fxv.Save();
                break;

            case "2":
                // image
                //tblImageAssets blob = new tblImageAssets();
                //blob.AddNew();
                //blob.Save();
                tblItemFieldStringValues img = new tblItemFieldStringValues();
                img.AddNew();
                img.ItemFieldValue = " ";
                img.Save();

                fxv.AddNew();
                fxv.ItemId = item.ItemId;
                fxv.LanguageId = int.Parse(Request["langId"]);
                fxv.ItemFieldId = 3; // image
                fxv.ItemFieldStringId = -1;
                if (ConfigurationManager.AppSettings["usesApprovals"] == "true")
                {
                    fxv.ItemFieldStringTempId = img.ItemFieldStringValueId;
                }
                else
                {
                    fxv.ItemFieldStringId = img.ItemFieldStringValueId;
                }

                fxv.Save();
                break;
            case "3":
                // rich text
                tblItemFieldTextValues txt = new tblItemFieldTextValues();
                txt.AddNew();
                txt.Save();

                fxv.AddNew();
                fxv.ItemId = item.ItemId;
                fxv.LanguageId = int.Parse(Request["langId"]);
                fxv.ItemFieldId = 2; // image

                if (ConfigurationManager.AppSettings["usesApprovals"] == "true")
                {
                    fxv.ItemFieldTextTempId = txt.ItemFieldStringValueId;
                }
                else
                {
                    fxv.ItemFieldTextId = txt.ItemFieldStringValueId;
                }
                fxv.Save();
                break;
            case "4":
                // pdf
                fxv.AddNew();
                fxv.ItemId = item.ItemId;
                fxv.LanguageId = int.Parse(Request["langId"]);
                fxv.ItemFieldId = 5; // pdf
                fxv.ItemFieldPdfAssetId = -1;

                fxv.Save();
                break;
            case "5":
                // rich text
                tblItemFieldStringValues txt2 = new tblItemFieldStringValues();
                txt2.AddNew();
                txt2.ItemFieldValue = " ";
                txt2.Save();

                fxv.AddNew();
                fxv.ItemId = item.ItemId;
                fxv.LanguageId = int.Parse(Request["langId"]);
                fxv.ItemFieldId = 6; // image
                if (ConfigurationManager.AppSettings["usesApprovals"] == "true")
                {
                    fxv.ItemFieldStringTempId = txt2.ItemFieldStringValueId;
                }
                else
                {
                    fxv.ItemFieldStringId = txt2.ItemFieldStringValueId;
                }

                fxv.Save();
                break;
        }

        tblControlsXItems cxi = new tblControlsXItems();
        cxi.AddNew();
        cxi.ControlId = int.Parse(Request["ctl"]);
        cxi.LanguageId = int.Parse(Request["langId"]);
        cxi.ItemId = item.ItemId;

        cxi.Save();

        lbJs.Text = epicCMSLib.Navigation.CloseWindowString;
    }
}
