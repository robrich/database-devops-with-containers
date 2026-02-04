namespace DatabaseDevOps.Models.Data;

public class InvoiceLog
{
    [Key]
    public int InvoiceLogId { get; set; }
    public DateTime CreateDate { get; set; }
}
