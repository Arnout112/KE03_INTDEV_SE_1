using KE03_INTDEV_SE_1_Base.Helpers;
using KE03_INTDEV_SE_1_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages.Cart
{
    public class IndexModel : PageModel
    {
        public Models.Cart Cart { get; set; }

        public void OnGet()
        {
            Cart = HttpContext.Session.GetObject<Models.Cart>("Cart") ?? new Models.Cart();
        }

        public IActionResult OnPostRemove(int productId)
        {
            var cart = HttpContext.Session.GetObject<Models.Cart>("Cart") ?? new Models.Cart();

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateQuantity(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetObject<Models.Cart>("Cart") ?? new Models.Cart();

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity = quantity;
                if (item.Quantity <= 0)
                {
                    cart.Items.Remove(item);
                }
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToPage();
        }


        //public List<CartItem> Items { get; set; } = new List<CartItem>();

        //public decimal Total => Items.Sum(i => i.Quantity * i.Price);

        //public void OnGet()
        //{
            
        //    // Example data — replace with your real cart retrieval logic (e.g., from session)
        //    //Items = new List<CartItem>
        //    //{
        //    //    new CartItem { ProductId = 1, Name = "Sample Product 1", Price = 19.99m, Quantity = 2, ImageUrl = "/images/sample1.jpg" },
        //    //    new CartItem { ProductId = 2, Name = "Sample Product 2", Price = 9.49m, Quantity = 1, ImageUrl = "/images/sample2.jpg" }
        //    //};
        //}
    }

}
