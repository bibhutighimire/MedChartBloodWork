using MedChartBloodWork.Data;
using MedChartBloodWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedChartBloodWork.Controllers
{
    public class BloodWorkController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BloodWorkController> _logger;

        public BloodWorkController(ILogger<BloodWorkController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext  context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
           
        }
        //This shows list of all blood work of that specific patient using ID
        public async Task<IActionResult> Index()
        {
            //this will assign entire data of ASPNETUSERS Table value to user. This is how we capture ID of patient using this application if they are signed in
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //This will filter the list of bloodwork only of the specific patient who has signed in and stores them in List and sends to vIEW PAGE
            List<BloodWork> ListOfBloodWork = _context.BloodWork.Where(x => x.ApplicationUserID == user.Id).ToList();
            return View(ListOfBloodWork);
        }

        //Adding new blood work . Below code will throw to add new bloodwork viewpage
        [HttpGet]
        public IActionResult AddBloodWork()
        {
            //this will assign entire data of ASPNETUSERS Table value to user. This is how we capture ID of patient using this application if they are signed in
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            //var BloodWorkAddPatient = _context.BloodWork.Where(x => x.ApplicationUserID == user.Id).FirstOrDefault();
            return View();
        }

        //Below actionmethod has parameter which has data from add new blood work form that will be added to tables
        [HttpPost]
        public async Task<IActionResult> AddBloodWork(BloodWork bloodwork)
        {
            //this will assign entire data of ASPNETUSERS Table value to user. This is how we capture ID of patient using this application if they are signed in
            var user = await _userManager.GetUserAsync(HttpContext.User);
            //Instantiating method to assign data that came from form to ta database table
            BloodWork bWork = new BloodWork();
            bWork.DateCreated = bloodwork.DateCreated;
            bWork.ExamDate = bloodwork.ExamDate;
            bWork.ResultDate = bloodwork.ResultDate;
            bWork.Description = bloodwork.Description;
            bWork.Hemoglobin = bloodwork.Hemoglobin;
            bWork.Hematocrit = bloodwork.Hematocrit;
            bWork.WhiteBloodCellCount = bloodwork.WhiteBloodCellCount;
            bWork.RedBloodCellCount = bloodwork.RedBloodCellCount;
            bWork.ApplicationUserID = user.Id;
            //Adds record in new row and saves changes
            _context.BloodWork.Add(bWork);
            _context.SaveChanges();
            //The code below will send to Index page which has list of patient's blood work
            return RedirectToAction("Index");
        }
        [HttpGet]
        //This shows the Edit View
        public async Task<IActionResult> Edit(BloodWork bloodWordID)
        {
            //this will assign entire data of ASPNETUSERS Table value to user. This is how we capture ID of patient using this application if they are signed in
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //This will filter the list of bloodwork only of the specific patient who has signed in and stores them in List and sends to vIEW PAGE
           var ToBeEditedPatient= _context.BloodWork.Where(x => x.BloodWorkID == bloodWordID).FirstOrDefault();
            return View(ToBeEditedPatient);
        }

        [HttpPost]
        //This is bringing new data in the parameter which is updated in form 
        public async Task<IActionResult> Edit(BloodWork bloodWork)
        {
            //this will assign entire data of ASPNETUSERS Table value to user. This is how we capture ID of patient using this application if they are signed in
            var user = await _userManager.GetUserAsync(HttpContext.User);
            //Instantiating method to assign data that came from form to ta database table
            BloodWork bWork = new BloodWork();
            bWork.DateCreated = bloodWork.DateCreated;
            bWork.ExamDate = bloodWork.ExamDate;
            bWork.ResultDate = bloodWork.ResultDate;
            bWork.Description = bloodWork.Description;
            bWork.Hemoglobin = bloodWork.Hemoglobin;
            bWork.Hematocrit = bloodWork.Hematocrit;
            bWork.WhiteBloodCellCount = bloodWork.WhiteBloodCellCount;
            bWork.RedBloodCellCount = bloodWork.RedBloodCellCount;
            bWork.ApplicationUserID = user.Id;
            //Updates record in existing row and saves changes
            _context.Update(bWork);
            _context.SaveChanges();
            //The code below will send to Index page which has list of patient's blood work
            return RedirectToAction("Index");
        }

        [HttpGet]
        //This shows the Details View
        public async Task<IActionResult> Details(string bloodworkID)
        {
            //this will assign entire data of ASPNETUSERS Table value to user. This is how we capture ID of patient using this application if they are signed in
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //This will filter the list of bloodwork only of the specific patient who has signed in and stores them in List and sends to vIEW PAGE
            var DetailsOfAPatient = _context.BloodWork.Where(x => x.BloodWorkID == bloodworkID).FirstOrDefault();
            return View(DetailsOfAPatient);
        }

    }
}
