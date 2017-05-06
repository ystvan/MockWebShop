using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProductManager.Models.AdminViewModels
{
    public class UserViewModels
    {
        public class CreateModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }
        public class LoginModel
        {
            [Required]
            [UIHint("email")]
            public string Email { get; set; }
            [Required]
            [UIHint("password")]
            public string Password { get; set; }
        }
        public class RoleEditModel
        {
            public IdentityRole Role { get; set; }
            public IEnumerable<ApplicationUser> Members { get; set; }
            public IEnumerable<ApplicationUser> NonMembers { get; set; }
        }
        public class RoleModificationModel
        {
            [Required]
            public string RoleName { get; set; }
            public string RoleId { get; set; }
            public string[] IdsToAdd { get; set; }
            public string[] IdsToDelete { get; set; }
        }
    }
}
