using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MockyShopClient.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }
        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }
    }
}
