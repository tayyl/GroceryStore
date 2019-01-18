using Model.Entities;
using Repository.Concrete;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Models.InputModels.Home;
using System.Web.Mvc;

namespace WebApp.Controllers
{


    /// <summary>
    /// Główny kontroler
    /// </summary>
   // [RoutePrefix("api/home")]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        /*

        /// <summary>
        /// Pobierz dane
        /// </summary>
        /// <returns>Zwracany jest napis</returns>
        [HttpGet]
        //[Route("alamakota")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "zwracany kod")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok("to jest zapytanie get");
        }

        /// <summary>
        /// Pobierz dane
        /// </summary>
        /// <param name="id">Identyfikator obiektu</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Ok($"to jest zapytanie get nr {id}");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(HomeInputModel model)
        {
            if (model == null)
                return BadRequest("model is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category();
            category.Name = model.Name;

    
            return Ok($"Id: {model.Id}, Name: {model.Name}");*/
        //}

    }
}
