using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Api31.Models;
using MediatR;

namespace Api31.Services.UseCase
{
    public class SearchDetailQuery : IRequest<ImmutableList<AccountDetail>>
    {
        //全部にUserAccountId使うのなら、共通化が必要かね。
        public long UserAccountId { get; private set; }
        public DateTime? From { get; private set; }
        public DateTime? To { get; private set; }
        public string Remarks { get; private set; }

        public SearchDetailQuery(long userAccountId, string remarks , string fromString, string toString)
        {
            UserAccountId = userAccountId;
            Remarks = remarks;
            if (!string.IsNullOrEmpty(fromString))
            {
                From = DateTime.Parse($"{fromString.Substring(0, 4)}/{fromString.Substring(4, 2)}/{fromString.Substring(6, 2)}");
            }
            if (!string.IsNullOrEmpty(toString))
            {
                To = DateTime.Parse($"{toString.Substring(0, 4)}/{toString.Substring(4, 2)}/{toString.Substring(6, 2)}");
            }
        }
    }
}
