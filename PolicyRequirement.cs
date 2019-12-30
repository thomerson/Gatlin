using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin
{
    public class PolicyRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 用户权限集合
        /// </summary>
        public List<UserPermission> UserPermissions { get; private set; }
        /// <summary>
        /// 无权限action
        /// </summary>
        public string DeniedAction { get; set; }
        /// <summary>
        /// 构造
        /// </summary>
        public PolicyRequirement()
        {
            //没有权限则跳转到这个路由
            DeniedAction = new PathString("/api/nopermission");
            //用户有权限访问的路由配置,当然可以从数据库获取 //TODO
            UserPermissions = new List<UserPermission> { };
            UserPermissions.Add(new UserPermission { Url = "/api/value3", UserName = "admin" });
        }
    }
}
