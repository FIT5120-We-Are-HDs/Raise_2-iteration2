using Raise_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Raise_1.Controllers
{
    public class HomeController : Controller
    {
        private RiseDb db = new RiseDb();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            ViewBag.Message = GetSummaryList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public List<Records> GetSummaryList()
        {
            var summaryList = db.Summary.Include(w => w.Topic);

            summaryList = summaryList.Include(w => w.Topic).OrderByDescending(t => t.summary_year);

            List<Records> res = new List<Records>();

            foreach (var item in summaryList.ToList())
            {
                Records rec = new Records{SumTitle = item.Topic.topic_name, SumValue = item.summary_value, SumWord = item.summary_imp};
                res.Add(rec);
            }

            return res;   
            
        }
    }
}