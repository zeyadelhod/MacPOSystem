using WebApplication2.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class listpos : System.Web.UI.Page
    {

        String fileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                GridView GridView1 = (GridView)LoginView1.FindControl("GridView1");

                POs pos = new POs();
                List<POs> PurchaseOrders = pos.PurchaseOrders.ToList();
                GridView1.DataSource = PurchaseOrders;
                if (!IsPostBack)
                {

                    GridView1.DataBind();

                }
            }
        }

        protected void Update(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            String ID = btn.CommandArgument.ToString();

            Response.Redirect("http://mackpotracker.zeywalk.com/details.aspx?id=" + ID);

        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            fileName = e.CommandArgument.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}