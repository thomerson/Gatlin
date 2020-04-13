using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Core;
using Thomerson.Gatlin.Model.User;
using Thomerson.Gatlin.Utils;

namespace Thomerson.Gatlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService Service;
        public AuthController(IUserService service)
        {
            Service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            var currentUser = Service.Get(user.UserId);
            if (currentUser == null)
            {
                var password = MD5Core.ToMD5($"{user.UserId}{user.Password}{currentUser.Salt}");
                if (password != currentUser.Password)
                {
                    return BadRequest(new { message = "用户名或密码不正确" });
                }
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
                return BadRequest(new { message = "用户名或密码不正确" });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User model)
        {
            var currentUser = Service.Get(model.UserId);
            if (currentUser != null)
            {
                return BadRequest(new { message = "账号已存在" });
            }

            model.Salt = Guid.NewGuid().ToString().Replace("-", "");
            model.Password = MD5Core.ToMD5($"{model.UserId}{model.Password}{model.Salt}");

            Service.Insert(model);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            return Ok("");
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("nopermission")]
        public IActionResult NoPermission()
        {
            return Forbid("No Permission!");
        }

    }
}