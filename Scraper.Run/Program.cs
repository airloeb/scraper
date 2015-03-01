using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.Data;

namespace Scraper.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Repo repo = new Repo();
            repo.Run();
        }
    }
}
