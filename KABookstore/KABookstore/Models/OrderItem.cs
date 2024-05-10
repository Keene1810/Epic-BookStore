using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KABookstore.Models
{
    public class OrderItem
    {
        [Key]
        public int id { get; set; }
        public int Amount {  get; set; }
        public double Price { get; set; }

        // foreign key Book
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        
        // foreign key Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
