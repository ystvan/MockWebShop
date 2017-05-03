using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MockyShopClient.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
