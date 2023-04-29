using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Models;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync _accountService;
        private readonly JwtTokenHandler _jwtTokenHandler;
        public AccountController(IAccountServiceAsync accountService, JwtTokenHandler jwtTokenHandler)
        {
            _accountService = accountService;
            _jwtTokenHandler = jwtTokenHandler;
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
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            var response = _jwtTokenHandler.GenerateToken(request);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }



    }
}

