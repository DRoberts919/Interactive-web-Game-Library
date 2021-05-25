using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLibraryPt1.Areas.Admin.Pages.Roles
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;

        [BindProperty]
        public string RoleName { get; set; }

        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult OnGet()
        {
            return Page();

        }



        public async Task<IActionResult>  OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IdentityRole newRole = new IdentityRole
            {
                Name = RoleName
            };

            IdentityResult result =  await roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                return RedirectToPage("/Roles/index");
            }
            else
            {
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return Page();
            }



        }
    }
}
