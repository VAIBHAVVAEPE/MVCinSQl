using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCinSQl.Models;
using System;
using static MVCinSQl.Models.ProductDALcs;

namespace MVCinSQl.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL pd = new ProductDAL();
        // GET: ProductController
        public ActionResult Index()
        {

            var model = pd.GetAllProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product p = pd.GetProductById(id);
            return View(p);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            Product p = new Product();
            p.Pname = form["pName"];
            p.Price = Convert.ToSingle(form["price"]);
            p.Company = form["Company"];
            p.Description = form["Description"];
            int res = pd.Save(p);
            if (res == 1)
            {

                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            Product prod = pd.GetProductById(id);

            return View(prod);

        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {

            int res = pd.update(p);
            if (res == 1)
                return RedirectToAction("Index");

            return View();


        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product prod = pd.GetProductById(id);
            return View(prod);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteCo(int id)
        {
            int res = pd.Delete(id);
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
