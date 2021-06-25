using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class adminPODetails : System.Web.UI.Page
    {
        string ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {

                ID = Request.QueryString["ID"];
                POsDBContext pos = new POsDBContext();


                GridView GridView1 = (GridView)LoginView1.FindControl("GridView1");


                List<PurchaseOrderModel> PurchaseOrders = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).ToList();

                GridView1.DataSource = PurchaseOrders;
                if (!IsPostBack)
                {

                    GridView1.DataBind();

                }
            }
        }
        protected void UploadPO(object sender, EventArgs e)
        {
            FileUpload FileUpload1 = (FileUpload)LoginView1.FindControl("FileUpload1");
            TextBox TextBox1 = (TextBox)LoginView1.FindControl("TextBox1");
            TextBox TextBox2 = (TextBox)LoginView1.FindControl("TextBox2");
            TextBox TextBox3 = (TextBox)LoginView1.FindControl("TextBox3");
            Label Label1 = (Label)LoginView1.FindControl("Label1");


            Calendar Calendar1 = (Calendar)LoginView1.FindControl("cal");

            Label1.Text = " Create PO Please Wait!";
            Label1.BackColor = System.Drawing.Color.Yellow;
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("./files/");
            // Retrieve the name of the file that is posted.
            strFileName = FileUpload1.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (FileUpload1.PostedFile.FileName != "")
            {

                // Create the folder if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    Label1.Text = "This PO is already created in the system";
                    Label1.BackColor = System.Drawing.Color.Red;

                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(strFilePath);
                    Label1.Text =  "PO is created and sent to mack Dis ";
                    POsDBContext pos = new POsDBContext();

                    PurchaseOrderModel selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
                    selectedpo.MackPOAttach = FileUpload1.FileName;

                    pos.SaveChanges();
                    Label1.Text = "PO is created and sent to mack Dis ";
                    Label1.BackColor = System.Drawing.Color.Green;

                }
            }
            else
            {
                Label1.Text = "Click 'Browse' to select the file to upload.";
                Label1.BackColor = System.Drawing.Color.Red;

            }


        
            // SendEmail();
        }


        protected void DownloadCorinthianPO(object sender, EventArgs e)
        {
            POsDBContext pos = new POsDBContext();

            PurchaseOrderModel selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
            Button btn = (Button)sender;
            String fileName = btn.CommandArgument.ToString();
            DownloadFile(selectedpo.CorinthianPOAttach);

        }
        protected void DownloadMackPO(object sender, EventArgs e)
        {
            
                POsDBContext pos = new POsDBContext();

            PurchaseOrderModel selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
                Button btn = (Button)sender;
            String fileName = btn.CommandArgument.ToString();
                DownloadFile(selectedpo.MackPOAttach);

        }
        protected void Approve(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            String ID = btn.CommandArgument.ToString();
            POsDBContext pos = new POsDBContext();

            pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault().ApprovalStatus = true;
            pos.SaveChanges();

            Response.Redirect(Request.RawUrl);
            Response.Write("<script>alert('" + "PO is Approved now " + "')</script>");

        }
        protected void Cancel(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            String ID = btn.CommandArgument.ToString();
            POsDBContext pos = new POsDBContext();

            pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault().ApprovalStatus = false;
            pos.SaveChanges();
            Response.Write("<script>alert('" + "PO is rejected now " + "')</script>");

            Response.Redirect(Request.RawUrl);


        }
        protected void DownloadFile(String FileName)
        {

            //FTP Server URL.
            string ftp = "ftp://yourserver.com/";

       
            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "Uploads/";

            try
            {
                //Create FTP Request.                                     
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mack.besafe.mochahosted.com/mack.besafe.mochahosted.com/files/"+ FileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("zbacha", "Gobie@7009");
                request.UsePassive = true;
                request.UseBinary = true;
                request.EnableSsl = false;

                //Fetch the Response and read it into a MemoryStream object.
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (MemoryStream stream = new MemoryStream())
                {
                    //Download the File.
                    response.GetResponseStream().CopyTo(stream);
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(stream.ToArray());
                    Response.End();
                }
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
    }
}
