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

            _assassinRepository.AddAssassin(request.CodeName, request.Catchphrase, request.PreferredWeapon);
        }
    }

    public class AssassinRepository
    {
        static readonly List<Assassin> Assassins = new List<Assassin>();
    
        public Assassin AddAssassin(string codeName, string catchphrase, string preferredWeapon)
        {
            var newAssassin = new Assassin(codeName, catchphrase, preferredWeapon);

            newAssassin.Id = Assassins.Count + 1;

            Assassins.Add(newAssassin);

            return newAssassin;
        }       
    }

    public class CreateAssassinRequestValidator
    {
        public bool Validate(CreateAssassinRequest request)
        {
            // if any of these are true, it isnt valid; same logic as createuser logic just written differently
            return !string.IsNullOrEmpty(request.Catchphrase) &&
                !string.IsNullOrEmpty(request.CodeName) &&
                !string.IsNullOrEmpty(request.PreferredWeapon);
        }
    }
}