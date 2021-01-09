using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedChartBloodWork.Models
{
    public class BloodWork
    {
        public Guid BloodWorkID { get; set; }
        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        public string DateCreated { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        public string ExamDate { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        public string ResultDate { get; set; }

        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [PersonalData]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9.-]*$", ErrorMessage = "Please enter numbers only.")]
        public string Hemoglobin { get; set; }

        [Required]
        [PersonalData]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9.-]*$", ErrorMessage = "Please enter numbers only.")]
        public string Hematocrit { get; set; }

        [Required]
        [PersonalData]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9.-]*$", ErrorMessage = "Please enter numbers only.")]
        public string WhiteBloodCellCount { get; set; }

        [Required]
        [PersonalData]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9.-]*$", ErrorMessage = "Please enter numbers only.")]
        public string RedBloodCellCount { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
