using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scraper.Api;
using Scraper.Data;
using Scraper.Web.Models;

namespace Scraper.Web.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            Repo repo = new Repo();
            ReportsModel model = new ReportsModel();
            List<Product> products = repo.GetProducts();
            foreach (var product in products)
            {
                Item i = new Item{Id = product.Id ,Title = product.Title, Url = product.Url, Price = (double)repo.GetRecentLog(product.Id).Price,Image = product.Image};
                model.Items.Add(i);
            }
            return View(model);
        }



    }
}
