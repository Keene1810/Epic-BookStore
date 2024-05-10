using KABookstore.Data.Base;
using KABookstore.Data.ViewModels;
using KABookstore.Models;

namespace KABookstore.Data.Services
{
    public interface IBooksService: IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}
