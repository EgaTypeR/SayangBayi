/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Basic : User
    {
        public Baby baby { get; set; }

        // Constructor
        public Basic(int userId, string username, string password, string email)
            : base(userId, username, password, email){}


        //method
        public void setBayi()
        {
            this.baby = new Baby();
        }

        public void LogBabyData(Baby baby, int newWeight, int newSleepTime, int newHeight)
        {
            baby.RecordWeight(newWeight);
            baby.RecordSleep_time(newSleepTime);
            baby.RecordHeight(newHeight);
        }

        public Meal GenerateDailyMealPlan()
        {
            // Implementation for generating a daily meal plan
            return new Meal();
        }
    }
}
*/