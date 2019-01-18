using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            if (category == null)
                return false;
            context.Categories.Remove(category);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public async Task<bool> SaveCategoryAsync(Category category)
        {
            if (category == null)
                return false;
            try
            {
                context.Entry(category).State = category.Id == default(int) ? EntityState.Added : EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
