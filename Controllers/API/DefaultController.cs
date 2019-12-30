using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Thomerson.Gatlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //权限验证
    public class DefaultController : ControllerBase
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>结果</returns>
        [HttpGet]
        public Task<string> Get(string param)
        {
            var auth = HttpContext.AuthenticateAsync().Result.Principal.Claims;
            var userName = auth.FirstOrDefault(t => t.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            var role = auth.FirstOrDefault(t => t.Type.Equals("Role"))?.Value;

            return new Task<string>(() => { return ""; });
        }
    }
}