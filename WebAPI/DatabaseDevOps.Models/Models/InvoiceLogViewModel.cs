namespace DatabaseDevOps.Models.Models;

public class InvoiceLogViewModel
{
    public List<InvoiceLog> InvoiceLogs { get; set; } = new();
    public int Page { get; set; }
}
