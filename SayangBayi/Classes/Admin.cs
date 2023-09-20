using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Admin : User
    {
        // Constructor for the Admin class, which calls the base class (User) constructor.
        public Admin(int userId, string username, string password, string email)
            : base(userId, username, password, email)
        {
            // Additional constructor logic specific to Admin can be added here if needed.
        }

        public void EditUser(User user, string newUsername, string newEmail)
        {
            user.EditProfile(newUsername, newEmail);
        }

        public void DeleteUser(User user)
        {
            // Delete from database
        }

        public void GrantUser(User user)
        {
            // Grant in database
        }
    }
}
