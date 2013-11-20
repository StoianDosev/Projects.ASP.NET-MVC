using Hangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Repository
{
    public interface IUowData : IDisposable
    {

        IRepository<Country> Countries { get; }

        int SaveChanges();
    }
}
