using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.DTO;
using BackEnd.Utils;
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
        public async Task<IActionResult> Post([FromBody]User user)
        {
            try
            {
                var validateExistence = await _userServices.ValidateExistence(user);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + user.NameUser + " ya existe!" });
                }
                user.Password = Utilities.EncryptPassword(user.Password);
                await _userServices.SaveUser(user);
                return Ok(new { message = "Usuario registrado con éxito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("ChangePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePwdDTO changePwd)
        {
            try
            {
                int idUsuario = 5;
                string pwdEncrypted = Utilities.EncryptPassword(changePwd.passwordBefore);
                var user = await _userServices.ValidatePassword(idUsuario, pwdEncrypted);
                if (user==null)
                {
                    return BadRequest(new { message = "La contraseña es incorrecta." });
                }
                else
                {
                    user.Password = Utilities.EncryptPassword(changePwd.passwordNew);
                    await _userServices.UpdatePassword(user);
                    return Ok(new { message = "La contraseña fue actualizada con exito!" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
