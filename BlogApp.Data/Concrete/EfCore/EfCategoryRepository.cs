using BlogApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Entity;
using System.Linq;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private BlogContext context;

        public EfCategoryRepository(BlogContext _context)
        {
            context = _context;
        }

        public void AddCategory(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = context.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public IQueryable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(int categoryId)
        {
            return context.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
        }

        public void SaveCategory(Category entity)
        {
            if (entity.CategoryId == 0)
            {
                context.Categories.Add(entity);
            }
            else
            {
                var category = GetById(entity.CategoryId);
                if (category != null)
                {
                    category.Name = entity.Name;                   
                }
            }

            context.SaveChanges();
        }

        public void UpdateCategory(Category entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
