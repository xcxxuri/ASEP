using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Models;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync _accountService;
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IAuthenticationServiceAsync _authenticationServiceAsync;

        public AccountController(IAccountServiceAsync accountService, JwtTokenHandler jwtTokenHandler, IAuthenticationServiceAsync authenticationServiceAsync)
        {
            _accountService = accountService;
            _jwtTokenHandler = jwtTokenHandler;
            _authenticationServiceAsync = authenticationServiceAsync;
        }

        // GET: api/values
        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _accountService.GetAllAccountAsync());
        }

        [HttpGet("{id}" + " GetAccountById")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            return Ok(await _accountService.GetAccountByIdAsync(id));
        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody] AccountRequestModel account)
        {
            return Ok(await _accountService.AddAccountAsync(account));
        }

        [HttpPut("{id}" + " UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountRequestModel account)
        {
            return Ok(await _accountService.UpdateAccountAsync(account));
        }

        [HttpDelete("{id}" + " DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            return Ok(await _accountService.DeleteAccountAsync(id));
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authenticationServiceAsync.LoginAsync(model);
            if (result.Succeeded)
            {
                AuthenticationRequest request = new AuthenticationRequest()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                var response = _jwtTokenHandler.GenerateToken(request, "admin");
                if (response == null)
                {
                    return Unauthorized();
                }
                return Ok(response);
            }
            return BadRequest(result);

        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            var result = await _authenticationServiceAsync.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok("User Created Successfully");
            }
            return BadRequest(result);
        }



    }
}

