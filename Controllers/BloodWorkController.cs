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

        public IActionResult Index()
        {
            return View();
        }
    }
}
