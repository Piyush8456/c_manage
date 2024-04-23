using Microsoft.AspNetCore.Mvc;
using Custom_User_Management.Models;
using Custom_User_Management.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Custom_User_Management.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _DBContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(ApplicationDbContext DBContext, IWebHostEnvironment hostingEnvironment, SignInManager<ApplicationUser> signInManager)
        {
            _DBContext = DBContext;
            _hostingEnvironment = hostingEnvironment;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser application = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    ProfilePicture = model.ProfilePicture  // Assuming ProfilePicture is an IFormFile
                };

                _DBContext.Users.Add(application);
                _DBContext.SaveChanges();

                // Save profile picture file
                //if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                //{
                //    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", model.ProfilePicture.FileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        model.ProfilePicture.CopyTo(stream);
                //    }

                //}

                return RedirectToAction("Index", "Home");
            }

            return View(model);  // Return the same view with validation errors
        }

        [HttpGet]
        public IActionResult Login() 
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login attempt");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(model);
        }



    }
}
