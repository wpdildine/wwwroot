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
public partial class admin_controls_ctlRichTextControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
         RadSpell spell = (RadSpell)RadEditor1.RadSpell;
    }

    public string Text
    {
        set
        {
            RadEditor1.Html = value;
        }
        get { return RadEditor1.Html; }
    }
}
