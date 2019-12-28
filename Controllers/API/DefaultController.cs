using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Thomerson.Gatlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return new Task<string>(() => { return ""; });
        }
    }
}