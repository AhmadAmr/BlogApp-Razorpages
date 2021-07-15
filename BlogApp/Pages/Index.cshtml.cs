using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Data;
using BlogApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Pages
{

    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BlogService _service;
        private readonly ApplicationDbContext _contex;

        public IndexModel(ILogger<IndexModel> logger,BlogService service ,ApplicationDbContext context)
        {
            _logger = logger;
            _service = service;
            _contex = context;
        }

        public IList<BlogApp.Models.Blog> Blog { get; private set; }

        public async Task OnGetAsync()
        {
            var  blog =   _contex.Blogs.Where(x => x.Published && x.Status == BlogStatus.Approved);
            Blog = await blog.ToListAsync();
        }
    }
}
