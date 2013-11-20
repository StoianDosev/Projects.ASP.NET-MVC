using Hangman.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> Countries { get; set; }

        public DataContext()
        {
        }
    }
}
