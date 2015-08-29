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

public partial class admin_controls_ctlPageControls : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["pageId"] != null)
        {
            tblPageXControl pxc = new tblPageXControl();
            pxc.Where.PageId.Value = Int32.Parse(Request["pageId"]);

            pxc.Query.Load();

            pxc.Sort = "SortOrder";

            tblControlsXItems cxi = new tblControlsXItems();
            cxi.Where.ControlId.Value = pxc.ControlId;
            cxi.Query.Load();
            if (cxi.RowCount > 0)
            {
                Button1.Visible = true;
            }
            else{Button1.Visible = false;}
                if (pxc.RowCount > 0)
                {
                    pxc.Rewind();
                    do
                    {

                        // add this control's children
                        tblControls ctl = new tblControls();
                        ctl.Where.ParentControlId.Value = pxc.ControlId;
                        ctl.Query.Load();

                        ctl.Sort = "ParentControlSortOrder ASC";

                        addControl(pxc.ControlId);

                        if (ctl.RowCount > 0)
                        {
                            ctl.Rewind();
                            do
                            {
                                if ((pxc.ControlId != ctl.ParentControlId) && (ctl.Custom))
                                { addControl(ctl.ControlId); }
                            }

                            while (ctl.MoveNext());
                        }
                        else
                        {

                        }

                    } while (pxc.MoveNext());
                }
            }


        if (PlaceHolder1.Controls.Count == 0)
        {
            Button1.Visible = false;
        }
        
    }

    private void addControl(int controlId)
    {
        tblControls ctl = new tblControls();
        ctl.LoadByPrimaryKey(controlId);

        int start = PlaceHolder1.Controls.Count;

        PlaceHolder1.Controls.Add(new LiteralControl("<h2>"+ ctl.ControlFriendlyName));

        if (((int)UserContext.GetContextItemAsInt("userlevel") == 1) && (!ctl.Custom))
        {
            HyperLink hl = new HyperLink();
            hl.Text = "Add New Item &raquo;";
            hl.NavigateUrl = epicCMSLib.Navigation.PopupPageLink("AddItem.aspx?ctl=" + controlId.ToString() + "&langId=" + Request["langId"], 350, 100);
            PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;|&nbsp;"));
            PlaceHolder1.Controls.Add(hl);
            //  PlaceHolder1.Controls.Add(new LiteralControl("</td></tr>"));
        }

        PlaceHolder1.Controls.Add(new LiteralControl("</h2><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">"));
        PlaceHolder1.Controls.Add(new LiteralControl("<tr><td>"));

        bool foundItems = false;
        if (!ctl.Custom)
        {
            tblControlsXItems cxi = new tblControlsXItems();
            cxi.Where.ControlId.Value = controlId;
            cxi.Where.LanguageId.Value = Int32.Parse(Request["langId"]);

            cxi.Query.Load();

            cxi.Sort = "SortOrder";

            if (cxi.RowCount > 0)
            {
                cxi.Rewind();
                do
                {
                    admin_controls_ctlEditItem edit = (admin_controls_ctlEditItem)Page.LoadControl("~/admin/controls/ctlEditItem.ascx");
                    edit.LoadItem(cxi.ItemId);

                    PlaceHolder1.Controls.Add(new LiteralControl("<tr><td>"));
                    PlaceHolder1.Controls.Add(edit);
                    PlaceHolder1.Controls.Add(new LiteralControl("</td></tr>"));
                    foundItems = true;
                } while (cxi.MoveNext());
            }
        }
        else
        {
            //PlaceHolder1.Controls.Add(new LiteralControl("<tr><td style=\"padding:8px;\">"));
            //PlaceHolder1.Controls.Add(Page.LoadControl("~/App_Controls/" + ctl.CustomCmsLocation));
            //PlaceHolder1.Controls.Add(new LiteralControl("</td></tr>"));
            //foundItems = true;

            admin_controls_ctlEditItem edit = (admin_controls_ctlEditItem)Page.LoadControl("~/admin/controls/ctlEditItem.ascx");
            edit.LoadCustomItem(ctl.CustomCmsLocation);

            PlaceHolder1.Controls.Add(new LiteralControl("<tr><td>"));
            PlaceHolder1.Controls.Add(edit);
            PlaceHolder1.Controls.Add(new LiteralControl("</td></tr>"));
            foundItems = true;
        }

        if ((!foundItems) && ((int)UserContext.GetContextItemAsInt("userlevel") != 1))
        {
            for (int x = PlaceHolder1.Controls.Count - 1; x >= start ; x--)
            {
                PlaceHolder1.Controls.RemoveAt(x);
            }
        }
        else
        {
            PlaceHolder1.Controls.Add(new LiteralControl("</table><br>"));
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (Control ctl in PlaceHolder1.Controls)
        {
            try
            {
                admin_controls_ctlEditItem item = (admin_controls_ctlEditItem)ctl;
                item.SaveItem();
            }
            catch
            {
                // not an editable item :)
            }
        }
        Response.Redirect(Request.RawUrl);
    }
}
