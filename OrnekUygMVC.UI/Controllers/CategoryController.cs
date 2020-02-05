using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekUyg.BLL.Abstract;
using OrnekUyg.Model;

namespace OrnekUygMVC.UI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {
                ICollection<Category> categories = _categoryService.GetAll();
                return View(categories);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Index(Category category)
        {
            try
            {
                _categoryService.Insert(category);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int categoryID)
        {
            return View(_categoryService.Get(categoryID));
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            try
            {
                _categoryService.Update(category);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int categoryID)
        {
            _categoryService.DeleteById(categoryID);
            return RedirectToAction("Index");
        }
    }
}