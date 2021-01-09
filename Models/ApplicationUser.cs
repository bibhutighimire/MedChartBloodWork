using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedChartBloodWork.Models
{
    public class ApplicationUser:IdentityUser
    {
        public BloodWork BloodWork { get; set; }
    }
}
