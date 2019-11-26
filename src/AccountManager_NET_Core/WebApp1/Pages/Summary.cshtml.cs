using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp1.Pages
{
    public class SummaryModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public SearchItems SearchItem { set; get; }

        public void OnPost()
        {
            //TODO ラジオボタンが渡ってこない。。。
            Console.WriteLine(SearchItem);
        }

        public class SearchItems
        {
            public DateTime FromDate { set; get; }
            public DateTime ToDate { set; get; }
            public object TypeYear { set; get; }
            public object TypeMonth { set; get; }
            public object TypeDay { set; get; }
        }

    }
}