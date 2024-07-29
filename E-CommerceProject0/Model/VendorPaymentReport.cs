namespace E_CommerceProject0.Model
{
    public class VendorPaymentReport
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; }


        //public int PaymentId { get; set; }
        //public V_Payment Payment { get; set; }

        

    }
}
