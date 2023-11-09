using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayangBayi.Classes
{
    internal class Admin : User
    {
        // Constructor for the Admin class
        public Admin(string email, string username, string name, string password)
            : base(email, username, name, password)
        {
            
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

        public override void Register()
        {
            DbConnection connection = new DbConnection();


            try
            {
                connection.OpenConnection();

                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO users (email, username, name, user_pass, user_role) VALUES (@email, @username, @name, @password, 'admin')", connection.GetConnection()))
                {
                    // Provide values for the parameters
                    cmd.Parameters.AddWithValue("@email", this.email);
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Parameters.AddWithValue("@name", this.name);
                    cmd.Parameters.AddWithValue("@password", this.password);

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
        }
    }
}
