using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases.Requests;

namespace Assets.Scripts.Core.UseCases
{
    public class Initialize
    {
        private IUserRepository userRepository;
        private IIngredientRepository ingredientRepository;
        private IMealRepository mealRepository;
        public Initialize(IUserRepository userRepository, IIngredientRepository ingredientRepository, IMealRepository mealRepository) {
            this.userRepository = userRepository;
            this.ingredientRepository = ingredientRepository;
            this.mealRepository = mealRepository;
        }

        public void Execute(InitializeRequest request)
        {
            userRepository.Create(request.Money);
            ingredientRepository.AddIngredientTypes(request.IngredientTypes);
            ingredientRepository.AddIngredients(request.Ingredients, Owner.None);
            mealRepository.AddRecipes(request.Recipes);
        }
    }
}
 