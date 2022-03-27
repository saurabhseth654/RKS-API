using Microsoft.AspNetCore.Mvc;
using RKS.Core.Entities;
using RKS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RKS.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthorizationController(IAuthService authService)
        {
            _authService = authService;
        }
               

        // GET: api/<AuthorizationController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("ValidateUser")]
        public async Task<IActionResult> ValidateUser(User user)
        {
            return Ok(await _authService.ValidateUser());
        }
     }
}
