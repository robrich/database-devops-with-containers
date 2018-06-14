using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DataAccess;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InvoiceLogController : Controller
    {
        private readonly WebAppContext db;

        public InvoiceLogController(WebAppContext Context)
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
            List<InvoiceLog> logs = await (
                from i in db.InvoiceLog
                orderby i.InvoiceLogId
                select i
            ).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return View(new InvoiceLogViewModel
            {
                InvoiceLogs = logs,
                Page = page
            });
        }

    }
}
