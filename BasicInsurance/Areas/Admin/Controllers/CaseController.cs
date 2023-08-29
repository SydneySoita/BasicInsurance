using BasicInsurance.DataAccess.Repository;
using BasicInsurance.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;

namespace BasicInsurance.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CaseController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        private readonly ILogger<CaseController> _logger;
        private double basePremiumRate = 0.2;


        public CaseController(IUnitofwork db, ILogger<CaseController> logger)
        {
            _unitofwork = db;
            _logger = logger;

        }

        public IActionResult Index()
        {
            List<Undewritingcase> objCasesList = _unitofwork.Underwritingcase.GetAll().ToList();
            return View(objCasesList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Undewritingcase obj) 
        {
            if (ModelState.IsValid)
            {
                //Calculate Premium
                double healthRisk = CalculateHealthConditionFactor(obj.HealthCondition);
                double drivingRisk = CalculateDrivingHistoryFactor(obj.Accidents);
                double ageRisk = CalculateAgeFactor(obj.Age);
                double totalRisk = CalculateTotalRiskFactor(healthRisk, drivingRisk, ageRisk);
                double totalPremium = CalculatePremium((double)obj.CoverageAmount, totalRisk);
                double finalPremium = ApplyPaymentFrequencyAdjustment(totalPremium, obj.PaymentFrequency);
                double roundedPremium = Math.Floor(finalPremium * 100) / 100;
                obj.PremiumAmount = roundedPremium;


                //Calculate Risk
                string riskLevel = AssessRisk(obj.Age, obj.HealthCondition, obj.Accidents);
                obj.RiskResult = riskLevel;

                _unitofwork.Underwritingcase.Add(obj);
                _unitofwork.Save();

                _logger.LogInformation("New case created successfully");
                TempData["success"] = "Case added successfully";
                return RedirectToAction("Index");
            }
            _logger.LogWarning("Failed to create case due to validation errors");
            return View(obj);
        }
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }

            Undewritingcase? caseFromDb = _unitofwork.Underwritingcase.Get(u => u.Id == Id);

            if (caseFromDb == null)
            {
                return NotFound();
            }

            return View(caseFromDb);

        }
        [HttpPost]

        public IActionResult Edit(Undewritingcase obj)
        {
            if (ModelState.IsValid)
            {
                //Calculate Premium
                double healthRisk = CalculateHealthConditionFactor(obj.HealthCondition);
                double drivingRisk = CalculateDrivingHistoryFactor(obj.Accidents);
                double ageRisk = CalculateAgeFactor(obj.Age);
                double totalRisk = CalculateTotalRiskFactor(healthRisk, drivingRisk, ageRisk);
                double totalPremium = CalculatePremium((double)obj.CoverageAmount, totalRisk);
                double finalPremium = ApplyPaymentFrequencyAdjustment(totalPremium, obj.PaymentFrequency);
                double roundedPremium = Math.Floor(finalPremium * 100)/100;
                obj.PremiumAmount = roundedPremium;

                //Calculate Risk
                string riskLevel = AssessRisk(obj.Age, obj.HealthCondition, obj.Accidents);
                obj.RiskResult = riskLevel;

                _unitofwork.Underwritingcase.Update(obj);
                _unitofwork.Save();
                TempData["success"] = "Case edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Undewritingcase? caseFromDb = _unitofwork.Underwritingcase.Get(u => u.Id == Id);
            if (caseFromDb == null)
            {
                return NotFound();
            }
            return View(caseFromDb);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteCase(int Id)
        {
            Undewritingcase? obj = _unitofwork.Underwritingcase.Get(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitofwork.Underwritingcase.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = "Case deleted successfully";
            return RedirectToAction("Index");
        }

        private string AssessRisk(int age, string healthCondition, int accidents)
        {
            if (age < 25)
            {
                return "High";
            }
            else if (age >= 25 && age <= 65)
            {
                if (healthCondition.ToLower() == "bad" || accidents > 0)
                {
                    return "Moderate";
                }
                else
                {
                    return "Low";
                }
            }
            else
            {
                if (healthCondition.ToLower() == "bad" || accidents > 1)
                {
                    return "High";
                }
                else
                {
                    return "Moderate";
                }
            }
        }
        private double CalculatePremium(double coverageAmount, double adjustedBasePremiumRate)
        {
            return coverageAmount * adjustedBasePremiumRate;
        }

        static double ApplyPaymentFrequencyAdjustment(double premium, string paymentFrequency)
        {
            switch (paymentFrequency)
            {
                case "annual":
                    return premium;
                case "semi-annual":
                    return premium / 2;
                case "quarterly":
                    return premium / 4;
                case "monthly":
                    return premium / 12;
                default:
                    return premium;
            }
        }

           

        static double CalculateHealthConditionFactor(string healthCondition)
        {
            // Assign risk factors based on health condition
            switch (healthCondition.ToLower())
            {
                case "good":
                    return 0.8;
                case "average":
                    return 1.0;
                case "bad":
                    return 1.2;
                default:
                    return 1.0; 
            }
        }

        static double CalculateDrivingHistoryFactor(int accidentsLastYear)
        {
            // Assign risk factors based on number of accidents last year
            if (accidentsLastYear == 0)
            {
                return 0.8;
            }
            else if (accidentsLastYear == 1)
            {
                return 1.2;
            }
            else
            {
                return 1.5;
            }
        }
        static double CalculateAgeFactor(int age)
        {
            // Assign risk factors based on age
            if (age < 25)
            {
                return 1.5;
            }
            else if (age >= 25 && age <= 65)
            {
                return 1.0;
            }
            else
            {
                return 1.2;
            }
        }
       double CalculateTotalRiskFactor(double healthFactor, double drivingFactor, double ageFactor)
        {
            // Calculate the total risk factor by multiplying individual factors
            double RiskAdjustment = healthFactor * drivingFactor * ageFactor;
            double TotalRisk = RiskAdjustment + basePremiumRate;

            return TotalRisk;
        }

    }
}
