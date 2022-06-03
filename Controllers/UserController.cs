using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                await _userServices.SaveUser(user);
                return Ok(new { message = "Usuario registrado con éxito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
