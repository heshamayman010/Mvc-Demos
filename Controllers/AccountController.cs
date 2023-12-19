using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Appuser> manger;
        private readonly SignInManager<Appuser> signinmanger;

        public AccountController(UserManager<Appuser> manger,SignInManager<Appuser> signinmanger)
        {
            this.manger = manger;
            this.signinmanger = signinmanger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //public IActionResult Login() { 
        
        //return View();
        
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public IActionResult Login()
        //{

        //    return View();

        //}


        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        public async Task< IActionResult> Register(Registerviewmodel model)
        {

            if (ModelState.IsValid == true)
            {

                // the data of the user is correct 

                Appuser user = new Appuser();
                user.Email = model.Email;
                user.UserName = model.Username;
                user.PasswordHash = model.Password;


                var result = await manger.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // this means that the user is created 
                    await signinmanger.SignInAsync(user, false);

                    return RedirectToAction("Index","Home");
                }
                else {

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);


                }
            }
            else
            {

                return View(model);

            }


        }




    }
}
