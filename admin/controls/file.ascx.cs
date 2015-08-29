using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;
using System.Text;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

public partial class admin_controls_file : System.Web.UI.UserControl
{
    string sPhysicalPath = "";
    string sFileName = "";
    string sThumbName = "";
    int amount = 0;
    ArrayList af = new ArrayList();
    ArrayList al = new ArrayList();
    ArrayList al2 = new ArrayList();
    ArrayList alcheck = new ArrayList();
    string cat = "";
    private void BindTreeToDirectory(string dirPath, RadTreeNode parentNode, string exfolder)
    {
        string[] directories = Directory.GetDirectories(dirPath);
        foreach (string directory in directories)
        {
            if (!Path.GetFileName(directory).Contains("_svn") && !Path.GetFileName(directory).Contains(".svn"))
            {


                RadTreeNode node = new RadTreeNode(Path.GetFileName(directory));
                node.ImageUrl = "/admin/images/folder.gif";
                node.ExpandedImageUrl = "/admin/images/folder.gif";
                node.ContextMenuID = "MainContextMenu";
                node.Category = "Folder";
                node.Value = directory;

                parentNode.Nodes.Add(node);
                BindTreeToDirectory(directory, node, exfolder);

            }
        }

        string[] files = Directory.GetFiles(dirPath);
        foreach (string file in files)
        {

            if (!Path.GetFileName(file).Contains("_svn") && !Path.GetFileName(file).Contains(".svn"))
            {
                RadTreeNode node = new RadTreeNode(Path.GetFileName(file));
                node.ContextMenuID = "ContextMenuFiles";
                node.Category = "Files";
                node.Value = file;
                node.ImageUrl = "/admin/images/" + GetImageForExtension(Path.GetFileName(file).Substring(Path.GetFileName(file).IndexOf(".")));
                node.ExpandedImageUrl = "/admin/images/" + GetImageForExtension(Path.GetFileName(file).Substring(Path.GetFileName(file).IndexOf(".")));
                parentNode.Nodes.Add(node);
            }
        }

        if (exfolder != "")
        {
            if (exfolder == dirPath)
            {
                //string dir = exfolder.Substring(0, exfolder.LastIndexOf("\\"));
                foreach (RadTreeNode node in RadTreeView1.GetAllNodes())
                {
                    if (node.Value == exfolder)
                    {
                        node.ExpandParentNodes();
                        node.Selected = true;
                        node.Expanded = true;
                    }
                }
                //RadTreeNode cachedNodeClicked = RadTreeView1.FindNodeByValue(exfolder);
                //cachedNodeClicked.Expanded = true;
                //cachedNodeClicked.Selected = true;
            }
        }
    }

