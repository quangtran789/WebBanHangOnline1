using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Areas.Admin.Controllers.Facade;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        private readonly IStatisticalFacade _statisticalFacade;

        public StatisticalController()
        {
            _statisticalFacade = new StatisticalFacade();
        }

        // GET: Admin/Statistical
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStatistical(string fromDate, string toDate)
        {
            var statisticalData = _statisticalFacade.GetStatisticalData(fromDate, toDate);
            return Json(statisticalData, JsonRequestBehavior.AllowGet);
        }
    }

}