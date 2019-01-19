﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var _entities = new Model.AppContext();
            var model = _entities.Products;
         
            return View(model);
        }
        public ActionResult Index3()
        {
            var _entities = new Model.AppContext();
            var model = _entities.Products.Include(c => c.Nutrient);
            return View(model);
        }

        public async Task<ActionResult> Index4()
        {
            var _entities = new Model.AppContext();
            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new Model.AppContext()));
            var currentUser = manager.FindById(currentUserId);
            if (currentUser.Cart is null)
            {
                Cart newCart = _entities.Carts.Create();
                newCart.Id = Guid.NewGuid().ToString();
                newCart.Products = new List<Product> { };
      
                currentUser.Cart = newCart;
                var result = await _entities.SaveChangesAsync();
            }
            var products = currentUser.Cart.Products.ToList();
            return View(products);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}