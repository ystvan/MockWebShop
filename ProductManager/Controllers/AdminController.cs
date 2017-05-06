using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Models.AdminViewModels;

namespace ProductManager.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        private readonly IPasswordValidator<ApplicationUser> passwordValidator;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserValidator<ApplicationUser> userValidator;

        public AdminController(UserManager<ApplicationUser> usrMgr,
            IUserValidator<ApplicationUser> userValid,
            IPasswordValidator<ApplicationUser> passValid,
            IPasswordHasher<ApplicationUser> passwordHash)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }

        public ViewResult Index() => View(userManager.Users);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModels.CreateModel models)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = models.Name,
                    Email = models.Email
                };
                var result
                    = await userManager.CreateAsync(user, models.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                AddErrorsFromResult(result);
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email,
            string password)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                var validEmail
                    = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                    AddErrorsFromResult(validEmail);
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager,
                        user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user,
                            password);
                    else
                        AddErrorsFromResult(validPass);
                }
                if (validEmail.Succeeded && validPass == null
                    || validEmail.Succeeded
                    && password != string.Empty && validPass.Succeeded)
                {
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }


        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}