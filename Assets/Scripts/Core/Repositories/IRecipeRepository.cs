using Assets.Scripts.Core.Entities;

namespace Assets.Scripts.Core.Repositories
{
    public interface IRecipeRepository
    {
        Recipe GetRecipe(string name);

        Recipe[] GetRecipes();

        void UpdateRecipe(Recipe recipe);

        void AddRecipes(Recipe[] recipes);

        void AddMeal(Recipe recipe);

        Meal GetMeal(int id);

        Meal[] GetMeals();

        void RemoveMeal(int id);

        int GetMealCount();
    }
}
