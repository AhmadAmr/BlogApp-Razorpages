using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BlogApp.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;
using BlogApp.Services;
using System.ComponentModel.DataAnnotations;

namespace BlogApp
{
    public class CreateModel : PageModel
    {
        private readonly BlogApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly BlogService _service;

        public CreateModel(BlogApp.Data.ApplicationDbContext context , UserManager<ApplicationUser> userManager , IAuthorizationService authorizationService, BlogService service)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blog Blog { get;  set; }

        [BindProperty]
        
        public IFormFile Image { get; set; }
        [BindProperty]
        public int Number { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Blog.Author = await _userManager.GetUserAsync(User);
            Blog.CreatedOn = DateTime.Now;
            
            var img_name =  _service.UploadedFile(Image);
            Blog.Image = img_name;
            var isAuthorized = await _authorizationService.AuthorizeAsync( User, Blog, Operations.Create);

            if(!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            _context.Blogs.Add(Blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
