using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Core.UseCases
{
    public class SellDish
    {
        private IUserRepository userRepository;
        private IPresenter presenter;
        public SellDish(IUserRepository userRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.presenter = presenter;
        }
        public void Execute(SellDishRequest sellDishRequest)
        {
            var user = userRepository.GetUser();
            if (user.ReadyDishes.Count <= sellDishRequest.Id)
            {
                presenter.Notify(new SellDishResult(false, null));
                return;
            }

            var dish = user.ReadyDishes[sellDishRequest.Id];
            user.ReadyDishes.RemoveAt(sellDishRequest.Id);
            user.AddMoney(dish.Price);
            userRepository.UpdateUser(user);
            presenter.Notify(new SellDishResult(true, dish));
        }
    }
}
