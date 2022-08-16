using BullyBookWeb.Data.Repository.IRepository;
using BullyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullyBookWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverList = _unitOfWork.Cover.GetAll();
            return View(coverList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cover.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var cover= _unitOfWork.Cover.GetFirstOrDefault(u => u.Id == id);

            if (cover== null)
            {
                return NotFound();
            }

            return View(cover);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
        
            if (ModelState.IsValid)
            {
                _unitOfWork.Cover.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cover = _unitOfWork.Cover.GetFirstOrDefault(u => u.Id == id);
            if (cover == null)
            {
                return NotFound();
            }

            return View(cover);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cover = _unitOfWork.Cover.GetFirstOrDefault(u => u.Id == id);
            if (cover == null)
            {
                return NotFound();
            }
            _unitOfWork.Cover.Remove(cover);
            _unitOfWork.Save();
            TempData["success"] = "Successfully";
            return RedirectToAction("Index");
        }
    }
}