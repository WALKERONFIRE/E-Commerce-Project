using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int PriceAfterOffer { get; set; }
        public string Image { get; set; }

        public string availablity { get; set; }

        public int? OfferId { get; set; }
        public Offer? Offer { get; set; }
            
      public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<ProdRequestDetail> ProdRequestDetails{ get; set; }


        public List <OrderItem> OrderItems { get; set; }


    



    }
    public class ProductAdder
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int PriceAfterOffer { get; set; }

        public string Image { get; set; }

        //public byte[] Image { get; set; }
        public string availablity { get; set; }

        public int OfferId { get; set; }

        public int? VendorId { get; set; }

        public int? CategoryId { get; set; }
    }
}
