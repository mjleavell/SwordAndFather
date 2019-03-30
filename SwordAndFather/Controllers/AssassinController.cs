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
    public class AssassinController : ControllerBase
    {
        // Fields
        readonly CreateAssassinRequestValidator _validator;
        readonly AssassinRepository _assassinRepository;

        // Controller
        public AssassinController()
        {
            _validator = new CreateAssassinRequestValidator();
            _assassinRepository = new AssassinRepository();
        }

        // Attribute
        [HttpPost]
        // AddAssassin Method
        public ActionResult AddAssassin(CreateAssassinRequest request)
        {
            // Validate input
            if (!_validator.Validate(request))
            {
                return BadRequest();
            }

            var newAssassin = _assassinRepository.AddAssassin(request.CodeName, request.Catchphrase, request.PreferredWeapon);

            return Created($"api/Assassin/{newAssassin.Id}", newAssassin);
        }

    }

    public interface IValidator<TToValidate>
    {
        bool Validate(TToValidate objectToValidate);
    }
}