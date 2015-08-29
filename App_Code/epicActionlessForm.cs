using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for epicActionlessForm
/// </summary>
/// 
namespace ActionlessForm
{
    public class Form : System.Web.UI.HtmlControls.HtmlForm
    {
        protected override void RenderAttributes(HtmlTextWriter writer)
        {
            writer.WriteAttribute("name", this.Name);
            base.Attributes.Remove("name");

            writer.WriteAttribute("method", this.Method);
            base.Attributes.Remove("method");

            this.Attributes.Render(writer);

            base.Attributes.Remove("action");

            if (base.ID != null)
                writer.WriteAttribute("id", base.ClientID);
        }
    }
}
