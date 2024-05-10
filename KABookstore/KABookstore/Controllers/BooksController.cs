using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KABookstore.Data;
using KABookstore.Data.Services;
using KABookstore.Models;

namespace KABookstore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync();
            return View(allBooks);
        }



        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allBooks
                    .Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var BookDetail = await _service.GetBookByIdAsync(id);
            return View(BookDetail);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var BookDetails = await _service.GetBookByIdAsync(id);
            if (BookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                id = BookDetails.id,
                Name = BookDetails.Name,
                Description = BookDetails.Description,
                Author = BookDetails.Author,
                Price = BookDetails.Price,
                ImageURL = BookDetails.ImageURL,
                BookCategory = BookDetails.BookCategory,
            };

            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM Book)
        {
            if (id != Book.id) return View("NotFound");

            
            await _service.UpdateBookAsync(Book);
            return RedirectToAction(nameof(Index));
        }
    }
}
