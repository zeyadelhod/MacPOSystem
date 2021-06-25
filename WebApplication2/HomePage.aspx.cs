using WebApplication2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Controllers;
using System;
using System.Collections.Generic;
using WebApplication2.DAL;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using WebApplication2.Models;

namespace WebApplication2.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            FileUpload FileUpload1 = (FileUpload)LoginView1.FindControl("FileUpload1");
            TextBox TextBox1 = (TextBox)LoginView1.FindControl("TextBox1");
            TextBox TextBox2 = (TextBox)LoginView1.FindControl("TextBox2");
            TextBox TextBox3 = (TextBox)LoginView1.FindControl("TextBox3");
            Label Label1 = (Label)LoginView1.FindControl("Label1");
            
                            TextBox CommentsTextBox = (TextBox)LoginView1.FindControl("TextBox3");

            Calendar Calendar1 = (Calendar)LoginView1.FindControl("cal");

            Label1.Text =  " Create PO Please Wait!";
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
                    Label1.Text = strFileName + " already exists on the server!";
                    Label1.BackColor = System.Drawing.Color.Red;

                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(strFilePath);
                    Label1.Text = "PO is created and sent to mack Dis ";
                    Label1.BackColor = System.Drawing.Color.Green;
                    Response.Write("<script>alert('" + "PO is Created and now pending Mack Dis Approval" + "')</script>");

                }
            }
            else
            {
                Label1.Text = "Click 'Browse' to select the file to upload.";
                Label1.BackColor = System.Drawing.Color.Red;

            }

            POsDBContext pOsDBContext = new POsDBContext();
            PurchaseOrderModel pos = new PurchaseOrderModel
            {
                DealerName = TextBox1.Text,
                DealerPONumber = TextBox2.Text,
                CorinthianPO = TextBox3.Text,
                ProductionRequestDate = Calendar1.SelectedDate,
                ApprovalStatus = false,
                UserID = User.Identity.GetUserName(),
                Comments = CommentsTextBox.Text,
                CorinthianPOAttach = FileUpload1.FileName


            };

            pOsDBContext.PurchaseOrders.Add(pos);
            pOsDBContext.SaveChanges();
        }

      


   
    }
}