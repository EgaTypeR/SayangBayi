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
        protected string username { get; set; }
        protected string name { get; set; }
        protected string password { get; set; }
        protected string email { get; set; }
        // Constructor
        public User(string email, string username, string name, string password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
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
        public virtual void Register()
        {
            
            DbConnection connection = new DbConnection();


            try
            {
                connection.OpenConnection();

                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO users (email, username, name, user_pass, user_role) VALUES (@email, @username, @name, @password, 'user')", connection.GetConnection()))
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

        public bool Login()
        {
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username= @username AND user_pass= @password", connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Parameters.AddWithValue("@password", this.password);

                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        // Login successful
                        return true;
                    }
                    else
                    {
                        // Login failed
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
        }

    }
}
