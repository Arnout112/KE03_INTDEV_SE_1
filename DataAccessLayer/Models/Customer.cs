﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }

        public bool Active { get; set; } = true;

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}