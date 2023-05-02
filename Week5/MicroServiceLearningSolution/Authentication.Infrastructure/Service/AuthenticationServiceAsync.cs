using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Infrastructure.Service
{
    public class AuthenticationServiceAsync : IAuthenticationServiceAsync
    {   
        private readonly IAuthenticationRepositoryAsync _authenticationRepositoryAsync;
        public AuthenticationServiceAsync(IAuthenticationRepositoryAsync authenticationRepositoryAsync)
        {
            _authenticationRepositoryAsync = authenticationRepositoryAsync;
        }

        public async Task<IdentityResult> SignUpAsync (SignUpModel model)
        {
            var result = await _authenticationRepositoryAsync.SignUpAsync(model);
            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            var result = await _authenticationRepositoryAsync.SignInAsync(model);
            return result;
        }

        
    }
}

