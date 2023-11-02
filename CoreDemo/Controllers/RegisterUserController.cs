using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
      //  [HttpPost]
        //public async Task<IActionResult> Index(UserSignUpViewModel p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser user = new AppUser()
        //        {
        //            Email = p.Mail,
        //            UserName = p.UserName,
        //            NameSurname = p.nameSurname

        //        };
        //        var result = await _userManager.CreateAsync(user, p.ConfirmPassword);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Login");
        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)
        //            {
        //                ModelState.AddModelError("", item.Description);
        //            }
        //        }
        //    }
           // return View();
      //  }
    }
}
