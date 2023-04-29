using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleServiceAsync _userRoleService;
        public UserRoleController(IUserRoleServiceAsync userRoleService)
        {
            _userRoleService = userRoleService;
        }
        
        // GET: api/values
        [HttpGet("GetAllUserRoles")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            return Ok(await _userRoleService.GetAllUserRoleAsync());
        }

        [HttpGet("{id}" + " GetUserRoleById")]
        public async Task<IActionResult> GetUserRoleById(int id)
        {
            return Ok(await _userRoleService.GetUserRoleByIdAsync(id));
        }

        [HttpPost("AddUserRole")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleRequestModel userRole)
        {
            return Ok(await _userRoleService.AddUserRoleAsync(userRole));
        }

        [HttpPut("{id}" + " UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UserRoleRequestModel userRole)
        {
            return Ok(await _userRoleService.UpdateUserRoleAsync(userRole));
        }

        [HttpDelete("{id}" + " DeleteUserRole")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            return Ok(await _userRoleService.DeleteUserRoleAsync(id));
        }

        
    }
}

