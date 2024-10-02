using Assets.Scripts.Core.Entities;
using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.Repositories;
using System.Collections.Generic;

namespace Assets.Scripts.Core.UseCases
{
    public class PrepareMeal
    {
        private IIngredientRepository ingredientRepository;
        private IRecipeRepository recipeRepository;
        private IPresenter presenter;
        public PrepareMeal(IPresenter presenter, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            this.presenter = presenter;
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public void Execute()
        {
            var recipes = recipeRepository.GetRecipes();
            var countBefore = recipeRepository.GetMealCount();

            foreach (var recipe in recipes)
            {
                if (CanPrepare(recipe.Composition))
                {
                    recipeRepository.AddMeal(recipe);
                    for (int i = 0; i < recipe.Composition.Length; i++)
                    {
                        for (int k = 0; k < recipe.Composition[i].Count; k++)
                            ingredientRepository.RemoveAny(recipe.Composition[i].Name);
                    }
                }
            }
            var countAfter = recipeRepository.GetMealCount();

            presenter.Notify(countBefore < countAfter ? new PrepareMealResponse(true, recipeRepository.GetMeals()) : new PrepareMealResponse(false, null));
        }

        private bool CanPrepare(IngredientAmount[] composition)
        {
            Dictionary<string, int> ingredients = new Dictionary<string, int>();
            foreach (var ingredientAmount in composition)
            {
                var key = ingredientAmount.Name;
                if (ingredients.ContainsKey(key))
                {
                    ingredients[key] += ingredientAmount.Count;
                }
                else
                {
                    ingredients[key] = ingredientAmount.Count;
                }
            }

            var keys = ingredients.Keys;

            foreach (var key in keys)
            {
                var count = ingredientRepository.GetIngredients(key).Length;
                if (count < ingredients[key])
                {
                    return false;
                }
            }
            return true;
        }

    }

}
