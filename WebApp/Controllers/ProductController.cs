using AutoMapper;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Models.Product;
using WebApp.Models.InputModels;

namespace WebApp.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var Product = await _ProductRepository.GetProduct(id);
            if (Product == null)
                return NotFound();

            var outputModel = _mapper.Map<ProductOutputModel>(Product);
        
            return Ok(outputModel);

        }
        
        public async Task<IHttpActionResult> Get()
        {
            var Products = await _ProductRepository.GetProductsAsync();

            if (Products == null || !Products.Any())
                return NotFound();
            var outputModel = new List<ProductOutputModel>();
            outputModel = _mapper.Map<List<ProductOutputModel>>(Products);
            //foreach(var item in Products)
            //{
            //    outputModel.Add(new ProductOutputModel()
            //    {
            //        Name = item.Name
            //    });
            //}
            return Ok(outputModel);
        }
        public async Task<IHttpActionResult> Post(ProductInputModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Product = new Product();
            Product.Name = model.Name;
            Product.Type= model.Type;
            Product.Description = model.Description;
            Product.Barcode = model.Barcode;
            var result = await _ProductRepository.SaveProductAsync(Product);
            if (!result)
                return InternalServerError();
            return Ok();
        }

        public async Task<IHttpActionResult> Put(int id, ProductInputModel model)
        {
            Product Product = await _ProductRepository.GetProduct(id);
            if (Product == null)
                NotFound();
            Product.Name = model.Name;
            var result = await _ProductRepository.SaveProductAsync(Product);
            if (!result)
                return InternalServerError();
            return Ok();
        }
        public async Task<IHttpActionResult> Delete(int id)
        {
            var Product = await _ProductRepository.GetProduct(id);
            if (Product == null)
                return NotFound();

            var result = await _ProductRepository.DeleteProductAsync(Product);

            if (!result)
                return InternalServerError();

            return Ok();
        }
    }
}
