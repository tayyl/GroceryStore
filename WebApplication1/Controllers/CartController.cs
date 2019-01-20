using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Repository.Concrete;

namespace WebApplication1.Controllers
{
    public class CartController :Controller
    {
        private ApplicationUser CheckCurrentUser()
        {
            AppContext _entities = new Model.AppContext();
            string currentUserId = User.Identity.GetUserId();
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_entities));
            ApplicationUser currentUser = manager.FindById(currentUserId);
            return currentUser;
        }
        public async Task<ActionResult> Index()
        {
            CartRepository context = new CartRepository();
            var currentUser = CheckCurrentUser();
            if (currentUser is null)
                return Redirect("../Account/Login");
           else
           {
                currentUser.Cart = await context.GetCart(currentUser.Id);
                return View(currentUser.Cart);
           }           
        }

        public async Task<ActionResult> Index(Cart cart)
        {
            CartRepository repository = new CartRepository();
            var result = await repository.SaveCartAsync(cart);
            if (result is false)
                return View(); // TODO: Fix return on negative result
            return View();
        }
    }
}