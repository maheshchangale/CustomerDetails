using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class customer_login
    {
        [Key]
        public Guid login_id { get; set; }
        public string? email_id { get; set; }
        public string? password { get; set; }
    }
}
