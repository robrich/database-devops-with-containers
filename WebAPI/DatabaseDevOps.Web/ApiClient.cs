namespace DatabaseDevOps.Web;

public class ApiClient(HttpClient httpClient)
{
	public async Task<CustomerViewModel> GetCustomers(int page, CancellationToken cancellationToken = default) =>
		(await httpClient.GetFromJsonAsync<CustomerViewModel>($"/customers/{page}", cancellationToken)) ?? new CustomerViewModel();

	public async Task<InvoiceLogViewModel> GetInvoiceLogs(int page, CancellationToken cancellationToken = default) =>
		(await httpClient.GetFromJsonAsync<InvoiceLogViewModel>($"/invoicelogs/{page}", cancellationToken)) ?? new InvoiceLogViewModel();

	public async Task<List<Setting>> GetSettings(CancellationToken cancellationToken = default) =>
		(await httpClient.GetFromJsonAsync<List<Setting>>($"/settings", cancellationToken)) ?? new List<Setting>();
}
