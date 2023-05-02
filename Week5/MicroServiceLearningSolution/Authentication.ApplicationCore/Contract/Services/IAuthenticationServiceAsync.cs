using System;
using Authentication.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.ApplicationCore.Contract.Services
{
    public interface IAuthenticationServiceAsync
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResult> LoginAsync(LoginModel model);
    }
}

