using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RestApi.Models;
using System.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        [HttpPost]
        public JToken Post(JToken token)
        {
            var dic = new Dictionary<string, object>();
            try
            {
                using (var con = GetNewConnection())
                {
                    var oB = new DbContextOptionsBuilder<MyDbContext>();
                    oB.UseSqlServer(con);

                    using (var context = new MyDbContext(oB.Options))
                    {

                        dic = PostDetail(context, token);
                    }
                }
            }
            catch (Exception ex)
            {
                dic.Add("message", ex.Message);
                dic.Add("stack_trace", ex.StackTrace);
            }
            return JToken.FromObject(dic);
        }

        protected virtual Dictionary<string, object> PostDetail(MyDbContext context, JToken token)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetNewConnection()
        {
            var cnc = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AccountManage_Local;Integrated Security=True;");
            cnc.Open();
            return cnc;
        }

        protected IQueryable<AccountDetail> ExtractDetails(MyDbContext context, JToken token)
        {
            var userId = token["user_id"].Value<int>();

            var details = context.AccountDetails.Where(v => v.UserId == userId);

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
            return details;
        }
    }
}
