using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ChartApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChartCreator(string typ = "Column", string cache = "chart.jpeg")
        {
            Chart chart = Chart.GetFromCache(cache);

            if (chart == null)
            {
                chart = new Chart(500, 500);

                chart.AddTitle("Product Order Detail");
                chart.AddLegend("Product");

                chart.AddSeries(
                    name: "Computer A",
                    chartType: typ,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 800, 1200, 2300 }
                );

                chart.AddSeries(
                    name: "Computer B",
                    chartType: typ,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 900, 1600, 3300 }
                );

                string dir = Server.MapPath("~/Files/");

                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }

                string imgPath = dir + cache + ".jpeg";
                string xmlPath = dir + cache + ".xml";

                chart.Save(imgPath, format: "jpeg");
                chart.SaveXml(xmlPath);
                chart.SaveToCache(cache, 10, true);
            }

            return View(chart);
        }

        public ActionResult ChartCreatorPie(string typ = "Pie", string cache = "chart-pie.jpeg")
        {
            Chart chart = Chart.GetFromCache(cache);

            if (chart == null)
            {
                chart = new Chart(500, 500);

                chart.AddTitle("Product Order Detail");
                chart.AddLegend("Product");

                chart.AddSeries(
                    name: "Products",
                    chartType: typ,
                    xValue: new[] { "Computer", "Mouse", "Keyboard", "Monitor" },
                    yValues: new[] { 800, 1200, 2300, 4000 }
                );

                string dir = Server.MapPath("~/Files/");

                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }

                string imgPath = dir + cache + ".jpeg";
                string xmlPath = dir + cache + ".xml";

                chart.Save(imgPath, format: "jpeg");
                chart.SaveXml(xmlPath);
                chart.SaveToCache(cache, 10, true);
            }

            return View("ChartCreator", chart);
        }
    }

}