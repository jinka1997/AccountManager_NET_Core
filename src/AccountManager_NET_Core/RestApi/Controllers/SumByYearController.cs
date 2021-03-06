﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace RestApi.Controllers
{
    public class SumByYearController : ApiControllerBase
    {
        protected override Dictionary<string, object> PostDetail(MyDbContext context, JToken token)
        {
            var dic = new Dictionary<string, object>();

            var details = from d in ExtractDetails(context, token)
                          group d by new { d.SettlementDay.Year, d.AccountTypeId } into g
                          select new
                          {
                              g.Key.Year,
                              g.Key.AccountTypeId,
                              Revenue = g.Sum(v => v.ExpenseOrRevenue == "0" ? v.Amount : 0),
                              Expense = g.Sum(v => v.ExpenseOrRevenue == "1" ? v.Amount : 0),
                          };


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