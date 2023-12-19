using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class Appdbcontext:IdentityDbContext<Appuser>

    {

        public Appdbcontext()
        {
            
        }

        public Appdbcontext(DbContextOptions options):base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

    }
}
