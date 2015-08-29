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

public partial class admin_controls_cmsTextImageEditControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            TextBox1.Text = getTextVal();
    }

    private string getTextVal()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value = 6;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        txt.LoadByPrimaryKey(val.ItemFieldStringId);

        return txt.ItemFieldValue;
    }

    public void SaveValue()
    {
        tblItemFieldsXValue val = new tblItemFieldsXValue();
        val.Where.ItemId.Value = _itemId;

        // hard coded
        val.Where.ItemFieldId.Value =6;
        val.Where.LanguageId.Value = int.Parse(Request["langId"]);

        val.Query.Load();

        tblItemFieldStringValues txt = new tblItemFieldStringValues();
        txt.LoadByPrimaryKey(val.ItemFieldStringId);

        txt.ItemFieldValue =TextBox1.Text;

        txt.Save();
    }

    private int _itemId = -1;
    public int ItemId
    {
        get { return _itemId; }
        set { _itemId = value; }
    }
}

