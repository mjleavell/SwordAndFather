using SwordAndFather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwordAndFather.Data
{
    public class UserRepository
    {
        // static modifier (usually avoid unless absolutely necessary): The static modifier makes an item non-instantiable, 
        // it means the static item cannot be instantiated. 
        // If the static modifier is applied to a class then that class cannot be instantiated using the new keyword. 
        // If the static modifier is applied to a variable, 
        // method or property of class then they can be accessed without creating an object of the class
        static List<User> _users = new List<User>();

        public User AddUser(string username, string password)
        {
            var newUser = new User(username, password);

            newUser.Id = _users.Count + 1;

            _users.Add(newUser);

            return newUser;
        }
    }
}
