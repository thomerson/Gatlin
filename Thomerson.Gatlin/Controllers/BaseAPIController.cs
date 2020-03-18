using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Thomerson.Gatlin.Controllers
{
    /// <summary>
    /// Base API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AppDomain")]  //路由跨域设置  AppDomain = CORSMidware.PolicyName
    public class BaseAPIController : ControllerBase
    {

    }
}