﻿using System.ComponentModel.DataAnnotations;

namespace KABookstore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int id { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
