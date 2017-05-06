using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductManager.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Authorize(Roles = "Admins")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Admins")]
        public IActionResult RoleAdmin()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


    }
}
