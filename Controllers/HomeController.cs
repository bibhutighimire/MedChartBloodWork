using MedChartBloodWork.Data;
using MedChartBloodWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MedChartBloodWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public ActionResult GetData()
        //{
           
        //    var query = _context.BloodWork
        //           .GroupBy(p => p.ExamDate)
        //           .Select(g => new { name = g.Key, count = g.Sum(w => w.Hemoglobin) }).ToList();
        //    return Json(query, JsonRequestBehavior.AllowGet);
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
