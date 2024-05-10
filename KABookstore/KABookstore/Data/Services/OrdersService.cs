using Microsoft.EntityFrameworkCore;
using KABookstore.Models;

namespace KABookstore.Data.Services
{
    public class OrdersService : IOrdersService
    {

        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            // Retrieve orders from the database based on the provided user ID
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items) {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    BookId = item.Book.id,
                    OrderId = order.id,
                    Price = item.Book.Price

                };

                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}
