using Microsoft.AspNetCore.Identity;

namespace TequilaRestaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
