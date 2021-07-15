using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp
{
    public class DetailsModel : PageModel
    {
        private readonly BlogApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public DetailsModel(BlogApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            if (Blog == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id, BlogStatus status)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            if (blog == null)
                return NotFound();

            var opration = (status == BlogStatus.Approved) ? Operations.Approve : Operations.Reject;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, blog, opration);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            blog.Status = status;
            if (status == BlogStatus.Approved)
                blog.Approver = await _userManager.GetUserAsync(User);
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}
