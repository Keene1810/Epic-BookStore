using Firebase.Auth;
using KABookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LoginModel = KABookstore.Models.LoginModel;

namespace KABookstore.Controllers
{
    public class AuthController : Controller
    {
        private readonly FirebaseAuthProvider _auth;

        public AuthController(FirebaseAuthProvider auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginModel login)
        {
            try
            {
                await _auth.CreateUserWithEmailAndPasswordAsync(login.Email, login.Password);

                var fbAuthLink = await _auth.SignInWithEmailAndPasswordAsync(login.Email, login.Password);
                string currentUserId = fbAuthLink.User.LocalId;

                if (currentUserId != null)
                {
                    HttpContext.Session.SetString("currentUser", currentUserId);
                    return RedirectToAction("Calculate", "Math");
                }
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
                ModelState.AddModelError(String.Empty, firebaseEx.error.message);
                return View(login);
            }

            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                var fbAuthLink = await _auth.SignInWithEmailAndPasswordAsync(login.Email, login.Password);
                string currentUserId = fbAuthLink.User.LocalId;

                if (currentUserId != null)
                {
                    HttpContext.Session.SetString("currentUser", currentUserId);
                    return RedirectToAction("Calculate", "Math");
                }

            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
                ModelState.AddModelError(String.Empty, firebaseEx.error.message);

                Utils.AuthLogger.Instance.LogError(firebaseEx.error.message + " - User: " + login.Email + " - IP: " + HttpContext.Connection.RemoteIpAddress
        + " - Browser: " + Request.Headers.UserAgent);

                return View(login);
            }


            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Login");
        }
    }
}
