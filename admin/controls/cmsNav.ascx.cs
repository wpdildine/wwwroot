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
public partial class admin_controls_cmsNav : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int? ul = UserContext.GetContextItemAsInt("userlevel");
        if (ul != null)
        {
            //nav.Visible = true;
            if (ul > 2)
            {
                hlUser.Visible = false;
                hlImage.Visible = false;
                //hlMovie.Visible = false;
                hlDocs.Visible = false;
                hlPage.Visible = false;
                tdSpc0.Visible = false;
                tdSpc1.Visible = false;
                tdSpc2.Visible = false;
                //tdSpc3.Visible = false;
                tdSpc4.Visible = false;
                tdSpc5.Visible = false;
                tdSpc6.Visible = false;
            }
            else
            {
                if (ul <= 2)
                {
                    hlUser.HRef = "~/admin/default.aspx?pg=user";
                    hlImage.HRef = "~/admin/default.aspx?pg=image";
                    //hlMovie.HRef = "~/admin/default.aspx?pg=movie";
                    hlDocs.HRef = "~/admin/default.aspx?pg=docs";
                    hlAudio.HRef = "~/admin/default.aspx?pg=audio";
                    hlPodcasts.HRef = "~/admin/default.aspx?pg=podcasts";
                }

                tblPagesXLanguage pageL = new tblPagesXLanguage();
                pageL.Where.LanguageId.Value = epicShared.GetLanguageId();
                pageL.Where.ParentPage.Value = -1;
                pageL.Where.ShowInCMS.Value = false;
                pageL.Where.ShowInCMS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual;

                pageL.Query.Load();

                pageL.Sort = "SortOrder ASC";

                tblUserPageAccess access = new tblUserPageAccess();
                access.Where.UserId.Value = (int)UserContext.GetContextItemAsInt("userid");

                access.Query.Load();

                // find all the top level pages
                if (pageL.RowCount > 0)
                {

                    if (pageL.ShowInCMS != false)
                    {
                        access.Filter = "PageXLanguageId=" + pageL.PageXLanguageId.ToString();
                        if (access.RowCount > 0 && (access.AccessLevel <= 2))
                        {

                            hlPage.HRef = "~/admin/default.aspx?pg=welcome&langId=" + epicShared.GetLanguageId();
                           
                        }
                    }

                }
            }
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserContext.SetContextItem("welcome", null);
    }
}
