using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordAndFather.Models;

namespace SwordAndFather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // instatiated list of new users
        List<User> _users = new List<User>();

        [HttpPost("register")]
        // asp.net is creating user for us.
        // Bad Request and Crated methods are getting inherited from the base class
        // ActionResult doesnt necessarily need a type
        //public ActionResult<int> AddUser(User newUser)
        public ActionResult<int> AddUser(CreateUserRequest createRequest)
        {
            //validation
            if (string.IsNullOrEmpty(createRequest.Username) && string.IsNullOrEmpty(createRequest.Password))
            {
                // below is how you create a new anonymous type
                // have to return bad request in order for it to actually be seen
                return BadRequest(new { error = "users must have a username and password" });
            }


            var newUser = new User(createRequest.Username, createRequest.password);

            newUser.Id = _users.Count + 1;

            _users.Add(newUser);

            //return newUser.Id;

            // Created method is a method that gives us 201
            return Created($"api/users/{newUser.Id}", newUser);
        }
    }
}