using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Model.Criteria;
using Thomerson.Gatlin.Model.Page;

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

        [HttpGet]
        public Tuple<int, IEnumerable<User>> GetPage(UserCriteria criteria, Pagination pagination)
        {
            return UserService.GetPage(criteria, pagination);
        }

        [HttpPost]
        public void Add(User model)
        {
            UserService.Insert(model);
        }

        [HttpPut]
        public void Update(User model)
        {
            UserService.Update(model);
        }

        [HttpDelete]
        public void Delete(User model)
        {
            UserService.Delete(model);
        }
    }
}