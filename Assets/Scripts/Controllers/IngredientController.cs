using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Controllers
{
    public class IngredientController
    {
        private IUserRepository userRepository;
        private IMarketplaceRepository marketplaceRepository;
        private IPresenter presenter;
        public void ClickOnIngredient(int id)
        {
            var buyIngredient = new BuyIngredient(userRepository, marketplaceRepository, presenter);
            buyIngredient.Execute(new BuyIngredientRequest(id));
        }
    }
}