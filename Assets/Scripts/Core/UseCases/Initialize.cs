using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Core.UseCases
{
    public class Initialize
    {
        private IPresenter presenter;
        private IUserRepository userRepository;
        private IIngredientRepository ingredientRepository;
        private IRecipeRepository recipeRepository;
        public Initialize(IPresenter presenter, IUserRepository userRepository, IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository) {
            this.presenter = presenter;
            this.userRepository = userRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
        }

        public void Execute(InitializeRequest request)
        {
            var user = userRepository.Create(request.Money);
            ingredientRepository.AddIngredientNames(request.IngredientNames);
            ingredientRepository.AddIngredients(request.Ingredients, Owner.User);
            recipeRepository.AddRecipes(request.Recipes);
            presenter.Notify(new InitializeResponse(true));
        }
    }
}
 