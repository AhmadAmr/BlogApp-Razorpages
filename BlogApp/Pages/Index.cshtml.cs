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

namespace BlogApp.Pages
{

    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BlogService _service;

        public IndexModel(ILogger<IndexModel> logger,BlogService service)
        {
            _logger = logger;
            _service = service;
            
        }

        public IList<BlogApp.Models.Blog> Blog { get; private set; }

        public async Task OnGetAsync()
        {
            Blog = await _service.GetBlogs();
        }
    }
}
