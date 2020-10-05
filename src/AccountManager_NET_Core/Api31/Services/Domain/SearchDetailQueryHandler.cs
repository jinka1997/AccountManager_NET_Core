using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api31.Models;
using Api31.Repositories;
using MediatR;

namespace Api31.Services.Domain
{
    public class SearchDetailQueryHandler : IRequestHandler<SearchDetailQuery, AccountDetail>
    {
        private readonly AccountDetailRepository _repository;
        public SearchDetailQueryHandler(AccountDetailRepository repository)
        {
            _repository = repository;
        }

        public Task<AccountDetail> Handle(SearchDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
