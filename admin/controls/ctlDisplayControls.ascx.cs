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

public partial class admin_controls_ctlDisplayControls : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        placeData();
    }

    private void placeData()
    {
        tblLanguages lang = new tblLanguages();
        lang.Where.SiteId.Value = Int32.Parse(Request["siteId"]);
        lang.Query.Load();

        do
        {
            tblPagesXLanguage pxl = new tblPagesXLanguage();
            pxl.Where.LanguageId.Value = lang.LanguageId;
            pxl.Sort = "SortOrder ASC";

            pxl.Query.Load();

            do
            {
                tblPageXControl pxc = new tblPageXControl();
                pxc.Where.PageId.Value = pxl.PageId;

                pxc.Query.Load();

                pxc.Sort = "CmsSortOrder ASC";

                if (pxc.RowCount > 0)
                {
                    pxc.Rewind();
                    do
                    {
                        tblControls ctls = new tblControls();
                        ctls.LoadByPrimaryKey(pxc.ControlId);

                        HyperLink hl = new HyperLink();
                        hl.Text = ctls.ControlFriendlyName;

                        PlaceHolder1.Controls.Add(hl);
                    } while (pxc.MoveNext());
                }
            } while (pxl.MoveNext());
        } while (lang.MoveNext());
    }
}
