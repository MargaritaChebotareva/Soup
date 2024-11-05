using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Repositories;

namespace Assets.Scripts.Services
{
    public class IngredientFacade
    {
        private IIngredientRepository ingredientRepository;
        public IngredientFacade(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public Ingredient[] GetIngredients()
        {
            return ingredientRepository.GetIngredients();
        }

    }
}
