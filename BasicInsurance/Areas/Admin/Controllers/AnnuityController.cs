using BasicInsurance.DataAccess.Repository;
using BasicInsurance.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Protocol;

namespace BasicInsurance.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnuityController : Controller
    {
        private readonly IUnitofwork _unitofwork;
  
        public AnnuityController(IUnitofwork db)
        {
            _unitofwork = db;

        }

        public IActionResult Index()
        {
            List<Annuity> objAnnuityList = _unitofwork.Annuity.GetAll().ToList();
            return View(objAnnuityList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Annuity obj)
        {
            if (ModelState.IsValid)
            {
                double paymentAmount = CalculatePMT(obj.PrincipalAmount, obj.IntrestRate, obj.NumberofPayments);
                double finalamount = ApplyPaymentFrequencyAdjustment(paymentAmount, obj.PaymentFrequency);

                obj.PaymentAmount = finalamount;

              

                _unitofwork.Annuity.Add(obj);
                _unitofwork.Save();
                TempData["success"] = "Case added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Annuity? valFromDb = _unitofwork.Annuity.Get(u => u.Id == Id);

            if (valFromDb == null)
            {
                return NotFound();
            }

            return View(valFromDb);

        }
        [HttpPost]

        public IActionResult Edit(Annuity obj)
        {
            if (ModelState.IsValid)
            {
                double paymentAmount = CalculatePMT(obj.PrincipalAmount, obj.IntrestRate, obj.NumberofPayments);
                double finalamount = ApplyPaymentFrequencyAdjustment(paymentAmount, obj.PaymentFrequency);

                obj.PaymentAmount = finalamount;


                _unitofwork.Annuity.Update(obj);
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

            Annuity? valFromDb = _unitofwork.Annuity.Get(u => u.Id == Id);
            if (valFromDb == null)
            {
                return NotFound();
            }
            return View(valFromDb);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteCase(int Id)
        {
            Annuity? obj = _unitofwork.Annuity.Get(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitofwork.Annuity.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = "Case deleted successfully";
            return RedirectToAction("Index");
        }


        static double CalculatePMT(double principalAmount, double interestRate, int numberOfPayments)
        {
            interestRate = interestRate / 100;  // Convert interest rate to decimal form
            double ratePlusOne = 1 + interestRate;

            double numerator = principalAmount * interestRate * Math.Pow(ratePlusOne, numberOfPayments);
            double denominator = Math.Pow(ratePlusOne, numberOfPayments) - 1;

            double paymentAmount = numerator / denominator;

            return paymentAmount;
        }

        static double ApplyPaymentFrequencyAdjustment(double PaymentAmount, string paymentFrequency)
        {
            switch (paymentFrequency)
            {
                case "annual":
                    return PaymentAmount;
                case "semi-annual":
                    return PaymentAmount / 2;
                case "quarterly":
                    return PaymentAmount / 4;
                case "monthly":
                    return PaymentAmount / 12;
                default:
                    return PaymentAmount;
            }
        }

    }
}
