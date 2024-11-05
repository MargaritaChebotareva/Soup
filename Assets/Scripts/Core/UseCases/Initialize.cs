using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases.Requests;

namespace Assets.Scripts.Core.UseCases
{
    public class Initialize
    {
        private IUserRepository userRepository;
        private IIngredientRepository ingredientRepository;
        private IRecipeRepository recipeRepository;
        public Initialize(IUserRepository userRepository, IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository) {
            this.userRepository = userRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
        }

        public void Execute(InitializeRequest request)
        {
            userRepository.Create(request.Money);
            ingredientRepository.AddIngredientTypes(request.IngredientTypes);
            ingredientRepository.AddIngredients(request.Ingredients, Owner.None);
            recipeRepository.AddRecipes(request.Recipes);
        }
    }
}
 