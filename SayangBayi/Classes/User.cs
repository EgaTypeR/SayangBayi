using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        private string password { get; set; }
        public string email { get; set; }

        // Constructor
        public User(int userId, string username, string password, string email)
        {
            this.userId = userId;
            this.username = username;
            this.password = password; 
            this.email = email;
        }

        //method
        public void EditProfile(string newUsername, string newEmail)
        {
            this.username = newUsername;
            this.email = newEmail;
        }
         
        public void ChangePassword(string newPassword)
        {
            this.password = newPassword;
        }
    }
}
