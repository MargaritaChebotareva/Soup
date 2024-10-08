using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using Assets.Scripts.Core.UseCases;

namespace Assets.Scripts.Controllers
{
    public class LeverController
    {
        private IRecipeRepository recipeRepository;
        private IIngredientRepository ingredientRepository;
        private IPresenter presenter;

        public LeverController(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IPresenter presenter)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
            this.presenter = presenter;
        }

        public void ClickOnLever()
        {
            var prepareMeal = new PrepareMeal(presenter, recipeRepository, ingredientRepository);
            prepareMeal.Execute();
        }
    }
}