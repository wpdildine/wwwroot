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
using Telerik.WebControls;
using System.IO;
using System.Security.AccessControl;
public partial class admin_controls_filebrowser : System.Web.UI.UserControl
{
    ArrayList al = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        //RadTreeView1.NodeDrop += new RadTreeView.RadTreeViewEventHandler(RadTreeView1_NodeDrop);
        if (!IsPostBack)
        {

            //if (Request["pg"] == "image")
            //{
            Rootfolder(getmainfolder(Request["pg"].ToString()), getpath(Request["pg"].ToString()));
      
        }
        if (Request["pg"] == "image")
        {
           //RadUpload1.AllowedFileExtensions=new string[]{".jpeg,.jpg,.gif,.bmp,.tif,.png"};
        }
        else if (Request["pg"] == "movie")
        {
            //RadUpload1.AllowedFileExtensions=new string[]{".mpeg,.mov"};
        }
        else if (Request["pg"] == "docs")
        {
            //RadUpload1.AllowedFileExtensions = new string[] { ".doc,.pdf,.xls,.csv" };
        }


    }
   
    private string getpath(string path)
    {
        switch (path)
        {
            case "image":
                path = Server.MapPath("~/App_Uploads_Img/");
                break;

            case "movie":
                path = Server.MapPath("~/App_Uploads_Movies/");
                break;

            case "docs":
                path = Server.MapPath("~/App_Uploads_Docs/");
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

            case "movie":
                root = "Movies";
                break;

            case "docs":
                root = "Documents";
                break;
        }
        return root;
    }
    private void Rootfolder(string mainfoldername,string folder)
    {
        RadTreeNode rootNode1 = new RadTreeNode(mainfoldername);
        rootNode1.ImageUrl = "../RadControls/Grid/Skins/Default2006/folder.gif";
        rootNode1.Expanded = true;
        rootNode1.Category = "Folder";
        rootNode1.Value = folder;
        rootNode1.ContextMenuName = "treeContextMenu";
        RadTreeView1.Nodes.Add(rootNode1);
        LoadTreeViewImages(folder, rootNode1.Nodes);
        checkfiles(folder, rootNode1.Nodes);
    }
    private void LoadTreeViewImages(string folder, RadTreeNodeCollection maincollection)
    {


        string[] dirs = Directory.GetDirectories(folder);
        foreach (string path in dirs)
        {
            if (!path.Contains("_svn") && !path.Contains(".svn"))
            {
                string[] parts = path.Split('\\');
                string name = parts[parts.Length - 1];
                RadTreeNode rootNode = new RadTreeNode(name);
                rootNode.ImageUrl = "../RadControls/Grid/Skins/Default2006/folder.gif";
                rootNode.Category = "Folder";
                rootNode.Value = folder;
                rootNode.ContextMenuName = "treeContextMenu";
                maincollection.Add(rootNode);
                checkfiles(path, rootNode.Nodes);

                GetFileList(path, rootNode.Nodes);

               // BindDirectory(path, rootNode.Nodes);
            }
        }

    }
   
    private void GetFileList(string directory, RadTreeNodeCollection collection)
    {
       
        if (directory != string.Empty)
        {

            DirectoryInfo dir = new DirectoryInfo(directory);

            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                if (!subDir.FullName.Contains("_svn") && !subDir.FullName.Contains(".svn"))
                {
                    RadTreeNode node = new RadTreeNode(subDir.Name);
                    node.ImageUrl = "../RadControls/Grid/Skins/Default2006/folder.gif";
                    node.Value = subDir.FullName;
                    node.ContextMenuName = "treeContextMenu";
                    node.Category = "Folder";
                    collection.Add(node);
                    GetFileList(subDir.FullName, node.Nodes);
                    checkfiles(subDir.FullName, node.Nodes);

                }
            }

            //foreach (FileInfo file in dir.GetFiles())
            //{
            //    if (!file.FullName.Contains("_svn") && !file.FullName.Contains(".svn"))
            //    {
            //        RadTreeNode node = new RadTreeNode(file.Name);
            //        node.ImageUrl = "../RadControls/Grid/Skins/Default2006/" + GetImageForExtension(file.FullName.Substring(file.FullName.IndexOf(".")));
            //        node.Value = file.FullName;
            //        node.ContextMenuName = "Folder";
            //        node.Category = "Folder";
            //        collection.Add(node);
            //    }
            //}
        }


    }

    private void checkfiles(string directory, RadTreeNodeCollection collection)
    {

        if (directory != string.Empty)
        {

            DirectoryInfo dir = new DirectoryInfo(directory);
            foreach (FileInfo file in dir.GetFiles())
            {
                if (!file.FullName.Contains("_svn") && !file.FullName.Contains(".svn"))
                {
                    RadTreeNode node = new RadTreeNode(file.Name);
                    node.ImageUrl = "../RadControls/Grid/Skins/Default2006/" + GetImageForExtension(file.FullName.Substring(file.FullName.IndexOf(".")));
                    node.Value = file.FullName;
                    node.ContextMenuName = "treeContextMenu";
                    node.Category = "Files";
                    collection.Add(node);
                }
            }
        }


    }
    private string GetImageForExtension(string fileName)
    {
        string image = "File.gif";

        switch (Path.GetExtension(fileName))
        {
           

            case ".html":
                image = "html.gif";
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
    protected void RadTreeView1_NodeEdit(object o, RadTreeNodeEventArgs e)
    {
        RadTreeNode nodeEdited = e.NodeEdited;
        string oldtext = e.NodeEdited.Text;
        string oldpath = e.NodeEdited.Value.Substring(0,e.NodeEdited.Value.LastIndexOf("\\")+1);
        string newText = e.NodeEdited.Text;

        nodeEdited.Text = newText;
   
        string newpath = nodeEdited.Value;
        if (e.NodeEdited.Category == "Files")
        {
            getitemonserver(e.NodeEdited.Category, e.NodeEdited.Value, oldpath + newText);
        }
        else { getitemonserver(e.NodeEdited.Category, oldpath + oldtext, oldpath + newText); }
      

    }
    private void getitemonserver(string category,string item, string text)
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
                    string account =System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    dSecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.FullControl, AccessControlType.Allow));
                    Directory.SetAccessControl(item, dSecurity);
                    System.IO.Directory.Move(item, text);
                }
            }

  
       
    }
    protected void RadTreeView1_NodeDrop(object o, RadTreeNodeEventArgs e)
    {
        // Fetch event data
        RadTreeNode sourceNode = e.SourceDragNode;
        RadTreeNode destNode = e.DestDragNode;

        string path = e.DestDragNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1);
        if (e.SourceDragNode.Category == "Files")
        {
            if (System.IO.File.Exists(e.SourceDragNode.Value))
            {
                System.IO.File.Move(e.SourceDragNode.Value, e.DestDragNode.Value + "\\" + e.SourceDragNode.Text);
            }
        }
        else
        {
            if (System.IO.Directory.Exists(e.SourceDragNode.Value))
            {
                System.IO.Directory.Move(e.SourceDragNode.Value, e.DestDragNode.Value + "\\" + e.SourceDragNode.Text);
            }
            //getitemonserver(e.SourceDragNode.Category, e.SourceDragNode.Value, e.DestDragNode.Value + path + "\\" + e.SourceDragNode.Text); 
        }

        // Swap nodes in tree.
        if (!sourceNode.IsAncestorOf(destNode))
        {
            sourceNode.Parent.Selected = true;
            sourceNode.Owner.Nodes.Remove(sourceNode);
            destNode.Nodes.Add(sourceNode);
        }

        // Expand destination node to see result of swap immediately.
        destNode.ExpandMode = ExpandMode.ServerSide;
        destNode.Expanded = true;


    }

    protected void RadTreeView1_NodeExpand(object o, RadTreeNodeEventArgs e)
    {
        //if (e.NodeClicked.Nodes.Count == 0)
        //{
        //    //BindDirectory(e.NodeClicked.Value, e.NodeClicked.Nodes);
        //}
    }
    public RadTreeNode copiedTreeviewItem
    {
        get
        {
            RadTreeNode item = new RadTreeNode();
            if (ViewState["copiedTreeviewItem_name"] == null)
            {
                item.Text = string.Empty;
            }
            else
            {
                item.Text = (string)ViewState["copiedTreeviewItem_name"];
                item.Value = (string)ViewState["copiedTreeviewItem_value"];
                item.ImageUrl = (string)ViewState["copiedTreeviewItem_imageurl"];
            }

            return item;
        }
        set
        {
            ViewState["copiedTreeviewItem_name"] = ((RadTreeNode)value).Text;
            ViewState["copiedTreeviewItem_value"] = ((RadTreeNode)value).Value;
            ViewState["copiedTreeviewItem_imageurl"] = ((RadTreeNode)value).ImageUrl;
        }
    }
    
    protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
    {
        switch (e.Item.Text)
        {
            case "New Item":
                if (RadTreeView1.SelectedNode != null)
                {
                    RadTreeNode currentNode = RadTreeView1.SelectedNode;
                    RadTreeNode newNode = new RadTreeNode("new item");
                    newNode.ContextMenuName = "treeContextMenu";
                    newNode.ImageUrl = "../RadControls/Grid/Skins/Default2006/folder.gif";
                    newNode.ImageExpandedUrl = "../RadControls/Grid/Skins/Default2006/folder.gif";
                    currentNode.Nodes.Add(newNode);
                    currentNode.Expanded = true;
                    currentNode.Selected = false;
                    currentNode.Nodes.FindNodeByText("new item").Selected = true;
                    Directory.CreateDirectory(getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length+1) + "\\" + newNode.Text);
                   
                }
                break;

            case "Delete Item":
                if ((RadTreeView1.SelectedNode != null) && !(RadTreeView1.SelectedNode.Level == 0))
                {
                    //RadTreeNode parentNode = RadTreeView1.SelectedNode.Parent;
                    if (RadTreeView1.SelectedNode.Category == "Folder")
                    {
                        deletefilesfromfolder(getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\"));
                    }
                    else 
                    {
                        File.Delete(getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length+1).Replace("/","\\"));
                    }
                    //RadTreeView1.SelectedNode.Parent.Co.Remove(RadTreeView1.SelectedNode);
                    
                  
                }
                break;

        }
    }
    public void deletefilesfromfolder(string del_directory)
    {


        DirectoryInfo diMain = new DirectoryInfo(del_directory);

        DirectoryInfo[] diChildren = diMain.GetDirectories();
        //Directory del;
        int nCnt;

        for (nCnt = 0; nCnt <= diChildren.Length-1; nCnt++)
        {
            Directory.Delete(del_directory + "\\" + Convert.ToString(diChildren[nCnt]), true);

        }
        Directory.Delete(del_directory , true);
    }
    public void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        string arg = e.Argument;
        // your custom server side code here 
    } 


    //private void BindResults()
    //{
    //    if (RadUpload1.UploadedFiles.Count > 0)
    //    {

    //        reportResults.Visible = true;
    //        reportResults.DataSource = RadUpload1.UploadedFiles;
    //        reportResults.DataBind();
    //    }
    //    else
    //    {

    //        reportResults.Visible = false;
    //    }
    //}

   protected void ButtonSubmit_Click(object sender, EventArgs e)
 {
    //    if (RadTreeView1.SelectedNode != null)
    //    {
    //        string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

    //        DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

    //        if (RadUpload1.UploadedFiles.Count > 0)
    //        {
    //            foreach (UploadedFile file in RadUpload1.UploadedFiles)
    //            {

    //                file.SaveAs(targetFolder + "/" + file.GetName(), true);
    //                if (RadTreeView1.SelectedNode != null)
    //                {
    //                    RadTreeNode currentNode = RadTreeView1.SelectedNode;
    //                    RadTreeNode newNode = new RadTreeNode(file.GetName());
    //                    newNode.ContextMenuName = "treeContextMenu";
    //                    newNode.ImageUrl = "../RadControls/Grid/Skins/Default2006/" + GetImageForExtension(file.GetName().Substring(file.GetName().IndexOf(".")));
    //                    newNode.ImageExpandedUrl = "../RadControls/Grid/Skins/Default2006/" + GetImageForExtension(file.GetName().Substring(file.GetName().IndexOf(".")));
    //                    currentNode.Nodes.Add(newNode);
    //                    currentNode.Expanded = true;
    //                    currentNode.Selected = false;
    //                    currentNode.Nodes.FindNodeByText(file.GetName()).Selected = true;

    //                }

    //            }
    //        }

    //        BindResults();
    //    }
 }
    //private void RadUpload1_FileExists(object sender, Telerik.WebControls.UploadedFileEventArgs e)
    //{
    //    int counter = 1;

    //    UploadedFile file = e.UploadedFile;

    //    string targetFolder = getpath(Request["pg"].ToString()) + RadTreeView1.SelectedNode.FullPath.Substring(getmainfolder(Request["pg"].ToString()).Length + 1).Replace("/", "\\");

    //    string targetFileName = Path.Combine(targetFolder,
    //        file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

    //    while (System.IO.File.Exists(targetFileName))
    //    {
    //        counter++;
    //        targetFileName = Path.Combine(targetFolder,
    //            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
    //    }

    //    file.SaveAs(targetFileName);
    //}
}