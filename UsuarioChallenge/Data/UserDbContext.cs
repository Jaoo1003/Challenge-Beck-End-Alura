using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuarioChallenge.Data {
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>{

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt){

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = "AuthorizedUser", NormalizedName = "AUTHORIZEDUSER" });
        }
    }
}
