using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.DataAccess
{
    public class InvoiceLog
    {
        [Key]
        public int InvoiceLogId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
