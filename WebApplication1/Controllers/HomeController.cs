using EFCore.Data.Contexts;
using EFCore.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Controllers
{
    public class HomeController : Controller
    {
        //READ
        public IActionResult Index()
        {
            EFCoreContext context = new();
            return View(context.Products.ToList());
        }
        //CREATE
        public IActionResult AddProduct()
        {
            EFCoreContext context = new();
            Product addProduct = new();

            addProduct.Name = "Samsung";
            addProduct.Price = 2750;
            context.Products.Add(addProduct);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //UPDATE
        public IActionResult UpdateProduct()
        {
            EFCoreContext context = new();
            Product updatedProduct = context.Products.Where(x => x.Id == 25).FirstOrDefault();
            updatedProduct.Name = "Samsung Galaxy S22";
            updatedProduct.Price = 2950;
            context.Products.Update(updatedProduct);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //DELETE
        public IActionResult DeleteProduct()
        {
            EFCoreContext context = new();
            List<Product> deletedProduct=context.Products.Where(x => x.Name == "Samsung").ToList();
            context.Products.RemoveRange(deletedProduct);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
