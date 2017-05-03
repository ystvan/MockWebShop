using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MockyShopClient.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockyShopClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            string userName = userManager.GetUserName(User);
            return View("Index", userName);
        }
    }
}
