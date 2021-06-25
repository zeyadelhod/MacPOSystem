using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using WebApplication2.Controllers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DAL
{

  

    public class POsDBContext : DbContext
    {

        public POsDBContext() : base("POsDBConnectionString")
        {
        }


        public DbSet<PurchaseOrderModel> PurchaseOrders { get; set; }


    }
}