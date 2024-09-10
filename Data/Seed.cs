using Microsoft.AspNetCore.Identity;
using mvcprojekts.Data.Enum;
using mvcprojekts.Models;

namespace mvcprojekts.Data

{
    public class Seed
        {
            public static void SeedData(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                    if (!context.Clubs.Any())
                    {
                        context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Arkādija",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "Lielkungu Ila 35B",
                                City = "Daugavpils",
                                Region = "Latgale"
                            }
                         },
                        new Club()
                        {
                            Title = "Adidas Running",
                            Image = "https://www.eatthis.com/wp-conStent/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Endurance,
                            Address = new Address()
                            {
                                Street = "Graudu Iela 18",
                                City = "Liepāja",
                                Region = "Kurzeme"
                            }
                        },
                        new Club()
                        {
                            Title = "Nike Running",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Trail,
                            Address = new Address()
                            {
                                Street = "Dārzu Iela 2A",
                                City = "Jelgava",
                                Region = "Zemgale"
                            }
                        },
                        new Club()
                        {
                            Title = "Nike Running",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "Vesetas Iela 28",
                                City = "Rīga",
                                Region = "Vidzeme"
                            }
                        }
                    });
                        context.SaveChanges();
                    }
                    //Races
                    if (!context.Races.Any())
                    {
                        context.Races.AddRange(new List<Race>()
                    {
                        new Race()
                        {
                            Title = "Arkādija",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                            }
                        },
                        new Race()
                        {
                            Title = "Adidas Running",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            RaceCategory = RaceCategory.Ulthra,
                            //AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                Region = "NC"
                            }
                        }
                    });
                        context.SaveChanges();
                    }
                }
            }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            Region = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            Region = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
    }


