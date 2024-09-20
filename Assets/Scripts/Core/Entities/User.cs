using System.Collections.Generic;

namespace Assets.Scripts.Core.Entities
{
    public class User
    {
        public int Money { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Recipe> AvailableRecipes { get; private set; }
        public List<Recipe> Meals { get; private set; }

        public void AddMoney(int money)
        {
            Money += money;
        }

        public void RemoveMoney(int money)
        {
            Money -= money;
        }
    }
}