using Hangman.Data;
using Hangman.Models;
using Hangman.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangman.Web.Controllers
{
    public class BaseController : Controller
    {

        protected IUowData Data;
        

        protected NewUserManager userManager = new NewUserManager();

        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new UowData())
        {

        }
	}
}