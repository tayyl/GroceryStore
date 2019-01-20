
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Entities;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.AspNet.Identity;
using Repository.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Validation;
using System;
using static Model.AppContext;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private Model.AppContext db = new Model.AppContext();

        // GET: Product
        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*[Bind(Include = "Id,Barcode,Name,Description,Image,Type,PriceId")]*/ Product product, Nutrient nutrient, Collection<Price> prices, Price price, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                byte[] imgData;
                using (BinaryReader reader = new BinaryReader(file.InputStream))
                {
                    imgData = reader.ReadBytes((int)file.InputStream.Length);
                }
                product.Image = imgData;
                price.Product = product;
                price.CreationDate = System.DateTime.Now;
                nutrient.Product = product;
                product.Nutrient = nutrient;
                //product.Prices = new List<Price> { price };
                db.Products.Add(product);
                db.Nutrients.Add(nutrient);
                db.Prices.Add(price);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Barcode,Name,Description,Image,Type,PriceId")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                byte[] imgData;
                using (BinaryReader reader = new BinaryReader(file.InputStream))
                {
                    imgData = reader.ReadBytes((int)file.InputStream.Length);
                }
                product.Image = imgData;
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<ActionResult> AddToCart(int id)
        {
            // TODO: Code duplicate form CartController
            CartRepository cartRepository = new CartRepository();
            string currentUserId = User.Identity.GetUserId();
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = manager.FindById(currentUserId);
            if (currentUser is null)
                return Redirect("../../Account/Login");
            
            //Cart cart = await cartRepository.GetCart(currentUser.CartId);
            //if (cart is null)
            //{
            //    cart = new Cart();
            //    //db.Carts.Add(cart); 
            //}
            Product product = db.Products.Where(o => o.Id == id).Single();
            var query = from d in db.CartItems
                            where d.Product == product
                            where d.TempId == currentUser.Id
                            select d;
            var item = query.ToList();
            if (item[0] != default(CartItem))
                item[0].Amount++;
            else
            {
                var newItem = new CartItem(product);
                newItem.TempId = currentUser.Id;
                
                db.CartItems.Add(newItem);
            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
