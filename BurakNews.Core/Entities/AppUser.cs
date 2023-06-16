using Microsoft.AspNetCore.Identity;

namespace BurakNews.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public bool RememberMe { get; set; }

    }
}
