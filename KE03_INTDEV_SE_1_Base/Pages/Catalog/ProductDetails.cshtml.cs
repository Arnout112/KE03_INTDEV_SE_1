using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Helpers;
using KE03_INTDEV_SE_1_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages.Catalog
{
    public class ProductDetailsModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public ProductDetailsModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
        // TODO: check if quantity does not exceed stock
        // TODO: reserve stock for the product when adding to cart
        public IActionResult OnPostAddToCart(int productId, int quantity = 1)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetObject<Models.Cart>("Cart") ?? new Models.Cart();

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToPage("/Cart/Index");
        }
    }

}
