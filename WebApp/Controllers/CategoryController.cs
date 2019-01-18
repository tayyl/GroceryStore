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
using WebApp.Models.Category;
using WebApp.Models.InputModels;

namespace WebApp.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            var outputModel = _mapper.Map<CategoryOutputModel>(category);
        
            return Ok(outputModel);

        }
        
        public async Task<IHttpActionResult> Get()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            if (categories == null || !categories.Any())
                return NotFound();
            var outputModel = new List<CategoryOutputModel>();
            outputModel = _mapper.Map<List<CategoryOutputModel>>(categories);
            //foreach(var item in categories)
            //{
            //    outputModel.Add(new CategoryOutputModel()
            //    {
            //        Name = item.Name
            //    });
            //}
            return Ok(outputModel);
        }
        public async Task<IHttpActionResult> Post(CategoryInputModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = new Category();
            category.Name = model.Name;
            var result = await _categoryRepository.SaveCategoryAsync(category);
            if (!result)
                return InternalServerError();
            return Ok();
        }

        public async Task<IHttpActionResult> Put(int id, CategoryInputModel model)
        {
            Category category = await _categoryRepository.GetCategory(id);
            if (category == null)
                NotFound();
            category.Name = model.Name;
            var result = await _categoryRepository.SaveCategoryAsync(category);
            if (!result)
                return InternalServerError();
            return Ok();
        }
        public async Task<IHttpActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            var result = await _categoryRepository.DeleteCategoryAsync(category);

            if (!result)
                return InternalServerError();

            return Ok();
        }
    }
}
