using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;


public partial class converter : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    // calculate number of pages
    public int getNumberOfPdfPages(string fileName)
    {
        using (StreamReader sr = new StreamReader(File.OpenRead(fileName)))
        {
            Regex regex = new Regex(@"/Type\s*/Page[^s]");
            MatchCollection matches = regex.Matches(sr.ReadToEnd());
            int cnt = matches.Count;
            return cnt;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string flnm = FileUpload1.FileName;

        FileUpload1.SaveAs(Server.MapPath("~/PDF/")+flnm);
        string filnm =Server.MapPath("~/PDF/")+flnm;
        int count= getNumberOfPdfPages(filnm);
        //for (int i = 1; i <= count; i++)
        //{
        int i = 0;
            convertToswf(filnm, i);
       // }
    }

    public void convertToswf(string filnm,int cnt)
   {
      
       int pageNumber = cnt;
       string fileName = filnm;

       System.Diagnostics.Process p = new System.Diagnostics.Process();

       p.StartInfo.UseShellExecute = false;

       p.StartInfo.RedirectStandardOutput = true;

       p.StartInfo.CreateNoWindow = true;

       p.StartInfo.RedirectStandardError = true;

       p.StartInfo.WorkingDirectory = HttpContext.Current.Server.MapPath("~");

       p.StartInfo.FileName = HttpContext.Current.Server.MapPath("~/pdf2swf/PDF2SWF.exe");

      // p.StartInfo.Arguments = "-F " + "\"" + HttpContext.Current.Server.MapPath("~/PDF2SWF/FONTS") + "\"" + " -p " + pageNumber + " " + fileName + " -o " + fileName + pageNumber + ".swf";

       //p.StartInfo.Arguments = " \"" + fileName +"\" -b \""+ "\" -o \"" + fileName + ".swf\"";
        p.StartInfo.Arguments = " \"" + fileName + "\" -t \""+ "\" -o \"" + fileName + ".swf";
      // p.StartInfo.Arguments = " \"" + fileName + "\"" + " -o " + fileName + ".swf";
       
       ///.p.StartInfo.Arguments = fileName + "\" "-t -o " + fileName + ".swf\"";
       //Start the process

       p.Start();
       p.WaitForExit();
       p.Close();
    }
}