using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Infrastructure.Repository
{
	public class AuthenticationRepositoryAsync: IAuthenticationRepositoryAsync
	{
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationRepositoryAsync(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // this will return a task of type IdentityResult which is perdefined in Identity framework
        public async Task<IdentityResult> SignUpAsync (SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            // CreateAsync will return IdentityResult
            return await _userManager.CreateAsync(user, model.Password);// can use either password or confirm password

        }

        public async Task<SignInResult> SignInAsync(LoginModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            // false, false means we are not locking the user out and we are not checking if the user is active or not
        }

    }
}

