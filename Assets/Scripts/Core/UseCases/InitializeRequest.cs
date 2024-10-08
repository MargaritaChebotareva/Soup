using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.UseCases
{
    public class InitializeRequest
    {
        public int Money { get; } 
        public IngredientType[] IngredientTypes { get; } 
        public Ingredient[] Ingredients { get; } 
        
        public Recipe[] Recipes { get; }

        public InitializeRequest(int money, IngredientType[] ingredientTypes, Ingredient[] ingredients, Recipe[] recipes)
        {
            Money = money;
            IngredientTypes = ingredientTypes;
            Ingredients = ingredients;
            Recipes = recipes;
        }
    }
}
 