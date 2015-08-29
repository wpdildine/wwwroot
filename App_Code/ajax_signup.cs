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
public class form_signup : System.Web.Services.WebService
{

    [WebMethod]
    public string send_signup(string contextKey)
    {
        string firstname = contextKey.Substring(0, contextKey.IndexOf("~"));
        string s1 = contextKey.Substring(firstname.Length + 1);

        string lastname = s1.Substring(0, s1.IndexOf("~"));
        string s2 = s1.Substring(lastname.Length + 1);

        string email = s2.Substring(0, s2.IndexOf("~"));
        string s3 = s2.Substring(email.Length + 1);

        string address = s3.Substring(0, s3.IndexOf("~"));
        string s4 = s3.Substring(address.Length + 1);

        string city = s4.Substring(0, s4.IndexOf("~"));
        string s5 = s4.Substring(city.Length + 1);

        string state = s5.Substring(0, s5.IndexOf("~"));
        string s6 = s5.Substring(state.Length + 1);

        string zip = s6.Substring(0, s6.IndexOf("~"));
        string s7 = s6.Substring(zip.Length + 1);

        string country = s7.Substring(0);

        // Save to database
        SqlConnection conn = new SqlConnection(epicShared._connstring);
        conn.Open();

//        string insertSQL = @"
//            INSERT INTO tblStellpflug_LegalResources_LawClipsSignups
//            (Signup_DateAdded,Signup_Firstname,Signup_Lastname,Signup_Email,Signup_Address,Signup_City,Signup_State,Signup_Zip,Signup_Country)
//            VALUES
//            ('" + DateTime.Now + @"',
//            '" + firstname.Replace("'", "''") + @"',
//            '" + lastname.Replace("'", "''") + @"',
//            '" + email.Replace("'", "''") + @"',
//            '" + address.Replace("'", "''") + @"',
//            '" + city.Replace("'", "''") + @"',
//            '" + state.Replace("'", "''") + @"',
//            '" + zip.Replace("'", "''") + @"',
//            '" + country.Replace("'", "''") + @"')   select scope_identity() as [identity_value]
//        ";

        string insertSQL = @"
            INSERT INTO tblStellpflug_LegalResources_LawClipsSignups
            (Signup_DateAdded,Signup_Firstname,Signup_Lastname,Signup_Email,Signup_Address,Signup_City,Signup_State,Signup_Zip,Signup_Country)
            VALUES
            (@Signup_DateAdded,@Signup_Firstname,@Signup_Lastname,@Signup_Email,@Signup_Address,@Signup_City,@Signup_State,@Signup_Zip,@Signup_Country)   select scope_identity() as [identity_value]
        ";

        SqlCommand sqlComm = new SqlCommand(insertSQL, conn);

        sqlComm.Parameters.Add("@Signup_DateAdded", SqlDbType.DateTime);
        sqlComm.Parameters["@Signup_DateAdded"].Value = DateTime.Now;

        sqlComm.Parameters.Add("@Signup_Firstname", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_Firstname"].Value = firstname.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_Lastname", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_Lastname"].Value = lastname.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_Email", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_Email"].Value = email.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_Address", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_Address"].Value = address.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_City", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_City"].Value = city.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_State", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_State"].Value = state.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_Zip", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_Zip"].Value = zip.Replace("'", "''");

        sqlComm.Parameters.Add("@Signup_Country", SqlDbType.VarChar);
        sqlComm.Parameters["@Signup_Country"].Value = country.Replace("'", "''");

        int idA = Convert.ToInt32(sqlComm.ExecuteScalar());

        conn.Close();

        EmailFunctions.epicEmail em = new EmailFunctions.epicEmail();

        // Create Settings
        // Josef@movietomovement.com
        // info@stellpfluglaw.com
        
        string client_email = "info@stellpfluglaw.com";
        string client_email2 = "RKindle@stellpfluglaw.com";

        //string client_email = "natalie@balancestudios.com";
        //string client_email2 = "development@balancestudios.com";
        string client_name = "Stellpflug Law";
        string client_domain = "StellpflugLaw.com";
        string client_linecolor = "#808080";
        string client_emailsubject = "New LawClips Signup";
        string sender_emailsubject = "Your LawClips Signup";
        string name = firstname + " " + lastname;

        string mybody = em.Signup_Client(name, email, address, city, state, zip, country, client_linecolor, "www." + client_domain, client_name, client_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(client_email, name, client_email, client_name, client_domain + " - " + client_emailsubject, mybody, true);

        string mybody3 = em.Signup_Client(name, email, address, city, state, zip, country, client_linecolor, "www." + client_domain, client_name, client_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(client_email2, name, client_email2, client_name, client_domain + " - " + client_emailsubject, mybody3, true);

        string mybody2 = em.Signup_Sender(name, email, client_linecolor, "www." + client_domain, client_name, sender_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(email, name, client_email, client_name, client_domain + " - " + sender_emailsubject, mybody2, true);




        string success = "Thank You! <br />You have successfully signed up to receive the LawClips Newsletter.";

        return success;

    }



}

