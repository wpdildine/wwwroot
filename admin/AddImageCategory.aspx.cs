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

public partial class admin_AddImageCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["catid"] != null)
            {
                loadData();
            }
            createLanguageDD();
        }
    }
    private void loadData()
    {
        tblImageCategories cat = new tblImageCategories();
        cat.LoadByPrimaryKey(Convert.ToInt32(Request["catid"]));

        TextBox1.Text = cat.ImageCategoryTitle;
    }

    private void createLanguageDD()
    {
        int selLang = -1;
        if (Request["catid"] != null)
        {
            tblImageCategories cat = new tblImageCategories();
            cat.LoadByPrimaryKey(Convert.ToInt32(Request["catid"]));

            selLang = cat.LanguageId;
        }

        tblLanguages lang = new tblLanguages();
        lang.LoadAll();

        do
        {
            ddLanguages.Items.Add(new ListItem(lang.LanguageTitle, lang.LanguageId.ToString()));

            if (selLang == lang.LanguageId)
                ddLanguages.Items[ddLanguages.Items.Count - 1].Selected = true;

        } while (lang.MoveNext());

        if (ddLanguages.Items.Count == 1)
            trLang.Visible = false;
    }

    public void SaveData()
    {
        tblImageCategories cat = new tblImageCategories();
        if (Request["catid"] != null)
            cat.LoadByPrimaryKey(Convert.ToInt32(Request["catid"]));
        else
            cat.AddNew();

        cat.ImageCategoryTitle = TextBox1.Text;

        if (trLang.Visible)
            cat.LanguageId = Convert.ToInt32(ddLanguages.SelectedItem.Value);
        else
        {
            tblLanguages lang = new tblLanguages();
            lang.LoadAll();
            cat.LanguageId = lang.LanguageId;
        }

        cat.Save();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SaveData();
        Response.Write(epicCMSLib.Navigation.CloseWindowString);
    }
}
