using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed roles : user, admin, superadmin

            var adminRoleId = "0c690983-a3fc-4443-b3c7-ab27d1eb5c71";
            var superAdminRoleId = "hels1312-0c4a-48b6-9693-b5cbef581bf5";
            var userRoleId = "8485524e-1935-46b5-9608-9cb9ffe9b2a2";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name= "Admin",
                    NormalizedName= "Admin",
                    Id=adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName="SuperAdmin",
                    Id=superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },

                new IdentityRole
                {
                    Name= "User",
                    NormalizedName = "User",
                    Id=userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //Superadmin
            var superAdminId = "13122023-he10-4120-92b2-9a19ed6dc116";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadminq@helsblog.com",
                Email = "superadminq@helsblog.com",
                NormalizedEmail = "superadminq@helsblog.com".ToUpper(),
                NormalizedUserName = "superadminq@helsblog.com".ToUpper(),
                Id = superAdminId

            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadminhels1312");
                
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add all roles to SuperAdminUser

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

            
            
        }
    }
}
