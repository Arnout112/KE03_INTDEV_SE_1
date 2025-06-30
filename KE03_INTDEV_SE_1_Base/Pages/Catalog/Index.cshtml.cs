using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            //Filter on query
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

        //private readonly IProductRepository _productRepository;
        //private readonly IPartRepository _partRepository;
        //private readonly IOrderRepository _orderRepository;
        //private readonly int _hardcodedCustomerId = 1; // Replace with real identity later

        //[TempData]
        //public string? StatusMessage { get; set; }

        //public Order CurrentOrder { get; set; } = new();

        //public List<Product> Products { get; set; }
        //public List<Part> Parts { get; set; }

        //public IndexModel(IProductRepository productRepository, IPartRepository partRepository, IOrderRepository orderRepository)
        //{
        //    _productRepository = productRepository;
        //    _partRepository = partRepository;
        //    _orderRepository = orderRepository;
        //    Products = new List<Product>();
        //    Parts = new List<Part>();
        //}

        //public void OnGet(string query)
        //{
        //    //Filter on query
        //    if (!string.IsNullOrEmpty(query))
        //    {
        //        Products = Products = _productRepository.GetAllProducts()
        //            .Where(p => p.Name.ToLower().Contains(query.ToLower()))
        //            .ToList();
        //    }
        //    else
        //    {
        //        Products = _productRepository.GetAllProducts().ToList();
        //        Parts = _partRepository.GetAllParts().ToList();
        //    }


        //    // Get latest order for this customer
        //    CurrentOrder = _orderRepository.GetAllOrders()
        //        .Where(o => o.CustomerId == _hardcodedCustomerId)
        //        .OrderByDescending(o => o.OrderDate)
        //        .FirstOrDefault() ?? CreateInitialOrder();
        //}
    }
}
