using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _dbContext.categories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "category added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get
        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _dbContext.categories.Find(id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }    

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _dbContext.categories.Find(id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbContext.categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _dbContext.categories.Remove(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Category deleted Successfully";
                return RedirectToAction("Index");      
        }
    }
  }
