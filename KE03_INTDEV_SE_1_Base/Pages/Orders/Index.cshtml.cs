using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Base.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer.MatrixIncDbContext _context;

        public IndexModel(DataAccessLayer.MatrixIncDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task<RedirectToPageResult> OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Products)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.Customer).ToListAsync();

            return RedirectToPage("/Catalog/Index");
        }
    }
}
