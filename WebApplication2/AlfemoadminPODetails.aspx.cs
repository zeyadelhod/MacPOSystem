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

namespace WebApplication2
{
    public partial class AlfemoadminPODetails : System.Web.UI.Page
    {
        string ID;
        String FilePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {

                ID = Request.QueryString["ID"];
                POs pos = new POs();


                if (!Page.IsPostBack)
                {
                    // First page access


                    List<POs> PurchaseOrders = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).ToList();


                    GridView GridView1 = (GridView)LoginView1.FindControl("GridView1");

                    POs selectedpo = PurchaseOrders.FirstOrDefault();
                    selectedpo.Status = DropDownList1.SelectedValue;
                    ContainerNumber.Text = selectedpo.ContainerNumber;
                    FinalDestinatonTB.Text = selectedpo.FinalDestLocation;
                    FactoryETA.SelectedDate = selectedpo.FactoryEstimatedArrivalDate;
                    FACTORYETSD.SelectedDate = selectedpo.FactoryEstimatedShipDate;


                    GridView1.DataSource = PurchaseOrders;
                    if (!IsPostBack)
                    {

                        GridView1.DataBind();

                    }
                }
            }
        }
        protected void UpdateStatus(object sender, EventArgs e)
        {
            POs pos = new POs();

            POs selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
            selectedpo.Status = DropDownList1.SelectedValue;
            selectedpo.ContainerNumber = ContainerNumber.Text;
            selectedpo.FinalDestLocation = FinalDestinatonTB.Text;
         selectedpo.FactoryEstimatedArrivalDate=   FactoryETA.SelectedDate;
            selectedpo.FactoryEstimatedShipDate = FACTORYETSD.SelectedDate;
 Label1.Text = " status PO is updated";
                    Label1.BackColor = System.Drawing.Color.Green;
            pos.SaveChanges();
                   

           Response.Write("<script>alert('" + "PO Info is updated " + "')</script>");



            // SendEmail();
        }


        protected void DownloadCorinthianPO(object sender, EventArgs e)
        {
            POs pos = new POs();

            POs selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
            Button btn = (Button)sender;
            String fileName = btn.CommandArgument.ToString();
            DownloadFile(selectedpo.CorinthianPOAttach);

        }
        protected void DownloadMackPO(object sender, EventArgs e)
        {
            
                POs pos = new POs();

                POs selectedpo = pos.PurchaseOrders.ToList().Where(s => s.ID == int.Parse(ID)).FirstOrDefault();
                Button btn = (Button)sender;
            String fileName = btn.CommandArgument.ToString();
                DownloadFile(selectedpo.MackPOAttach);

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
