using Hangman.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Data
{
    public class InitializeDatabase : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //creating role admin
            string adminRole = "admin";

            roleManager.Create(new IdentityRole(adminRole));

            string userName = "Admin";
            string password = "123456";

            //creating user
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userName
            };

            var resultUser = userManager.Create(user, password);

            if (resultUser.Succeeded)
            {
                userManager.AddToRole(user.Id, adminRole);
            }

            context.Countries.Add(new Country { Name = "Bulgaria" });
            context.Countries.Add(new Country { Name = "Greece" });
            context.Countries.Add(new Country { Name = "Russia" });
            context.Countries.Add(new Country { Name = "Iran" });
        }
    }
}
