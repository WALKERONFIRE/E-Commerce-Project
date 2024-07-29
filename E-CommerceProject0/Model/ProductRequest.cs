using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class ProductRequest
    {
        public int Id { get; set; } 

        public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        
        public List<ProdRequestDetail> ProdRequestDetails { get; set; }

       

    }
}
