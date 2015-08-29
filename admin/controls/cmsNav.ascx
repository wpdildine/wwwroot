<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmsNav.ascx.cs" Inherits="admin_controls_cmsNav" %>
<script type="text/javascript" language="javascript">
function Save(){
var postBackButton = document.getElementById("<%= Button1.ClientID %>");
postBackButton.click();
}</script>
<ul id="nav">
    <li runat="server" id="tdSpc1"><a  runat="server" id="hlUser" title="Users">Users</a></li>
    <li runat="server" id="tdSpc0"><a  runat="server" id="hlPage" title="Pages">Pages</a></li>
    <li runat="server" id="tdSpc2"><a  runat="server" id="hlImage" title="Images">Images</a></li>
    <li runat="server" id="tdSpc4"><a  runat="server" id="hlDocs"  title="Documents">Documents</a></li>
    <!--<li runat="server" id="tdSpc3"><a  runat="server" id="hlMovie"  title="Movies">Movies</a></li>
    <li runat="server" id="tdSpc5"><a  runat="server" id="hlAudio"  title="Audio">Audio</a></li>-->
    <!--<li runat="server" id="tdSpc6"><a  runat="server" id="hlPodcasts"  title="Podcasts">Podcasts</a></li>-->
</ul>
<asp:Button ID="Button1" Visible="false" runat="server" Text="Button" OnClick="Button1_Click" />


    
