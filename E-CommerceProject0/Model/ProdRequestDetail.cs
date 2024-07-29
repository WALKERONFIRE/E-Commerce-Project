namespace E_CommerceProject0.Model
{
    public class ProdRequestDetail
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? ProductRequestId { get; set; }
        public ProductRequest? ProductRequest { get; set; }



    }
}
