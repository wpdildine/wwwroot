using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using epicCMS;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
/// <summary>
/// Summary description for epicShared
/// </summary>
public class epicShared
{
    public epicShared()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string StripTrailingBR(string myString)
    {
        if (myString.Length >= 4)
        {
            int lastIndex = myString.LastIndexOf("<br>");
            if (lastIndex == (myString.Length - 4))
                myString = myString.Substring(0, myString.Length - 4);
        }
        return myString;

    }
    public static string _connstring = ConfigurationManager.ConnectionStrings["epicConnectionString"].ConnectionString;

    public static string GetLanguageId()
    {
        string langId = "";
        if (HttpContext.Current.Request["langId"] != null)
        {
            langId = HttpContext.Current.Request["langId"].ToString();
        }
        else
        {
            string siteId = "";
            if ((HttpContext.Current.Request["siteId"] != null) && (HttpContext.Current.Request["siteId"].ToString() != "-1"))
            {
                siteId = HttpContext.Current.Request["siteId"].ToString();
            }
            else
            {
                tblSites s = new tblSites();
                s.Where.SiteTitle.Value = epicShared.GetSiteIdURL();
                s.Query.Load();
                siteId = s.SiteId.ToString();

            }
            tblLanguages lang = new tblLanguages();
            lang.Where.DefaultLanguage.Value = true;
            lang.Where.SiteId.Value = Int32.Parse(siteId);

            lang.Query.Load();

            langId = lang.LanguageId.ToString();
        }
        return langId;
    }

    public static string EncryptPassword(string sData)
    {

        byte[] encData_byte = new byte[sData.Length];
        encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
        string encodedData = Convert.ToBase64String(encData_byte);
        return encodedData;
    }

    public static string DecryptPassword(string sData)
    {
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        System.Text.Decoder utf8Decode = encoder.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(sData);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        string result = new String(decoded_char);
        return result;
    }

    public static string GetDateSuffix(DateTime date)
    {
        string day = date.Day.ToString();
        if (day.EndsWith("1"))
        {
            return day.StartsWith("1") && date.Day != 1 ? "th" : "st";
        }
        else if (day.EndsWith("2"))
        {
            return day.StartsWith("1") ? "th" : "nd";
        }
        else if (day.EndsWith("3"))
        {
            return day.StartsWith("1") ? "th" : "rd";
        }
        return "th";
    }

