using Microsoft.EntityFrameworkCore;
using KABookstore.Data.Base;
using KABookstore.Data.ViewModels;
using KABookstore.Models;

namespace KABookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Author = data.Author,
                BookCategory = data.BookCategory,
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();


        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var BookDetails = await _context.Books
                
                .FirstOrDefaultAsync(n => n.id == id);

            return BookDetails;
        }



        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.id == data.id);

            if (dbBook != null)
            {
                dbBook.Name = data.Name;
                dbBook.Description = data.Description;
                dbBook.Author = data.Author;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.BookCategory = data.BookCategory;
                
                await _context.SaveChangesAsync();
            }

        }
    }
}

