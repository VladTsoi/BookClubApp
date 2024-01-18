using BookClubApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BookClubApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> BookCatalog(User user)
        {
            return View(await db.Catalogs.Where(c => c.User.Login == User.Identity.Name).ToListAsync());
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Finish(int? id)
        {
            await Crud.Update(id, db);
            return RedirectToAction("BookCatalog");
        }
        [HttpPost]
        public async Task<IActionResult> PutAway(int? id)
        {
            await Crud.Update(id, db);
            return RedirectToAction("Read");
        }
        public async Task<IActionResult> Read(User user)
        {
            return View(await db.Catalogs.Where(c => c.User.Login == User.Identity.Name && c.Status == true).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            await Crud.Insert(user, db);
            await Authenticate(user);
            return RedirectToAction("BookCatalog");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