    public static string GetStateNameFromAbbrev(string abbrev)
    {
        string statename = "Canada";
        switch (abbrev)
        {
            case "AL":
                statename = "Alabama";
                break;
            
            case "AK":
                statename = "Alaska";
                break;

            case "AZ":
                statename = "Arizona";
                break;

            case "AR":
                statename = "Arkansas";
                break;

            case "CA":
                statename = "California";
                break;

            case "CO":
                statename = "Colorado";
                break;

            case "CT":
                statename = "Connecticut";
                break;

            case "DE":
                statename = "Delaware";
                break;

            case "DC":
                statename = "Distric of Columbia";
                break;

            case "FL":
                statename = "Florida";
                break;

            case "GA":
                statename = "Georgia";
                break;

            case "GU":
                statename = "Guam";
                break;

            case "HI":
                statename = "Hawaii";
                break;

            case "ID":
                statename = "Idaho";
                break;

            case "IL":
                statename = "Illinois";
                break;

            case "IN":
                statename = "Indiana";
                break;

            case "IA":
                statename = "Iowa";
                break;

            case "KS":
                statename = "Kansas";
                break;

            case "KY":
                statename = "Kentucky";
                break;

            case "LA":
                statename = "Louisiana";
                break;

            case "ME":
                statename = "Maine";
                break;

            case "MH":
                statename = "Marshall Islands";
                break;

            case "MA":
                statename = "Massachusetts";
                break;

            case "MI":
                statename = "Michigan";
                break;

            case "MN":
                statename = "Minnesota";
                break;

            case "MS":
                statename = "Mississippi";
                break;

            case "MO":
                statename = "Missouri";
                break;

            case "MT":
                statename = "Montana";
                break;

            case "NE":
                statename = "Nebraska";
                break;

            case "NV":
                statename = "Nevada";
                break;

            case "NH":
                statename = "New Hampshire";
                break;

            case "NJ":
                statename = "New Jersey";
                break;

            case "NM":
                statename = "New Mexico";
                break;

            case "NY":
                statename = "New York";
                break;

            case "NC":
                statename = "North Carolina";
                break;

            case "ND":
                statename = "North Dakota";
                break;

            case "OH":
                statename = "Ohio";
                break;

            case "OK":
                statename = "Oklahoma";
                break;

            case "OR":
                statename = "Oregona";
                break;

            case "PA":
                statename = "Pennsylvania";
                break;

            case "PR":
                statename = "Puerto Rico";
                break;

            case "RI":
                statename = "Rhode Island";
                break;

            case "SC":
                statename = "South Carolina";
                break;

            case "SD":
                statename = "South Dakota";
                break;

            case "TN":
                statename = "Tennessee";
                break;

            case "TX":
                statename = "Texas";
                break;

            case "UT":
                statename = "Utah";
                break;

            case "VT":
                statename = "Vermont";
                break;

            case "VA":
                statename = "Virginia";
                break;

            case "VI":
                statename = "Virgin Islands";
                break;

            case "WV":
                statename = "West Virginia";
                break;

            case "WI":
                statename = "Wisconsin";
                break;

            case "WY":
                statename = "Wyoming";
                break;

        }
        return statename;

    }
    public static SortedList GetStates()
    {
        SortedList ht = new SortedList();
        ht.Add("-- Select State --", "-- Select State --");
        ht.Add("Alabama", "AL");
        ht.Add("Alaska", "AK");
        ht.Add("Arizona", "AZ");
        ht.Add("Arkansas", "AR");
        ht.Add("California", "CA");
        ht.Add("Colorado", "CO");
        ht.Add("Connecticut", "CT");
        ht.Add("Delaware", "DE");
        ht.Add("District of Columbia", "DC");
        ht.Add("Florida", "FL");
        ht.Add("Georgia", "GA");
        ht.Add("Guam", "GU");
        ht.Add("Hawaii", "HI");
        ht.Add("Idaho", "ID");
        ht.Add("Illinois", "IL");
        ht.Add("Indiana", "IN");
        ht.Add("Iowa", "IA");
        ht.Add("Kansas", "KS");
        ht.Add("Kentucky", "KY");
        ht.Add("Louisiana", "LA");
        ht.Add("Maine", "ME");
        ht.Add("Marshall Islands", "MH");
        ht.Add("Maryland", "MD");
        ht.Add("Massachusetts", "MA");
        ht.Add("Michigan", "MI");
        ht.Add("Minnesota", "MN");
        ht.Add("Mississippi", "MS");
        ht.Add("Missouri", "MO");
        ht.Add("Montana", "MT");
        ht.Add("Nebraska", "NE");
        ht.Add("Nevada", "NV");
        ht.Add("New Hampshire", "NH");
        ht.Add("New Jersey", "NJ");
        ht.Add("New Mexico", "NM");
        ht.Add("New York", "NY");
        ht.Add("North Carolina", "NC");
        ht.Add("North Dakota", "ND");
        ht.Add("Ohio", "OH");
        ht.Add("Oklahoma", "OK");
        ht.Add("Oregon", "OR");
        ht.Add("Pennsylvania", "PA");
        ht.Add("Puerto Rico", "PR");
        ht.Add("Rhode Island", "RI");
        ht.Add("South Carolina", "SC");
        ht.Add("South Dakota", "SD");
        ht.Add("Tennessee", "TN");
        ht.Add("Texas", "TX");
        ht.Add("Utah", "UT");
        ht.Add("Vermont", "VT");
        ht.Add("Virginia", "VA");
        ht.Add("Virgin Islands", "VI");
        ht.Add("Washington", "WA");
        ht.Add("West Virginia", "WV");
        ht.Add("Wisconsin", "WI");
        ht.Add("Wyoming", "WY");

        ht.Add("CAN - Alberta", "AB");
        ht.Add("CAN - British Columbia", "BC");
        ht.Add("CAN - Manitoba", "MB");
        ht.Add("CAN - New Brunswick", "NB");
        //ht.Add("CAN - Newfoundland and Labrador", "NL");
        ht.Add("CAN - Newfoundland and Lab...", "NL");
        ht.Add("CAN - Northwest Territories", "NT");
        ht.Add("CAN - Nova Scotia", "NS");
        ht.Add("CAN - Nunavut", "NU");
        ht.Add("CAN - Ontario", "ON");
        ht.Add("CAN - Prince Edward Island", "PE");
        ht.Add("CAN - Quebec", "QC");
        ht.Add("CAN - Saskatchewan", "SK");
        ht.Add("CAN - Yukon", "YT");

        return ht;
    }
    public static SortedList GetCountries()
    {
        SortedList ht = new SortedList();
        ht.Add("-- Select Country --", "-- Select Country --");
        ht.Add("United States", "US");
        ht.Add("Canada", "CA");
        ht.Add("Afghanistan", "AF");
        ht.Add("Albania", "AL");
        ht.Add("Algeria", "DZ");
        ht.Add("American Samoa", "AS");
        ht.Add("Andorra", "AD");
        ht.Add("Angola", "AO");
        ht.Add("Anguilla", "AI");
        ht.Add("Antarctica", "AQ");
        ht.Add("Antigua And Barbuda", "AG");



        ht.Add("Argentina", "AR");



        ht.Add("Armenia", "AM");



        ht.Add("Aruba", "AW");



        ht.Add("Austria", "AT");



        ht.Add("Australia", "AU");



        ht.Add("Azerbaijan", "AZ");



        ht.Add("Bahamas", "BS");



        ht.Add("Bahrain", "BH");



        ht.Add("Bangladesh", "BD");



        ht.Add("Barbados", "BB");



        ht.Add("Belarus", "BY");



        ht.Add("Belgium", "BE");



        ht.Add("Belize", "BZ");



        ht.Add("Benin", "BJ");


        ht.Add("Bermuda", "BM");



        ht.Add("Bhutan", "BT");



        ht.Add("Bolivia", "BO");



        ht.Add("Bosnia and Herzegovina", "BA");



        ht.Add("Botswana", "BW");



        ht.Add("Bouvet Island", "BV");



        ht.Add("Brazil", "BR");



        ht.Add("British Indian Ocean Territory", "IO");



        ht.Add("Brunei Darussalam", "BN");



        ht.Add("Bulgaria", "BG");



        ht.Add("Burkina Faso", "BF");



        ht.Add("Burundi", "BI");



        ht.Add("Cambodia", "KH");



        ht.Add("Cameroon", "CM");



        ht.Add("Cape Verde", "CV");



        ht.Add("Cayman Islands", "KY");


        ht.Add("Central African Republic", "CF");


        ht.Add("Chad", "TD");



        ht.Add("Chile", "CL");



        ht.Add("China", "CN");



        ht.Add("Christmas Island", "CX");



        ht.Add("Cocos (Keeling) Islands", "CC");



        ht.Add("Colombia", "CO");



        ht.Add("Comoros", "KM");



        ht.Add("Congo", "CG");



        ht.Add("Cook Islands", "CK");



        ht.Add("Costa Rica", "CR");



        ht.Add("Cote D'Ivoire", "CI");



        ht.Add("Croatia (Local Name: Hrvatska)", "HR");



        ht.Add("Cuba", "CU");



        ht.Add("Cyprus", "CY");



        ht.Add("Czech Republic", "CZ");



        ht.Add("Denmark", "DK");



        ht.Add("Djibouti", "DJ");



        ht.Add("Dominica", "DM");



        ht.Add("Dominican Republic", "DO");



        ht.Add("East Timor", "TP");



        ht.Add("Ecuador", "EC");



        ht.Add("Egypt", "EG");



        ht.Add("El Salvador", "SV");



        ht.Add("Equatorial Guinea", "GQ");



        ht.Add("Eritrea", "ER");



        ht.Add("Estonia", "EE");



        ht.Add("Ethiopia", "ET");



        ht.Add("Falkland Islands (Malvinas)", "FK");



        ht.Add("Faroe Islands", "FO");



        ht.Add("Fiji", "FJ");



        ht.Add("Finland", "FI");



        ht.Add("France", "FR");



        ht.Add("French Guiana", "GF");



        ht.Add("French Polynesia", "PF");



        ht.Add("French Southern Territories", "TF");



        ht.Add("Gabon", "GA");



        ht.Add("Gambia", "GM");



        ht.Add("Georgia", "GE");



        ht.Add("Germany", "DE");



        ht.Add("Ghana", "GH");



        ht.Add("Gibraltar", "GI");



        ht.Add("Greece", "GR");



        ht.Add("Greenland", "GL");



        ht.Add("Grenada", "GD");



        ht.Add("Guadeloupe", "GP");



        ht.Add("Guam", "GU");



        ht.Add("Guatemala", "GT");



        ht.Add("Guinea", "GN");



        ht.Add("Guinea-Bissau", "GW");



        ht.Add("Guyana", "GY");



        ht.Add("Haiti", "HT");



        ht.Add("Heard And Mc Donald Islands", "HM");



        ht.Add("Holy See (Vatican City State)", "VA");



        ht.Add("Honduras", "HN");



        ht.Add("Hong Kong", "HK");



        ht.Add("Hungary", "HU");



        ht.Add("Iceland", "IS");



        ht.Add("India", "IN");



        ht.Add("Indonesia", "ID");



        ht.Add("Iran (Islamic Republic Of)", "IR");



        ht.Add("Iraq", "IQ");



        ht.Add("Ireland", "IE");



        ht.Add("Israel", "IL");



        ht.Add("Italy", "IT");



        ht.Add("Jamaica", "JM");



        ht.Add("Japan", "JP");



        ht.Add("Jordan", "JO");



        ht.Add("Kazakhstan", "KZ");



        ht.Add("Kenya", "KE");



        ht.Add("Kiribati", "KI");



        ht.Add("North Korea", "KP");



        ht.Add("South Korea", "KR");



        ht.Add("Kuwait", "KW");



        ht.Add("Kyrgyzstan", "KG");



        ht.Add("Laos", "LA");



        ht.Add("Latvia", "LV");



        ht.Add("Lebanon", "LB");



        ht.Add("Lesotho", "LS");



        ht.Add("Liberia", "LR");



        ht.Add("Libyan Arab Jamahiriya", "LY");



        ht.Add("Liechtenstein", "LI");



        ht.Add("Lithuania", "LT");



        ht.Add("Luxembourg", "LU");



        ht.Add("Macau", "MO");



        ht.Add("Macedonia", "MK");



        ht.Add("Madagascar", "MG");



        ht.Add("Malawi", "MW");



        ht.Add("Malaysia", "MY");



        ht.Add("Maldives", "MV");



        ht.Add("Mali", "ML");



        ht.Add("Malta", "MT");



        ht.Add("Marshall Islands", "MH");



        ht.Add("Martinique", "MQ");



        ht.Add("Mauritania", "MR");



        ht.Add("Mauritius", "MU");



        ht.Add("Mayotte", "YT");



        ht.Add("Mexico", "MX");



        ht.Add("Micronesia, Federated States", "FM");



        ht.Add("Moldova, Republic Of", "MD");



        ht.Add("Monaco", "MC");
        ht.Add("Mongolia", "MN");
        ht.Add("Montserrat", "MS");
        ht.Add("Morocco", "MA");
        ht.Add("Mozambique", "MZ");
        ht.Add("Myanmar", "MM");


        ht.Add("Namibia", "NA");



        ht.Add("Nauru", "NR");



        ht.Add("Nepal", "NP");


        ht.Add("Netherlands", "NL");



        ht.Add("Netherlands Antilles", "AN");



        ht.Add("New Caledonia", "NC");



        ht.Add("New Zealand", "NZ");



        ht.Add("Nicaragua", "NI");



        ht.Add("Niger", "NE");



        ht.Add("Nigeria", "NG");



        ht.Add("Niue", "NU");



        ht.Add("Norfolk Island", "NF");



        ht.Add("Northern Mariana Islands", "MP");



        ht.Add("Norway", "NO");



        ht.Add("Oman", "OM");



        ht.Add("Pakistan", "PK");



        ht.Add("Palau", "PW");



        ht.Add("Panama", "PA");



        ht.Add("Papua New Guinea", "PG");



        ht.Add("Paraguay", "PY");



        ht.Add("Peru", "PE");



        ht.Add("Philippines", "PH");



        ht.Add("Pitcairn", "PN");



        ht.Add("Poland", "PL");



        ht.Add("Portugal", "PT");



        ht.Add("Puerto Rico", "PR");



        ht.Add("Qatar", "QA");



        ht.Add("Reunion", "RE");



        ht.Add("Romania", "RO");



        ht.Add("Russian Federation", "RU");



        ht.Add("Rwanda", "RW");



        ht.Add("Saint Kitts and Nevis", "KN");



        ht.Add("Saint Lucia", "LC");



        ht.Add("Saint Vincent, The Grenadines", "VC");



        ht.Add("Samoa", "WS");



        ht.Add("San Marino", "SM");



        ht.Add("Sao Tome And Principe", "ST");



        ht.Add("Saudi Arabia", "SA");



        ht.Add("Senegal", "SN");



        ht.Add("Seychelles", "SC");



        ht.Add("Sierra Leone", "SL");



        ht.Add("Singapore", "SG");



        ht.Add("Slovakia (Slovak Republic)", "SK");



        ht.Add("Slovenia", "SI");



        ht.Add("Solomon Islands", "SB");



        ht.Add("Somalia", "SO");



        ht.Add("South Africa", "ZA");



        ht.Add("South Georgia , S Sandwich Is.", "GS");



        ht.Add("Spain", "ES");



        ht.Add("Sri Lanka", "LK");



        ht.Add("St. Helena", "SH");



        ht.Add("St. Pierre And Miquelon", "PM");



        ht.Add("Sudan", "SD");



        ht.Add("Suriname", "SR");



        ht.Add("Svalbard, Jan Mayen Islands", "SJ");



        ht.Add("Swaziland", "SZ");



        ht.Add("Sweden", "SE");



        ht.Add("Switzerland", "CH");



        ht.Add("Syrian Arab Republic", "SY");



        ht.Add("Taiwan", "TW");



        ht.Add("Tajikistan", "TJ");



        ht.Add("Tanzania, United Republic Of", "TZ");



        ht.Add("Thailand", "TH");



        ht.Add("Togo", "TG");



        ht.Add("Tokelau", "TK");



        ht.Add("Tonga", "TO");



        ht.Add("Trinidad And Tobago", "TT");



        ht.Add("Tunisia", "TN");



        ht.Add("Turkey", "TR");



        ht.Add("Turkmenistan", "TM");



        ht.Add("Turks And Caicos Islands", "TC");



        ht.Add("Tuvalu", "TV");



        ht.Add("Uganda", "UG");



        ht.Add("Ukraine", "UA");



        ht.Add("United Arab Emirates", "AE");



        ht.Add("United Kingdom", "GB");



        ht.Add("United States Minor Is.", "UM");



        ht.Add("Uruguay", "UY");



        ht.Add("Uzbekistan", "UZ");



        ht.Add("Vanuatu", "VU");



        ht.Add("Venezuela", "VE");



        ht.Add("Viet Nam", "VN");


        ht.Add("Virgin Islands (British)", "VG");



        ht.Add("Virgin Islands (U.S.)", "VI");



        ht.Add("Wallis And Futuna Islands", "WF");



        ht.Add("Western Sahara", "EH");



        ht.Add("Yemen", "YE");



        ht.Add("Yugoslavia", "YU");



        ht.Add("Zaire", "ZR");



        ht.Add("Zambia", "ZM");



        ht.Add("Zimbabwe", "ZW");
        return ht;



    }

