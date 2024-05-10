using KABookstore.Data.Base;
using KABookstore.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KABookstore.Models
{

    public class NewBookVM
    {
        public int id { get; set; }
        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Author of Book")]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Display(Name = "Price in R")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Book poster URL")]
        [Required(ErrorMessage = "Book poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Book category is required")]
        public BookCategory BookCategory { get; set; }
    }
}