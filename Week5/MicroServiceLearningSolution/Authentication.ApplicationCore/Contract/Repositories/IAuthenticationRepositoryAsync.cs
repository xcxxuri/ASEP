using System;
using Authentication.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.ApplicationCore.Contract.Repositories
{
    public interface IAuthenticationRepositoryAsync
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResult> SignInAsync(LoginModel model);
    }
}