    public static string GetSiteIdURL()
    {
        string site = "";
        string url = HttpContext.Current.Request.Url.Host.ToString();
        if (url.Contains("www"))
        {
            url = url.Replace("www.", "");
            if (site.Contains("http://"))
            {
                site = url.Replace("http://", "");
            }

        }
        else
        {
            //string url2 = url.Substring(url.IndexOf("//"));
            //url2 = url.Substring(url2.Length, url.IndexOf("/"));
            if (site.Contains("http://"))
            {
            site = url.Replace("http://", "");
            }
       
        }
        return site;

    }
    public static string[] GetProductDirsFromUrl()
    {
        string tmp = HttpContext.Current.Request.RawUrl;
        tmp = tmp.Substring(tmp.IndexOf("/"));

        string[] dirs = tmp.Split('/');

        return dirs;
    }

    public static void sendMail(string toEmail, string toName, string fromEmail, string fromName, string subject, string body, bool isHtml)
    {

        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        msg.From = new System.Net.Mail.MailAddress(fromEmail, fromName);
        System.Net.Mail.MailAddressCollection mc = msg.To;
        mc.Add(new System.Net.Mail.MailAddress(toEmail, toName));

        msg.Body = body;
        msg.Subject = subject;
        msg.IsBodyHtml = isHtml;


        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["mailServer"]);
        if (ConfigurationManager.AppSettings["mailServer"].Contains("office.balancestudios.com"))
        {
            System.Net.NetworkCredential authenticationInfo = new System.Net.NetworkCredential("smtp", "b@l_SMTP");
            client.UseDefaultCredentials = false;
            client.Credentials = authenticationInfo;
        }
        try
        {
            client.Send(msg);
        }
        catch (Exception e)
        {
        }
    }

    public static void sendMailwithBCC(string bccEmail, string bccName, string toEmail, string toName, string fromEmail, string fromName, string subject, string body, bool isHtml)
    {

        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        msg.From = new System.Net.Mail.MailAddress(fromEmail, fromName);
        System.Net.Mail.MailAddressCollection mc = msg.To;
        System.Net.Mail.MailAddressCollection bcc = msg.Bcc;
        bcc.Add(new System.Net.Mail.MailAddress(bccEmail, bccName));
        mc.Add(new System.Net.Mail.MailAddress(toEmail, toName));

        msg.Body = body;
        msg.Subject = subject;
        msg.IsBodyHtml = isHtml;

        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["mailServer"]);
        if (ConfigurationManager.AppSettings["mailServer"].Contains("office.balancestudios.com"))
        {
            System.Net.NetworkCredential authenticationInfo = new System.Net.NetworkCredential("smtp", "b@l_SMTP");
            client.UseDefaultCredentials = false;
            client.Credentials = authenticationInfo;
        }
        try
        {
            client.Send(msg);
        }
        catch (Exception e)
        {
        }
    }

    public static string sPhysicalPath = "";
    public static string sFileName = "";
    public static string sTempFileName = "";
    public static string sImageName = "";
    public static StringBuilder sb = new StringBuilder();
    public static void resize(string name, string path, string physicalpath, string width, string height, string suffix)
    {

        if (height.Length == 0)
            height = "0";
        else
            height = height;

        if (suffix != "")
            suffix = "_" + suffix;

        checkimageformat(path, physicalpath, name, suffix, Convert.ToInt32(width), Convert.ToInt32(height));


    }
    public static void checkimageformat(string savepath, string sPhysicalPath, string FName, string suffix, int width, int height)
    {
        decimal maxWidth = 0;
        decimal auto = 0;
        decimal newheight = 0;
        decimal maxHeight = 0;
        Size ThumbNailSize = new Size();
        sFileName = FName.ToLower();
        //sThumbName = sFileName.Replace(".", ThumbNailName + ".");
        string na = sFileName.Substring(0, sFileName.IndexOf("."));
        string format = sFileName.Substring(na.Length);
        sImageName = na + suffix + format;
        if (height > 0)
        {
            ThumbNailSize = new Size(width, height);
        }
        else
        {
            System.Drawing.Image origImg = System.Drawing.Image.FromFile(sPhysicalPath + FName);
            maxWidth = Convert.ToDecimal(origImg.Width);
            maxHeight = Convert.ToDecimal(origImg.Height);
            auto = Math.Round((maxWidth / maxHeight), 4);
            newheight = Math.Round((width / auto), 0);
            ThumbNailSize = new Size(width, Convert.ToInt32(newheight));
            origImg.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        if (sFileName.ToLower().IndexOf(".gif") > 0)
        {
            epicShared.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Gif, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".jpg") > 0)
        {
            epicShared.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".jpeg") > 0)
        {
            epicShared.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Jpeg, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".bmp") > 0)
        {
            epicShared.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Bmp, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".png") > 0)
        {
            epicShared.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Png, ThumbNailSize.Width, ThumbNailSize.Height);
        }
        if (sFileName.ToLower().IndexOf(".tif") > 0)
        {
            epicShared.GenerateImage(savepath, sPhysicalPath, sFileName, sImageName, ImageFormat.Tiff, ThumbNailSize.Width, ThumbNailSize.Height);
        }
    }

    public static string GenerateImage(string savePath, string sPhysicalPath, string sOrgFileName, string sImageFileName, ImageFormat oFormat, int widthnew, int heightnew)
    {
        string filename = sOrgFileName.Substring(0, sOrgFileName.LastIndexOf("."));
        Size thumsize = new Size(widthnew, heightnew);
        try
        {
            if (oFormat != ImageFormat.Gif)
            {
                System.Drawing.Image oImg = System.Drawing.Image.FromFile(sPhysicalPath + @"\" + sOrgFileName);
                System.Drawing.Image oThumbNail = new Bitmap(thumsize.Width, thumsize.Height, oImg.PixelFormat);

                Graphics oGraphic = Graphics.FromImage(oThumbNail);
                oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                oGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                ImageAttributes attribute = new ImageAttributes();
                attribute.SetWrapMode(WrapMode.TileFlipXY);
                oGraphic.DrawImage(oImg, new Rectangle(new Point(0, 0), thumsize), 0, 0, oImg.Width, oImg.Height, GraphicsUnit.Pixel, attribute);

                oImg.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // First delete the image
                //FileInfo fi = new FileInfo(sPhysicalPath + sOrgFileName);
                //fi.Attributes = FileAttributes.Normal;
                //fi.Delete();

                // Then resave it with its new size
                oThumbNail.Save(sPhysicalPath + sImageFileName, oFormat);

                // Empty Garbage
                oGraphic.Dispose();
                oThumbNail.Dispose();
                GC.Collect();
                sb.Append(sPhysicalPath + sImageFileName);
            }
            else
            {
                Bitmap bm = new Bitmap(sPhysicalPath + @"\" + sOrgFileName);
                Bitmap bm2 = new Bitmap(thumsize.Width, thumsize.Height, PixelFormat.Format64bppPArgb);
                Graphics g2 = Graphics.FromImage(bm2);
                Rectangle subRect = new Rectangle(0, 0, thumsize.Width, thumsize.Height);
                g2.DrawImage(bm, subRect);
                bm.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                bm2.Save(sPhysicalPath + sImageFileName, oFormat);
                g2.Dispose();
                bm2.Dispose();
                GC.Collect();

                sb.Append(sPhysicalPath + sImageFileName);

            }
        }
        catch (Exception e1) { sb.Append(e1.Message); }
        return sb.ToString();
    }
    

}
