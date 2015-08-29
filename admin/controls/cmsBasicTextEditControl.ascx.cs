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

public partial class admin_controls_cmsBasicTextEditControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                TextBox1.Text = getTextVal();
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
        val.Where.ItemFieldId.Value = 7;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        try
        {
            int ret = val.ItemFieldStringTempId;
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
        val.Where.ItemFieldId.Value = 7;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        tblItemFieldStringValues txt = new tblItemFieldStringValues();

        if (val.ItemFieldStringTempId > -1)
        {
            txt.LoadByPrimaryKey(val.ItemFieldStringTempId);
        }
        else
        {
            txt.LoadByPrimaryKey(val.ItemFieldStringId);
        }

      

        return txt.ItemFieldValue;
    }

    public void RejectChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 7;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        // load the temp
        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        txt.LoadByPrimaryKey(val.ItemFieldStringTempId);

        val.s_ItemFieldStringTempId = "";
        txt.MarkAsDeleted();
        txt.Save();
        val.Save();
    }

    public void ApproveChange()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 7;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        // load the temp
        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        txt.LoadByPrimaryKey(val.ItemFieldStringTempId);

        // load the live
        tblItemFieldStringValues txt2 = new tblItemFieldStringValues();
        if (val.ItemFieldStringId > -1)
        {
            txt2.LoadByPrimaryKey(val.ItemFieldStringId);
        }
        else
        {
            txt2.AddNew();
        }

        // make them equal
        txt2.ItemFieldValue = txt.ItemFieldValue;

        // save
        txt2.Save();

        val.ItemFieldStringId = txt2.ItemFieldStringValueId;

        // delete the old reference
        val.ItemFieldStringTempId = -1;
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
        val.Where.ItemFieldId.Value = 7;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        if (val.RowCount == 0)
        {
            val.AddNew();
            val.ItemFieldId = 7;
            val.LanguageId = int.Parse(Request["langId"]); ;
            val.ItemId = _itemId;
        }

        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        try
        {
            if (val.ItemFieldStringTempId > -1)
            {
                txt.LoadByPrimaryKey(val.ItemFieldStringTempId);
            }
            else { txt.AddNew(); }
        }
        catch
        {
            txt.AddNew();
        }

        // check if we need an update
        tblItemFieldStringValues valtxt = new tblItemFieldStringValues();

        bool update = true;

        try
        {
            valtxt.LoadByPrimaryKey(val.ItemFieldStringId);

            if (valtxt.ItemFieldValue == TextBox1.Text)
            {
                update = false;
            }
        }
        catch
        {
        }

        if (update)
        {
            txt.ItemFieldValue = TextBox1.Text;
            txt.Save();

            val.ItemFieldStringTempId = txt.ItemFieldStringValueId;
            val.Save();
        }
    }

    public int ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }
}
