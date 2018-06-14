using System.Collections.Generic;
using WebApp.DataAccess;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public List<Setting> Settings { get; set; }
        public Customer FeaturedCustomer { get; set; }
        public InvoiceLog FeaturedInvoiceLog { get; set; }
    }
}
