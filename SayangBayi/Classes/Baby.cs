using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Baby
    {
        //fields
        private int babyId;
        private string username;
        private int age;
        private int weight;
        private int height;
        private int sleep_time;

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

        public int Weight
        {
            get { return weight; }
        }

        public int Height
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
    }
}
