using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Thomerson.Gatlin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public string Login([FromBody]string name, string password)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,"Ers")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456111111111111111111"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken("webapi.cn", "WebApi", claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

        [HttpGet]
        [Authorize]
        public void AuthorizeTest()
        {

        }
    }
}