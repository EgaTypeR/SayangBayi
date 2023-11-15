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
        private int sleep_time;
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

        public int SleepTime
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

        public Baby GetBaby(User user)
        {
            Baby baby = new Baby();
            
            DbConnection connection = new DbConnection();
            try
            {
                connection.OpenConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM baby WHERE user_id = @user_id", connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@user_id", 4 /*user.userId*/);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the Baby object with data from the database
                            baby.babyId = Convert.ToInt32(reader["id"]);
                            baby.username = reader["name"].ToString();
                            baby.age = Convert.ToInt32(reader["age"]);
                            baby.weight = Convert.ToDouble(reader["weight"]);
                            baby.height = Convert.ToDouble(reader["height"]);
                            baby.sex = reader["sex"].ToString();

                            // Add other properties as needed

                            return baby;
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
            return null;
        }
    }
}
