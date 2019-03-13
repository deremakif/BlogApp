using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Abstract
{
    public interface IBlogRepository
    {
        Blog GetById(int blogId);
        IQueryable<Blog> GetAll();
        void AddBlog(Blog entity);
        void UpdateBlog(Blog entity);
        void SaveBlog(Blog entity);
        void DeleteBlog(int blogId);
    }
}
