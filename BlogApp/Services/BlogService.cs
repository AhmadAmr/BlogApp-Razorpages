using BlogApp.Data;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class BlogService
    {
        private ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }
    }
}
