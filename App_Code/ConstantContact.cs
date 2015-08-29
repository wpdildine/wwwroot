using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;
/// <summary>
/// Summary description for WholeLife_ConstantContact
/// </summary>
public class ConstantContact
{


    //private static string sUsername = "NalleyPickles";
    //private static string sPassword = "bvfpickles1";

    private static string sUsername = "balancestudios";
    private static string sPassword = "b@l_c0nstant";


    public ConstantContact()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void SubmitToConstantContact(string ListID, DataTable myConstantContacts)
    {
        string sUri = "https://api.constantcontact.com/ws/customers/" + sUsername + "/activities";
        string sListUri = "https://api.constantcontact.com/ws/customers/" + sUsername + "/lists/" + ListID;
        string sAPIKey = "cf36f16b-93a7-46df-807a-bd166ac9f114";

        Uri address = new Uri(sUri);

        // Create WebRequest
        HttpWebRequest Request;
        Request = WebRequest.Create(address) as HttpWebRequest;
        Request.Credentials = new NetworkCredential((sAPIKey + "%" + sUsername), sPassword);
        Request.Method = "POST";
        Request.ContentType = "application/x-www-form-urlencoded";

        // Set up XML String for the POST
        // Long string with quotes, use an absolute string with literals string or a StringBuilder
        StringBuilder XMLData = new StringBuilder();
        XMLData.Append("activityType=" + HttpUtility.UrlEncode("SV_ADD", Encoding.UTF8));
            XMLData.Append("&data=" + HttpUtility.UrlEncode(("Email Address" + Environment.NewLine), Encoding.UTF8));
        DataRow[] foundRows;
        foundRows = myConstantContacts.Select();
        foreach (DataRow dr in foundRows)
        {
                XMLData.Append(HttpUtility.UrlEncode((dr["Email"] + Environment.NewLine), Encoding.UTF8));
        }
        XMLData.Append("&lists=" + HttpUtility.UrlEncode(sListUri));
        //HttpContext.Current.Response.Write(XMLData.ToString() + "<br><br>");

        // Set up the XML Document, application dependant 

        // Convert XMLData to byteArray for posting
        byte[] byteArray = Encoding.UTF8.GetBytes(XMLData.ToString());

        // Send POST request

        // Set the ContentLength portion of the header
        Request.ContentLength = byteArray.Length;
        string XMLResponse = "Bytes to send:" + byteArray.Length;

        // Create a stream for the POST Request
        // Note: Remember to add using System.IO
        Stream streamRequest = Request.GetRequestStream();

        // Write the data to the stream.
        streamRequest.Write(byteArray, 0, byteArray.Length);
        streamRequest.Close();
        HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

        StreamReader Reader = new StreamReader(Response.GetResponseStream());

        // Read the entire XML response to a string
        XMLResponse += Response.StatusCode + " " + Response.StatusDescription + " " + Reader.ReadToEnd();

        //HttpContext.Current.Response.Write(XMLResponse.ToString() + "<br><br>");

        // Close Reader
        Reader.Close();

        // Close the response to free up the system resources
        Response.Close();
    }

    

}
