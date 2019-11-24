using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RestApi.Controllers
{
    public class AccountDetailsController : ApiControllerBase
    {
        protected override Dictionary<string, object> PostDetail(MyDbContext context, JToken token)
        {
            var userId = token["user_id"].Value<int>();
            var dic = new Dictionary<string, object>();

            var details = from d in context.AccountDetails
                          join t in context.AccountTypes
                          on new { d.AccountTypeId, d.UserId } equals new { t.AccountTypeId, t.UserId }
                          where d.UserId == userId
                          select new
                          {
                              d.Id,
                              d.SettlementDay,
                              d.ItemNumber,
                              d.AccountTypeId,
                              t.AccountTypeName,
                              d.ExpenseOrRevenue,
                              d.Amount,
                              d.Remarks
                          };

            var keyword = token["keyword"].Value<string>();
            if (!string.IsNullOrEmpty(keyword))
            {
                details = details.Where(v => v.Remarks.Contains(keyword));
            }

            var fromDateString = token["from_date"].Value<string>();
            if (!string.IsNullOrEmpty(fromDateString))
            {
                var fromDate = DateTime.Parse(fromDateString);
                details = details.Where(v => (fromDate <= v.SettlementDay));

            }

            var toDateString = token["to_date"].Value<string>();
            if (!string.IsNullOrEmpty(toDateString))
            {
                var toDate = DateTime.Parse(toDateString);
                details = details.Where(v => (v.SettlementDay <= toDate));
            }

            var list = new List<Dictionary<string, object>>();
            foreach (var detail in details)
            {
                var dic0 = new Dictionary<string, object>();
                foreach (var prop in detail.GetType().GetProperties())
                {
                    var key = prop.Name;
                    var value = prop.GetValue(detail);
                    dic0.Add(key, value);
                }
                list.Add(dic0);
            }

            dic.Add("items", list);
            return dic;
        }
    }
}