using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Api31.Models;
using Api31.Models.Enumeration;
using Microsoft.EntityFrameworkCore;


namespace Api31.Repositories
{
    public class Repository<T> where T : Entity
    {
        protected readonly AccountManagerContext _db;
        public Repository(AccountManagerContext acContext)
        {
            _db = acContext;
        }

        public DbSet<T> GetAll()
        {
            var table = _db.Set<T>();
            return table;
        }
    }
}
