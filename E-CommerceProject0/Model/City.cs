using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }

    }
}
