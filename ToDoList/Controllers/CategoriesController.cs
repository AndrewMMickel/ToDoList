using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ToDoListContext _db;

        public CategoriesController(ToDoListContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Category> model = _db.Categories.Include(category => category.Items).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Category thisCategory = _db.Categories.Include(category => category.Items).FirstOrDefault(Category => Category.CategoryId == id);
            return View(thisCategory);
        }

    }
}