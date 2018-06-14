using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly WebAppContext db;

        public CustomerController(WebAppContext Context)
        {
            db = Context ?? throw new ArgumentNullException(nameof(Context));
        }
        
        /// <param name="id">page number, base 0</param>
        public async Task<IActionResult> Index(int? id)
        {
            int page = id ?? 0;
            if (page < 0)
            {
                page = 0;
            }
            int pageSize = 24;
            List<Customer> customers = await (
                from c in db.Customer
                orderby c.CustomerId
                select c
            ).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return View(new CustomerViewModel {
                Customers = customers,
                Page = page
            });
        }

    }
}