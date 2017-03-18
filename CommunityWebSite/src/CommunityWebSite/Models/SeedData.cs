using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using CommunityWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CommunityWebSite.Models {
    public class SeedData {
        public static async Task EnsurePopulated(IApplicationBuilder app) {


            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            // Add a user for testing
            string firstName = "Alphonze";
            string lastName = "Elrich";
            string username = firstName + lastName;
            string email = "Fullmetal@alchemy.org";
            string password = "Transmute1!";
            string role = "Member";

            string firstNameAdmin = "Al";
            string lastNameAdmin = "Elrich";
            string usernameAdmin = firstNameAdmin + lastNameAdmin;
            string emailAdmin = "metal@alchemy.org";
            string passwordAdmin = "Transmute2!";
            string roleAdmin = "Admin";

            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            if (!context.Messages.Any() || userManager.Users.Count() != 0) {

                User user = await userManager.FindByNameAsync(username);
                if (user == null) {
                    user = new User { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (await roleManager.FindByNameAsync(role) == null) {
                        await roleManager.CreateAsync(new IdentityRole(role));
                        if (result.Succeeded) {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }

                User userAdmin = await userManager.FindByNameAsync(usernameAdmin);
                if (userAdmin == null) {
                    userAdmin = new User { FirstName = firstNameAdmin, LastName = lastNameAdmin, UserName = usernameAdmin,
                        Email = emailAdmin
                    };
                    IdentityResult result = await userManager.CreateAsync(userAdmin, passwordAdmin);
                    if (await roleManager.FindByNameAsync(roleAdmin) == null) {
                        await roleManager.CreateAsync(new IdentityRole(roleAdmin));
                        if (result.Succeeded) {
                            await userManager.AddToRoleAsync(userAdmin, roleAdmin);
                        }
                    }
                }


                var member = new Member { FirstName = "John", LastName = "Doe", Email = "doej@gmail.com" };
                context.Members.Add(member);
                var message = new Message {
                    Subject = "Test Subject omicron", Body = "blah blah blah", Date = new DateTime(2017, 1, 1),
                    Sender = member,
                    Topic = "Topic A"
                };
                context.Messages.Add(message);

                message = new Message {
                    Subject = "Test Subject omega", Body = "blah blah blah", Date = new DateTime(2016, 6, 5),
                    Sender = member,
                    Topic = "Topic A"
                };
                context.Messages.Add(message);

                member = new Member { FirstName = "George", LastName = "Lucas", Email = "starwarsfan@gmail.com" };
                context.Members.Add(member);

                message = new Message {
                    Subject = "Test Subject alpha", Body = "blah blah blah", Date = new DateTime(2017, 1, 31),
                    Sender = member,
                    Topic = "Topic B"

                };
                context.Messages.Add(message);

                message = new Message {
                    Subject = "Test Subject delta", Body = "blah blah blah", Date = new DateTime(2016, 12, 1),
                    Sender = member,
                    Topic = "Topic C"
                };
                context.Messages.Add(message);

                member = new Member { FirstName = "Jane", LastName = "Dee", Email = "deej@gmail.com" };
                context.Members.Add(member);

                message = new Message {
                    Subject = "Test Subject beta", Body = "blah blah blah", Date = new DateTime(2017, 2, 10),
                    Sender = member,
                    Topic = "Topic C"
                };
                context.Messages.Add(message);
                message = new Message {
                    Subject = "Test Subject sigma", Body = "blah blah blah", Date = new DateTime(2016, 4, 1),
                    Sender = member,
                    Topic = "Topic B"
                };
                context.Messages.Add(message);
            }
            context.SaveChanges();
        }
    }
}
