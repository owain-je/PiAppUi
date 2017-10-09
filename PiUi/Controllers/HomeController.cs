using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PiUi.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index(int id)
        {

            var p = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "config");
            var builder = new ConfigurationBuilder().SetBasePath(p).AddJsonFile("appsettings.json");
            var Configuration = builder.Build();
            var ServiceAddress = Configuration["connection"];


            var i = this.HttpContext.Items;

            if(id == 0 )
            {
                id = 20;
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri (ServiceAddress);            
            HttpResponseMessage response = client.GetAsync(string.Format("/api/values/$0",id)).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            ViewData["Message"] = stringData;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
