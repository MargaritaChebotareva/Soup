using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Core.UseCases
{
    public class SellMeal
    {
        private IUserRepository userRepository;
        private IPresenter presenter;
        public SellMeal(IUserRepository userRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.presenter = presenter;
        }
        public void Execute(SellMealRequest sellMealRequest)
        {
            var user = userRepository.GetUser();
            if (user.Meals.Count <= sellMealRequest.Id)
            {
                presenter.Notify(new SellMealResult(false, null));
                return;
            }

            var meal = user.Meals[sellMealRequest.Id];
            user.Meals.RemoveAt(sellMealRequest.Id);
            user.AddMoney(meal.Price);
            userRepository.UpdateUser(user);
            presenter.Notify(new SellMealResult(true, meal));
        }
    }
}
