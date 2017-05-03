using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MockyShopClient.Models
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
