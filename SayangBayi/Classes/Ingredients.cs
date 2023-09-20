using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayangBayi.Classes
{
    internal class Ingredients
    {
        //field
        private int ingredient_id;
        private string ingredient_name;
        private List<string> nutrients;

        //properties
        public int IngredientID { get { return ingredient_id;} }
        public string IngredientName { get { return ingredient_name;} set { ingredient_name = value; } }
        public List<string> Nutrients { get { return nutrients;} set { nutrients = value; } }

        //method
        public void addIngredients()
        {
            //code
        }
        public void removeItem(int id)
        {
            //
        }
        public List<Ingredients> getItems()
        {
            return null;
        }
        public List<string> getNutrients()
        {
            return null;
        }
    }
}
