using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KABookstore.Data.Cart;
using KABookstore.Data.Services;
using KABookstore.Data.ViewModels;
using System.Security.Claims;
using Firebase.Auth;
using FirebaseAdmin.Auth;

namespace KABookstore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IBooksService _BooksService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly FirebaseAuthProvider _auth;

        public OrdersController(IBooksService BooksService, ShoppingCart shoppingCart, IOrdersService ordersService, FirebaseAuthProvider auth)
        {
            _BooksService = BooksService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            _auth = auth;
        }

        //public async Task<IActionResult> Index()
        //{
        //    // Get user ID from Firebase authentication
        //    var userId = await GetUserIdFromFirebase();

        //    // Fetch orders for the current user
        //    var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
        //    return View(orders);
        //}

        //public IActionResult ShoppingCart()
        //{
        //    var items = _shoppingCart.GetShoppingCartItems();
        //    _shoppingCart.ShoppingCartItems = items;

        //    var response = new ShoppingCartVM()
        //    {
        //        ShoppingCart = _shoppingCart,
        //        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        //    };

        //    return View(response);
        //}

        //public async Task<IActionResult> AddItemToShoppingCart(int id)
        //{
        //    var item = await _BooksService.GetBookByIdAsync(id);

        //    if (item != null)
        //    {
        //        _shoppingCart.AddItemToCart(item);
        //    }
        //    return RedirectToAction(nameof(ShoppingCart));
        //}

        //public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        //{
        //    var item = await _BooksService.GetBookByIdAsync(id);

        //    if (item != null)
        //    {
        //        _shoppingCart.RemoveItemFromCart(item);
        //    }
        //    return RedirectToAction(nameof(ShoppingCart));
        //}

        //public async Task<IActionResult> CompleteOrder()
        //{
        //    // Get user ID and email address from Firebase authentication
        //    var userId = await GetUserIdFromFirebase();
        //    var userEmail = await GetUserEmailFromFirebase();

        //    // Get shopping cart items
        //    var items = _shoppingCart.GetShoppingCartItems();

        //    // Store order and clear shopping cart
        //    await _ordersService.StoreOrderAsync(items, userId, userEmail);
        //    await _shoppingCart.ClearShoppingCartAsync();

        //    return View("OrderCompleted");
        //}

        //private async Task<string> GetUserIdFromFirebase()
        //{
        //    // Retrieve user ID from Firebase authentication token
        //    // var authLink = await _auth.VerifyIdTokenAsync(Request.Cookies["Token"]);
        //    // return authLink.Uid; // Uid contains the user's unique ID
        //}


        //private async Task<string> GetUserEmailFromFirebase()
        //{
        //    // Retrieve user email address from Firebase authentication token
        //    // var authLink = await _auth.VerifyIdTokenAsync(Request.Cookies["Token"]);
        //    // return authLink.User.Email;
        //}

        //public IActionResult AccessDenied(string ReturnUrl)
        //{
        //    return View(ReturnUrl);
        //}
    }
}