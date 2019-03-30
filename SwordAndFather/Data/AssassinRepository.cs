using SwordAndFather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwordAndFather.Data
{
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
}
