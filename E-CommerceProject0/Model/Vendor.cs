using System;
using System.Collections.Generic;

namespace E_CommerceProject0.Model
{
    public class VendorRegister
    {
        public string Name { get; set; }
        public String VendorSsn { get; set; }

        public string Email { get; set; }
        public String password { get; set; }

        public int CountryId { get; set; }
    }
    public class VendorLogin
    {
        public string Email { get; set; }
        public String password { get; set; }
    }

    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        
        public String VendorSsn { get; set; }

        public string Email { get; set; }
        public String password { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        
        //public V_Payment Payment { get; set; }


        public List<ProductRequest> productRequests { get; set; }
        public List <VendorPaymentReport> vendorPaymentReports { get; set; }
        public List <Product> Products { get; set; }

    }
}
