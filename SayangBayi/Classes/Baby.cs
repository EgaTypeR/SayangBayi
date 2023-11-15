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

        //properties
        public int BabyID
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
        }

        public double Weight
        {
            get { return weight; }
        }

        public double Height
        {
            get { return height; }
        }

        public double SleepTime
        {
            get { return sleep_time; }
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

        public bool UpdateBaby()
        {
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO baby (username, age, weight, height, sleep_time, sex) VALUES (@username, @age, @weight, @height, @sleep_time, @sex)", connection.GetConnection()))
                {
                    // Provide values for the parameters
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Parameters.AddWithValue("@age", this.username);
                    cmd.Parameters.AddWithValue("@weight", this.weight);
                    cmd.Parameters.AddWithValue("@height", this.height);
                    cmd.Parameters.AddWithValue("@sleep_time", this.sleep_time);
                    cmd.Parameters.AddWithValue("@sex", this.sex);

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
        public Baby()
        {
            this.username = "";
            this.age = 0;
            this.weight = 0;
            this.height = 0;
            this.sleep_time = 0;
            this.sex = "unknown";
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
                            //baby.sex = reader["sex"].ToString();

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
