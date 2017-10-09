using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.IO;
using Microsoft.Extensions.Configuration;
using log4net;

namespace PiUi.Controllers
{
    public class HomeController : Controller
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public IActionResult Index(int id)
        {

            log.Info(string.Format("home request id is : {0}", id));


            var p = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "config");
            var builder = new ConfigurationBuilder().SetBasePath(p).AddJsonFile("appsettings.json");
            var Configuration = builder.Build();
            var ServiceAddress = Configuration["pi_app_service"];


            var i = this.HttpContext.Items;

            if (id == 0)
            {
                id = 20;
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri(ServiceAddress);
            log.Debug(string.Format("calling {0} /api/values/{1}", id, ServiceAddress));
            HttpResponseMessage response = client.GetAsync(string.Format("/api/values/{0}", id)).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            ViewData["Message"] = stringData;
            log.Debug(string.Format("Response: {0}", stringData));
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
