using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; } = null!;
        public ICollection<Product> Products { get; } = new List<Product>();

        public ICollection<OrderItem> Items { get; } = new List<OrderItem>();

        public class OrderItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}
