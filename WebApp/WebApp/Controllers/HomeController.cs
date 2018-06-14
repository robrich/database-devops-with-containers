using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataAccess;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppContext db;

        public HomeController(WebAppContext Context)
        {
            db = Context ?? throw new ArgumentNullException(nameof(Context));
        }

        public IActionResult Index()
        {
            // random customer
            Random r = new Random();
            int invoiceLogId = r.Next(1, 1000);
            int customerId = r.Next(1, 5000);

            List<Setting> settings = (
                from s in db.Settings
                orderby s.Name
                select s
            ).ToList();
            Customer customer = (
                from c in db.Customer
                where c.CustomerId == customerId
                select c
            ).First(); // assume it exists
            InvoiceLog invoiceLog = (
                from s in db.InvoiceLog
                where s.InvoiceLogId == invoiceLogId
                select s
            ).First(); // assume it exists

            return View(new HomeViewModel
            {
                Settings = settings,
                FeaturedCustomer = customer,
                FeaturedInvoiceLog = invoiceLog
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
