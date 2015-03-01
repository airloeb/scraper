using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scraper.Api;

namespace Scraper.Web.Models
{
    public class ReportsModel
    {
        public List<Item> Items { get; set; }

        public ReportsModel()
        {
            Items = new List<Item>();
        }
    }
}