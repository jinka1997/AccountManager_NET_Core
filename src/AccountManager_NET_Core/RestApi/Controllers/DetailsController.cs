using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    public class DetailsController : ApiControllerBase
    {
        protected override Dictionary<string, object> PostDetail(MyDbContext context, JToken token)
        {
            var keyword = token["keyword"].Value<string>();

            var dic = new Dictionary<string, object>();
            var details = context.AccountDetails.Where(v => v.Remarks.Contains(keyword));

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