using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm= new BlogManager(new EfBlogRepository());
        //UserManager wm = new UserManager(new EfUserRepository());
        private readonly UserManager<User> _userManager;

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            var values = bm.GetBlogById(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categories = (from x in cm.GetAllTs()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog)
        {
            BlogValidator wv = new BlogValidator();
            ValidationResult validationResult = new ValidationResult();
            validationResult = wv.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                var userId = await _userManager.FindByNameAsync(User.Identity.Name);
                //blog.AppUserID = userId.Id;
                bm.TAdd(blog);
                return RedirectToAction("BlogReadAll", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult BlogDelete(int id)
        {
            var blogValue = bm.GetTById(id);
            bm.TDelete(blogValue);
            return RedirectToAction("BlogReadAll", "Blog");
        }
        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categories = (from x in cm.GetAllTs()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categories;
            var blogvalue = bm.GetTById(id);
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {
            bm.TUpdate(blog);
            return RedirectToAction("BlogReadAll", "Blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = bm.GetTById(id);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            return RedirectToAction("Index","Blog");
        }
    }
}