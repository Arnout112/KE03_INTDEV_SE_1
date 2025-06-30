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
        // TODO: check if quantity does not exceed stock
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
                else
                {
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToPage();
        }
    }

}
