using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Controllers
{
    public class MealController
    {
        private IUserRepository userRepository;
        private IPresenter presenter;

        public void ClickOnMeal(int id)
        {
            var sellMeal = new SellMeal(userRepository, presenter);
            sellMeal.Execute(new SellMealRequest(id));
        }
    }
}