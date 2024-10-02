using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class InitializeRequest
    {
        public int Money { get; } 
        public string[] IngredientNames { get; } 
        public Ingredient[] Ingredients { get; } 
        
        public Recipe[] Recipes { get; }

        public InitializeRequest(int money, string[] ingredientNames, Ingredient[] ingredients, Recipe[] recipes)
        {
            Money = money;
            IngredientNames = ingredientNames;
            Ingredients = ingredients;
            Recipes = recipes;
        }
    }
}
 