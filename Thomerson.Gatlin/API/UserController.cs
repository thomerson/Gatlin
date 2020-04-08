using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Contract;

namespace Thomerson.Gatlin.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService;
        public UserController(IUserService service)
        {
            UserService = service;
        }

        public List<User> Get()
        {
            return new List<User>();
        }
    }
}