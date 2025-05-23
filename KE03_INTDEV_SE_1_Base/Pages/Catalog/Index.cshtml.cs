using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages.Catalog
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IPartRepository _partRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly int _hardcodedCustomerId = 1; // Replace with real identity later

        [TempData]
        public string? StatusMessage { get; set; }

        public Order CurrentOrder { get; set; } = new();

        public List<Product> Products { get; set; }
        public List<Part> Parts { get; set; }

        public IndexModel(IProductRepository productRepository, IPartRepository partRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _partRepository = partRepository;
            _orderRepository = orderRepository;
            Products = new List<Product>();
            Parts = new List<Part>();
        }

        public void OnGet()
        {
            Products = _productRepository.GetAllProducts().ToList();
            Parts = _partRepository.GetAllParts().ToList();

            // Get latest order for this customer
            CurrentOrder = _orderRepository.GetAllOrders()
                .Where(o => o.CustomerId == _hardcodedCustomerId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefault() ?? CreateInitialOrder();
        }
        private Order CreateInitialOrder()
        {
            var order = new Order
            {
                CustomerId = _hardcodedCustomerId,
                OrderDate = DateTime.UtcNow
            };

            _orderRepository.AddOrder(order);
            return order;
        }
        public IActionResult OnPostAddToOrder(int productId, int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            var product = _productRepository.GetProductById(productId);

            if (order != null && product != null)
            {
                if (!order.Products.Any(p => p.Id == product.Id))
                {
                    // Prevent duplicate orders
                    order.Products.Add(product);
                    _orderRepository.UpdateOrder(order);
                    StatusMessage = $"✔️ '{product.Name}' was added to your order.";
                }
                else
                {
                    StatusMessage = $"⚠️ '{product.Name}' is already in your order.";
                }
            }
            else
            {
                StatusMessage = $"❌ Unable to add product to the order.";
            }

            return RedirectToPage();
        }
    }
}
