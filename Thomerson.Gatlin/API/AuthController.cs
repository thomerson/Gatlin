using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Thomerson.Gatlin.Core;
using Thomerson.Gatlin.Model.User;

namespace Thomerson.Gatlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login([FromBody] UserLogin user)
        {
            if (!string.IsNullOrEmpty(user.UserId) && !string.IsNullOrEmpty(user.Password))
            {
                //TODO 用户名密码验证

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId)  //token 添加用户名
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppCommon.SecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: AppCommon.Domain,
                    audience: AppCommon.Domain,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return BadRequest(new { message = "username or password is incorrect." });
            }
        }

        public IActionResult ValidateLogin([FromBody] ValidateUserLogin user)
        {
            //验证validate
            if (!string.IsNullOrEmpty(user.UserId) && !string.IsNullOrEmpty(user.Password))
            {
                //TODO 用户名密码验证

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId)  //token 添加用户名
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppCommon.SecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: AppCommon.Domain,
                    audience: AppCommon.Domain,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return BadRequest(new { message = "username or password is incorrect." });
            }
        }

        public IActionResult Logout()
        {
            return Ok("");
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("api/nopermission")]
        public IActionResult NoPermission()
        {
            return Forbid("No Permission!");
        }

    }
}