using KABookstore.Data.Base;
using KABookstore.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KABookstore.Models
{
    public class Book:IEntityBase
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
     
        public BookCategory BookCategory { get; set;  }

        // to get the category name
        public string CategoryName => Enum.GetName(typeof(BookCategory), BookCategory);

    }
}
