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
    public class DetailsModel : PageModel
    {
        public IList<DetailItem> DetailItems { get; set; } = new List<DetailItem>();

        [BindProperty]
        public SearchItems SearchItem { set; get; }

        public void OnGet()
        {
        }



        public void OnPost()
        {
            //WebApi呼び出し
            var url = "http://localhost:50367/api/Details";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";

            var dic = new Dictionary<string, object>
            {
                { "user_id", 1764565 },
                { "keyword", SearchItem.Keyword },
                { "from_date", SearchItem.FromDate.ToString("yyyy-MM-dd") },
                { "to_date", SearchItem.ToDate.ToString("yyyy-MM-dd") }
            };
            var source = JToken.FromObject(dic);

            var inputJson = JsonConvert.SerializeObject(source);

            byte[] byteArray = Encoding.UTF8.GetBytes(inputJson);
            req.ContentLength = byteArray.Length;
            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            var responseJson = "";
            using (var sr = new StreamReader(res.GetResponseStream()))
            {
                responseJson = sr.ReadToEnd();
            }
            var result = JsonConvert.DeserializeObject<JToken>(responseJson);


            foreach (var t in result["items"])
            {
                var item = new DetailItem()
                {
                    Id = t["Id"].Value<int>(),
                    SettlementDay = t["SettlementDay"].Value<DateTime>(),
                    ItemNumber = t["ItemNumber"].Value<int>(),
                    AccountTypeId = t["AccountTypeId"].Value<int>(),
                    AccountTypeName = t["AccountTypeName"].Value<string>(),
                    ExpenseOrRevenue = t["ExpenseOrRevenue"].Value<string>(),
                    Amount = t["Amount"].Value<int>(),
                    Remarks = t["Remarks"].Value<string>()
                };
                DetailItems.Add(item);
            }
        }

        public class DetailItem
        {
            public int Id { set; get; }
            public DateTime SettlementDay { set; get; }
            public int ItemNumber { set; get; }
            public int AccountTypeId { set; get; }
            public string AccountTypeName { set; get; }
            public string ExpenseOrRevenue { set; get; }
            public int Amount { set; get; }
            public string Remarks { set; get; }
        }

        public class SearchItems
        {
            public string Keyword { set; get; }
            public DateTime FromDate { set; get; }
            public DateTime ToDate { set; get; }
        }

    }
}