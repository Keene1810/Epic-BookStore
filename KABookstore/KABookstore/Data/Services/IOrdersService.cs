﻿using KABookstore.Models;

namespace KABookstore.Data.Services
{
    public interface IOrdersService
    {

        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
