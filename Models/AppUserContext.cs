using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace authentication.Models
{
    public class AppUserContext:IdentityDbContext
    {
        public AppUserContext(DbContextOptions<AppUserContext> options) : base(options) { }
        public DbSet<AppUser> Users { get; set; }
    }
}
