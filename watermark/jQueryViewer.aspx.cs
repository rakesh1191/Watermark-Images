using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class jQueryViewer : System.Web.UI.Page
{
    public string swfFileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        swfFileName = "sc.swf";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
            string Path = GetUplaodImagePhysicalPath();
            DirectoryInfo dirUploadImage = new DirectoryInfo(Path);
            if (dirUploadImage.Exists == false)
            {
                dirUploadImage.Create();
            }
            string fileUrl = Path + fUpload.PostedFile.FileName;
            fUpload.PostedFile.SaveAs(fileUrl);
            swfFileName = "image/" + fUpload.PostedFile.FileName;
        
    }

    private bool IsVaildFile()
    {
        string swfExt = System.IO.Path.GetExtension(fUpload.PostedFile.FileName);
        switch (swfExt)
        {
            case ".swf":
                return true;
            default:
                {
                    //lblMsg.Text = "Please select only swf file.";
                    return false;
                }
        }
    }
    string GetUplaodImagePhysicalPath()
    {
        return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "image\\";
    }
}