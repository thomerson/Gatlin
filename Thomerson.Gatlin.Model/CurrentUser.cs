using System;
using System.Collections.Generic;
using System.Text;

namespace Thomerson.Gatlin.Model
{
    /// <summary>
    /// 当前登录用户
    /// </summary>
    public class CurrentUser : BaseModel
    {
        public string NickName { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