    protected void RadTreeView1_HandleDrop(object sender, RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;
        RadTreeNode destNode = e.DestDragNode;
        RadTreeViewDropPosition dropPosition = e.DropPosition;

        string result = "";

        if (destNode != null)//drag&drop is performed between trees
        {

            if (sourceNode.TreeView.SelectedNodes.Count <= 1)
            {
                result += "<b>" + sourceNode.Text + "</b>" + ";";
                PerformDragAndDrop(dropPosition, sourceNode, destNode);
            }
            else if (sourceNode.TreeView.SelectedNodes.Count > 1)
            {
                foreach (RadTreeNode node in sourceNode.TreeView.SelectedNodes)
                {
                    result += "<b>" + node.Text + "</b>" + ";";
                    PerformDragAndDrop(dropPosition, node, destNode);
                }

            }
            else//dropped node will be a sibling of the destination node
            {
                if (sourceNode.TreeView.SelectedNodes.Count <= 1)
                {

                    if (!sourceNode.IsAncestorOf(destNode))
                    {
                        result += "<b>" + sourceNode.Text + "</b>" + ";";
                        sourceNode.Owner.Nodes.Remove(sourceNode);
                        destNode.Nodes.Add(sourceNode);
                    }
                }
                else if (sourceNode.TreeView.SelectedNodes.Count > 1)
                {
                    foreach (RadTreeNode node in RadTreeView1.SelectedNodes)
                    {
                        if (!node.IsAncestorOf(destNode))
                        {
                            result += "<b>" + node.Text + "</b>" + ";";
                            node.Owner.Nodes.Remove(node);
                            destNode.Nodes.Add(node);
                        }
                    }
                }
            }


            if (e.SourceDragNode.Category == "Files")
            {
                if (!System.IO.File.Exists(e.SourceDragNode.Value))
                {
                    System.IO.File.Move(e.SourceDragNode.Value, e.DestDragNode.Value + "\\" + e.SourceDragNode.Text);

                }
                else
                {
                    string fname = e.SourceDragNode.Text.Substring(0, e.SourceDragNode.Text.LastIndexOf("."));
                    string ext = e.SourceDragNode.Text.Substring(fname.Length);
                    int counter = 1;
                    string targetFileName = Path.Combine(e.DestDragNode.Value, fname + counter.ToString() + ext);

                    while (System.IO.File.Exists(targetFileName))
                    {
                        counter++;
                        targetFileName = Path.Combine(e.DestDragNode.Value, fname + counter.ToString() + ext);

                    }

                    System.IO.File.Move(e.SourceDragNode.Value, targetFileName);
                }
            }
            else
            {
                if (!System.IO.Directory.Exists(e.DestDragNode.Value + "\\" + e.SourceDragNode.Text))
                {
                    if (System.IO.Directory.Exists(e.SourceDragNode.Value))
                    {
                        System.IO.Directory.Move(e.SourceDragNode.Value, e.DestDragNode.Value + "\\" + e.SourceDragNode.Text);
                    }
                }
            }

            destNode.Expanded = true;
            System.IO.FileSystemWatcher mywatcher = new FileSystemWatcher(e.DestDragNode.Value);
            mywatcher.WaitForChanged(WatcherChangeTypes.All, 2000);
            sourceNode.TreeView.ClearSelectedNodes();
            createtree(e.DestDragNode.Value);
            // UpdatePanel1.Update();

        }

    }
    private static void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
    {
        if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
        {
            return;
        }
        sourceNode.Owner.Nodes.Remove(sourceNode);

        switch (dropPosition)
        {
            case RadTreeViewDropPosition.Over:
                // child
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    destNode.Nodes.Add(sourceNode);
                }
                break;

            case RadTreeViewDropPosition.Above:
                // sibling - above                    
                destNode.InsertBefore(sourceNode);
                break;

            case RadTreeViewDropPosition.Below:
                // sibling - below
                destNode.InsertAfter(sourceNode);
                break;
        }

    }

    protected void RadTreeView1_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
    {
        RadTreeNode nodeEdited = e.Node;
        string newText = e.Text;
        nodeEdited.Text = newText;

        string oldpath = e.Node.Value.Substring(0, e.Node.Value.LastIndexOf("\\") + 1);
        string oldtext = e.Node.Value.Substring(oldpath.Length);

        if (nodeEdited.Category == "Files")
        {
            getitemonserver(nodeEdited.Category, nodeEdited.Value, oldpath + newText);
        }
        else { getitemonserver(nodeEdited.Category, oldpath + oldtext, oldpath + newText); }

        System.IO.FileSystemWatcher mywatcher = new FileSystemWatcher(oldpath);
        mywatcher.WaitForChanged(WatcherChangeTypes.All, 2000);
        createtree(oldpath.Substring(0, oldpath.LastIndexOf("\\")));

        //UpdatePanel1.Update();

    }

    private void getitemonserver(string category, string item, string text)
    {

        if (category == "Files")
        {
            if (System.IO.File.Exists(item))
            {
                System.IO.File.Move(item, text);
            }
        }
        else
        {
            if (System.IO.Directory.Exists(item))
            {


                DirectoryInfo dInfo = new DirectoryInfo(item);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                string account = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                dSecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.FullControl, AccessControlType.Allow));
                Directory.SetAccessControl(item, dSecurity);
                System.IO.Directory.Move(item, text);
            }
        }



    }

    protected void RadTreeView1_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
    {
        switch (e.MenuItem.Value)
        {

            case "NewFolder":
                if ((RadTreeView1.SelectedNode != null) && (RadTreeView1.SelectedNode.Level == 0))
                {
                    string newNodeTitle = ("New Folder");
                    e.Node.Nodes.Add(new RadTreeNode(newNodeTitle));
                    e.Node.Category = "Folder";
                    e.Node.ImageUrl = "/admin/images/folder.gif";
                    e.Node.ExpandedImageUrl = "/admin/images/folder.gif";
                    e.Node.ContextMenuID = "MainContextMenu";
                    e.Node.Value = getpath(Request["pg"].ToString()) + "\\" + newNodeTitle;
                    e.Node.Expanded = true;
                    Directory.CreateDirectory(getpath(Request["pg"].ToString()) + "\\" + newNodeTitle);
                    createtree("");
                    getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
                }
                else
                {
                    string newNodeTitle = string.Format("New Folder", e.Node.ParentNode.Nodes.Count + 1);
                    e.Node.Nodes.Add(new RadTreeNode(newNodeTitle));
                    e.Node.Category = "Folder";
                    e.Node.ImageUrl = "/admin/images/folder.gif";
                    e.Node.ExpandedImageUrl = "/admin/images/folder.gif";
                    e.Node.ContextMenuID = "MainContextMenu";
                    e.Node.Value = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1) + "\\" + newNodeTitle;
                    e.Node.Expanded = true;
                    Directory.CreateDirectory(getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1) + "\\" + newNodeTitle);
                    createtree(getpath(Request["pg"].ToString()) + (RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1)).Replace("/", "\\"));
                    getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
                }
                break;

            case "Delete":
                
                break;

            case "Rename":

                if (RadTreeView1.SelectedNode != null)
                {
                    GC.Collect();
                    RadTreeNode nodeEdited = e.Node;
                    string oldtext = e.Node.Text;
                    string oldpath = e.Node.Value.Substring(0, e.Node.Value.LastIndexOf("\\") + 1);
                    string newText = e.Node.Text;

                    nodeEdited.Text = newText;

                    string newpath = nodeEdited.Value;
                    if (e.Node.Category == "Files")
                    {

                        getitemonserver(e.Node.Category, e.Node.Value, oldpath + newText);
                    }
                    else
                    {

                        getitemonserver(e.Node.Category, oldpath + oldtext, oldpath + newText);
                    }
                    System.IO.FileSystemWatcher mywatcher = new FileSystemWatcher(oldpath);
                    mywatcher.WaitForChanged(WatcherChangeTypes.All, 2000);
                    createtree(oldpath.Substring(0, oldpath.LastIndexOf("\\")));
                    getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
                }
                break;

        }
    }
  
    private RadTreeNode CloneNode(RadTreeNode original, string text)
    {
        RadTreeNode cloned = new RadTreeNode();
        cloned.Text = text;
        cloned.Font.Bold = original.Font.Bold;
        cloned.Font.Italic = original.Font.Italic;
        cloned.ImageUrl = original.ImageUrl;

        foreach (RadTreeNode node in original.Nodes)
        {
            cloned.Nodes.Add(CloneNode(node, original.Text));
        }
        return cloned;
    }
    StringBuilder sb = new StringBuilder();
    private void createtree(string name)
    {
        RadTreeView1.Nodes.Clear();
        string rootFolder = getpath(Request["pg"].ToString());

        RadTreeNode rootNode = new RadTreeNode(getmainfolder(Request["pg"].ToString()));
        rootNode.ImageUrl = "/admin/images/folder.gif";
        rootNode.ExpandedImageUrl = "/admin/images/folder.gif";
        rootNode.ContextMenuID = "RootContextMenu";
        rootNode.Category = "Folder";
        rootNode.Value = getpath(Request["pg"].ToString());
        rootNode.Expanded = true;
        RadTreeView1.Nodes.Add(rootNode);
        BindTreeToDirectory(rootFolder, rootNode, name);
    }
    protected void btnSize_Click(object sender, EventArgs e)
    {

        if (Session["autoresize"] != null)
        {

            createtree(getpath(Request["pg"].ToString()) + "/" + Session["autoresize"].ToString());
            autoresize.Style.Add("display", "block");
            ddCat.SelectedValue = Session["autoresize"].ToString();

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
       
        RadTreeNode n = RadTreeView1.FindNodeByValue(txtFile.Text);
        if (n.Category != "Folder")
        {
            string filed = "";
            int size = 0;

            string direc = txtFile.Text;
            string path = direc.Substring(0, direc.LastIndexOf("\\"));
            string fild = direc.Substring(path.Length);

            System.IO.FileInfo fi = new System.IO.FileInfo(direc);
            if (fi.Exists)
            {
                GC.Collect();
                fi.Attributes = FileAttributes.Normal;
                fi.Delete();
                createtree(path);
       
            }
        }
        else
        {
            
            string dir = txtFile.Text;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dir);
            di.Attributes = FileAttributes.Normal;
            if (di.Exists)
            {
                GC.Collect();
                deletefilesfrfolder(dir);
                createtree(dir.Substring(0, dir.LastIndexOf("\\")));
            }
        }
        Session["delete"] = null;
    }
    protected void btnSizeMa_Click(object sender, EventArgs e)
    {

        if (Session["manualresize"] != null)
        {

            createtree(getpath(Request["pg"].ToString()) + "/" + Session["manualresize"].ToString());
            manualresize.Style.Add("display", "block");
            
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["autoresize"] != null)
        {

            string sessionkey = Session["autoresize"].ToString().Replace("/", "\\");
            autoresize.Style.Add("display", "block");
            getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
            Panel2.Controls.Clear();
            Panel2.Controls.Add(new LiteralControl("<span style=\"color:green\">Your files have been created.<br/>We recommend to delete the source files if they are not needed anymore.</span>"));
            createtree(getpath(Request["pg"].ToString()) + sessionkey);
            Session["autoresize"] = null;

        }
        if (Session["manualresize"] != null)
        {

            string sessionkey = Session["manualresize"].ToString().Replace("/", "\\");
            sessionkey = sessionkey.Replace(txtroot.Text, "");
            string path = epicCMSLib.Navigation.SiteRoot + sessionkey.Replace("\\", "/");
            string file = path.Substring(path.LastIndexOf("/") + 1);
            image.InnerHtml = "<img  id=\"" + file + "\"" + "alt=" + "\"" + file + "\"" + "height=" + "\"" + tbheight.Text + "\"" + "width=" + "\"" + tbwidth.Text + "\"" + "src=\"" + path + "\"" + "/>";

            //image.AlternateText  = sessionkey;
            //image.Controls.Add();
            if (cbContstraint.Checked == true)
            {
                height.Style.Add("visibility", "hidden");
            }
            manual.Style.Add("display", "block");
            createtree(sessionkey.Substring(0, sessionkey.LastIndexOf("\\")));
            Session["manualresize"] = null;

        }
       
        if (!Page.IsPostBack)
        {
            if ((Session["autoresize"] == null) && (txtFile.Text.Length <= 0) && (Session["manualresize"] == null))
            {
                if (Session["upload"] == null)
                {
                    createtree("");
                }
                else 
                {
                    createtree(Session["upload"].ToString());
                    Session["upload"] = null;
                }
              
                tbheight.Text = "";
                tbThumb.Text = "";
                tbwidth.Text = "";
                txtFile.Text = "";

                if (Request["pg"].ToString() == "audio")
                {
                    sb.Append("<h2>Audio Administration</h2>");
                    MainContextMenu.Items.FindItemByValue("Resize").Visible = false;
                    ContextMenuFiles.Items.FindItemByValue("ResizeFile").Visible = false;
                }
                if (Request["pg"].ToString() == "image")
                {
                    sb.Append("<h2>Image Administration</h2>");
                    getfold(ref al, Server.MapPath("~/App_Uploads_Img/"));
                    getallfolders(ref al2, Server.MapPath("~/App_Uploads_Img/"));
                    txtFilePath.Text = Server.MapPath("~/App_Uploads_Img/").ToString();
                    ddCat.Attributes.Add("onchange", "return OnSelectedIndexChange();");
                    //Button5.Attributes.Add("onclientclick ", "updateDateKeyAutoResizeImages();");
                }
                else if (Request["pg"].ToString() == "docs")
                {
                    sb.Append("<h2>Document Administration</h2>");
                    MainContextMenu.Items.FindItemByValue("Resize").Visible = false;
                    ContextMenuFiles.Items.FindItemByValue("ResizeFile").Visible = false;
                }
                else if (Request["pg"].ToString() == "movie")
                {
                    sb.Append("<h2>Movie Administration</h2>");
                    MainContextMenu.Items.FindItemByValue("Resize").Visible = false;
                    ContextMenuFiles.Items.FindItemByValue("ResizeFile").Visible = false;
                }
                else if (Request["pg"].ToString() == "podcasts")
                {
                    sb.Append("<h2>Podcast Administration</h2>");
                    MainContextMenu.Items.FindItemByValue("Resize").Visible = false;
                    ContextMenuFiles.Items.FindItemByValue("ResizeFile").Visible = false;
                }
                PlaceHolder1.Controls.Add(new LiteralControl(sb.ToString()));
            }
        }

    }

    private string getpath(string path)
    {
        switch (path)
        {
            case "image":
                path = Server.MapPath("~/App_Uploads_Img/");
                break;

            case "audio":
                path = Server.MapPath("~/App_Uploads_Audio/");
                break;

            case "movie":
                path = Server.MapPath("~/App_Uploads_Movies/");
                break;

            case "docs":
                path = Server.MapPath("~/App_Uploads_Docs/");
                break;

            case "podcasts":
                path = Server.MapPath("~/App_Uploads_Podcasts/");
                break;
        }
        return path;
    }
    private string getmainfolder(string root)
    {
        switch (root)
        {
            case "image":
                root = "Images";
                break;

            case "audio":
                root = "Audio";
                break;

            case "movie":
                root = "Movies";
                break;

            case "docs":
                root = "Documents";
                break;

            case "podcasts":
                root = "Podcasts";
                break;
        }
        return root;
    }
    private string GetImageForExtension(string fileName)
    {
        string image = "File.gif";

        switch (Path.GetExtension(fileName).ToLower())
        {


            case ".html":
                image = "html.gif";
                break;


            case ".pdf":
                image = "ico_pdf.gif";
                break;

            case ".doc":
                image = "ico_word.gif";
                break;

            case ".xls":
                image = "ico_excel.gif";
                break;
            case ".zip":
                image = "ico_zip.gif";
                break;

            case ".mov":
                image = "ico_quicktime.gif";
                break;
            case ".flv":
                image = "ico_flv.gif";
                break;
            case ".mp3":
                image = "ico_mp3.gif";
                break;
            case ".wmv":
                image = "ico_flv.gif";
                break;

            case ".png":
            case ".bmp":
            case ".tif":
            case ".jpeg":
            case ".gif":
            case ".jpg":
                image = "gif.gif";
                break;

            case "":
                image = "folder.gif";
                break;
        }

        return image;
    }
    public bool checkifsubfolders(ref ArrayList alcheck, string dir)
    {
        bool found = false;

        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = dir;
            //string foldername = folder.Substring(appdir.Length);
            string foldername = folder;
            if ((!foldername.Contains("_svn")) || (!foldername.Contains("_svn")))
            {
                alcheck.Add(foldername);
            }

        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            checkifsubfolders(ref alcheck, dir2);
        }
        if (alcheck.Count > 0)
        {
            found = true;
        }
        return found;
    }
    
    public long GetFolderSize(string DirPath, bool IncludeSubFolders)
    {
        long lngFolderSize = 0;
        System.IO.DirectoryInfo objFolder;

        try
        {
            objFolder = new DirectoryInfo(DirPath);
            foreach (System.IO.FileInfo objFileInfo in objFolder.GetFiles())
            {
                lngFolderSize = (lngFolderSize + objFileInfo.Length);
            }
            if (IncludeSubFolders)
            {
                foreach (System.IO.DirectoryInfo objSubFolder in objFolder.GetDirectories())
                {
                    lngFolderSize = (lngFolderSize + GetFolderSize(objSubFolder.FullName, IncludeSubFolders));
                }
            }
        }
        catch
        {

        }
        return lngFolderSize;
    }

    public void deletefilesfrfolder(string del_directory)
    {
        string[] mainfiles = Directory.GetFiles(del_directory);
        if (mainfiles.Length > 0)
        {
            foreach (string mainfile in mainfiles)
            {
                FileInfo fi = new FileInfo(mainfile);
                fi.Attributes = FileAttributes.Normal;
                fi.Delete();
            }
        }
        string[] folders = Directory.GetDirectories(del_directory);
        if (folders.Length > 0)
        {
            foreach (string folder in folders)
            {
                deletefilesfrfolder(folder);
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }
            }
        }
        Directory.Delete(del_directory, true);
    }
   
    
    private void BindResults()
    {
        if (RadUpload1.UploadedFiles.Count > 0)
        {

            reportResults.Visible = true;
            reportResults.DataSource = RadUpload1.UploadedFiles;
            reportResults.DataBind();
        }
        else
        {

            reportResults.Visible = false;
        }
    }

    protected void ButtonSubmit1_Click(object sender, EventArgs e)
    {
        if (RadTreeView1.SelectedNode != null)
        {
            string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

            DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

            if (RadUpload1.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadUpload1.UploadedFiles)
                {
                    file.SaveAs(targetFolder + "/" + file.GetName(), true);
                    
                    if (RadTreeView1.SelectedNode != null)
                    {
                        RadTreeNode currentNode = RadTreeView1.SelectedNode;
                        RadTreeNode newNode = new RadTreeNode(file.GetName());
                        newNode.ContextMenuID = "ContextMenuFiles";
                        newNode.Category = "Files";
                        newNode.Value = targetFolder + "/" + file.GetName();
                        newNode.ImageUrl = "/admin/images/" + GetImageForExtension(file.GetName().Substring(file.GetName().IndexOf(".")));
                        newNode.ExpandedImageUrl = "/admin/images/" + GetImageForExtension(file.GetName().Substring(file.GetName().IndexOf(".")));
                        currentNode.Nodes.Add(newNode);
                        Session["upload"] = currentNode.Value;
                    }
                    GC.Collect();
                }
                Response.Redirect(Request.Url.ToString());
            }
            
            //Session["upload"] = targetFolder;
        }
        
    }


    protected void RadUpload1_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
    {
        int counter = 1;

        UploadedFile file = e.UploadedFile;

        string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

        string targetFileName = Path.Combine(targetFolder,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while (System.IO.File.Exists(targetFileName))
        {
            counter++;
            targetFileName = Path.Combine(targetFolder,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
        GC.Collect();
        
    }


    private void getfold(ref ArrayList al, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if (!foldername.Contains("_svn") && (!foldername.Contains(".svn")))
            {
                if (!foldername.Contains("toresize"))
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);

                    if (files.Length > 0)
                    {
                        al.Add(foldername);
                    }
                }
            }
        }
        if (!dir.Contains("_svn") && (!dir.Contains(".svn")))
        {
            string[] dirs = Directory.GetDirectories(dir);
            foreach (string dir2 in dirs)
            {

                getfold(ref al, dir2);
            }
        }
        if (al.Count > 0)
        {
            ddCat.DataSource = al;
            ddCat.DataBind();

            ddCat.Items.Insert(0, new ListItem("- Select a Folder -"));
            ddCat.SelectedIndex = 0;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel2.Controls.Clear();
        Panel2.Controls.Add(new LiteralControl("Files will be deleted. This may take a few minutes..."));

        System.Threading.Thread.Sleep(af.Count * 1000);
        string path = (Server.MapPath("~/App_Uploads_Img/") + ddCat.SelectedValue);
        if (!ddCat.SelectedValue.Contains("- Select a Folder -"))
        {

            string[] mainfiles = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/" + ddCat.SelectedValue));
            if (mainfiles.Length > 0)
            {
                foreach (string mainfile in mainfiles)
                {
                    FileInfo fi = new FileInfo(mainfile);
                    fi.Attributes = FileAttributes.Normal;
                    fi.Delete();
                }
            }

        }
        else 
        {
            string[] mainfiles = Directory.GetFiles(RadTreeView1.SelectedNode.Value);
            if (mainfiles.Length > 0)
            {
                foreach (string mainfile in mainfiles)
                {
                    FileInfo fi = new FileInfo(mainfile);
                    fi.Attributes = FileAttributes.Normal;
                    fi.Delete();
                }
            }
        }
        Thread.Sleep(2000);
         //Panel2.Controls.Clear();
         Panel2.Controls.Add(new LiteralControl("<span style=\"color:green\"><br/>Files have been deleted.</span>"));
         //createtree(Session["delete"].ToString().Replace("/", "\\"));
         //Session["delete"] = null;
        
         autoresize.Style.Add("visibility", "hidden");
         createtree(RadTreeView1.SelectedNode.Value);
    }
    private void getallfolders(ref ArrayList al2, string dir)
    {
        string[] folders = Directory.GetDirectories(dir);
        foreach (string folder in folders)
        {
            string appdir = Server.MapPath("~/App_Uploads_Img/");
            string foldername = folder.Substring(appdir.Length);

            if (!foldername.Contains("_svn") && (!foldername.Contains(".svn")))
            {
                if (!foldername.Contains("toresize"))
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/App_Uploads_Img/") + foldername);
                    if (files.Length > 0)
                    {

                        al2.Add(foldername);
                    }

                }
            }
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (string dir2 in dirs)
        {
            getallfolders(ref al2, dir2);
        }

        ddSavePath.DataSource = al2;
        ddSavePath.DataBind();

        ddSavePath.Items.Insert(0, new ListItem("- Select a Folder -"));
        ddSavePath.SelectedIndex = 0;
    }

    protected void ButtonSubmit2_Click(object sender, EventArgs e)
    {
        if (RadTreeView1.SelectedNode != null)
        {
            string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

            DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

            if (RadUpload2.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadUpload2.UploadedFiles)
                {
                    file.SaveAs(targetFolder + "/" + file.GetName(), true);
                    if (RadTreeView1.SelectedNode != null)
                    {
                        RadTreeNode currentNode = RadTreeView1.SelectedNode;
                        RadTreeNode newNode = new RadTreeNode(file.GetName());
                        newNode.ContextMenuID = "ContextMenuFiles";
                        newNode.Category = "Files";
                        newNode.Value = targetFolder + "/" + file.GetName();
                        newNode.ImageUrl = "/admin/images/" + GetImageForExtension(file.GetName().Substring(file.GetName().IndexOf(".")));
                        newNode.ExpandedImageUrl = "/admin/images/" + GetImageForExtension(file.GetName().Substring(file.GetName().IndexOf(".")));
                        currentNode.Nodes.Add(newNode);
                        Session["upload"] = currentNode.Value;
                    }
                    GC.Collect();

                }
                Response.Redirect(Request.Url.ToString());
            }
            //Session["upload"] = targetFolder;

        }
    }


    protected void RadUpload2_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
    {
        int counter = 1;

        UploadedFile file = e.UploadedFile;

        string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

        string targetFileName = Path.Combine(targetFolder,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while (System.IO.File.Exists(targetFileName))
        {
            counter++;
            targetFileName = Path.Combine(targetFolder,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
    }

    protected void ButtonSubmit4_Click(object sender, EventArgs e)
    {
        string faudio = "";
        if (RadTreeView1.SelectedNode != null)
        {
            string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

            DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

            if (RadUpload4.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadUpload4.UploadedFiles)
                {
                    if (file.FileName.Contains("'"))
                    {
                        faudio = file.FileName.Replace("'", "");
                    }
                    else
                    {
                        faudio = file.FileName;
                    }
                    file.SaveAs(targetFolder + "/" + faudio, true);
                    if (RadTreeView1.SelectedNode != null)
                    {
                        RadTreeNode currentNode = RadTreeView1.SelectedNode;
                        RadTreeNode newNode = new RadTreeNode(faudio);
                        newNode.ContextMenuID = "ContextMenuFiles";
                        newNode.Category = "Files";
                        newNode.Value = targetFolder + "/" + faudio;
                        newNode.ImageUrl = "/admin/images/" + GetImageForExtension(faudio.Substring(faudio.IndexOf(".")));
                        newNode.ExpandedImageUrl = "/admin/images/" + GetImageForExtension(faudio.Substring(faudio.IndexOf(".")));
                        currentNode.Nodes.Add(newNode);
                        Session["upload"] = currentNode.Value;
                    }
                    GC.Collect();

                }
                Response.Redirect(Request.Url.ToString());
            }
            //Session["upload"] = targetFolder;
        }
    }
    protected void RadUpload4_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
    {
        int counter = 1;

        UploadedFile file = e.UploadedFile;

        string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

        string targetFileName = Path.Combine(targetFolder,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while (System.IO.File.Exists(targetFileName))
        {
            counter++;
            targetFileName = Path.Combine(targetFolder,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
    }

    protected void ButtonSubmit60_Click(object sender, EventArgs e)
    {
        string fpodcast = "";
        if (RadTreeView1.SelectedNode != null)
        {
            string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

            DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

            if (RadUpload60.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadUpload60.UploadedFiles)
                {
                    if (file.FileName.Contains("'"))
                    {
                        fpodcast = file.FileName.Replace("'", "");
                    }
                    else
                    {
                        fpodcast = file.FileName;
                    }
                    file.SaveAs(targetFolder + "/" + fpodcast, true);
                    if (RadTreeView1.SelectedNode != null)
                    {
                        RadTreeNode currentNode = RadTreeView1.SelectedNode;
                        RadTreeNode newNode = new RadTreeNode(fpodcast);
                        newNode.ContextMenuID = "ContextMenuFiles";
                        newNode.Category = "Files";
                        newNode.Value = targetFolder + "/" + fpodcast;
                        newNode.ImageUrl = "/admin/images/" + GetImageForExtension(fpodcast.Substring(fpodcast.IndexOf(".")));
                        newNode.ExpandedImageUrl = "/admin/images/" + GetImageForExtension(fpodcast.Substring(fpodcast.IndexOf(".")));
                        currentNode.Nodes.Add(newNode);
                        Session["upload"] = currentNode.Value;
                    }
                    GC.Collect();

                }
                Response.Redirect(Request.Url.ToString());
            }
            //Session["upload"] = targetFolder;
        }
    }
    protected void RadUpload60_FileExists(object sender, Telerik.Web.UI.Upload.UploadedFileEventArgs e)
    {
        int counter = 1;

        UploadedFile file = e.UploadedFile;

        string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

        string targetFileName = Path.Combine(targetFolder,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while (System.IO.File.Exists(targetFileName))
        {
            counter++;
            targetFileName = Path.Combine(targetFolder,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
    }
}