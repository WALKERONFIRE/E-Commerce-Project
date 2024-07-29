using Microsoft.Data.SqlClient.Server;
using Microsoft.VisualBasic;
using System;

namespace E_CommerceProject0.Model
{
    public class UserPaymentReport
    {
        public int Id { get; set; }

        public DateTime TimeCreated { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        //public int PaymentId { get; set; }
        //public C_Payment Payment { get; set; }

        public string status { get; set; }
    }
    public class UPR_Final
    {
        public DateTime TimeCreated { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }

    public string status { get; set; }
    }
}