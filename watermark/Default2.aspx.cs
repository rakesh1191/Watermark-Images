using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    ShockwaveFlashObjects.ShockwaveFlash shflsh;
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        shflsh = new ShockwaveFlashObjects.ShockwaveFlash();
        shflsh.Movie=@"D:\imageViwer\PDFtoSWF\image\l-diversity algo.pdf.swf";
        shflsh.Play();
       
    }
}