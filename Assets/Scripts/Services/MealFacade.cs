using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Services
{
    public class MealFacade
    {
        private IRecipeRepository recipeRepository;
        public MealFacade(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public Meal[] GetMeals()
        {
            return recipeRepository.GetMeals();
        }
    }
}
