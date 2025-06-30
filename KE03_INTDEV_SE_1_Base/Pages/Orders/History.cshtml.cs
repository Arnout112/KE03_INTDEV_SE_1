using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages.Orders
{
    public class HistoryModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public HistoryModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; } = new();

        public async Task OnGetAsync()
        {
            // TODO: Ad user identification logic (e.g. User.Identity.Name or user ID)

            Orders = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }

}
