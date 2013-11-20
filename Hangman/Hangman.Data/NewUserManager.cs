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
    public class NewUserManager : UserManager<ApplicationUser>
    {
        public NewUserManager()
            :base( new UserStore<ApplicationUser>(new DataContext()))
        {

        }
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return (Store as UserStore<ApplicationUser>).GetUsers();
        }
    }
}
