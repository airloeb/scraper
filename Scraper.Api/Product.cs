using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Api
{
    public class Item
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
