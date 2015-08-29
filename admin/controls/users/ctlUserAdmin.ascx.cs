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
using Telerik.WebControls;
using epicCMS;
public partial class admin_controls_users_ctlUserAdmin : System.Web.UI.UserControl
{
    private Int32 m_iRowIdx;

    bool[] rowChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request["langId"] != null)
        {
            txtLangId.Value = Request["langId"];
        }
        int totalRows = ctlGridView.Rows.Count;
        rowChanged = new bool[totalRows];


        ctlGridView.DataBind();

    }
    
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink editLink = (HyperLink)e.Row.FindControl("EditLink");
            editLink.Attributes["href"] = "#";
            editLink.Attributes["onclick"] = string.Format("return ShowEditFormUser('{0}');", DataBinder.Eval(e.Row.DataItem, "UserId").ToString());

            e.Row.Attributes.Add("onmouseover", "this.className='hightlighrow'");
            e.Row.Attributes.Add("onmouseout", "this.className=''");
            e.Row.Attributes["onfocus"] = Page.ClientScript.GetPostBackClientHyperlink(this.ctlGridView, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["onblur"] = Page.ClientScript.GetPostBackClientHyperlink(this.ctlGridView, "Edit$" + e.Row.RowIndex);

        }
        m_iRowIdx++;
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        string s = ctlGridView.SelectedRow.Cells[1].Text;
        textb.Value = s;
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        int totalrows = ctlGridView.Rows.Count;
        for (int r = 0; r < totalrows; r++)
        {

            ctlGridView.EditIndex = 0;
            //break;

        }
        ctlGridView.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow r in ctlGridView.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                Page.ClientScript.RegisterForEventValidation
                    (r.UniqueID + "$ctl00");
                Page.ClientScript.RegisterForEventValidation
                        (r.UniqueID + "$ctl01");
            }
        }

        base.Render(writer);
    }
    protected void OnDataBound(Object sender, EventArgs e)
    {
        GridViewRow gvrPager = ctlGridView.BottomPagerRow;

        if (gvrPager == null) return;

        // get your controls from the gridview
        DropDownList ddlPages =
            (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        Label lblPageCount =
            (Label)gvrPager.Cells[0].FindControl("lblPageCount");

        if (ddlPages != null)
        {
            // populate pager
            for (int i = 0; i < ctlGridView.PageCount; i++)
            {

                int intPageNumber = i + 1;
                ListItem lstItem =
                    new ListItem(intPageNumber.ToString());

                if (i == ctlGridView.PageIndex)
                    lstItem.Selected = true;

                ddlPages.Items.Add(lstItem);
            }
        }

        // populate page count
        if (lblPageCount != null)
            lblPageCount.Text = ctlGridView.PageCount.ToString();
    }
    protected void ddlPages_SelectedIndexChanged(Object sender,
    EventArgs e)
    {
        GridViewRow gvrPager = ctlGridView.BottomPagerRow;
        DropDownList ddlPages =
            (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");

        ctlGridView.PageIndex = ddlPages.SelectedIndex;

        // a method to populate your grid
        //PopulateGrid();
    }
    protected void Paginate(object sender, CommandEventArgs e)
    {
        // get the current page selected
        int intCurIndex = ctlGridView.PageIndex;

        switch (e.CommandArgument.ToString().ToLower())
        {
            case "first":
                ctlGridView.PageIndex = 0;
                break;
            case "prev":
                ctlGridView.PageIndex = intCurIndex - 1;
                break;
            case "next":
                ctlGridView.PageIndex = intCurIndex + 1;
                break;
            case "last":
                ctlGridView.PageIndex = ctlGridView.PageCount - 1;
                break;
        }

        // popultate the gridview control
        //ctlGridView.Re
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ctlGridView.DataBind();
        aspUpdPanTaskList.Update();
    }
    //protected void BtnDelete_Click(object sender, EventArgs e)
    //{
    //    //  get the gridviewrow from the sender so we can get the datakey we need
    //    Button btnDelete = sender as Button;
    //    string index = btnDelete.ID.Substring(btnDelete.ID.IndexOf(""));
    //    GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
    //    //  find the item and remove it
    //    dsPortfolioByIdTableAdapters.uspSelectPortfolioByIdTableAdapter da = new dsPortfolioByIdTableAdapters.uspSelectPortfolioByIdTableAdapter();
    //    dsPortfolioById.uspSelectPortfolioByIdDataTable dt = da.GetData(Convert.ToInt32(index));
    //    dsPortfolioById.uspSelectPortfolioByIdRow dr = (dsPortfolioById.uspSelectPortfolioByIdRow)dt.Rows[0];

    //    dt.Rows[0].Delete();

    //    //  rebind the datasource
    //    ctlGridView.DataBind();
    //    aspUpdPanTaskList.Update();
    //}

}