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

        public ActionResult ChartCreator(string typ = "Column")
        {
            Chart chart = new Chart(500, 500);
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

            string imgPath = dir + "chart.jpeg";
            string xmlPath = dir + "chart.xml";

            chart.Save(imgPath, format: "jpeg");
            chart.SaveXml(xmlPath);

            return View(chart);
        }
    }

}