using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace task1.Model
{
    public class Context : IdentityDbContext <ApplicationUser>
    {
        //private readonly UserManager<ApplicationUser> userManager; 

        public Context(DbContextOptions options) : base(options) 
        {
            //userManager = _userManager; 
        }
        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<News> news {  get; set; }
        public DbSet<Author> authors {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
   

            ApplicationUser user = new ApplicationUser
            {
                Id = "1",
                UserName = "saeed",
                NormalizedUserName = "SAEED",
                Email = "saeedm113@gmail.com",
                NormalizedEmail = "SAEEDM1113@GMAIL.COM",
                EmailConfirmed = true
            };

            string passwordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "123456");

            user.PasswordHash = passwordHash;

            builder.Entity<ApplicationUser>().HasData(user);



            //builder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        Id = "1",
            //        UserName = "saeed",
            //        NormalizedUserName = "SAEED",
            //        Email = "saeedm113@gmail.com",
            //        NormalizedEmail = "SAEEDM1113@GMAIL.COM",
            //        EmailConfirmed = true,
            //        PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword( , "123456") 
            //    });

            // builder.Entity<IdentityRole>().HasData(
            //     new IdentityRole<string>
            //     {
            //         Id = "1",
            //         Name = "Admin"
            //     },
            //      new IdentityRole<string>
            //      {
            //          Id = "2",
            //          Name = "User"
            //      }
            //);

            //       builder.Entity<Context>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        UserId = "1",
            //        RoleId = "1"
            //    }
            //);


            base.OnModelCreating(builder);
        }


        //private async Task SeedDefaultUser()
        //{
        //    // Check if the user already exists
        //    ApplicationUser existingUser = userManager.FindByNameAsync("saeed").Result;
        //    if (existingUser == null)
        //    {
        //        ApplicationUser newUser = new ApplicationUser
        //        {
        //            UserName = "saeed",
        //            Email = "saeedm113@gmail.com",
        //            EmailConfirmed = true
        //        };

        //        // Hash the password
        //        var passwordHash = new PasswordHasher<ApplicationUser>().HashPassword(newUser, "123456");

        //        newUser.PasswordHash = passwordHash;

        //        // Add the user to the database
        //        await userManager.CreateAsync(newUser);
        //    }
        //}
}
    }
