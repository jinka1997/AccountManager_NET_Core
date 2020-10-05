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
    public class AccountDetailRepository
    {
        private readonly AccountManagerContext _dbContext;
        public AccountDetailRepository(AccountManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AccountDetail> GetDetail(long userAccountId, string remarks, DateTimeOffset from, DateTimeOffset to)
        {
            var query = _dbContext.AccountDetails
                .Include(d => d.AccountBook)
                .Include(d => d.AccountType)
                .Include(d => d.UserAccount)
                .Where(d => d.Id == userAccountId)
                .Where(d => string.IsNullOrEmpty(remarks) ||  EF.Functions.Like(nameof(d.Remarks), $"%{remarks}%"))
                .Where(d => from == null || d.SettlementDay >= from)
                .Where(d => to == null || d.SettlementDay <= to)
                .ToList();
            return query;

        }
    }
}
