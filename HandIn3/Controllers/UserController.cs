using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandIn_3.Models;
using HandIn3.Database;
using Microsoft.AspNetCore.Mvc;

namespace HandIn3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserDAO UserDao;

        public UserController(UserDAO userDao)
        {
            this.UserDao = userDao;
        }

        [HttpGet]
        public async Task<ActionResult<User>> getUsers()
        {
            try
            {
               IList<User> users =  await UserDao.getUsers();
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}