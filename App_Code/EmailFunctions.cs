using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

/// <summary>
/// Summary description for EmailFunctions
/// </summary>

namespace EmailFunctions
{
    public class epicEmail
    {
        public epicEmail()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        internal string GetFromResources(string htmlfile)
        {
            string resourceName = HttpContext.Current.Request.PhysicalApplicationPath + "\\_templates\\" + htmlfile;
            StreamReader objStreamReader = new StreamReader(resourceName);
            try
            {

                return objStreamReader.ReadToEnd();
                
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving from Resources. Tried '"
                                         + resourceName + "'\r\n" + e.ToString());
            }
        }


        public string Contact_Client(string email1, string email2, string name, string address, string city, string state, string zip, string home, string office, string email, string preferred, string time, string how, string comments, string bordercolor, string client_domain, string client_name, string client_subject, string client_logo, string date)
        {
            string quote = GetFromResources("contact_client.htm");

            quote = quote.Replace("%name%", name);
            quote = quote.Replace("%address%", address);
            quote = quote.Replace("%city%", city);
            quote = quote.Replace("%state%", state);
            quote = quote.Replace("%zip%", zip);
            quote = quote.Replace("%home%", home);
            quote = quote.Replace("%office%", office);
            quote = quote.Replace("%email%", email);
            quote = quote.Replace("%email1%", email1);
            quote = quote.Replace("%email2%", email2);
            quote = quote.Replace("%preferred%", preferred);
            quote = quote.Replace("%time%", time);
            quote = quote.Replace("%how%", how);
            quote = quote.Replace("%comments%", comments);

            quote = quote.Replace("%bordercolor%", bordercolor);
            quote = quote.Replace("%client_name%", client_name);
            quote = quote.Replace("%client_subject%", client_subject);
            quote = quote.Replace("%client_logo%", client_logo);
            quote = quote.Replace("%client_web%", client_domain);
            quote = quote.Replace("%date%", date);
            return quote;
        }

        public string Contact_Sender(string name, string email, string bordercolor, string client_domain, string client_name, string client_subject, string client_logo, string date)
        {
            string quote = GetFromResources("contact_sender.htm");

            quote = quote.Replace("%name%", name);
            quote = quote.Replace("%email%", email);

            quote = quote.Replace("%bordercolor%", bordercolor);
            quote = quote.Replace("%client_name%", client_name);
            quote = quote.Replace("%client_subject%", client_subject);
            quote = quote.Replace("%client_logo%", client_logo);
            quote = quote.Replace("%client_web%", client_domain);
            quote = quote.Replace("%date%", date);
            return quote;
        }

        public string Signup_Client(string name, string email, string address, string city, string state, string zip, string country, string bordercolor, string client_domain, string client_name, string client_subject, string client_logo, string date)
        {
            string quote = GetFromResources("signup_client.htm");

            quote = quote.Replace("%name%", name);
            quote = quote.Replace("%address%", address);
            quote = quote.Replace("%city%", city);
            quote = quote.Replace("%state%", state);
            quote = quote.Replace("%zip%", zip);
            quote = quote.Replace("%country%", country);
            quote = quote.Replace("%email%", email);

            quote = quote.Replace("%bordercolor%", bordercolor);
            quote = quote.Replace("%client_name%", client_name);
            quote = quote.Replace("%client_subject%", client_subject);
            quote = quote.Replace("%client_logo%", client_logo);
            quote = quote.Replace("%client_web%", client_domain);
            quote = quote.Replace("%date%", date);
            return quote;
        }

        public string Signup_Sender(string name, string email, string bordercolor, string client_domain, string client_name, string client_subject, string client_logo, string date)
        {
            string quote = GetFromResources("signup_sender.htm");

            quote = quote.Replace("%name%", name);
            quote = quote.Replace("%email%", email);

            quote = quote.Replace("%bordercolor%", bordercolor);
            quote = quote.Replace("%client_name%", client_name);
            quote = quote.Replace("%client_subject%", client_subject);
            quote = quote.Replace("%client_logo%", client_logo);
            quote = quote.Replace("%client_web%", client_domain);
            quote = quote.Replace("%date%", date);
            return quote;
        }

