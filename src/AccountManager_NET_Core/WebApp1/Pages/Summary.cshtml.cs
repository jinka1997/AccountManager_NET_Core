using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WebApp1.Pages
{
    public class SummaryModel : PageModel
    {
        public void OnGet()
        {

        }

        public IList<DetailItem> DetailItems { get; set; } = new List<DetailItem>();


        [BindProperty]
        public SearchItems SearchItem { set; get; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            //TODO ラジオボタンが渡ってこない。。。
            Console.WriteLine(SearchItem);

            //WebApi呼び出し
            var url = "http://localhost:50367/api/SumByYear";
            var dic = new Dictionary<string, object>
            {
                { "user_id", 1764565 },
                { "from_date", SearchItem.FromDate != DateTime.MinValue ? SearchItem.FromDate.ToString("yyyy-MM-dd") : "" },
                { "to_date", SearchItem.ToDate != DateTime.MinValue ? SearchItem.ToDate.ToString("yyyy-MM-dd") : "" }
            };
            var source = JToken.FromObject(dic);

            var result = RestApi.Execute(url, "POST", source);


            foreach (var t in result["items"])
            {
                var item = new DetailItem()
                {
                    Year = t["Year"].Value<int>(),
                    AccountTypeId = t["AccountTypeId"].Value<int>(),
                    Revenue = t["Revenue"].Value<int>(),
                    Expense = t["Expense"].Value<int>()
                };
                DetailItems.Add(item);
            }
        }

        public class DetailItem
        {
            public int Year { set; get; }
            public int AccountTypeId { set; get; }
            public int Revenue { set; get; }
            public int Expense { set; get; }
        }


        public class SearchItems
        {
            public DateTime FromDate { set; get; }
            public DateTime ToDate { set; get; }
            public string TypeYear { set; get; }
            public string TypeMonth { set; get; }
            public string TypeDay { set; get; }
        }

    }
}