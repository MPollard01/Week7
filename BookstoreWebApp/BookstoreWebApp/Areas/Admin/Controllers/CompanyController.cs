using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var company = new Company();

            if(id == null || id == 0)
            {
                return View(company);
            }

            company = _unitOfWork.Company.Find(id);
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if(company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Company updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(company);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Company.GetAll();
            return Json(new {data = result});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var company = _unitOfWork.Company.Find(id);
            if(company == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(company);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
