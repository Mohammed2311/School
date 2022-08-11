using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.BL.Models;

namespace School.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region SingUp
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterationVm model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = new IdentityUser()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        
                    };
                    
                    var result = await userManager.CreateAsync(data, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");

                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }



                }

                return View(model);
            }
            catch (Exception ex)
            {

                return View(ex);
            }
        }

        #endregion
        #region LogIn
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (user is not null)
                    {
                        
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, false,false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("index", "Home");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Email or Password");
                        }
                    }

                    else
                    {

                        ModelState.AddModelError("", "Invalid Email");
                    }
                    return View(model);

                }
                return View(model);


            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }


        }
        #endregion
    }
}
