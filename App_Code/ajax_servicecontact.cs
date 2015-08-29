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
public class form_servicecontact : System.Web.Services.WebService
{

    [WebMethod]
    public string send_servicecontactform(string contextKey)
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

        string fax = s8.Substring(0, s8.IndexOf("~"));
        string s9 = s8.Substring(fax.Length + 1);

        string email = s9.Substring(0, s9.IndexOf("~"));
        string s10 = s9.Substring(email.Length + 1);

        string preferred = s10.Substring(0, s10.IndexOf("~"));
        string s11 = s10.Substring(preferred.Length + 1);

        string age = s11.Substring(0, s11.IndexOf("~"));
        string s12 = s11.Substring(age.Length + 1);

        string businesses = s12.Substring(0, s12.IndexOf("~"));
        string s12_businesses = s12.Substring(businesses.Length + 1);

        string inquiring = s12_businesses.Substring(0, s12_businesses.IndexOf("~"));
        string s13 = s12_businesses.Substring(inquiring.Length + 1);

        string inquiringB = s13.Substring(0, s13.IndexOf("~"));
        string s14 = s13.Substring(inquiringB.Length + 1);

        string field1 = s14.Substring(0, s14.IndexOf("~"));
        string s15 = s14.Substring(field1.Length + 1);

        string field2 = s15.Substring(0, s15.IndexOf("~"));
        string s16 = s15.Substring(field2.Length + 1);

        string field3 = s16.Substring(0, s16.IndexOf("~"));
        string s17 = s16.Substring(field3.Length + 1);

        string field4 = s17.Substring(0, s17.IndexOf("~"));
        string s18 = s17.Substring(field4.Length + 1);

        string field5 = s18.Substring(0, s18.IndexOf("~"));
        string s19 = s18.Substring(field5.Length + 1);

        string field6 = s19.Substring(0, s19.IndexOf("~"));
        string s20 = s19.Substring(field6.Length + 1);

        string field7 = s20.Substring(0, s20.IndexOf("~"));
        string s21 = s20.Substring(field7.Length + 1);

        string field7b = s21.Substring(0, s21.IndexOf("~"));
        string s22 = s21.Substring(field7b.Length + 1);

        string field8 = s22.Substring(0, s22.IndexOf("~"));
        string s23 = s22.Substring(field8.Length + 1);

        string field9 = s23.Substring(0, s23.IndexOf("~"));
        string s24 = s23.Substring(field9.Length + 1);

        string field9b = s24.Substring(0, s24.IndexOf("~"));
        string s25 = s24.Substring(field9b.Length + 1);

        string field10 = s25.Substring(0, s25.IndexOf("~"));
        string s26 = s25.Substring(field10.Length + 1);

        string field11 = s26.Substring(0, s26.IndexOf("~"));
        string s27 = s26.Substring(field11.Length + 1);

        string field12 = s27.Substring(0, s27.IndexOf("~"));
        string s28 = s27.Substring(field12.Length + 1);

        string field13 = s28.Substring(0, s28.IndexOf("~"));
        string s29 = s28.Substring(field13.Length + 1);

        string field14 = s29.Substring(0, s29.IndexOf("~"));
        string s30 = s29.Substring(field14.Length + 1);

        string field15 = s30.Substring(0, s30.IndexOf("~"));
        string s31 = s30.Substring(field15.Length + 1);

        string field15b = s31.Substring(0, s31.IndexOf("~"));
        string s32 = s31.Substring(field15b.Length + 1);

        string field16 = s32.Substring(0, s32.IndexOf("~"));
        string s33 = s32.Substring(field16.Length + 1);

        string field17 = s33.Substring(0, s33.IndexOf("~"));
        string s34 = s33.Substring(field17.Length + 1);

        string field18 = s34.Substring(0, s34.IndexOf("~"));
        string s35 = s34.Substring(field18.Length + 1);

        string field18b = s35.Substring(0, s35.IndexOf("~"));
        string s36 = s35.Substring(field18b.Length + 1);

        string field19 = s36.Substring(0, s36.IndexOf("~"));
        string s37 = s36.Substring(field19.Length + 1);

        string field20 = s37.Substring(0, s37.IndexOf("~"));
        string s38 = s37.Substring(field20.Length + 1);

        string serviceid = s38.Substring(0, s38.IndexOf("~"));
        string s39 = s38.Substring(serviceid.Length + 1);

        string formtype = s39.Substring(0);

        // Save to database
        SqlConnection conn = new SqlConnection(epicShared._connstring);
        conn.Open();

        // Quickly get Service Title based on ID
        SqlCommand sqlComm = new SqlCommand("SELECT * FROM tblStellpflug_Services WHERE Service_ID = '" + serviceid + "'", conn);
        SqlDataReader r = sqlComm.ExecuteReader();
        string servicetitle = "";
        while (r.Read())
            servicetitle = r["Service_Title"].ToString();

