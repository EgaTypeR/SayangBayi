using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Meal
    {
        //field
        private int meal_id;
        private string meal_name;
        private List<Ingredients> ingredients;

        //properties
        public int MealID { get { return meal_id; } }
        public string MealName { get { return meal_name; } set { meal_name = value; } }
        public List<Ingredients> Ingredients { get { return ingredients; } set { ingredients = value;} }


        //method
        public void addItem()
        {
            //code
        }
        public void removeItem()
        {
            //code
        }
        public List<Ingredients> GetIngredients()
        {
            return null;
        }
    }
}
