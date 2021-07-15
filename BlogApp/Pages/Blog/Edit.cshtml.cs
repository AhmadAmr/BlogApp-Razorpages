using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BlogApp.Authorization;

namespace BlogApp
{
    public class EditModel : PageModel
    {
        private readonly BlogApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public EditModel(BlogApp.Data.ApplicationDbContext context , UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        [BindProperty]
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
            var isAuthorized = await _authorizationService.AuthorizeAsync( User, Blog,Operations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var blog = await _context.Blogs.AsNoTracking().Include(x => x.Author).FirstOrDefaultAsync(m => m.Id == id);

            if(blog == null)
            {
                return NotFound();
            }
            EditHistory editHistorys = new EditHistory();

            editHistorys.UpdatedOn = DateTime.Now;
            editHistorys.user= await _userManager.GetUserAsync(User);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, blog, Operations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

             Blog.EditHistories = new List<EditHistory> { editHistorys };
            _context.editHistories.Add(editHistorys);
            _context.Attach(Blog).State = EntityState.Modified;

            if(blog.Status == BlogStatus.Approved)
            {
                var canApprove = await _authorizationService.AuthorizeAsync(User, Blog, Operations.Approve);

                if (!canApprove.Succeeded)
                {
                    Blog.Status = BlogStatus.Submitted;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

       
    }
}
