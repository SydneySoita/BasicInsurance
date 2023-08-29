using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInsurance.Models.Models
{
    public class Undewritingcase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ApplicantName { get; set; }
        [Required]
        public string? Policytype { get; set;}
        [Required]
        public string? RiskDescription { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? HealthCondition { get; set; }
        [Required]
        public int Accidents { get; set; }

        public string? RiskResult { get; set; }

        public double? CoverageAmount { get; set; }
        public string? PaymentFrequency { get; set; }
        public double? PremiumAmount { get; set; }

    }
}
