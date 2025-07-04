using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using KE03_INTDEV_SE_1_Base.Helpers;
using KE03_INTDEV_SE_1_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DataAccessLayer.Models.Order;

namespace KE03_INTDEV_SE_1_Base.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public OrderInputModel Order { get; set; }

        public Models.Cart Cart { get; set; }
        private readonly IOrderRepository _orderRepository;

        public CheckoutModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
            Cart = HttpContext.Session.GetObject<Models.Cart>("Cart") ?? new Models.Cart();
        }
        //async Task<IActionResult>
        public async Task<IActionResult> OnPostAsync()
        {
            Cart = HttpContext.Session.GetObject<Models.Cart>("Cart") ?? new Models.Cart();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Cart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return Page();
            }

            // TODO:if user is logged in, don't ask for contact details

            // save the order to the database

            var customer = new Customer
            {
                Name = Order.Name,
                Address = Order.Address,
                City = Order.City,
                Email = Order.Email,
            };

            var order = new Order
            {
                Customer = customer,

            };
            

            // Map cart items to order items
            foreach (var cartItem in Cart.Items)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = cartItem.Product.Id,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                });
            }

            // Add to DbContext and save
            _orderRepository.AddOrder(order);

            HttpContext.Session.Remove("Cart");

            TempData["OrderSuccess"] = "Thank you! Your order has been placed.";
            return RedirectToPage("/Catalog/Index");
        }

        public class OrderInputModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Address { get; set; }
            [Required]
            public string City { get; set; }
            [Required, EmailAddress]
            public string Email { get; set; }
        }
    }

}
