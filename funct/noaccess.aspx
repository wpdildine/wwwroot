<%@ Page Language="C#" AutoEventWireup="true" CodeFile="noaccess.aspx.cs" Inherits="funct_noaccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Floortime Training - Access Required</title>
    
 
    <meta http-equiv="imagetoolbar" content="no" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="" runat="server" id="meta_desc"/>
    <meta name="keywords" content=""  runat="server" id="meta_keywords"/>
    <meta name="language" content="EN-US" />
    <meta name="author" content="" />
    <meta name="robots" content="all" />
    <meta name="revisit-after" content="1 days" />
    <meta name="distribution" content="GLOBAL" />
    <meta http-equiv="imagetoolbar" content="no" />
    
    <script type="text/javascript" src="/App_Js/jquery-1.11.2.js"></script>
    <script type="text/javascript" src="/App_Js/scrollto/jquery.scrollTo.min.js"></script> 
    <script type="text/javascript" src="/App_Js/easydropdown-master/src/jquery.easydropdown.js"></script>
    <link rel="stylesheet" type="text/css" href="/App_Css/reset.css" />
    <link rel="stylesheet" type="text/css" href="/App_Css/webfonts/geneva/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="/App_Css/common.css" />
    <link rel="stylesheet" type="text/css" href="/App_Css/buttons.css" />
    <link rel="stylesheet" type="text/css" href="/App_Css/text.css" />
    <link rel="stylesheet" type="text/css" href="/App_Css/pages.css" />
    <link rel="stylesheet" type="text/css" href="/App_Css/overlay.css" />
    <link rel="stylesheet" type="text/css" href="/App_Js/easydropdown-master/themes/easydropdown.floortime.css" />
    <script src="http://jwpsrv.com/library/0tCsWOIWEeSNxRJtO5t17w.js"></script>
    <script type="text/javascript">jwplayer.key = "KrZPJLoXOq9HGsNJ2TOTWKUHpWtV98VmANWGz73NnAk="</script>
    <script type="text/javascript" src="/App_JS/functions.js"></script>
    
    <style type="text/css">

         /* No Accesse */
        .pg_noaccess #content {
            width: 1057px;
        }

        .pg_noaccess #content .top {

            
            background: url(/App_Images/img_welcome1.png) repeat-x;
            height: 433px;
            position: relative;
            margin-left: -95px; 

        }

            .pg_noaccess #content .top .inner { 
                color: #fff; 
                position: absolute; 
                top: 103px; 
                left: 577px; 
                width: 480px 

            }
            
        .pg_noaccess #content .btm {

            
            background: url(/App_Images/img_welcome2.png) no-repeat;
            height: 215px;
            position: relative;
            margin: 0px -95px; 
            

        }

         .pg_noaccess #content .btm .inner { 
                color: #fff; 
                position: absolute; 
                top: 60px; 
                left: 95px; 
                width: 975px 

            }

         .pg_noaccess #content .btm .inner div { 
               line-height: 24px; font-size: 18px; font-weight: bold;

            }
         .pg_noaccess #content .btm .inner abbr.vocab, .pg_noaccess #content .top .inner abbr.vocab { background-color: transparent; text-decoration: underline; }
                     .pg_noaccess #content .btm .arrow { position: absolute; top: 0px; right: 115px;}
                     .pg_noaccess #content .btm .btn { position: absolute; z-index: 10; top: 60px; right: 150px;}

    </style>
</head>
<body runat="server" class="pg_noaccess" id="html_body"><form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div id="overall_wrapper">
            <div class="overall_inner">

                   <div id="header">

                        <h1><a href="/en-us/default.aspx"><img src="/App_Images/logo_top.png" alt="The Greenspan Floortime Approach" /></a></h1>
                    
                    </div>

                

                
            
               
                <div id="content">
                    <div class="top">

                        <div class="inner">
                            <h6 class="s_bold">ACCESS REQUIRED</h6>
                            <div class="p s_bold c_white">
                                In order to access the Floortime Training website, please log back in to your account at:<br /><br />                                <a class="c_white" href="http://www.StanleyGreenspan.com" target="_blank">www.StanleyGreenspan.com</a><br /><br />                                Afterwards, use the link for FloortimeTraining.com to access this website.          <br /><br />  

                            </div>
                        </div>
                    </div>
                    <p style="margin-top: 30px">If you continue to experience difficulties accessing this website, please <a href="http://www.stanleygreenspan.com/contact-us/" target="_blank">contact us immediately</a>.</p>


                </div>
        
                <ul id="footer">

                    <li></li>

                </ul>
            </div>
        </div>
     
</form>
</body>


</html>

