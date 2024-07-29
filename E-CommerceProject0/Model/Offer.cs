using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class Offer
    {

        public int Id { get; set; }
        public int OfferPercentage { get; set; }    
        public List<Product> products { get; set; }

    }
}
