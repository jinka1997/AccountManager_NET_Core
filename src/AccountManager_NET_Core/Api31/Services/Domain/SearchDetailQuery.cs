using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api31.Models;
using MediatR;

namespace Api31.Services.Domain
{
    public class SearchDetailQuery : IRequest<AccountDetail>
    {
        
    }
    public class SearchDetailQueryCommand : IRequest
    {
        //全部にUserAccountId使うのなら、共通化が必要かね。
        public long UserAccountId { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public string Remarks { get; private set; }

        public SearchDetailQueryCommand(long userAccountId, string remarks, DateTime from ,DateTime to)
        {
            UserAccountId = userAccountId;
            Remarks = remarks;
            From = from;
            To = to;
        }
    }
}
