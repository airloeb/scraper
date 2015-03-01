using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.Api;

namespace Scraper.Data
{
    public class Repo
    {
        private readonly string _connection = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Scraper;Integrated Security=True";

        public void InsertLog(Log l)
        {
            var db = new LinkDataContext();
            db.Logs.InsertOnSubmit(l);
            db.SubmitChanges();
        }

        public void InsertProduct(Product p)
        {
            var db = new LinkDataContext();
            db.Products.InsertOnSubmit(p);
            db.SubmitChanges();
        }

        public Log GetRecentLog(int id)
        {
            using (var db = new LinkDataContext())
            {
                return db.Logs.Where(p => p.ProductId == id).OrderByDescending(d => d.Date).First();
            }
        }

        public bool CheckPrice(Item i)
        {
            using (var db = new LinkDataContext())
            {
                Product product = db.Products.Where(x => x.Title == i.Title).FirstOrDefault();
                if (product == null)
                {
                    Product p = new Product{Title = i.Title,Url = i.Url,Image = i.Image, Active = true};
                    InsertProduct(p);
                    Log newLog = new Log { Date = DateTime.Now, Price = (decimal)i.Price, ProductId = p.Id };
                    InsertLog(newLog);
                    return false;
                }
                Log log = GetRecentLog(product.Id);
                if ((double)log.Price > i.Price)
                {
                    Log newLog = new Log{Date = DateTime.Now,Price = (decimal)i.Price,ProductId = product.Id};
                    InsertLog(newLog);
                    Email.Send(i.Title,i.Price.ToString(),log.Price.ToString(),i.Url);
                    return true;
                }
                return false;
            }
        }

        public List<Product> GetProducts()
        {
            using (var db = new LinkDataContext())
            {
                return db.Products.Where(p => p.Active).ToList();
            }
        } 

        public void Run()
        {
            using (var db = new LinkDataContext())
            {
                List<Product> products = GetProducts();
                foreach (var product in products)
                {
                    CheckPrice(Searcher.Scrape(product.Url));
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new LinkDataContext())
            {
                Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
                product.Active = false;
                db.SubmitChanges();
            }
        }
    }
}
