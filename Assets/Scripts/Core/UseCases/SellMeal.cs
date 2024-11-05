using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases.Requests;
using Assets.Scripts.Core.UseCases.Responses;

namespace Assets.Scripts.Core.UseCases
{
    public class SellMeal
    {
        private IUserRepository userRepository;
        private IMealRepository mealRepository;
        private IPresenter presenter;
        public SellMeal(IPresenter presenter, IUserRepository userRepository, IMealRepository mealRepository)
        {
            this.presenter = presenter;
            this.userRepository = userRepository;
            this.mealRepository = mealRepository;   
        }
        public void Execute(SellMealRequest request)
        {
            var user = userRepository.Get();

            var meal = mealRepository.GetMeal(request.Id);
            var price = mealRepository.GetRecipe(meal.Name).Price;
            mealRepository.RemoveMeal(request.Id);
            user.AddMoney(price);

            userRepository.Update(user);
            presenter.Notify(new SellMealResponse(true, userRepository.Get().Money, mealRepository.GetMeals()));
        }
    }
}
