using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using Repository.Concrete;
using static Model.AppContext;

namespace WebApplication1.Controllers
{
    public class CartController :Controller
    {
        public ApplicationUser CheckCurrentUser()
        {
            AppContext _entities = new Model.AppContext();
            string currentUserId = User.Identity.GetUserId();
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_entities));
            ApplicationUser currentUser = manager.FindById(currentUserId);
            return currentUser;
        }
        public async Task<ActionResult> Index()
        {
            CartsRepository context = new CartsRepository();
            var currentUser = CheckCurrentUser();
            if (currentUser is null)
                return Redirect("../Account/Login");
           else
           {
                Cart cart = await context.GetCart(currentUser.CartId);
                return View(cart);
           }           
        }

        public async Task<ActionResult> Index(Cart cart)
        {
            CartsRepository repository = new CartsRepository();
            var result = await repository.SaveCartAsync(cart);
            if (result is false)
                return View(); // TODO: Fix return on negative result
            return View();
        }
    }
}