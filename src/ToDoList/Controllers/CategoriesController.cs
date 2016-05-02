using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        private ToDoListContext _db;

        public CategoriesController(ToDoListContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(GetAllCategories());
        }

        // GET: /categories/create
        public IActionResult Create()
        {
            return View();
        }

        //Post: /categories/create/
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();

            return View("Index", GetAllCategories());
        }

        //Post: /categories/Delete
        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            var doomedCategory = _db.Categories.FirstOrDefault(m => m.CategoryId == categoryId);
            _db.Categories.Remove(doomedCategory);
            _db.SaveChanges();

            return View("index", GetAllCategories());
        }

        [NonAction]
        public IEnumerable<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
    }
}