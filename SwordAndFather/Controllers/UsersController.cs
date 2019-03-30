using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordAndFather.Data;
using SwordAndFather.Models;

namespace SwordAndFather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // fields
        readonly UserRepository _userRepository;
        readonly CreateUserRequestValidator _validator;

        // property
        public UsersController()
        {
            var _validator = new CreateUserRequestValidator();
            var _userRepository = new UserRepository();
        }


        [HttpPost("register")]
        // asp.net is creating user for us.
        // Bad Request and Crated methods are getting inherited from the base class; ActionResult doesnt necessarily need a type
        //public ActionResult<int> AddUser(User newUser)
        public ActionResult<int> AddUser(CreateUserRequest createRequest)
        {

            if (!_validator.Validate(createRequest))
            {
                // below is how you create a new anonymous type; have to return bad request in order for it to actually be seen
                return BadRequest(new { error = "users must have a username and password" });
            }

            var newUser = _userRepository.AddUser(createRequest.Username, createRequest.Password);

            // ****HTTP Response****
            // Created method is a method that gives us 201
            return Created($"api/users/{newUser.Id}", newUser);
        }
    }
}