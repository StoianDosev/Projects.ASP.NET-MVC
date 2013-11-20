using Hangman.Data;
using Hangman.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Repository
{
    public class UowData : IUowData
    {
        private readonly DbContext context;

        private readonly DataContext db = new DataContext();

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();


        public UowData()
            : this(new DataContext())
        {

        }

        public UowData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Country> Countries
        {
            get { return this.GetRepository<Country>(); }
        }

       
        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        
    }
}