        r.Close();

//        string insertSQL = @"
//            INSERT INTO tblStellpflug_ServiceContactSubmissions
//            (Contact_DateAdded,Contact_Firstname,Contact_Lastname,Contact_Address,Contact_City,Contact_State,Contact_Zip,Contact_Phone1,Contact_Phone2,Contact_Phone3,Contact_Email,Contact_PreferredMethod,Contact_Over18,Contact_Inquiring,Contact_InquiringB,Contact_Businesses,Contact_IncidentField1,Contact_IncidentField2,Contact_IncidentField3,Contact_IncidentField4,Contact_IncidentField5,Contact_IncidentField6,Contact_IncidentField7,Contact_IncidentField7b,Contact_IncidentField8,Contact_IncidentField9,Contact_IncidentField9b,Contact_IncidentField10,Contact_IncidentField11,Contact_IncidentField12,Contact_IncidentField13,Contact_IncidentField14,Contact_IncidentField15,Contact_IncidentField15b,Contact_IncidentField16,Contact_IncidentField17,Contact_IncidentField18,Contact_IncidentField18b,Contact_IncidentField19,Contact_IncidentField20,Contact_ServiceID,Contact_ServiceTitle)
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
//            '" + fax.Replace("'", "''") + @"',
//            '" + email.Replace("'", "''") + @"',
//            '" + preferred.Replace("'", "''") + @"',
//            '" + age.Replace("'", "''") + @"',
//            '" + inquiring.Replace("'", "''") + @"',
//            '" + inquiringB.Replace("'", "''") + @"',
//            '" + businesses.Replace("'", "''") + @"',
//            '" + field1.Replace("'", "''") + @"',
//            '" + field2.Replace("'", "''") + @"',
//            '" + field3.Replace("'", "''") + @"',
//            '" + field4.Replace("'", "''") + @"',
//            '" + field5.Replace("'", "''") + @"',
//            '" + field6.Replace("'", "''") + @"',
//            '" + field7.Replace("'", "''") + @"',
//            '" + field7b.Replace("'", "''") + @"',
//            '" + field8.Replace("'", "''") + @"',
//            '" + field9.Replace("'", "''") + @"',
//            '" + field9b.Replace("'", "''") + @"',
//            '" + field10.Replace("'", "''") + @"',
//            '" + field11.Replace("'", "''") + @"',
//            '" + field12.Replace("'", "''") + @"',
//            '" + field13.Replace("'", "''") + @"',
//            '" + field14.Replace("'", "''") + @"',
//            '" + field15.Replace("'", "''") + @"',
//            '" + field15b.Replace("'", "''") + @"',
//            '" + field16.Replace("'", "''") + @"',
//            '" + field17.Replace("'", "''") + @"',
//            '" + field18.Replace("'", "''") + @"',
//            '" + field18b.Replace("'", "''") + @"',
//            '" + field19.Replace("'", "''") + @"',
//            '" + field20.Replace("'", "''") + @"',
//            '" + serviceid.Replace("'", "''") + @"',
//            '" + servicetitle.Replace("'", "''") + @"')
//        ";

        string insertSQL = @"
            INSERT INTO tblStellpflug_ServiceContactSubmissions
            (Contact_DateAdded,Contact_Firstname,Contact_Lastname,Contact_Address,Contact_City,Contact_State,Contact_Zip,Contact_Phone1,Contact_Phone2,Contact_Phone3,Contact_Email,Contact_PreferredMethod,Contact_Over18,Contact_Inquiring,Contact_InquiringB,Contact_Businesses,Contact_IncidentField1,Contact_IncidentField2,Contact_IncidentField3,Contact_IncidentField4,Contact_IncidentField5,Contact_IncidentField6,Contact_IncidentField7,Contact_IncidentField7b,Contact_IncidentField8,Contact_IncidentField9,Contact_IncidentField9b,Contact_IncidentField10,Contact_IncidentField11,Contact_IncidentField12,Contact_IncidentField13,Contact_IncidentField14,Contact_IncidentField15,Contact_IncidentField15b,Contact_IncidentField16,Contact_IncidentField17,Contact_IncidentField18,Contact_IncidentField18b,Contact_IncidentField19,Contact_IncidentField20,Contact_ServiceID,Contact_ServiceTitle)
            VALUES
            (@Contact_DateAdded,@Contact_Firstname,@Contact_Lastname,@Contact_Address,@Contact_City,@Contact_State,@Contact_Zip,@Contact_Phone1,@Contact_Phone2,@Contact_Phone3,@Contact_Email,@Contact_PreferredMethod,@Contact_Over18,@Contact_Inquiring,@Contact_InquiringB,@Contact_Businesses,@Contact_IncidentField1,@Contact_IncidentField2,@Contact_IncidentField3,@Contact_IncidentField4,@Contact_IncidentField5,@Contact_IncidentField6,@Contact_IncidentField7,@Contact_IncidentField7b,@Contact_IncidentField8,@Contact_IncidentField9,@Contact_IncidentField9b,@Contact_IncidentField10,@Contact_IncidentField11,@Contact_IncidentField12,@Contact_IncidentField13,@Contact_IncidentField14,@Contact_IncidentField15,@Contact_IncidentField15b,@Contact_IncidentField16,@Contact_IncidentField17,@Contact_IncidentField18,@Contact_IncidentField18b,@Contact_IncidentField19,@Contact_IncidentField20,@Contact_ServiceID,@Contact_ServiceTitle)
        ";

