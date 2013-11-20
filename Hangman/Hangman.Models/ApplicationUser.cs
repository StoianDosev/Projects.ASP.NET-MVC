using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Score { get; set; }

        public string Email { get; set; }
    }
}
