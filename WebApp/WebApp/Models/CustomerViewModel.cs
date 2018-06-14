using System.Collections.Generic;
using WebApp.DataAccess;

namespace WebApp.Models
{
    public class CustomerViewModel
    {
        public List<Customer> Customers { get; set; }
        public int Page { get; set; }
    }
}
