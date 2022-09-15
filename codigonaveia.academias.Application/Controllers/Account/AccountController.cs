using codigonaveia.academias.Application.Models;
using codigonaveia.academias.Application.Models.Account;
using codigonaveia.academias.Application.Services;
using codigonaveia.academias.Domain.Entities.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.academias.Application.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly IUserClaimsPrincipalFactory<Users> _userClaimsPrincipalFactory;
        private readonly UserManager<Users> _userManager;

        public AccountController(SignInManager<Users> signInManager, IUserClaimsPrincipalFactory<Users> userClaimsPrincipalFactory, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
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
        public async Task<IActionResult> Register(UserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = new Users
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.UserName,
                        PasswordHash = model.Password

                    };

                    var resultado = await _userManager.CreateAsync(user, model.Password);
                    var confirmarEmail = string.Empty;
                    if (resultado.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        System.IO.File.WriteAllText("ConfirmarEmail.text", confirmarEmail);
                    }
                    else
                    {
                        foreach (var erro in resultado.Errors)
                        {
                            ModelState.AddModelError(string.Empty, erro.Description);
                        }
                    }


                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário já existe");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var user = await _userManager.FindByNameAsync(model.UserName);

                    if (user != null && !await _userManager.IsLockedOutAsync(user))
                    {
                        if (await _userManager.CheckPasswordAsync(user, model.Password))
                        {

                            if (!await _userManager.IsEmailConfirmedAsync(user))
                            {
                                ModelState.AddModelError(string.Empty, "Conta esta em processo de validação");
                                return View();
                            }

                            await _userManager.ResetAccessFailedCountAsync(user);
                            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

                            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new System.Security.Claims.ClaimsPrincipal(principal));
                            return RedirectToAction(nameof(BemVindo));
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Senha invalida");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Conta esta bloqueada");
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModelView mod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(mod.Email);
                    if (user != null)
                    {
                        
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var resetUrl = Url.Action("ResetPassword", "Account", new { token = token, email = mod.Email }, Request.Scheme);

                        // System.IO.File.WriteAllText("resetLinkToNewPass", resetUrl);

                       
                        var mail = new EmailServices();

                        var msg = new EmailAddressModelView()
                        {
                            Subject = "E-mail enviado para alteração de senha",
                            To = mod.Email,
                            Body =  resetUrl
                        };

                        await mail.SendEmailAsync(msg);
                        TempData["MsgEmailSucesso"] = "Email enviado com sucesso.";
                        TempData["ResetSenha"] = resetUrl;
                        return RedirectToAction(nameof(ConfirmPasswordSuccess));
                    }

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"Ops, ocorreu um erro:  {ex.Message}");
            }
            return View();
        }

        public IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel mod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(mod.Email);

                    if (user != null)
                    {
                        var result = await _userManager.ResetPasswordAsync(user, mod.Token, mod.Password);
                        if (!result.Succeeded)
                        {
                            foreach (var erro in result.Errors)
                            {
                                ModelState.AddModelError("", erro.Description);
                            }

                            return View();
                        }

                        return View("Success");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult ConfirmPasswordSuccess()
        {
            return View();
        }
        public IActionResult BemVindo()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
