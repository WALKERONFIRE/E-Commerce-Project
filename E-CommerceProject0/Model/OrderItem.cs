namespace E_CommerceProject0.Model
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        
        public int qty { get; set; }

    }
   
}
