using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayangBayi.Classes
{
    internal class Baby
    {
        //fields
        private int babyId;
        private string username;
        private int age;
        private double weight;
        private double height;
        private double sleep_time;
        private string sex;
        private int userId;

        //properties
        public int babyID
        {
            get { return babyId; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double SleepTime
        {
            get { return sleep_time; }
            set { sleep_time = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        //methods
        public void RecordWeight(int newWeight)
        {
            //codes
        }

        public void RecordHeight(int newHeight)
        {
            //codes
        }

        public void RecordSleep_time(int newSleepTime)
        {
            //codes
        }

        //public MealPlan ChangeAge()
        //{
            //codes
        //}

        //constructor
        public Baby(string username, int age, double weight, double height, double sleep_time)
        {
            this.username = username;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.sleep_time = sleep_time;

        }

        public bool CreateBaby(User user)
        {
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO baby (username, age, weight, height, sleep_time, sex, user_id) VALUES (@username, @age, @weight, @height, @sleep_time, @sex, @userId)", connection.GetConnection()))
                {
                    // Provide values for the parameters
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Parameters.AddWithValue("@age", this.age);
                    cmd.Parameters.AddWithValue("@weight", this.weight);
                    cmd.Parameters.AddWithValue("@height", this.height);
                    cmd.Parameters.AddWithValue("@sleep_time", this.sleep_time);
                    cmd.Parameters.AddWithValue("@sex", this.sex);
                    cmd.Parameters.AddWithValue("@userId", this.userId);

                    cmd.ExecuteNonQuery();
                    return true;
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

        public void UpdateBaby()
        {
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();

                // Baby exists, update the existing one
                using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE baby SET username = @username, age = @age, weight = @weight, height = @height, sleep_time = @sleep_time, sex = @sex WHERE user_id = @userId", connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Parameters.AddWithValue("@age", this.age);
                    cmd.Parameters.AddWithValue("@weight", this.weight);
                    cmd.Parameters.AddWithValue("@height", this.height);
                    cmd.Parameters.AddWithValue("@sleep_time", this.sleep_time);
                    cmd.Parameters.AddWithValue("@sex", this.sex);
                    cmd.Parameters.AddWithValue("@userId", this.userId);
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

        public Baby()
        {
            this.babyId = 0;
            this.username = "My Baby";
            this.age = 0;
            this.weight = 0;
            this.height = 0;
            this.sleep_time = 0;
            this.sex = "";
    }
        public void GetBaby(User user)
        {          
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM baby WHERE user_id = @user_id", connection.GetConnection()))
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
                            this.sex = reader["sex"].ToString();
                            this.userId = Convert.ToInt32(reader["user_id"]);
                            // Add other properties as needed
                        }
                    }
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
