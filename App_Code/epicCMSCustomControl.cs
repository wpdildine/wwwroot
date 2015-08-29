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
/// Summary description for epicCMSCustomControl
/// </summary>
public class epicCMSCustomControl : System.Web.UI.UserControl
{
    public epicCMSCustomControl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Returns true if data is successfully synced
    /// </summary>
    /// <returns></returns>
    virtual public bool SyncData()
    {
        return true;
    }

    /// <summary>
    /// Saves the data
    /// </summary>
    /// <returns></returns>
    virtual public bool SaveData()
    {
        return true;
    }

    /// <summary>
    /// Returns true if data is successfully rejected (moved from live to dev)
    /// </summary>
    /// <returns></returns>
    virtual public bool RejectData()
    {
        return true;
    }

    /// <summary>
    /// Returns true if data needs to be synced
    /// </summary>
    /// <returns></returns>
    virtual public bool CompareData()
    {
        return true;
    }
}
