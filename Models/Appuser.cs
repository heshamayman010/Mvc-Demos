using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class Appuser:IdentityUser
    {

        public string? Address { get; set; }



    }
}
