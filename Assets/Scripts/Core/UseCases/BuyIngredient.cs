using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Core.UseCases
{
    public class BuyIngredient
    {
        private IUserRepository userRepository;
        private IMarketplaceRepository marketplaceRepository;
        private IPresenter presenter;
        public BuyIngredient(IUserRepository userRepository, IMarketplaceRepository marketplaceRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.marketplaceRepository = marketplaceRepository;
            this.presenter = presenter;
        }

        public void Execute(BuyIngredientRequest request)
        {
            var user = userRepository.GetUser();
            var ingredient = marketplaceRepository.GetIngredient(request.Id);
            if (user.Money < ingredient.Price)
            {
                presenter.Notify(new BuyIngredientResult(false, null, null));
                return;
            }
            user.RemoveMoney(ingredient.Price);
            user.Ingredients.Add(ingredient);

            userRepository.UpdateUser(user);
            presenter.Notify(new BuyIngredientResult(true, user, ingredient));
        }
    }
}