        sqlComm = new SqlCommand(insertSQL, conn);

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

        sqlComm.Parameters.Add("@Contact_Phone3", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Phone3"].Value = fax.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Email", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Email"].Value = email.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_PreferredMethod", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_PreferredMethod"].Value = preferred.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Over18", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Over18"].Value = age.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Inquiring", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_Inquiring"].Value = inquiring.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_InquiringB", SqlDbType.Text);
        sqlComm.Parameters["@Contact_InquiringB"].Value = inquiringB.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_Businesses", SqlDbType.Text);
        sqlComm.Parameters["@Contact_Businesses"].Value = businesses.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField1", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField1"].Value = field1.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField2", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField2"].Value = field2.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField3", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField3"].Value = field3.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField4", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField4"].Value = field4.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField5", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField5"].Value = field5.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField6", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField6"].Value = field6.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField7", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField7"].Value = field7.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField7b", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField7b"].Value = field7b.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField8", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField8"].Value = field8.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField9", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField9"].Value = field9.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField9b", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField9b"].Value = field9b.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField10", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField10"].Value = field10.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField11", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField11"].Value = field11.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField12", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField12"].Value = field12.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField13", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField13"].Value = field13.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField14", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField14"].Value = field14.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField15", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField15"].Value = field15.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField15b", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField15b"].Value = field15b.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField16", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField16"].Value = field16.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField17", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField17"].Value = field17.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField18", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField18"].Value = field18.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField18b", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField18b"].Value = field18b.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField19", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_IncidentField19"].Value = field19.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_IncidentField20", SqlDbType.Text);
        sqlComm.Parameters["@Contact_IncidentField20"].Value = field20.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_ServiceID", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_ServiceID"].Value = serviceid.Replace("'", "''");

        sqlComm.Parameters.Add("@Contact_ServiceTitle", SqlDbType.VarChar);
        sqlComm.Parameters["@Contact_ServiceTitle"].Value = servicetitle.Replace("'", "''");

        sqlComm.ExecuteNonQuery();
        conn.Close();

        EmailFunctions.epicEmail em = new EmailFunctions.epicEmail();

        // Create Settings
        // info@stellpfluglaw.com
        string client_email = "info@stellpfluglaw.com";
        //RKindle@stellpfluglaw.com
        string client_email2 = "RKindle@stellpfluglaw.com";
        string client_name = "Stellpflug Law";
        string client_domain = "StellpflugLaw.com";
        string client_linecolor = "#808080";
        string client_emailsubject = "New Service Contact Submission (" + servicetitle + ")";
        string sender_emailsubject = "Your Contact Submission";
        string name = firstname + " " + lastname;

        string mybody = em.ServiceContact_Client(name, address, city, state, zip, home, office, fax, email, preferred, age, inquiring, inquiringB, businesses, field1, field2, field3, field4, field5, field6, field7, field7b, field8, field9, field9b, field10, field11, field12, field13, field14, field15, field15b, field16, field17, field18, field18b, field19, field20, servicetitle, formtype, client_linecolor, "www." + client_domain, client_name, client_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(client_email, name, client_email, client_name, client_domain + " - " + client_emailsubject, mybody, true);

        string mybody3 = em.ServiceContact_Client(name, address, city, state, zip, home, office, fax, email, preferred, age, inquiring, inquiringB, businesses, field1, field2, field3, field4, field5, field6, field7, field7b, field8, field9, field9b, field10, field11, field12, field13, field14, field15, field15b, field16, field17, field18, field18b, field19, field20, servicetitle, formtype, client_linecolor, "www." + client_domain, client_name, client_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
        epicShared.sendMail(client_email2, name, client_email2, client_name, client_domain + " - " + client_emailsubject, mybody3, true);

        if (email != "")
        {

            string mybody2 = em.ServiceContact_Sender(name, email, client_linecolor, "www." + client_domain, client_name, sender_emailsubject, "<img src=\"http://www.stellpfluglaw.com/App_Images/logo_email.jpg\" alt=\"LOGO\" />", DateTime.Now.ToString("d"));
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

