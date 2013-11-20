using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Hangman.Models;

namespace Hangman.Data
{
    
    public static class Extensions
    {
        public static IDbSet<ApplicationUser> GetUsers(this UserStore<ApplicationUser> userStore)
        {
            return (userStore.Context as IdentityDbContext<ApplicationUser>).GetUsers();
        }

        public static IDbSet<ApplicationUser> GetUsers(this IdentityDbContext<ApplicationUser> context)
        {
            return context.Users;
        }
    }
}
