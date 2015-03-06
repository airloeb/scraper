using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scraper.Api;
using Scraper.Data;

namespace Scraper.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Scrape(string url)
        {
            if (!url.Contains("bloomingdales.com/shop/product"))
            {
                return Redirect("/Home/Index");
            }
            Item product = Searcher.Scrape(url);
            Repo repo = new Repo();
            bool flag = repo.CheckPrice(product);

            return Redirect("/Reports/Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repo repo = new Repo();
            repo.Delete(id);
            return Redirect("/Reports/Index");
        }

    }
}
