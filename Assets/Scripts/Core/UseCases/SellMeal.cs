using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Core.UseCases
{
    public class SellMeal
    {
        private IUserRepository userRepository;
        private IRecipeRepository recipeRepository;
        private IPresenter presenter;
        public SellMeal(IPresenter presenter, IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            this.presenter = presenter;
            this.userRepository = userRepository;
            this.recipeRepository = recipeRepository;   
        }
        public void Execute(SellMealRequest request)
        {
            var user = userRepository.Get();

            var meal = recipeRepository.GetMeal(request.Id);
            var price = recipeRepository.GetRecipe(meal.Name).Price;
            recipeRepository.RemoveMeal(request.Id);
            user.AddMoney(price);

            userRepository.Update(user);
            presenter.Notify(new SellMealResponse(true, recipeRepository.GetMeals()));
        }
    }
}
