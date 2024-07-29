using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class Country
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vendor> Vendors  { get; set; }
    }
}
