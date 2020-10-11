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
    public class AccountDetailRepository : Repository<AccountDetail> 
    {
        public AccountDetailRepository(AccountManagerContext dbContext) : base(dbContext)
        {
        }
    }
}
