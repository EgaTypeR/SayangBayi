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

        public User()
        {
            this.userId = 2;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        /*public User Login()
        {
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users WHERE username = @username AND user_pass = @password", connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Parameters.AddWithValue("@password", this.password);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Login successful, retrieve user data
                            User user = new User
                            {
                                thi = Convert.ToInt32(reader["user_id"]),
                                Username = reader["username"].ToString(),
                                // Add other properties as needed
                            };

                            return user;
                        }
                        else
                        {
                            // Login failed
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connection.CloseConnection();
            }
        }*/


        /*public void GetUser(string username, string password)
        {
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users WHERE username = @user_id", connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@user_id", user.userId);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the Baby object with data from the database
                            this.babyId = Convert.ToInt32(reader["baby_id"]);
                            this.username = reader["username"].ToString();
                            this.age = Convert.ToInt32(reader["age"]);
                            this.weight = Convert.ToDouble(reader["weight"]);
                            this.height = Convert.ToDouble(reader["height"]);
                            this.sleep_time = Convert.ToDouble(reader["sleep_time"]);
                            //baby.sex = reader["sex"].ToString();

                            // Add other properties as needed
                        }
                    }
                }
            }
        }*/

    }
}