        public string ServiceContact_Client(string name, string address, string city, string state, string zip, string home, string office, string fax, string email, string preferred, string age, string inquiring, string inquiringB, string businesses, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field7b, string field8, string field9, string field9b, string field10, string field11, string field12, string field13, string field14, string field15, string field15b, string field16, string field17, string field18, string field18b, string field19, string field20, string servicetitle, string formtype, string bordercolor, string client_domain, string client_name, string client_subject, string client_logo, string date)
        {
            string quote = GetFromResources("contact_service_client.htm");

            quote = quote.Replace("%name%", name);
            quote = quote.Replace("%address%", address);
            quote = quote.Replace("%city%", city);
            quote = quote.Replace("%state%", state);
            quote = quote.Replace("%zip%", zip);
            quote = quote.Replace("%home%", home);
            quote = quote.Replace("%office%", office);
            quote = quote.Replace("%fax%", fax);
            quote = quote.Replace("%email%", email);
            quote = quote.Replace("%preferred%", preferred);
            quote = quote.Replace("%age%", age);
            quote = quote.Replace("%inquiring%", inquiring);
            quote = quote.Replace("%inquiringb%", inquiringB);
            quote = quote.Replace("%businesses%", businesses);
            quote = quote.Replace("%field1%", field1);
            quote = quote.Replace("%field2%", field2);
            quote = quote.Replace("%field3%", field3);
            quote = quote.Replace("%field4%", field4);
            quote = quote.Replace("%field5%", field5);
            quote = quote.Replace("%field6%", field6);

            string longform = "";
            if (formtype == "long")
            {

                longform += "<br /><strong>Have you consulted with another attorney on this matter?</strong> " + field7 + "<br />";
                if (field7.ToLower() == "yes")
                    longform += "<strong>If Yes, Please Explain:</strong> " + field7b + "<br />";
                longform += "<strong>Is your incident currently in litigation?</strong> " + field8 + "<br />";
                longform += "<strong>Is your claim currently under investigation?</strong> " + field9 + "<br />";
                if (field9.ToLower() == "yes")
                    longform += "<strong>If Yes, Please Explain:</strong> " + field9b + "<br />";
                longform += "<strong>If a vehicular accident, did you receive citation?</strong> " + field10 + "<br />";
                longform += "<strong>If your case involves a product, do you still have the product?</strong> " + field11 + "<br />";
                longform += "<strong>Please select the area or areas were your injury or injuries occurred:</strong> " + field12 + "<br />";
                longform += "<strong>Please explain the nature of your injury or injuries selected above in detail:</strong> " + field13 + "<br />";
                longform += "<strong>Please name all health care providers you have seen as a result of your injury:</strong> " + field14 + "<br />";
                longform += "<strong>Were you in good health prior to the injury?</strong> " + field15 + "<br />";
                if (field15.ToLower() == "no")
                    longform += "<strong>If No, Please Explain:</strong> " + field15b + "<br />";
                longform += "<strong>Are you still being medically treated for your injuries?</strong> " + field16 + "<br />";
                longform += "<strong>Did you miss work as a result of your injuries?</strong> " + field17 + "<br />";
                longform += "<strong>Did you sustain any permanent injuries?</strong> " + field18 + "<br />";
                if (field18.ToLower() == "yes")
                    longform += "<strong>If Yes, Please Explain:</strong> " + field18b + "<br />";
                longform += "<strong>Do we have your permission to associate other attorneys in your jurisdiction?:</strong> " + field19 + "<br />";
                longform += "<strong>Please indicate any other information you would like to provide:</strong> " + field20 + "<br />";
                quote = quote.Replace("%longform%", longform);

            }
            else
            {
                quote = quote.Replace("%longform%", "");
            }

            quote = quote.Replace("%servicetitle%", servicetitle);

            quote = quote.Replace("%bordercolor%", bordercolor);
            quote = quote.Replace("%client_name%", client_name);
            quote = quote.Replace("%client_subject%", client_subject);
            quote = quote.Replace("%client_logo%", client_logo);
            quote = quote.Replace("%client_web%", client_domain);
            quote = quote.Replace("%date%", date);
            return quote;
        }

        public string ServiceContact_Sender(string name, string email, string bordercolor, string client_domain, string client_name, string client_subject, string client_logo, string date)
        {
            string quote = GetFromResources("contact_service_sender.htm");

            quote = quote.Replace("%name%", name);
            quote = quote.Replace("%email%", email);

            quote = quote.Replace("%bordercolor%", bordercolor);
            quote = quote.Replace("%client_name%", client_name);
            quote = quote.Replace("%client_subject%", client_subject);
            quote = quote.Replace("%client_logo%", client_logo);
            quote = quote.Replace("%client_web%", client_domain);
            quote = quote.Replace("%date%", date);
            return quote;
        }
    }
}
