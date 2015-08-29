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

public partial class admin_controls_cmsTextEditControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // FCKeditor1.BasePath = epicCMSLib.Navigation.SiteRoot + "FCKEditor/";
        if (!Page.IsPostBack)
        {
            try
            {
                // FCKeditor1.Value = getTextVal();
                CtlRichTextControl1.Text = getTextVal();
            }
            catch { }
        }

        getTemp();
    }

    private void getTemp()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 2;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        try
        {
            int ret = val.ItemFieldTextTempId;
            _temp = true;
        }
        catch
        {
            _temp = false;
        }
    }

    private int _itemId;

    private bool _temp = false;
    public bool IsTemp()
    {
       getTemp();
        return _temp;
    }

    private string getTextVal()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 2;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        tblItemFieldTextValues txt = new tblItemFieldTextValues();

        try
        {
            txt.LoadByPrimaryKey(val.ItemFieldTextTempId);
        }
        catch
        {
            txt.LoadByPrimaryKey(val.ItemFieldTextId);
        }

        return txt.ItemFieldValue;
    }

    public void RejectChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 2;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        // load the temp
        tblItemFieldTextValues txt = new tblItemFieldTextValues();
        txt.LoadByPrimaryKey(val.ItemFieldTextTempId);

        val.s_ItemFieldTextTempId = "";
        txt.MarkAsDeleted();
        txt.Save();
        val.Save();
    }

    public void ApproveChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 2;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        // load the temp
        tblItemFieldTextValues txt = new tblItemFieldTextValues();
        txt.LoadByPrimaryKey(val.ItemFieldTextTempId);

        // load the live
        tblItemFieldTextValues txt2 = new tblItemFieldTextValues();
        try
        {
            txt2.LoadByPrimaryKey(val.ItemFieldTextId);
        }
        catch
        {
            // for some reason, wasn't created for this language
            txt2.AddNew();
        }

        // make them equal
        txt2.ItemFieldValue = txt.ItemFieldValue;

        // save
        txt2.Save();

        val.ItemFieldTextId = txt2.ItemFieldStringValueId;

        // delete the old reference
        val.s_ItemFieldTextTempId = "";
        val.Save();

        // delete the old
        txt.MarkAsDeleted();
        txt.Save();
    }

    public void SaveValue()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 2;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        if (val.RowCount == 0)
        {
            val.AddNew();
            val.ItemFieldId = 2;
            val.LanguageId = int.Parse(Request["langId"]); ;
            val.ItemId = _itemId;
        }

        tblItemFieldTextValues txt = new tblItemFieldTextValues();
        try
        {
            txt.LoadByPrimaryKey(val.ItemFieldTextTempId);

            if (txt.RowCount == 0)
            {
                txt.AddNew();
            }
        }
        catch
        {
            txt.AddNew();
        }



        // check if we need an update
        tblItemFieldTextValues valtxt = new tblItemFieldTextValues();

        bool update = true;

        try
        {
            valtxt.LoadByPrimaryKey(val.ItemFieldTextId);

            if (valtxt.ItemFieldValue == CtlRichTextControl1.Text)
            {
                update = false;
            }
        }
        catch
        {
        }

        if (update)
        {
            txt.ItemFieldValue = CtlRichTextControl1.Text;
            txt.Save();

            if (ConfigurationManager.AppSettings["usesApprovals"] == "true")
                val.ItemFieldTextTempId = txt.ItemFieldStringValueId;
            else
                val.ItemFieldTextId = txt.ItemFieldStringValueId;
            val.Save();
        }
    }

    public int ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }

}
