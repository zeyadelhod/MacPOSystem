using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;

namespace WebApplication2
{
    public partial class Mypos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                GridView GridView1 = (GridView)LoginView1.FindControl("GridView1");

                POs pos = new POs();
               
                List<POs> PurchaseOrders = pos.PurchaseOrders.ToList().Where(s => s.UserID == User.Identity.Name).ToList();
             
                GridView1.DataSource = PurchaseOrders;
                if (!IsPostBack)
                {

                    GridView1.DataBind();

                }
            }
        }
    }
}