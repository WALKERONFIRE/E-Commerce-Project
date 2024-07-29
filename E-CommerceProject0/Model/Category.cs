using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }


        public List<Product> Products { get; set; }
        public List<ProdRequestDetail> ProdRequestDetails { get; set; }
    }
}
