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
/// Summary description for YouTubeFunctions
/// </summary>
public class YouTubeFunctions
{
	public YouTubeFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string RetrieveYouTubeID(string embedcode)
    {
        string youtube_id = "";
        int id_index = 0;
        int stop_index = 0;

        // Since YouTube updated their embed codes, we now need to update our own code to properly search for the ID
        // This check deciphers whether the stored EmbedCode is old YouTube embed (when the site was launched, or is newer  
        // (current as of January, 2011)
        if (embedcode.Contains("<iframe"))
        {
            youtube_id = RetrieveYouTubeID_v2(embedcode);
        }
        else
        {
            if (embedcode != "")
            {
                id_index = embedcode.IndexOf("http://www.youtube.com/v/");

                stop_index = embedcode.IndexOf("?");
                if (stop_index == -1)
                    stop_index = embedcode.IndexOf("&");


                youtube_id = embedcode.Substring((id_index + 25), (stop_index - (id_index + 25)));
            }
        }
        return youtube_id;
    }

    public static string RetrieveYouTubeID_v2(string embedcode)
    {
        string youtube_id = "";
        int id_index = 0;
        int snippet_index = 0;
        int stop_index = 0;

        string snippet = "";
        if (embedcode != "")
        {
            id_index = embedcode.IndexOf("http://www.youtube.com/embed/") + 29;
            snippet = embedcode.Substring(id_index, (embedcode.Length - id_index));
            embedcode = embedcode.Replace(snippet, "");
            stop_index = snippet.IndexOf("\"");

            youtube_id = snippet.Substring(0, stop_index);
        }
        return youtube_id;
    }

    //public static bool ValidateYouTubeID(string youtube_id)
    //{

    //}

    public static string RetrieveYouTubeIDFromLink(string link)
    {
        string youtube_id = "";
        int start = 0;

        start = link.IndexOf("http://www.youtube.com/watch?v=") + 31;
        youtube_id = link.Substring(start, link.Length - start);

        return youtube_id;
    }

    public static string StripObjectTag(string embedcode)
    {
        string stripped_embed = "";
        int start = 0;
        int end = 0;

        start = embedcode.IndexOf("<embed");
        end = embedcode.IndexOf("</object>");

        stripped_embed = embedcode.Substring(start, end - start);

        return stripped_embed;
    }
}
