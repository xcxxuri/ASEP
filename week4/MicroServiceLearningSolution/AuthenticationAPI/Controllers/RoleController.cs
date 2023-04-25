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
    public class RoleController : ControllerBase
    {
        private readonly IRoleServiceAsync _roleService;
        public RoleController(IRoleServiceAsync roleService)
        {
            _roleService = roleService;
        }

        // GET: api/values
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleService.GetAllRoleAsync());
        }

        [HttpGet("{id}" + " GetRoleById")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            return Ok(await _roleService.GetRoleByIdAsync(id));
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleRequestModel role)
        {
            return Ok(await _roleService.AddRoleAsync(role));
        }

        [HttpPut("{id}" + " UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleRequestModel role)
        {
            return Ok(await _roleService.UpdateRoleAsync(role));
        }

        [HttpDelete("{id}" + " DeleteRole")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            return Ok(await _roleService.DeleteRoleAsync(id));
        }
        
    }
}

