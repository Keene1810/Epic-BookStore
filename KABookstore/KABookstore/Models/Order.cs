using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KABookstore.Models
{
    public class Order
    {
        [Key] 
        public int id { get; set; }

        public string Email { get; set; }

        // foreign key User
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public List <OrderItem> OrderItems { get; set; }
    }
}
