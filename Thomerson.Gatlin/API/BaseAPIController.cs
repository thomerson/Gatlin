using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
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
        /// <summary>
        /// Client 启用Cookie 网站首页启动时js调用
        /// </summary>
        [HttpPost]
        public void EnableCookie()
        {
            HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
        }

        #region Cookie


        protected void AddCookies(string key, string val)
        {
            Response.Cookies.Append(key, val
                //, new Microsoft.AspNetCore.Http.CookieOptions()
                //{
                //    HttpOnly = true,//后端只读，前端无法通过js获取cookie防止XXL攻击
                //    Secure = false          //安全模式，https
                //}
                );
        }

        protected void DeleteCookies(string key)    //删除指定的cookie
        {
            HttpContext.Response.Cookies.Delete(key);
        }

        protected string GetCookies(string key)     //获取指定的cookie
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }
        #endregion

    }
}