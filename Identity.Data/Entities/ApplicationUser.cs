using Microsoft.AspNetCore.Identity;

namespace Identity.Data.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string Fio { get; set; }
    }
}