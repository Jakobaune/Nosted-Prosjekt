using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NostedServicePro.Models.Account;


namespace NostedServicePro.Controllers;
[Authorize]
public class AccountController : Controller
{
    private readonly ILogger _logger;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILoggerFactory loggerFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = loggerFactory.CreateLogger<AccountController>();
    }

    // GET: /Account/Login
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {

        try
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger?.LogInformation(1, "Bruker logget inn.");

           
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

                if (result.IsLockedOut)
                {
                    //kode for å håndtere låste brukere 
                    //_logger?.LogWarning(2, "User account locked out.");
                    //return View("Lockout");
                  
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ugyldig login forsøk.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        catch (Exception ex)
        {
            _logger?.LogError($"An error occurred during login: {ex.Message}");
            ModelState.AddModelError(string.Empty, "An error occurred during login.");
            return View(model);
        }
    }

    // GET: /Account/Register

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Register()
    {
        return View();
    }

    //
    // POST: /Account/Register
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName, Email = model.Email, EmailConfirmed = true, LockoutEnabled = false,
                LockoutEnd = null
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Tildel rollen basert på brukerens valg
                await _userManager.AddToRoleAsync(user, model.SelectedRole);

                _logger.LogInformation(3, "User created a new account with password.");

                TempData["Message"] = "Brukeren er registrert vellykket!";

                return RedirectToAction("VisAlleBrukere", "Bruker");
            }

            AddErrors(result);
        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }


    public async Task<IActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation(4, "Bruker logget ut.");
        return RedirectToAction();
    }


    [HttpGet]
    [Authorize]
    public IActionResult ResetPassword()
    {
        return View();
    }

    // POST: /Account/ResetPassword
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); // Hent brukeren som er logget inn
            if (user == null)
                // Noe gikk galt, håndter feil her
                return RedirectToAction(nameof(ResetPasswordConfirmation), "Account");

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
                // Passordet ble endret vellykket
                return RedirectToAction(nameof(ResetPasswordConfirmation), "Account");

            AddErrors(result);
            return View();
        }
        return View(model);
    }


    // GET: /Account/ResetPasswordConfirmation
    [HttpGet]
    public IActionResult ResetPasswordConfirmation()
    {
        return View();
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
    }

}