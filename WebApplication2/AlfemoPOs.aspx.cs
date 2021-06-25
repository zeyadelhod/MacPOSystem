using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class AlfemoPOs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                GridView GridView1 = (GridView)LoginView1.FindControl("GridView1");

                POsDBContext pos = new POsDBContext();

                List<PurchaseOrderModel> PurchaseOrders = pos.PurchaseOrders.ToList().Where(s => s.ApprovalStatus == true).ToList();

                GridView1.DataSource = PurchaseOrders;
                if (!IsPostBack)
                {

                    GridView1.DataBind();

                }
            }
        }


        protected void DownloadMackPO(object sender, EventArgs e)
        {

            POsDBContext pos = new POsDBContext();

            PurchaseOrderModel selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
            Button btn = (Button)sender;
            String fileName = btn.CommandArgument.ToString();
            DownloadFile(selectedpo.MackPOAttach);

        }
        protected void Review(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            String ID = btn.CommandArgument.ToString();

            Response.Redirect("http://mack.besafe.mochahosted.com/AlfemoadminPODetails.aspx?id=" + ID);



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
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mack.besafe.mochahosted.com/mack.besafe.mochahosted.com/files/" + FileName);
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
