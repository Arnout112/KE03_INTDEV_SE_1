using KE03_INTDEV_SE_1_Base.Helpers;
using KE03_INTDEV_SE_1_Base.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Threading.Tasks;

namespace KE03_INTDEV_SE_1_Base.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            int count = cart.Items.Sum(i => i.Quantity);

            // Return raw HTML string instead of a separate view file
            return Task.FromResult<IViewComponentResult>(
                new HtmlContentViewComponentResult(
                    new HtmlString($"<span class=\"badge bg-primary ms-1\">{count}</span>")
                )
            );
        }
    }
}

