﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;
using ProductMVC.Repository;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {

        ProductRepository productRepository = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {
            var usuarios = productRepository.GetProductsList();
            return View(usuarios);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var produto = productRepository.GetProductById(id);

            if (produto == null)
            {
                return StatusCode(404);
            }


            return View(produto);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Product produto)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    productRepository.CreateProduct(produto);
                    return RedirectToAction(nameof(Index));
                }

                return View(produto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind] Product produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository.UpdateProduct(produto);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete([Bind] Product product)
        {
            productRepository.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}