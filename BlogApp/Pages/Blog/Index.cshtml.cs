using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Services;

namespace BlogApp
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly BlogService blogService;

        public IndexModel(ApplicationDbContext context,BlogService BlogService)
        {
            _context = context;
            blogService = BlogService;
        }

        public IList<Blog> Blog { get; private set; }

        public async Task OnGetAsync()
        {
            Blog = await blogService.GetBlogs();
        }
    }
}
