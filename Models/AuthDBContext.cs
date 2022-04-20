using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth_project.Models
{
    public class AuthDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {
            _options = options;
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        
    }
}
