using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using SayangBayi;

namespace SayangBayi.Classes
{
    internal class User
    {
        public int userId { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        // Constructor
        public User(string email, string username, string name, string password)
        {
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
        public static User Register(string email, string username, string name, string password, string role = "user")
        {
            User newUser = new User(email, username, name, password);
            DbConnection connection = new DbConnection();

            try
            {
                connection.OpenConnection();

                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO users (email, username, name, user_pass, user_role) VALUES (@email, @username, @name, @password, 'user')", connection.GetConnection()))
                {
                    // Provide values for the parameters
                    cmd.Parameters.AddWithValue("@email", newUser.email);
                    cmd.Parameters.AddWithValue("@username", newUser.username);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", newUser.password);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
            return newUser;
        }

    }
}
