using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Controllers
{
    public class MealController
    {
        private IUserRepository userRepository;
        private IRecipeRepository recipeRepository;
        private IPresenter presenter;

        public MealController(IUserRepository userRepository, IRecipeRepository recipeRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.recipeRepository = recipeRepository;
            this.presenter = presenter;
        }

        public void ClickOnMeal(int id)
        {
            var sellMeal = new SellMeal(presenter, userRepository, recipeRepository);
            sellMeal.Execute(new SellMealRequest(id));
        }
    }
}