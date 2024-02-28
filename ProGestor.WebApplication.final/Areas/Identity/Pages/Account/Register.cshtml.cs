// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ProGestor.Common.Const;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;

namespace ProGestor.WebApplication.final.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICityRepository _cityRepository;
        private readonly IGenderRepository _genderRepository;

        public RegisterModel(
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, 
            ICityRepository cityRepository, IGenderRepository genderRepository)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _cityRepository = cityRepository;
            _genderRepository = genderRepository;
            
            Cities =  _cityRepository.GetAll().Result.ToList();
            Genders = _genderRepository.GetAll().Result.ToList();
            
        }
        
        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty] public int CitySelected { get; set; } = 0;
        [BindProperty] public int GenderSelected { get; set; } = 0;
        
        public string ReturnUrl { get; set; }
        
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public class InputModel
        {
            
            [Display(Name = "Nombre")]
            public string Name { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Nombre")]
            public string firstName { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Apellido")]
            public string LastName { get; set; }
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Numero de teléfono")]
            public string NumberPhone { get; set; }
            public string SelectedRole { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Cities = await _cityRepository.GetAll();
            Genders = await _genderRepository.GetAll();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.genderId = GenderSelected;
                user.numberPhone = Input.NumberPhone;
                user.CityId = CitySelected;
                user.firstName = Input.firstName;
                user.lastName = Input.LastName;
                user.EmailConfirmed = true;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    //Validar si existen, sino se crean
                    if (!await _roleManager.RoleExistsAsync(Rols.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Rols.Admin));
                        await _roleManager.CreateAsync(new IdentityRole(Rols.Employee));
                        await _roleManager.CreateAsync(new IdentityRole(Rols.Client));
                    }
                    
                    switch (Input.SelectedRole)
                    {
                       case Rols.Admin:
                        await _userManager.AddToRoleAsync(user, Rols.Admin);
                        break;
                       case Rols.Employee:
                           await _userManager.AddToRoleAsync(user, Rols.Employee);
                           break;
                       case Rols.Client:
                           await _userManager.AddToRoleAsync(user, Rols.Client);
                           break;
                       default:
                           await _userManager.AddToRoleAsync(user, Rols.Client);
                           break;
                    }
                    
                    _logger.LogInformation("El usuario creó una nueva cuenta con contraseña.");
                    
                    var userId = await _userManager.GetUserIdAsync(user);
                    if (User.IsInRole(Rols.Admin))
                    {
                       return RedirectToAction("Index", "User", new { area = "Admin"});
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("MainPage", "Home", new { area = "Client"});
                    }

                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    // var callbackUrl = Url.Page(
                    //     "/Account/ConfirmEmail",
                    //     pageHandler: null,
                    //     values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //     protocol: Request.Scheme);

                    // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"No se puede crear una instancia de'{nameof(User)}'. " +
                    $"Asegurarse de que '{nameof(User)}' no es una clase abstracta y tiene un constructor sin parámetros, o alternativamente" +
                    $"anular la página de registro en /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("La interfaz de usuario predeterminada requiere una tienda de usuarios con soporte por correo electrónico.");
            }
            return (IUserEmailStore<User>)_userStore;
        }
    }
}
