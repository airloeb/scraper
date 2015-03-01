using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsQuery;

namespace Scraper.Api
{
    public static class Searcher
    {

        public static Item Scrape(string url)
        {
            var web = new MyWebClient();
            web.Headers[HttpRequestHeader.UserAgent] = "Amazon is awful!!";
            web.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, sdch";
            var html = web.DownloadString(url);
            return GetInfo(html,url);
        }

        public static Item GetInfo(string html,string url)
        {
            CQ dom = html;
            string myTempPrice = dom.Find(".netPrice:first").Val();
            //if (myTempPrice == null)
            //{
            //    myTempPrice = dom.Find("span[class=priceBig]:first").Text();
            //}
            string myPrice = myTempPrice.Substring(myTempPrice.IndexOf('$') + 1);
            string title = dom.Find("#productTitle").Text();
            string image = dom.Find("#productImage").Attr("src");
            double price = double.Parse(myPrice);
            Item p = new Item { Title = title, Price = price, Url = url, Image = image};
            return p;
        }
    }
}
