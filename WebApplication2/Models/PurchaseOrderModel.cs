using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.DAL;

namespace WebApplication2.Models
{


    [Table("mackpotracker")]

    public class PurchaseOrderModel
    {
        [Key]
        public int ID { get; set; }
        public String DealerName { get; set; }
        public String DealerPONumber { get; set; }
        public String MackPONumber { get; set; }

        public String CorinthianPO { get; set; }
        public String ItemID { get; set; }
        public String SupplierName { get; set; }
        public String UserID { get; set; }
        public String MackPOAttach { get; set; }

        public String CorinthianPOAttach { get; set; }
        public String Comments { get; set; }

        public String Status { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProductionRequestDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime FactoryEstimatedShipDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateReceived { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FactoryEstimatedArrivalDate { get; set; }

        public bool Booked { get; set; }

        public String FinalDestLocation { get; set; }

        public String ContainerNumber { get; set; }


        public String ProductionRequestTime { get; set; }
        public bool ApprovalStatus { get; set; }
    }
}