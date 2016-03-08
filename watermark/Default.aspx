<%@ Page Title="Free Image Watermark | Free Online Converter" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link rel="icon" href="http://onlineconvert-free.com/favicon.jpg" type="image/x-icon" />
 <meta name="keywords" content="watermark, onlineconvert-free, online convert free, convert online,onlineconvert, converter, free, online-converter,online,image-watermark,images,watermark-pic,pics,watermark,image,pic,pics,watermark software,watermark photos,free watermark software,watermarks,watermarking photos,watermark paper,photo watermark, write words on picture, edit images">
  <meta name="description" content="Free online image watermark tool. Convert Image to watermarked image with this free online converter. Upload file and download instantly as zip file. ">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 251px;
        }
        .style3
        {
            width: 251px;
            text-align: center;
        }
    .auto-style1
    {
        width: 251px;
        height: 52px;
    }
    .auto-style2
    {
        height: 52px;
    }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="style1">
    <tr>
        <td class="auto-style1">
            </td>
        <td class="auto-style2">
            <asp:FileUpload ID="FileUpload1" runat="server"  multiple="multiple"/>
            <br />
            <asp:Button ID="Button6" runat="server" Text="Upload" OnClick="Button6_Click" class='btn btn-primary'/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Btn_Zip" runat="server" ForeColor="#009900" OnClick="Btn_Zip_Click" Text="Download ZIP" Visible="False"  class="btn btn-default"/>
        </td>
        <td class="auto-style2">
            </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:TextBox ID="txtWaterMark" runat="server" Font-Size="Medium" Visible="False">Watermark Text</asp:TextBox>
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="Add Watermark" Visible="False" class="btn btn-success" />
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Text Size"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Default Font Size=30"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                Text="Move Right" Visible="False" class="btn btn-default btn-sm"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                Text="Move Left" Visible="False" class="btn btn-default btn-sm"/>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                Text="Submit Changes" Visible="False" class="btn btn-success"/>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="PREVIEW"></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" Height="445px" Width="528px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<br />
<br />
</asp:Content>
