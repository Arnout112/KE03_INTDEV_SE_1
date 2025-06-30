using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages.Catalog
{
    public class IndexModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public IndexModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Layout { get; set; } // "grid" or "table"
        public string? Query { get; set; } // Search query

        public async Task OnGetAsync(string? query)
        {
            // Filters on query
            // TODO: add category filter, price range filter, etc.
            if (!string.IsNullOrEmpty(query))
            {
                Products = await _context.Products
                    .Where(p => p.Name.ToLower().Contains(query.ToLower()))
                    .ToListAsync();
                Query = query; // Preserve the query for the view
            }
            else
            {
                Products = await _context.Products.ToListAsync();
            }

            // default to "grid" if invalid
            if (Layout != "table" && Layout != "grid")
            {
                Layout = "grid";
            }
        }
    }
}
