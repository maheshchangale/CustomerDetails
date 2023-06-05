using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class customer_details
    {
        [Key]
        public Guid customer_id { get; set; }
        public string? customer_name { get; set; }
        public string? customer_mobile { get; set; }
        public string? customer_address { get; set; }
        public string? customer_dob { get; set; }
        public string? customer_email { get; set; }
    }
}
