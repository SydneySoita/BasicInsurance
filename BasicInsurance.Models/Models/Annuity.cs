using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BasicInsurance.Models.Models
{
    public class Annuity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContractName { get; set; }
        [Required]
        public int PrincipalAmount { get; set; }
        [Required]
        public double IntrestRate { get; set;}
        [Required]
        public int NumberofPayments { get; set; }
        [Required]
        public string PaymentFrequency { get; set; }
        public double? PaymentAmount { get; set; }
    }
}
