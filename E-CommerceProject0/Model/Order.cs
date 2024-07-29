using System;
using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }


        public int? UserId { get; set; }
        public User? User { get; set; }

        public UserPaymentReport report { get; set; }
        public List<OrderItem> Items { get; set; }

    }
    public class OrderDTO
    {
        public int UserId { get; set; }
        public List<OrderData> OrderData { get; set; }

    }
    public class OrderData
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int qty { get; set; }
    }
    //public class orderadder
    //{
    //    public int UserId { get; set; }
    //}
}
