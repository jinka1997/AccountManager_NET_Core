using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api31.Models;
using Microsoft.EntityFrameworkCore;
using Api31.Repositories;
using MediatR;
using Api31.Models.Enumeration;
using System.Collections.Immutable;

namespace Api31.Services.UseCase
{
    public class SearchDetailQueryHandler : IRequestHandler<SearchDetailQuery, ImmutableList<AccountDetail>>
    {
        private readonly AccountDetailRepository _repository;
        public SearchDetailQueryHandler(AccountDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImmutableList<AccountDetail>> Handle(SearchDetailQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll()
                .Where(d => d.Id == request.UserAccountId)
                .Where(d => string.IsNullOrEmpty(request.Remarks) || EF.Functions.Like(nameof(d.Remarks), $"%{request.Remarks}%"))
                .Where(d => request.From == null || d.SettlementDay >= request.From)
                .Where(d => request.To == null || d.SettlementDay <= request.To)
                .Include(d => d.AccountBook)
                .Include(d => d.AccountType)
                .Include(d => d.UserAccount);
            return await Task.Run(() => query.ToImmutableList());
        }
    }
}
