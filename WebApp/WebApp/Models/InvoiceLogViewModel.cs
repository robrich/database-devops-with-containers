using System.Collections.Generic;
using WebApp.DataAccess;

namespace WebApp.Models
{
    public class InvoiceLogViewModel
    {
        public List<InvoiceLog> InvoiceLogs { get; set; }
        public int Page { get; set; }
    }
}
