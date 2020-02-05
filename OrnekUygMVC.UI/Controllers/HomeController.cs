using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrnekUyg.BLL.Abstract;
using OrnekUyg.Model;

namespace OrnekUygMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int catID = 0)
        {

            if (HttpContext.Session.GetString("LoginSession") != null)
            {
                ICollection<Product> products;
                if (catID == 0)
                {
                    products = _productService.GetAll().ToList();
                }
                else
                {
                    products = _productService.GetByCategoryID(catID);
                }
                ViewBag.Products = products;
                ViewBag.Categories = _categoryService.GetAll();
                return View();
            }
            return RedirectToAction("Index", "Login");

        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(product);
                ICollection<Product> products = _productService.GetByCategoryID(product.CategoryID);
                ViewBag.Categories = _categoryService.GetAll();
                ViewBag.Products = products;
                return View();
            }
            return RedirectToAction("Index", "Home", new { catID = 0 });
        }
        public IActionResult CategoryAdd(Category category)
        {
            _categoryService.Insert(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productID)
        {
            _productService.DeleteById(productID);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int productID = 0)
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {
                Product product;
                if (productID == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    product = _productService.Get(productID);
                }
                ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryID", "CategoryName"); ;
                return View(product);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }

    }
}