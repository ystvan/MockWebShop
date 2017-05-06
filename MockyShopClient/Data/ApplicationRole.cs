using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MockyShopClient.Data
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
    }
}
