using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SpaWebPortofolio.Pages.Account
{
    [ValidateAntiForgeryToken]
    public class Login : PageModel
    {
        [BindProperty] public LoginForm Form { get; set; }
        
        public void OnGet(string returnUrl)
        {
            Form = new LoginForm() {ReturnUrl = returnUrl};
        }
        public async Task<IActionResult> OnPost([FromServices] SignInManager<IdentityUser> signInManager, 
            [FromServices] UserManager<IdentityUser> userManager)
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            
            var loginResult = await signInManager.PasswordSignInAsync(Form.Username, Form.Password, false, false);

            if (loginResult.Succeeded)
            {
                return Redirect(Form.ReturnUrl);
            }

            ModelState.AddModelError(String.Empty , "Incorrect user name or password.");
            return Page();
        }
    }
    
    public class LoginForm
    {
        public string ReturnUrl { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}