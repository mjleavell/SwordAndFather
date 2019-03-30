using SwordAndFather.Data;
using SwordAndFather.Models;

namespace SwordAndFather.Controllers
{
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