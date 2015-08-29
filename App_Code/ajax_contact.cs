using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for emailcontact
/// </summary>
[WebService(Namespace = "http://www.stellpfluglaw.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class form_contact : System.Web.Services.WebService
{

    [WebMethod]
    public string send_contactform(string contextKey)
    {
        string firstname = contextKey.Substring(0, contextKey.IndexOf("~"));
        string s1 = contextKey.Substring(firstname.Length + 1);

        string lastname = s1.Substring(0, s1.IndexOf("~"));
        string s2 = s1.Substring(lastname.Length + 1);

        string address = s2.Substring(0, s2.IndexOf("~"));
        string s3 = s2.Substring(address.Length + 1);

        string city = s3.Substring(0, s3.IndexOf("~"));
        string s4 = s3.Substring(city.Length + 1);

        string state = s4.Substring(0, s4.IndexOf("~"));
        string s5 = s4.Substring(state.Length + 1);

        string zip = s5.Substring(0, s5.IndexOf("~"));
        string s6 = s5.Substring(zip.Length + 1);

        string home = s6.Substring(0, s6.IndexOf("~"));
        string s7 = s6.Substring(home.Length + 1);

        string office = s7.Substring(0, s7.IndexOf("~"));
        string s8 = s7.Substring(office.Length + 1);

        string email = s8.Substring(0, s8.IndexOf("~"));
        string s9 = s8.Substring(email.Length + 1);

        string preferred = s9.Substring(0, s9.IndexOf("~"));
        string s10 = s9.Substring(preferred.Length + 1);

        string time = s10.Substring(0, s10.IndexOf("~"));
        string s11 = s10.Substring(time.Length + 1);

        string how = s11.Substring(0, s11.IndexOf("~"));
        string s12 = s11.Substring(how.Length + 1);

        string comments = s12.Substring(0, s12.IndexOf("~"));
        string s13 = s12.Substring(comments.Length + 1);

        string recipient = s13.Substring(0);

        // Save to database
        SqlConnection conn = new SqlConnection(epicShared._connstring);
        conn.Open();

//        string insertSQL = @"
//            INSERT INTO tblStellpflug_Contact_Submissions
//            (Contact_DateAdded,Contact_Firstname,Contact_Lastname,Contact_Address,Contact_City,Contact_State,Contact_Zip,Contact_Phone1,Contact_Phone2,Contact_Email,Contact_PreferredMethod,Contact_BestTime,Contact_How,Contact_Comments,Contact_Recipient)
//            VALUES
//            ('" + DateTime.Now + @"',
//            '" + firstname.Replace("'", "''") + @"',
//            '" + lastname.Replace("'", "''") + @"',
//            '" + address.Replace("'", "''") + @"',
//            '" + city.Replace("'", "''") + @"',
//            '" + state.Replace("'", "''") + @"',
//            '" + zip.Replace("'", "''") + @"',
//            '" + home.Replace("'", "''") + @"',
//            '" + office.Replace("'", "''") + @"',
//            '" + email.Replace("'", "''") + @"',
//            '" + preferred.Replace("'", "''") + @"',
//            '" + how.Replace("'", "''") + @"',
//            '" + time.Replace("'", "''") + @"',
//            '" + comments.Replace("'", "''") + @"',
//            '" + recipient.Replace("'", "''") + @"')
//        ";

        string insertSQL = @"
            INSERT INTO tblStellpflug_Contact_Submissions
            (Contact_DateAdded,Contact_Firstname,Contact_Lastname,Contact_Address,Contact_City,Contact_State,Contact_Zip,Contact_Phone1,Contact_Phone2,Contact_Email,Contact_PreferredMethod,Contact_BestTime,Contact_How,Contact_Comments,Contact_Recipient)
            VALUES
            (@Contact_DateAdded,@Contact_Firstname,@Contact_Lastname,@Contact_Address,@Contact_City,@Contact_State,@Contact_Zip,@Contact_Phone1,@Contact_Phone2,@Contact_Email,@Contact_PreferredMethod,@Contact_BestTime,@Contact_How,@Contact_Comments,@Contact_Recipient)
        ";

        SqlCommand sqlComm = new SqlCommand(insertSQL, conn);

        sqlComm.Parameters.Add("@Contact_DateAdded", SqlDbType.DateTime);
        sqlComm.Parameters["@Contact_DateAdded"].Value = DateTime.Now;

        sqlComm.Parameters.Add("@Contact_Firstname", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Firstname"].Value = firstname.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Lastname", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Lastname"].Value = lastname.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Address", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Address"].Value = address.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_City", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_City"].Value = city.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_State", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_State"].Value = state.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Zip", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Zip"].Value = zip.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Phone1", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Phone1"].Value = home.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Phone2", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Phone2"].Value = office.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Email", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Email"].Value = email.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_PreferredMethod", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_PreferredMethod"].Value = preferred.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_BestTime", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_BestTime"].Value = time.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_How", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_How"].Value = how.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Comments", SqlDbType.Text);
        sqlComm.Parameters["@Contact_Comments"].Value = comments.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Recipient", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Recipient"].Value = recipient.Replace("'", "''");

        sqlComm.ExecuteNonQuery();
        conn.Close();

        EmailFunctions.epicEmail em = new EmailFunctions.epicEmail();

        // Create Settings
        // RKindle@stellpfluglaw.com
        string client_email = recipient;
        string client_email2 = "RKindle@stellpfluglaw.com";
        //string client_email = "natalie@balancestudios.com";
        //string client_email2 = "natalie@balancestudios.com";

        string client_name = "Stellpflug Law";
        string client_domain = "StellpflugLaw.com";
        string client_linecolor = "#808080";
        string client_emailsubject = "New Contact Submission";
        string sender_emailsubject = "Your Contact Submission";
        string name = firstname + " " + lastname;

        string mybody = em.Contact_Client(client_email, client_email2, name, address, city, state, zip, home, office, email, preferred, time, how, comments, client_linecolor, "www." + client_domain, client_name, client_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(client_email, name, client_email, client_name, client_domain + " - " + client_emailsubject, mybody, true);

        string mybody3 = em.Contact_Client(client_email, client_email2, name, address, city, state, zip, home, office, email, preferred, time, how, comments, client_linecolor, "www." + client_domain, client_name, client_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(client_email2, name, client_email2, client_name, client_domain + " - " + client_emailsubject, mybody3, true);

        if (email != "")
        {
            string mybody2 = em.Contact_Sender(name, email, client_linecolor, "www." + client_domain, client_name, sender_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
            epicShared.sendMail(email, name, client_email, client_name, client_domain + " - " + sender_emailsubject, mybody2, true);
        }

        string success = @"Thank You 
                <br /><br />
                Your message was successfully sent to the Stellpflug Law, S.C.  You should receive a reply from a representative of our law firm by the end of the next business day.  Occasionally we receive a very large number of messages, and your response may take a little longer.  If this occurs, we appreciate your patience, and we assure you that you will receive a response. 
                <br /><br />
                Thank you for taking the time to contact us. 
                <br /><br />
                Stellpflug Law, S.C.<br />
                Attorneys &amp; Staff";

        return success;

    }

   

}

