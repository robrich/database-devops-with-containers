namespace DatabaseDevOps.Models.Models;

public class CustomerViewModel
{
    public List<Customer> Customers { get; set; } = new();
    public int Page { get; set; }
}
