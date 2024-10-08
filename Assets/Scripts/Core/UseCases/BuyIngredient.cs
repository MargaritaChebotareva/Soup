using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Core.UseCases
{
    public class BuyIngredient
    {
        private IUserRepository userRepository;
        private IIngredientRepository ingredientRepository;
        private IPresenter presenter;
        public BuyIngredient(IUserRepository userRepository, IIngredientRepository ingredientRepository, IPresenter presenter)
        {
            this.userRepository = userRepository;
            this.ingredientRepository = ingredientRepository;
            this.presenter = presenter;
        }

        public void Execute(BuyIngredientRequest request)
        {
            var user = userRepository.Get();
            var ingredient = ingredientRepository.GetIngredient(request.Id);
            var ingredientType = ingredientRepository.GetIngredientType(ingredient.Name);
            if (user.Money < ingredientType.Price)
            {
                presenter.Notify(new BuyIngredientResponse(false, null, null));
                return;
            }
            user.RemoveMoney(ingredientType.Price);
            ingredient.SetOwner(Entities.Owner.User);

            userRepository.Update(user);
            ingredientRepository.UpdateIngredient(ingredient);
            presenter.Notify(new BuyIngredientResponse(true, user, ingredient));
        }
    }
}
