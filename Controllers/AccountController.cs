using Ecommerce_App.Models;
using Ecommerce_App.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public SignInManager<ApplicationUser> SignInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = register.UserName,
                    Age = register.Age,
                    Email = register.Email
                };

                var result = await userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }

               
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

           
            return View(register);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                //check username if found
                var user = await userManager.FindByNameAsync(login.UserName);
                if (user == null) return View("NotFound");
                //check Paasword
            bool flag=await userManager.CheckPasswordAsync(user, login.Password);
                if (flag)
                {
                    //generate token
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    var roles = await userManager.GetRolesAsync(user);
                    foreach (var item in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));


                    }
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_a_super_secret_key_1234567890_abcdefghijklmnopqrstuvwxyz!!!"));
                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);



                    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                        issuer: "https://localhost:7027",
                        audience: "https://localhost:7027/",
                        claims: claims,
                        expires:DateTime.Now.AddHours(1),
                        signingCredentials:signingCredentials

                        );
                    var tokenHandler = new JwtSecurityTokenHandler();
                    string tokenString = tokenHandler.WriteToken(jwtSecurityToken);
                    HttpContext.Response.Cookies.Append("jwt", tokenString, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.Now.AddHours(1)
                    });

                    return RedirectToAction("Index", "Movies");
                }

                else
                {
                    ModelState.AddModelError("", "InCorrect UserName Or Password");
                    return View(login);
                }

            }
            else
            {
                return View(login);
            }

        }
        public async Task<IActionResult> Logout()
        {
           
            await SignInManager.SignOutAsync();

            
            HttpContext.Response.Cookies.Delete("jwt");

            return RedirectToAction("Login", "Account");
        }


    }
}
