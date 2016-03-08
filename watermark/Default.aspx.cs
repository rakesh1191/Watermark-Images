using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

using System.IO;
using Ionic.Zip;
using System.Windows.Forms;




public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string path = Server.MapPath("~/input/");
                string saveurl = Server.MapPath("~/Converted/");
                Directory.Delete("~/input/");
                foreach (string file in Directory.EnumerateFiles(path, "*.jpg"))
                {
                    File.Delete(file);

                }
                foreach (string file in Directory.EnumerateFiles(saveurl, "*.jpg"))
                {
                    File.Delete(file);
                }
            }
            catch (Exception r) { }
        }

    }
    PictureBox picContainer = new PictureBox();

    System.Drawing.Image img;
    ImageCodecInfo myImageCodecInfo;
    System.Drawing.Imaging.Encoder myEncoder;
    EncoderParameter myEncoderParameter;
    EncoderParameters myEncoderParameters;
    System.Drawing.Color myWatermarkColor;
    System.Drawing.Font myFont;

    protected void Button1_Click(object sender, EventArgs e)
    {


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try { 
        int nm = 1;
        string d = ViewState["fileName"].ToString();
        String extName = ViewState["extName"].ToString();
        string path = Server.MapPath("~/input/" + d);
        foreach (string file in Directory.EnumerateFiles(path, "*." + extName))
        {

            watermark(file, nm);
            nm++;

        }
        //MessageBox.Show(" saved.", "File Save");
        review();
        Btn_Zip.Visible = true;
        }
        catch (Exception ere) { }
    }

    public void review()
    {
        String extName = ViewState["extName"].ToString();
        string d = ViewState["fileName"].ToString();
        Image1.ImageUrl = "~/Converted/" + d + "/1." + extName;


    }

    public void watermark(string flnm, int nm1)
    {
        String extName = ViewState["extName"].ToString();
        string d = ViewState["fileName"].ToString();
        Directory.CreateDirectory(Server.MapPath("~/Converted/") + d);
        int fntsize = 30;
        try
        {
            fntsize = Convert.ToInt32(TextBox1.Text);
        }
        catch (Exception e) { }
        finally
        {

        }
        //int nm = 1;
        string name = nm1.ToString();
        //string CurrentFile = @"D:\imageViwer\WatermarkNew\input\w.jpg";
        string CurrentFile = flnm;
        // Update the applicaton by reloading the image
        picContainer.Image = System.Drawing.Image.FromFile(CurrentFile);

        int opac = 80;
        ////myFont = fontDialog1.Font;
        myWatermarkColor = Color.Gray;
        //// txtWaterMark.Font = new FontFamily("Consolas");
        txtWaterMark.ForeColor = Color.Gray;

        // Get a graphics context
        Graphics g = Graphics.FromImage(picContainer.Image);

        // Create a solid brush to write the watermark text on the image
        Brush myBrush = new SolidBrush(Color.FromArgb(opac, myWatermarkColor));

        // Calculate the size of the text
        Font f = new Font("Serif", fntsize);
        SizeF sz = g.MeasureString(txtWaterMark.Text, f);

        // Creae a copy of variables to keep track of the
        // drawing position (X,Y)
        int X;
        int Y;

        // Set the drawing position based on the users
        // selection of placing the text at the bottom or
        // top of the image
        ////if (optTop.Checked == true)
        ////{
        X = (int)(picContainer.Image.Width / 4);
        Y = (int)(picContainer.Image.Height / 8);
        ////    X = 5;
        ////    Y = 300;
        ////   new Point((control.Width / 2) - (image.Width /2),(control.Height / 2) - (image.Height / 2));
        ////}
        ////else
        ////{
        ////    X = (int)(picContainer.Image.Width - sz.Width) / 2;
        ////    Y = (int)(picContainer.Image.Height - sz.Height);
        ////}
        // Point p = new Point(100, 20);
        Point p = new Point(X, Y);
        //p.Offset(34, 200);
        // draw the water mark text

        //
        //centre  X = (int)(picContainer.Image.Width/5); Y = (int)(picContainer.Image.Height / 2);
        //curve X = (int)(picContainer.Image.Width/3);  Y = (int)(picContainer.Image.Height / 9); g.RotateTransform(45);
        //
        //
        //


        g.RotateTransform(35);
        g.DrawString(txtWaterMark.Text, f, myBrush, p);




        ////////////////////////////////////////////////////////////////////


        //try
        //{

        //get the extension to figure out how to limit the save
        //option to the current image file type
        ////string strExt;
        ////strExt = System.IO.Path.GetExtension(CurrentFile);
        ////strExt = strExt.ToUpper();
        ////strExt = strExt.Remove(0, 1);

        //if the current image is, for example, a gif, only
        //allow the user to save the file with the watermark
        //as a gif
        ////SaveFileDialog1.Title = "Save File";
        ////SaveFileDialog1.DefaultExt = strExt;
        ////SaveFileDialog1.Filter = strExt + " Image Files|*." + strExt;
        ////SaveFileDialog1.FilterIndex = 1;

        ////if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
        ////{
        ////    if (SaveFileDialog1.FileName == "")
        ////    {
        ////        return;
        ////    }
        ////    else
        ////    {
        string saveurl = Server.MapPath("~/Converted/" + d + "/");
        //save the file with the name supplied by the user
        picContainer.Image.Save(saveurl + name + "." + extName);
        ////}
        picContainer.Dispose();
        //update the current image file to point to the newly saved
        //image
        ////CurrentFile = SaveFileDialog1.FileName;
        ////this.Text = "Watermark Utility: " + CurrentFile;
        // MessageBox.Show(CurrentFile.ToString() + " saved.", "File Save");
        ////    }
        ////    else
        ////    {
        ////        MessageBox.Show("The save file request was cancelled by user.", "Save Cancelled");
        ////    }
        ////}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message.ToString(), "Image Save Error");
        //}

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string oldmark = txtWaterMark.Text;
        string newmark = " " + oldmark;
        txtWaterMark.Text = newmark.ToString();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        String extName = ViewState["extName"].ToString();
        int nm = 1;
        string d = ViewState["fileName"].ToString();
        string path = Server.MapPath("~/input/" + d);
        foreach (string file in Directory.EnumerateFiles(path, "*." + extName))
        {

            watermark(file, nm);
            nm++;

        }
        //MessageBox.Show(" saved.", "File Save");
        review();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string newmark1 = "";
        string oldmark = txtWaterMark.Text;
        newmark1 = oldmark.Remove(1, 1);
        txtWaterMark.Text = newmark1.ToString();

    }
    protected void randomFIleName()
    {
        Random r = new Random();
        int no = r.Next(500, 100000);
        string d = "new" + no.ToString();
        ViewState["fileName"] = d;
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        try { 
        randomFIleName();
        int nm = 1;
        String d = ViewState["fileName"].ToString();
        String[] extnm = FileUpload1.FileName.Split('.');
        String h = extnm[1];
        ViewState["extName"] = h;
        if (FileUpload1.HasFile)
        {
            Directory.CreateDirectory(Server.MapPath("~/input/") + d);
            //foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
            //{
            // Directory.CreateDirectory(Server.MapPath("~/input/")+uploadedFile.FileName);
            // uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/input/"+d),uploadedFile.FileName)); 
            //}
            FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("~/input/" + d), FileUpload1.FileName));

        }

        txtWaterMark.Visible = true;
        Button2.Visible = true;
        TextBox1.Visible = true;
        Button3.Visible = true;
        Button4.Visible = true;
        Button5.Visible = true;
            
            //clear previous image
            Image1.ImageUrl = "";


        }
        catch (Exception ew) {
            //System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>");            
            string script = "alert(\"Upload File!!\");";
            ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
        }
    }
    protected void Btn_Zip_Click(object sender, EventArgs e)
    {
        string d = ViewState["fileName"].ToString();
        try
        {
            string pathname = Server.MapPath("~/Converted/" + d);
            string[] filename = Directory.GetFiles(pathname);
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFiles(filename, "file");
                // zip.Save(Server.MapPath("~/Converted/watermarked.zip"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + "watermarked.zip");
                zip.Save(Response.OutputStream);
                Response.End();
                // lbltxt.Text = "Zip File Created";
            }
        }
        catch (Exception ex)
        {
            //lbltxt.Text = ex.Message;
        }


    }
}
