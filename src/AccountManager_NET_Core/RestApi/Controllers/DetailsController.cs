using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RestApi.Controllers
{
    public class DetailsController : ApiControllerBase
    {
        protected override Dictionary<string, object> PostDetail(MyDbContext context, JToken token)
        {
            var dic = new Dictionary<string, object>();

            var details = from d in ExtractDetails(context,token)
                          join t in context.AccountTypes
                          on new { d.AccountTypeId, d.UserId } equals new { t.AccountTypeId, t.UserId }
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

            var orderedDetails = details.OrderBy(v => v.SettlementDay).ThenBy(v => v.ItemNumber);

            var list = new List<Dictionary<string, object>>();
            foreach (var detail in orderedDetails)
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