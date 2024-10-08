using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Controllers
{
    public class IngredientController
    {
        private IUserRepository userRepository;
        private IIngredientRepository ingredientRepository;
        private IPresenter presenter;
        public IngredientController(IUserRepository userRepository, IIngredientRepository ingredientRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.ingredientRepository = ingredientRepository;
            this.presenter = presenter;
            presenter.OnBuyIngredientResponce += OnBuyIngredientResponce;
        }

        private void OnBuyIngredientResponce(BuyIngredientResponse response)
        {

        }

        public void ClickOnIngredient(int id)
        {
            var buyIngredient = new BuyIngredient(userRepository, ingredientRepository, presenter);
            buyIngredient.Execute(new BuyIngredientRequest(id));
        }

    }
}